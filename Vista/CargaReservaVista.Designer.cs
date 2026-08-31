namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class CargaReservaVista
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
            cbCliente = new ComboBox();
            lblCliente = new Label();
            cbVehiculo = new ComboBox();
            lblVehiculo = new Label();
            cbEmpleado = new ComboBox();
            lblEmpleado = new Label();
            panelDerecha = new Panel();
            cbEstado = new ComboBox();
            lblEstado = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaInicio = new Label();
            dtpFechaFin = new DateTimePicker();
            lblFechaFin = new Label();
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
            lblTitulo.Size = new Size(150, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Crear Reserva";
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
            panelIzquierda.Controls.Add(cbCliente);
            panelIzquierda.Controls.Add(lblCliente);
            panelIzquierda.Controls.Add(cbVehiculo);
            panelIzquierda.Controls.Add(lblVehiculo);
            panelIzquierda.Controls.Add(cbEmpleado);
            panelIzquierda.Controls.Add(lblEmpleado);
            panelIzquierda.Location = new Point(25, 70);
            panelIzquierda.Name = "panelIzquierda";
            panelIzquierda.Size = new Size(345, 230);
            panelIzquierda.TabIndex = 2;
            //
            // cbCliente
            //
            cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCliente.Font = new Font("Segoe UI", 9F);
            cbCliente.FormattingEnabled = true;
            cbCliente.Location = new Point(15, 35);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(310, 23);
            cbCliente.TabIndex = 0;
            //
            // lblCliente
            //
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCliente.ForeColor = Color.FromArgb(51, 51, 76);
            lblCliente.Location = new Point(15, 15);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(48, 15);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente";
            //
            // cbVehiculo
            //
            cbVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVehiculo.Font = new Font("Segoe UI", 9F);
            cbVehiculo.FormattingEnabled = true;
            cbVehiculo.Location = new Point(15, 85);
            cbVehiculo.Name = "cbVehiculo";
            cbVehiculo.Size = new Size(310, 23);
            cbVehiculo.TabIndex = 2;
            //
            // lblVehiculo
            //
            lblVehiculo.AutoSize = true;
            lblVehiculo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVehiculo.ForeColor = Color.FromArgb(51, 51, 76);
            lblVehiculo.Location = new Point(15, 65);
            lblVehiculo.Name = "lblVehiculo";
            lblVehiculo.Size = new Size(56, 15);
            lblVehiculo.TabIndex = 3;
            lblVehiculo.Text = "Vehiculo";
            //
            // cbEmpleado
            //
            cbEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmpleado.Font = new Font("Segoe UI", 9F);
            cbEmpleado.FormattingEnabled = true;
            cbEmpleado.Location = new Point(15, 135);
            cbEmpleado.Name = "cbEmpleado";
            cbEmpleado.Size = new Size(310, 23);
            cbEmpleado.TabIndex = 4;
            //
            // lblEmpleado
            //
            lblEmpleado.AutoSize = true;
            lblEmpleado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmpleado.ForeColor = Color.FromArgb(51, 51, 76);
            lblEmpleado.Location = new Point(15, 115);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(62, 15);
            lblEmpleado.TabIndex = 5;
            lblEmpleado.Text = "Empleado";
            //
            // panelDerecha
            //
            panelDerecha.BackColor = Color.White;
            panelDerecha.Controls.Add(cbEstado);
            panelDerecha.Controls.Add(lblEstado);
            panelDerecha.Controls.Add(dtpFechaInicio);
            panelDerecha.Controls.Add(lblFechaInicio);
            panelDerecha.Controls.Add(dtpFechaFin);
            panelDerecha.Controls.Add(lblFechaFin);
            panelDerecha.Location = new Point(385, 70);
            panelDerecha.Name = "panelDerecha";
            panelDerecha.Size = new Size(340, 230);
            panelDerecha.TabIndex = 3;
            //
            // cbEstado
            //
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.Font = new Font("Segoe UI", 9F);
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(15, 35);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(305, 23);
            cbEstado.TabIndex = 0;
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(51, 51, 76);
            lblEstado.Location = new Point(15, 15);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(43, 15);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "Estado";
            //
            // dtpFechaInicio
            //
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(15, 85);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(305, 23);
            dtpFechaInicio.TabIndex = 2;
            //
            // lblFechaInicio
            //
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaInicio.ForeColor = Color.FromArgb(51, 51, 76);
            lblFechaInicio.Location = new Point(15, 65);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(75, 15);
            lblFechaInicio.TabIndex = 3;
            lblFechaInicio.Text = "Fecha Inicio";
            //
            // dtpFechaFin
            //
            dtpFechaFin.Font = new Font("Segoe UI", 9F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(15, 135);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(305, 23);
            dtpFechaFin.TabIndex = 4;
            //
            // lblFechaFin
            //
            lblFechaFin.AutoSize = true;
            lblFechaFin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaFin.ForeColor = Color.FromArgb(51, 51, 76);
            lblFechaFin.Location = new Point(15, 115);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(62, 15);
            lblFechaFin.TabIndex = 5;
            lblFechaFin.Text = "Fecha Fin";
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
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Crear Reserva";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // CargaReservaVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(separador);
            Controls.Add(panelIzquierda);
            Controls.Add(panelDerecha);
            Controls.Add(btnGuardar);
            Name = "CargaReservaVista";
            Size = new Size(750, 400);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel separador;
        private Panel panelIzquierda;
        private ComboBox cbCliente;
        private Label lblCliente;
        private ComboBox cbVehiculo;
        private Label lblVehiculo;
        private ComboBox cbEmpleado;
        private Label lblEmpleado;
        private Panel panelDerecha;
        private ComboBox cbEstado;
        private Label lblEstado;
        private DateTimePicker dtpFechaInicio;
        private Label lblFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Label lblFechaFin;
        private Button btnGuardar;
    }
}
