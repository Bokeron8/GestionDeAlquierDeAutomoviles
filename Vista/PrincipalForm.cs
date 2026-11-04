using System;
using System.Collections.Generic;
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
        public DevolucionVista devolucionVista;
        public CargaDanioVista cargaDanio;
        public ListaDanioVista listaDanio;
        public CargaEstadoVista cargaEstado;
        public ListaEstadoVista listaEstado;
        public CargaRolVista cargaRol;
        public ListaRolVista listaRol;
        public ReporteVista reporteVista;
        public InicioVista inicioVista;

        private readonly int _idRol;
        private readonly int _idEmpleado;
        private readonly string _nombreEmpleado;
        private readonly string _nombreRol;

        public PrincipalForm(Empleado? empleado = null)
        {
            InitializeComponent();
            _idRol = empleado?.IdRol ?? 0;
            _idEmpleado = empleado?.IdEmpleado ?? 0;
            _nombreEmpleado = empleado == null ? "" : $"{empleado.Nombre} {empleado.Apellido}".Trim();
            _nombreRol = NombreRolSesion();
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
            devolucionVista = new DevolucionVista();
            cargaDanio = new CargaDanioVista();
            listaDanio = new ListaDanioVista();
            cargaEstado = new CargaEstadoVista();
            listaEstado = new ListaEstadoVista();
            cargaRol = new CargaRolVista();
            listaRol = new ListaRolVista();
            reporteVista = new ReporteVista();
            inicioVista = new InicioVista();
            cargaReserva.ConfigurarSesion(_idEmpleado, _nombreEmpleado);
            ConfigurarMenuPorRol();
            AbrirInicio();
        }

        private bool EsAdmin => _idRol == 1;
        private bool EsRecepcionista => _idRol == 2;
        private bool EsMecanico => _idRol == 3;
        private bool EsGerente => _idRol == 4;

        /// <summary>
        /// The role rules live in one place: menu visibility and the home shortcuts both read
        /// them, so the home screen can never offer a section the menu hides.
        /// </summary>
        private void ConfigurarMenuPorRol()
        {
            vehiculosToolStripMenuItem.Visible = EsAdmin || EsGerente;
            marcasToolStripMenuItem.Visible = EsAdmin || EsGerente;
            modelosToolStripMenuItem.Visible = EsAdmin || EsGerente;
            categoriasToolStripMenuItem.Visible = EsAdmin || EsGerente;
            clientesToolStripMenuItem.Visible = EsAdmin || EsRecepcionista;
            empleadosToolStripMenuItem.Visible = EsAdmin || EsGerente;
            reservasToolStripMenuItem.Visible = EsAdmin || EsRecepcionista;
            alquileresToolStripMenuItem.Visible = EsAdmin || EsRecepcionista;
            daniosToolStripMenuItem.Visible = EsAdmin || EsMecanico;
            estadosToolStripMenuItem.Visible = EsAdmin;
            rolesToolStripMenuItem.Visible = EsAdmin;
            reportesToolStripMenuItem.Visible = EsGerente;
        }

        /// <summary>
        /// Landing screen for every role: it replaces opening the app straight into the
        /// vehicle creation form, which made no sense for anyone but the administrator.
        /// </summary>
        public void AbrirInicio()
        {
            MostrarUserControl(inicioVista);
            inicioVista.Configurar(_nombreEmpleado, _nombreRol, SeccionesDisponibles());
        }

        public void AbrirSeccion(SeccionInicio seccion)
        {
            switch (seccion)
            {
                case SeccionInicio.Vehiculos:
                    MostrarUserControl(listaVehiculo);
                    listaVehiculo.Refrescar();
                    break;
                case SeccionInicio.Clientes:
                    MostrarUserControl(listaCliente);
                    listaCliente.Refrescar();
                    break;
                case SeccionInicio.Reservas:
                    MostrarUserControl(listaReserva);
                    listaReserva.Refrescar();
                    break;
                case SeccionInicio.Alquileres:
                    MostrarUserControl(listaAlquiler);
                    listaAlquiler.Refrescar();
                    break;
                case SeccionInicio.Danios:
                    MostrarUserControl(listaDanio);
                    listaDanio.Refrescar();
                    break;
                case SeccionInicio.Empleados:
                    MostrarUserControl(listaEmpleado);
                    listaEmpleado.Refrescar();
                    break;
                case SeccionInicio.Estados:
                    MostrarUserControl(listaEstado);
                    listaEstado.Refrescar();
                    break;
                case SeccionInicio.Roles:
                    MostrarUserControl(listaRol);
                    listaRol.Refrescar();
                    break;
                case SeccionInicio.Reportes:
                    MostrarUserControl(reporteVista);
                    reporteVista.Refrescar();
                    break;
            }
        }

        private List<SeccionInicio> SeccionesDisponibles()
        {
            var secciones = new List<SeccionInicio>();

            if (EsAdmin || EsGerente) secciones.Add(SeccionInicio.Vehiculos);
            if (EsAdmin || EsRecepcionista) secciones.Add(SeccionInicio.Clientes);
            if (EsAdmin || EsRecepcionista)
            {
                secciones.Add(SeccionInicio.Reservas);
                secciones.Add(SeccionInicio.Alquileres);
            }
            if (EsAdmin || EsMecanico) secciones.Add(SeccionInicio.Danios);
            if (EsAdmin || EsGerente) secciones.Add(SeccionInicio.Empleados);
            if (EsAdmin)
            {
                secciones.Add(SeccionInicio.Estados);
                secciones.Add(SeccionInicio.Roles);
            }
            if (EsGerente) secciones.Add(SeccionInicio.Reportes);

            return secciones;
        }

        /// <summary>
        /// Role label for the greeting. The login query does not join Rol, so the name is read
        /// once from the catalog; a failure leaves the greeting without a role instead of
        /// breaking the session start.
        /// </summary>
        private string NombreRolSesion()
        {
            if (_idRol <= 0) return "";
            try
            {
                return Rol.ObtenerPorId(_idRol)?.NombreRol ?? "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void MostrarUserControl(UserControl uc)
        {
            panelContenido.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(uc);
        }

        private void ListarVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSeccion(SeccionInicio.Vehiculos);
        }

        private void ListarMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaMarca);
            listaMarca.Refrescar();
        }

        private void ListarModelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaModelo);
            listaModelo.Refrescar();
        }

        private void ListarCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(listaCategoria);
            listaCategoria.Refrescar();
        }

        private void ListarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSeccion(SeccionInicio.Clientes);
        }

        private void ListarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSeccion(SeccionInicio.Empleados);
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

        public void CargarEdicionEstado(Estado estado)
        {
            cargaEstado.SetEstado(estado);
            MostrarUserControl(cargaEstado);
        }

        public void CargarEdicionRol(Rol rol)
        {
            cargaRol.SetRol(rol);
            MostrarUserControl(cargaRol);
        }

        public void CargarEdicionDanio(Danio danio)
        {
            cargaDanio.SetDanio(danio);
            MostrarUserControl(cargaDanio);
        }

        public void CargarEdicionAlquiler(int id)
        {
            cargaAlquiler.SetAlquiler(id);
            MostrarUserControl(cargaAlquiler);
        }

        public void CargarDevolucion(int idAlquiler)
        {
            devolucionVista.SetAlquiler(idAlquiler);
            MostrarUserControl(devolucionVista);
        }

        public void MostrarCarga(UserControl uc)
        {
            MostrarUserControl(uc);
        }

        private void ListarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSeccion(SeccionInicio.Reservas);
        }

        private void ListarAlquileresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSeccion(SeccionInicio.Alquileres);
        }

        private void ListarDaniosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSeccion(SeccionInicio.Danios);
        }

        private void ListarEstadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSeccion(SeccionInicio.Estados);
        }

        private void CerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSeccion(SeccionInicio.Roles);
        }

        private void MostrarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSeccion(SeccionInicio.Reportes);
        }

        private void InicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirInicio();
        }
    }
}
