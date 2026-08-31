namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class CargaVehiculoVista
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
            lblMatricula = new Label();
            lblAnio = new Label();
            txtMatricula = new TextBox();
            txtAnio = new TextBox();
            btnGuardar = new Button();
            cbModelo = new ComboBox();
            cbCategoria = new ComboBox();
            lblModelo = new Label();
            lblCategoria = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(200, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Nuevo Vehiculo";
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Segoe UI", 10F);
            lblMatricula.Location = new Point(40, 70);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(70, 19);
            lblMatricula.TabIndex = 1;
            lblMatricula.Text = "Matricula:";
            // 
            // txtMatricula
            // 
            txtMatricula.Font = new Font("Segoe UI", 10F);
            txtMatricula.Location = new Point(150, 67);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(150, 25);
            txtMatricula.TabIndex = 2;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Font = new Font("Segoe UI", 10F);
            lblAnio.Location = new Point(40, 115);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(38, 19);
            lblAnio.TabIndex = 3;
            lblAnio.Text = "Anio:";
            // 
            // txtAnio
            // 
            txtAnio.Font = new Font("Segoe UI", 10F);
            txtAnio.Location = new Point(150, 112);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(150, 25);
            txtAnio.TabIndex = 4;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Segoe UI", 10F);
            lblModelo.Location = new Point(370, 70);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(58, 19);
            lblModelo.TabIndex = 5;
            lblModelo.Text = "Modelo:";
            // 
            // cbModelo
            // 
            cbModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbModelo.Font = new Font("Segoe UI", 10F);
            cbModelo.FormattingEnabled = true;
            cbModelo.Location = new Point(440, 67);
            cbModelo.Name = "cbModelo";
            cbModelo.Size = new Size(180, 25);
            cbModelo.TabIndex = 6;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 10F);
            lblCategoria.Location = new Point(370, 115);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(69, 19);
            lblCategoria.TabIndex = 7;
            lblCategoria.Text = "Categoria:";
            // 
            // cbCategoria
            // 
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.Font = new Font("Segoe UI", 10F);
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(440, 112);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(180, 25);
            cbCategoria.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(51, 51, 76);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(230, 190);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 40);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar Vehiculo";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // CargaVehiculoVista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(lblMatricula);
            Controls.Add(txtMatricula);
            Controls.Add(lblAnio);
            Controls.Add(txtAnio);
            Controls.Add(lblModelo);
            Controls.Add(cbModelo);
            Controls.Add(lblCategoria);
            Controls.Add(cbCategoria);
            Controls.Add(btnGuardar);
            Name = "CargaVehiculoVista";
            Size = new Size(784, 411);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMatricula;
        private Label lblAnio;
        private TextBox txtMatricula;
        private TextBox txtAnio;
        private Button btnGuardar;
        private ComboBox cbModelo;
        private ComboBox cbCategoria;
        private Label lblModelo;
        private Label lblCategoria;
    }
}
