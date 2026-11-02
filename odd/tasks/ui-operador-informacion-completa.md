# Interfaz del operador: información completa y búsqueda legible

Branch: `master` · Delivery: un commit por unidad de trabajo · Runner: ninguno (WinForms; el usuario prueba manualmente en Windows y reporta fallas)

Objetivo: que el operador nunca tenga que ver ni tipear un ID numérico para identificar un cliente,
un vehículo o una reserva. Toda referencia a otra entidad se muestra resuelta y legible, y toda lista
se puede buscar por los datos que el operador realmente conoce.

## Specs

- **S1 — Cadenas de presentación.** Formato único y reutilizado en combos, grillas y tarjetas:
  - Cliente: `Pérez, Juan — DNI 30123456`
  - Vehículo: `AB123CD — Toyota Corolla 2020`
  - Reserva (combo de entrega): `#42 · Pérez, Juan · AB123CD · 12/11 → 15/11`
  - Empleado: `Pérez, Juan`
- **S2 — Grillas sin FK crudos.** `ListaReservaVista` deja de mostrar `ID Cliente`, `ID Vehículo` e
  `ID Empleado` y muestra `Cliente`, `Vehículo` y `Empleado` resueltos. `ListaAlquilerVista` suma
  `Cliente` y `Vehículo`. `ListaVehiculoVista` reemplaza `ID Modelo` / `ID Categoría` por `Marca`,
  `Modelo`, `Categoría`. `ListaModeloVista` reemplaza `ID Marca` por `Marca`. Las columnas FK quedan
  ocultas, no eliminadas, porque el código lee el valor desde la celda.
- **S3 — Columnas visibles por grilla.**
  - Reservas: ID · Estado · Cliente · Vehículo · F. Inicio · F. Fin · Precio Diario · Empleado
  - Alquileres: ID · Estado · Cliente · Vehículo · Reserva · F. Entrega · F. Devolución · Mora
  - Vehículos: ID · Matrícula · Marca · Modelo · Categoría · Año · Color · Activo
  - Modelos: ID · Modelo · Marca · Activo
  - Ocultas: `Chasis`, `CombustibleSalida/Entrada`, `KilometrajeSalida/Entrada`, `Activo` de reservas
    y alquileres, e identificadores de otras entidades.
- **S4 — Combos descriptivos.** `CargaReservaVista` muestra clientes y vehículos con S1;
  `CargaAlquilerVista` muestra las reservas con S1.
- **S5 — Tarjeta de resumen en las cargas.** `CargaReservaVista` y `CargaAlquilerVista` muestran una
  tarjeta de solo lectura estilo `DevolucionVista` que se actualiza al cambiar la selección.
  - Reserva: cliente (nombre completo, DNI, teléfono, licencia y vencimiento), vehículo (matrícula,
    marca modelo año, color, categoría), rango pactado con cantidad de días, precio diario,
    total estimado, empleado, estado.
  - Entrega: reserva #, cliente completo, vehículo completo, rango pactado con días, precio diario,
    total estimado, estado de la reserva.
- **S6 — Total estimado.** `días = max(1, (fin.Date - inicio.Date).Days)`; total = días × precio diario.
  *Supuesto:* un rango de un mismo día se cobra como un día. Si el negocio cobra por día calendario
  transcurrido, se corrige acá.
- **S7 — Búsqueda por datos legibles.** Cada lista filtra en memoria por los campos que el operador
  conoce, sin distinguir mayúsculas ni acentos:
  - Reservas: ID, apellido, nombre, DNI, matrícula.
  - Alquileres: ID alquiler, ID reserva, apellido, nombre, DNI, matrícula.
  - Clientes: ID, apellido, nombre, DNI, correo.
  - Vehículos: ID, matrícula, marca, modelo.
  - Modelos: ID, modelo, marca.
- **S8 — Placeholder en cada buscador.** `txtBuscar.PlaceholderText` con el texto acordado:
  - Reservas: `Buscar por DNI, apellido, nombre, matrícula o ID...`
  - Alquileres: `Buscar por DNI, apellido, nombre, matrícula, N° alquiler o reserva...`
  - Clientes: `Buscar por DNI, apellido, nombre o correo...`
  - Vehículos: `Buscar por matrícula, marca, modelo o ID...`
  - Modelos: `Buscar por modelo, marca o ID...`
