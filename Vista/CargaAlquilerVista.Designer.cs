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
            txtBuscarReserva = new TextBox();
            cbReserva = new ComboBox();
            lblReserva = new Label();
            lblCombustibleSalida = new Label();
            txtCombustibleSalida = new TextBox();
            lblKilometrajeSalida = new Label();
            txtKilometrajeSalida = new TextBox();
            btnGuardar = new Button();
            lblResumen = new Label();
            lblAvisoLicencia = new Label();
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
            lblTitulo.Text = "Registrar Entrega";
            //
            // separador
            //
            separador.BackColor = Color.FromArgb(51, 51, 76);
            separador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            separador.Location = new Point(25, 55);
            separador.Name = "separador";
            separador.Size = new Size(700, 2);
            separador.TabIndex = 1;
            //
            // txtBuscarReserva
            //
            txtBuscarReserva.Font = new Font("Segoe UI", 10F);
            txtBuscarReserva.Location = new Point(40, 80);
            txtBuscarReserva.Name = "txtBuscarReserva";
            txtBuscarReserva.PlaceholderText = "Buscar reserva por cliente, matrícula...";
            txtBuscarReserva.Size = new Size(400, 25);
            txtBuscarReserva.TabIndex = 2;
            //
            // cbReserva
            //
            cbReserva.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReserva.Font = new Font("Segoe UI", 10F);
            cbReserva.FormattingEnabled = true;
            cbReserva.Location = new Point(40, 110);
            cbReserva.Name = "cbReserva";
            cbReserva.Size = new Size(400, 25);
            cbReserva.TabIndex = 3;
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
            lblCombustibleSalida.Location = new Point(40, 150);
            lblCombustibleSalida.Name = "lblCombustibleSalida";
            lblCombustibleSalida.Size = new Size(125, 19);
            lblCombustibleSalida.TabIndex = 4;
            lblCombustibleSalida.Text = "Combustible al entregar (%)";
            //
            // txtCombustibleSalida
            //
            txtCombustibleSalida.Font = new Font("Segoe UI", 10F);
            txtCombustibleSalida.Location = new Point(40, 175);
            txtCombustibleSalida.Name = "txtCombustibleSalida";
            txtCombustibleSalida.Size = new Size(180, 25);
            txtCombustibleSalida.TabIndex = 5;
            //
            // lblKilometrajeSalida
            //
            lblKilometrajeSalida.AutoSize = true;
            lblKilometrajeSalida.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKilometrajeSalida.ForeColor = Color.FromArgb(51, 51, 76);
            lblKilometrajeSalida.Location = new Point(260, 150);
            lblKilometrajeSalida.Name = "lblKilometrajeSalida";
            lblKilometrajeSalida.Size = new Size(120, 19);
            lblKilometrajeSalida.TabIndex = 6;
            lblKilometrajeSalida.Text = "Kilometraje al entregar (km)";
            //
            // txtKilometrajeSalida
            //
            txtKilometrajeSalida.Font = new Font("Segoe UI", 10F);
            txtKilometrajeSalida.Location = new Point(260, 175);
            txtKilometrajeSalida.Name = "txtKilometrajeSalida";
            txtKilometrajeSalida.Size = new Size(180, 25);
            txtKilometrajeSalida.TabIndex = 7;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(51, 51, 76);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Anchor = AnchorStyles.Bottom;
            btnGuardar.Location = new Point(275, 215);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 45);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Registrar Entrega";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // lblResumen
            //
            lblResumen.BackColor = Color.White;
            lblResumen.BorderStyle = BorderStyle.FixedSingle;
            lblResumen.Font = new Font("Segoe UI", 8.25F);
            lblResumen.ForeColor = Color.FromArgb(51, 51, 76);
            lblResumen.Location = new Point(470, 62);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(255, 205);
            lblResumen.TabIndex = 9;
            lblResumen.Text = "";
            //
            // lblAvisoLicencia
            //
            lblAvisoLicencia.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblAvisoLicencia.ForeColor = Color.FromArgb(180, 40, 40);
            lblAvisoLicencia.Location = new Point(40, 265);
            lblAvisoLicencia.Name = "lblAvisoLicencia";
            lblAvisoLicencia.Size = new Size(400, 32);
            lblAvisoLicencia.TabIndex = 10;
            lblAvisoLicencia.Text = "";
            lblAvisoLicencia.Visible = false;
            //
            // CargaAlquilerVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(separador);
            Controls.Add(txtBuscarReserva);
            Controls.Add(cbReserva);
            Controls.Add(lblReserva);
            Controls.Add(lblCombustibleSalida);
            Controls.Add(txtCombustibleSalida);
            Controls.Add(lblKilometrajeSalida);
            Controls.Add(txtKilometrajeSalida);
            Controls.Add(btnGuardar);
            Controls.Add(lblResumen);
            Controls.Add(lblAvisoLicencia);
            Name = "CargaAlquilerVista";
            MinimumSize = new Size(750, 300);
            Size = new Size(750, 300);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel separador;
        private TextBox txtBuscarReserva;
        private ComboBox cbReserva;
        private Label lblReserva;
        private Label lblCombustibleSalida;
        private TextBox txtCombustibleSalida;
        private Label lblKilometrajeSalida;
        private TextBox txtKilometrajeSalida;
        private Button btnGuardar;
        private Label lblResumen;
        private Label lblAvisoLicencia;
    }
}
