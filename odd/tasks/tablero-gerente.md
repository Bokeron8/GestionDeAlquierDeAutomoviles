# Tablero del gerente

Objetivo: que `ReporteVista` sea un tablero de decisiones (no cuatro tablas apiladas), con KPIs de
operación, jerarquía visual y scroll vertical sin scroll horizontal.
Rama: `master` (fast-forward, sin PR). Verificación: `~/.dotnet/dotnet build` en 0 errores; la
validación visual la hace el usuario en Windows (este entorno compila pero no renderiza WinForms).

## Specs

S1 **Alcance cerrado.** Sólo `Vista/ReporteVista.cs`, `Vista/ReporteVista.Designer.cs`,
`Controlador/ReporteController.cs` y `Modelo/ResumenDashboard.cs`. No se toca `DatabaseHelper`, ni
SQL, ni `Modelo/*` de entidades: los datos salen de métodos existentes
(`Vehiculo.ObtenerActivos`, `Vehiculo.ObtenerDisponibles`, `Cliente.ObtenerActivos`,
`Empleado.ObtenerTodos`, `Alquiler.ObtenerEnCurso`, `Alquiler.ObtenerIngresos`,
`Alquiler.ObtenerIngresosPorCategoria`, `Alquiler.ObtenerFinalizadosRecientes`,
`Reserva.ObtenerActivas`).

S2 **Seis tarjetas de métricas** (se elimina la métrica de Empleados). Etiquetas exactas:
`Vehículos activos`, `Alquileres en curso`, `Reservas pendientes`, `Ingresos del mes`,
`Ocupación de flota`, `Clientes activos`. Valor: entero sin decimales; ingresos con `C0` en
`es-AR` (ej. `$102.100`); ocupación con el formato `16 de 26 · 61%`.

S3 **Reservas pendientes** = reservas activas en estado `Pendiente` o `Confirmada`
(`EstadosReserva.Pendiente = 1`, `EstadosReserva.Confirmada = 2`).

S4 **Ocupación de flota** = porcentaje redondeado de alquileres en curso sobre vehículos activos;
sin vehículos activos el porcentaje es `0`.

S5 **Variación de ingresos.** La etiqueta de la tarjeta de ingresos cambia según el mes anterior:
sin ingresos el mes anterior → `Ingresos del mes`; variación menor a medio punto →
`Ingresos del mes · sin variación`; en otro caso `Ingresos del mes · +12%` (signo explícito,
redondeo a entero).

S6 **Layout con scroll vertical.** `AutoScroll = true` en el `UserControl`, con
`MinimumSize = 300×240`: el control tiene que poder encogerse al tamaño del panel anfitrión para
que WinForms muestre la barra vertical en vez de recortar el contenido (un `MinimumSize` mayor que
el panel fuerza al control a crecer y el panel lo recorta sin scrollbar). El contenido vive en
`pnlContenido`, de `900×926`, `MinimumSize = 875×926` y anclado `Top|Left|Right`: a 875 de ancho
las dos columnas siguen sin solaparse, y por debajo de eso aparece scroll horizontal en vez de
recortes. Orden: título y acciones; dos filas de tres tarjetas; `Reservas Activas` a ancho
completo; `Ingresos por Categoría` y `Vehículos Disponibles` en dos columnas; `Alquileres
Finalizados Recientes` a ancho completo.

S7 **Columnas por allowlist.** Cada grilla muestra sólo las columnas declaradas por la vista y
oculta todas las demás. Esto elimina la columna residual `VehiculoDescripcion` que hoy se escapa
de la lista de ocultas hardcodeada (`ReporteVista.cs:85`) y evita que una propiedad nueva del
modelo vuelva a aparecer.

S8 **Estados vacíos.** Con la grilla sin filas se muestra un texto centrado sobre el área de la
grilla y la grilla queda visible: `Sin reservas activas`, `Sin ingresos registrados en el mes`,
`Sin vehículos disponibles`, `Sin alquileres finalizados en el mes`.

S9 **Refresco.** Botón `Actualizar` arriba a la derecha, anclado `Top|Right`, que vuelve a cargar
el tablero. Leyenda `Actualizado dd/MM/yyyy HH:mm` debajo, alineada a la derecha; se limpia a
`Sin datos` cuando la carga falla. `Refrescar()` sigue siendo público porque
`PrincipalForm` lo invoca al abrir la sección.

S10 **Patrón visual de la aplicación.** `lblTitulo` en `(25,20)` con Segoe UI 14 Bold y
`ForeColor 51,51,76`; grillas con `AutoSizeColumnsMode.Fill`, fondo blanco, `BorderStyle.None`,
header `51,51,76` con texto blanco bold 10F, filas 10F, selección `200,200,220`,
`RowHeadersVisible = false`, `ReadOnly`, `FullRowSelect`; botones `FlatStyle.Flat`,
`BackColor 51,51,76`, `ForeColor` blanco, alto 35; handlers conectados en el constructor y no en el
Designer; `BackColor 240,240,245` y `AutoScaleMode.Font` en el `UserControl`.

