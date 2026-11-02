# Daños y empleados: información completa y acciones recuperables

Branch: master · Delivery: work units on master · Test runner: none (manual on Windows)

Objetivo: que las pantallas de daños y de empleados muestren datos resueltos, no expongan la
contraseña, y permitan deshacer una baja.

Route: inline (no writer trigger; single coherent change over understood files).

## Specs

- **S1** — Columnas visibles de la lista de empleados: ID · Apellido · Nombre · DNI · Rol ·
  Teléfono · Correo · F. Contratación · Activo. Ocultas: Usuario, Contrasenia, Direccion,
  FechaNacimiento, IdRol, Descripcion.
- **S2** — El Rol de la lista es el nombre resuelto (`rol.rol` vía JOIN), no `id_rol`. La
  configuración de columnas debe nombrar las propiedades que genera el binding, en PascalCase;
  hoy usa snake_case y por eso el bloque entero es código muerto y la contraseña se muestra.
- **S3** — La contraseña nunca se muestra en ninguna grilla ni se precarga en el formulario de
  edición.
- **S4** — Lista de empleados con buscador en memoria (`FiltroBusqueda`) por DNI, apellido,
  nombre, usuario, rol e ID, sin distinguir mayúsculas ni acentos. Placeholder:
  `Buscar por DNI, apellido, nombre, usuario o rol...`. Sin label `Buscar:`.
- **S5** — La lista muestra empleados activos e inactivos. Un solo botón alterna entre
  `Dar de baja` y `Restaurar` según el estado de la fila seleccionada.
  `EmpleadoController.Restaurar` delega en `Empleado.Restaurar`.
- **S6** — En la carga de empleado, el campo de contraseña queda vacío al editar, con
  `PlaceholderText` `Dejar vacío para no cambiarla`, y hay un campo de repetición. Si los dos no
  coinciden, no se guarda y se avisa `Las contraseñas no coinciden.`
- **S7** — Validaciones nuevas: el empleado debe tener al menos 18 años y la fecha de
  contratación no puede ser anterior a la de nacimiento.
- **S8** — Columnas visibles de la lista de daños: ID · Cliente · Vehículo · F. Entrega · Zona ·
  Descripción · Evidencia · Activo. Ocultas: IdAlquiler, NombreCliente, DniCliente, EstadoAlquiler
  y EvidenciaFotografica. La columna Cliente muestra `DescripcionCliente`
  (`Pérez, Juan — DNI 30123456`); la de evidencia muestra `EvidenciaArchivo`, sólo el nombre del
  archivo.
- **S9** — Lista de daños con buscador en memoria por cliente, DNI, matrícula, zona, descripción
  y ID. Placeholder: `Buscar por cliente, DNI, matrícula, zona o descripción...`.
- **S10** — El combo de alquiler de la carga de daño muestra `#12 · Pérez, Juan · AB123CD` y
  lista sólo alquileres en curso (`activo = 1`). Al editar un daño cuyo alquiler ya se cerró, ese
  alquiler igual aparece (marcado `Devuelto`) y el combo queda deshabilitado, para que guardar no
  reasigne el daño a otro contrato.
- **S11** — Evidencia fotográfica: se valida que el archivo exista antes de guardar, se previsualiza
  en la columna derecha del formulario y se libera la imagen anterior antes de cargar la siguiente.
- **S12** — Editar un daño preserva su `Activo`; ya no lo reactiva en silencio. `Danio.Restaurar` +
  botón que alterna baja/restauración en la lista.
- **S13** — La zona del daño sigue siendo texto libre. Sin combo, sin constraint nuevo.
- **S14** — Tarjeta de sólo lectura en la carga de daño con cliente, vehículo, fecha de entrega y
  estado del alquiler, al estilo de `DevolucionVista` (Label blanco con borde).

## Tasks

- ☑ T1 — S2, S3, S5, S7 (empleado: modelo, controller y validaciones) → `b19eb59`
- ☑ T2 — S1, S4, S5 (lista de empleados: columnas, buscador y botón alterno) → `e02ece6`
- ☑ T3 — S3, S6 (carga de empleado: contraseña y confirmación) → `526d7c0`
- ☑ T4 — S8, S9, S12 (daño: modelo, controller y lista) → `3dcbdda` y `cef8715`
- ☑ T5 — S10, S11, S13, S14 (carga de daño: combo, tarjeta, miniatura) → `d83eaa0`
- ☑ T6 — Diferencial y cierre: documentación y espejo en Engram → este commit

