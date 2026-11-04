namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class ListaVehiculoVista
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
            dgvVehiculos = new DataGridView();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(180, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listado de Vehiculos";
            //
            // dgvVehiculos
            //
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.AllowUserToDeleteRows = false;
            dgvVehiculos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvVehiculos.Location = new Point(25, 60);
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.Size = new Size(700, 320);
            dgvVehiculos.TabIndex = 1;
            //
            // btnAgregar
            //
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAgregar.BackColor = Color.FromArgb(51, 51, 76);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(25, 395);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(130, 35);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            //
            // btnEditar
            //
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditar.BackColor = Color.FromArgb(51, 51, 76);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(170, 395);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(130, 35);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            //
            // btnEliminar
            //
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.BackColor = Color.FromArgb(180, 40, 40);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(315, 395);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 35);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.Location = new Point(400, 22);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por matrícula, marca, modelo o ID...";
            txtBuscar.Size = new Size(325, 25);
            txtBuscar.TabIndex = 5;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            //
            // ListaVehiculoVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(dgvVehiculos);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(txtBuscar);
            Name = "ListaVehiculoVista";
            MinimumSize = new Size(750, 450);
            Size = new Size(750, 450);
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvVehiculos;
        private Button btnEditar;
        private Button btnAgregar;
        private Button btnEliminar;
        private TextBox txtBuscar;
    }
}