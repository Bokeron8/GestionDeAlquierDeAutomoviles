using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaReservaVista : UserControl
    {
        private readonly ReservaController _controller = new();
        private Reserva? _reservaEditar;
        private int _idEmpleadoSesion;
        private string _nombreEmpleadoSesion = "";

        public CargaReservaVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
            txtBuscarCliente.TextChanged += txtBuscarCliente_TextChanged;
            txtBuscarVehiculo.TextChanged += txtBuscarVehiculo_TextChanged;

            // The summary card follows every input that changes what the operator is
            // about to commit to: who, which car, which dates and at what price.
            cbCliente.SelectedIndexChanged += (_, _) => ActualizarResumen();
            cbVehiculo.SelectedIndexChanged += (_, _) => ActualizarResumen();
            numPrecioDiarioPactado.ValueChanged += (_, _) => ActualizarResumen();
            dtpFechaInicio.ValueChanged += (_, _) => ActualizarResumen();
            dtpFechaFin.ValueChanged += (_, _) => ActualizarResumen();
        }

        /// <summary>
        /// The employee who registers the reservation comes from the session, not from a
        /// picker: the state and the owner are business invariants, not form fields.
        /// </summary>
        public void ConfigurarSesion(int idEmpleado, string nombreEmpleado)
        {
            _idEmpleadoSesion = idEmpleado;
            _nombreEmpleadoSesion = nombreEmpleado ?? "";
            lblEmpleadoValor.Text = string.IsNullOrWhiteSpace(_nombreEmpleadoSesion) ? "Sin sesión" : _nombreEmpleadoSesion;
            ActualizarResumen();
        }

        private List<Cliente> _todosClientes = [];
        private List<Vehiculo> _todosVehiculos = [];

        private void CargarCombos()
        {
            // Both pickers show the identity label instead of the raw name, so the
            // operator distinguishes two clients with the same name by their DNI.
            _todosClientes = _controller.ObtenerClientes();
            FiltrarClientes();

            _todosVehiculos = _controller.ObtenerVehiculos();
            FiltrarVehiculos();
        }

        private void FiltrarClientes()
        {
            string termino = FiltroBusqueda.Normalizar(txtBuscarCliente.Text);
            var filtrados = _todosClientes.Where(c =>
                termino.Length == 0 ||
                FiltroBusqueda.Contiene(c.Nombre, termino) ||
                FiltroBusqueda.Contiene(c.Apellido, termino) ||
                FiltroBusqueda.Contiene(c.Dni, termino) ||
                FiltroBusqueda.Contiene(c.Correo, termino)).ToList();

            cbCliente.DataSource = null;
            cbCliente.DataSource = filtrados;
            cbCliente.DisplayMember = "Descripcion";
            cbCliente.ValueMember = "IdCliente";
        }

        private void FiltrarVehiculos()
        {
            string termino = FiltroBusqueda.Normalizar(txtBuscarVehiculo.Text);
            var filtrados = _todosVehiculos.Where(v =>
                termino.Length == 0 ||
                FiltroBusqueda.Contiene(v.Matricula, termino) ||
                FiltroBusqueda.Contiene(v.NombreMarca, termino) ||
                FiltroBusqueda.Contiene(v.NombreModelo, termino) ||
                FiltroBusqueda.Contiene(v.Color, termino)).ToList();

            cbVehiculo.DataSource = null;
            cbVehiculo.DataSource = filtrados;
            cbVehiculo.DisplayMember = "Descripcion";
            cbVehiculo.ValueMember = "IdVehiculo";
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void txtBuscarVehiculo_TextChanged(object sender, EventArgs e)
        {
            FiltrarVehiculos();
        }

        public void SetReserva(Reserva res)
        {
            _reservaEditar = res;
            lblTitulo.Text = "Editar Reserva";
            btnGuardar.Text = "Actualizar Reserva";

            CargarCombos();
            cbCliente.SelectedValue = res.IdCliente;
            cbVehiculo.SelectedValue = res.IdVehiculo;

            numPrecioDiarioPactado.Value = res.PrecioDiarioPactado;
            dtpFechaInicio.Value = res.FechaInicioReserva;
            dtpFechaFin.Value = res.FechaFinReserva;

            ActualizarResumen();
        }

        public void LimpiarFormulario()
        {
            _reservaEditar = null;
            lblTitulo.Text = "Crear Reserva";
            btnGuardar.Text = "Guardar Reserva";

            numPrecioDiarioPactado.Value = 0;
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today.AddDays(1);
            CargarCombos();
            ActualizarResumen();
        }

        /// <summary>
        /// Read-only card that mirrors the reservation about to be saved. It exists so the
        /// operator confirms the identity, the vehicle, the dates and the estimated total
        /// instead of trusting a combo box selection.
        /// </summary>
        private void ActualizarResumen()
        {
            var cliente = cbCliente.SelectedItem as Cliente;
            var vehiculo = cbVehiculo.SelectedItem as Vehiculo;

            string clienteTexto = "Cliente: —";
            string contactoTexto = "";
            if (cliente != null)
            {
                clienteTexto = $"Cliente: {cliente.Descripcion}";
                contactoTexto = $"Tel: {cliente.Telefono} · Lic. {cliente.NroLicencia} vence {cliente.VencimientoLicencia:dd/MM/yyyy}";
            }

            string vehiculoTexto = "Vehículo: —";
            string detalleVehiculoTexto = "";
            if (vehiculo != null)
            {
                vehiculoTexto = $"Vehículo: {vehiculo.Descripcion}";
                detalleVehiculoTexto = $"Color: {vehiculo.Color} · Categoría: {vehiculo.NombreCategoria}";
            }

            int dias = DiasPactados();
            decimal precioDiario = numPrecioDiarioPactado.Value;
            decimal total = dias * precioDiario;
            string empleado = _reservaEditar != null && !string.IsNullOrWhiteSpace(_reservaEditar.NombreEmpleado)
                ? _reservaEditar.NombreEmpleado
                : _nombreEmpleadoSesion;
            string estado = _reservaEditar != null && !string.IsNullOrWhiteSpace(_reservaEditar.NombreEstado)
                ? _reservaEditar.NombreEstado
                : "Pendiente";

            lblResumen.Text =
                $"{clienteTexto}{Environment.NewLine}" +
                $"{contactoTexto}{Environment.NewLine}" +
                $"{vehiculoTexto}{Environment.NewLine}" +
                $"{detalleVehiculoTexto}{Environment.NewLine}" +
                $"Del {dtpFechaInicio.Value:dd/MM/yyyy} al {dtpFechaFin.Value:dd/MM/yyyy} · {dias} día(s){Environment.NewLine}" +
                $"Precio diario: $ {precioDiario:0.00}{Environment.NewLine}" +
                $"Total estimado: $ {total:0.00}{Environment.NewLine}" +
                $"Empleado: {empleado} · Estado: {estado}";

            AdvertirLicencia(cliente);
        }

        /// <summary>
        /// A licence that expired before the reservation starts is exactly the human error
        /// the card has to surface before the reservation is saved.
        /// </summary>
        private void AdvertirLicencia(Cliente? cliente)
        {
            bool vencida = cliente != null && cliente.VencimientoLicencia.Date < dtpFechaInicio.Value.Date;
            lblAvisoLicencia.Visible = vencida;
            lblAvisoLicencia.Text = vencida && cliente != null
                ? $"Licencia vencida el {cliente.VencimientoLicencia:dd/MM/yyyy}. Verificar antes de alquilar."
                : "";
        }

        /// <summary>
        /// Days between the agreed extremes. A same-day reservation still counts as one
        /// day, which is the assumption recorded in the feature document.
        /// </summary>
        private int DiasPactados()
        {
            return Math.Max(1, (dtpFechaFin.Value.Date - dtpFechaInicio.Value.Date).Days);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var res = _reservaEditar ?? new Reserva();
                res.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
                res.IdVehiculo = Convert.ToInt32(cbVehiculo.SelectedValue);
                res.IdEmpleado = _reservaEditar?.IdEmpleado ?? _idEmpleadoSesion;
                res.IdEstado = _reservaEditar?.IdEstado ?? EstadosReserva.Pendiente;
                res.PrecioDiarioPactado = numPrecioDiarioPactado.Value;
                res.FechaInicioReserva = dtpFechaInicio.Value;
                res.FechaFinReserva = dtpFechaFin.Value;
                res.Activo = true;

                var errores = _controller.ValidarReserva(res);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.Guardar(res);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _reservaEditar == null ? "Reserva registrada correctamente." : "Reserva actualizada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
