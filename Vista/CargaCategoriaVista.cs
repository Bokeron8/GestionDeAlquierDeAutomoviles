using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaCategoriaVista : UserControl
    {
        private readonly CategoriaController _controller = new();
        private Categoria? _categoriaEditar;

        public CargaCategoriaVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        public void SetCategoria(Categoria cat)
        {
            _categoriaEditar = cat;
            lblTitulo.Text = "Editar Categoría";
            btnGuardar.Text = "Actualizar Categoría";
            txtNombre.Text = cat.Nombre;
            txtDescripcion.Text = cat.Descripcion ?? "";
        }

        public void LimpiarFormulario()
        {
            _categoriaEditar = null;
            lblTitulo.Text = "Agregar Categoría";
            btnGuardar.Text = "Guardar Categoría";
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var cat = _categoriaEditar ?? new Categoria();
                cat.Nombre = txtNombre.Text.Trim();
                cat.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();
                cat.Activo = true;

                var errores = _controller.ValidarCategoria(cat);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.Guardar(cat);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _categoriaEditar == null ? "Categoría registrada correctamente." : "Categoría actualizada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
