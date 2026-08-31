namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class ListaReservaVista
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
            dgvReservas = new DataGridView();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
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
            lblTitulo.Text = "Listado de Reservas";
            //
            // dgvReservas
            //
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvReservas.Location = new Point(25, 60);
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.RowHeadersVisible = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(700, 320);
            dgvReservas.TabIndex = 1;
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
            btnAgregar.TabIndex = 2;
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
            // ListaReservaVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(dgvReservas);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Name = "ListaReservaVista";
            Size = new Size(750, 450);
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvReservas;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
    }
}
