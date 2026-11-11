# Cierre del circuito de devolución y estadísticas de ingresos para el gerente
Feature de mejora en el flujo de alquileres, liquidación de devoluciones y tablero gerencial.

## Specs
- S1: El odómetro de entrada (`KilometrajeEntrada`) y el nivel de combustible de entrada (`CombustibleEntrada`) registrados en la devolución sirven para auditar el uso del vehículo (kilómetros recorridos = entrada - salida), actualizar el estado/mantenimiento de la flota y controlar posibles diferencias de combustible respecto a la salida.
- S2: La pantalla de devolución (`DevolucionVista`) debe mostrar en tiempo real un resumen financiero desglosado: cantidad de días cobrados (mínimo 1 día), subtotal de alquiler (días × precio diario pactado), monto de mora por días de atraso, y el **Total a Cobrar** (Subtotal + Mora) en un formato destacado para indicarle el monto exacto al cliente.
- S3: El tablero del gerente (`ReporteVista` / `ReporteController`) debe incluir estadísticas detalladas de ingresos (ingresos del mes, desglosados por categoría de vehículo y listado de alquileres finalizados recientes).

## Tasks
- T1: Crear documento de especificación ODD para el cierre del circuito y estadísticas (S1, S2, S3) [done]
- T2: Implementar cálculo y resumen financiero en tiempo real en DevolucionVista (S2) [done]
- T3: Ampliar ReporteController y ReporteVista con estadísticas detalladas de ingresos para el gerente (S3) [done]
- T4: Verificar integridad y compilación del sistema [done]

## Log
- L1: "Siento que el circuito no esta cerrado del todo correctamente y hay datos que no se definieron con exactitud que son. No esta definido al 100% como se calcula el costo final, no hay una pantalla que muestre cuanto se gano del alquiler ni un monto a decirle al cliente para que pague, tampoco se que exactamente son los datos de kilometro de entrada y combustible de entrada, o para que quiero, y la estadistica de cuanto gana para el gerente es necesaria."
- L6 (2026-11-11): Reconciliación del documento con el código. T2 quedó implementada en `5cc2e37`
  (resumen financiero en vivo) y ampliada en `e68a196` (kilómetros recorridos, diferencia de
  combustible, validación inline). T3 quedó implementada en `5cc2e37` y rediseñada en `b2435b8`
  (tarjetas de KPI y secciones del tablero). T4: `~/.dotnet/dotnet build` en 0 errores al cierre de
  `ae87898`.
