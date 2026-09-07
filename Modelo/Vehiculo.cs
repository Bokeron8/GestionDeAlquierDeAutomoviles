namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Matricula { get; set; }
        public string Chasis { get; set; }
        public string Color { get; set; }
        public int Anio { get; set; }
        public bool Activo { get; set; }
        public int IdModelo { get; set; }
        public int IdCategoria { get; set; }
    }
}
