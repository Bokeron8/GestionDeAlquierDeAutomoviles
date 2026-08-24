namespace GestionDeAlquierDeAutomoviles
{
    partial class CargaVehiculoVista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LMatricula = new Label();
            LAnio = new Label();
            TBMatricula = new TextBox();
            TBAnio = new TextBox();
            BGuardarVehiculo = new Button();
            CBModelo = new ComboBox();
            CBCategoria = new ComboBox();
            LModelo = new Label();
            LCategoria = new Label();
            SuspendLayout();
            // 
            // LMatricula
            // 
            LMatricula.AutoSize = true;
            LMatricula.Location = new Point(61, 52);
            LMatricula.Name = "LMatricula";
            LMatricula.Size = new Size(57, 15);
            LMatricula.TabIndex = 0;
            LMatricula.Text = "Matricula";
            // 
            // LAnio
            // 
            LAnio.AutoSize = true;
            LAnio.Location = new Point(61, 112);
            LAnio.Name = "LAnio";
            LAnio.Size = new Size(29, 15);
            LAnio.TabIndex = 1;
            LAnio.Text = "Año";
            // 
            // TBMatricula
            // 
            TBMatricula.Location = new Point(139, 52);
            TBMatricula.Name = "TBMatricula";
            TBMatricula.Size = new Size(100, 23);
            TBMatricula.TabIndex = 2;
            // 
            // TBAnio
            // 
            TBAnio.Location = new Point(139, 109);
            TBAnio.Name = "TBAnio";
            TBAnio.Size = new Size(100, 23);
            TBAnio.TabIndex = 3;
            // 
            // BGuardarVehiculo
            // 
            BGuardarVehiculo.Location = new Point(224, 245);
            BGuardarVehiculo.Name = "BGuardarVehiculo";
            BGuardarVehiculo.Size = new Size(253, 65);
            BGuardarVehiculo.TabIndex = 4;
            BGuardarVehiculo.Text = "Guardar nuevo vehiculo";
            BGuardarVehiculo.UseVisualStyleBackColor = true;
            BGuardarVehiculo.Click += BGuardarVehiculo_Click;
            // 
            // CBModelo
            // 
            CBModelo.FormattingEnabled = true;
            CBModelo.Location = new Point(428, 52);
            CBModelo.Name = "CBModelo";
            CBModelo.Size = new Size(121, 23);
            CBModelo.TabIndex = 5;
            // 
            // CBCategoria
            // 
            CBCategoria.FormattingEnabled = true;
            CBCategoria.Location = new Point(428, 104);
            CBCategoria.Name = "CBCategoria";
            CBCategoria.Size = new Size(121, 23);
            CBCategoria.TabIndex = 6;
            // 
            // LModelo
            // 
            LModelo.AutoSize = true;
            LModelo.Location = new Point(338, 52);
            LModelo.Name = "LModelo";
            LModelo.Size = new Size(48, 15);
            LModelo.TabIndex = 7;
            LModelo.Text = "Modelo";
            // 
            // LCategoria
            // 
            LCategoria.AutoSize = true;
            LCategoria.Location = new Point(338, 109);
            LCategoria.Name = "LCategoria";
            LCategoria.Size = new Size(58, 15);
            LCategoria.TabIndex = 8;
            LCategoria.Text = "Categoria";
            // 
            // CargaVehiculoVista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 411);
            Controls.Add(LCategoria);
            Controls.Add(LModelo);
            Controls.Add(CBCategoria);
            Controls.Add(CBModelo);
            Controls.Add(BGuardarVehiculo);
            Controls.Add(TBAnio);
            Controls.Add(TBMatricula);
            Controls.Add(LAnio);
            Controls.Add(LMatricula);
            Name = "CargaVehiculoVista";
            Text = "CargaVehiculoVista";
            Load += CargaVehiculoVista_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LMatricula;
        private Label LAnio;
        private TextBox TBMatricula;
        private TextBox TBAnio;
        private Button BGuardarVehiculo;
        private ComboBox CBModelo;
        private ComboBox CBCategoria;
        private Label LModelo;
        private Label LCategoria;
    }
}