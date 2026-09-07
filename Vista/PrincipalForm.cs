using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class PrincipalForm : Form
    {
        public CargaVehiculoVista cargaVehiculo;
        public ListaVehiculoVista listaVehiculo;
        public CargaMarcaVista cargaMarca;
        public ListaMarcaVista listaMarca;
        public CargaModeloVista cargaModelo;
        public ListaModeloVista listaModelo;
        public CargaCategoriaVista cargaCategoria;
        public ListaCategoriaVista listaCategoria;
        public CargaClienteVista cargaCliente;
        public ListaClienteVista listaCliente;
        public CargaEmpleadoVista cargaEmpleado;
        public ListaEmpleadoVista listaEmpleado;
        public CargaReservaVista cargaReserva;
        public ListaReservaVista listaReserva;
        public CargaAlquilerVista cargaAlquiler;
        public ListaAlquilerVista listaAlquiler;
        public CargaDanioVista cargaDanio;
        public ListaDanioVista listaDanio;
        public CargaEstadoVista cargaEstado;
        public ListaEstadoVista listaEstado;
        public CargaRolVista cargaRol;
        public ListaRolVista listaRol;

        public PrincipalForm()
        {
            InitializeComponent();
            cargaVehiculo = new CargaVehiculoVista();
            listaVehiculo = new ListaVehiculoVista();
            cargaMarca = new CargaMarcaVista();
            listaMarca = new ListaMarcaVista();
            cargaModelo = new CargaModeloVista();
            listaModelo = new ListaModeloVista();
            cargaCategoria = new CargaCategoriaVista();
            listaCategoria = new ListaCategoriaVista();
            cargaCliente = new CargaClienteVista();
            listaCliente = new ListaClienteVista();
            cargaEmpleado = new CargaEmpleadoVista();
            listaEmpleado = new ListaEmpleadoVista();
            cargaReserva = new CargaReservaVista();
            listaReserva = new ListaReservaVista();
            cargaAlquiler = new CargaAlquilerVista();
            listaAlquiler = new ListaAlquilerVista();
            cargaDanio = new CargaDanioVista();
            listaDanio = new ListaDanioVista();
            cargaEstado = new CargaEstadoVista();
            listaEstado = new ListaEstadoVista();
            cargaRol = new CargaRolVista();
            listaRol = new ListaRolVista();
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

        private void CargarModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaModelo);
        }

        private void ListarModelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaModelo);
        }

        private void CargarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaCategoria);
        }

        private void ListarCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaCategoria);
        }

        private void CargarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaCliente);
        }

        private void ListarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaCliente);
        }

        private void CargarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaEmpleado);
        }

        private void ListarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaEmpleado);
        }

        public void CargarEdicionEmpleado(Empleado emp)
        {
            cargaEmpleado.SetEmpleado(emp);
            MostrarUserControl(cargaEmpleado);
        }

        public void MostrarCarga(UserControl uc)
        {
            MostrarUserControl(uc);
        }

        private void CargarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaReserva);
        }

        private void ListarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaReserva);
        }

        private void CargarAlquilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaAlquiler);
        }

        private void ListarAlquileresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaAlquiler);
        }

        private void CargarDanioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaDanio);
        }

        private void ListarDaniosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaDanio);
        }

        private void CargarEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaEstado);
        }

        private void ListarEstadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaEstado);
        }

        private void CargarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(cargaRol);
        }

        private void ListarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaRol);
        }
    }
}
