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
            Load += ListaAlquilerVista_Load;
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void ListaAlquilerVista_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaAlquiler.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaAlquiler);
        }

        private void CargarDatos()
        {
            var lista = _controller.Listar();
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
            if (dgvAlquileres.Columns["Activo"] != null)
            {
                dgvAlquileres.Columns["Activo"].HeaderText = "Activo";
                dgvAlquileres.Columns["Activo"].Width = 60;
            }
            if (dgvAlquileres.Columns["IdReserva"] != null)
                dgvAlquileres.Columns["IdReserva"].HeaderText = "ID Reserva";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
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
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAlquileres.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un alquiler para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvAlquileres.CurrentRow.Cells["IdAlquiler"].Value);
            var alq = _controller.BuscarPorId(id);
            if (alq == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionAlquiler(id);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlquileres.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un alquiler para dar de baja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvAlquileres.CurrentRow.Cells["IdAlquiler"].Value);
            bool activo = Convert.ToBoolean(dgvAlquileres.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja el alquiler #{id}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _controller.Eliminar(id);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show($"El alquiler #{id} ya se encuentra inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
