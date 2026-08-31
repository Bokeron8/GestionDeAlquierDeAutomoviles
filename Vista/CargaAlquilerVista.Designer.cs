namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class CargaAlquilerVista
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
            cbReserva = new ComboBox();
            lblReserva = new Label();
            lblCombustibleSalida = new Label();
            txtCombustibleSalida = new TextBox();
            lblKilometrajeSalida = new Label();
            txtKilometrajeSalida = new TextBox();
            lblCombustibleEntrada = new Label();
            txtCombustibleEntrada = new TextBox();
            lblKilometrajeEntrada = new Label();
            txtKilometrajeEntrada = new TextBox();
            lblMontoMora = new Label();
            txtMontoMora = new TextBox();
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
            lblTitulo.Size = new Size(170, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Alquiler";
            //
            // separador
            //
            separador.BackColor = Color.FromArgb(51, 51, 76);
            separador.Location = new Point(25, 55);
            separador.Name = "separador";
            separador.Size = new Size(700, 2);
            separador.TabIndex = 1;
            //
            // cbReserva
            //
            cbReserva.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReserva.Font = new Font("Segoe UI", 10F);
            cbReserva.FormattingEnabled = true;
            cbReserva.Location = new Point(40, 80);
            cbReserva.Name = "cbReserva";
            cbReserva.Size = new Size(400, 25);
            cbReserva.TabIndex = 2;
            //
            // lblReserva
            //
            lblReserva.AutoSize = true;
            lblReserva.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReserva.ForeColor = Color.FromArgb(51, 51, 76);
            lblReserva.Location = new Point(40, 60);
            lblReserva.Name = "lblReserva";
            lblReserva.Size = new Size(56, 19);
            lblReserva.TabIndex = 3;
            lblReserva.Text = "Reserva";
            //
            // lblCombustibleSalida
            //
            lblCombustibleSalida.AutoSize = true;
            lblCombustibleSalida.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCombustibleSalida.ForeColor = Color.FromArgb(51, 51, 76);
            lblCombustibleSalida.Location = new Point(40, 120);
            lblCombustibleSalida.Name = "lblCombustibleSalida";
            lblCombustibleSalida.Size = new Size(125, 19);
            lblCombustibleSalida.TabIndex = 4;
            lblCombustibleSalida.Text = "Combustible Salida";
            //
            // txtCombustibleSalida
            //
            txtCombustibleSalida.Font = new Font("Segoe UI", 10F);
            txtCombustibleSalida.Location = new Point(40, 145);
            txtCombustibleSalida.Name = "txtCombustibleSalida";
            txtCombustibleSalida.Size = new Size(180, 25);
            txtCombustibleSalida.TabIndex = 5;
            //
            // lblKilometrajeSalida
            //
            lblKilometrajeSalida.AutoSize = true;
            lblKilometrajeSalida.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKilometrajeSalida.ForeColor = Color.FromArgb(51, 51, 76);
            lblKilometrajeSalida.Location = new Point(260, 120);
            lblKilometrajeSalida.Name = "lblKilometrajeSalida";
            lblKilometrajeSalida.Size = new Size(120, 19);
            lblKilometrajeSalida.TabIndex = 6;
            lblKilometrajeSalida.Text = "Kilometraje Salida";
            //
            // txtKilometrajeSalida
            //
            txtKilometrajeSalida.Font = new Font("Segoe UI", 10F);
            txtKilometrajeSalida.Location = new Point(260, 145);
            txtKilometrajeSalida.Name = "txtKilometrajeSalida";
            txtKilometrajeSalida.Size = new Size(180, 25);
            txtKilometrajeSalida.TabIndex = 7;
            //
            // lblCombustibleEntrada
            //
            lblCombustibleEntrada.AutoSize = true;
            lblCombustibleEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCombustibleEntrada.ForeColor = Color.FromArgb(51, 51, 76);
            lblCombustibleEntrada.Location = new Point(40, 185);
            lblCombustibleEntrada.Name = "lblCombustibleEntrada";
            lblCombustibleEntrada.Size = new Size(135, 19);
            lblCombustibleEntrada.TabIndex = 8;
            lblCombustibleEntrada.Text = "Combustible Entrada";
            //
            // txtCombustibleEntrada
            //
            txtCombustibleEntrada.Font = new Font("Segoe UI", 10F);
            txtCombustibleEntrada.Location = new Point(40, 210);
            txtCombustibleEntrada.Name = "txtCombustibleEntrada";
            txtCombustibleEntrada.Size = new Size(180, 25);
            txtCombustibleEntrada.TabIndex = 9;
            //
            // lblKilometrajeEntrada
            //
            lblKilometrajeEntrada.AutoSize = true;
            lblKilometrajeEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKilometrajeEntrada.ForeColor = Color.FromArgb(51, 51, 76);
            lblKilometrajeEntrada.Location = new Point(260, 185);
            lblKilometrajeEntrada.Name = "lblKilometrajeEntrada";
            lblKilometrajeEntrada.Size = new Size(130, 19);
            lblKilometrajeEntrada.TabIndex = 10;
            lblKilometrajeEntrada.Text = "Kilometraje Entrada";
            //
            // txtKilometrajeEntrada
            //
            txtKilometrajeEntrada.Font = new Font("Segoe UI", 10F);
            txtKilometrajeEntrada.Location = new Point(260, 210);
            txtKilometrajeEntrada.Name = "txtKilometrajeEntrada";
            txtKilometrajeEntrada.Size = new Size(180, 25);
            txtKilometrajeEntrada.TabIndex = 11;
            //
            // lblMontoMora
            //
            lblMontoMora.AutoSize = true;
            lblMontoMora.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMontoMora.ForeColor = Color.FromArgb(51, 51, 76);
            lblMontoMora.Location = new Point(40, 250);
            lblMontoMora.Name = "lblMontoMora";
            lblMontoMora.Size = new Size(85, 19);
            lblMontoMora.TabIndex = 12;
            lblMontoMora.Text = "Monto Mora";
            //
            // txtMontoMora
            //
            txtMontoMora.Font = new Font("Segoe UI", 10F);
            txtMontoMora.Location = new Point(40, 275);
            txtMontoMora.Name = "txtMontoMora";
            txtMontoMora.Size = new Size(180, 25);
            txtMontoMora.TabIndex = 13;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(51, 51, 76);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(265, 320);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 45);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Registrar Alquiler";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // CargaAlquilerVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(separador);
            Controls.Add(cbReserva);
            Controls.Add(lblReserva);
            Controls.Add(lblCombustibleSalida);
            Controls.Add(txtCombustibleSalida);
            Controls.Add(lblKilometrajeSalida);
            Controls.Add(txtKilometrajeSalida);
            Controls.Add(lblCombustibleEntrada);
            Controls.Add(txtCombustibleEntrada);
            Controls.Add(lblKilometrajeEntrada);
            Controls.Add(txtKilometrajeEntrada);
            Controls.Add(lblMontoMora);
            Controls.Add(txtMontoMora);
            Controls.Add(btnGuardar);
            Name = "CargaAlquilerVista";
            Size = new Size(750, 400);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel separador;
        private ComboBox cbReserva;
        private Label lblReserva;
        private Label lblCombustibleSalida;
        private TextBox txtCombustibleSalida;
        private Label lblKilometrajeSalida;
        private TextBox txtKilometrajeSalida;
        private Label lblCombustibleEntrada;
        private TextBox txtCombustibleEntrada;
        private Label lblKilometrajeEntrada;
        private TextBox txtKilometrajeEntrada;
        private Label lblMontoMora;
        private TextBox txtMontoMora;
        private Button btnGuardar;
    }
}
