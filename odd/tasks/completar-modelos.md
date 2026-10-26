# Feature: Completar funciones de los modelos + unicidad de catálogos

Branch: `master` (commits directos) · Delivery: single-pr N/A (commits directos a master) · Test runner: none (no test project; verification = `~/.dotnet/dotnet build` + SQL review against `db_structure.sql`)

## Specs

- **S1 Scope.** Complete the persistence surface of `Estado`, `Rol` and `Danio`; add duplicate-check methods to `Marca`, `Categoria`, `ModeloVehiculo`, `Estado`, `Rol`; wire those checks into the `Validar*` methods of `MarcaController`, `CategoriaController`, `ModeloController`, and the new `EstadoController` and `RolController`; add the matching `UNIQUE` constraints to `db_restricciones.sql`. Out of scope: the views `CargaEstadoVista`, `ListaEstadoVista`, `CargaRolVista`, `ListaRolVista`, `CargaDanioVista`, `ListaDanioVista`; any `DanioController`; any relational query such as `Danio.ObtenerPorAlquiler`.
- **S2 Pattern.** Every completed model must match `Modelo/Marca.cs` exactly: `public static List<T> ObtenerTodos()` returning `SELECT *` ordered by the human-readable column (`Danio` groups by `id_alquiler, zona` instead, since its listing is per rental), `public static T? ObtenerPorId(int id)`, `public static int Guardar(T)` as an upsert (`Id == 0` → `INSERT`, else `UPDATE`, returning rows affected), `public static bool Eliminar(int id)` as a logical delete (`UPDATE <Table> SET activo = 0 WHERE ...` returning `rows > 0`), and `private static T Map(DataRow row)`. `ObtenerTodos` never filters by `activo`.
- **S3 Activo.** `Rol` and `Danio` currently lack the `Activo` property although both tables have `activo BIT NOT NULL DEFAULT 1`. Add `public bool Activo { get; set; }` to both and map `row["activo"]` in `Map`.
- **S4 Duplicate checks.** Exact signatures and error messages:
  - `Estado.EsNombreDuplicado(string nombre, int? idExcluir = null)` → `"Ya existe un estado con ese nombre."`
  - `Rol.EsRolDuplicado(string rol, int? idExcluir = null)` → `"Ya existe un rol con ese nombre."`
  - `Marca.EsNombreDuplicado(string nombre, int? idExcluir = null)` → `"Ya existe una marca con ese nombre."`
  - `Categoria.EsNombreDuplicado(string nombre, int? idExcluir = null)` → `"Ya existe una categoría con ese nombre."`
  - `ModeloVehiculo.EsNombreDuplicado(string nombre, int idMarca, int? idExcluir = null)` → `"Ya existe un modelo con ese nombre para esa marca."`
  Each body mirrors `Vehiculo.EsMatriculaDuplicada`: `SELECT COUNT(*) FROM <Table> WHERE <col> = @<col>` plus `AND <pk> <> @idExcluir` when `idExcluir.HasValue`, returning `count > 0`. `ModeloVehiculo` also filters `AND id_marca = @id_marca`.
- **S5 Validator wiring.** Each `Validar*` first keeps its existing required-field checks, then appends the duplicate error only when the required value is present, passing `entidad.Id == 0 ? null : entidad.Id` as `idExcluir` so editing a record without renaming it does not self-collide.
- **S6 New controllers.** `EstadoController` and `RolController` mirror `MarcaController`: `Validar<X>(<X>)`, `Listar()`, `BuscarPorId(int)`, `Guardar(<X>)`, `Eliminar(int)`. Required-field messages: `"El nombre del estado es obligatorio."` and `"El nombre del rol es obligatorio."`.
- **S7 SQL.** Append section 12 to `db_restricciones.sql`, same plain-`ALTER` style as the rest of the file, preceded by commented verification `SELECT`s:
  - `ALTER TABLE Estado ADD CONSTRAINT UQ_Estado_Nombre UNIQUE (nombre);`
  - `ALTER TABLE Rol ADD CONSTRAINT UQ_Rol_Rol UNIQUE (rol);`
  - `ALTER TABLE Marca ADD CONSTRAINT UQ_Marca_Marca UNIQUE (marca);`
  - `ALTER TABLE Categoria ADD CONSTRAINT UQ_Categoria_Nombre UNIQUE (nombre);`
  - `ALTER TABLE Modelo ADD CONSTRAINT UQ_Modelo_Marca_Modelo UNIQUE (id_marca, modelo);`
