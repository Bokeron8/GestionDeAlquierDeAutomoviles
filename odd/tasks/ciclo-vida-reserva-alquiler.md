# Ciclo de vida de reserva y alquiler

Branch: `master` · Delivery: un commit por unidad de trabajo · Runner: ninguno (WinForms, verificación manual en Windows)

Objetivo: implementar el ciclo de vida completo `Pendiente → Confirmada → En Curso → Finalizada` (y `Cancelada`),
de punta a punta, sin migración de esquema.

## Specs

- **S1 — Estados fijos en código.** Los 5 estados se referencian por ID estable: `Pendiente=1`, `Confirmada=2`,
  `En Curso=3`, `Finalizada=4`, `Cancelada=5`, en `Modelo/EstadosReserva.cs`.
- **S2 — El estado no se elige a mano.** `CargaReservaVista` no expone el combo de estado. Una reserva nueva nace
  **Pendiente**; una edición conserva el estado cargado.
- **S3 — Solapamiento.** `ReservaController.ValidarReserva` rechaza el guardado cuando el mismo vehículo tiene otra
  reserva `activo = 1` en estado Pendiente/Confirmada/En Curso cuyo rango se cruza (extremos inclusivos).
  Mensaje exacto: `"El vehículo ya tiene una reserva en ese rango de fechas."`
- **S4 — Empleado desde la sesión.** `PrincipalForm` guarda el `Empleado` logueado y lo pasa a `CargaReservaVista`;
  el combo de empleado se reemplaza por el nombre en solo lectura. En edición se conserva el empleado original.
- **S5 — Confirmar.** Botón "Confirmar" en `ListaReservaVista`: Pendiente → Confirmada.
- **S6 — Entrega.** Solo reservas **Confirmada** aparecen en el combo de `CargaAlquilerVista` y solo esas se pueden
  entregar. Mensaje exacto: `"Solo se puede entregar una reserva confirmada."`
  Si `FechaEntregaReal` es anterior a `fechaInicioReserva` se bloquea:
  `"La fecha de entrega no puede ser anterior al inicio de la reserva."` Retiro tardío permitido.
  La entrega inserta el `Alquiler` y pasa la reserva a **En Curso** en una sola transacción.
- **S7 — Sin datos de devolución en la entrega.** `CargaAlquilerVista` deja de pedir combustible/km de entrada y mora.
  Al editar un alquiler conserva `FechaEntregaReal`, `FechaEntregaDevolucion`, entrada y mora ya cargados.
- **S8 — Devolución.** `DevolucionVista` (cabecera de solo lectura con Reserva #, Cliente, Vehículo, fecha de entrega,
  fecha de fin pactada y precio diario pactado; inputs de fecha de devolución, km entrada, combustible entrada, mora).
  Solo alquileres activos. Mensaje exacto: `"Solo se puede devolver un alquiler activo."`
  Mora calculada en vivo: `días de atraso × PrecioDiarioPactado`, editable.
  Al confirmar, en una sola transacción: cierra el `Alquiler` (`activo = 0`, fecha, km, combustible, mora) y pasa la
  reserva a **Finalizada**.
- **S9 — Devolución anticipada permitida**, con `montoMora = 0`.
- **S10 — Edición por estado.** Reserva editable solo en Pendiente/Confirmada. Confirmar y baja solo en
  Pendiente/Confirmada. En Curso/Finalizada/Cancelada son de solo lectura. Los botones se habilitan/deshabilitan
  según la fila seleccionada, no muestran error después del click.
- **S11 — Baja.** Reserva: estado **Cancelada** + `activo = 0`. Alquileres pierden el botón de baja: un alquiler solo
  se cierra devolviéndolo.
- **S12 — Listas legibles.** `ListaReservaVista` muestra el **nombre** del estado. `ListaAlquilerVista` muestra una
  columna **Estado** con "En curso"/"Devuelto" en lugar del booleano `Activo`.
- **S13 — Sin expiración automática.** Una reserva Confirmada que nadie retira se cancela a mano. No hay proceso
  en background.
- **S14 — Sin migración de datos.** La base se recrea con `db_datos_prueba.sql`.

## Tasks

