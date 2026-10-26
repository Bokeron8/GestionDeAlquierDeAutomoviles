using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaAlquilerVista : UserControl
    {
        private readonly AlquilerController _controller = new();
        private int _alquilerId = 0;

        public CargaAlquilerVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        private void CargarReservas()
        {
            var reservas = _controller.ObtenerReservasDisponibles(_alquilerId);
            cbReserva.DataSource = reservas;
            cbReserva.DisplayMember = "IdReserva";
            cbReserva.ValueMember = "IdReserva";
        }

        public void SetAlquiler(int id)
        {
            _alquilerId = id;
            var alq = _controller.BuscarPorId(id);
            if (alq == null) return;

            lblTitulo.Text = "Editar Alquiler";
            btnGuardar.Text = "Actualizar Alquiler";

            CargarReservas();
            cbReserva.SelectedValue = alq.IdReserva;

            txtCombustibleSalida.Text = alq.CombustibleSalida.ToString();
            txtKilometrajeSalida.Text = alq.KilometrajeSalida.ToString();
            txtCombustibleEntrada.Text = alq.CombustibleEntrada?.ToString() ?? "";
            txtKilometrajeEntrada.Text = alq.KilometrajeEntrada?.ToString() ?? "";
            txtMontoMora.Text = alq.MontoMora.ToString();
        }

        public void LimpiarFormulario()
        {
            _alquilerId = 0;
            lblTitulo.Text = "Registrar Alquiler";
            btnGuardar.Text = "Registrar Alquiler";
            txtCombustibleSalida.Clear();
            txtKilometrajeSalida.Clear();
            txtCombustibleEntrada.Clear();
            txtKilometrajeEntrada.Clear();
            txtMontoMora.Clear();
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

                decimal? combustibleEntrada = null;
                if (!string.IsNullOrWhiteSpace(txtCombustibleEntrada.Text))
                {
                    if (decimal.TryParse(txtCombustibleEntrada.Text, out decimal ce))
                        combustibleEntrada = ce;
                    else
                    {
                        MessageBox.Show("El combustible de entrada debe ser numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                decimal? kilometrajeEntrada = null;
                if (!string.IsNullOrWhiteSpace(txtKilometrajeEntrada.Text))
                {
                    if (decimal.TryParse(txtKilometrajeEntrada.Text, out decimal ke))
                        kilometrajeEntrada = ke;
                    else
                    {
                        MessageBox.Show("El kilometraje de entrada debe ser numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                decimal montoMora = 0;
                if (!string.IsNullOrWhiteSpace(txtMontoMora.Text))
                {
                    if (!decimal.TryParse(txtMontoMora.Text, out montoMora))
                    {
                        MessageBox.Show("El monto de mora debe ser numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int idReserva = Convert.ToInt32(cbReserva.SelectedValue);

                var alq = new Alquiler
                {
                    IdAlquiler = _alquilerId,
                    FechaEntregaReal = DateTime.Now,
                    CombustibleSalida = combustibleSalida,
                    KilometrajeSalida = kilometrajeSalida,
                    CombustibleEntrada = combustibleEntrada,
                    KilometrajeEntrada = kilometrajeEntrada,
                    MontoMora = montoMora,
                    Activo = true,
                    IdReserva = idReserva
                };

                var errores = _controller.ValidarAlquiler(alq);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.Guardar(alq);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _alquilerId == 0 ? "Alquiler registrado correctamente." : "Alquiler actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el alquiler.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