- **S9 — Buscadores faltantes.** Se agrega buscador a `ListaReservaVista`, `ListaVehiculoVista` y
  `ListaModeloVista`. Se conecta el `txtBuscar` de `ListaClienteVista`, que hoy existe en el Designer
  pero no filtra nada.
- **S10 — Combos filtran dados de baja.** Los combos de selección de `CargaReservaVista` usan clientes
  y vehículos con `activo = 1`. Las listas de gestión siguen mostrando todo.
- **S11 — Devolución consistente.** La cabecera de `DevolucionVista` usa las cadenas de S1 y suma DNI
  del cliente y marca/modelo del vehículo.
- **S12 — Aviso de licencia vencida.** En las tarjetas de reserva y entrega, si
  `Cliente.VencimientoLicencia` es anterior a la fecha de inicio de la reserva, se muestra un aviso en
  rojo. El aviso es un `Label` aparte, porque un `Label` de WinForms no permite colorear parte del texto.
- **S13 — Sin cambios de esquema.** Todo se resuelve con JOINs sobre el esquema existente.

## Tasks

- ☑ T1 — S1, S2, S3, S10 (modelo y controladores): propiedades de presentación en `Cliente`,
  `Vehiculo`, `ModeloVehiculo`, `Reserva` y `Alquiler`; JOINs en las consultas de listado y de carga
  por id; `ObtenerActivos` en los combos. → `209eba3` y `6c4cb27`
- ☑ T2 — S2, S3, S7, S8, S9 (listas): columnas resueltas, buscadores nuevos y arreglo del buscador
  muerto de clientes. → `209eba3`
- ☑ T3 — S4, S5, S6, S12 (cargas): combos descriptivos, tarjeta de resumen y aviso de licencia.
  → `6c4cb27`
- ☑ T4 — S11 y cierre: cabecera de `DevolucionVista`, log y espejo en Engram. → `69d8ee8`

## Verification

Este proyecto no se compila ni se ejecuta en este entorno (no hay SDK .NET y WinForms necesita Windows).
El usuario prueba manualmente y reporta. Cierre con revisión cruzada de cada spec contra el diff y
`grep` de referencias a columnas/propiedades que hayan quedado colgadas.

## Log

- **L1 (pedido original, verbatim):** "Necesito mejorar la interfaz para el operador, actualmente se
  muestra muy poca informacion y eso puede llevr a que se cometan errores humanos, entonces quiero por
  ejemplo en vez de solo mostrar el ID para un alquiler de la reserva o solo mostrar el nombre del
  cliente que realiza la reserva, mostrar apellido nombre dni, es decir mostrar informacion mas
  completa en todos los formularios mas similar a como se muestra el cuadro de registrar devolucion"
- **L2:** Confirmado el alcance por grilling: flujo operativo (Reserva, Alquiler, Devolución) más
  Vehículo y Modelo. Catálogos planos (Marca, Categoría, Estado, Rol, Daño) sin cambios.
- **L3:** Confirmado reemplazar el FK crudo por la columna resuelta y ocultar el ID, conservando el ID
  propio de la fila.
- **L4:** Confirmado combo descriptivo más tarjeta de resumen con total estimado.
- **L5 (verbatim):** "si es posible agregar como un placeholdeer que diga que datos se pueden usarde
  busqueda por ejemplo \"inserte dni/nombre/apellido/id...\""
- **L6:** Confirmado filtrar clientes y vehículos dados de baja solo en los combos de selección.
- **L7:** Formato de cadenas, columnas visibles, contenido de las tarjetas, textos de placeholder y
  enriquecimiento de `DevolucionVista` aprobados ("Todo correcto").
- **L8:** El usuario pidió no ejecutar verificaciones en este proyecto: él prueba manualmente y reporta
  los errores. No se bloquea el cierre por `dotnet build` pendiente.
- **L9:** Implementado y commiteado en tres slices. Sin compilar: no hay SDK .NET en este entorno y
  WinForms necesita Windows. Verificación hecha por lectura: balance de llaves/paréntesis en los
  Designer, cada control referenciado está declarado, y los JOINs nuevos no pueden perder filas porque
  todas las tablas relacionadas usan baja lógica (`activo BIT`), así que las filas siguen existiendo.
- **L10:** Hallazgo fuera de alcance, no corregido: `ListaModeloVista.cbMarcaFiltro` existe en el
  Designer en `(25, 300)` pero queda tapado por la grilla y no está conectado a ningún handler. Se
  reporta al usuario en lugar de tocarlo, porque el buscador de texto ya cubre la marca.
