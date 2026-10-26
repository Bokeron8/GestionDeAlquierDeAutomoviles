using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class DevolucionVista : UserControl
    {
        private readonly AlquilerController _controller = new();
        private ContratoAlquiler? _contrato;

        public DevolucionVista()
        {
            InitializeComponent();
            btnConfirmar.Click += btnConfirmar_Click;
            dtpFechaDevolucion.ValueChanged += (_, _) => RecalcularMora();
        }

        public void SetAlquiler(int idAlquiler)
        {
            _contrato = _controller.ObtenerContrato(idAlquiler);
            if (_contrato == null)
            {
                lblContrato.Text = "No se encontró el alquiler seleccionado.";
                btnConfirmar.Enabled = false;
                return;
            }

            MostrarContrato();

            txtKilometrajeEntrada.Text = _contrato.KilometrajeSalida.ToString();
            txtCombustibleEntrada.Text = "";
            dtpFechaDevolucion.Value = DateTime.Now < _contrato.FechaEntregaReal ? _contrato.FechaEntregaReal : DateTime.Now;
            RecalcularMora();

            btnConfirmar.Enabled = _contrato.Activo;
        }

        private void MostrarContrato()
        {
            if (_contrato == null) return;

            lblContrato.Text =
                $"Reserva #{_contrato.IdReserva}{Environment.NewLine}" +
                $"Cliente: {_contrato.Cliente}{Environment.NewLine}" +
                $"Vehículo: {_contrato.Vehiculo}{Environment.NewLine}" +
                $"Fecha de entrega: {_contrato.FechaEntregaReal:dd/MM/yyyy}{Environment.NewLine}" +
                $"Fin pactado: {_contrato.FechaFinReserva:dd/MM/yyyy}{Environment.NewLine}" +
                $"Precio diario pactado: ${_contrato.PrecioDiarioPactado:0.00}{Environment.NewLine}" +
                $"Estado: {(_contrato.Activo ? "En curso" : "Devuelto")}";
        }

        /// <summary>
        /// The late fee is derived from the contract: days past the agreed end multiplied by
        /// the agreed daily price. It stays editable so a manager can adjust it.
        /// </summary>
        private void RecalcularMora()
        {
            if (_contrato == null) return;

            int diasAtraso = (dtpFechaDevolucion.Value.Date - _contrato.FechaFinReserva.Date).Days;
            decimal mora = diasAtraso > 0 ? diasAtraso * _contrato.PrecioDiarioPactado : 0;
            txtMontoMora.Text = mora.ToString("0.00");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_contrato == null)
                {
                    MessageBox.Show("Seleccione un alquiler para devolver.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var alq = _controller.BuscarPorId(_contrato.IdAlquiler);
                if (alq == null)
                {
                    MessageBox.Show("El alquiler seleccionado ya no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtKilometrajeEntrada.Text, out decimal kilometrajeEntrada))
                {
                    MessageBox.Show("El kilometraje de entrada debe ser un valor numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtCombustibleEntrada.Text, out decimal combustibleEntrada))
                {
                    MessageBox.Show("El combustible de entrada debe ser un valor numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtMontoMora.Text, out decimal montoMora))
                {
                    MessageBox.Show("El monto de mora debe ser un valor numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                alq.FechaEntregaDevolucion = dtpFechaDevolucion.Value;
                alq.CombustibleEntrada = combustibleEntrada;
                alq.KilometrajeEntrada = kilometrajeEntrada;
                alq.MontoMora = montoMora;

                var errores = _controller.ValidarDevolucion(alq);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool ok = _controller.RegistrarDevolucionTransaccional(
                    alq.IdAlquiler, alq.FechaEntregaDevolucion.Value, combustibleEntrada, kilometrajeEntrada, montoMora);

                if (ok)
                {
                    MessageBox.Show("Devolución registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _contrato = _controller.ObtenerContrato(alq.IdAlquiler);
                    MostrarContrato();
                    btnConfirmar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la devolución.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
