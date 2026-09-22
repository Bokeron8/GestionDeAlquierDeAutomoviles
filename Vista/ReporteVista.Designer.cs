namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class ReporteVista
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblMetricVehiculos = new Label();
            lblMetricVehiculosVal = new Label();
            lblMetricClientes = new Label();
            lblMetricClientesVal = new Label();
            lblMetricEmpleados = new Label();
            lblMetricEmpleadosVal = new Label();
            lblMetricAlquileres = new Label();
            lblMetricAlquileresVal = new Label();
            lblMetricIngresos = new Label();
            lblMetricIngresosVal = new Label();
            lblReservasTitulo = new Label();
            dgvReservas = new DataGridView();
            lblVehiculosTitulo = new Label();
            dgvVehiculos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblTitulo.Location = new Point(25, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(280, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Dashboard Gerente";
            //
            // lblMetricVehiculos
            //
            lblMetricVehiculos.AutoSize = true;
            lblMetricVehiculos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMetricVehiculos.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricVehiculos.Location = new Point(25, 72);
            lblMetricVehiculos.Name = "lblMetricVehiculos";
            lblMetricVehiculos.Size = new Size(100, 19);
            lblMetricVehiculos.TabIndex = 7;
            lblMetricVehiculos.Text = "Vehículos:";
            //
            // lblMetricVehiculosVal
            //
            lblMetricVehiculosVal.AutoSize = true;
            lblMetricVehiculosVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMetricVehiculosVal.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricVehiculosVal.Location = new Point(130, 70);
            lblMetricVehiculosVal.Name = "lblMetricVehiculosVal";
            lblMetricVehiculosVal.Size = new Size(50, 25);
            lblMetricVehiculosVal.TabIndex = 8;
            lblMetricVehiculosVal.Text = "0";
            //
            // lblMetricClientes
            //
            lblMetricClientes.AutoSize = true;
            lblMetricClientes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMetricClientes.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricClientes.Location = new Point(200, 72);
            lblMetricClientes.Name = "lblMetricClientes";
            lblMetricClientes.Size = new Size(80, 19);
            lblMetricClientes.TabIndex = 9;
            lblMetricClientes.Text = "Clientes:";
            //
            // lblMetricClientesVal
            //
            lblMetricClientesVal.AutoSize = true;
            lblMetricClientesVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMetricClientesVal.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricClientesVal.Location = new Point(295, 70);
            lblMetricClientesVal.Name = "lblMetricClientesVal";
            lblMetricClientesVal.Size = new Size(50, 25);
            lblMetricClientesVal.TabIndex = 10;
            lblMetricClientesVal.Text = "0";
            //
            // lblMetricEmpleados
            //
            lblMetricEmpleados.AutoSize = true;
            lblMetricEmpleados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMetricEmpleados.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricEmpleados.Location = new Point(375, 72);
            lblMetricEmpleados.Name = "lblMetricEmpleados";
            lblMetricEmpleados.Size = new Size(90, 19);
            lblMetricEmpleados.TabIndex = 11;
            lblMetricEmpleados.Text = "Empleados:";
            //
            // lblMetricEmpleadosVal
            //
            lblMetricEmpleadosVal.AutoSize = true;
            lblMetricEmpleadosVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMetricEmpleadosVal.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricEmpleadosVal.Location = new Point(485, 70);
            lblMetricEmpleadosVal.Name = "lblMetricEmpleadosVal";
            lblMetricEmpleadosVal.Size = new Size(50, 25);
            lblMetricEmpleadosVal.TabIndex = 12;
            lblMetricEmpleadosVal.Text = "0";
            //
            // lblMetricAlquileres
            //
            lblMetricAlquileres.AutoSize = true;
            lblMetricAlquileres.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMetricAlquileres.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricAlquileres.Location = new Point(550, 72);
            lblMetricAlquileres.Name = "lblMetricAlquileres";
            lblMetricAlquileres.Size = new Size(110, 19);
            lblMetricAlquileres.TabIndex = 13;
            lblMetricAlquileres.Text = "Alquileres:";
            //
            // lblMetricAlquileresVal
            //
            lblMetricAlquileresVal.AutoSize = true;
            lblMetricAlquileresVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMetricAlquileresVal.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricAlquileresVal.Location = new Point(660, 70);
            lblMetricAlquileresVal.Name = "lblMetricAlquileresVal";
            lblMetricAlquileresVal.Size = new Size(50, 25);
            lblMetricAlquileresVal.TabIndex = 14;
            lblMetricAlquileresVal.Text = "0";
            //
            // lblMetricIngresos
            //
            lblMetricIngresos.AutoSize = true;
            lblMetricIngresos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMetricIngresos.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricIngresos.Location = new Point(725, 72);
            lblMetricIngresos.Name = "lblMetricIngresos";
            lblMetricIngresos.Size = new Size(70, 19);
            lblMetricIngresos.TabIndex = 15;
            lblMetricIngresos.Text = "Ingresos:";
            //
            // lblMetricIngresosVal
            //
            lblMetricIngresosVal.AutoSize = true;
            lblMetricIngresosVal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMetricIngresosVal.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricIngresosVal.Location = new Point(810, 70);
            lblMetricIngresosVal.Name = "lblMetricIngresosVal";
            lblMetricIngresosVal.Size = new Size(60, 25);
            lblMetricIngresosVal.TabIndex = 16;
            lblMetricIngresosVal.Text = "$0";
            //
            // lblReservasTitulo
            //
            lblReservasTitulo.AutoSize = true;
            lblReservasTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblReservasTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblReservasTitulo.Location = new Point(25, 115);
            lblReservasTitulo.Name = "lblReservasTitulo";
            lblReservasTitulo.Size = new Size(200, 20);
            lblReservasTitulo.TabIndex = 17;
            lblReservasTitulo.Text = "Reservas Activas";
            //
            // dgvReservas
            //
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.BackgroundColor = Color.White;
            dgvReservas.BorderStyle = BorderStyle.None;
            dgvReservas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvReservas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvReservas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservas.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvReservas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvReservas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvReservas.EnableHeadersVisualStyles = false;
            dgvReservas.Location = new Point(25, 140);
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.RowHeadersVisible = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(520, 280);
            dgvReservas.TabIndex = 18;
            //
            // lblVehiculosTitulo
            //
            lblVehiculosTitulo.AutoSize = true;
            lblVehiculosTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblVehiculosTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblVehiculosTitulo.Location = new Point(570, 115);
            lblVehiculosTitulo.Name = "lblVehiculosTitulo";
            lblVehiculosTitulo.Size = new Size(200, 20);
            lblVehiculosTitulo.TabIndex = 19;
            lblVehiculosTitulo.Text = "Vehículos Disponibles";
            //
            // dgvVehiculos
            //
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.AllowUserToDeleteRows = false;
            dgvVehiculos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.BackgroundColor = Color.White;
            dgvVehiculos.BorderStyle = BorderStyle.None;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVehiculos.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvVehiculos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvVehiculos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvVehiculos.EnableHeadersVisualStyles = false;
            dgvVehiculos.Location = new Point(570, 140);
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.Size = new Size(310, 280);
            dgvVehiculos.TabIndex = 20;
            //
            // ReporteVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(lblMetricVehiculos);
            Controls.Add(lblMetricVehiculosVal);
            Controls.Add(lblMetricClientes);
            Controls.Add(lblMetricClientesVal);
            Controls.Add(lblMetricEmpleados);
            Controls.Add(lblMetricEmpleadosVal);
            Controls.Add(lblMetricAlquileres);
            Controls.Add(lblMetricAlquileresVal);
            Controls.Add(lblMetricIngresos);
            Controls.Add(lblMetricIngresosVal);
            Controls.Add(lblReservasTitulo);
            Controls.Add(dgvReservas);
            Controls.Add(lblVehiculosTitulo);
            Controls.Add(dgvVehiculos);
            Name = "ReporteVista";
            Size = new Size(900, 450);
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMetricVehiculos;
        private Label lblMetricVehiculosVal;
        private Label lblMetricClientes;
        private Label lblMetricClientesVal;
        private Label lblMetricEmpleados;
        private Label lblMetricEmpleadosVal;
        private Label lblMetricAlquileres;
        private Label lblMetricAlquileresVal;
        private Label lblMetricIngresos;
        private Label lblMetricIngresosVal;
        private Label lblReservasTitulo;
        private Label lblVehiculosTitulo;
        private DataGridView dgvReservas;
        private DataGridView dgvVehiculos;
    }
}
