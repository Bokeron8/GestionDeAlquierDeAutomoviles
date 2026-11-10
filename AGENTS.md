# AGENTS.md

## Project Overview

C# Windows Forms application for vehicle rental management (reservations, rentals, returns, damages, employees, reports).
Targets `net10.0-windows` with `Microsoft.Data.SqlClient` 7.0.2 against SQL Server Express (`.\SQLEXPRESS`, database `GestionDeAlquilerDeAutomoviles`).

## Build & Run

- Build: `dotnet build`
- Run: `dotnet run` (launches the WinForms app)
- Solution: `GestionDeAlquierDeAutomoviles.slnx` (single project).
- `EnableWindowsTargeting` is `true`, so the project *compiles* on Linux, but the app only *runs* on Windows with SQL Server Express reachable.
- This development environment has **no .NET SDK installed** (`dotnet-install.sh` is present but unused). `dotnet build` and any runtime check must happen on the user's Windows machine.
- Database scripts are run by hand, in this order: `db_structure.sql` → `db_restricciones.sql` → `db_datos_prueba.sql`.

## Architecture

Three layers plus a shared DB helper. It is **not** classic MVC: there are no controllers holding state, and views talk to controllers, which delegate to static persistence methods on the models.

- **`Modelo/`** — 11 entity POCOs (`Alquiler`, `Categoria`, `Cliente`, `Danio`, `Empleado`, `Estado`, `Marca`, `ModeloVehiculo`, `Reserva`, `Rol`, `Vehiculo`) plus three support types:
  - `ContratoAlquiler` — read model for the printable rental contract.
  - `ResumenDashboard` — read model for the manager dashboard.
  - `EstadosReserva` — stable IDs of the reservation lifecycle (`Pendiente=1`, `Confirmada=2`, `EnCurso=3`, `Finalizada=4`, `Cancelada=5`).
  Each entity owns its SQL: static `ObtenerTodos()`, `ObtenerPorId(int)`, `Guardar(T)`, `Eliminar(int)`, `Restaurar(int)`, duplicate checks (`EsDniDuplicado`, `EsUsuarioDuplicado`, `EsNombreDuplicado`, …) and a private `Map(DataRow)`.
- **`Controlador/`** — 12 controllers (`Alquiler`, `Categoria`, `Cliente`, `Danio`, `Empleado`, `Estado`, `Marca`, `Modelo`, `Reporte`, `Reserva`, `Rol`, `Vehiculo`). They hold **no state** and do not open connections: they validate and orchestrate.
  - Standard shape: `List<string> Validar<T>(T)` (empty list = valid), `List<T> Listar()`, `T? BuscarPorId(int)`, `int Guardar(T)`, `bool Eliminar(int)`, `bool Restaurar(int)`, plus combo feeders (`ObtenerRoles()`, `ObtenerMarcas()`, `ObtenerModelos()`, `ObtenerCategorias()`).
  - Lifecycle actions live here: `ReservaController.Confirmar/Cancelar/EsEditable`, `AlquilerController.RegistrarEntrega/RegistrarDevolucionTransaccional`.
- **`Vista/`** — Windows Forms. Two `Form`s (`LoginForm`, `PrincipalForm`) and 25 `UserControl`s:
  - `Carga*Vista` — create/edit form (e.g. `CargaVehiculoVista`), exposes `Set<T>(T)` and `LimpiarFormulario()`.
  - `Lista*Vista` — grid with search box, logical delete and restore, exposes `Refrescar()`.
  - `DevolucionVista` — return registration (mileage, fuel, live late fee).
  - `ReporteVista` — manager dashboard.
  - `InicioVista` — role-aware landing screen, declares `enum SeccionInicio`.
  - `Theme` — palette and fonts **for controls built at runtime only**; designer files keep their own literals on purpose, because the WinForms designer rewrites them on save.
  - `FiltroBusqueda` — shared case- and accent-insensitive matcher (`"perez"` finds `"Pérez"`).
  - Every `*Vista.cs` has a `*Designer.cs` companion (auto-generated, do not hand-edit except when adding a control).
- **`DatabaseHelper.cs`** (root, `internal`) — owns the connection string and creates every `SqlConnection`; transactional flows (`AlquilerController`) open one and pass it together with a `SqlTransaction`.
- **`Program.cs`** — login loop: `LoginForm.ShowDialog()` → `PrincipalForm(empleadoLogueado)`; closing the main form returns to login, cancelling exits.

## Data access

`DatabaseHelper` API:

- `GetConnection()` → new `SqlConnection`.
- `ExecuteQuery(string, SqlParameter[]?)` → `DataTable`.
- `ExecuteNonQuery(string, SqlParameter[]?)` → affected rows.
- `ExecuteNonQuery(string, SqlParameter[], SqlConnection, SqlTransaction)` → same, inside a caller-owned transaction.
- `ExecuteScalar(string, SqlParameter[]?)` and its transactional overload.

Rules:

