# Robustez de layout y UI/UX de las vistas

Branch: `feat/ui-layout-robustness` · Delivery: un commit por tier, revisión del usuario entre tiers · Test runner: ninguno (sin tests en el repo; verificación = `dotnet build` 0 errores + capturas del usuario)

Objetivo: que ninguna vista se recorte ni se superponga al cambiar el tamaño de la ventana ni al
escalar la pantalla entre 100 % y 150 %, sin tocar el comportamiento: mismas vistas, mismos
controles, mismos handlers.

## Specs

S1 **Shell mínimo.** `PrincipalForm.MinimumSize` pasa de `700×400` a `900×640` y
`panelContenido.AutoScroll = true`. El contrato de `MostrarUserControl` no cambia: limpia
`panelContenido`, asigna `Dock = Fill` y agrega la vista.

S2 **Resguardo de scroll.** Una `UserControl` cuyo `MinimumSize` excede el área disponible de
`panelContenido` se ve completa con barras de desplazamiento, en lugar de recortarse en silencio.
Hoy no existe ningún `AutoScroll` en `Vista/`.

S3 **Login centrado.** El bloque de campos deja de estar descentrado: la columna de 300 px se
posiciona en `x = 192` sobre un `ClientSize` de 684 px (= `(684 - 300) / 2`). Se conserva
`FormBorderStyle.FixedSingle` con `MaximizeBox = false`: es un diálogo no redimensionable, así que
la fluidez interna no aporta y no se cambia la sensación de la ventana. `LoginForm` no se hace
redimensionable en esta feature.

S4 **Inicio fluido.** En `InicioVista`: `panelAccesos` (FlowLayoutPanel) se ancla
`Top|Left|Right`, estirando su ancho y conservando los márgenes de 40 px, y reacomoda sus botones
al angostarse por ser un flow panel; `lblPista` se ancla `Bottom|Left`; la vista lleva
`AutoScroll = true` y `MinimumSize = 750×450`.

S5 **Invariantes.** Sin renombres de controles, sin reconexión de handlers, sin cambios de lógica
en los `.cs` más allá de propiedades de layout. `DatabaseHelper`, `Modelo/` y `Controlador/` no se
tocan. Sin factory de formularios: la edición visual en el diseñador de WinForms sigue funcionando
en todas las vistas.

S6 **Criterio de aceptación** (por vista tocada): sin controles recortados, sin superposiciones,
sin posiciones negativas, tanto en el tamaño mínimo de ventana como maximizada; los anclajes
mantienen sus bordes; `MinimumSize` evita el colapso por debajo del contenido usable; 100 %, 125 %
y 150 % de escalado soportados (175 % o más, fuera de alcance). Antes/después por captura de
pantalla del usuario: sin captura previa no hay prueba de mejora.

S7 **Verificación.** `dotnet build` debe quedar en 0 errores antes de cada commit (el SDK existe en
`~/.dotnet/dotnet`, no está en `PATH`). La corrección visual la valida el usuario: este entorno
compila pero no renderiza WinForms.

S8 **Alcance y orden.** Tier 1 shell (`PrincipalForm`, `LoginForm`, `InicioVista`); Tier 2
`Vista/Ui/Theme.cs` + 11 `Carga*` + `DevolucionVista`; Tier 2b `CargaEmpleado` y `CargaVehiculo`
con cuerpo desplazable y barra de acción anclada abajo; Tier 3 las 11 `Lista*` con anclajes y
buscador uniforme, más `ReporteVista` en commit propio al final.

## Tasks

- [x] T1 — S1, S2 (PrincipalForm): `panelContenido.AutoScroll = true` y `MinimumSize` de
  `700×400` a `900×640`. Contrato de `MostrarUserControl` intacto. Evidencia: `956b105`.
- [x] T2 — S3 (LoginForm): los 5 controles del bloque pasan de `x = 176` a `x = 192`, el centro
  real de la columna de 300 px sobre 684. Evidencia: `956b105`.
- [x] T3 — S4 (InicioVista): `panelAccesos` anclado `Top|Left|Right` con `AutoScroll` propio para
  las filas que se envuelven; `lblPista` anclada `Bottom|Left`; vista con `AutoScroll` y
  `MinimumSize` 750×450. Evidencia: `956b105`.
- [x] T4 — S7 (cierre de tier 1): `dotnet build` → 0 errores, 220 advertencias (idénticas a la
  línea base, sin advertencias nuevas). Commit `956b105`. Capturas del usuario pendientes para S6.
- [ ] T5 — S8 Tier 2: `Theme.cs` + 11 `Carga*` + `DevolucionVista`.
- [ ] T6 — S8 Tier 2b: `CargaEmpleado` y `CargaVehiculo` con scroll y barra inferior.
- [ ] T7 — S8 Tier 3: `ListaModelo` (corrección de superposición), resto de `Lista*`, `ReporteVista`.

## Log

L1 (2026-11-04) Pedido original: *"find a skill for improving UI/UX layout design for this
windows form project"* y luego *"Skip the skill and go straight to auditing and fixing"*.

L2 (2026-11-04) Grilling, decisiones del usuario (todas aceptadas): estructura antes que estética;
alcance por tiers con corte de revisión entre cada uno; quirúrgico con `TableLayoutPanel` solo
donde haga falta; sin factory de formularios; se conserva la identidad visual actual; solo
propiedades de layout; escalado 100–150 % soportado; criterio de aceptación por capturas; convención
ODD existente; `LoginForm` incluido en el tier 1; `ReporteVista` en commit propio.

L3 (2026-11-04) Auditoría previa (explorador, 27 `Designer.cs`): todos los `UserControl` son
lienzos fijos de ~750×450 con `AutoScaleMode.Font` y sin `AutoScroll`; el host mide 900×476, así
que `CargaEmpleadoVista` (560 de alto) y `CargaVehiculoVista` (530) ya se recortan en el tamaño por
defecto. `PrincipalForm.MinimumSize` (700×400) es menor que su hijo más grande. Solo `Lista*` usa
anclajes. `ListaModeloVista.Designer.cs:116-129` superpone el filtro de marca sobre la grilla:
defecto real, no cosmético.

L4 (2026-11-04) Corrección de entorno: el doc `inicio-y-navbar.md` (L3) registra "no hay SDK"; sí
lo hay, en `~/.dotnet/dotnet` (10.0.100-rc.2), y `dotnet build` compila con 0 errores y 220
advertencias de nulabilidad. Desde ahora el cierre de cada tier exige build limpio en vez de solo
revisión del diff.

L5 (2026-11-04) Tier 1 cerrado en `956b105`. Tres cambios de designer, cero líneas de lógica:
`PrincipalForm` (scroll del host + mínimo de ventana), `LoginForm` (5 `Location` de 176 a 192),
`InicioVista` (dos anclajes + `AutoScroll` + `MinimumSize`). Build 0 errores, 220 advertencias sin
cambios respecto de la línea base. Queda pendiente la validación visual del usuario: el `AutoScroll`
del host depende de que el layout respete el `MinimumSize` de la vista hija; si en la captura no
aparece barra de desplazamiento cuando corresponde, se corrige en un commit de seguimiento antes de
seguir al tier 2.
