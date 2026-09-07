# AGENTS.md

## Project Overview

C# Windows Forms application for vehicle rental management. Targets .NET 10.0 with `Microsoft.Data.SqlClient` 7.0.2 connecting to SQL Server Express (`.\SQLEXPRESS`, database `GestionDeAlquilerDeAutomoviles`).

## Build & Run

- Build: `dotnet build`
- Run: `dotnet run` (launches the WinForms app)
- The `.slnx` solution file references the single `.csproj` project.

## Architecture

MVC pattern with incomplete controller layer:

- **`Modelo/`** — 11 POCO domain classes (Alquiler, Categoria, Cliente, Danio, Empleado, Estado, Marca, ModeloVehiculo, Reserva, Rol, Vehiculo). Each has `Id*` primary key properties and `public` access. Key fields: Empleado has `Usuario`/`Contrasenia`; Vehiculo has `Chasis`/`Color`; Reserva has `PrecioDiarioPactado`.
- **`Vista/`** — Windows Forms UserControls. Two naming patterns per entity:
  - `Carga*Vista.cs` — Create/edit forms (e.g., `CargaVehiculoVista`)
  - `Lista*Vista.cs` — List/display views (e.g., `ListaVehiculoVista`)
  - Each has a companion `*Designer.cs` auto-generated file.
  - All Vista classes are in namespace `GestionDeAlquierDeAutomoviles.Vista`.
- **`Controlador/`** — Empty directory. Controllers not yet implemented.
- **`DatabaseHelper.cs`** — Root-level static DB helper (`GestionDeAlquierDeAutomoviles` namespace). Provides `GetConnection()`, `ExecuteQuery()`, `ExecuteNonQuery()`, `ExecuteScalar()`. Connection string uses `TrustServerCertificate=True`.
- **`Program.cs`** — Entry point. Launches `PrincipalForm`.

## PrincipalForm Pattern

`PrincipalForm` uses `MostrarUserControl(UserControl uc)` to swap UserControls in `panelContenido`. It instantiates all Carga/Lista views in its constructor and wires them to menu items (e.g., `CargarVehiculoToolStripMenuItem_Click` → `MostrarUserControl(cargaVehiculo)`).

## Resource Handling

Images referenced via `Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Recursos", ...)`. The `auto.png` is set with `CopyToOutputDirectory: PreserveNewest` in the `.csproj`.

## Key Constraints

- `Nullable<enable>` and `ImplicitUsings<enable>` are active.
- `OutputType` is `WinExe` — this is a GUI application, not console.
- The `Controlador/` directory exists but is empty; adding controllers there is the expected extension pattern.
- No tests, no CI workflows, no README, no `opencode.json`, or `.editorconfig` exist yet.
- `.gitignore` is the standard Visual Studio template (ignores `bin/`, `obj/`, `*.user`, `*.suo`, etc.).
