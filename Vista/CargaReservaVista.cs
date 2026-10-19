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

        public CargaReservaVista()
        {
            InitializeComponent();
            Load += CargaReservaVista_Load;
            btnGuardar.Click += btnGuardar_Click;
        }

        private void CargaReservaVista_Load(object sender, EventArgs e)
        {
            CargarCombos();
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

            var empleados = _controller.ObtenerEmpleados();
            cbEmpleado.DataSource = empleados;
            cbEmpleado.DisplayMember = "Nombre";
            cbEmpleado.ValueMember = "IdEmpleado";

            var estados = _controller.ObtenerEstados();
            cbEstado.DataSource = estados;
            cbEstado.DisplayMember = "Nombre";
            cbEstado.ValueMember = "IdEstado";
        }

        public void SetReserva(Reserva res)
        {
            _reservaEditar = res;
            lblTitulo.Text = "Editar Reserva";
            btnGuardar.Text = "Actualizar Reserva";

            CargarCombos();
            cbCliente.SelectedValue = res.IdCliente;
            cbVehiculo.SelectedValue = res.IdVehiculo;
            cbEmpleado.SelectedValue = res.IdEmpleado;
            cbEstado.SelectedValue = res.IdEstado;

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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var res = _reservaEditar ?? new Reserva();
                res.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
                res.IdVehiculo = Convert.ToInt32(cbVehiculo.SelectedValue);
                res.IdEmpleado = Convert.ToInt32(cbEmpleado.SelectedValue);
                res.IdEstado = Convert.ToInt32(cbEstado.SelectedValue);
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
