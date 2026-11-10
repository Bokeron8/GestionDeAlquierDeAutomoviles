# Gestión de Alquiler de Automóviles

Aplicación de escritorio para administrar el alquiler de vehículos: flota, clientes, reservas, entregas, devoluciones, daños y personal, con permisos según el rol del empleado que inicia sesión.

**Materia:** Programación II
**Integrantes:** _(completar)_
**Año:** 2026

---

## 1. Qué problema resuelve

Una empresa de alquiler de autos necesita coordinar varias cosas a la vez: qué vehículos tiene disponibles, quién los reservó y para qué fechas, quién los retiró, cuándo y en qué condiciones los devolvió, qué daños se registraron y qué ingresos generó cada mes. Además, no todos los empleados deben poder hacer lo mismo: un mecánico carga daños, pero no debería dar de alta empleados ni ver los reportes de ingresos.

El sistema cubre ese circuito completo en una aplicación Windows Forms contra SQL Server. El objetivo del trabajo fue resolver el **ciclo de vida de una reserva y su alquiler** con reglas de negocio reales (solapamientos, estados, mora, transacciones) y no solo un ABM de tablas.

## 2. Funcionalidades

| Módulo | Qué permite |
|---|---|
| Inicio de sesión | Autenticación de empleados activos; el rol define el resto de la aplicación |
| Inicio | Pantalla de bienvenida con el nombre del empleado, su rol y accesos directos a las secciones habilitadas |
| Vehículos | Alta, edición, baja lógica y restauración; marca, modelo, categoría, chasis, matrícula, color y año |
| Catálogos | Marcas, modelos y categorías, con validación de duplicados |
| Clientes | ABM con DNI, licencia y vencimiento, contacto y domicilio |
| Empleados | ABM con usuario, rol y datos personales; baja lógica |
| Estados y Roles | ABM de los catálogos que gobiernan el ciclo de vida y los permisos |
| Reservas | Alta con cliente, vehículo, rango de fechas y precio diario pactado; confirmación, cancelación y control de solapamientos |
| Alquileres | Entrega del vehículo a partir de una reserva, con combustible y kilometraje de salida |
| Devoluciones | Registro de la devolución con combustible y kilometraje de entrada, cálculo de mora en vivo y cierre del alquiler |
| Daños | Registro de daños por zona sobre un alquiler, con descripción y evidencia fotográfica |
| Reportes | Panel del gerente: cantidad de vehículos, clientes y empleados activos, alquileres en curso, ingresos del mes, reservas activas y vehículos disponibles |

Las grillas de vehículos, clientes, empleados, reservas, alquileres, daños y modelos tienen buscador con filtrado en vivo, insensible a mayúsculas y acentos. Los catálogos chicos (marcas, categorías, estados y roles) no lo necesitan y muestran la lista completa.

Las bajas son lógicas: el registro queda inactivo y puede restaurarse desde la misma lista en 9 de las 11 grillas de listado. Las dos excepciones siguen la lógica del negocio: la baja de una reserva es una **cancelación** (`Cancelada`, sin restauración) y el alquiler no se da de baja porque se cierra con la devolución.

## 3. Reglas de negocio

Estas son las decisiones que hacen que el sistema no sea un CRUD plano:

- **El estado de una reserva no se elige a mano.** Toda reserva nueva nace `Pendiente`. El ciclo es `Pendiente → Confirmada → En Curso → Finalizada`, con `Cancelada` como salida lateral. Los IDs de estado son fijos en la base (`EstadosReserva`: 1 a 5) y se referencian por constante, así renombrar la etiqueta no rompe la lógica.
- **No se puede reservar dos veces el mismo vehículo en fechas superpuestas.** La validación compara el rango completo con extremos inclusivos contra las reservas activas en estado `Pendiente`, `Confirmada` o `En Curso`.
- **El empleado sale de la sesión, no de un combo.** El operador que reserva queda registrado automáticamente; no puede elegir a otro.
- **La entrega y la devolución son transaccionales.** La entrega crea el alquiler y mueve la reserva a `En Curso` en la misma transacción; la devolución actualiza el alquiler, calcula la mora y pasa la reserva a `Finalizada` en un único commit. Si algo falla, no queda un alquiler sin estado o una reserva cerrada sin devolución.
- **La mora se calcula por día de atraso.** Días de atraso por precio diario pactado, recalculada en vivo mientras se elige la fecha de devolución y editable si la empresa decide condonarla.
- **Una reserva solo se edita mientras está `Pendiente` o `Confirmada`.** En los demás estados la fila es de solo lectura y los botones de acción se deshabilitan.
- **La baja de una reserva es una cancelación**, no un borrado: el registro conserva su historia.
- **El rol define el menú y los accesos del inicio.** Las dos cosas leen la misma regla, así la pantalla de inicio nunca ofrece una sección que el menú esconde.

## 4. Arquitectura

