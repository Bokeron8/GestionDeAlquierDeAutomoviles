using System;
using System.Windows.Forms;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    partial class ListaModeloVista
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
            dgvModelos = new DataGridView();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            cbMarcaFiltro = new ComboBox();
            lblFiltroMarca = new Label();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvModelos).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(51, 51, 76);
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(150, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listado de Modelos";
            //
            // dgvModelos
            //
            dgvModelos.AllowUserToAddRows = false;
            dgvModelos.AllowUserToDeleteRows = false;
            dgvModelos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvModelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvModelos.BackgroundColor = Color.White;
            dgvModelos.BorderStyle = BorderStyle.None;
            dgvModelos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvModelos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvModelos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvModelos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvModelos.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvModelos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 220);
            dgvModelos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvModelos.EnableHeadersVisualStyles = false;
            dgvModelos.Location = new Point(25, 95);
            dgvModelos.Name = "dgvModelos";
            dgvModelos.ReadOnly = true;
            dgvModelos.RowHeadersVisible = false;
            dgvModelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvModelos.Size = new Size(700, 285);
            dgvModelos.TabIndex = 1;
            //
            // btnAgregar
            //
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAgregar.BackColor = Color.FromArgb(51, 51, 76);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(25, 395);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(130, 35);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            //
            // btnEditar
            //
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditar.BackColor = Color.FromArgb(51, 51, 76);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(170, 395);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(130, 35);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            //
            // btnEliminar
            //
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEliminar.BackColor = Color.FromArgb(180, 40, 40);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(315, 395);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 35);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.Location = new Point(400, 22);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por modelo, marca o ID...";
            txtBuscar.Size = new Size(325, 25);
            txtBuscar.TabIndex = 7;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            //
            // ListaModeloVista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(240, 240, 245);
            Controls.Add(lblTitulo);
            Controls.Add(dgvModelos);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(txtBuscar);
            Name = "ListaModeloVista";
            MinimumSize = new Size(750, 450);
            Size = new Size(750, 450);
            ((System.ComponentModel.ISupportInitialize)dgvModelos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvModelos;
        private Button btnEditar;
        private Button btnAgregar;
        private Button btnEliminar;
        private TextBox txtBuscar;
    }
}