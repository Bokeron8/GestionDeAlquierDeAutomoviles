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
            panelContenido = new Panel();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { cargarVehiculoToolStripMenuItem, listarVehiculosToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // cargarVehiculoToolStripMenuItem
            // 
            cargarVehiculoToolStripMenuItem.Name = "cargarVehiculoToolStripMenuItem";
            cargarVehiculoToolStripMenuItem.Size = new Size(103, 20);
            cargarVehiculoToolStripMenuItem.Text = "Cargar Vehiculo";
            cargarVehiculoToolStripMenuItem.Click += CargarVehiculoToolStripMenuItem_Click;
            // 
            // listarVehiculosToolStripMenuItem
            // 
            listarVehiculosToolStripMenuItem.Name = "listarVehiculosToolStripMenuItem";
            listarVehiculosToolStripMenuItem.Size = new Size(110, 20);
            listarVehiculosToolStripMenuItem.Text = "Listar Vehiculos";
            listarVehiculosToolStripMenuItem.Click += ListarVehiculosToolStripMenuItem_Click;
            // 
            // panelContenido
            // 
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 24);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(800, 426);
            panelContenido.TabIndex = 1;
            // 
            // PrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenido);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "PrincipalForm";
            Text = "Gestion de Alquiler de Automoviles";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem cargarVehiculoToolStripMenuItem;
        private ToolStripMenuItem listarVehiculosToolStripMenuItem;
        private Panel panelContenido;
    }
}
