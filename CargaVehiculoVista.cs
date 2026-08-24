using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestionDeAlquierDeAutomoviles
{
    public partial class CargaVehiculoVista : Form
    {
        public CargaVehiculoVista()
        {
            InitializeComponent();
        }

        private void CargaVehiculoVista_Load(object sender, EventArgs e)
        {
            this.CargarModelos();
            this.CargarCategorias();
        }

        private void CargarModelos()
        {
            string query = "SELECT id_modelo, modelo FROM dbo.Modelo";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            CBModelo.DataSource = dt;
            CBModelo.DisplayMember = "modelo";  // Lo que ve el usuario
            CBModelo.ValueMember = "id_modelo";    // El valor interno que guardas en la BD
            CBModelo.SelectedIndex = -1;         // Inicia sin nada seleccionado
        }

        private void CargarCategorias()
        {
            string query = "SELECT id_categoria, nombre as categoria FROM dbo.Categoria";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            CBCategoria.DataSource = dt;
            CBCategoria.DisplayMember = "categoria";  // Lo que ve el usuario
            CBCategoria.ValueMember = "id_categoria";    // El valor interno que guardas en la BD
            CBCategoria.SelectedIndex = -1;         // Inicia sin nada seleccionado
        }

        private void BGuardarVehiculo_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(TBMatricula.Text))
            {
                MessageBox.Show("Por favor ingresa la matrícula.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBMatricula.Focus();
                return;
            }

            if (!int.TryParse(TBAnio.Text.Trim(), out int anioValido))
            {
                MessageBox.Show("Por favor ingresa un año numérico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBAnio.Focus();
                return;
            }

            if (CBModelo.SelectedValue == null)
            {
                MessageBox.Show("Por favor selecciona un modelo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CBCategoria.SelectedValue == null)
            {
                MessageBox.Show("Por favor selecciona una categoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idModelo = Convert.ToInt32(CBModelo.SelectedValue);
            int idCategoria = Convert.ToInt32(CBCategoria.SelectedValue);
            string matricula = TBMatricula.Text.Trim();

            // 2. Sentencia SQL parametrizada
            string query = @"INSERT INTO dbo.Vehiculo (matricula, anio, id_modelo, id_categoria) 
                     VALUES (@matricula, @anio, @id_modelo, @id_categoria)";

            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@matricula", matricula),
        new SqlParameter("@anio", anioValido),
        new SqlParameter("@id_modelo", idModelo),
        new SqlParameter("@id_categoria", idCategoria)
            };

            // 3. Ejecutar y verificar
            try
            {
                int filasAfectadas = DatabaseHelper.ExecuteNonQuery(query, parametros);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Vehículo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (SqlException ex)
            {
                // 2627 es el código de SQL Server para violación de clave única (ej. matrícula repetida)
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Ya existe un vehículo registrado con esa matrícula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error de base de datos: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            TBAnio.Clear();
            TBMatricula.Clear();
            CBModelo.SelectedIndex = -1;
            CBCategoria.SelectedIndex = -1;
        }
    }
}
