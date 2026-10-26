# Feature: Vistas de Estado, Rol y Danio

Branch: `master` (commits directos) · Delivery: direct to master · Test runner: none (verification = `~/.dotnet/dotnet build`)

## Specs

- **S1 Scope.** Wire the six existing stubs `CargaEstadoVista`, `ListaEstadoVista`, `CargaRolVista`, `ListaRolVista`, `CargaDanioVista`, `ListaDanioVista` with full parity to `CargaMarcaVista`/`ListaMarcaVista` (create, edit, logical delete with confirmation). Add `Controlador/DanioController.cs`. Add the missing `Refrescar()` calls and the three `CargarEdicion*` helpers in `Vista/PrincipalForm.cs`. No model, no schema, and no `Designer.cs` change other than the new `btnExaminar` in `CargaDanioVista.Designer.cs`.
- **S2 Pattern.** Each `Carga*Vista` mirrors `CargaMarcaVista`: a `private readonly <X>Controller _controller = new();`, a nullable `_<x>Editar` field, `Set<X>(<X>)`, `LimpiarFormulario()`, and a `btnGuardar_Click` with `try/catch`, validation messages joined with `"\n"`, and the success/error dialogs.
- **S3 DanioController.** Mirrors `MarcaController`: `List<string> ValidarDanio(Danio danio)`, `List<Danio> Listar()`, `Danio? BuscarPorId(int id)`, `int Guardar(Danio danio)`, `bool Eliminar(int id)`, plus `List<Alquiler> ObtenerAlquileres()` returning `Alquiler.ObtenerTodos()` (the same shape as `ModeloController.ObtenerMarcas`).
- **S4 Danio validation.** Exactly these messages, in this order: `"La zona es obligatoria."` when `Zona` is blank, `"La descripción es obligatoria."` when `Descripcion` is blank, `"Debe seleccionar un alquiler."` when `IdAlquiler <= 0`. `EvidenciaFotografica` is optional. No length checks.
- **S5 cbAlquiler.** `DisplayMember = "IdAlquiler"`, `ValueMember = "IdAlquiler"`, populated by a private `CargarAlquileres()` called from **both** `SetDanio` and `LimpiarFormulario` (the `CargarCombos()` precedent in `CargaReservaVista`). No `Format` handler, no computed model property.
- **S6 Evidence picker.** `CargaDanioVista.Designer.cs` gains `btnExaminar`: `Font("Segoe UI", 10F)`, `Location = (450, 300)`, `Size = (100, 25)`, `TabIndex = 10`, `Text = "Examinar..."`, added through `Controls.Add` like every other control; `btnGuardar.TabIndex` becomes 11. The click handler lives in the `.cs` (this project wires every `Click` in the constructor, never in the Designer) and uses `using var dlg = new OpenFileDialog()` with `Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp"`; on `DialogResult.OK` it writes `dlg.FileName` into `txtEvidencia`; cancelling leaves the current text untouched.
- **S7 Grid styling.** Every list mirrors `ListaMarcaVista`: `DataSource = null` then the list, `Refrescar()` public, column `HeaderText` in Spanish, `AutoSizeMode = DataGridViewAutoSizeColumnMode.None` set **before** `Width` (a previous NRE bug came from that order), width 50 for ID and 60 for Activo, every `Columns["X"]` access null-guarded.
  - `dgvEstados`: `IdEstado` → "ID", `Nombre` → "Estado", `Descripcion` → "Descripción", `Activo` → "Activo".
  - `dgvRoles`: `IdRol` → "ID", `NombreRol` → "Rol", `Descripcion` → "Descripción", `Activo` → "Activo".
  - `dgvDanios`: `IdDanio` → "ID", `IdAlquiler` → "Alquiler", `Zona` → "Zona", `Descripcion` → "Descripción", `EvidenciaFotografica` → "Evidencia", `Activo` → "Activo".
- **S8 PrincipalForm.** `ListarDaniosToolStripMenuItem_Click`, `ListarEstadosToolStripMenuItem_Click` and `ListarRolesToolStripMenuItem_Click` must call `.Refrescar()` after `MostrarUserControl` (today they do not). Add `public void CargarEdicionEstado(Estado estado)`, `public void CargarEdicionRol(Rol rol)` and `public void CargarEdicionDanio(Danio danio)` mirroring `CargarEdicionMarca`.
- **S9 Cross-file API contract** (several files are written in parallel, so these names are fixed):
  - `CargaEstadoVista`: `public void SetEstado(Estado estado)`, `public void LimpiarFormulario()`
  - `CargaRolVista`: `public void SetRol(Rol rol)`, `public void LimpiarFormulario()`
  - `CargaDanioVista`: `public void SetDanio(Danio danio)`, `public void LimpiarFormulario()`
  - `ListaEstadoVista`, `ListaRolVista`, `ListaDanioVista`: `public void Refrescar()`
  - `DanioController`: as in S3.
- **S10 UI copy.** Estado: `"Registrar Estado"` / `"Editar Estado"`, `"Guardar Estado"` / `"Actualizar Estado"`, `"Estado registrado correctamente."` / `"Estado actualizado correctamente."`, `"No se pudo guardar el estado."`, `"¿Desea dar de baja el estado {nombre}?"`, `"El estado {nombre} ya se encuentra inactivo."`. Rol: the same with "Rol"/"rol". Danio: `"Registrar Daño"` / `"Editar Daño"`, `"Registrar Daño"` / `"Actualizar Daño"`, `"Daño registrado correctamente."` / `"Daño actualizado correctamente."`, `"No se pudo guardar el daño."`, `"¿Desea dar de baja el daño de la zona {zona}?"`, `"El daño de la zona {zona} ya se encuentra inactivo."`.
- **S11 Verification.** `~/.dotnet/dotnet build --nologo -v q` → `0 Error(s)`; warning count must stay at the baseline of 155 (no new warnings). **Not met literally — see L12 for the measured deviation and the parity evidence.**

