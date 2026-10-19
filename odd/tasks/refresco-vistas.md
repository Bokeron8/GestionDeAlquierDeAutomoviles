# Task: Refresco de datos en vistas tras navegación

## Goal
Fix stale data in `Lista*Vista` grids and `Carga*Vista` combos caused by cached
UserControl instances whose `Load` event only fires once. Replace the Load-based
loading with explicit `Refrescar()` calls driven by `PrincipalForm` menu handlers.

## Problem
`PrincipalForm.MostrarUserControl` reuses control instances (`panelContenido.Controls.Clear()`
does not dispose or recreate them), so the WinForms `Load` event fires exactly once per
instance. Data loaded in `*_Load` handlers goes stale: new rows never appear in lists and
combos keep their initial values (worst case: `CargaVehiculoVista` shown at startup freezes
its Model/Categoria combos for the whole session). Deleting a row while a search filter is
active also silently drops the filter.

## Agreed decisions (grilling session)
- No interfaces: explicit `public void Refrescar()` on each view, called from menu handlers.
- Remove `Load +=` subscriptions; single loading path (explicit call).
- `Refrescar()` preserves the active search filter (Empleado, Alquiler).
- Combo loading moves into `LimpiarFormulario()`; startup calls `cargaVehiculo.LimpiarFormulario()`.
- After saving, forms stay open (no auto-navigation back to the list).
- Delivery: commits directly to `master` (user decision), Conventional Commits.

## Route declaration
Inline direct (mechanical, already-understood edits; no unresolved design). Writer rule
not fired: every file change is a mechanical rename/removal, no research needed.

## Tasks
- [x] 1. Unit 1 — lists: replace `*_Load` with `public void Refrescar()` in the 8 `Lista*Vista`;
      filter-aware refresh in Empleado/Alquiler; PrincipalForm menu handlers call `Refrescar()`.
- [x] 2. Unit 2 — combos: move combo loading to `LimpiarFormulario()` in the 5 `Carga*Vista`
      with combos; startup `LimpiarFormulario()` for `cargaVehiculo`.

## Post-fix regression (reported by user running the app on Windows)
`NullReferenceException` in `ListaMarcaVista.Refrescar()` at the `Width = 60` assignment
(`DataGridViewBand.set_Thickness`), thrown from the menu handler.

Root cause: `Refrescar()` was called *before* `MostrarUserControl()`, so the grid had no
parent/layout when `Width` was assigned while `AutoSizeColumnsMode = Fill` was active
(`ListaMarcaVista.Designer.cs:44`). Evidence from the same failing run: the `IdMarca`
column set `AutoSizeMode = None` before `Width`, and that line did not throw; the `Activo`
column set `Width` directly with `Fill` still active and threw.

Fix (commit e0be406):
- Order inverted in all 8 menu handlers: show the control, then `Refrescar()`.
- `AutoSizeMode = None` set before every fixed `Width` (the proven-safe sequence from the
  `IdMarca` column), so the assignment no longer depends on grid layout state.

## Verification evidence
- Commit 8e3ce6b: build 0 errors (warnings 160 -> 152). `~/.dotnet/dotnet build`.
- Commit 4a40e10: build 0 errors (147 warnings); no `Load +=` left in Lista*/Carga* views;
  no `CargarDatos` references remain.
- `gentle-ai review assess`: risk high, `review_due: high_risk` — native review NOT run:
  the opencode runtime is not eligible (only claude-code/codex). Ordinary checks only.

## Acceptance criteria
- `~/.dotnet/dotnet build` reports 0 errors.
- No `Load +=` subscriptions remain in the touched views.
- Manual smoke test (user, Windows): new marca appears in menu list; new categoria appears
  in CargaVehiculo combo; baja with active filter keeps the filter.

## Progress
- Baseline build: 0 errors, 160 pre-existing warnings. `dotnet` not on PATH: use `~/.dotnet/dotnet`.
