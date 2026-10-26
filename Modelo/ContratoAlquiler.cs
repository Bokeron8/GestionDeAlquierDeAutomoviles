using System;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    /// <summary>
    /// Read-only view of everything needed to close a rental: the rental itself plus the
    /// reservation contract it belongs to (client, vehicle, agreed dates and price).
    /// </summary>
    public class ContratoAlquiler
    {
        public int IdAlquiler { get; set; }
        public int IdReserva { get; set; }
        public DateTime FechaEntregaReal { get; set; }
        public DateTime FechaFinReserva { get; set; }
        public decimal PrecioDiarioPactado { get; set; }
        public decimal KilometrajeSalida { get; set; }
        public bool Activo { get; set; }
        public string Cliente { get; set; } = "";
        public string Vehiculo { get; set; } = "";
    }
}
