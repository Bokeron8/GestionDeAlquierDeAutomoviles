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
            lblReferencia = new Label();
            lblCombustibleEntrada = new Label();
            txtCombustibleEntrada = new TextBox();
            lblMontoMora = new Label();
            txtMontoMora = new TextBox();
            lblErrores = new Label();
            lblDerivados = new Label();
            lblResumenFinanciero = new Label();
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
            separador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            lblContrato.Size = new Size(670, 145);
            lblContrato.TabIndex = 2;
            lblContrato.Text = "Seleccione un alquiler.";
            //
            // lblFechaDevolucion
            //
            lblFechaDevolucion.AutoSize = true;
            lblFechaDevolucion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFechaDevolucion.ForeColor = Color.FromArgb(51, 51, 76);
            lblFechaDevolucion.Location = new Point(40, 225);
            lblFechaDevolucion.Name = "lblFechaDevolucion";
            lblFechaDevolucion.Size = new Size(145, 19);
            lblFechaDevolucion.TabIndex = 3;
            lblFechaDevolucion.Text = "Fecha de devolución";
            //
            // dtpFechaDevolucion
            //
            dtpFechaDevolucion.Font = new Font("Segoe UI", 10F);
            dtpFechaDevolucion.Format = DateTimePickerFormat.Short;
            dtpFechaDevolucion.Location = new Point(40, 247);
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            dtpFechaDevolucion.Size = new Size(300, 25);
            dtpFechaDevolucion.TabIndex = 4;
            //
            // lblKilometrajeEntrada
            //
            lblKilometrajeEntrada.AutoSize = true;
            lblKilometrajeEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKilometrajeEntrada.ForeColor = Color.FromArgb(51, 51, 76);
            lblKilometrajeEntrada.Location = new Point(370, 225);
            lblKilometrajeEntrada.Name = "lblKilometrajeEntrada";
            lblKilometrajeEntrada.Size = new Size(190, 19);
            lblKilometrajeEntrada.TabIndex = 5;
            lblKilometrajeEntrada.Text = "Kilometraje al devolver (km)";
            //
            // txtKilometrajeEntrada
            //
            txtKilometrajeEntrada.Font = new Font("Segoe UI", 10F);
            txtKilometrajeEntrada.Location = new Point(370, 247);
            txtKilometrajeEntrada.Name = "txtKilometrajeEntrada";
            txtKilometrajeEntrada.Size = new Size(300, 25);
            txtKilometrajeEntrada.TabIndex = 6;
            //
            // lblReferencia
            //
            lblReferencia.Font = new Font("Segoe UI", 9F);
            lblReferencia.ForeColor = Color.FromArgb(90, 90, 110);
            lblReferencia.Location = new Point(370, 276);
            lblReferencia.Name = "lblReferencia";
            lblReferencia.Size = new Size(340, 16);
            lblReferencia.TabIndex = 7;
            lblReferencia.Text = "";
            lblReferencia.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblCombustibleEntrada
            //
            lblCombustibleEntrada.AutoSize = true;
            lblCombustibleEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCombustibleEntrada.ForeColor = Color.FromArgb(51, 51, 76);
            lblCombustibleEntrada.Location = new Point(40, 300);
            lblCombustibleEntrada.Name = "lblCombustibleEntrada";
            lblCombustibleEntrada.Size = new Size(180, 19);
            lblCombustibleEntrada.TabIndex = 8;
            lblCombustibleEntrada.Text = "Combustible al devolver (%)";
            //
            // txtCombustibleEntrada
            //
            txtCombustibleEntrada.Font = new Font("Segoe UI", 10F);
            txtCombustibleEntrada.Location = new Point(40, 322);
            txtCombustibleEntrada.Name = "txtCombustibleEntrada";
            txtCombustibleEntrada.Size = new Size(300, 25);
            txtCombustibleEntrada.TabIndex = 9;
            //
            // lblMontoMora
            //
            lblMontoMora.AutoSize = true;
            lblMontoMora.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMontoMora.ForeColor = Color.FromArgb(51, 51, 76);
            lblMontoMora.Location = new Point(370, 300);
            lblMontoMora.Name = "lblMontoMora";
            lblMontoMora.Size = new Size(175, 19);
            lblMontoMora.TabIndex = 10;
            lblMontoMora.Text = "Mora por atraso (opcional)";
            //
            // txtMontoMora
            //
            txtMontoMora.Font = new Font("Segoe UI", 10F);
            txtMontoMora.Location = new Point(370, 322);
            txtMontoMora.Name = "txtMontoMora";
            txtMontoMora.Size = new Size(300, 25);
            txtMontoMora.TabIndex = 11;
            //
            // lblErrores
            //
            lblErrores.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblErrores.ForeColor = Color.FromArgb(180, 40, 40);
            lblErrores.Location = new Point(40, 352);
            lblErrores.Name = "lblErrores";
            lblErrores.Size = new Size(630, 30);
            lblErrores.TabIndex = 12;
            lblErrores.Text = "";
            lblErrores.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblDerivados
            //
            lblDerivados.Font = new Font("Segoe UI", 9F);
            lblDerivados.ForeColor = Color.FromArgb(90, 90, 110);
            lblDerivados.Location = new Point(40, 384);
            lblDerivados.Name = "lblDerivados";
            lblDerivados.Size = new Size(630, 18);
            lblDerivados.TabIndex = 13;
            lblDerivados.Text = "";
            lblDerivados.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblResumenFinanciero
            //
            lblResumenFinanciero.BackColor = Color.White;
            lblResumenFinanciero.BorderStyle = BorderStyle.FixedSingle;
            lblResumenFinanciero.Font = new Font("Segoe UI", 10F);
            lblResumenFinanciero.ForeColor = Color.FromArgb(51, 51, 76);
            lblResumenFinanciero.Location = new Point(40, 406);
            lblResumenFinanciero.Name = "lblResumenFinanciero";
            lblResumenFinanciero.Padding = new Padding(10);
            lblResumenFinanciero.Size = new Size(630, 75);
            lblResumenFinanciero.TabIndex = 14;
            lblResumenFinanciero.Text = "Resumen financiero del alquiler...";
            //
            // btnConfirmar
            //
            btnConfirmar.Anchor = AnchorStyles.Bottom;
            btnConfirmar.BackColor = Color.FromArgb(51, 51, 76);
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(265, 491);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(220, 45);
            btnConfirmar.TabIndex = 15;
            btnConfirmar.Text = "Confirmar Devolución";
            btnConfirmar.UseVisualStyleBackColor = false;
            //
            // DevolucionVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(separador);
            Controls.Add(lblContrato);
            Controls.Add(lblFechaDevolucion);
            Controls.Add(dtpFechaDevolucion);
            Controls.Add(lblKilometrajeEntrada);
            Controls.Add(txtKilometrajeEntrada);
            Controls.Add(lblReferencia);
            Controls.Add(lblCombustibleEntrada);
            Controls.Add(txtCombustibleEntrada);
            Controls.Add(lblMontoMora);
            Controls.Add(txtMontoMora);
            Controls.Add(lblErrores);
            Controls.Add(lblDerivados);
            Controls.Add(lblResumenFinanciero);
            Controls.Add(btnConfirmar);
            MinimumSize = new Size(300, 300);
            Name = "DevolucionVista";
            Size = new Size(750, 555);
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
        private Label lblReferencia;
        private Label lblCombustibleEntrada;
        private TextBox txtCombustibleEntrada;
        private Label lblMontoMora;
        private TextBox txtMontoMora;
        private Label lblErrores;
        private Label lblDerivados;
        private Label lblResumenFinanciero;
        private Button btnConfirmar;
    }
}
