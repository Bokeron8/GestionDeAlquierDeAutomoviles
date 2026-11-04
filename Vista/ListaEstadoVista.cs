using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaEstadoVista : UserControl
    {
        private readonly EstadoController _controller = new();

        public ListaEstadoVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            dgvEstados.SelectionChanged += (_, _) => ActualizarBotonBaja();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaEstado.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaEstado);
        }

        public void Refrescar()
        {
            var lista = _controller.Listar();
            dgvEstados.DataSource = null;
            dgvEstados.DataSource = lista;

            if (dgvEstados.Columns["IdEstado"] != null)
            {
                dgvEstados.Columns["IdEstado"].HeaderText = "ID";
                dgvEstados.Columns["IdEstado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvEstados.Columns["IdEstado"].Width = 50;
            }
            if (dgvEstados.Columns["Nombre"] != null)
                dgvEstados.Columns["Nombre"].HeaderText = "Estado";
            if (dgvEstados.Columns["Descripcion"] != null)
                dgvEstados.Columns["Descripcion"].HeaderText = "Descripción";
            if (dgvEstados.Columns["Activo"] != null)
            {
                dgvEstados.Columns["Activo"].HeaderText = "Activo";
                dgvEstados.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvEstados.Columns["Activo"].Width = 60;
            }

            ActualizarBotonBaja();
        }

        private void ActualizarBotonBaja()
        {
            bool hayFila = dgvEstados.CurrentRow != null;
            bool activo = hayFila && Convert.ToBoolean(dgvEstados.CurrentRow!.Cells["Activo"].Value);

            btnEliminar.Enabled = hayFila;
            btnEliminar.Text = hayFila && !activo ? "Restaurar" : "Dar de baja";
            btnEliminar.BackColor = hayFila && !activo
                ? System.Drawing.Color.FromArgb(40, 140, 80)
                : System.Drawing.Color.FromArgb(180, 40, 40);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEstados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estado para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvEstados.CurrentRow.Cells["IdEstado"].Value);
            var estado = _controller.BuscarPorId(id);
            if (estado == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionEstado(estado);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEstados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estado para dar de baja o restaurar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvEstados.CurrentRow.Cells["IdEstado"].Value);
            string nombre = dgvEstados.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";
            bool activo = Convert.ToBoolean(dgvEstados.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja el estado {nombre}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;

                _controller.Eliminar(id);
            }
            else
            {
                var result = MessageBox.Show(
                    $"¿Desea restaurar el estado {nombre}?",
                    "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                _controller.Restaurar(id);
            }

            Refrescar();
        }
    }
}
