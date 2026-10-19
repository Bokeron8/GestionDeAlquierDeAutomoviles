using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaModeloVista : UserControl
    {
        private readonly ModeloController _controller = new();
        private ModeloVehiculo? _modeloEditar;

        public CargaModeloVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        private void CargarMarcas()
        {
            var marcas = _controller.ObtenerMarcas();
            cbMarca.DataSource = marcas;
            cbMarca.DisplayMember = "Nombre";
            cbMarca.ValueMember = "IdMarca";
        }

        public void SetModelo(ModeloVehiculo modelo)
        {
            _modeloEditar = modelo;
            lblTitulo.Text = "Editar Modelo";
            btnGuardar.Text = "Actualizar Modelo";
            txtNombre.Text = modelo.NombreModelo;
            CargarMarcas();
            cbMarca.SelectedValue = modelo.IdMarca;
        }

        public void LimpiarFormulario()
        {
            _modeloEditar = null;
            lblTitulo.Text = "Agregar Modelo";
            btnGuardar.Text = "Guardar Modelo";
            txtNombre.Clear();
            CargarMarcas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var modelo = _modeloEditar ?? new ModeloVehiculo();
                modelo.NombreModelo = txtNombre.Text.Trim();
                modelo.IdMarca = Convert.ToInt32(cbMarca.SelectedValue);
                modelo.Activo = true;

                var errores = _controller.ValidarModelo(modelo);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.Guardar(modelo);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _modeloEditar == null ? "Modelo registrado correctamente." : "Modelo actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el modelo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
