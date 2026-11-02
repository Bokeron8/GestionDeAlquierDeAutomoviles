using System.Globalization;
using System.Text;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    /// <summary>
    /// Case- and accent-insensitive matching shared by every list search box, so the
    /// operator can type "perez" and still find "Pérez".
    /// </summary>
    internal static class FiltroBusqueda
    {
        /// <summary>
        /// Trims, lowercases and strips diacritics from the search text. An empty result
        /// means "no filter".
        /// </summary>
        public static string Normalizar(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";

            var descompuesto = texto.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var limpio = new StringBuilder(descompuesto.Length);
            foreach (char c in descompuesto)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    limpio.Append(c);
                }
            }
            return limpio.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// True when the source text contains the already normalized search term.
        /// </summary>
        public static bool Contiene(string? origen, string terminoNormalizado)
        {
            return terminoNormalizado.Length == 0 || Normalizar(origen).Contains(terminoNormalizado);
        }
    }
}
