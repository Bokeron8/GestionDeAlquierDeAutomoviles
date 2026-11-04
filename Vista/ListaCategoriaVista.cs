using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaCategoriaVista : UserControl
    {
        private readonly CategoriaController _controller = new();

        public ListaCategoriaVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            dgvCategorias.SelectionChanged += (_, _) => ActualizarBotonBaja();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaCategoria.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaCategoria);
        }

        public void Refrescar()
        {
            var lista = _controller.Listar();
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = lista;

            if (dgvCategorias.Columns["IdCategoria"] != null)
            {
                dgvCategorias.Columns["IdCategoria"].HeaderText = "ID";
                dgvCategorias.Columns["IdCategoria"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvCategorias.Columns["IdCategoria"].Width = 50;
            }
            if (dgvCategorias.Columns["Nombre"] != null)
                dgvCategorias.Columns["Nombre"].HeaderText = "Categoría";
            if (dgvCategorias.Columns["Descripcion"] != null)
                dgvCategorias.Columns["Descripcion"].HeaderText = "Descripción";
            if (dgvCategorias.Columns["Activo"] != null)
            {
                dgvCategorias.Columns["Activo"].HeaderText = "Activo";
                dgvCategorias.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvCategorias.Columns["Activo"].Width = 60;
            }

            ActualizarBotonBaja();
        }

        private void ActualizarBotonBaja()
        {
            bool hayFila = dgvCategorias.CurrentRow != null;
            bool activo = hayFila && Convert.ToBoolean(dgvCategorias.CurrentRow!.Cells["Activo"].Value);

            btnEliminar.Enabled = hayFila;
            btnEliminar.Text = hayFila && !activo ? "Restaurar" : "Dar de baja";
            btnEliminar.BackColor = hayFila && !activo
                ? System.Drawing.Color.FromArgb(40, 140, 80)
                : System.Drawing.Color.FromArgb(180, 40, 40);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una categoría para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["IdCategoria"].Value);
            var cat = _controller.BuscarPorId(id);
            if (cat == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionCategoria(cat);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una categoría para dar de baja o restaurar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["IdCategoria"].Value);
            string nombre = dgvCategorias.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";
            bool activo = Convert.ToBoolean(dgvCategorias.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja la categoría {nombre}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;

                _controller.Eliminar(id);
            }
            else
            {
                var result = MessageBox.Show(
                    $"¿Desea restaurar la categoría {nombre}?",
                    "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                _controller.Restaurar(id);
            }

            Refrescar();
        }
    }
}
