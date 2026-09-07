using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaEmpleadoVista : UserControl
    {
        private readonly EmpleadoController _controller = new();
        private CargaEmpleadoVista? _cargaVista;

        public ListaEmpleadoVista()
        {
            InitializeComponent();
            Load += ListaEmpleadoVista_Load;
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaEmpleado.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaEmpleado);
        }

        private void ListaEmpleadoVista_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            var lista = _controller.Listar();
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = lista;

            if (dgvEmpleados.Columns["contrasenia"] != null)
                dgvEmpleados.Columns["contrasenia"].Visible = false;
            if (dgvEmpleados.Columns["usuario"] != null)
                dgvEmpleados.Columns["usuario"].Visible = false;
            if (dgvEmpleados.Columns["id_empleado"] != null)
            {
                dgvEmpleados.Columns["id_empleado"].HeaderText = "ID";
                dgvEmpleados.Columns["id_empleado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvEmpleados.Columns["id_empleado"].Width = 50;
            }
            if (dgvEmpleados.Columns["id_rol"] != null)
            {
                dgvEmpleados.Columns["id_rol"].HeaderText = "Rol";
                dgvEmpleados.Columns["id_rol"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvEmpleados.Columns["id_rol"].Width = 80;
            }
            if (dgvEmpleados.Columns["activo"] != null)
            {
                dgvEmpleados.Columns["activo"].HeaderText = "Activo";
                dgvEmpleados.Columns["activo"].Width = 60;
            }
            if (dgvEmpleados.Columns["fecha_nacimiento"] != null)
                dgvEmpleados.Columns["fecha_nacimiento"].HeaderText = "F. Nacimiento";
            if (dgvEmpleados.Columns["fecha_contratacion"] != null)
                dgvEmpleados.Columns["fecha_contratacion"].HeaderText = "F. Contratación";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string termino = txtBuscar.Text.Trim();
            var lista = string.IsNullOrEmpty(termino)
                ? _controller.Listar()
                : _controller.Buscar(termino);
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = lista;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
            var emp = _controller.BuscarPorId(id);
            if (emp == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionEmpleado(emp);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado para dar de baja o restaurar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
            string nombre = dgvEmpleados.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";
            string apellido = dgvEmpleados.CurrentRow.Cells["Apellido"].Value?.ToString() ?? "";
            bool activo = Convert.ToBoolean(dgvEmpleados.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja al empleado {nombre} {apellido}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _controller.Eliminar(id);
                    CargarDatos();
                    txtBuscar_TextChanged(sender, e);
                }
            }
            else
            {
                var result = MessageBox.Show(
                    $"¿Desea restaurar al empleado {nombre} {apellido}?",
                    "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Empleado.Restaurar(id);
                    CargarDatos();
                    txtBuscar_TextChanged(sender, e);
                }
            }
        }
    }
}
