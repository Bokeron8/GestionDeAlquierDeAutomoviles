using System;
using System.IO;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaVehiculoVista : UserControl
    {
        private readonly VehiculoController _controller = new();
        private Vehiculo? _vehiculoEditar;

        public CargaVehiculoVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
            CargarImagen();
        }

        private void CargarImagen()
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Recursos", "auto.png");
            if (File.Exists(ruta))
            {
                pbAuto.Image = Image.FromFile(ruta);
            }
        }

        private void CargarCombos()
        {
            var modelos = _controller.ObtenerModelos();
            cbModelo.DataSource = modelos;
            cbModelo.DisplayMember = "NombreModelo";
            cbModelo.ValueMember = "IdModelo";

            var categorias = _controller.ObtenerCategorias();
            cbCategoria.DataSource = categorias;
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "IdCategoria";
        }

        public void SetVehiculo(Vehiculo veh)
        {
            _vehiculoEditar = veh;
            lblTitulo.Text = "Editar Vehiculo";
            btnGuardar.Text = "Actualizar Vehiculo";

            txtMatricula.Text = veh.Matricula;
            txtChasis.Text = veh.Chasis;
            txtColor.Text = veh.Color;
            txtAnio.Text = veh.Anio.ToString();

            CargarCombos();
            cbModelo.SelectedValue = veh.IdModelo;
            cbCategoria.SelectedValue = veh.IdCategoria;
        }

        public void LimpiarFormulario()
        {
            _vehiculoEditar = null;
            lblTitulo.Text = "Registrar Nuevo Vehiculo";
            btnGuardar.Text = "Guardar Vehiculo";
            txtMatricula.Clear();
            txtChasis.Clear();
            txtColor.Clear();
            txtAnio.Clear();
            CargarCombos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtAnio.Text, out int anio))
                {
                    MessageBox.Show("El año debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var veh = _vehiculoEditar ?? new Vehiculo();
                veh.Matricula = txtMatricula.Text.Trim();
                veh.Chasis = txtChasis.Text.Trim();
                veh.Color = txtColor.Text.Trim();
                veh.Anio = anio;
                veh.Activo = true;
                veh.IdModelo = Convert.ToInt32(cbModelo.SelectedValue);
                veh.IdCategoria = Convert.ToInt32(cbCategoria.SelectedValue);

                var errores = _controller.ValidarVehiculo(veh, esNuevo: _vehiculoEditar == null);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.Guardar(veh);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _vehiculoEditar == null ? "Vehículo registrado correctamente." : "Vehículo actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el vehículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
