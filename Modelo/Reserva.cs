namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaInicioReserva { get; set; }
        public DateTime FechaFinReserva { get; set; }
        public int IdEstado { get; set; }
        public int IdEmpleado { get; set; }
        public int IdVehiculo { get; set; }
        public int IdCliente { get; set; }
    }
}
