using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaModeloVista : UserControl
    {
        private readonly ModeloController _controller = new();

        public ListaModeloVista()
        {
            InitializeComponent();
            Load += ListaModeloVista_Load;
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void ListaModeloVista_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaModelo.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaModelo);
        }

        private void CargarDatos()
        {
            var lista = _controller.Listar();
            dgvModelos.DataSource = null;
            dgvModelos.DataSource = lista;

            if (dgvModelos.Columns["IdModelo"] != null)
            {
                dgvModelos.Columns["IdModelo"].HeaderText = "ID";
                dgvModelos.Columns["IdModelo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvModelos.Columns["IdModelo"].Width = 50;
            }
            if (dgvModelos.Columns["NombreModelo"] != null)
                dgvModelos.Columns["NombreModelo"].HeaderText = "Modelo";
            if (dgvModelos.Columns["IdMarca"] != null)
                dgvModelos.Columns["IdMarca"].HeaderText = "ID Marca";
            if (dgvModelos.Columns["Activo"] != null)
            {
                dgvModelos.Columns["Activo"].HeaderText = "Activo";
                dgvModelos.Columns["Activo"].Width = 60;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvModelos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un modelo para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvModelos.CurrentRow.Cells["IdModelo"].Value);
            var modelo = _controller.BuscarPorId(id);
            if (modelo == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionModelo(modelo);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvModelos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un modelo para dar de baja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvModelos.CurrentRow.Cells["IdModelo"].Value);
            string nombre = dgvModelos.CurrentRow.Cells["NombreModelo"].Value?.ToString() ?? "";
            bool activo = Convert.ToBoolean(dgvModelos.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja el modelo {nombre}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _controller.Eliminar(id);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show($"El modelo {nombre} ya se encuentra inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
