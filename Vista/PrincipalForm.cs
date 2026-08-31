using System;
using System.Windows.Forms;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class PrincipalForm : Form
    {
        private CargaVehiculoVista cargaVehiculo;
        private ListaVehiculoVista listaVehiculo;
        private CargaMarcaVista cargaMarca;
        private ListaMarcaVista listaMarca;

        public PrincipalForm()
        {
            InitializeComponent();
            cargaVehiculo = new CargaVehiculoVista();
            listaVehiculo = new ListaVehiculoVista();
            cargaMarca = new CargaMarcaVista();
            listaMarca = new ListaMarcaVista();
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

        private void CargarMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaMarca);
        }

        private void ListarMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaMarca);
        }
    }
}
