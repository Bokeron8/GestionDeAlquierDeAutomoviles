using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaEmpleadoVista : UserControl
    {
        private readonly EmpleadoController _controller = new();

        public CargaEmpleadoVista()
        {
            InitializeComponent();
            Load += CargaEmpleadoVista_Load;
            btnGuardar.Click += btnGuardar_Click;
        }

        private void CargaEmpleadoVista_Load(object sender, EventArgs e)
        {
            var roles = _controller.ObtenerRoles();
            cbRol.DataSource = roles;
            cbRol.DisplayMember = "NombreRol";
            cbRol.ValueMember = "IdRol";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var emp = new Empleado
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = txtDni.Text.Trim(),
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    FechaContratacion = dtpFechaContratacion.Value,
                    Activo = true,
                    IdRol = Convert.ToInt32(cbRol.SelectedValue),
                    Usuario = txtUsuario.Text.Trim(),
                    Contrasenia = txtContrasenia.Text.Trim()
                };

                int rows = _controller.Guardar(emp);
                if (rows > 0)
                {
                    MessageBox.Show("Empleado guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar el empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
