using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaDanioVista : UserControl
    {
        private readonly DanioController _controller = new();

        public ListaDanioVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaDanio.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaDanio);
        }

        public void Refrescar()
        {
            var lista = _controller.Listar();
            dgvDanios.DataSource = null;
            dgvDanios.DataSource = lista;

            if (dgvDanios.Columns["IdDanio"] != null)
            {
                dgvDanios.Columns["IdDanio"].HeaderText = "ID";
                dgvDanios.Columns["IdDanio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvDanios.Columns["IdDanio"].Width = 50;
            }
            if (dgvDanios.Columns["IdAlquiler"] != null)
                dgvDanios.Columns["IdAlquiler"].HeaderText = "Alquiler";
            if (dgvDanios.Columns["Zona"] != null)
                dgvDanios.Columns["Zona"].HeaderText = "Zona";
            if (dgvDanios.Columns["Descripcion"] != null)
                dgvDanios.Columns["Descripcion"].HeaderText = "Descripción";
            if (dgvDanios.Columns["EvidenciaFotografica"] != null)
                dgvDanios.Columns["EvidenciaFotografica"].HeaderText = "Evidencia";
            if (dgvDanios.Columns["Activo"] != null)
            {
                dgvDanios.Columns["Activo"].HeaderText = "Activo";
                dgvDanios.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvDanios.Columns["Activo"].Width = 60;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDanios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un daño para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvDanios.CurrentRow.Cells["IdDanio"].Value);
            var danio = _controller.BuscarPorId(id);
            if (danio == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionDanio(danio);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDanios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un daño para dar de baja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvDanios.CurrentRow.Cells["IdDanio"].Value);
            string zona = dgvDanios.CurrentRow.Cells["Zona"].Value?.ToString() ?? "";
            bool activo = Convert.ToBoolean(dgvDanios.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja el daño de la zona {zona}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _controller.Eliminar(id);
                    Refrescar();
                }
            }
            else
            {
                MessageBox.Show($"El daño de la zona {zona} ya se encuentra inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
