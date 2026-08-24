using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles
{
    public partial class Form1 : Form
    {
        private DataGridView dgvVehiculos;
        private Button btnRecargar;

        public Form1()
        {
            InitializeComponent();
            ConfigurarInterfaz();
        }

        private void ConfigurarInterfaz()
        {
            // Propiedades básicas de la ventana
            this.Text = "Listado de Vehículos";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Botón de recarga
            btnRecargar = new Button
            {
                Text = "Recargar Datos",
                Location = new Point(12, 12),
                Size = new Size(130, 32)
            };
            btnRecargar.Click += (s, e) => CargarVehiculos();

            // Grilla de datos
            dgvVehiculos = new DataGridView
            {
                Location = new Point(12, 55),
                Size = new Size(760, 340),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            // Agregar controles al formulario
            this.Controls.Add(btnRecargar);
            this.Controls.Add(dgvVehiculos);

            // Cargar datos al iniciar
            this.Load += (s, e) => CargarVehiculos();
        }

        private void CargarVehiculos()
        {
            try
            {
                string query = "SELECT * FROM dbo.Vehiculo";
                DataTable datos = DatabaseHelper.ExecuteQuery(query);
                dgvVehiculos.DataSource = datos;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de conexión con SQL Server:\n{ex.Message}",
                                "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}