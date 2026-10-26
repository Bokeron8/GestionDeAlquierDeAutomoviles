namespace GestionDeAlquierDeAutomoviles.Modelo
{
    /// <summary>
    /// Identificadores estables del catalogo Estado aplicados al ciclo de vida de una reserva.
    /// Los ids son IDENTITY fijos en la base; renombrar el estado solo cambia la etiqueta mostrada.
    /// </summary>
    public static class EstadosReserva
    {
        public const int Pendiente = 1;
        public const int Confirmada = 2;
        public const int EnCurso = 3;
        public const int Finalizada = 4;
        public const int Cancelada = 5;
    }
}
