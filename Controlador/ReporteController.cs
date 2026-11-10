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

            return new ResumenDashboard
            {
                Vehiculos = Vehiculo.ObtenerActivos().Count,
                Clientes = Cliente.ObtenerActivos().Count,
                Empleados = Empleado.ObtenerTodos().Count(e => e.Activo),
                AlquileresEnCurso = Alquiler.ObtenerEnCurso().Count,
                IngresosDelMes = Alquiler.ObtenerIngresos(inicioMes, inicioMes.AddMonths(1)),
                ReservasActivas = Reserva.ObtenerActivas(),
                VehiculosDisponibles = Vehiculo.ObtenerDisponibles(),
                IngresosPorCategoria = Alquiler.ObtenerIngresosPorCategoria(),
                AlquileresFinalizadosRecientes = Alquiler.ObtenerFinalizadosRecientes()
            };
        }
    }
}
