using System;
using System.IO;
using System.Windows.Forms;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaVehiculoVista : UserControl
    {
        public CargaVehiculoVista()
        {
            InitializeComponent();
            CargarImagen();
        }

        private void CargarImagen()
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Recursos", "auto.png");
            if (File.Exists(ruta))
            {
                pbAuto.Image = Image.FromFile(ruta);
            }
        }
    }
}
