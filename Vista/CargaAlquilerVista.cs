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
            txtBuscarReserva.TextChanged += txtBuscarReserva_TextChanged;
            cbReserva.SelectedIndexChanged += (_, _) => ActualizarResumen();
        }

        private List<Reserva> _todasReservas = [];

        private void CargarReservas()
        {
            // The picker shows client, vehicle and dates instead of the reservation number,
            // so the operator cannot hand over the wrong car.
            _todasReservas = _controller.ObtenerReservasDisponibles(_alquilerEditar?.IdReserva ?? 0);
            FiltrarReservas();
        }

        private void FiltrarReservas()
        {
            string termino = FiltroBusqueda.Normalizar(txtBuscarReserva.Text);
            var filtradas = _todasReservas.Where(r =>
                termino.Length == 0 ||
                r.IdReserva.ToString().Contains(termino) ||
                FiltroBusqueda.Contiene(r.NombreCliente, termino) ||
                FiltroBusqueda.Contiene(r.DniCliente, termino) ||
                FiltroBusqueda.Contiene(r.MatriculaVehiculo, termino) ||
                FiltroBusqueda.Contiene(r.VehiculoDescripcion, termino)).ToList();

            cbReserva.DataSource = null;
            cbReserva.DataSource = filtradas;
            cbReserva.DisplayMember = "DescripcionCombo";
            cbReserva.ValueMember = "IdReserva";
        }

        private void txtBuscarReserva_TextChanged(object sender, EventArgs e)
        {
            FiltrarReservas();
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

            ActualizarResumen();
        }

        public void LimpiarFormulario()
        {
            _alquilerEditar = null;
            lblTitulo.Text = "Registrar Entrega";
            btnGuardar.Text = "Registrar Entrega";
            txtCombustibleSalida.Clear();
            txtKilometrajeSalida.Clear();
            CargarReservas();
            ActualizarResumen();
        }

        /// <summary>
        /// Read-only card with everything the operator must verify before handing over the
        /// car: who is renting, which vehicle, the agreed dates and the estimated total.
        /// </summary>
        private void ActualizarResumen()
        {
            var reserva = cbReserva.SelectedItem as Reserva;
            if (reserva == null)
            {
                lblResumen.Text = "Seleccione una reserva confirmada para ver el detalle.";
                lblAvisoLicencia.Visible = false;
                lblAvisoLicencia.Text = "";
                return;
            }

            var cliente = _controller.ObtenerCliente(reserva.IdCliente);
            var vehiculo = _controller.ObtenerVehiculo(reserva.IdVehiculo);

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

            int dias = Math.Max(1, (reserva.FechaFinReserva.Date - reserva.FechaInicioReserva.Date).Days);
            decimal total = dias * reserva.PrecioDiarioPactado;

            lblResumen.Text =
                $"Reserva #{reserva.IdReserva} · {reserva.NombreEstado}{Environment.NewLine}" +
                $"{clienteTexto}{Environment.NewLine}" +
                $"{contactoTexto}{Environment.NewLine}" +
                $"{vehiculoTexto}{Environment.NewLine}" +
                $"{detalleVehiculoTexto}{Environment.NewLine}" +
                $"Del {reserva.FechaInicioReserva:dd/MM/yyyy} al {reserva.FechaFinReserva:dd/MM/yyyy} · {dias} día(s){Environment.NewLine}" +
                $"Precio diario: $ {reserva.PrecioDiarioPactado:0.00}{Environment.NewLine}" +
                $"Total estimado: $ {total:0.00}";

            AdvertirLicencia(reserva, cliente);
        }

        /// <summary>
        /// A licence that expired before the reservation starts is exactly the human error
        /// the card has to surface before the car leaves the lot.
        /// </summary>
        private void AdvertirLicencia(Reserva reserva, Cliente? cliente)
        {
            bool vencida = cliente != null && cliente.VencimientoLicencia.Date < reserva.FechaInicioReserva.Date;
            lblAvisoLicencia.Visible = vencida;
            lblAvisoLicencia.Text = vencida && cliente != null
                ? $"Licencia vencida el {cliente.VencimientoLicencia:dd/MM/yyyy}. Verificar antes de entregar."
                : "";
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
