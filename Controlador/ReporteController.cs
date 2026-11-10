using System;
using System.Linq;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    /// <summary>
    /// Builds the manager dashboard snapshot. Reports only read, so there is no validation
    /// here: the controller is the single place that decides which query feeds each tile.
    /// </summary>
    public class ReporteController
    {
        public ResumenDashboard ObtenerResumen()
        {
            DateTime hoy = DateTime.Today;
            var inicioMes = new DateTime(hoy.Year, hoy.Month, 1);
            var inicioMesAnterior = inicioMes.AddMonths(-1);

            // Both counters are needed by the occupancy card and by the counter itself, so they
            // are read once instead of hitting the same query twice.
            int vehiculos = Vehiculo.ObtenerActivos().Count;
            int alquileresEnCurso = Alquiler.ObtenerEnCurso().Count;
            var reservasActivas = Reserva.ObtenerActivas();

            return new ResumenDashboard
            {
                Vehiculos = vehiculos,
                Clientes = Cliente.ObtenerActivos().Count,
                Empleados = Empleado.ObtenerTodos().Count(e => e.Activo),
                AlquileresEnCurso = alquileresEnCurso,
                ReservasPendientes = reservasActivas.Count(r =>
                    r.IdEstado == EstadosReserva.Pendiente || r.IdEstado == EstadosReserva.Confirmada),
                IngresosDelMes = Alquiler.ObtenerIngresos(inicioMes, inicioMes.AddMonths(1)),
                IngresosMesAnterior = Alquiler.ObtenerIngresos(inicioMesAnterior, inicioMes),
                PorcentajeOcupacion = vehiculos > 0
                    ? Math.Round(alquileresEnCurso * 100m / vehiculos, 0)
                    : 0m,
                ReservasActivas = reservasActivas,
                VehiculosDisponibles = Vehiculo.ObtenerDisponibles(),
                IngresosPorCategoria = Alquiler.ObtenerIngresosPorCategoria(),
                AlquileresFinalizadosRecientes = Alquiler.ObtenerFinalizadosRecientes()
            };
        }
    }
}