El proyecto sigue el patrón **MVC** pedido por la cátedra, con una decisión de implementación que conviene aclarar: la persistencia vive en el modelo, no en el controlador.

```
Vista  ──>  Controlador  ──>  Modelo  ──>  DatabaseHelper  ──>  SQL Server
```

- **`Modelo/`** — las entidades (POCO) y su acceso a datos. Cada entidad expone métodos estáticos: `ObtenerTodos`, `ObtenerPorId`, `Guardar`, `Eliminar`, `Restaurar`, sus chequeos de duplicados y un `Map(DataRow)` privado que traduce la fila a objeto. Acá vive el SQL de cada entidad.
- **`Controlador/`** — no tiene estado. Valida (`List<string> ValidarX(...)`, donde una lista vacía significa "válido"), orquesta las operaciones y expone las acciones del ciclo de vida (`Confirmar`, `Cancelar`, `RegistrarEntrega`, `RegistrarDevolucionTransaccional`). No ejecuta SQL, con una excepción deliberada: `AlquilerController` abre una conexión y ejecuta las sentencias de entrega y devolución dentro de una transacción, porque esas operaciones tocan dos tablas a la vez. La vista nunca decide reglas de negocio.
- **`Vista/`** — Windows Forms. Dos formularios (`LoginForm` y `PrincipalForm`) y 25 controles de usuario: uno de carga y uno de lista por entidad, más devolución, reportes e inicio.
- **`DatabaseHelper`** — centraliza ADO.NET: cadena de conexión, `ExecuteQuery`, `ExecuteNonQuery`, `ExecuteScalar` y sus variantes con `SqlConnection` + `SqlTransaction` para las operaciones atómicas.

**Por qué la persistencia en el modelo y no en el controlador:** con un controlador por entidad, mover el SQL al controlador duplicaba mapeo y conexiones en doce archivos. Dejar el acceso a datos junto a la entidad mantiene una sola definición de cada tabla y deja al controlador con una responsabilidad clara: decidir si la operación es válida. La contra es que el modelo queda "gordo"; con un ORM o un repositorio por entidad se resolvería mejor, pero el alcance del trabajo pedía ADO.NET explícito.

**Flujo de una operación** (crear una reserva):

1. `CargaReservaVista` arma el objeto y llama a `ReservaController.Guardar`.
2. El controlador valida campos, coherencia de fechas, solapamiento y estado; devuelve la lista de errores.
3. Si no hay errores, delega en `Reserva.Guardar`, que ejecuta el `INSERT` parametrizado.
4. La vista refresca la grilla y muestra el mensaje de confirmación.

## 5. Modelo de datos

11 tablas, 10 claves foráneas y restricciones declaradas en la base, no solo en el código.

```
Rol       1 ── N  Empleado
Estado    1 ── N  Reserva
Empleado  1 ── N  Reserva
Cliente   1 ── N  Reserva
Vehiculo  1 ── N  Reserva
Marca     1 ── N  Modelo
Modelo    1 ── N  Vehiculo
Categoria 1 ── N  Vehiculo
Reserva   1 ── N  Alquiler
Alquiler  1 ── N  Danio
```

| Decisión | Motivo |
|---|---|
| Columna `activo` en todas las tablas | La baja lógica conserva el historial: una reserva cancelada o un cliente dado de baja siguen siendo consultables |
| `UNIQUE` en DNI, correo, usuario, matrícula, chasis y nombres de catálogos | La base es la última defensa; la aplicación valida antes para dar un mensaje claro, pero el dato no puede quedar inconsistente |
| `CHECK (activo IN (0,1))` y `CHECK (montoMora >= 0)` | Evitan estados imposibles incluso si se escribe directo en SQL |
| Índice único parcial `UX_Alquiler_Reserva_Activo` | Garantiza a nivel de base que una reserva no tenga dos alquileres activos |
| IDs fijos para `Estado` y `Rol` | El código referencia el ciclo de vida por constante; el nombre visible queda libre para cambiarse |

Los scripts están en el repositorio y se ejecutan en este orden: `db_structure.sql` (tablas), `db_restricciones.sql` (PK, FK, UNIQUE, CHECK, índices) y `db_datos_prueba.sql` (datos de ejemplo).

## 6. Tecnologías

- **C# / .NET 10** (`net10.0-windows`)
- **Windows Forms** para la interfaz
- **ADO.NET** con `Microsoft.Data.SqlClient` 7.0.2 — sin ORM, con consultas parametrizadas en todos los accesos
- **SQL Server Express** (`.\SQLEXPRESS`), autenticación integrada de Windows

## 7. Puesta en marcha

Requisitos: Windows, .NET 10 SDK, SQL Server Express y Visual Studio (o `dotnet` CLI).

