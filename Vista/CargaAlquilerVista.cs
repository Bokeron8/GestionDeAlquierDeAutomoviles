using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using GestionDeAlquierDeAutomoviles;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class CargaAlquilerVista : UserControl
    {
        private int _alquilerId = 0;

        public CargaAlquilerVista()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        public void SetAlquiler(int id)
        {
            _alquilerId = id;
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Alquiler WHERE id_alquiler = @id",
                new SqlParameter[] { new SqlParameter("@id", id) });
            if (dt.Rows.Count == 0) return;

            var row = dt.Rows[0];
            lblTitulo.Text = "Editar Alquiler";
            btnGuardar.Text = "Actualizar Alquiler";

            var reservas = DatabaseHelper.ExecuteQuery("SELECT id_reserva FROM Reserva WHERE activo = 1 ORDER BY id_reserva");
            cbReserva.DataSource = reservas;
            cbReserva.DisplayMember = "id_reserva";
            cbReserva.ValueMember = "id_reserva";
            cbReserva.SelectedValue = Convert.ToInt32(row["id_reserva"]);

            txtCombustibleSalida.Text = Convert.ToDecimal(row["combustibleSalida"]).ToString();
            txtKilometrajeSalida.Text = Convert.ToDecimal(row["kilometrajeSalida"]).ToString();
            txtCombustibleEntrada.Text = row["combustibleEntrada"] != DBNull.Value ? Convert.ToDecimal(row["combustibleEntrada"]).ToString() : "";
            txtKilometrajeEntrada.Text = row["kilometrajeEntrada"] != DBNull.Value ? Convert.ToDecimal(row["kilometrajeEntrada"]).ToString() : "";
            txtMontoMora.Text = Convert.ToDecimal(row["montoMora"]).ToString();
        }

        public void LimpiarFormulario()
        {
            _alquilerId = 0;
            lblTitulo.Text = "Registrar Alquiler";
            btnGuardar.Text = "Registrar Alquiler";
            txtCombustibleSalida.Clear();
            txtKilometrajeSalida.Clear();
            txtCombustibleEntrada.Clear();
            txtKilometrajeEntrada.Clear();
            txtMontoMora.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal combustibleSalida = Convert.ToDecimal(txtCombustibleSalida.Text);
                decimal kilometrajeSalida = Convert.ToDecimal(txtKilometrajeSalida.Text);
                decimal combustibleEntrada = string.IsNullOrEmpty(txtCombustibleEntrada.Text) ? 0 : Convert.ToDecimal(txtCombustibleEntrada.Text);
                decimal kilometrajeEntrada = string.IsNullOrEmpty(txtKilometrajeEntrada.Text) ? 0 : Convert.ToDecimal(txtKilometrajeEntrada.Text);
                decimal montoMora = Convert.ToDecimal(txtMontoMora.Text);
                int idReserva = Convert.ToInt32(cbReserva.SelectedValue);

                if (_alquilerId == 0)
                {
                    int rows = DatabaseHelper.ExecuteNonQuery(
                        @"INSERT INTO Alquiler (fechaEntregaReal, combustibleSalida, combustibleEntrada, kilometrajeSalida, kilometrajeEntrada, montoMora, activo, id_reserva)
                          VALUES (GETDATE(), @combustibleSalida, @combustibleEntrada, @kilometrajeSalida, @kilometrajeEntrada, @montoMora, 1, @id_reserva)",
                        new SqlParameter[] {
                            new SqlParameter("@combustibleSalida", combustibleSalida),
                            new SqlParameter("@combustibleEntrada", combustibleEntrada),
                            new SqlParameter("@kilometrajeSalida", kilometrajeSalida),
                            new SqlParameter("@kilometrajeEntrada", kilometrajeEntrada),
                            new SqlParameter("@montoMora", montoMora),
                            new SqlParameter("@id_reserva", idReserva)
                        });
                    if (rows > 0)
                    {
                        MessageBox.Show("Alquiler registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el alquiler", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    int rows = DatabaseHelper.ExecuteNonQuery(
                        @"UPDATE Alquiler SET combustibleSalida = @combustibleSalida, combustibleEntrada = @combustibleEntrada,
                          kilometrajeSalida = @kilometrajeSalida, kilometrajeEntrada = @kilometrajeEntrada, montoMora = @montoMora, id_reserva = @id_reserva
                          WHERE id_alquiler = @id_alquiler",
                        new SqlParameter[] {
                            new SqlParameter("@combustibleSalida", combustibleSalida),
                            new SqlParameter("@combustibleEntrada", combustibleEntrada),
                            new SqlParameter("@kilometrajeSalida", kilometrajeSalida),
                            new SqlParameter("@kilometrajeEntrada", kilometrajeEntrada),
                            new SqlParameter("@montoMora", montoMora),
                            new SqlParameter("@id_reserva", idReserva),
                            new SqlParameter("@id_alquiler", _alquilerId)
                        });
                    if (rows > 0)
                    {
                        MessageBox.Show("Alquiler actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el alquiler", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
