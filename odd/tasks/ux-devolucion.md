# UX de la devolución: terminología y control de datos

Objetivo: que la pantalla de devolución hable el idioma del operador ("al entregar" / "al
devolver" en vez de "salida" / "entrada"), no precargue datos engañosos y muestre en vivo los
valores que el gerente necesita controlar.
Verificación: `~/.dotnet/dotnet build` en 0 errores; la validación visual la hace el usuario en
Windows (este entorno compila pero no renderiza WinForms).

## Specs

S1 **Alcance.** `Vista/DevolucionVista.cs`, `Vista/DevolucionVista.Designer.cs`,
`Vista/CargaAlquilerVista.cs`, `Vista/CargaAlquilerVista.Designer.cs`,
`Controlador/AlquilerController.cs` (sólo textos de validación), `Modelo/ContratoAlquiler.cs` y la
consulta `Alquiler.ObtenerContrato`. Sin cambios de esquema: `combustibleSalida`,
`combustibleEntrada`, `kilometrajeSalida` y `kilometrajeEntrada` conservan su nombre en la base y
en el modelo.

S2 **Terminología de usuario.** "Salida" y "entrada" desaparecen de la interfaz y de los mensajes.
Etiquetas exactas: `Combustible al entregar (%)`, `Kilometraje al entregar (km)`,
`Kilometraje al devolver (km)`, `Combustible al devolver (%)`, `Fecha de devolución`,
`Mora por atraso (opcional)`.

S3 **Sin precarga del kilometraje.** `txtKilometrajeEntrada` arranca vacío: precargarlo con el
kilometraje de entrega permitía registrar 0 km recorridos sin aviso. Los datos de entrega se
muestran como referencia al lado del campo, con el formato exacto
`Al entregar: 45.230 km · 80% de combustible`.

S4 **Valores derivados en vivo.** Bajo los campos se muestran, cuando los datos alcanzan:
`Kilómetros recorridos: 412 km` y
`Combustible: entregado 80% → devuelto 60% (-20 puntos)`. Si el combustible vuelve por debajo del
entregado, la línea se muestra en rojo (`180, 40, 40`).

S5 **Validación inline.** El error se informa junto a los campos mientras se escribe, no en un
`MessageBox` al confirmar: kilometraje vacío o menor al de entrega, combustible vacío o fuera de
`0..100`, mora no numérica o negativa. `Confirmar Devolución` queda deshabilitado mientras haya
algún error o el alquiler no esté activo.

S6 **Formato y parseo.** La vista usa una única cultura `es-AR` explícita para parsear y para
mostrar importes (`C2`), en lugar de depender de la cultura del sistema: `$ 10.700,00`.

S7 **Layout.** El bloque de resumen financiero y el botón se reacomodan para dejar lugar a los
avisos; el `UserControl` mantiene `AutoScroll` con `MinimumSize` chico para que la vista scrollee
en vez de recortarse cuando el panel del `PrincipalForm` es más bajo que el contenido.

S8 **Invariantes.** No cambia el flujo transaccional (`RegistrarDevolucionTransaccional`), ni el
cálculo de mora, ni las reglas de `ValidarDevolucion`. Los nombres de los controles usados por
otras clases no cambian. `PrincipalForm` no se toca.

S9 **Verificación.** `dotnet build` en 0 errores y 0 warnings nuevos. El usuario valida en Windows:
los textos nuevos, la referencia de entrega, los derivados y el botón deshabilitado con datos
inválidos.

## Tasks

- [x] T1 — S2: renombrar etiquetas y mensajes en entrega y devolución. Ruta: inline.
- [x] T2 — S1, S3: `ContratoAlquiler.CombustibleSalida` + consulta, y quitar la precarga del
  kilometraje con la línea de referencia. Ruta: inline.
- [x] T3 — S4, S5, S6: derivados, validación inline, cultura `es-AR`. Ruta: inline.
- [x] T4 — S7, S9: layout, `dotnet build` y commit del work unit. Ruta: inline.

## Log

L1 (2026-11-10) — Pedido del usuario, verbatim: «Investigar si se puede mejorar la UX en los
textos por ejemplo combustible de entrada cuando se devuelve el vehiculo es confuso».

L2 — Evidencia recogida: `DevolucionVista.Designer.cs:97,116` decía `Kilometraje Entrada` y
`Combustible Entrada (%)` mientras la entrega decía `Combustible Salida` / `Kilometraje Salida`;
`DevolucionVista.cs:33` precargaba el kilometraje de devolución con el de entrega y dejaba el
combustible vacío; `AlquilerController.cs:38-52` validaba sólo al confirmar, con mensajes
"de salida" / "de entrada"; el resumen nunca mostraba kilómetros ni combustible; la moneda se
formateaba con `:0.00` mientras el tablero usa `C0`/`C2`.

L3 — Ronda 1 de diseño. Decisiones: renombrar sólo la interfaz (S1), sin precarga más línea de
referencia (S3), derivados en vivo (S4), validación inline (S5) y cultura `es-AR` acotada a esta
vista (S6). Respuesta del usuario, verbatim: «Todo es correcto».

L4 — Implementación cerrada. `dotnet build`: 0 errores, 0 warnings en los archivos tocados.
Pendiente: validación visual del usuario en Windows.

Pendiente anotado, fuera de alcance: `CargaAlquilerVista` conserva sus validaciones en
`MessageBox` al confirmar; sólo se renombraron sus etiquetas y mensajes.