1. Clonar el repositorio.
2. Crear la base `GestionDeAlquilerDeAutomoviles` en SQL Server Express.
3. Ejecutar los tres scripts en orden: `db_structure.sql`, `db_restricciones.sql`, `db_datos_prueba.sql`.
4. **Importante:** `db_datos_prueba.sql` trae comentado el bloque de `Estado`, `Rol` y `Empleado` porque en la base de desarrollo ya existían. Si la base se crea desde cero, hay que descomentar ese bloque (líneas 296–324) antes de ejecutar; sin roles ni empleados no se puede iniciar sesión.
5. Compilar y ejecutar con `dotnet run`, o abrir la solución `GestionDeAlquierDeAutomoviles.slnx` en Visual Studio.

Usuarios de prueba que crea ese bloque (contraseña `123456` en todos):

| Usuario | Rol | Qué ve |
|---|---|---|
| `admin` | Administrador | Todo, incluidos Estados y Roles |
| `gerente` | Gerente | Vehículos, catálogos, empleados y reportes |
| `operador` | Atención al Cliente | Clientes, reservas y alquileres |
| `mecanico` | Mecánico | Daños |
| `inactivo` | Administrador (inactivo) | Nada: sirve para probar que el login rechaza usuarios dados de baja |

## 8. Estructura del repositorio

```
GestionDeAlquierDeAutomoviles/
├── Controlador/              # 12 controladores: validación y orquestación
├── Modelo/                   # 11 entidades + modelos de lectura + EstadosReserva
├── Vista/                    # 2 formularios y 25 controles de usuario
│   ├── Theme.cs              # paleta y tipografías de los controles en runtime
│   └── FiltroBusqueda.cs     # búsqueda insensible a mayúsculas y acentos
├── DatabaseHelper.cs         # cadena de conexión y helpers de ADO.NET
├── Program.cs                # login y arranque del formulario principal
├── db_structure.sql          # creación de tablas
├── db_restricciones.sql      # PK, FK, UNIQUE, CHECK e índices
├── db_datos_prueba.sql       # datos de ejemplo
├── odd/                      # documentos de las features: especificación y bitácora
└── Recursos/                 # imágenes usadas por la interfaz
```

## 9. Decisiones y aprendizajes

- **ADO.NET explícito en lugar de un ORM.** Escribir el SQL y el mapeo a mano fue más trabajo, pero me obligó a entender qué viaja a la base, cómo se parametriza una consulta y qué devuelve cada operación.
- **Validar en dos capas.** La aplicación valida para dar un mensaje entendible; la base restringe para que el dato no pueda quedar mal. Aprendí que una validación solo en la interfaz es una sugerencia.
- **Transacciones donde el dato se parte en dos.** Entrega y devolución tocan dos tablas con una regla de negocio en el medio. Sin transacción, un error a mitad de camino dejaba el sistema en un estado que ninguna pantalla sabía mostrar.
- **Baja lógica como regla general.** Fue la decisión que más simplificó el resto: reportes, historial de reservas y auditoría de alquileres siguen funcionando aunque el registro esté inactivo. Solo la reserva y el alquiler tienen su propia salida, porque su baja es un cambio de estado y no un borrado.
- **Una sola fuente de verdad para los permisos.** Tener las reglas de rol en un único método evitó el bug clásico de "el menú lo esconde pero el inicio te deja entrar".
- **El layout como parte del trabajo.** Adaptar las vistas a distintas resoluciones (scroll, tamaños mínimos, anclajes) llevó más tiempo del previsto y me enseñó que en WinForms el diseñador no garantiza que la pantalla se vea bien en otra máquina.

## 10. Limitaciones y trabajo futuro

Soy consciente de lo que el sistema no resuelve todavía:

- **Sin pruebas automatizadas.** La verificación es manual. Es la deuda técnica más grande: el cálculo de mora y la validación de solapamientos son lógica pura y deberían tener tests.
- **Las contraseñas se guardan en texto plano.** Quedó así por alcance del trabajo; lo correcto sería un hash con salt (por ejemplo PBKDF2 o bcrypt).
- **La cadena de conexión está fija en `DatabaseHelper.cs`.** Debería salir a un archivo de configuración.
- **Sin índices dedicados en la mayoría de las claves foráneas.** El único índice explícito es el parcial de `Alquiler`. A la escala de los datos de prueba no se nota, pero es una mejora barata.
- **Los reportes son solo en pantalla.** No hay exportación a PDF ni a Excel.
- **Falta la validación funcional completa del ciclo reserva → alquiler** en una base recién creada, con el checklist de ocho pasos que dejé documentado en `odd/tasks/`.

## 11. Conclusión

El sistema resuelve el circuito completo de un alquiler de vehículos con reglas de negocio verificables: estados que no se pueden saltear, reservas que no se superponen, entregas y devoluciones atómicas y permisos por rol. La arquitectura en capas mantiene separadas la interfaz, las reglas y el acceso a datos, y las restricciones en la base sostienen la integridad incluso fuera de la aplicación.

Lo que más me sirvió del trabajo fue tener que justificar cada decisión: por qué una baja es lógica, por qué una operación va en transacción, por qué el estado no lo elige el usuario. Eso es lo que diferencia un ABM de un sistema.
