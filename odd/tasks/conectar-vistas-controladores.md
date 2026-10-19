# Task: Conectar Vistas Desfasadas con Controladores

## Goal
Conectar todas las vistas operativas principales (`CargaVehiculoVista`, `ListaVehiculoVista`, `CargaClienteVista`, `ListaClienteVista`, `CargaReservaVista`, `ListaReservaVista`, `CargaAlquilerVista`, `ListaAlquilerVista`) con sus respectivos controladores (`VehiculoController`, `ClienteController`, `ReservaController`, `AlquilerController`), eliminando SQL embebido en las vistas y utilizando el estándar de validaciones y operaciones establecido.

## Tasks
- [x] 1. Refactorizar `CargaAlquilerVista` y `ListaAlquilerVista` para usar exclusivamente `AlquilerController`.
- [x] 2. Implementar lógica y eventos en `CargaVehiculoVista` y `ListaVehiculoVista` con `VehiculoController`.
- [x] 3. Implementar lógica y eventos en `CargaClienteVista` y `ListaClienteVista` con `ClienteController`.
- [x] 4. Implementar lógica y eventos en `CargaReservaVista` y `ListaReservaVista` con `ReservaController`.
- [x] 5. Agregar métodos de navegación y edición en `PrincipalForm` para Vehiculo, Cliente y Reserva.
- [x] 6. Verificar compilación completa (`dotnet build`) sin errores.