S11 **Tarjetas declaradas en el Designer.** Los seis paneles y sus etiquetas se declaran en
`ReporteVista.Designer.cs` con colores literales, como el resto de las vistas, para que sigan
siendo editables en el diseñador visual. `Theme.cs` queda reservado a controles construidos en
tiempo de ejecución (`InicioVista`), sin cambios.

S12 **Invariantes.** Sin cambios en `PrincipalForm`, sin reconexión de handlers externos, sin
consultas nuevas, sin migraciones. Los nombres de los controles de esta vista pueden cambiar; los
nombres que otras clases usan (`ReporteVista`, `Refrescar`) no.

S13 **Verificación.** `~/.dotnet/dotnet build` en 0 errores y 0 warnings nuevos. La corrección
visual la valida el usuario con captura de pantalla en Windows: al ancho mínimo no hay controles
recortados, no hay solapamientos y no aparece scroll horizontal.

S14 **Moneda en grillas.** Las columnas monetarias fijan `DefaultCellStyle.FormatProvider` con la
cultura `es-AR` explícita. Un `DataGridView` formatea con la cultura del hilo: en una máquina con
configuración regional de España, `Format = "C2"` imprimía `€` en las grillas mientras las tarjetas,
que usan la cultura explícita, imprimían `$`. El símbolo debe ser `$` con independencia de la
configuración regional del equipo.

## Tasks

- [x] T1 — S1, S3, S4, S5: `ResumenDashboard` + `ReporteController` con `ReservasPendientes`,
  `IngresosMesAnterior` y `PorcentajeOcupacion`. Ruta: inline. Evidencia: `ResumenDashboard.cs`
  39 → 41 líneas, `ReporteController.cs` 32 → 45 líneas; sin consultas nuevas.
- [x] T2 — S6, S10, S11: reescritura de `ReporteVista.Designer.cs` (seis tarjetas, cuatro
  secciones, botón y leyenda de refresco, estados vacíos). Ruta: inline. Evidencia:
  `ReporteVista.Designer.cs` 295 → 690 líneas, 43 controles declarados.
- [x] T3 — S2, S7, S8, S9: `ReporteVista.cs` con allowlist de columnas, estados vacíos, variación
  de ingresos y refresco. Ruta: inline. Evidencia: `ReporteVista.cs` 191 → 218 líneas,
  `MostrarColumnas` (+`EtiquetaIngresos`, +`btnActualizar.Click`).
- [x] T4 — S13: `dotnet build` y commit del work unit. Ruta: inline. Evidencia: 0 errores,
  0 warnings en los cuatro archivos tocados (234 warnings preexistentes en otras vistas).

## Log

L1 (2026-11-10) — Pedido del usuario, verbatim: «necesito mejorar la vista del gerente».

L2 — Ronda 1 de diseño: alcance (a) visual, (b) información y (c) robustez de layout — las tres;
sin gráficos en v1; autorizado tocar `ReporteController` y `ResumenDashboard`.

L3 — Respuesta del usuario, verbatim: «2. agrega scroll. lo demas ok». El scroll se acepta como
solución de layout; se descarta forzar todo el tablero dentro de 1366×768.

L4 — Ronda 2 de diseño: seis tarjetas con Empleados afuera, sin selector de período, stack de
ancho completo con Reservas primero, botón Actualizar con leyenda de hora y estados vacíos por
grilla. Respuesta del usuario, verbatim: «todo correcto, si me gstaria que respete el patron como
en las demas vistas».

L5 — Ronda 3: las tarjetas se declaran en el Designer (opción A) para mantener la edición visual.
Respuesta del usuario, verbatim: «correcto».

L6 — Evidencia del defecto que motiva S7: en la captura del usuario la grilla de reservas muestra
una columna recortada `culoDescrip...`, que es la cabecera de `Reserva.VehiculoDescripcion`
escapada de la lista de columnas ocultas. Otras `Lista*` comparten la fragilidad; quedan fuera de
alcance y se anotan como pendiente.

L7 — Implementación cerrada. `dotnet build` (SDK en `~/.dotnet`, no en `PATH`): 0 errores, 0
warnings en `ReporteVista.cs`, `ReporteVista.Designer.cs`, `ReporteController.cs` y
`ResumenDashboard.cs`. Pendiente: validación visual del usuario en Windows (al ancho mínimo, sin
recortes, sin solapamientos, sin scroll horizontal).

Pendiente anotado, fuera de alcance: las `Lista*` siguen ocultando columnas con una lista
hardcodeada (`ListaAlquilerVista.cs:72`, entre otras) y comparten la fragilidad que esta vista ya
corrigió con allowlist.

L8 (2026-11-10) — Revisión del usuario, verbatim: «asi se ve mas grande, y en pantalla mas chica la
parte de abajo se corta». Diagnóstico: `MinimumSize` del `UserControl` mayor que el panel
`panelContenido` de `PrincipalForm` (que aporta unos 660 px de alto útil) fuerza al control a
crecer por encima del panel, y el panel recorta en lugar de scrollear. Causa común a la versión
anterior y a la primera versión nueva. Corrección: S6 reescrita con `pnlContenido` interno de
tamaño fijo y `MinimumSize` chico en el `UserControl`; `dotnet build` 0 errores, 0 warnings en los
archivos tocados. La captura del usuario corresponde al build previo a `b2435b8`.
