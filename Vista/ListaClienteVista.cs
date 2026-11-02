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
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaCliente.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaCliente);
        }

        public void Refrescar()
        {
            string termino = FiltroBusqueda.Normalizar(txtBuscar.Text);
            var lista = _controller.Listar();
            if (termino.Length > 0)
            {
                lista = lista.Where(c =>
                    c.IdCliente.ToString().Contains(termino) ||
                    FiltroBusqueda.Contiene(c.Apellido, termino) ||
                    FiltroBusqueda.Contiene(c.Nombre, termino) ||
                    FiltroBusqueda.Contiene(c.Dni, termino) ||
                    FiltroBusqueda.Contiene(c.Correo, termino)).ToList();
            }

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
            if (dgvClientes.Columns["Provincia"] != null)
                dgvClientes.Columns["Provincia"].HeaderText = "Provincia";
            if (dgvClientes.Columns["Activo"] != null)
            {
                dgvClientes.Columns["Activo"].HeaderText = "Activo";
                dgvClientes.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvClientes.Columns["Activo"].Width = 60;
            }

            // Nombre and apellido already travel separately, so the combined labels would
            // only duplicate them at the cost of grid width.
            string[] ocultas = ["NombreCompleto", "Descripcion"];
            foreach (string columna in ocultas)
            {
                if (dgvClientes.Columns[columna] != null)
                    dgvClientes.Columns[columna].Visible = false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Refrescar();
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
                    Refrescar();
                }
            }
            else
            {
                MessageBox.Show($"El cliente {nombre} {apellido} ya se encuentra inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
