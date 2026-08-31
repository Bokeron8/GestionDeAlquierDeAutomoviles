namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class CargaMarcaVista
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
            lblTitulo.Size = new Size(160, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregar Marca";
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
            lblNombre.Size = new Size(54, 19);
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
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(51, 51, 76);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(165, 180);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 45);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar Marca";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // CargaMarcaVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(separador);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(btnGuardar);
            Name = "CargaMarcaVista";
            Size = new Size(750, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel separador;
        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnGuardar;
    }
}
