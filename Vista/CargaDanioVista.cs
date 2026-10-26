using System;
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
        }

        private void CargarAlquileres()
        {
            var alquileres = _controller.ObtenerAlquileres();
            cbAlquiler.DataSource = alquileres;
            cbAlquiler.DisplayMember = "IdAlquiler";
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
                var danio = _danioEditar ?? new Danio();
                danio.IdAlquiler = Convert.ToInt32(cbAlquiler.SelectedValue);
                danio.Zona = txtZona.Text.Trim();
                danio.Descripcion = txtDescripcion.Text.Trim();
                danio.EvidenciaFotografica = string.IsNullOrWhiteSpace(txtEvidencia.Text) ? null : txtEvidencia.Text.Trim();
                danio.Activo = true;

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
