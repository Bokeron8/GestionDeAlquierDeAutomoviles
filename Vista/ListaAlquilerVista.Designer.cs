namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class ListaAlquilerVista
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
            dgvAlquileres = new DataGridView();
            btnEditar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlquileres).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(190, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listado de Alquileres";
            //
            // dgvAlquileres
            //
            dgvAlquileres.AllowUserToAddRows = false;
            dgvAlquileres.AllowUserToDeleteRows = false;
            dgvAlquileres.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAlquileres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlquileres.BackgroundColor = Color.White;
            dgvAlquileres.BorderStyle = BorderStyle.None;
            dgvAlquileres.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvAlquileres.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAlquileres.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAlquileres.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAlquileres.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvAlquileres.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvAlquileres.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAlquileres.EnableHeadersVisualStyles = false;
            dgvAlquileres.Location = new Point(25, 60);
            dgvAlquileres.Name = "dgvAlquileres";
            dgvAlquileres.ReadOnly = true;
            dgvAlquileres.RowHeadersVisible = false;
            dgvAlquileres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlquileres.Size = new Size(700, 320);
            dgvAlquileres.TabIndex = 1;
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
            // ListaAlquilerVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(dgvAlquileres);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Name = "ListaAlquilerVista";
            Size = new Size(750, 450);
            ((System.ComponentModel.ISupportInitialize)dgvAlquileres).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvAlquileres;
        private Button btnEditar;
        private Button btnAgregar;
    }
}
