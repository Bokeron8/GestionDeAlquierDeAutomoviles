using System;
using System.Linq;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaAlquilerVista : UserControl
    {
        private readonly AlquilerController _controller = new();

        public ListaAlquilerVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnDevolucion.Click += btnDevolucion_Click;
            dgvAlquileres.SelectionChanged += (_, _) => ActualizarBotones();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaAlquiler.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaAlquiler);
        }

        public void Refrescar()
        {
            string termino = txtBuscar.Text.Trim();
            var lista = _controller.Listar();
            if (!string.IsNullOrEmpty(termino))
            {
                lista = lista.Where(a =>
                    a.IdAlquiler.ToString().Contains(termino) ||
                    a.IdReserva.ToString().Contains(termino)).ToList();
            }
            dgvAlquileres.DataSource = null;
            dgvAlquileres.DataSource = lista;

            if (dgvAlquileres.Columns["IdAlquiler"] != null)
            {
                dgvAlquileres.Columns["IdAlquiler"].HeaderText = "ID";
                dgvAlquileres.Columns["IdAlquiler"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAlquileres.Columns["IdAlquiler"].Width = 50;
            }
            if (dgvAlquileres.Columns["FechaEntregaReal"] != null)
                dgvAlquileres.Columns["FechaEntregaReal"].HeaderText = "F. Entrega";
            if (dgvAlquileres.Columns["FechaEntregaDevolucion"] != null)
                dgvAlquileres.Columns["FechaEntregaDevolucion"].HeaderText = "F. Devolución";
            if (dgvAlquileres.Columns["CombustibleSalida"] != null)
                dgvAlquileres.Columns["CombustibleSalida"].HeaderText = "Comb. Salida";
            if (dgvAlquileres.Columns["CombustibleEntrada"] != null)
                dgvAlquileres.Columns["CombustibleEntrada"].HeaderText = "Comb. Entrada";
            if (dgvAlquileres.Columns["KilometrajeSalida"] != null)
                dgvAlquileres.Columns["KilometrajeSalida"].HeaderText = "Km. Salida";
            if (dgvAlquileres.Columns["KilometrajeEntrada"] != null)
                dgvAlquileres.Columns["KilometrajeEntrada"].HeaderText = "Km. Entrada";
            if (dgvAlquileres.Columns["MontoMora"] != null)
                dgvAlquileres.Columns["MontoMora"].HeaderText = "Mora";
            if (dgvAlquileres.Columns["Estado"] != null)
            {
                dgvAlquileres.Columns["Estado"].HeaderText = "Estado";
                dgvAlquileres.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAlquileres.Columns["Estado"].Width = 90;
            }
            if (dgvAlquileres.Columns["Activo"] != null)
                dgvAlquileres.Columns["Activo"].Visible = false;
            if (dgvAlquileres.Columns["IdReserva"] != null)
                dgvAlquileres.Columns["IdReserva"].HeaderText = "ID Reserva";

            ActualizarBotones();
        }

        /// <summary>
        /// The return action only exists for a rental that is still out; after the return
        /// the row is history, so the button goes dark instead of failing on click.
        /// </summary>
        private void ActualizarBotones()
        {
            bool activo = FilaActiva();
            btnDevolucion.Enabled = activo;
            btnEditar.Enabled = dgvAlquileres.CurrentRow != null;
        }

        private bool FilaActiva()
        {
            if (dgvAlquileres.CurrentRow == null) return false;
            var celda = dgvAlquileres.CurrentRow.Cells["Activo"];
            return celda.Value != null && Convert.ToBoolean(celda.Value);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAlquileres.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un alquiler para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvAlquileres.CurrentRow.Cells["IdAlquiler"].Value);
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionAlquiler(id);
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            if (dgvAlquileres.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un alquiler para registrar la devolución", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvAlquileres.CurrentRow.Cells["IdAlquiler"].Value);
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarDevolucion(id);
        }
    }
}
