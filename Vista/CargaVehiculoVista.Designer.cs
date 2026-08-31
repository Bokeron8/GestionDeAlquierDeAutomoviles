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
            separador = new Panel();
            panelIzquierda = new Panel();
            lblMatricula = new Label();
            txtMatricula = new TextBox();
            lblAnio = new Label();
            txtAnio = new TextBox();
            panelDerecha = new Panel();
            lblModelo = new Label();
            cbModelo = new ComboBox();
            lblCategoria = new Label();
            cbCategoria = new ComboBox();
            panelInferior = new Panel();
            pbAuto = new PictureBox();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbAuto).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(230, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Nuevo Vehiculo";
            //
            // separador
            //
            separador.BackColor = Color.FromArgb(51, 51, 76);
            separador.Location = new Point(25, 55);
            separador.Name = "separador";
            separador.Size = new Size(700, 2);
            separador.TabIndex = 1;
            //
            // panelIzquierda
            //
            panelIzquierda.BackColor = Color.White;
            panelIzquierda.Controls.Add(lblMatricula);
            panelIzquierda.Controls.Add(txtMatricula);
            panelIzquierda.Controls.Add(lblAnio);
            panelIzquierda.Controls.Add(txtAnio);
            panelIzquierda.Location = new Point(25, 75);
            panelIzquierda.Name = "panelIzquierda";
            panelIzquierda.Size = new Size(345, 180);
            panelIzquierda.TabIndex = 2;
            //
            // lblMatricula
            //
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMatricula.ForeColor = Color.FromArgb(51, 51, 76);
            lblMatricula.Location = new Point(20, 20);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(75, 19);
            lblMatricula.TabIndex = 0;
            lblMatricula.Text = "Matricula";
            //
            // txtMatricula
            //
            txtMatricula.Font = new Font("Segoe UI", 10F);
            txtMatricula.Location = new Point(20, 48);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(305, 25);
            txtMatricula.TabIndex = 1;
            //
            // lblAnio
            //
            lblAnio.AutoSize = true;
            lblAnio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAnio.ForeColor = Color.FromArgb(51, 51, 76);
            lblAnio.Location = new Point(20, 95);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(39, 19);
            lblAnio.TabIndex = 2;
            lblAnio.Text = "Anio";
            //
            // txtAnio
            //
            txtAnio.Font = new Font("Segoe UI", 10F);
            txtAnio.Location = new Point(20, 123);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(305, 25);
            txtAnio.TabIndex = 3;
            //
            // panelDerecha
            //
            panelDerecha.BackColor = Color.White;
            panelDerecha.Controls.Add(lblModelo);
            panelDerecha.Controls.Add(cbModelo);
            panelDerecha.Controls.Add(lblCategoria);
            panelDerecha.Controls.Add(cbCategoria);
            panelDerecha.Location = new Point(385, 75);
            panelDerecha.Name = "panelDerecha";
            panelDerecha.Size = new Size(340, 180);
            panelDerecha.TabIndex = 3;
            //
            // lblModelo
            //
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblModelo.ForeColor = Color.FromArgb(51, 51, 76);
            lblModelo.Location = new Point(20, 20);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(58, 19);
            lblModelo.TabIndex = 0;
            lblModelo.Text = "Modelo";
            //
            // cbModelo
            //
            cbModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbModelo.Font = new Font("Segoe UI", 10F);
            cbModelo.FormattingEnabled = true;
            cbModelo.Location = new Point(20, 48);
            cbModelo.Name = "cbModelo";
            cbModelo.Size = new Size(300, 25);
            cbModelo.TabIndex = 1;
            //
            // lblCategoria
            //
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.FromArgb(51, 51, 76);
            lblCategoria.Location = new Point(20, 95);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(69, 19);
            lblCategoria.TabIndex = 2;
            lblCategoria.Text = "Categoria";
            //
            // cbCategoria
            //
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.Font = new Font("Segoe UI", 10F);
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(20, 123);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(300, 25);
            cbCategoria.TabIndex = 3;
            //
            // panelInferior
            //
            panelInferior.BackColor = Color.FromArgb(240, 240, 245);
            panelInferior.Controls.Add(pbAuto);
            panelInferior.Controls.Add(btnGuardar);
            panelInferior.Location = new Point(25, 270);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(700, 140);
            panelInferior.TabIndex = 4;
            //
            // pbAuto
            //
            pbAuto.Location = new Point(10, 5);
            pbAuto.Name = "pbAuto";
            pbAuto.Size = new Size(180, 125);
            pbAuto.SizeMode = PictureBoxSizeMode.Zoom;
            pbAuto.TabIndex = 0;
            pbAuto.TabStop = false;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(51, 51, 76);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(250, 35);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 50);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar Vehiculo";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // CargaVehiculoVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(separador);
            Controls.Add(panelIzquierda);
            Controls.Add(panelDerecha);
            Controls.Add(panelInferior);
            Name = "CargaVehiculoVista";
            Size = new Size(750, 430);
            ((System.ComponentModel.ISupportInitialize)pbAuto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel separador;
        private Panel panelIzquierda;
        private Label lblMatricula;
        private TextBox txtMatricula;
        private Label lblAnio;
        private TextBox txtAnio;
        private Panel panelDerecha;
        private Label lblModelo;
        private ComboBox cbModelo;
        private Label lblCategoria;
        private ComboBox cbCategoria;
        private Panel panelInferior;
        private PictureBox pbAuto;
        private Button btnGuardar;
    }
}
