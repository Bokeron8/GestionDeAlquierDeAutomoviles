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

        private void ListarVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaVehiculo);
        }

        private void ListarMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaMarca);
        }

        private void ListarModelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaModelo);
        }

        private void ListarCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaCategoria);
        }

        private void ListarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaCliente);
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

        private void ListarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaReserva);
        }

        private void ListarAlquileresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaAlquiler);
        }

        private void ListarDaniosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaDanio);
        }

        private void ListarEstadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaEstado);
        }

        private void ListarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaRol);
        }
    }
}
