using System.Drawing;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    /// <summary>
    /// Palette and typography shared by the controls that are built at runtime.
    /// Designer-generated files keep their own literals on purpose: the WinForms designer
    /// rewrites those files on save, so a constant there would be replaced by a literal anyway.
    /// </summary>
    internal static class Theme
    {
        internal static readonly Color Fondo = Color.FromArgb(240, 240, 245);
        internal static readonly Color Primario = Color.FromArgb(51, 51, 76);
        internal static readonly Color Peligro = Color.FromArgb(180, 40, 40);
        internal static readonly Color TextoSecundario = Color.FromArgb(90, 90, 110);

        internal static Font Titulo(int tamanio = 14) => new Font("Segoe UI", tamanio, FontStyle.Bold);

        internal static Font Cuerpo(int tamanio = 10) => new Font("Segoe UI", tamanio);

        internal static Font CuerpoNegrita(int tamanio = 10) => new Font("Segoe UI", tamanio, FontStyle.Bold);
    }
}
