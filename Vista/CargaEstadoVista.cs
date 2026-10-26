using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaEstadoVista : UserControl
    {
        private readonly EstadoController _controller = new();
        private Estado? _estadoEditar;

        public CargaEstadoVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        public void SetEstado(Estado estado)
        {
            _estadoEditar = estado;
            lblTitulo.Text = "Editar Estado";
            btnGuardar.Text = "Actualizar Estado";
            txtNombre.Text = estado.Nombre;
            txtDescripcion.Text = estado.Descripcion ?? "";
        }

        public void LimpiarFormulario()
        {
            _estadoEditar = null;
            lblTitulo.Text = "Registrar Estado";
            btnGuardar.Text = "Guardar Estado";
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var estado = _estadoEditar ?? new Estado();
                estado.Nombre = txtNombre.Text.Trim();
                estado.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();
                estado.Activo = true;

                var errores = _controller.ValidarEstado(estado);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.Guardar(estado);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _estadoEditar == null ? "Estado registrado correctamente." : "Estado actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
