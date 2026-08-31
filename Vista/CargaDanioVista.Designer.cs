namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class CargaDanioVista
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
            cbAlquiler = new ComboBox();
            lblAlquiler = new Label();
            lblZona = new Label();
            txtZona = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblEvidencia = new Label();
            txtEvidencia = new TextBox();
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
            lblTitulo.Size = new Size(140, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Daño";
            //
            // separador
            //
            separador.BackColor = Color.FromArgb(51, 51, 76);
            separador.Location = new Point(25, 55);
            separador.Name = "separador";
            separador.Size = new Size(700, 2);
            separador.TabIndex = 1;
            //
            // cbAlquiler
            //
            cbAlquiler.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAlquiler.Font = new Font("Segoe UI", 10F);
            cbAlquiler.FormattingEnabled = true;
            cbAlquiler.Location = new Point(40, 80);
            cbAlquiler.Name = "cbAlquiler";
            cbAlquiler.Size = new Size(400, 25);
            cbAlquiler.TabIndex = 2;
            //
            // lblAlquiler
            //
            lblAlquiler.AutoSize = true;
            lblAlquiler.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAlquiler.ForeColor = Color.FromArgb(51, 51, 76);
            lblAlquiler.Location = new Point(40, 60);
            lblAlquiler.Name = "lblAlquiler";
            lblAlquiler.Size = new Size(55, 19);
            lblAlquiler.TabIndex = 3;
            lblAlquiler.Text = "Alquiler";
            //
            // lblZona
            //
            lblZona.AutoSize = true;
            lblZona.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblZona.ForeColor = Color.FromArgb(51, 51, 76);
            lblZona.Location = new Point(40, 120);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(39, 19);
            lblZona.TabIndex = 4;
            lblZona.Text = "Zona";
            //
            // txtZona
            //
            txtZona.Font = new Font("Segoe UI", 10F);
            txtZona.Location = new Point(40, 145);
            txtZona.Name = "txtZona";
            txtZona.Size = new Size(400, 25);
            txtZona.TabIndex = 5;
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(51, 51, 76);
            lblDescripcion.Location = new Point(40, 180);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(80, 19);
            lblDescripcion.TabIndex = 6;
            lblDescripcion.Text = "Descripción";
            //
            // txtDescripcion
            //
            txtDescripcion.Font = new Font("Segoe UI", 10F);
            txtDescripcion.Location = new Point(40, 205);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(400, 60);
            txtDescripcion.TabIndex = 7;
            //
            // lblEvidencia
            //
            lblEvidencia.AutoSize = true;
            lblEvidencia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEvidencia.ForeColor = Color.FromArgb(51, 51, 76);
            lblEvidencia.Location = new Point(40, 275);
            lblEvidencia.Name = "lblEvidencia";
            lblEvidencia.Size = new Size(140, 19);
            lblEvidencia.TabIndex = 8;
            lblEvidencia.Text = "Ruta Evidencia Foto";
            //
            // txtEvidencia
            //
            txtEvidencia.Font = new Font("Segoe UI", 10F);
            txtEvidencia.Location = new Point(40, 300);
            txtEvidencia.Name = "txtEvidencia";
            txtEvidencia.Size = new Size(400, 25);
            txtEvidencia.TabIndex = 9;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(51, 51, 76);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(265, 345);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 45);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Registrar Daño";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // CargaDanioVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(separador);
            Controls.Add(cbAlquiler);
            Controls.Add(lblAlquiler);
            Controls.Add(lblZona);
            Controls.Add(txtZona);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblEvidencia);
            Controls.Add(txtEvidencia);
            Controls.Add(btnGuardar);
            Name = "CargaDanioVista";
            Size = new Size(750, 420);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel separador;
        private ComboBox cbAlquiler;
        private Label lblAlquiler;
        private Label lblZona;
        private TextBox txtZona;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblEvidencia;
        private TextBox txtEvidencia;
        private Button btnGuardar;
    }
}
