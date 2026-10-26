namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class DevolucionVista
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
            lblContrato = new Label();
            lblFechaDevolucion = new Label();
            dtpFechaDevolucion = new DateTimePicker();
            lblKilometrajeEntrada = new Label();
            txtKilometrajeEntrada = new TextBox();
            lblCombustibleEntrada = new Label();
            txtCombustibleEntrada = new TextBox();
            lblMontoMora = new Label();
            txtMontoMora = new TextBox();
            btnConfirmar = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(210, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Devolución";
            //
            // separador
            //
            separador.BackColor = Color.FromArgb(51, 51, 76);
            separador.Location = new Point(25, 55);
            separador.Name = "separador";
            separador.Size = new Size(700, 2);
            separador.TabIndex = 1;
            //
            // lblContrato
            //
            lblContrato.BackColor = Color.White;
            lblContrato.BorderStyle = BorderStyle.FixedSingle;
            lblContrato.Font = new Font("Segoe UI", 10F);
            lblContrato.ForeColor = Color.FromArgb(51, 51, 76);
            lblContrato.Location = new Point(40, 70);
            lblContrato.Name = "lblContrato";
            lblContrato.Padding = new Padding(10);
            lblContrato.Size = new Size(670, 115);
            lblContrato.TabIndex = 2;
            lblContrato.Text = "Seleccione un alquiler.";
            //
            // lblFechaDevolucion
            //
            lblFechaDevolucion.AutoSize = true;
            lblFechaDevolucion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFechaDevolucion.ForeColor = Color.FromArgb(51, 51, 76);
            lblFechaDevolucion.Location = new Point(40, 200);
            lblFechaDevolucion.Name = "lblFechaDevolucion";
            lblFechaDevolucion.Size = new Size(145, 19);
            lblFechaDevolucion.TabIndex = 3;
            lblFechaDevolucion.Text = "Fecha de Devolución";
            //
            // dtpFechaDevolucion
            //
            dtpFechaDevolucion.Font = new Font("Segoe UI", 10F);
            dtpFechaDevolucion.Format = DateTimePickerFormat.Short;
            dtpFechaDevolucion.Location = new Point(40, 222);
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            dtpFechaDevolucion.Size = new Size(300, 25);
            dtpFechaDevolucion.TabIndex = 4;
            //
            // lblKilometrajeEntrada
            //
            lblKilometrajeEntrada.AutoSize = true;
            lblKilometrajeEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKilometrajeEntrada.ForeColor = Color.FromArgb(51, 51, 76);
            lblKilometrajeEntrada.Location = new Point(370, 200);
            lblKilometrajeEntrada.Name = "lblKilometrajeEntrada";
            lblKilometrajeEntrada.Size = new Size(150, 19);
            lblKilometrajeEntrada.TabIndex = 5;
            lblKilometrajeEntrada.Text = "Kilometraje Entrada";
            //
            // txtKilometrajeEntrada
            //
            txtKilometrajeEntrada.Font = new Font("Segoe UI", 10F);
            txtKilometrajeEntrada.Location = new Point(370, 222);
            txtKilometrajeEntrada.Name = "txtKilometrajeEntrada";
            txtKilometrajeEntrada.Size = new Size(300, 25);
            txtKilometrajeEntrada.TabIndex = 6;
            //
            // lblCombustibleEntrada
            //
            lblCombustibleEntrada.AutoSize = true;
            lblCombustibleEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCombustibleEntrada.ForeColor = Color.FromArgb(51, 51, 76);
            lblCombustibleEntrada.Location = new Point(40, 265);
            lblCombustibleEntrada.Name = "lblCombustibleEntrada";
            lblCombustibleEntrada.Size = new Size(155, 19);
            lblCombustibleEntrada.TabIndex = 7;
            lblCombustibleEntrada.Text = "Combustible Entrada (%)";
            //
            // txtCombustibleEntrada
            //
            txtCombustibleEntrada.Font = new Font("Segoe UI", 10F);
            txtCombustibleEntrada.Location = new Point(40, 287);
            txtCombustibleEntrada.Name = "txtCombustibleEntrada";
            txtCombustibleEntrada.Size = new Size(300, 25);
            txtCombustibleEntrada.TabIndex = 8;
            //
            // lblMontoMora
            //
            lblMontoMora.AutoSize = true;
            lblMontoMora.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMontoMora.ForeColor = Color.FromArgb(51, 51, 76);
            lblMontoMora.Location = new Point(370, 265);
            lblMontoMora.Name = "lblMontoMora";
            lblMontoMora.Size = new Size(135, 19);
            lblMontoMora.TabIndex = 9;
            lblMontoMora.Text = "Monto Mora (tardanza)";
            //
            // txtMontoMora
            //
            txtMontoMora.Font = new Font("Segoe UI", 10F);
            txtMontoMora.Location = new Point(370, 287);
            txtMontoMora.Name = "txtMontoMora";
            txtMontoMora.Size = new Size(300, 25);
            txtMontoMora.TabIndex = 10;
            //
            // btnConfirmar
            //
            btnConfirmar.BackColor = Color.FromArgb(51, 51, 76);
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(265, 340);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(220, 45);
            btnConfirmar.TabIndex = 11;
            btnConfirmar.Text = "Confirmar Devolución";
            btnConfirmar.UseVisualStyleBackColor = false;
            //
            // DevolucionVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(separador);
            Controls.Add(lblContrato);
            Controls.Add(lblFechaDevolucion);
            Controls.Add(dtpFechaDevolucion);
            Controls.Add(lblKilometrajeEntrada);
            Controls.Add(txtKilometrajeEntrada);
            Controls.Add(lblCombustibleEntrada);
            Controls.Add(txtCombustibleEntrada);
            Controls.Add(lblMontoMora);
            Controls.Add(txtMontoMora);
            Controls.Add(btnConfirmar);
            Name = "DevolucionVista";
            Size = new Size(750, 410);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel separador;
        private Label lblContrato;
        private Label lblFechaDevolucion;
        private DateTimePicker dtpFechaDevolucion;
        private Label lblKilometrajeEntrada;
        private TextBox txtKilometrajeEntrada;
        private Label lblCombustibleEntrada;
        private TextBox txtCombustibleEntrada;
        private Label lblMontoMora;
        private TextBox txtMontoMora;
        private Button btnConfirmar;
    }
}
