namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string NroLicencia { get; set; }
        public DateTime VencimientoLicencia { get; set; }
        public string EstadoIdentidad { get; set; }
        public bool Activo { get; set; }
    }
}