- **Always parameterize** with `SqlParameter`; never concatenate user input into SQL. The codebase uses collection expressions: `[new SqlParameter("@id", id)]`.
- Multi-table writes (delivery, return, reservation status) run inside an explicit `SqlConnection` + `SqlTransaction` using the transactional overloads.
- The connection string is **hardcoded** at `DatabaseHelper.cs:10` (`Integrated Security=True`, `TrustServerCertificate=True`). There is no configuration file.
- Deletes are **logical**: `Eliminar` sets `activo = 0`, `Restaurar` sets it back to `1`. `Lista*` grids show every row, inactive included, with an `Activo` column; combo feeders use `ObtenerActivos()` (`Cliente`, `Vehiculo`) so a deactivated record cannot be selected.

## PrincipalForm pattern

- `MostrarUserControl(UserControl uc)` clears `panelContenido` and docks the control `Fill`.
- `AbrirSeccion(SeccionInicio)` shows a list view and calls its `Refrescar()`; every menu item and every home shortcut routes through it.
- `CargarEdicion<X>(X)` (and `CargarEdicionAlquiler(int)`, `CargarDevolucion(int)`) show the matching `Carga*`/`Devolucion` view. Child views navigate by calling `PrincipalForm.CargarEdicion<X>` or `MostrarCarga(uc)`.
- **Role rules have a single source of truth**: `ConfigurarMenuPorRol()` sets menu visibility and `SeccionesDisponibles()` builds the home shortcuts, so the landing screen can never offer a section the menu hides. Adding a section means touching both.
- Views are instantiated once in the constructor and reused.

## Roles and permissions

Role IDs are fixed in the `Rol` seed (`db_datos_prueba.sql`):

| id | Rol | Sees |
|----|-----|------|
| 1 | Administrador | everything, including Estados and Roles |
| 2 | Atención al Cliente | Clientes, Reservas, Alquileres |
| 3 | Mecánico | Daños |
| 4 | Gerente | Vehículos, Marcas, Modelos, Categorías, Empleados, Reportes |

## Reservation and rental lifecycle

`Pendiente → Confirmada → En Curso → Finalizada`, plus `Cancelada` as the outcome of cancelling or deactivating a reservation.

- A new reservation is always `Pendiente`; the state is never chosen by hand in `CargaReservaVista`.
- The employee is taken from the session (`ConfigurarSesion`), not from a selector.
- Overlapping reservations for the same vehicle are rejected (`Reserva.TieneSolapamiento`, inclusive range, only `Pendiente`/`Confirmada`/`EnCurso` rows).
- `Confirmar` moves `Pendiente → Confirmada`; delivery moves the reservation to `En Curso` and creates the rental in the same transaction; return computes the late fee per late day and closes both rows atomically.
- Only `Pendiente`/`Confirmada` reservations are editable; the other states are read-only and the row buttons enable/disable accordingly.

## UI conventions

- Every `Carga*`, `Lista*`, `DevolucionVista`, `InicioVista`, `ReporteVista` and `PrincipalForm` sets `AutoScroll = true` and a `MinimumSize`, so content is never clipped and the window cannot be shrunk into an unusable layout.
- List views share one search box position: `x = 400`, `width = 325`, with `FiltroBusqueda` behind it.
- Footer action buttons are anchored `Bottom` and centered; `x = 275` is the unified value.
- User-facing strings (labels, messages, grid headers) are **Spanish**, neutral register, and are asserted verbatim by the feature specs in `odd/tasks/`.
- Code comments follow the file they are in (mixed Spanish/English); new comments should match the surrounding file rather than switch language.

## Key constraints

- `Nullable<enable>` and `ImplicitUsings<enable>` are active; `OutputType` is `WinExe`.
- Only `Recursos/auto.png` is copied to output (`PreserveNewest`); images are loaded via `Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Recursos", ...)`.
- `.gitignore` is the standard Visual Studio template (`bin/`, `obj/`, `*.user`, `*.suo`).
- There is **no test project and no CI**. Verification is manual, on Windows.
- There is **no README**. This file is the entry point for contributors and agents.
- `odd/tasks/*.md` holds the feature documents (`Specs` with numbered `S#`, `Tasks`, `Log`). Read the relevant document before changing behavior it specifies.

## Delivery conventions

- The user tests the app on Windows by pulling `master`, so changes are committed to `master` (fast-forward, no PR flow). Feature branches are for local work only.
- Conventional Commit messages, no AI attribution.
- No `Co-Authored-By` trailers.

## Known gaps

- Manual checklist for the reservation → rental lifecycle (8 steps in `odd/tasks/ciclo-vida-reserva-alquiler.md`) has never been confirmed on Windows.
- Visual validation of layout tiers 2 and 3 (`odd/tasks/ui-layout-robustness.md`) is pending user screenshots.
- Zero automated tests.
- Connection string hardcoded in `DatabaseHelper.cs`.
- No indexes on foreign keys; the only explicit index is `UX_Alquiler_Reserva_Activo`.