- **S8 No exception handling.** `Guardar` must not catch `SqlException`. Duplicate protection comes from the pre-validation plus the constraint, not from swallowing errors.
- **S9 Verification.** (a) `~/.dotnet/dotnet build` finishes with 0 errors; (b) the new SQL is checked column-by-column against `db_structure.sql` and `db_restricciones.sql` (table names, column names, nullability, existing constraint names, FK order).

## Tasks

- [x] T1 `Modelo/Estado.cs` — full pattern + `EsNombreDuplicado` (S2, S4). Route: delegated (worker, parallel wave 1). Evidence: diff reviewed by parent, `ObtenerTodos` now maps through `Map`, +72/-15 lines.
- [x] T2 `Modelo/Rol.cs` — full pattern + `Activo` + `EsRolDuplicado` (S2, S3, S4). Route: delegated (worker, parallel wave 1). Evidence: diff reviewed, `Activo` added and mapped, `SELECT * FROM Rol ORDER BY rol`.
- [x] T3 `Modelo/Danio.cs` — full pattern + `Activo` (S2, S3). Route: delegated (worker, parallel wave 1). Evidence: diff reviewed, logical delete `activo = 0`, no duplicate check (no UNIQUE column).
- [x] T4 `Modelo/Marca.cs`, `Modelo/Categoria.cs`, `Modelo/ModeloVehiculo.cs` — duplicate-check methods only (S4). Route: delegated (worker, parallel wave 1). Evidence: additions only (+12/+12/+16 lines), `Modelo` scoped by `(id_marca, modelo)`.
- [x] T5 `db_restricciones.sql` — section 12 constraints (S7). Route: delegated (worker, parallel wave 1). Evidence: 5 constraints + 6 verification SELECT comments, sections 1-11 untouched.
- [x] T6 `Controlador/*` — wire validators, add `EstadoController` and `RolController` (S5, S6). Route: delegated (worker, wave 2). Evidence: build `0 Error(s)`, `else if` guards pass `Id == 0 ? null : Id`.
- [x] T7 Build + SQL review (S9). Route: inline (parent). Evidence: `~/.dotnet/dotnet build --nologo -v q` → `0 Error(s)`, warnings unchanged from the 155-warning baseline; every SQL identifier checked against `db_structure.sql`.

## Log

- **L1 (user, 2026-10-26):** "@grilling Quiero terminar de implementar las funciones de los modelos"
- **L2 (grilling R1, accepted):** scope is the three incomplete models only — `Estado`, `Rol`, `Danio`; controllers and stub views are separate work.
- **L3 (grilling R1, accepted):** replicate the `Marca` pattern exactly, including `Map`, upsert and logical delete.
- **L4 (grilling R1, accepted):** add the missing `Activo` property to `Danio` and `Rol` and map the column; `ObtenerTodos` keeps returning every row.
- **L5 (grilling R1, accepted):** verification is a clean `dotnet build` plus a manual SQL review against the schema files.
- **L6 (grilling R2, accepted):** `Danio.Eliminar` is a logical delete; no duplicate-name check was originally planned and no relational query is added (superseded for duplicates by L8).
- **L7 (grilling R2, accepted):** commits go directly to `master`, Conventional Commits, no AI attribution.
- **L8 (user, 2026-10-26):** "9. Extender a los demas tambien, agregando el codigo necesario para verificar que no sea duplicado." → `UNIQUE` constraints extend to `Marca`, `Categoria` and `Modelo` too, and the code that pre-validates duplicates must exist so the constraint surfaces as a form message instead of a raw `SqlException`.
- **L9 (grilling R4, accepted):** duplicate checks are wired into the controllers' `Validar*`; `Modelo` uniqueness is scoped to `(id_marca, modelo)`; `Guardar` does not catch `SqlException`; delivery is 6 commits (Estado, Rol, Danio, catalog models, controllers, SQL).
- **Baseline:** `master` at commit ahead of origin, `dotnet build` = 0 errors / 155 warnings, `dotnet` lives at `~/.dotnet/dotnet`, SQL Server not reachable from this Linux box.
- **L10 (verification, 2026-10-26):** independent `gentle-ai-verify` pass over `cf066b0..HEAD`: S1-S9 pass, no blockers. Build 0 errors and 155 warnings, warning set for unchanged files byte-identical to baseline. Advisories recorded: `Danio` ordering is composite (see revised S2); a soft-deleted name still blocks re-creation because `UNIQUE` cannot be filtered by `activo`; `Validar*` now issues one extra DB round-trip; the new controllers are unreachable from the UI until `CargaEstadoVista`/`CargaRolVista` exist.
- **L11 (RDD, 2026-10-26):** `gentle-ai review assess --cwd . --agent opencode --base-ref cf066b0 --committed-only` returned `risk: medium`, `review_due: false`, `review_due_reason: under_budget`. No native review transaction opened for this slice.
