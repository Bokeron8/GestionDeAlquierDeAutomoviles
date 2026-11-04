namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class InicioVista
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
            lblBienvenida = new Label();
            lblRol = new Label();
            lblAccesos = new Label();
            panelAccesos = new FlowLayoutPanel();
            lblPista = new Label();
            SuspendLayout();
            //
            // lblBienvenida
            //
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(51, 51, 76);
            lblBienvenida.Location = new Point(40, 36);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(220, 32);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido";
            //
            // lblRol
            //
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 10F);
            lblRol.ForeColor = Color.FromArgb(90, 90, 110);
            lblRol.Location = new Point(42, 76);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(60, 19);
            lblRol.TabIndex = 1;
            lblRol.Text = "Rol:";
            //
            // lblAccesos
            //
            lblAccesos.AutoSize = true;
            lblAccesos.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAccesos.ForeColor = Color.FromArgb(51, 51, 76);
            lblAccesos.Location = new Point(40, 118);
            lblAccesos.Name = "lblAccesos";
            lblAccesos.Size = new Size(140, 20);
            lblAccesos.TabIndex = 2;
            lblAccesos.Text = "Accesos rápidos";
            //
            // panelAccesos
            //
            panelAccesos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelAccesos.AutoScroll = true;
            panelAccesos.Location = new Point(40, 150);
            panelAccesos.Name = "panelAccesos";
            panelAccesos.Size = new Size(820, 220);
            panelAccesos.TabIndex = 3;
            //
            // lblPista
            //
            lblPista.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPista.AutoSize = true;
            lblPista.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblPista.ForeColor = Color.FromArgb(120, 120, 140);
            lblPista.Location = new Point(42, 392);
            lblPista.Name = "lblPista";
            lblPista.Size = new Size(340, 15);
            lblPista.TabIndex = 4;
            lblPista.Text = "Usá el menú superior para el resto de las secciones.";
            //
            // InicioVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblBienvenida);
            Controls.Add(lblRol);
            Controls.Add(lblAccesos);
            Controls.Add(panelAccesos);
            Controls.Add(lblPista);
            MinimumSize = new Size(750, 450);
            Name = "InicioVista";
            Size = new Size(900, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
        private Label lblRol;
        private Label lblAccesos;
        private FlowLayoutPanel panelAccesos;
        private Label lblPista;
    }
}
