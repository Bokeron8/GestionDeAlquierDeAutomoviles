using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaEmpleadoVista : UserControl
    {
        private readonly EmpleadoController _controller = new();
        private Empleado? _empleadoEditar;

        public CargaEmpleadoVista()
        {
            InitializeComponent();
            Load += CargaEmpleadoVista_Load;
            btnGuardar.Click += btnGuardar_Click;
        }

        public void SetEmpleado(Empleado emp)
        {
            _empleadoEditar = emp;
            chkActivo.Visible = true;
            txtNombre.Text = emp.Nombre;
            txtApellido.Text = emp.Apellido;
            txtDni.Text = emp.Dni;
            dtpFechaNacimiento.Value = emp.FechaNacimiento;
            txtDireccion.Text = emp.Direccion ?? "";
            txtTelefono.Text = emp.Telefono ?? "";
            txtCorreo.Text = emp.Correo ?? "";
            dtpFechaContratacion.Value = emp.FechaContratacion;
            chkActivo.Checked = emp.Activo;
            txtUsuario.Text = emp.Usuario ?? "";
            txtContrasenia.Text = emp.Contrasenia ?? "";

            var roles = _controller.ObtenerRoles();
            cbRol.DataSource = roles;
            cbRol.DisplayMember = "NombreRol";
            cbRol.ValueMember = "IdRol";
            cbRol.SelectedValue = emp.IdRol;

            lblTitulo.Text = "Editar Empleado";
            btnGuardar.Text = "Actualizar Empleado";
        }

        private void CargaEmpleadoVista_Load(object sender, EventArgs e)
        {
            var roles = _controller.ObtenerRoles();
            cbRol.DataSource = roles;
            cbRol.DisplayMember = "NombreRol";
            cbRol.ValueMember = "IdRol";
            chkActivo.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var emp = _empleadoEditar != null
                    ? _empleadoEditar
                    : new Empleado();

                emp.Nombre = txtNombre.Text.Trim();
                emp.Apellido = txtApellido.Text.Trim();
                emp.Dni = txtDni.Text.Trim();
                emp.FechaNacimiento = dtpFechaNacimiento.Value;
                emp.Direccion = txtDireccion.Text.Trim();
                emp.Telefono = txtTelefono.Text.Trim();
                emp.Correo = txtCorreo.Text.Trim();
                emp.FechaContratacion = dtpFechaContratacion.Value;
                emp.Activo = chkActivo.Checked;
                emp.IdRol = Convert.ToInt32(cbRol.SelectedValue);
                emp.Usuario = txtUsuario.Text.Trim();

                if (_empleadoEditar == null)
                {
                    emp.Contrasenia = txtContrasenia.Text.Trim();
                }
                else
                {
                    string nuevaContrasenia = txtContrasenia.Text.Trim();
                    if (!string.IsNullOrEmpty(nuevaContrasenia))
                        emp.Contrasenia = nuevaContrasenia;
                }

                int rows = _controller.Guardar(emp);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _empleadoEditar != null ? "Empleado actualizado correctamente" : "Empleado guardado correctamente",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
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

        public void LimpiarFormulario()
        {
            _empleadoEditar = null;
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtUsuario.Clear();
            txtContrasenia.Clear();
            chkActivo.Checked = true;
            chkActivo.Visible = false;
            lblTitulo.Text = "Agregar Empleado";
            btnGuardar.Text = "Guardar Empleado";
        }
    }
}
