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
            lblMetricClientes = new Label();
            lblMetricEmpleados = new Label();
            lblMetricAlquileres = new Label();
            lblMetricIngresos = new Label();
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
            lblMetricVehiculos.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblMetricVehiculos.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricVehiculos.Location = new Point(25, 72);
            lblMetricVehiculos.Name = "lblMetricVehiculos";
            lblMetricVehiculos.Size = new Size(110, 19);
            lblMetricVehiculos.TabIndex = 7;
            lblMetricVehiculos.Text = "Vehículos: 0";
            //
            // lblMetricClientes
            //
            lblMetricClientes.AutoSize = true;
            lblMetricClientes.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblMetricClientes.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricClientes.Location = new Point(160, 72);
            lblMetricClientes.Name = "lblMetricClientes";
            lblMetricClientes.Size = new Size(95, 19);
            lblMetricClientes.TabIndex = 8;
            lblMetricClientes.Text = "Clientes: 0";
            //
            // lblMetricEmpleados
            //
            lblMetricEmpleados.AutoSize = true;
            lblMetricEmpleados.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblMetricEmpleados.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricEmpleados.Location = new Point(285, 72);
            lblMetricEmpleados.Name = "lblMetricEmpleados";
            lblMetricEmpleados.Size = new Size(105, 19);
            lblMetricEmpleados.TabIndex = 9;
            lblMetricEmpleados.Text = "Empleados: 0";
            //
            // lblMetricAlquileres
            //
            lblMetricAlquileres.AutoSize = true;
            lblMetricAlquileres.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblMetricAlquileres.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricAlquileres.Location = new Point(420, 72);
            lblMetricAlquileres.Name = "lblMetricAlquileres";
            lblMetricAlquileres.Size = new Size(170, 19);
            lblMetricAlquileres.TabIndex = 10;
            lblMetricAlquileres.Text = "Alquileres en curso: 0";
            //
            // lblMetricIngresos
            //
            lblMetricIngresos.AutoSize = true;
            lblMetricIngresos.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblMetricIngresos.ForeColor = Color.FromArgb(51, 51, 76);
            lblMetricIngresos.Location = new Point(620, 72);
            lblMetricIngresos.Name = "lblMetricIngresos";
            lblMetricIngresos.Size = new Size(185, 19);
            lblMetricIngresos.TabIndex = 11;
            lblMetricIngresos.Text = "Ingresos (mes actual): $0";
            //
            // lblReservasTitulo
            //
            lblReservasTitulo.AutoSize = true;
            lblReservasTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblReservasTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblReservasTitulo.Location = new Point(25, 115);
            lblReservasTitulo.Name = "lblReservasTitulo";
            lblReservasTitulo.Size = new Size(200, 20);
            lblReservasTitulo.TabIndex = 12;
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
            dgvReservas.TabIndex = 13;
            //
            // lblVehiculosTitulo
            //
            lblVehiculosTitulo.AutoSize = true;
            lblVehiculosTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblVehiculosTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblVehiculosTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVehiculosTitulo.Location = new Point(570, 115);
            lblVehiculosTitulo.Name = "lblVehiculosTitulo";
            lblVehiculosTitulo.Size = new Size(200, 20);
            lblVehiculosTitulo.TabIndex = 14;
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
            dgvVehiculos.TabIndex = 15;
            //
            // lblIngresosCategoriaTitulo
            //
            lblIngresosCategoriaTitulo.AutoSize = true;
            lblIngresosCategoriaTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIngresosCategoriaTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblIngresosCategoriaTitulo.Location = new Point(25, 435);
            lblIngresosCategoriaTitulo.Name = "lblIngresosCategoriaTitulo";
            lblIngresosCategoriaTitulo.Size = new Size(220, 20);
            lblIngresosCategoriaTitulo.TabIndex = 16;
            lblIngresosCategoriaTitulo.Text = "Ingresos por Categoría";
            //
            // dgvIngresosCategoria
            //
            dgvIngresosCategoria.AllowUserToAddRows = false;
            dgvIngresosCategoria.AllowUserToDeleteRows = false;
            dgvIngresosCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dgvIngresosCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngresosCategoria.BackgroundColor = Color.White;
            dgvIngresosCategoria.BorderStyle = BorderStyle.None;
            dgvIngresosCategoria.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvIngresosCategoria.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIngresosCategoria.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvIngresosCategoria.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresosCategoria.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvIngresosCategoria.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvIngresosCategoria.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvIngresosCategoria.EnableHeadersVisualStyles = false;
            dgvIngresosCategoria.Location = new Point(25, 460);
            dgvIngresosCategoria.Name = "dgvIngresosCategoria";
            dgvIngresosCategoria.ReadOnly = true;
            dgvIngresosCategoria.RowHeadersVisible = false;
            dgvIngresosCategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngresosCategoria.Size = new Size(350, 250);
            dgvIngresosCategoria.TabIndex = 17;
            //
            // lblAlquileresFinalizadosTitulo
            //
            lblAlquileresFinalizadosTitulo.AutoSize = true;
            lblAlquileresFinalizadosTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAlquileresFinalizadosTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblAlquileresFinalizadosTitulo.Location = new Point(395, 435);
            lblAlquileresFinalizadosTitulo.Name = "lblAlquileresFinalizadosTitulo";
            lblAlquileresFinalizadosTitulo.Size = new Size(250, 20);
            lblAlquileresFinalizadosTitulo.TabIndex = 18;
            lblAlquileresFinalizadosTitulo.Text = "Alquileres Finalizados Recientes";
            //
            // dgvAlquileresFinalizados
            //
            dgvAlquileresFinalizados.AllowUserToAddRows = false;
            dgvAlquileresFinalizados.AllowUserToDeleteRows = false;
            dgvAlquileresFinalizados.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dgvAlquileresFinalizados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlquileresFinalizados.BackgroundColor = Color.White;
            dgvAlquileresFinalizados.BorderStyle = BorderStyle.None;
            dgvAlquileresFinalizados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvAlquileresFinalizados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAlquileresFinalizados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAlquileresFinalizados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAlquileresFinalizados.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvAlquileresFinalizados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvAlquileresFinalizados.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAlquileresFinalizados.EnableHeadersVisualStyles = false;
            dgvAlquileresFinalizados.Location = new Point(395, 460);
            dgvAlquileresFinalizados.Name = "dgvAlquileresFinalizados";
            dgvAlquileresFinalizados.ReadOnly = true;
            dgvAlquileresFinalizados.RowHeadersVisible = false;
            dgvAlquileresFinalizados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlquileresFinalizados.Size = new Size(485, 250);
            dgvAlquileresFinalizados.TabIndex = 19;
            //
            // ReporteVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(lblMetricVehiculos);
            Controls.Add(lblMetricClientes);
            Controls.Add(lblMetricEmpleados);
            Controls.Add(lblMetricAlquileres);
            Controls.Add(lblMetricIngresos);
            Controls.Add(lblReservasTitulo);
            Controls.Add(dgvReservas);
            Controls.Add(lblVehiculosTitulo);
            Controls.Add(dgvVehiculos);
            Controls.Add(lblIngresosCategoriaTitulo);
            Controls.Add(dgvIngresosCategoria);
            Controls.Add(lblAlquileresFinalizadosTitulo);
            Controls.Add(dgvAlquileresFinalizados);
            Name = "ReporteVista";
            MinimumSize = new Size(900, 750);
            Size = new Size(900, 750);
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvIngresosCategoria).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlquileresFinalizados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMetricVehiculos;
        private Label lblMetricClientes;
        private Label lblMetricEmpleados;
        private Label lblMetricAlquileres;
        private Label lblMetricIngresos;
        private Label lblReservasTitulo;
        private Label lblVehiculosTitulo;
        private DataGridView dgvReservas;
        private DataGridView dgvVehiculos;
        private Label lblIngresosCategoriaTitulo;
        private DataGridView dgvIngresosCategoria;
        private Label lblAlquileresFinalizadosTitulo;
        private DataGridView dgvAlquileresFinalizados;
    }
}
