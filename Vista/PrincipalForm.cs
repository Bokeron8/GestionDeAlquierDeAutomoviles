using System;
using System.Windows.Forms;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class PrincipalForm : Form
    {
        private CargaVehiculoVista cargaVehiculo;
        private ListaVehiculoVista listaVehiculo;

        public PrincipalForm()
        {
            InitializeComponent();
            cargaVehiculo = new CargaVehiculoVista();
            listaVehiculo = new ListaVehiculoVista();
            MostrarUserControl(cargaVehiculo);
        }

        private void MostrarUserControl(UserControl uc)
        {
            panelContenido.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(uc);
        }

        private void CargarVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaVehiculo);
        }

        private void ListarVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaVehiculo);
        }
    }
}
