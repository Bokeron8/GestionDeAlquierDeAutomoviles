namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class CargaEmpleadoVista
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            panelDerecha = new Panel();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblFechaContratacion = new Label();
            dtpFechaContratacion = new DateTimePicker();
            cbRol = new ComboBox();
            lblRol = new Label();
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
            lblTitulo.Text = "Agregar Empleado";
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
            panelIzquierda.Controls.Add(lblNombre);
            panelIzquierda.Controls.Add(txtNombre);
            panelIzquierda.Controls.Add(lblApellido);
            panelIzquierda.Controls.Add(txtApellido);
            panelIzquierda.Controls.Add(lblDni);
            panelIzquierda.Controls.Add(txtDni);
            panelIzquierda.Controls.Add(lblFechaNacimiento);
            panelIzquierda.Controls.Add(dtpFechaNacimiento);
            panelIzquierda.Controls.Add(lblDireccion);
            panelIzquierda.Controls.Add(txtDireccion);
            panelIzquierda.Location = new Point(25, 70);
            panelIzquierda.Name = "panelIzquierda";
            panelIzquierda.Size = new Size(345, 280);
            panelIzquierda.TabIndex = 2;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(51, 51, 76);
            lblNombre.Location = new Point(15, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(52, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            //
            // txtNombre
            //
            txtNombre.Font = new Font("Segoe UI", 9F);
            txtNombre.Location = new Point(15, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(310, 23);
            txtNombre.TabIndex = 1;
            //
            // lblApellido
            //
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(51, 51, 76);
            lblApellido.Location = new Point(15, 65);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido";
            //
            // txtApellido
            //
            txtApellido.Font = new Font("Segoe UI", 9F);
            txtApellido.Location = new Point(15, 85);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(310, 23);
            txtApellido.TabIndex = 3;
            //
            // lblDni
            //
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDni.ForeColor = Color.FromArgb(51, 51, 76);
            lblDni.Location = new Point(15, 115);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(28, 15);
            lblDni.TabIndex = 4;
            lblDni.Text = "DNI";
            //
            // txtDni
            //
            txtDni.Font = new Font("Segoe UI", 9F);
            txtDni.Location = new Point(15, 135);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(310, 23);
            txtDni.TabIndex = 5;
            //
            // lblFechaNacimiento
            //
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaNacimiento.ForeColor = Color.FromArgb(51, 51, 76);
            lblFechaNacimiento.Location = new Point(15, 165);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(115, 15);
            lblFechaNacimiento.TabIndex = 6;
            lblFechaNacimiento.Text = "Fecha Nacimiento";
            //
            // dtpFechaNacimiento
            //
            dtpFechaNacimiento.Font = new Font("Segoe UI", 9F);
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(15, 185);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(310, 23);
            dtpFechaNacimiento.TabIndex = 7;
            //
            // lblDireccion
            //
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDireccion.ForeColor = Color.FromArgb(51, 51, 76);
            lblDireccion.Location = new Point(15, 215);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(58, 15);
            lblDireccion.TabIndex = 8;
            lblDireccion.Text = "Dirección";
            //
            // txtDireccion
            //
            txtDireccion.Font = new Font("Segoe UI", 9F);
            txtDireccion.Location = new Point(15, 235);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(310, 23);
            txtDireccion.TabIndex = 9;
            //
            // panelDerecha
            //
            panelDerecha.BackColor = Color.White;
            panelDerecha.Controls.Add(lblTelefono);
            panelDerecha.Controls.Add(txtTelefono);
            panelDerecha.Controls.Add(lblCorreo);
            panelDerecha.Controls.Add(txtCorreo);
            panelDerecha.Controls.Add(lblFechaContratacion);
            panelDerecha.Controls.Add(dtpFechaContratacion);
            panelDerecha.Controls.Add(cbRol);
            panelDerecha.Controls.Add(lblRol);
            panelDerecha.Location = new Point(385, 70);
            panelDerecha.Name = "panelDerecha";
            panelDerecha.Size = new Size(340, 280);
            panelDerecha.TabIndex = 3;
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(51, 51, 76);
            lblTelefono.Location = new Point(15, 15);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(55, 15);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Telefono";
            //
            // txtTelefono
            //
            txtTelefono.Font = new Font("Segoe UI", 9F);
            txtTelefono.Location = new Point(15, 35);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(305, 23);
            txtTelefono.TabIndex = 1;
            //
            // lblCorreo
            //
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCorreo.ForeColor = Color.FromArgb(51, 51, 76);
            lblCorreo.Location = new Point(15, 65);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(45, 15);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "Correo";
            //
            // txtCorreo
            //
            txtCorreo.Font = new Font("Segoe UI", 9F);
            txtCorreo.Location = new Point(15, 85);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(305, 23);
            txtCorreo.TabIndex = 3;
            //
            // lblFechaContratacion
            //
            lblFechaContratacion.AutoSize = true;
            lblFechaContratacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaContratacion.ForeColor = Color.FromArgb(51, 51, 76);
            lblFechaContratacion.Location = new Point(15, 115);
            lblFechaContratacion.Name = "lblFechaContratacion";
            lblFechaContratacion.Size = new Size(115, 15);
            lblFechaContratacion.TabIndex = 4;
            lblFechaContratacion.Text = "Fecha Contratación";
            //
            // dtpFechaContratacion
            //
            dtpFechaContratacion.Font = new Font("Segoe UI", 9F);
            dtpFechaContratacion.Format = DateTimePickerFormat.Short;
            dtpFechaContratacion.Location = new Point(15, 135);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(305, 23);
            dtpFechaContratacion.TabIndex = 5;
            //
            // cbRol
            //
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.Font = new Font("Segoe UI", 9F);
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(15, 185);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(305, 23);
            cbRol.TabIndex = 6;
            //
            // lblRol
            //
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRol.ForeColor = Color.FromArgb(51, 51, 76);
            lblRol.Location = new Point(15, 165);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(27, 15);
            lblRol.TabIndex = 7;
            lblRol.Text = "Rol";
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(51, 51, 76);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(265, 370);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 45);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar Empleado";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // CargaEmpleadoVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(separador);
            Controls.Add(panelIzquierda);
            Controls.Add(panelDerecha);
            Controls.Add(btnGuardar);
            Name = "CargaEmpleadoVista";
            Size = new Size(750, 440);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel separador;
        private Panel panelIzquierda;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblDni;
        private TextBox txtDni;
        private Label lblFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private Panel panelDerecha;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblFechaContratacion;
        private DateTimePicker dtpFechaContratacion;
        private ComboBox cbRol;
        private Label lblRol;
        private Button btnGuardar;
    }
}