## Tasks

- [x] T1 `Vista/CargaEstadoVista.cs` + `Vista/ListaEstadoVista.cs` (S2, S7, S9, S10). Route: delegated writer, wave 1. Evidence: verifier PASS; committed in `b703dc3`.
- [x] T2 `Vista/CargaRolVista.cs` + `Vista/ListaRolVista.cs` (S2, S7, S9, S10). Route: delegated writer, wave 1. Evidence: verifier PASS; committed in `b703dc3`.
- [x] T3 `Vista/CargaDanioVista.cs` + `ListaDanioVista.cs` + `CargaDanioVista.Designer.cs` (S3, S5, S6, S7, S9, S10). Route: delegated writer, wave 1. Evidence: verifier PASS (geometry arithmetic and combo binding included); committed in `b703dc3`.
- [x] T4 `Controlador/DanioController.cs` (S3, S4). Route: delegated writer, wave 1. Evidence: verifier PASS on all six members; committed in `a980419`.
- [x] T5 `Vista/PrincipalForm.cs` (S8, S9). Route: delegated writer, wave 1. Evidence: verifier PASS, handlers now parallel to `ListarMarcasToolStripMenuItem_Click`; committed in `b703dc3`.
- [x] T6 Build + review (S11). Route: inline build + independent verifier. Evidence: `0 Error(s)`; warnings 155 → 191, spec deviation recorded in L12.

## Log

- **L1 (user, 2026-10-26):** "Si continuemos con las vistas, @grilling"
- **L2 (grilling R1, accepted):** full CRUD parity for the three entities, not read-only lists.
- **L3 (grilling R1, accepted):** create `DanioController`; the views never call the model directly.
- **L4 (grilling R1, accepted):** add the missing `Refrescar()` calls and the `CargarEdicion*` helpers in `PrincipalForm`.
- **L5 (grilling R1, accepted):** grid styling identical to `ListaMarcaVista`, preserving the `AutoSizeMode`-then-`Width` order that fixed the NRE bug.
- **L6 (grilling R2, accepted):** `cbAlquiler` shows the raw `IdAlquiler`, consistent with `cbReserva`; a readable label would have to cover both combos in a separate task.
- **L7 (grilling R2, accepted):** `Danio` validation messages fixed; evidence optional; no length checks.
- **L8 (user, 2026-10-26):** "7. utilizar openfiledialog." → evidence field gets an `Examinar...` button with `OpenFileDialog`.
- **L9 (grilling R3, accepted):** the dialog stores the absolute path as-is (no copy into `Recursos/`), filter `Imágenes|*.jpg;*.jpeg;*.png;*.bmp`, cancel keeps the previous text.
- **L10 (grilling R3, accepted):** `btnExaminar` is declared in `CargaDanioVista.Designer.cs` (hand-edited, same style as the generated code), not created in the constructor.
- **L11 (implementation, 2026-10-26):** wave 1 ran five bounded writers in parallel with disjoint edit surfaces (Estado views, Rol views, Danio views + Designer, `DanioController`, `PrincipalForm`). Because `PrincipalForm` references `SetEstado`, `SetRol` and `SetDanio`, the six view files and the form had to land in one commit: any split would have left a commit that does not compile. Commits: `a980419` (controller) and `b703dc3` (views + form).
- **L12 (deviation, 2026-10-26):** S11 is **not met literally**. Baseline was `0 Error(s)` / `155 Warning(s)`; current is `0 Error(s)` / `191 Warning(s)`. All 36 new warnings are inherited kinds with no new category: `CS8602` from the `Columns["X"]` nullability idiom that the six existing `Lista*` views already emit, and `CS8622` from the pre-existing `object sender` handler signature (`CargaVehiculoVista` has the same one). Per-file parity (unique warning locations): `ListaMarcaVista` 10, `ListaCategoriaVista` 11, `ListaModeloVista` 11, `ListaEstadoVista` 11, `ListaRolVista` 11, `ListaDanioVista` 13 (six columns instead of four). Keeping the mirrored idiom was chosen over fixing only the new files, which would leave two idioms for the same pattern. Decision left open: a separate mechanical pass over all twelve list views using `is DataGridViewColumn col` pattern matching would remove the whole `CS8602` family at once.
- **L13 (verification, 2026-10-26):** independent `gentle-ai-verify` over `d675598..HEAD`, in scratch copies outside the worktree. S1-S10 PASS, zero blockers. Column keys match the model properties, `DisplayMember`/`ValueMember` are `IdAlquiler` with `DataSource` assigned first, `btnExaminar` geometry does not overlap `txtEvidencia` or `btnGuardar` and stays inside the 750x420 control, `TabIndex` 10/11 unique, cross-file API names all resolve, UI copy matches S10 verbatim including accents, delete flow reads the `Activo` cell first, and `git diff --name-status d675598..HEAD` is exactly the nine expected paths with `Modelo/` untouched. Advisories carried forward unchanged from before this feature: saving an edit forces `Activo = true` (so editing a deactivated row reactivates it), and `Alquiler.ObtenerTodos()` has no `activo` filter, so `cbAlquiler` also lists inactive rentals.
