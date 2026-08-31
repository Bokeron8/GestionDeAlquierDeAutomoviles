namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class CargaRolVista
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
            separador = new Panel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            lblDescripcion = new Label();
            btnGuardar = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(120, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregar Rol";
            //
            // separador
            //
            separador.BackColor = Color.FromArgb(51, 51, 76);
            separador.Location = new Point(25, 55);
            separador.Name = "separador";
            separador.Size = new Size(700, 2);
            separador.TabIndex = 1;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(51, 51, 76);
            lblNombre.Location = new Point(40, 90);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(45, 19);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            //
            // txtNombre
            //
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(40, 120);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(400, 25);
            txtNombre.TabIndex = 3;
            //
            // txtDescripcion
            //
            txtDescripcion.Font = new Font("Segoe UI", 10F);
            txtDescripcion.Location = new Point(40, 180);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(400, 25);
            txtDescripcion.TabIndex = 4;
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(51, 51, 76);
            lblDescripcion.Location = new Point(40, 160);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(83, 19);
            lblDescripcion.TabIndex = 5;
            lblDescripcion.Text = "Descripción";
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(51, 51, 76);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(165, 240);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 45);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar Rol";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // CargaRolVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(separador);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(btnGuardar);
            Name = "CargaRolVista";
            Size = new Size(750, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel separador;
        private Label lblNombre;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Label lblDescripcion;
        private Button btnGuardar;
    }
}
