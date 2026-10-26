using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaAlquilerVista : UserControl
    {
        private readonly AlquilerController _controller = new();
        private Alquiler? _alquilerEditar;

        public CargaAlquilerVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        private void CargarReservas()
        {
            var reservas = _controller.ObtenerReservasDisponibles(_alquilerEditar?.IdReserva ?? 0);
            cbReserva.DataSource = reservas;
            cbReserva.DisplayMember = "IdReserva";
            cbReserva.ValueMember = "IdReserva";
        }

        public void SetAlquiler(int id)
        {
            var alq = _controller.BuscarPorId(id);
            if (alq == null) return;

            _alquilerEditar = alq;
            lblTitulo.Text = "Editar Entrega";
            btnGuardar.Text = "Actualizar Entrega";

            CargarReservas();
            cbReserva.SelectedValue = alq.IdReserva;

            txtCombustibleSalida.Text = alq.CombustibleSalida.ToString();
            txtKilometrajeSalida.Text = alq.KilometrajeSalida.ToString();
        }

        public void LimpiarFormulario()
        {
            _alquilerEditar = null;
            lblTitulo.Text = "Registrar Entrega";
            btnGuardar.Text = "Registrar Entrega";
            txtCombustibleSalida.Clear();
            txtKilometrajeSalida.Clear();
            CargarReservas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtCombustibleSalida.Text, out decimal combustibleSalida))
                {
                    MessageBox.Show("El combustible de salida debe ser un valor numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtKilometrajeSalida.Text, out decimal kilometrajeSalida))
                {
                    MessageBox.Show("El kilometraje de salida debe ser un valor numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbReserva.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una reserva confirmada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idReserva = Convert.ToInt32(cbReserva.SelectedValue);

                // Everything the delivery does not own is carried over from the loaded
                // rental, so editing never rewrites the original delivery date nor erases
                // the return data already captured.
                var alq = new Alquiler
                {
                    IdAlquiler = _alquilerEditar?.IdAlquiler ?? 0,
                    FechaEntregaReal = _alquilerEditar?.FechaEntregaReal ?? DateTime.Now,
                    FechaEntregaDevolucion = _alquilerEditar?.FechaEntregaDevolucion,
                    CombustibleSalida = combustibleSalida,
                    CombustibleEntrada = _alquilerEditar?.CombustibleEntrada,
                    KilometrajeSalida = kilometrajeSalida,
                    KilometrajeEntrada = _alquilerEditar?.KilometrajeEntrada,
                    MontoMora = _alquilerEditar?.MontoMora ?? 0,
                    Activo = _alquilerEditar?.Activo ?? true,
                    IdReserva = idReserva
                };

                var errores = _controller.ValidarAlquiler(alq);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.RegistrarEntrega(alq);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _alquilerEditar == null ? "Entrega registrada correctamente." : "Entrega actualizada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la entrega.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
