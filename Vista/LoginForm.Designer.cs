namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class LoginForm
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
            panelHeader = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            panelContenido = new Panel();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasenia = new Label();
            txtContrasenia = new TextBox();
            btnIniciarSesion = new Button();
            panelIcono = new Panel();
            lblIcono = new Label();
            panelHeader.SuspendLayout();
            panelContenido.SuspendLayout();
            SuspendLayout();
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(51, 51, 76);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(400, 50);
            panelHeader.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(160, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestion de Alquiler";
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblSubtitulo.Location = new Point(15, 15);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(200, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Inicie sesion para continuar";
            //
            // panelContenido
            //
            panelContenido.BackColor = Color.FromArgb(240, 240, 245);
            panelContenido.Controls.Add(panelIcono);
            panelContenido.Controls.Add(lblIcono);
            panelContenido.Controls.Add(lblContrasenia);
            panelContenido.Controls.Add(txtContrasenia);
            panelContenido.Controls.Add(lblUsuario);
            panelContenido.Controls.Add(txtUsuario);
            panelContenido.Controls.Add(btnIniciarSesion);
            panelContenido.Controls.Add(lblSubtitulo);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 50);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(400, 350);
            panelContenido.TabIndex = 1;
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(51, 51, 76);
            lblUsuario.Location = new Point(50, 130);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(60, 15);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario";
            //
            // txtUsuario
            //
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtUsuario.Location = new Point(50, 150);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(300, 30);
            txtUsuario.TabIndex = 3;
            //
            // lblContrasenia
            //
            lblContrasenia.AutoSize = true;
            lblContrasenia.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContrasenia.ForeColor = Color.FromArgb(51, 51, 76);
            lblContrasenia.Location = new Point(50, 200);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(76, 15);
            lblContrasenia.TabIndex = 4;
            lblContrasenia.Text = "Contraseña";
            //
            // txtContrasenia
            //
            txtContrasenia.Font = new Font("Segoe UI", 10F);
            txtContrasenia.Location = new Point(50, 220);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(300, 30);
            txtContrasenia.TabIndex = 5;
            txtContrasenia.UseSystemPasswordChar = true;
            //
            // btnIniciarSesion
            //
            btnIniciarSesion.BackColor = Color.FromArgb(51, 51, 76);
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.Location = new Point(50, 270);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(300, 45);
            btnIniciarSesion.TabIndex = 6;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            //
            // panelIcono
            //
            panelIcono.BackColor = Color.FromArgb(51, 51, 76);
            panelIcono.Controls.Add(lblIcono);
            panelIcono.Dock = DockStyle.Top;
            panelIcono.Location = new Point(50, 60);
            panelIcono.Name = "panelIcono";
            panelIcono.Size = new Size(300, 55);
            panelIcono.TabIndex = 1;
            //
            // lblIcono
            //
            lblIcono.AutoSize = true;
            lblIcono.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblIcono.ForeColor = Color.White;
            lblIcono.Location = new Point(105, 8);
            lblIcono.Name = "lblIcono";
            lblIcono.Size = new Size(90, 38);
            lblIcono.TabIndex = 0;
            lblIcono.Text = "🔒";
            lblIcono.TextAlign = ContentAlignment.MiddleCenter;
            //
            // LoginForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            ClientSize = new Size(400, 350);
            Controls.Add(panelContenido);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion de Alquiler de Automoviles";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContenido.ResumeLayout(false);
            panelContenido.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel panelContenido;
        private Panel panelIcono;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblContrasenia;
        private TextBox txtContrasenia;
        private Button btnIniciarSesion;
        private Label lblIcono;
    }
}