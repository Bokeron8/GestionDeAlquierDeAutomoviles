# Dashboard de reportes del gerente

Branch: master (commits directos) · Delivery: direct to master · Test runner: none (verificación manual del usuario)

Objetivo: que `ReporteVista` deje de ser un stub y muestre datos reales en los controles que ya
existen: cinco métricas y las grillas de reservas activas y vehículos disponibles.

## Specs

S1 **Alcance cerrado.** `Vista/ReporteVista.cs` carga datos en los controles ya declarados en
`Vista/ReporteVista.Designer.cs`: `lblMetricVehiculosVal`, `lblMetricClientesVal`,
`lblMetricEmpleadosVal`, `lblMetricAlquileresVal`, `lblMetricIngresosVal`, `dgvReservas`,
`dgvVehiculos`. No se agregan controles nuevos.

S2 **Métricas de conteo.** `Vehículos` = cantidad de vehículos con `activo = 1`;
`Clientes` = cantidad de clientes con `activo = 1`; `Empleados` = cantidad de empleados con
`activo = 1`; `Alquileres` = cantidad de alquileres con `activo = 1` (en curso ahora, no
histórico).

S3 **Ingresos.** Suma sobre los alquileres devueltos (`activo = 0`) cuya `fechaEntregaDevolucion`
cae en el mes calendario en curso, de
`precio_diario_pactado × máx(1, DATEDIFF(DAY, fechaEntregaReal, fechaEntregaDevolucion)) + montoMora`.
Un alquiler devuelto el mismo día cuenta como un día. Sin devoluciones en el mes, el valor es `0`.

S4 **Formato y textos.** `lblMetricIngresos` dice `Ingresos (mes actual):` y
`lblMetricAlquileres` dice `Alquileres en curso:`. El importe se muestra con
`ToString("C0", CultureInfo.GetCultureInfo("es-AR"))`; los conteos con `ToString()`.

S5 **Vehículos disponibles.** Vehículos con `activo = 1` que no tienen ningún alquiler con
`activo = 1` y no tienen una reserva con `activo = 1` en estado Pendiente o Confirmada cuyo rango
`[fecha_inicio_reserva, fecha_fin_reserva]` incluya la fecha de hoy. Ordenados por matrícula.
Un vehículo con reserva `En Curso` queda excluido por la condición del alquiler.

S6 **Reservas activas.** Reservas con `activo = 1` que están `En Curso`, o que están Pendiente o
Confirmada con `fecha_fin_reserva >= hoy`. Ordenadas por `fecha_inicio_reserva` ascendente
(lo más urgente arriba).

S7 **Columnas de las grillas.** `dgvReservas` muestra Cliente, Vehículo, Desde, Hasta y Estado;
`dgvVehiculos` muestra Matrícula, Marca y modelo y Categoría. El resto de las columnas generadas por
el binding queda oculta. El orden se fija con `DisplayIndex`, igual que en `ListaReservaVista`.
`Vehículo` usa la propiedad de presentación `Vehiculo.MarcaModelo`.

S8 **Arquitectura.** Las consultas viven en métodos estáticos de los modelos
(`Vehiculo.ObtenerDisponibles()`, `Reserva.ObtenerActivas()`, `Alquiler.ObtenerIngresos(desde, hasta)`).
`Controlador/ReporteController.cs` orquesta y devuelve `Modelo/ResumenDashboard.cs`.
`ReporteVista.Refrescar()` se dispara desde `PrincipalForm.MostrarReporteToolStripMenuItem_Click`.
Sin timer: se refresca al entrar por el menú.

S9 **Error de base de datos.** `Refrescar()` envuelve la carga en `try/catch`; ante una excepción
muestra un único `MessageBox` con `"No se pudo cargar el tablero. " + ex.Message`, título `Error`,
y deja las métricas en `0` y las grillas vacías. No propaga la excepción.

S10 **Verificación.** Este proyecto no tiene tests ni CI (decisión del usuario) y no se compila ni se
ejecuta en este entorno: el usuario prueba la aplicación manualmente y reporta. El cierre se hace por
revisión cruzada de cada spec contra el diff.

## Tasks

- [x] T1 — S2, S3, S5, S6, S7 (Modelo): `Vehiculo.ObtenerDisponibles()`, `Vehiculo.MarcaModelo`,
  `Reserva.ObtenerActivas()`, `Alquiler.ObtenerIngresos(desde, hasta)`, `Modelo/ResumenDashboard.cs`.
  Evidencia: +45 `Vehiculo.cs`, +36 `Reserva.cs`, +26 `Alquiler.cs`, archivo nuevo de 20 líneas;
  identificadores SQL cotejados contra `db_structure.sql`.
- [x] T2 — S8 (Controlador): `Controlador/ReporteController.cs` con `ObtenerResumen()`.
  Evidencia: 29 líneas; reutiliza `ObtenerActivos`/`ObtenerTodos`/`ObtenerEnCurso` existentes.
- [x] T3 — S1, S4, S7, S9 (Vista): `ReporteVista.Refrescar()`, textos y geometría de las métricas,
  `PrincipalForm` refrescando al abrir el reporte. Evidencia: `ReporteVista.cs` 10 → 143 líneas,
  Designer con dos textos y diez coordenadas nuevas, una línea en `PrincipalForm.cs:232`.
- [x] T4 — S10 (Cierre): log y espejo en Engram.

## Log

L1 (2026-11-04) Pedido original: *"Arrancao con el dashboar de reportes @grilling"*, con las
respuestas del grilling: *"2. Si funciona correctamente. 3. No, no haremos tests ni CI."*.
El usuario confirmó en dos rondas el árbol de decisiones completo ("todo correcto", "Correcto",
"Arranca").

L2 (2026-11-04) Decisiones cerradas en el grilling: alcance sin controles nuevos; métricas de
activos y alquileres en curso; ingresos devengados del mes; disponibilidad derivada; arquitectura
modelo-consulta + controlador orquestador; refresco por menú; `try/catch` con `MessageBox`.

L3 (2026-11-04) Ajuste de geometría en la fila de métricas: los textos nuevos
(`Alquileres en curso:` e `Ingresos (mes actual):`) no entraban entre las posiciones originales,
que dejaban 85 px y 110 px para las etiquetas. Se reubicaron las cinco parejas etiqueta/valor a
`25/91`, `175/235`, `300/369`, `445/575` y `640/776` conservando las fuentes 10F y 14F, para que
la fila completa entre en los 900 px del panel (`panelContenido` mide 900×476).

L4 (2026-11-04) Cierre. Sin `dotnet build` ni ejecución: no hay SDK ni Windows en este entorno y
así lo pidió el usuario. Verificación por revisión cruzada del diff contra S1–S9 y contra
`db_structure.sql`: `precio_diario_pactado`, `fecha_inicio_reserva`, `fecha_fin_reserva`,
`fechaEntregaReal`, `fechaEntregaDevolucion` y `montoMora` existen con esos nombres, y
`Alquiler.id_reserva` es la única vía al vehículo de un alquiler. Nombres de columnas del binding
cotejados contra las propiedades de `Reserva` y `Vehiculo` (incluida la nueva `MarcaModelo`).
