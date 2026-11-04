# Pantalla de inicio y orden del navbar

Branch: master (commits directos) · Delivery: direct to master · Test runner: none (verificación manual del usuario)

Objetivo: que la aplicación abra en una pantalla de bienvenida válida para cualquier rol —hoy abre
en el formulario de alta de vehículo— y que el menú siga el orden real de trabajo, con `Inicio`
primero y `Cerrar Sesión` al final.

## Specs

S1 **Arranque.** `PrincipalForm` abre en `InicioVista` para todos los roles. Deja de mostrar
`cargaVehiculo` en el constructor; cada `Carga*Vista` sigue llamando a su `LimpiarFormulario()`
desde el botón Agregar de su lista, así que no se pierde ninguna carga de combos.

S2 **Contenido de Inicio.** Muestra `Hola, {nombre y apellido}`, `Rol: {nombre del rol}`,
el título `Accesos rápidos` y un botón por sección habilitada. Si el empleado no tiene nombre,
el saludo es `Bienvenido`.

S3 **Nombre del rol.** `ValidarLogin` no une `Rol`, así que el nombre se lee una vez con
`Rol.ObtenerPorId(_idRol)`. Si la consulta falla, la pantalla queda sin línea de rol y no se
interrumpe el arranque de la sesión.

S4 **Permisos.** `Inicio` nunca ofrece una sección que el menú oculta: las reglas de rol viven una
sola vez en `PrincipalForm` (`EsAdmin`, `EsRecepcionista`, `EsMecanico`, `EsGerente`), y tanto
`ConfigurarMenuPorRol()` como `SeccionesDisponibles()` las leen. Recepcionista ve Clientes,
Reservas y Alquileres; mecánico ve Daños; gerente ve Vehículos, Empleados y Reportes; administrador
ve todo.

S5 **Navegación única.** El menú y los botones de Inicio abren la sección con el mismo
`AbrirSeccion(SeccionInicio)`, que muestra la vista y la refresca. Los ítems sin botón en Inicio
(Marcas, Modelos, Categorías, Cerrar Sesión) conservan su handler propio.

S6 **Orden del menú.** `Inicio · Vehículos · Marcas · Modelos · Categorías · Clientes · Reservas ·
Alquileres · Daños · Empleados · Estados · Roles · Reportes · Cerrar Sesión`. La visibilidad por rol
no cambia, solo el orden.

S7 **Verificación.** Sin tests ni CI por decisión del usuario; no se compila ni se ejecuta en este
entorno. Cierre por revisión cruzada del diff y prueba manual del usuario.

## Tasks

- [x] T1 — S2, S3 (Vista nueva): `Vista/InicioVista.cs` + `Vista/InicioVista.Designer.cs`, con el
  enum `SeccionInicio` y los botones generados por rol. Evidencia: 115 + 115 líneas, botones
  200×56 en un `FlowLayoutPanel` de 820×220 (tres por fila).
- [x] T2 — S1, S4, S5 (PrincipalForm): propiedades de rol, `ConfigurarMenuPorRol()` movido desde el
  Designer, `AbrirInicio()`, `AbrirSeccion()`, `SeccionesDisponibles()`, `NombreRolSesion()` y
  arranque en Inicio. Evidencia: los seis handlers con sección propia quedaron en una línea.
- [x] T3 — S6 (Designer): ítem `Inicio` y `AddRange` reordenado con `Cerrar Sesión` al final.
- [x] T4 — S7 (Cierre): log y espejo en Engram.

## Log

L1 (2026-11-04) Pedido original: *"ordena el navbar de gerente, y agrega una pantalla de inicio
general ya que todos los usuarios comienzan en la pantalla de agregar vehiculo"*.

L2 (2026-11-04) Decisión del usuario sobre el contenido de Inicio: saludo + accesos rápidos
filtrados por rol (opción b del grilling), no una pantalla vacía. El navbar se reordena sin
dropdowns, respetando la matriz de visibilidad existente.

L3 (2026-11-04) Cierre sin `dotnet build` ni ejecución (no hay SDK ni Windows en este entorno y así
lo pidió el usuario). Revisión cruzada: cada `Carga*Vista` sigue llamando a su `LimpiarFormulario()`
desde el Agregar de su lista (grep de `LimpiarFormulario` en las once listas), y el arranque en
Inicio no dejó ninguna referencia huérfana a `cargaVehiculo` en el constructor.
