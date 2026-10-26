using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaClienteVista : UserControl
    {
        private readonly ClienteController _controller = new();
        private Cliente? _clienteEditar;

        public CargaClienteVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        public void SetCliente(Cliente cli)
        {
            _clienteEditar = cli;
            lblTitulo.Text = "Editar Cliente";
            btnGuardar.Text = "Actualizar Cliente";

            txtNombre.Text = cli.Nombre;
            txtApellido.Text = cli.Apellido;
            txtDni.Text = cli.Dni;
            dtpFechaNacimiento.Value = cli.FechaNacimiento;
            txtDireccion.Text = cli.Direccion ?? "";
            txtTelefono.Text = cli.Telefono;
            txtCorreo.Text = cli.Correo;
            txtNroLicencia.Text = cli.NroLicencia;
            dtpVencimientoLicencia.Value = cli.VencimientoLicencia;
            txtProvincia.Text = cli.Provincia;
        }

        public void LimpiarFormulario()
        {
            _clienteEditar = null;
            lblTitulo.Text = "Agregar Cliente";
            btnGuardar.Text = "Guardar Cliente";

            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtNroLicencia.Clear();
            dtpVencimientoLicencia.Value = DateTime.Today.AddYears(1);
            txtProvincia.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var cli = _clienteEditar ?? new Cliente();
                cli.Nombre = txtNombre.Text.Trim();
                cli.Apellido = txtApellido.Text.Trim();
                cli.Dni = txtDni.Text.Trim();
                cli.FechaNacimiento = dtpFechaNacimiento.Value;
                cli.Direccion = txtDireccion.Text.Trim();
                cli.Telefono = txtTelefono.Text.Trim();
                cli.Correo = txtCorreo.Text.Trim();
                cli.NroLicencia = txtNroLicencia.Text.Trim();
                cli.VencimientoLicencia = dtpVencimientoLicencia.Value;
                cli.Provincia = txtProvincia.Text.Trim();
                cli.Activo = true;

                var errores = _controller.ValidarCliente(cli, esNuevo: _clienteEditar == null);
                if (errores.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errores), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = _controller.Guardar(cli);
                if (rows > 0)
                {
                    MessageBox.Show(
                        _clienteEditar == null ? "Cliente registrado correctamente." : "Cliente actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