## Log

**L1** — Pedido original del usuario, textual:

> Mejorar la vista de danios y de empleado

**L2** — Ronda 1 de preguntas. El usuario respondió `5. no` y `Si a todo`. Es decir: rechaza el
combo editable de zonas (S13 queda texto libre) y acepta las recomendaciones 1, 2, 3, 4, 6 y 7.

**L3** — Ronda 2. El usuario respondió `correcto`: se agrega el alquiler cerrado al combo al editar,
la miniatura va en la columna derecha libre, se agrega `Danio.Restaurar`, y entra el alcance de la
carga de empleado (contraseña vacía al editar, confirmación, validaciones de fechas).

**L4** — Hallazgos confirmados por lectura, no reportados por el usuario:

1. `ListaEmpleadoVista.Refrescar()` configura columnas `contrasenia`, `id_empleado`, `id_rol`,
   `activo`, `fecha_nacimiento`, `fecha_contratacion`, pero la grilla bindea `List<Empleado>`, que
   genera columnas en PascalCase. El bloque entero no hace nada y la contraseña se ve en texto
   plano. Las anchuras y los headers tampoco se aplican.
2. `CargaDanioVista.btnGuardar_Click` asigna `danio.Activo = true` siempre: editar un daño dado de
   baja lo reactiva sin avisar.
3. `Empleado.Restaurar` existe en el modelo pero no hay método en el controller ni botón que lo
   llame: la baja es irreversible desde la UI.

**L5** — Decisión de alcance: las contraseñas siguen en texto plano en la base. Ocultarlas y no
precargarlas es parte de S3, pero hashear exige migrar los datos existentes y tocar `ValidarLogin`,
y no se puede probar en este entorno. Queda como deuda técnica, fuera de esta feature.

**L6** — Verificación: el usuario prueba manualmente en Windows y reporta los errores. No se ejecuta
`dotnet build` acá. Chequeo por lectura al cerrar: balance de llaves y paréntesis en los Designer,
cada control referenciado declarado, y los JOINs nuevos no pueden perder filas porque todas las
tablas relacionadas usan baja lógica.

**L7** — Decisiones de implementación que no estaban en las specs:

- `Alquiler` comparte un `SelectConRelaciones` entre `ObtenerTodos`, `ObtenerEnCurso` y
  `ObtenerPorId`, para que las tres devuelvan los mismos campos resueltos. `ObtenerPorId` dejó de
  ser un `SELECT *` por la misma razón que en la feature anterior: la tarjeta y el combo necesitan
  el nombre, no el id.
- `Empleado.SelectConRol` cumple el mismo papel para las dos consultas de empleado.
- `Danio.EstadoAlquiler` sale de un `bool?`, no de un `bool`: si algún camino futuro vuelve a traer
  el daño con un `SELECT *`, la propiedad devuelve vacío en lugar de afirmar "Devuelto".
- Los JOINs con `Modelo` y `Marca` son seguros: `Vehiculo.id_modelo` y `Modelo.id_marca` son
  `NOT NULL` según `db_structure.sql`, así que un INNER JOIN no puede perder alquileres.
- `Danio.EvidenciaArchivo` usa `Path.GetFileName`: la ruta completa ocupaba la columna entera.
- La miniatura copia la imagen a un `Bitmap` nuevo y descarta el `MemoryStream`, porque
  `Image.FromStream` deja el archivo bloqueado mientras la imagen viva.
- El botón de baja conserva el nombre `btnEliminar` para no renombrar controles del Designer; su
  texto y su color cambian según el estado de la fila.

**L8** — Efecto colateral previsto y cubierto: las propiedades calculadas nuevas
(`Alquiler.DescripcionVehiculo`, `Alquiler.DescripcionCombo`, `Empleado.Descripcion`,
`Danio.EstadoAlquiler`, `Danio.EvidenciaArchivo`) generan columnas automáticas en cualquier grilla
bindada a esos modelos. `ListaAlquilerVista`, `ListaEmpleadoVista` y `ListaDanioVista` las ocultan
explícitamente cuando no deben verse.
