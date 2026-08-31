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
            cargarVehiculoToolStripMenuItem = new ToolStripMenuItem();
            listarVehiculosToolStripMenuItem = new ToolStripMenuItem();
            marcasToolStripMenuItem = new ToolStripMenuItem();
            cargarMarcaToolStripMenuItem = new ToolStripMenuItem();
            listarMarcasToolStripMenuItem = new ToolStripMenuItem();
            modelosToolStripMenuItem = new ToolStripMenuItem();
            cargarModeloToolStripMenuItem = new ToolStripMenuItem();
            listarModelosToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            cargarCategoriaToolStripMenuItem = new ToolStripMenuItem();
            listarCategoriasToolStripMenuItem = new ToolStripMenuItem();
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
            menuStrip.Items.AddRange(new ToolStripItem[] { vehiculosToolStripMenuItem, marcasToolStripMenuItem, modelosToolStripMenuItem, categoriasToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(900, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            //
            // vehiculosToolStripMenuItem
            //
            vehiculosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cargarVehiculoToolStripMenuItem, listarVehiculosToolStripMenuItem });
            vehiculosToolStripMenuItem.ForeColor = Color.White;
            vehiculosToolStripMenuItem.Name = "vehiculosToolStripMenuItem";
            vehiculosToolStripMenuItem.Size = new Size(78, 20);
            vehiculosToolStripMenuItem.Text = "Vehiculos";
            //
            // cargarVehiculoToolStripMenuItem
            //
            cargarVehiculoToolStripMenuItem.Name = "cargarVehiculoToolStripMenuItem";
            cargarVehiculoToolStripMenuItem.Size = new Size(170, 22);
            cargarVehiculoToolStripMenuItem.Text = "Cargar Vehiculo";
            cargarVehiculoToolStripMenuItem.Click += CargarVehiculoToolStripMenuItem_Click;
            //
            // listarVehiculosToolStripMenuItem
            //
            listarVehiculosToolStripMenuItem.Name = "listarVehiculosToolStripMenuItem";
            listarVehiculosToolStripMenuItem.Size = new Size(170, 22);
            listarVehiculosToolStripMenuItem.Text = "Listar Vehiculos";
            listarVehiculosToolStripMenuItem.Click += ListarVehiculosToolStripMenuItem_Click;
            //
            // marcasToolStripMenuItem
            //
            marcasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cargarMarcaToolStripMenuItem, listarMarcasToolStripMenuItem });
            marcasToolStripMenuItem.ForeColor = Color.White;
            marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            marcasToolStripMenuItem.Size = new Size(57, 20);
            marcasToolStripMenuItem.Text = "Marcas";
            //
            // cargarMarcaToolStripMenuItem
            //
            cargarMarcaToolStripMenuItem.Name = "cargarMarcaToolStripMenuItem";
            cargarMarcaToolStripMenuItem.Size = new Size(152, 22);
            cargarMarcaToolStripMenuItem.Text = "Cargar Marca";
            cargarMarcaToolStripMenuItem.Click += CargarMarcaToolStripMenuItem_Click;
            //
            // listarMarcasToolStripMenuItem
            //
            listarMarcasToolStripMenuItem.Name = "listarMarcasToolStripMenuItem";
            listarMarcasToolStripMenuItem.Size = new Size(152, 22);
            listarMarcasToolStripMenuItem.Text = "Listar Marcas";
            listarMarcasToolStripMenuItem.Click += ListarMarcasToolStripMenuItem_Click;
            //
            // modelosToolStripMenuItem
            //
            modelosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cargarModeloToolStripMenuItem, listarModelosToolStripMenuItem });
            modelosToolStripMenuItem.ForeColor = Color.White;
            modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
            modelosToolStripMenuItem.Size = new Size(66, 20);
            modelosToolStripMenuItem.Text = "Modelos";
            //
            // cargarModeloToolStripMenuItem
            //
            cargarModeloToolStripMenuItem.Name = "cargarModeloToolStripMenuItem";
            cargarModeloToolStripMenuItem.Size = new Size(160, 22);
            cargarModeloToolStripMenuItem.Text = "Cargar Modelo";
            cargarModeloToolStripMenuItem.Click += CargarModeloToolStripMenuItem_Click;
            //
            // listarModelosToolStripMenuItem
            //
            listarModelosToolStripMenuItem.Name = "listarModelosToolStripMenuItem";
            listarModelosToolStripMenuItem.Size = new Size(160, 22);
            listarModelosToolStripMenuItem.Text = "Listar Modelos";
            listarModelosToolStripMenuItem.Click += ListarModelosToolStripMenuItem_Click;
            //
            // categoriasToolStripMenuItem
            //
            categoriasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cargarCategoriaToolStripMenuItem, listarCategoriasToolStripMenuItem });
            categoriasToolStripMenuItem.ForeColor = Color.White;
            categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            categoriasToolStripMenuItem.Size = new Size(80, 20);
            categoriasToolStripMenuItem.Text = "Categorias";
            //
            // cargarCategoriaToolStripMenuItem
            //
            cargarCategoriaToolStripMenuItem.Name = "cargarCategoriaToolStripMenuItem";
            cargarCategoriaToolStripMenuItem.Size = new Size(172, 22);
            cargarCategoriaToolStripMenuItem.Text = "Cargar Categoria";
            cargarCategoriaToolStripMenuItem.Click += CargarCategoriaToolStripMenuItem_Click;
            //
            // listarCategoriasToolStripMenuItem
            //
            listarCategoriasToolStripMenuItem.Name = "listarCategoriasToolStripMenuItem";
            listarCategoriasToolStripMenuItem.Size = new Size(172, 22);
            listarCategoriasToolStripMenuItem.Text = "Listar Categorias";
            listarCategoriasToolStripMenuItem.Click += ListarCategoriasToolStripMenuItem_Click;
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
        private ToolStripMenuItem cargarVehiculoToolStripMenuItem;
        private ToolStripMenuItem listarVehiculosToolStripMenuItem;
        private ToolStripMenuItem marcasToolStripMenuItem;
        private ToolStripMenuItem cargarMarcaToolStripMenuItem;
        private ToolStripMenuItem listarMarcasToolStripMenuItem;
        private ToolStripMenuItem modelosToolStripMenuItem;
        private ToolStripMenuItem cargarModeloToolStripMenuItem;
        private ToolStripMenuItem listarModelosToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem cargarCategoriaToolStripMenuItem;
        private ToolStripMenuItem listarCategoriasToolStripMenuItem;
        private Panel panelHeader;
        private Label lblTitulo;
        private Panel panelContenido;
    }
}
