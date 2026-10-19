using System;
using System.Linq;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaClienteVista : UserControl
    {
        private readonly ClienteController _controller = new();

        public ListaClienteVista()
        {
            InitializeComponent();
            Load += ListaClienteVista_Load;
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void ListaClienteVista_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaCliente.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaCliente);
        }

        private void CargarDatos()
        {
            var lista = _controller.Listar();
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = lista;

            if (dgvClientes.Columns["IdCliente"] != null)
            {
                dgvClientes.Columns["IdCliente"].HeaderText = "ID";
                dgvClientes.Columns["IdCliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvClientes.Columns["IdCliente"].Width = 50;
            }
            if (dgvClientes.Columns["Nombre"] != null)
                dgvClientes.Columns["Nombre"].HeaderText = "Nombre";
            if (dgvClientes.Columns["Apellido"] != null)
                dgvClientes.Columns["Apellido"].HeaderText = "Apellido";
            if (dgvClientes.Columns["Dni"] != null)
                dgvClientes.Columns["Dni"].HeaderText = "DNI";
            if (dgvClientes.Columns["Telefono"] != null)
                dgvClientes.Columns["Telefono"].HeaderText = "Teléfono";
            if (dgvClientes.Columns["Correo"] != null)
                dgvClientes.Columns["Correo"].HeaderText = "Correo";
            if (dgvClientes.Columns["NroLicencia"] != null)
                dgvClientes.Columns["NroLicencia"].HeaderText = "N° Licencia";
            if (dgvClientes.Columns["VencimientoLicencia"] != null)
                dgvClientes.Columns["VencimientoLicencia"].HeaderText = "Venc. Licencia";
            if (dgvClientes.Columns["EstadoIdentidad"] != null)
                dgvClientes.Columns["EstadoIdentidad"].HeaderText = "Identidad";
            if (dgvClientes.Columns["Activo"] != null)
            {
                dgvClientes.Columns["Activo"].HeaderText = "Activo";
                dgvClientes.Columns["Activo"].Width = 60;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);
            var cli = _controller.BuscarPorId(id);
            if (cli == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionCliente(cli);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para dar de baja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);
            string nombre = dgvClientes.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";
            string apellido = dgvClientes.CurrentRow.Cells["Apellido"].Value?.ToString() ?? "";
            bool activo = Convert.ToBoolean(dgvClientes.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja al cliente {nombre} {apellido}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _controller.Eliminar(id);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show($"El cliente {nombre} {apellido} ya se encuentra inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