- ☑ T1 — S1, S2, S3, S4: constantes de estado, solapamiento, quitar combo de estado, empleado de sesión. → `a8d7e71`
- ☑ T2 — S6, S7: entrega transaccional con transición a En Curso, combos y validaciones de entrega. → `01e1f1b`
- ☑ T3 — S8, S9, S12 (alquileres): `DevolucionVista`, transacción de devolución, finalización de la reserva, entrada desde la lista. → `724fa5e`
- ☑ T4 — S5, S10, S11, S12 (reservas): Confirmar, botones dinámicos, baja como Cancelada, nombres de estado. → `d83619b`
- ☑ T5 — Cierre: log, espejo en Engram, checklist de verificación manual.

## Verification

Observado en este entorno:

- Revisión cruzada de cada transición contra la spec y `grep` de referencias a controles/métodos eliminados: sin residuos
  (`cbEstado`, `cbEmpleado`, `txtMontoMora`, `btnEliminar` de alquileres, `Alquiler.Eliminar`, `Reserva.Eliminar`).
- **No ejecutado:** `dotnet build` (no hay SDK .NET en este entorno) ni la aplicación (WinForms + SQL Server Express).
  La compilación y la prueba funcional quedan pendientes de correr en Windows.

Checklist manual pendiente (Windows, base recreada con `db_datos_prueba.sql`):

1. Crear reserva → aparece como **Pendiente**, empleado tomado de la sesión, sin combo de estado.
2. Crear otra reserva para el mismo vehículo con fechas que se cruzan → error
   `"El vehículo ya tiene una reserva en ese rango de fechas."`
3. Confirmar reserva 1 → estado **Confirmada**; el botón Confirmar se deshabilita.
4. Entrega de reserva 1 → reserva pasa a **En Curso**, aparece el alquiler **En curso**.
5. Intentar entregar otra vez la misma reserva → ya no aparece en el combo.
6. Devolución con fecha posterior al fin pactado → mora calculada por día de atraso, reserva **Finalizada**.
7. Volver a reservar el mismo vehículo en las mismas fechas → permitido (la anterior está Finalizada).
8. Dar de baja una reserva Confirmada → **Cancelada** y editable deshabilitado.

## Log

- **L1 (pedido original, verbatim):** "Actualmente las vistas se adaptan correctamente al flujo que deberiamos tener
  para reservar y alquilar un vehiculo?"
- **L2 (verbatim):** "@grilling quiero que hagas el flujo correctamente del ciclo de vida desde generar la reserva a
  finalizar el alquiler"
- **L3:** Auditoría previa: `RegistrarDevolucionTransaccional` sin llamadores, `FechaEntregaDevolucion` nunca asignada
  desde la UI, estados elegibles libremente, sin validación de solapamiento, `FechaEntregaReal` pisada al editar.
- **L4:** Round 1 del grilling aprobado ("Todo sí"): transiciones en el controlador, Pendiente→Confirmada como paso
  explícito, IDs fijos, `DevolucionVista` separada, baja = Cancelada, rechazo de solapamiento, bloquear retiro
  anticipado, mora calculada, empleado de sesión, daños fuera de alcance.
- **L5:** Round 2 aprobado ("correcto"): edición según estado, devolución atómica sobre dos tablas, devolución
  anticipada permitida, sin expiración automática, un solo punto de entrada de entrega, nombres en listas, textos de
  error, verificación manual, sin migración.
- **L6:** Round 3 aprobado ("Todo sí"): `DevolucionVista`, acción de fila en `ListaAlquilerVista`, cabecera de solo
  lectura, mora en vivo, botones dinámicos, commits en `master` por unidad, CRUD de Estados sin cambios.
- **L7:** Desvío declarado: las constantes viven en `Modelo/EstadosReserva.cs` (no en `Controlador/`) porque
  `Modelo.Reserva` las necesita y no debe depender de `Controlador`.
- **L8:** Implementado y commiteado en cuatro unidades (`a8d7e71`, `01e1f1b`, `724fa5e`, `d83619b`).
  Sin compilación verificable en este entorno: se reporta como pendiente de `dotnet build` en Windows.
- **L9:** Desvío declarado: en la entrega la reserva también se mueve a En Curso dentro de la misma transacción
  (simetría con la devolución, aprobada en Q12). Sin esa atomicidad la entrega podía quedar sin transición.
