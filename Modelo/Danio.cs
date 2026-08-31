namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Danio
    {
        public int IdDanio { get; set; }
        public string Zona { get; set; }
        public string Descripcion { get; set; }
        public string? EvidenciaFotografica { get; set; }
        public int IdAlquiler { get; set; }
    }
}
