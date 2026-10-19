using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaMarcaVista : UserControl
    {
        private readonly MarcaController _controller = new();
        private Marca? _marcaEditar;

        public CargaMarcaVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        public void SetMarca(Marca marca)
        {
            _marcaEditar = marca;
            lblTitulo.Text = "Editar Marca";
            btnGuardar.Text = "Actualizar Marca";
            txtNombre.Text = marca.Nombre;
        }

        public void LimpiarFormulario()
        {
            _marcaEditar = null;
            lblTitulo.Text = "Agregar Marca";
            btnGuardar.Text = "Guardar Marca";
            txtNombre.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var marca = _marcaEditar ?? new Marca();
                marca.Nombre = txtNombre.Text.Trim();
                marca.Activo = true;

                var errores = _controller.ValidarMarca(marca);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.Guardar(marca);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _marcaEditar == null ? "Marca registrada correctamente." : "Marca actualizada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
