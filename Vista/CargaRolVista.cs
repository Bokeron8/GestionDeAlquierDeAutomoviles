using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaRolVista : UserControl
    {
        private readonly RolController _controller = new();
        private Rol? _rolEditar;

        public CargaRolVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        public void SetRol(Rol rol)
        {
            _rolEditar = rol;
            lblTitulo.Text = "Editar Rol";
            btnGuardar.Text = "Actualizar Rol";
            txtNombre.Text = rol.NombreRol;
            txtDescripcion.Text = rol.Descripcion ?? "";
        }

        public void LimpiarFormulario()
        {
            _rolEditar = null;
            lblTitulo.Text = "Registrar Rol";
            btnGuardar.Text = "Guardar Rol";
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var rol = _rolEditar ?? new Rol();
                rol.NombreRol = txtNombre.Text.Trim();
                rol.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();
                rol.Activo = true;

                var errores = _controller.ValidarRol(rol);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.Guardar(rol);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _rolEditar == null ? "Rol registrado correctamente." : "Rol actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
