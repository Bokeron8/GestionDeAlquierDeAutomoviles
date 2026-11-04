using System.Collections.Generic;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    /// <summary>
    /// Read-only snapshot the manager dashboard renders: the four counters, the income earned
    /// during the current month and the two lists that need no further querying.
    /// </summary>
    public class ResumenDashboard
    {
        public int Vehiculos { get; set; }
        public int Clientes { get; set; }
        public int Empleados { get; set; }
        public int AlquileresEnCurso { get; set; }
        public decimal IngresosDelMes { get; set; }
        public List<Reserva> ReservasActivas { get; set; } = [];
        public List<Vehiculo> VehiculosDisponibles { get; set; } = [];
    }
}
