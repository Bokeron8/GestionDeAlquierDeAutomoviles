using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaRolVista : UserControl
    {
        private readonly RolController _controller = new();

        public ListaRolVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            dgvRoles.SelectionChanged += (_, _) => ActualizarBotonBaja();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaRol.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaRol);
        }

        public void Refrescar()
        {
            var lista = _controller.Listar();
            dgvRoles.DataSource = null;
            dgvRoles.DataSource = lista;

            if (dgvRoles.Columns["IdRol"] != null)
            {
                dgvRoles.Columns["IdRol"].HeaderText = "ID";
                dgvRoles.Columns["IdRol"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvRoles.Columns["IdRol"].Width = 50;
            }
            if (dgvRoles.Columns["NombreRol"] != null)
                dgvRoles.Columns["NombreRol"].HeaderText = "Rol";
            if (dgvRoles.Columns["Descripcion"] != null)
                dgvRoles.Columns["Descripcion"].HeaderText = "Descripción";
            if (dgvRoles.Columns["Activo"] != null)
            {
                dgvRoles.Columns["Activo"].HeaderText = "Activo";
                dgvRoles.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvRoles.Columns["Activo"].Width = 60;
            }

            ActualizarBotonBaja();
        }

        private void ActualizarBotonBaja()
        {
            bool hayFila = dgvRoles.CurrentRow != null;
            bool activo = hayFila && Convert.ToBoolean(dgvRoles.CurrentRow!.Cells["Activo"].Value);

            btnEliminar.Enabled = hayFila;
            btnEliminar.Text = hayFila && !activo ? "Restaurar" : "Dar de baja";
            btnEliminar.BackColor = hayFila && !activo
                ? System.Drawing.Color.FromArgb(40, 140, 80)
                : System.Drawing.Color.FromArgb(180, 40, 40);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un rol para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IdRol"].Value);
            var rol = _controller.BuscarPorId(id);
            if (rol == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionRol(rol);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un rol para dar de baja o restaurar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IdRol"].Value);
            string nombre = dgvRoles.CurrentRow.Cells["NombreRol"].Value?.ToString() ?? "";
            bool activo = Convert.ToBoolean(dgvRoles.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja el rol {nombre}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;

                _controller.Eliminar(id);
            }
            else
            {
                var result = MessageBox.Show(
                    $"¿Desea restaurar el rol {nombre}?",
                    "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                _controller.Restaurar(id);
            }

            Refrescar();
        }
    }
}
