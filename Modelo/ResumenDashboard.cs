using System;
using System.Collections.Generic;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class IngresosPorCategoriaDto
    {
        public string Categoria { get; set; } = "";
        public int CantidadAlquileres { get; set; }
        public decimal TotalIngresos { get; set; }
    }

    public class AlquilerFinalizadoDto
    {
        public int IdAlquiler { get; set; }
        public string Cliente { get; set; } = "";
        public string Vehiculo { get; set; } = "";
        public DateTime FechaEntrega { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public decimal MontoTotal { get; set; }
    }

    /// <summary>
    /// Read-only snapshot the manager dashboard renders: the counters, the income earned during
    /// the current month (plus the previous one, so the card can show the variation), the fleet
    /// occupancy, category-wise revenue breakdown, recent finalized rentals and the lists.
    /// </summary>
    public class ResumenDashboard
    {
        public int Vehiculos { get; set; }
        public int Clientes { get; set; }
        public int Empleados { get; set; }
        public int AlquileresEnCurso { get; set; }
        public int ReservasPendientes { get; set; }
        public decimal IngresosDelMes { get; set; }
        public decimal IngresosMesAnterior { get; set; }
        public decimal PorcentajeOcupacion { get; set; }
        public List<Reserva> ReservasActivas { get; set; } = [];
        public List<Vehiculo> VehiculosDisponibles { get; set; } = [];
        public List<IngresosPorCategoriaDto> IngresosPorCategoria { get; set; } = [];
        public List<AlquilerFinalizadoDto> AlquileresFinalizadosRecientes { get; set; } = [];
    }
}
