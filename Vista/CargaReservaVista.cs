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
        }

        private void CargarCombos()
        {
            var clientes = _controller.ObtenerClientes();
            cbCliente.DataSource = clientes;
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "IdCliente";

            var vehiculos = _controller.ObtenerVehiculos();
            cbVehiculo.DataSource = vehiculos;
            cbVehiculo.DisplayMember = "Matricula";
            cbVehiculo.ValueMember = "IdVehiculo";
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
