using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaMarcaVista : UserControl
    {
        private readonly MarcaController _controller = new();

        public ListaMarcaVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaMarca.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaMarca);
        }

        public void Refrescar()
        {
            var lista = _controller.Listar();
            dgvMarcas.DataSource = null;
            dgvMarcas.DataSource = lista;

            if (dgvMarcas.Columns["IdMarca"] != null)
            {
                dgvMarcas.Columns["IdMarca"].HeaderText = "ID";
                dgvMarcas.Columns["IdMarca"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvMarcas.Columns["IdMarca"].Width = 50;
            }
            if (dgvMarcas.Columns["Nombre"] != null)
                dgvMarcas.Columns["Nombre"].HeaderText = "Marca";
            if (dgvMarcas.Columns["Activo"] != null)
            {
                dgvMarcas.Columns["Activo"].HeaderText = "Activo";
                dgvMarcas.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvMarcas.Columns["Activo"].Width = 60;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una marca para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvMarcas.CurrentRow.Cells["IdMarca"].Value);
            var marca = _controller.BuscarPorId(id);
            if (marca == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionMarca(marca);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una marca para dar de baja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvMarcas.CurrentRow.Cells["IdMarca"].Value);
            string nombre = dgvMarcas.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";
            bool activo = Convert.ToBoolean(dgvMarcas.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja la marca {nombre}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _controller.Eliminar(id);
                    Refrescar();
                }
            }
            else
            {
                MessageBox.Show($"La marca {nombre} ya se encuentra inactiva.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
