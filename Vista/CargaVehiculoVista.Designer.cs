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
            pbAuto = new PictureBox();
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
            lblTitulo.Size = new Size(230, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Nuevo Vehiculo";
            //
            // separador
            //
            separador.BackColor = Color.FromArgb(51, 51, 76);
            separador.Location = new Point(25, 55);
            separador.Name = "separador";
            separador.Size = new Size(730, 2);
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
            panelIzquierda.Size = new Size(350, 170);
            panelIzquierda.TabIndex = 2;
            //
            // lblMatricula
            //
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMatricula.ForeColor = Color.FromArgb(51, 51, 76);
            lblMatricula.Location = new Point(20, 25);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(75, 19);
            lblMatricula.TabIndex = 0;
            lblMatricula.Text = "Matricula";
            //
            // txtMatricula
            //
            txtMatricula.Font = new Font("Segoe UI", 10F);
            txtMatricula.Location = new Point(20, 55);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(310, 25);
            txtMatricula.TabIndex = 1;
            //
            // lblAnio
            //
            lblAnio.AutoSize = true;
            lblAnio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAnio.ForeColor = Color.FromArgb(51, 51, 76);
            lblAnio.Location = new Point(20, 100);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(39, 19);
            lblAnio.TabIndex = 2;
            lblAnio.Text = "Anio";
            //
            // txtAnio
            //
            txtAnio.Font = new Font("Segoe UI", 10F);
            txtAnio.Location = new Point(20, 130);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(310, 25);
            txtAnio.TabIndex = 3;
            //
            // panelDerecha
            //
            panelDerecha.BackColor = Color.White;
            panelDerecha.Controls.Add(lblModelo);
            panelDerecha.Controls.Add(cbModelo);
            panelDerecha.Controls.Add(lblCategoria);
            panelDerecha.Controls.Add(cbCategoria);
            panelDerecha.Location = new Point(405, 75);
            panelDerecha.Name = "panelDerecha";
            panelDerecha.Size = new Size(350, 170);
            panelDerecha.TabIndex = 3;
            //
            // lblModelo
            //
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblModelo.ForeColor = Color.FromArgb(51, 51, 76);
            lblModelo.Location = new Point(20, 25);
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
            cbModelo.Location = new Point(20, 55);
            cbModelo.Name = "cbModelo";
            cbModelo.Size = new Size(310, 25);
            cbModelo.TabIndex = 1;
            //
            // lblCategoria
            //
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.FromArgb(51, 51, 76);
            lblCategoria.Location = new Point(20, 100);
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
            cbCategoria.Location = new Point(20, 130);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(310, 25);
            cbCategoria.TabIndex = 3;
            //
            // pbAuto
            //
            pbAuto.Location = new Point(25, 265);
            pbAuto.Name = "pbAuto";
            pbAuto.Size = new Size(200, 130);
            pbAuto.SizeMode = PictureBoxSizeMode.Zoom;
            pbAuto.TabIndex = 5;
            pbAuto.TabStop = false;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(51, 51, 76);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(265, 275);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(220, 45);
            btnGuardar.TabIndex = 4;
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
            Controls.Add(pbAuto);
            Controls.Add(btnGuardar);
            Name = "CargaVehiculoVista";
            Size = new Size(784, 411);
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
        private Button btnGuardar;
        private PictureBox pbAuto;
    }
}
