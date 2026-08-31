namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class PrincipalForm
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
            menuStrip = new MenuStrip();
            cargarVehiculoToolStripMenuItem = new ToolStripMenuItem();
            listarVehiculosToolStripMenuItem = new ToolStripMenuItem();
            panelHeader = new Panel();
            lblTitulo = new Label();
            panelContenido = new Panel();
            menuStrip.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.FromArgb(51, 51, 76);
            menuStrip.Items.AddRange(new ToolStripItem[] { cargarVehiculoToolStripMenuItem, listarVehiculosToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(900, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // cargarVehiculoToolStripMenuItem
            // 
            cargarVehiculoToolStripMenuItem.ForeColor = Color.White;
            cargarVehiculoToolStripMenuItem.Name = "cargarVehiculoToolStripMenuItem";
            cargarVehiculoToolStripMenuItem.Size = new Size(103, 20);
            cargarVehiculoToolStripMenuItem.Text = "Cargar Vehiculo";
            cargarVehiculoToolStripMenuItem.Click += CargarVehiculoToolStripMenuItem_Click;
            // 
            // listarVehiculosToolStripMenuItem
            // 
            listarVehiculosToolStripMenuItem.ForeColor = Color.White;
            listarVehiculosToolStripMenuItem.Name = "listarVehiculosToolStripMenuItem";
            listarVehiculosToolStripMenuItem.Size = new Size(110, 20);
            listarVehiculosToolStripMenuItem.Text = "Listar Vehiculos";
            listarVehiculosToolStripMenuItem.Click += ListarVehiculosToolStripMenuItem_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(68, 68, 102);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 24);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 50);
            panelHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(280, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestion de Alquiler de Automoviles";
            // 
            // panelContenido
            // 
            panelContenido.BackColor = Color.FromArgb(240, 240, 245);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 74);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(900, 476);
            panelContenido.TabIndex = 2;
            // 
            // PrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            ClientSize = new Size(900, 550);
            Controls.Add(panelContenido);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(700, 400);
            Name = "PrincipalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion de Alquiler de Automoviles";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem cargarVehiculoToolStripMenuItem;
        private ToolStripMenuItem listarVehiculosToolStripMenuItem;
        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelContenido;
    }
}
