using System;
using System.Linq;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaReservaVista : UserControl
    {
        private readonly ReservaController _controller = new();

        public ListaReservaVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaReserva.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaReserva);
        }

        public void Refrescar()
        {
            var lista = _controller.Listar();
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = lista;

            if (dgvReservas.Columns["IdReserva"] != null)
            {
                dgvReservas.Columns["IdReserva"].HeaderText = "ID";
                dgvReservas.Columns["IdReserva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvReservas.Columns["IdReserva"].Width = 50;
            }
            if (dgvReservas.Columns["PrecioDiarioPactado"] != null)
                dgvReservas.Columns["PrecioDiarioPactado"].HeaderText = "Precio Diario";
            if (dgvReservas.Columns["FechaSolicitud"] != null)
                dgvReservas.Columns["FechaSolicitud"].HeaderText = "F. Solicitud";
            if (dgvReservas.Columns["FechaInicioReserva"] != null)
                dgvReservas.Columns["FechaInicioReserva"].HeaderText = "F. Inicio";
            if (dgvReservas.Columns["FechaFinReserva"] != null)
                dgvReservas.Columns["FechaFinReserva"].HeaderText = "F. Fin";
            if (dgvReservas.Columns["IdCliente"] != null)
                dgvReservas.Columns["IdCliente"].HeaderText = "ID Cliente";
            if (dgvReservas.Columns["IdVehiculo"] != null)
                dgvReservas.Columns["IdVehiculo"].HeaderText = "ID Vehículo";
            if (dgvReservas.Columns["IdEmpleado"] != null)
                dgvReservas.Columns["IdEmpleado"].HeaderText = "ID Empleado";
            if (dgvReservas.Columns["IdEstado"] != null)
                dgvReservas.Columns["IdEstado"].HeaderText = "ID Estado";
            if (dgvReservas.Columns["Activo"] != null)
            {
                dgvReservas.Columns["Activo"].HeaderText = "Activo";
                dgvReservas.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvReservas.Columns["Activo"].Width = 60;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvReservas.CurrentRow.Cells["IdReserva"].Value);
            var res = _controller.BuscarPorId(id);
            if (res == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionReserva(res);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva para dar de baja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvReservas.CurrentRow.Cells["IdReserva"].Value);
            bool activo = Convert.ToBoolean(dgvReservas.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja la reserva #{id}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _controller.Eliminar(id);
                    Refrescar();
                }
            }
            else
            {
                MessageBox.Show($"La reserva #{id} ya se encuentra inactiva.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
