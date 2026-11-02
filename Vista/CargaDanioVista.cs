using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaDanioVista : UserControl
    {
        private readonly DanioController _controller = new();
        private Danio? _danioEditar;

        public CargaDanioVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
            btnExaminar.Click += btnExaminar_Click;
            cbAlquiler.SelectedIndexChanged += (s, e) => ActualizarResumen();
            txtEvidencia.TextChanged += (s, e) => MostrarEvidencia(txtEvidencia.Text);
        }

        /// <summary>
        /// Only rentals that are still open can receive a damage. When editing, the rental
        /// the record already points to is added even if it was closed, so saving never
        /// reassigns the damage to a different contract.
        /// </summary>
        private void CargarAlquileres()
        {
            var alquileres = _controller.ObtenerAlquileres(_danioEditar?.IdAlquiler);
            cbAlquiler.DataSource = alquileres;
            cbAlquiler.DisplayMember = "DescripcionCombo";
            cbAlquiler.ValueMember = "IdAlquiler";
        }

        public void SetDanio(Danio danio)
        {
            _danioEditar = danio;
            lblTitulo.Text = "Editar Daño";
            btnGuardar.Text = "Actualizar Daño";

            CargarAlquileres();
            cbAlquiler.SelectedValue = danio.IdAlquiler;

            txtZona.Text = danio.Zona;
            txtDescripcion.Text = danio.Descripcion;
            txtEvidencia.Text = danio.EvidenciaFotografica ?? "";

            ActualizarResumen();
        }

        public void LimpiarFormulario()
        {
            _danioEditar = null;
            lblTitulo.Text = "Registrar Daño";
            btnGuardar.Text = "Registrar Daño";
            txtZona.Clear();
            txtDescripcion.Clear();
            txtEvidencia.Clear();
            CargarAlquileres();
            ActualizarResumen();
        }

        /// <summary>
        /// Read-only card with the rental the damage belongs to, mirroring the summary the
        /// return screen shows.
        /// </summary>
        private void ActualizarResumen()
        {
            if (cbAlquiler.SelectedItem is not Alquiler alquiler)
            {
                lblResumen.Text = "No hay alquileres en curso para registrar un daño.";
                cbAlquiler.Enabled = false;
                return;
            }

            lblResumen.Text =
                $"Cliente:  {alquiler.DescripcionCliente}\n" +
                $"Vehículo: {alquiler.DescripcionVehiculo}\n" +
                $"Entrega:  {alquiler.FechaEntregaReal:dd/MM/yyyy}\n" +
                $"Estado:   {alquiler.Estado}";

            cbAlquiler.Enabled = alquiler.Activo;
        }

        private void MostrarEvidencia(string ruta)
        {
            var anterior = picEvidencia.Image;
            picEvidencia.Image = null;
            anterior?.Dispose();

            if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
            {
                lblEvidenciaVista.Text = string.IsNullOrWhiteSpace(ruta)
                    ? "Evidencia"
                    : "Evidencia (no encontrada)";
                return;
            }

            try
            {
                var bytes = File.ReadAllBytes(ruta);
                using var memoria = new MemoryStream(bytes);
                using var original = Image.FromStream(memoria);
                picEvidencia.Image = new Bitmap(original);
                lblEvidenciaVista.Text = Path.GetFileName(ruta);
            }
            catch (Exception)
            {
                lblEvidenciaVista.Text = "Evidencia (no se pudo abrir)";
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtEvidencia.Text = dlg.FileName;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAlquiler.SelectedItem is not Alquiler)
                {
                    MessageBox.Show("No hay alquileres en curso para registrar un daño.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string? evidencia = string.IsNullOrWhiteSpace(txtEvidencia.Text)
                    ? null
                    : txtEvidencia.Text.Trim();

                if (evidencia != null && !File.Exists(evidencia))
                {
                    MessageBox.Show(
                        $"No se encuentra el archivo de evidencia:\n{evidencia}",
                        "Evidencia inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var danio = _danioEditar ?? new Danio();
                danio.IdAlquiler = Convert.ToInt32(cbAlquiler.SelectedValue);
                danio.Zona = txtZona.Text.Trim();
                danio.Descripcion = txtDescripcion.Text.Trim();
                danio.EvidenciaFotografica = evidencia;

                // A new damage starts active; editing has to preserve the state it was
                // loaded with instead of reactivating a record that was disabled.
                if (_danioEditar == null) danio.Activo = true;

                var errores = _controller.ValidarDanio(danio);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.Guardar(danio);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _danioEditar == null ? "Daño registrado correctamente." : "Daño actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el daño.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
