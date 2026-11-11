using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class DevolucionVista : UserControl
    {
        private static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("es-AR");

        private readonly AlquilerController _controller = new();
        private ContratoAlquiler? _contrato;

        public DevolucionVista()
        {
            InitializeComponent();
            btnConfirmar.Click += btnConfirmar_Click;
            dtpFechaDevolucion.ValueChanged += (_, _) => { RecalcularMora(); ActualizarResumenFinanciero(); };
            txtMontoMora.TextChanged += (_, _) => { ValidarEntradas(); ActualizarResumenFinanciero(); };
            txtKilometrajeEntrada.TextChanged += (_, _) => { ValidarEntradas(); ActualizarResumenFinanciero(); };
            txtCombustibleEntrada.TextChanged += (_, _) => { ValidarEntradas(); ActualizarResumenFinanciero(); };
        }

        public void SetAlquiler(int idAlquiler)
        {
            _contrato = _controller.ObtenerContrato(idAlquiler);
            if (_contrato == null)
            {
                lblContrato.Text = "No se encontró el alquiler seleccionado.";
                lblReferencia.Text = "";
                lblErrores.Text = "";
                lblDerivados.Text = "";
                btnConfirmar.Enabled = false;
                return;
            }

            MostrarContrato();

            // The delivery readings are reference data, not the answer: the operator has to
            // type the return values, otherwise an untouched field would record zero kilometres.
            lblReferencia.Text =
                $"Al entregar: {_contrato.KilometrajeSalida.ToString("N0", Cultura)} km · " +
                $"{_contrato.CombustibleSalida.ToString("0", Cultura)}% de combustible";
            txtKilometrajeEntrada.Text = "";
            txtCombustibleEntrada.Text = "";

            dtpFechaDevolucion.Value = DateTime.Now < _contrato.FechaEntregaReal ? _contrato.FechaEntregaReal : DateTime.Now;
            RecalcularMora();
            ActualizarResumenFinanciero();
            ValidarEntradas();
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
                $"Precio diario pactado: {_contrato.PrecioDiarioPactado.ToString("C2", Cultura)}{Environment.NewLine}" +
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
            txtMontoMora.Text = mora.ToString("0.00", Cultura);
        }

        /// <summary>
        /// Everything the operator could get wrong is reported next to the fields while they
        /// type, instead of all at once after pressing the button.
        /// </summary>
        private void ValidarEntradas()
        {
            if (_contrato == null)
            {
                lblErrores.Text = "";
                btnConfirmar.Enabled = false;
                return;
            }

            var errores = new List<string>();

            if (!LeerDecimal(txtKilometrajeEntrada.Text, out decimal kilometraje))
                errores.Add("Ingrese el kilometraje al devolver.");
            else if (kilometraje < _contrato.KilometrajeSalida)
                errores.Add($"El kilometraje al devolver no puede ser menor a {_contrato.KilometrajeSalida.ToString("N0", Cultura)} km.");

            if (!LeerDecimal(txtCombustibleEntrada.Text, out decimal combustible))
                errores.Add("Ingrese el combustible al devolver (0 a 100).");
            else if (combustible < 0 || combustible > 100)
                errores.Add("El combustible al devolver debe estar entre 0 y 100.");

            if (!LeerDecimal(txtMontoMora.Text, out decimal mora))
                errores.Add("El monto de mora debe ser un valor numérico.");
            else if (mora < 0)
                errores.Add("El monto de mora no puede ser negativo.");

            lblErrores.Text = string.Join("   ·   ", errores);
            btnConfirmar.Enabled = errores.Count == 0 && _contrato.Activo;
        }

        private void ActualizarResumenFinanciero()
        {
            if (lblResumenFinanciero == null) return;
            if (_contrato == null)
            {
                lblResumenFinanciero.Text = "Seleccione un alquiler.";
                lblDerivados.Text = "";
                return;
            }

            int dias = (dtpFechaDevolucion.Value.Date - _contrato.FechaEntregaReal.Date).Days;
            if (dias < 1) dias = 1;

            decimal subtotal = dias * _contrato.PrecioDiarioPactado;
            LeerDecimal(txtMontoMora.Text, out decimal mora);
            decimal total = subtotal + mora;

            lblResumenFinanciero.Text =
                $"Días facturados: {dias} (del {_contrato.FechaEntregaReal:dd/MM} al {dtpFechaDevolucion.Value:dd/MM}){Environment.NewLine}" +
                $"Subtotal alquiler: {subtotal.ToString("C2", Cultura)}  |  Mora por atraso: {mora.ToString("C2", Cultura)}{Environment.NewLine}" +
                $"TOTAL A COBRAR AL CLIENTE: {total.ToString("C2", Cultura)}";

            MostrarDerivados();
        }

        /// <summary>
        /// Turns the two raw readings into the numbers the manager actually checks: how far the
        /// vehicle was driven and how much fuel came back.
        /// </summary>
        private void MostrarDerivados()
        {
            if (_contrato == null) return;

            var partes = new List<string>();
            bool combustibleBajo = false;

            if (LeerDecimal(txtKilometrajeEntrada.Text, out decimal kilometraje) &&
                kilometraje >= _contrato.KilometrajeSalida)
            {
                decimal recorridos = kilometraje - _contrato.KilometrajeSalida;
                partes.Add($"Kilómetros recorridos: {recorridos.ToString("N0", Cultura)} km");
            }

            if (LeerDecimal(txtCombustibleEntrada.Text, out decimal combustible) &&
                combustible >= 0 && combustible <= 100)
            {
                decimal diferencia = combustible - _contrato.CombustibleSalida;
                partes.Add($"Combustible: entregado {_contrato.CombustibleSalida:0}% → devuelto {combustible:0}% " +
                           $"({diferencia.ToString("+0;-0;0", Cultura)} puntos)");
                combustibleBajo = diferencia < 0;
            }

            lblDerivados.Text = string.Join("   |   ", partes);
            lblDerivados.ForeColor = combustibleBajo
                ? System.Drawing.Color.FromArgb(180, 40, 40)
                : System.Drawing.Color.FromArgb(90, 90, 110);
        }

        private static bool LeerDecimal(string texto, out decimal valor)
        {
            return decimal.TryParse(texto.Trim(), NumberStyles.Number, Cultura, out valor);
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

                if (!LeerDecimal(txtKilometrajeEntrada.Text, out decimal kilometrajeEntrada))
                {
                    MessageBox.Show("El kilometraje al devolver debe ser un valor numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!LeerDecimal(txtCombustibleEntrada.Text, out decimal combustibleEntrada))
                {
                    MessageBox.Show("El combustible al devolver debe ser un valor numérico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!LeerDecimal(txtMontoMora.Text, out decimal montoMora))
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
                    ValidarEntradas();
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
