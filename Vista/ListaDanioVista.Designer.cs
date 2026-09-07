namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class ListaDanioVista
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
            dgvDanios = new DataGridView();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDanios).BeginInit();
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
            lblTitulo.Text = "Listado de Daños";
            //
            // dgvDanios
            //
            dgvDanios.AllowUserToAddRows = false;
            dgvDanios.AllowUserToDeleteRows = false;
            dgvDanios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDanios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanios.BackgroundColor = Color.White;
            dgvDanios.BorderStyle = BorderStyle.None;
            dgvDanios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvDanios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDanios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDanios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanios.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvDanios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvDanios.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDanios.EnableHeadersVisualStyles = false;
            dgvDanios.Location = new Point(25, 60);
            dgvDanios.Name = "dgvDanios";
            dgvDanios.ReadOnly = true;
            dgvDanios.RowHeadersVisible = false;
            dgvDanios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanios.Size = new Size(700, 320);
            dgvDanios.TabIndex = 1;
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
            // ListaDanioVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(dgvDanios);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Name = "ListaDanioVista";
            Size = new Size(750, 450);
            ((System.ComponentModel.ISupportInitialize)dgvDanios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvDanios;
        private Button btnEditar;
        private Button btnAgregar;
        private Button btnEliminar;
    }
}
