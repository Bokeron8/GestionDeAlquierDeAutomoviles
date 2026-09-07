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
            vehiculosToolStripMenuItem = new ToolStripMenuItem();
            marcasToolStripMenuItem = new ToolStripMenuItem();
            modelosToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            empleadosToolStripMenuItem = new ToolStripMenuItem();
            reservasToolStripMenuItem = new ToolStripMenuItem();
            alquileresToolStripMenuItem = new ToolStripMenuItem();
            daniosToolStripMenuItem = new ToolStripMenuItem();
            estadosToolStripMenuItem = new ToolStripMenuItem();
            rolesToolStripMenuItem = new ToolStripMenuItem();
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
            menuStrip.Items.AddRange(new ToolStripItem[] { vehiculosToolStripMenuItem, marcasToolStripMenuItem, modelosToolStripMenuItem, categoriasToolStripMenuItem, clientesToolStripMenuItem, empleadosToolStripMenuItem, reservasToolStripMenuItem, alquileresToolStripMenuItem, daniosToolStripMenuItem, estadosToolStripMenuItem, rolesToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(900, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            //
            // vehiculosToolStripMenuItem
            //
            vehiculosToolStripMenuItem.ForeColor = Color.White;
            vehiculosToolStripMenuItem.Name = "vehiculosToolStripMenuItem";
            vehiculosToolStripMenuItem.Size = new Size(78, 20);
            vehiculosToolStripMenuItem.Text = "Vehiculos";
            vehiculosToolStripMenuItem.Click += ListarVehiculosToolStripMenuItem_Click;
            //
            // marcasToolStripMenuItem
            //
            marcasToolStripMenuItem.ForeColor = Color.White;
            marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            marcasToolStripMenuItem.Size = new Size(57, 20);
            marcasToolStripMenuItem.Text = "Marcas";
            marcasToolStripMenuItem.Click += ListarMarcasToolStripMenuItem_Click;
            //
            // modelosToolStripMenuItem
            //
            modelosToolStripMenuItem.ForeColor = Color.White;
            modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
            modelosToolStripMenuItem.Size = new Size(66, 20);
            modelosToolStripMenuItem.Text = "Modelos";
            modelosToolStripMenuItem.Click += ListarModelosToolStripMenuItem_Click;
            //
            // categoriasToolStripMenuItem
            //
            categoriasToolStripMenuItem.ForeColor = Color.White;
            categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            categoriasToolStripMenuItem.Size = new Size(80, 20);
            categoriasToolStripMenuItem.Text = "Categorias";
            categoriasToolStripMenuItem.Click += ListarCategoriasToolStripMenuItem_Click;
            //
            // clientesToolStripMenuItem
            //
            clientesToolStripMenuItem.ForeColor = Color.White;
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(64, 20);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += ListarClientesToolStripMenuItem_Click;
            //
            // empleadosToolStripMenuItem
            //
            empleadosToolStripMenuItem.ForeColor = Color.White;
            empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            empleadosToolStripMenuItem.Size = new Size(81, 20);
            empleadosToolStripMenuItem.Text = "Empleados";
            empleadosToolStripMenuItem.Click += ListarEmpleadosToolStripMenuItem_Click;
            //
            // reservasToolStripMenuItem
            //
            reservasToolStripMenuItem.ForeColor = Color.White;
            reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            reservasToolStripMenuItem.Size = new Size(63, 20);
            reservasToolStripMenuItem.Text = "Reservas";
            reservasToolStripMenuItem.Click += ListarReservasToolStripMenuItem_Click;
            //
            // alquileresToolStripMenuItem
            //
            alquileresToolStripMenuItem.ForeColor = Color.White;
            alquileresToolStripMenuItem.Name = "alquileresToolStripMenuItem";
            alquileresToolStripMenuItem.Size = new Size(76, 20);
            alquileresToolStripMenuItem.Text = "Alquileres";
            alquileresToolStripMenuItem.Click += ListarAlquileresToolStripMenuItem_Click;
            //
            // daniosToolStripMenuItem
            //
            daniosToolStripMenuItem.ForeColor = Color.White;
            daniosToolStripMenuItem.Name = "daniosToolStripMenuItem";
            daniosToolStripMenuItem.Size = new Size(54, 20);
            daniosToolStripMenuItem.Text = "Danios";
            daniosToolStripMenuItem.Click += ListarDaniosToolStripMenuItem_Click;
            //
            // estadosToolStripMenuItem
            //
            estadosToolStripMenuItem.ForeColor = Color.White;
            estadosToolStripMenuItem.Name = "estadosToolStripMenuItem";
            estadosToolStripMenuItem.Size = new Size(60, 20);
            estadosToolStripMenuItem.Text = "Estados";
            estadosToolStripMenuItem.Click += ListarEstadosToolStripMenuItem_Click;
            //
            // rolesToolStripMenuItem
            //
            rolesToolStripMenuItem.ForeColor = Color.White;
            rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            rolesToolStripMenuItem.Size = new Size(48, 20);
            rolesToolStripMenuItem.Text = "Roles";
            rolesToolStripMenuItem.Click += ListarRolesToolStripMenuItem_Click;
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
        private ToolStripMenuItem vehiculosToolStripMenuItem;
        private ToolStripMenuItem marcasToolStripMenuItem;
        private ToolStripMenuItem modelosToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem empleadosToolStripMenuItem;
        private ToolStripMenuItem reservasToolStripMenuItem;
        private ToolStripMenuItem alquileresToolStripMenuItem;
        private ToolStripMenuItem daniosToolStripMenuItem;
        private ToolStripMenuItem estadosToolStripMenuItem;
        private ToolStripMenuItem rolesToolStripMenuItem;
        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelContenido;
    }
}
