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
            btnConfirmar.Click += btnConfirmar_Click;
            dgvReservas.SelectionChanged += (_, _) => ActualizarBotones();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaReserva.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaReserva);
        }

        public void Refrescar()
        {
            string termino = FiltroBusqueda.Normalizar(txtBuscar.Text);
            var lista = _controller.Listar();
            if (termino.Length > 0)
            {
                lista = lista.Where(r =>
                    r.IdReserva.ToString().Contains(termino) ||
                    FiltroBusqueda.Contiene(r.NombreCliente, termino) ||
                    FiltroBusqueda.Contiene(r.DniCliente, termino) ||
                    FiltroBusqueda.Contiene(r.MatriculaVehiculo, termino)).ToList();
            }

            dgvReservas.DataSource = null;
            dgvReservas.DataSource = lista;

            if (dgvReservas.Columns["IdReserva"] != null)
            {
                dgvReservas.Columns["IdReserva"].HeaderText = "ID";
                dgvReservas.Columns["IdReserva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvReservas.Columns["IdReserva"].Width = 50;
            }
            if (dgvReservas.Columns["NombreEstado"] != null)
            {
                dgvReservas.Columns["NombreEstado"].HeaderText = "Estado";
                dgvReservas.Columns["NombreEstado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvReservas.Columns["NombreEstado"].Width = 110;
            }
            if (dgvReservas.Columns["NombreCliente"] != null)
                dgvReservas.Columns["NombreCliente"].HeaderText = "Cliente";
            if (dgvReservas.Columns["MatriculaVehiculo"] != null)
                dgvReservas.Columns["MatriculaVehiculo"].HeaderText = "Vehículo";
            if (dgvReservas.Columns["FechaInicioReserva"] != null)
                dgvReservas.Columns["FechaInicioReserva"].HeaderText = "F. Inicio";
            if (dgvReservas.Columns["FechaFinReserva"] != null)
                dgvReservas.Columns["FechaFinReserva"].HeaderText = "F. Fin";
            if (dgvReservas.Columns["PrecioDiarioPactado"] != null)
                dgvReservas.Columns["PrecioDiarioPactado"].HeaderText = "Precio Diario";
            if (dgvReservas.Columns["NombreEmpleado"] != null)
                dgvReservas.Columns["NombreEmpleado"].HeaderText = "Empleado";

            // The related ids stay in the grid because the row actions read them, but the
            // operator never needs to see them: the resolved columns say it better.
            string[] ocultas =
            [
                "FechaSolicitud", "IdCliente", "IdVehiculo", "IdEmpleado", "IdEstado", "Activo",
                "DniCliente", "DescripcionCliente", "DescripcionCombo"
            ];
            foreach (string columna in ocultas)
            {
                if (dgvReservas.Columns[columna] != null)
                    dgvReservas.Columns[columna].Visible = false;
            }

            OrdenarColumnas();

            ActualizarBotones();
        }

        private void OrdenarColumnas()
        {
            string[] orden =
            [
                "IdReserva", "NombreEstado", "NombreCliente", "MatriculaVehiculo",
                "FechaInicioReserva", "FechaFinReserva", "PrecioDiarioPactado", "NombreEmpleado"
            ];
            for (int i = 0; i < orden.Length; i++)
            {
                if (dgvReservas.Columns[orden[i]] != null)
                    dgvReservas.Columns[orden[i]].DisplayIndex = i;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Refrescar();
        }

        /// <summary>
        /// The available actions are a function of the row state, so the buttons reflect the
        /// state machine instead of failing after the click.
        /// </summary>
        private void ActualizarBotones()
        {
            int estado = EstadoFila();
            bool hayFila = dgvReservas.CurrentRow != null;
            bool editable = hayFila && ReservaController.EsEditable(estado);

            btnConfirmar.Enabled = hayFila && estado == EstadosReserva.Pendiente;
            btnEditar.Enabled = editable;
            btnEliminar.Enabled = editable;
        }

        private int EstadoFila()
        {
            if (dgvReservas.CurrentRow == null) return 0;
            var celda = dgvReservas.CurrentRow.Cells["IdEstado"];
            return celda.Value == null ? 0 : Convert.ToInt32(celda.Value);
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva para confirmar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvReservas.CurrentRow.Cells["IdReserva"].Value);
            var errores = _controller.Confirmar(id);
            if (errores.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errores), "No se pudo confirmar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Refrescar();
                return;
            }

            MessageBox.Show($"La reserva #{id} quedó confirmada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva para dar de baja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvReservas.CurrentRow.Cells["IdReserva"].Value);

            var result = MessageBox.Show(
                $"¿Desea dar de baja la reserva #{id}?",
                "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            var errores = _controller.Cancelar(id);
            if (errores.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errores), "No se pudo dar de baja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Refrescar();
        }
    }
}
