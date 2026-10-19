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
        public ReporteVista reporteVista;

        private readonly int _idRol;

        public PrincipalForm(Empleado? empleado = null)
        {
            InitializeComponent();
            _idRol = empleado?.IdRol ?? 0;
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
            reporteVista = new ReporteVista();
            ConfigurarMenuPorRol();
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
            listaVehiculo.Refrescar();
            MostrarUserControl(listaVehiculo);
        }

        private void ListarMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaMarca.Refrescar();
            MostrarUserControl(listaMarca);
        }

        private void ListarModelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaModelo.Refrescar();
            MostrarUserControl(listaModelo);
        }

        private void ListarCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaCategoria.Refrescar();
            MostrarUserControl(listaCategoria);
        }

        private void ListarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaCliente.Refrescar();
            MostrarUserControl(listaCliente);
        }

        private void ListarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaEmpleado.Refrescar();
            MostrarUserControl(listaEmpleado);
        }

        public void CargarEdicionEmpleado(Empleado emp)
        {
            cargaEmpleado.SetEmpleado(emp);
            MostrarUserControl(cargaEmpleado);
        }

        public void CargarEdicionVehiculo(Vehiculo veh)
        {
            cargaVehiculo.SetVehiculo(veh);
            MostrarUserControl(cargaVehiculo);
        }

        public void CargarEdicionCliente(Cliente cli)
        {
            cargaCliente.SetCliente(cli);
            MostrarUserControl(cargaCliente);
        }

        public void CargarEdicionReserva(Reserva res)
        {
            cargaReserva.SetReserva(res);
            MostrarUserControl(cargaReserva);
        }

        public void CargarEdicionMarca(Marca marca)
        {
            cargaMarca.SetMarca(marca);
            MostrarUserControl(cargaMarca);
        }

        public void CargarEdicionModelo(ModeloVehiculo modelo)
        {
            cargaModelo.SetModelo(modelo);
            MostrarUserControl(cargaModelo);
        }

        public void CargarEdicionCategoria(Categoria cat)
        {
            cargaCategoria.SetCategoria(cat);
            MostrarUserControl(cargaCategoria);
        }

        public void CargarEdicionAlquiler(int id)
        {
            cargaAlquiler.SetAlquiler(id);
            MostrarUserControl(cargaAlquiler);
        }

        public void MostrarCarga(UserControl uc)
        {
            MostrarUserControl(uc);
        }

        private void ListarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaReserva.Refrescar();
            MostrarUserControl(listaReserva);
        }

        private void ListarAlquileresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaAlquiler.Refrescar();
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

        private void CerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaRol);
        }

        private void MostrarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(reporteVista);
        }
    }
}
