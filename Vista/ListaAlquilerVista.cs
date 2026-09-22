using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using GestionDeAlquierDeAutomoviles;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaAlquilerVista : UserControl
    {
        public ListaAlquilerVista()
        {
            InitializeComponent();
            Load += ListaAlquilerVista_Load;
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void ListaAlquilerVista_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaAlquiler.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaAlquiler);
        }

        private void CargarDatos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Alquiler ORDER BY id_alquiler DESC");
            dgvAlquileres.DataSource = null;
            dgvAlquileres.DataSource = dt;

            if (dgvAlquileres.Columns["id_alquiler"] != null)
            {
                dgvAlquileres.Columns["id_alquiler"].HeaderText = "ID";
                dgvAlquileres.Columns["id_alquiler"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAlquileres.Columns["id_alquiler"].Width = 50;
            }
            if (dgvAlquileres.Columns["fechaEntregaReal"] != null)
                dgvAlquileres.Columns["fechaEntregaReal"].HeaderText = "F. Entrega";
            if (dgvAlquileres.Columns["fechaEntregaDevolucion"] != null)
                dgvAlquileres.Columns["fechaEntregaDevolucion"].HeaderText = "F. Devolución";
            if (dgvAlquileres.Columns["combustibleSalida"] != null)
                dgvAlquileres.Columns["combustibleSalida"].HeaderText = "Comb. Salida";
            if (dgvAlquileres.Columns["combustibleEntrada"] != null)
                dgvAlquileres.Columns["combustibleEntrada"].HeaderText = "Comb. Entrada";
            if (dgvAlquileres.Columns["kilometrajeSalida"] != null)
                dgvAlquileres.Columns["kilometrajeSalida"].HeaderText = "Km. Salida";
            if (dgvAlquileres.Columns["kilometrajeEntrada"] != null)
                dgvAlquileres.Columns["kilometrajeEntrada"].HeaderText = "Km. Entrada";
            if (dgvAlquileres.Columns["montoMora"] != null)
                dgvAlquileres.Columns["montoMora"].HeaderText = "Mora";
            if (dgvAlquileres.Columns["activo"] != null)
            {
                dgvAlquileres.Columns["activo"].HeaderText = "Activo";
                dgvAlquileres.Columns["activo"].Width = 60;
            }
            if (dgvAlquileres.Columns["id_reserva"] != null)
                dgvAlquileres.Columns["id_reserva"].HeaderText = "ID Reserva";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string termino = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(termino))
            {
                CargarDatos();
                return;
            }
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT * FROM Alquiler 
                  WHERE CAST(id_alquiler AS VARCHAR) LIKE @termino 
                  OR CAST(id_reserva AS VARCHAR) LIKE @termino 
                  ORDER BY id_alquiler DESC",
                [new SqlParameter("@termino", $"%{termino}%")]);
            dgvAlquileres.DataSource = null;
            dgvAlquileres.DataSource = dt;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAlquileres.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un alquiler para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvAlquileres.CurrentRow.Cells["id_alquiler"].Value);
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Alquiler WHERE id_alquiler = @id",
                [new SqlParameter("@id", id)]);
            if (dt.Rows.Count == 0) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionAlquiler(id);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlquileres.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un alquiler para dar de baja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvAlquileres.CurrentRow.Cells["id_alquiler"].Value);
            bool activo = Convert.ToBoolean(dgvAlquileres.CurrentRow.Cells["activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja al alquiler ID {id}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Alquiler SET activo = 0 WHERE id_alquiler = @id",
                        [new SqlParameter("@id", id)]);
                    CargarDatos();
                    txtBuscar_TextChanged(sender, e);
                }
            }
            else
            {
                MessageBox.Show(
                    $"El alquiler ID {id} ya se encuentra dado de baja.",
                    "Alquiler inactivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
