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
            panelIcono = new Panel();
            lblIcono = new Label();
            lblContrasenia = new Label();
            txtContrasenia = new TextBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            btnIniciarSesion = new Button();
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
            panelHeader.Size = new Size(684, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(182, 25);
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
            lblSubtitulo.Size = new Size(151, 15);
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
            panelContenido.Size = new Size(684, 311);
            panelContenido.TabIndex = 1;
            // 
            // panelIcono
            // 
            panelIcono.BackColor = Color.FromArgb(51, 51, 76);
            panelIcono.Dock = DockStyle.Top;
            panelIcono.Location = new Point(0, 0);
            panelIcono.Name = "panelIcono";
            panelIcono.Size = new Size(684, 55);
            panelIcono.TabIndex = 1;
            // 
            // lblIcono
            // 
            lblIcono.AutoSize = true;
            lblIcono.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblIcono.ForeColor = Color.White;
            lblIcono.Location = new Point(105, 8);
            lblIcono.Name = "lblIcono";
            lblIcono.Size = new Size(58, 45);
            lblIcono.TabIndex = 0;
            lblIcono.Text = "🔒";
            lblIcono.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblContrasenia
            // 
            lblContrasenia.AutoSize = true;
            lblContrasenia.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContrasenia.ForeColor = Color.FromArgb(51, 51, 76);
            lblContrasenia.Location = new Point(176, 128);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(69, 15);
            lblContrasenia.TabIndex = 4;
            lblContrasenia.Text = "Contraseña";
            // 
            // txtContrasenia
            // 
            txtContrasenia.Font = new Font("Segoe UI", 10F);
            txtContrasenia.Location = new Point(176, 148);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(300, 25);
            txtContrasenia.TabIndex = 5;
            txtContrasenia.UseSystemPasswordChar = true;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(51, 51, 76);
            lblUsuario.Location = new Point(176, 58);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(49, 15);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtUsuario.Location = new Point(176, 78);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(300, 25);
            txtUsuario.TabIndex = 3;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.FromArgb(51, 51, 76);
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.Location = new Point(176, 198);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(300, 45);
            btnIniciarSesion.TabIndex = 6;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            ClientSize = new Size(684, 361);
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