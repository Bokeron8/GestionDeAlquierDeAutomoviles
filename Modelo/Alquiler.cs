namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Alquiler
    {
        public int IdAlquiler { get; set; }
        public DateTime FechaEntregaReal { get; set; }
        public DateTime? FechaEntregaDevolucion { get; set; }
        public decimal CombustibleSalida { get; set; }
        public decimal? CombustibleEntrada { get; set; }
        public decimal KilometrajeSalida { get; set; }
        public decimal? KilometrajeEntrada { get; set; }
        public decimal MontoMora { get; set; }
        public int IdReserva { get; set; }
    }
}
