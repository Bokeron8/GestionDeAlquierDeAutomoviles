namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class ReporteVista
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
            btnActualizar = new Button();
            lblActualizado = new Label();
            pnlContenido = new Panel();
            pnlVehiculos = new Panel();
            lblVehiculosEtiqueta = new Label();
            lblVehiculosValor = new Label();
            pnlAcentoVehiculos = new Panel();
            pnlAlquileres = new Panel();
            lblAlquileresEtiqueta = new Label();
            lblAlquileresValor = new Label();
            pnlAcentoAlquileres = new Panel();
            pnlPendientes = new Panel();
            lblPendientesEtiqueta = new Label();
            lblPendientesValor = new Label();
            pnlAcentoPendientes = new Panel();
            pnlIngresos = new Panel();
            lblIngresosEtiqueta = new Label();
            lblIngresosValor = new Label();
            pnlAcentoIngresos = new Panel();
            pnlOcupacion = new Panel();
            lblOcupacionEtiqueta = new Label();
            lblOcupacionValor = new Label();
            pnlAcentoOcupacion = new Panel();
            pnlClientes = new Panel();
            lblClientesEtiqueta = new Label();
            lblClientesValor = new Label();
            pnlAcentoClientes = new Panel();
            lblReservasTitulo = new Label();
            dgvReservas = new DataGridView();
            lblSinReservas = new Label();
            lblIngresosCategoriaTitulo = new Label();
            dgvIngresosCategoria = new DataGridView();
            lblSinIngresos = new Label();
            lblVehiculosTitulo = new Label();
            dgvVehiculos = new DataGridView();
            lblSinVehiculos = new Label();
            lblAlquileresFinalizadosTitulo = new Label();
            dgvAlquileresFinalizados = new DataGridView();
            lblSinAlquileresFinalizados = new Label();
            pnlContenido.SuspendLayout();
            pnlVehiculos.SuspendLayout();
            pnlAlquileres.SuspendLayout();
            pnlPendientes.SuspendLayout();
            pnlIngresos.SuspendLayout();
            pnlOcupacion.SuspendLayout();
            pnlClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvIngresosCategoria).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlquileresFinalizados).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(280, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Dashboard Gerente";
            //
            // btnActualizar
            //
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.BackColor = Color.FromArgb(51, 51, 76);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(740, 17);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(135, 35);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            //
            // lblActualizado
            //
            lblActualizado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblActualizado.Font = new Font("Segoe UI", 9F);
            lblActualizado.ForeColor = Color.FromArgb(90, 90, 110);
            lblActualizado.Location = new Point(500, 54);
            lblActualizado.Name = "lblActualizado";
            lblActualizado.Size = new Size(375, 18);
            lblActualizado.TabIndex = 2;
            lblActualizado.Text = "Sin datos";
            lblActualizado.TextAlign = ContentAlignment.MiddleRight;
            //
            // pnlVehiculos
            //
            pnlVehiculos.BackColor = Color.White;
            pnlVehiculos.Controls.Add(lblVehiculosEtiqueta);
            pnlVehiculos.Controls.Add(lblVehiculosValor);
            pnlVehiculos.Controls.Add(pnlAcentoVehiculos);
            pnlVehiculos.Location = new Point(25, 82);
            pnlVehiculos.Name = "pnlVehiculos";
            pnlVehiculos.Size = new Size(270, 74);
            pnlVehiculos.TabIndex = 3;
            //
            // lblVehiculosEtiqueta
            //
            lblVehiculosEtiqueta.AutoSize = true;
            lblVehiculosEtiqueta.Font = new Font("Segoe UI", 9F);
            lblVehiculosEtiqueta.ForeColor = Color.FromArgb(90, 90, 110);
            lblVehiculosEtiqueta.Location = new Point(14, 12);
            lblVehiculosEtiqueta.Name = "lblVehiculosEtiqueta";
            lblVehiculosEtiqueta.Size = new Size(100, 15);
            lblVehiculosEtiqueta.TabIndex = 1;
            lblVehiculosEtiqueta.Text = "Vehículos activos";
            //
            // lblVehiculosValor
            //
            lblVehiculosValor.AutoSize = true;
            lblVehiculosValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVehiculosValor.ForeColor = Color.FromArgb(51, 51, 76);
            lblVehiculosValor.Location = new Point(14, 32);
            lblVehiculosValor.Name = "lblVehiculosValor";
            lblVehiculosValor.Size = new Size(25, 30);
            lblVehiculosValor.TabIndex = 2;
            lblVehiculosValor.Text = "0";
            //
            // pnlAcentoVehiculos
            //
            pnlAcentoVehiculos.BackColor = Color.FromArgb(51, 51, 76);
            pnlAcentoVehiculos.Location = new Point(0, 0);
            pnlAcentoVehiculos.Name = "pnlAcentoVehiculos";
            pnlAcentoVehiculos.Size = new Size(4, 74);
            pnlAcentoVehiculos.TabIndex = 0;
            //
            // pnlAlquileres
            //
            pnlAlquileres.BackColor = Color.White;
            pnlAlquileres.Controls.Add(lblAlquileresEtiqueta);
            pnlAlquileres.Controls.Add(lblAlquileresValor);
            pnlAlquileres.Controls.Add(pnlAcentoAlquileres);
            pnlAlquileres.Location = new Point(305, 82);
            pnlAlquileres.Name = "pnlAlquileres";
            pnlAlquileres.Size = new Size(270, 74);
            pnlAlquileres.TabIndex = 4;
            //
            // lblAlquileresEtiqueta
            //
            lblAlquileresEtiqueta.AutoSize = true;
            lblAlquileresEtiqueta.Font = new Font("Segoe UI", 9F);
            lblAlquileresEtiqueta.ForeColor = Color.FromArgb(90, 90, 110);
            lblAlquileresEtiqueta.Location = new Point(14, 12);
            lblAlquileresEtiqueta.Name = "lblAlquileresEtiqueta";
            lblAlquileresEtiqueta.Size = new Size(110, 15);
            lblAlquileresEtiqueta.TabIndex = 1;
            lblAlquileresEtiqueta.Text = "Alquileres en curso";
            //
            // lblAlquileresValor
            //
            lblAlquileresValor.AutoSize = true;
            lblAlquileresValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAlquileresValor.ForeColor = Color.FromArgb(51, 51, 76);
            lblAlquileresValor.Location = new Point(14, 32);
            lblAlquileresValor.Name = "lblAlquileresValor";
            lblAlquileresValor.Size = new Size(25, 30);
            lblAlquileresValor.TabIndex = 2;
            lblAlquileresValor.Text = "0";
            //
            // pnlAcentoAlquileres
            //
            pnlAcentoAlquileres.BackColor = Color.FromArgb(51, 51, 76);
            pnlAcentoAlquileres.Location = new Point(0, 0);
            pnlAcentoAlquileres.Name = "pnlAcentoAlquileres";
            pnlAcentoAlquileres.Size = new Size(4, 74);
            pnlAcentoAlquileres.TabIndex = 0;
            //
            // pnlPendientes
            //
            pnlPendientes.BackColor = Color.White;
            pnlPendientes.Controls.Add(lblPendientesEtiqueta);
            pnlPendientes.Controls.Add(lblPendientesValor);
            pnlPendientes.Controls.Add(pnlAcentoPendientes);
            pnlPendientes.Location = new Point(585, 82);
            pnlPendientes.Name = "pnlPendientes";
            pnlPendientes.Size = new Size(270, 74);
            pnlPendientes.TabIndex = 5;
            //
            // lblPendientesEtiqueta
            //
            lblPendientesEtiqueta.AutoSize = true;
            lblPendientesEtiqueta.Font = new Font("Segoe UI", 9F);
            lblPendientesEtiqueta.ForeColor = Color.FromArgb(90, 90, 110);
            lblPendientesEtiqueta.Location = new Point(14, 12);
            lblPendientesEtiqueta.Name = "lblPendientesEtiqueta";
            lblPendientesEtiqueta.Size = new Size(115, 15);
            lblPendientesEtiqueta.TabIndex = 1;
            lblPendientesEtiqueta.Text = "Reservas pendientes";
            //
            // lblPendientesValor
            //
            lblPendientesValor.AutoSize = true;
            lblPendientesValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPendientesValor.ForeColor = Color.FromArgb(51, 51, 76);
            lblPendientesValor.Location = new Point(14, 32);
            lblPendientesValor.Name = "lblPendientesValor";
            lblPendientesValor.Size = new Size(25, 30);
            lblPendientesValor.TabIndex = 2;
            lblPendientesValor.Text = "0";
            //
            // pnlAcentoPendientes
            //
            pnlAcentoPendientes.BackColor = Color.FromArgb(51, 51, 76);
            pnlAcentoPendientes.Location = new Point(0, 0);
            pnlAcentoPendientes.Name = "pnlAcentoPendientes";
            pnlAcentoPendientes.Size = new Size(4, 74);
            pnlAcentoPendientes.TabIndex = 0;
            //
            // pnlIngresos
            //
            pnlIngresos.BackColor = Color.White;
            pnlIngresos.Controls.Add(lblIngresosEtiqueta);
            pnlIngresos.Controls.Add(lblIngresosValor);
            pnlIngresos.Controls.Add(pnlAcentoIngresos);
            pnlIngresos.Location = new Point(25, 164);
            pnlIngresos.Name = "pnlIngresos";
            pnlIngresos.Size = new Size(270, 74);
            pnlIngresos.TabIndex = 6;
            //
            // lblIngresosEtiqueta
            //
            lblIngresosEtiqueta.AutoSize = true;
            lblIngresosEtiqueta.Font = new Font("Segoe UI", 9F);
            lblIngresosEtiqueta.ForeColor = Color.FromArgb(90, 90, 110);
            lblIngresosEtiqueta.Location = new Point(14, 12);
            lblIngresosEtiqueta.Name = "lblIngresosEtiqueta";
            lblIngresosEtiqueta.Size = new Size(105, 15);
            lblIngresosEtiqueta.TabIndex = 1;
            lblIngresosEtiqueta.Text = "Ingresos del mes";
            //
            // lblIngresosValor
            //
            lblIngresosValor.AutoSize = true;
            lblIngresosValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblIngresosValor.ForeColor = Color.FromArgb(30, 110, 60);
            lblIngresosValor.Location = new Point(14, 32);
            lblIngresosValor.Name = "lblIngresosValor";
            lblIngresosValor.Size = new Size(45, 30);
            lblIngresosValor.TabIndex = 2;
            lblIngresosValor.Text = "$0";
            //
            // pnlAcentoIngresos
            //
            pnlAcentoIngresos.BackColor = Color.FromArgb(30, 110, 60);
            pnlAcentoIngresos.Location = new Point(0, 0);
            pnlAcentoIngresos.Name = "pnlAcentoIngresos";
            pnlAcentoIngresos.Size = new Size(4, 74);
            pnlAcentoIngresos.TabIndex = 0;
            //
            // pnlOcupacion
            //
            pnlOcupacion.BackColor = Color.White;
            pnlOcupacion.Controls.Add(lblOcupacionEtiqueta);
            pnlOcupacion.Controls.Add(lblOcupacionValor);
            pnlOcupacion.Controls.Add(pnlAcentoOcupacion);
            pnlOcupacion.Location = new Point(305, 164);
            pnlOcupacion.Name = "pnlOcupacion";
            pnlOcupacion.Size = new Size(270, 74);
            pnlOcupacion.TabIndex = 7;
            //
            // lblOcupacionEtiqueta
            //
            lblOcupacionEtiqueta.AutoSize = true;
            lblOcupacionEtiqueta.Font = new Font("Segoe UI", 9F);
            lblOcupacionEtiqueta.ForeColor = Color.FromArgb(90, 90, 110);
            lblOcupacionEtiqueta.Location = new Point(14, 12);
            lblOcupacionEtiqueta.Name = "lblOcupacionEtiqueta";
            lblOcupacionEtiqueta.Size = new Size(100, 15);
            lblOcupacionEtiqueta.TabIndex = 1;
            lblOcupacionEtiqueta.Text = "Ocupación de flota";
            //
            // lblOcupacionValor
            //
            lblOcupacionValor.AutoSize = true;
            lblOcupacionValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblOcupacionValor.ForeColor = Color.FromArgb(51, 51, 76);
            lblOcupacionValor.Location = new Point(14, 32);
            lblOcupacionValor.Name = "lblOcupacionValor";
            lblOcupacionValor.Size = new Size(110, 30);
            lblOcupacionValor.TabIndex = 2;
            lblOcupacionValor.Text = "0 de 0 · 0%";
            //
            // pnlAcentoOcupacion
            //
            pnlAcentoOcupacion.BackColor = Color.FromArgb(51, 51, 76);
            pnlAcentoOcupacion.Location = new Point(0, 0);
            pnlAcentoOcupacion.Name = "pnlAcentoOcupacion";
            pnlAcentoOcupacion.Size = new Size(4, 74);
            pnlAcentoOcupacion.TabIndex = 0;
            //
            // pnlClientes
            //
            pnlClientes.BackColor = Color.White;
            pnlClientes.Controls.Add(lblClientesEtiqueta);
            pnlClientes.Controls.Add(lblClientesValor);
            pnlClientes.Controls.Add(pnlAcentoClientes);
            pnlClientes.Location = new Point(585, 164);
            pnlClientes.Name = "pnlClientes";
            pnlClientes.Size = new Size(270, 74);
            pnlClientes.TabIndex = 8;
            //
            // lblClientesEtiqueta
            //
            lblClientesEtiqueta.AutoSize = true;
            lblClientesEtiqueta.Font = new Font("Segoe UI", 9F);
            lblClientesEtiqueta.ForeColor = Color.FromArgb(90, 90, 110);
            lblClientesEtiqueta.Location = new Point(14, 12);
            lblClientesEtiqueta.Name = "lblClientesEtiqueta";
            lblClientesEtiqueta.Size = new Size(90, 15);
            lblClientesEtiqueta.TabIndex = 1;
            lblClientesEtiqueta.Text = "Clientes activos";
            //
            // lblClientesValor
            //
            lblClientesValor.AutoSize = true;
            lblClientesValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblClientesValor.ForeColor = Color.FromArgb(51, 51, 76);
            lblClientesValor.Location = new Point(14, 32);
            lblClientesValor.Name = "lblClientesValor";
            lblClientesValor.Size = new Size(25, 30);
            lblClientesValor.TabIndex = 2;
            lblClientesValor.Text = "0";
            //
            // pnlAcentoClientes
            //
            pnlAcentoClientes.BackColor = Color.FromArgb(51, 51, 76);
            pnlAcentoClientes.Location = new Point(0, 0);
            pnlAcentoClientes.Name = "pnlAcentoClientes";
            pnlAcentoClientes.Size = new Size(4, 74);
            pnlAcentoClientes.TabIndex = 0;
            //
            // lblReservasTitulo
            //
            lblReservasTitulo.AutoSize = true;
            lblReservasTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblReservasTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblReservasTitulo.Location = new Point(25, 252);
            lblReservasTitulo.Name = "lblReservasTitulo";
            lblReservasTitulo.Size = new Size(130, 20);
            lblReservasTitulo.TabIndex = 9;
            lblReservasTitulo.Text = "Reservas Activas";
            //
            // dgvReservas
            //
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.BackgroundColor = Color.White;
            dgvReservas.BorderStyle = BorderStyle.None;
            dgvReservas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvReservas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvReservas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservas.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvReservas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvReservas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvReservas.EnableHeadersVisualStyles = false;
            dgvReservas.Location = new Point(25, 276);
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.RowHeadersVisible = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(850, 200);
            dgvReservas.TabIndex = 10;
            //
            // lblSinReservas
            //
            lblSinReservas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSinReservas.Font = new Font("Segoe UI", 10F);
            lblSinReservas.ForeColor = Color.FromArgb(90, 90, 110);
            lblSinReservas.Location = new Point(25, 366);
            lblSinReservas.Name = "lblSinReservas";
            lblSinReservas.Size = new Size(850, 20);
            lblSinReservas.TabIndex = 11;
            lblSinReservas.Text = "Sin reservas activas";
            lblSinReservas.TextAlign = ContentAlignment.MiddleCenter;
            lblSinReservas.Visible = false;
            //
            // lblIngresosCategoriaTitulo
            //
            lblIngresosCategoriaTitulo.AutoSize = true;
            lblIngresosCategoriaTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblIngresosCategoriaTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblIngresosCategoriaTitulo.Location = new Point(25, 490);
            lblIngresosCategoriaTitulo.Name = "lblIngresosCategoriaTitulo";
            lblIngresosCategoriaTitulo.Size = new Size(200, 20);
            lblIngresosCategoriaTitulo.TabIndex = 12;
            lblIngresosCategoriaTitulo.Text = "Ingresos por Categoría";
            //
            // dgvIngresosCategoria
            //
            dgvIngresosCategoria.AllowUserToAddRows = false;
            dgvIngresosCategoria.AllowUserToDeleteRows = false;
            dgvIngresosCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvIngresosCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngresosCategoria.BackgroundColor = Color.White;
            dgvIngresosCategoria.BorderStyle = BorderStyle.None;
            dgvIngresosCategoria.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvIngresosCategoria.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIngresosCategoria.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvIngresosCategoria.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresosCategoria.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvIngresosCategoria.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvIngresosCategoria.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvIngresosCategoria.EnableHeadersVisualStyles = false;
            dgvIngresosCategoria.Location = new Point(25, 514);
            dgvIngresosCategoria.Name = "dgvIngresosCategoria";
            dgvIngresosCategoria.ReadOnly = true;
            dgvIngresosCategoria.RowHeadersVisible = false;
            dgvIngresosCategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngresosCategoria.Size = new Size(410, 170);
            dgvIngresosCategoria.TabIndex = 13;
            //
            // lblSinIngresos
            //
            lblSinIngresos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSinIngresos.Font = new Font("Segoe UI", 10F);
            lblSinIngresos.ForeColor = Color.FromArgb(90, 90, 110);
            lblSinIngresos.Location = new Point(25, 589);
            lblSinIngresos.Name = "lblSinIngresos";
            lblSinIngresos.Size = new Size(410, 20);
            lblSinIngresos.TabIndex = 14;
            lblSinIngresos.Text = "Sin ingresos registrados en el mes";
            lblSinIngresos.TextAlign = ContentAlignment.MiddleCenter;
            lblSinIngresos.Visible = false;
            //
            // lblVehiculosTitulo
            //
            lblVehiculosTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVehiculosTitulo.AutoSize = true;
            lblVehiculosTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblVehiculosTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblVehiculosTitulo.Location = new Point(465, 490);
            lblVehiculosTitulo.Name = "lblVehiculosTitulo";
            lblVehiculosTitulo.Size = new Size(150, 20);
            lblVehiculosTitulo.TabIndex = 15;
            lblVehiculosTitulo.Text = "Vehículos Disponibles";
            //
            // dgvVehiculos
            //
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.AllowUserToDeleteRows = false;
            dgvVehiculos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.BackgroundColor = Color.White;
            dgvVehiculos.BorderStyle = BorderStyle.None;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVehiculos.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvVehiculos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvVehiculos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvVehiculos.EnableHeadersVisualStyles = false;
            dgvVehiculos.Location = new Point(465, 514);
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.Size = new Size(410, 170);
            dgvVehiculos.TabIndex = 16;
            //
            // lblSinVehiculos
            //
            lblSinVehiculos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSinVehiculos.Font = new Font("Segoe UI", 10F);
            lblSinVehiculos.ForeColor = Color.FromArgb(90, 90, 110);
            lblSinVehiculos.Location = new Point(465, 589);
            lblSinVehiculos.Name = "lblSinVehiculos";
            lblSinVehiculos.Size = new Size(410, 20);
            lblSinVehiculos.TabIndex = 17;
            lblSinVehiculos.Text = "Sin vehículos disponibles";
            lblSinVehiculos.TextAlign = ContentAlignment.MiddleCenter;
            lblSinVehiculos.Visible = false;
            //
            // lblAlquileresFinalizadosTitulo
            //
            lblAlquileresFinalizadosTitulo.AutoSize = true;
            lblAlquileresFinalizadosTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAlquileresFinalizadosTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblAlquileresFinalizadosTitulo.Location = new Point(25, 698);
            lblAlquileresFinalizadosTitulo.Name = "lblAlquileresFinalizadosTitulo";
            lblAlquileresFinalizadosTitulo.Size = new Size(230, 20);
            lblAlquileresFinalizadosTitulo.TabIndex = 18;
            lblAlquileresFinalizadosTitulo.Text = "Alquileres Finalizados Recientes";
            //
            // dgvAlquileresFinalizados
            //
            dgvAlquileresFinalizados.AllowUserToAddRows = false;
            dgvAlquileresFinalizados.AllowUserToDeleteRows = false;
            dgvAlquileresFinalizados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvAlquileresFinalizados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlquileresFinalizados.BackgroundColor = Color.White;
            dgvAlquileresFinalizados.BorderStyle = BorderStyle.None;
            dgvAlquileresFinalizados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvAlquileresFinalizados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAlquileresFinalizados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAlquileresFinalizados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAlquileresFinalizados.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvAlquileresFinalizados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvAlquileresFinalizados.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAlquileresFinalizados.EnableHeadersVisualStyles = false;
            dgvAlquileresFinalizados.Location = new Point(25, 722);
            dgvAlquileresFinalizados.Name = "dgvAlquileresFinalizados";
            dgvAlquileresFinalizados.ReadOnly = true;
            dgvAlquileresFinalizados.RowHeadersVisible = false;
            dgvAlquileresFinalizados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlquileresFinalizados.Size = new Size(850, 180);
            dgvAlquileresFinalizados.TabIndex = 19;
            //
            // lblSinAlquileresFinalizados
            //
            lblSinAlquileresFinalizados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSinAlquileresFinalizados.Font = new Font("Segoe UI", 10F);
            lblSinAlquileresFinalizados.ForeColor = Color.FromArgb(90, 90, 110);
            lblSinAlquileresFinalizados.Location = new Point(25, 802);
            lblSinAlquileresFinalizados.Name = "lblSinAlquileresFinalizados";
            lblSinAlquileresFinalizados.Size = new Size(850, 20);
            lblSinAlquileresFinalizados.TabIndex = 20;
            lblSinAlquileresFinalizados.Text = "Sin alquileres finalizados en el mes";
            lblSinAlquileresFinalizados.TextAlign = ContentAlignment.MiddleCenter;
            lblSinAlquileresFinalizados.Visible = false;
            //
            // pnlContenido
            //
            pnlContenido.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlContenido.BackColor = Color.FromArgb(240, 240, 245);
            pnlContenido.Controls.Add(lblTitulo);
            pnlContenido.Controls.Add(btnActualizar);
            pnlContenido.Controls.Add(lblActualizado);
            pnlContenido.Controls.Add(pnlVehiculos);
            pnlContenido.Controls.Add(pnlAlquileres);
            pnlContenido.Controls.Add(pnlPendientes);
            pnlContenido.Controls.Add(pnlIngresos);
            pnlContenido.Controls.Add(pnlOcupacion);
            pnlContenido.Controls.Add(pnlClientes);
            pnlContenido.Controls.Add(lblReservasTitulo);
            pnlContenido.Controls.Add(dgvReservas);
            pnlContenido.Controls.Add(lblSinReservas);
            pnlContenido.Controls.Add(lblIngresosCategoriaTitulo);
            pnlContenido.Controls.Add(dgvIngresosCategoria);
            pnlContenido.Controls.Add(lblSinIngresos);
            pnlContenido.Controls.Add(lblVehiculosTitulo);
            pnlContenido.Controls.Add(dgvVehiculos);
            pnlContenido.Controls.Add(lblSinVehiculos);
            pnlContenido.Controls.Add(lblAlquileresFinalizadosTitulo);
            pnlContenido.Controls.Add(dgvAlquileresFinalizados);
            pnlContenido.Controls.Add(lblSinAlquileresFinalizados);
            pnlContenido.Location = new Point(0, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.MinimumSize = new Size(875, 926);
            pnlContenido.Size = new Size(900, 926);
            pnlContenido.TabIndex = 0;
            //
            // ReporteVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(pnlContenido);
            MinimumSize = new Size(300, 240);
            Name = "ReporteVista";
            Size = new Size(900, 926);
            pnlVehiculos.ResumeLayout(false);
            pnlVehiculos.PerformLayout();
            pnlAlquileres.ResumeLayout(false);
            pnlAlquileres.PerformLayout();
            pnlPendientes.ResumeLayout(false);
            pnlPendientes.PerformLayout();
            pnlIngresos.ResumeLayout(false);
            pnlIngresos.PerformLayout();
            pnlOcupacion.ResumeLayout(false);
            pnlOcupacion.PerformLayout();
            pnlClientes.ResumeLayout(false);
            pnlClientes.PerformLayout();
            pnlContenido.ResumeLayout(false);
            pnlContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvIngresosCategoria).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlquileresFinalizados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnActualizar;
        private Label lblActualizado;
        private Panel pnlContenido;
        private Panel pnlVehiculos;
        private Label lblVehiculosEtiqueta;
        private Label lblVehiculosValor;
        private Panel pnlAcentoVehiculos;
        private Panel pnlAlquileres;
        private Label lblAlquileresEtiqueta;
        private Label lblAlquileresValor;
        private Panel pnlAcentoAlquileres;
        private Panel pnlPendientes;
        private Label lblPendientesEtiqueta;
        private Label lblPendientesValor;
        private Panel pnlAcentoPendientes;
        private Panel pnlIngresos;
        private Label lblIngresosEtiqueta;
        private Label lblIngresosValor;
        private Panel pnlAcentoIngresos;
        private Panel pnlOcupacion;
        private Label lblOcupacionEtiqueta;
        private Label lblOcupacionValor;
        private Panel pnlAcentoOcupacion;
        private Panel pnlClientes;
        private Label lblClientesEtiqueta;
        private Label lblClientesValor;
        private Panel pnlAcentoClientes;
        private Label lblReservasTitulo;
        private DataGridView dgvReservas;
        private Label lblSinReservas;
        private Label lblIngresosCategoriaTitulo;
        private DataGridView dgvIngresosCategoria;
        private Label lblSinIngresos;
        private Label lblVehiculosTitulo;
        private DataGridView dgvVehiculos;
        private Label lblSinVehiculos;
        private Label lblAlquileresFinalizadosTitulo;
        private DataGridView dgvAlquileresFinalizados;
        private Label lblSinAlquileresFinalizados;
    }
}
