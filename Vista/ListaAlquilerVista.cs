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
            string termino = FiltroBusqueda.Normalizar(txtBuscar.Text);
            var lista = _controller.Listar();
            if (termino.Length > 0)
            {
                lista = lista.Where(a =>
                    a.IdAlquiler.ToString().Contains(termino) ||
                    a.IdReserva.ToString().Contains(termino) ||
                    FiltroBusqueda.Contiene(a.NombreCliente, termino) ||
                    FiltroBusqueda.Contiene(a.DniCliente, termino) ||
                    FiltroBusqueda.Contiene(a.MatriculaVehiculo, termino)).ToList();
            }
            dgvAlquileres.DataSource = null;
            dgvAlquileres.DataSource = lista;

            if (dgvAlquileres.Columns["IdAlquiler"] != null)
            {
                dgvAlquileres.Columns["IdAlquiler"].HeaderText = "ID";
                dgvAlquileres.Columns["IdAlquiler"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAlquileres.Columns["IdAlquiler"].Width = 50;
            }
            if (dgvAlquileres.Columns["Estado"] != null)
            {
                dgvAlquileres.Columns["Estado"].HeaderText = "Estado";
                dgvAlquileres.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvAlquileres.Columns["Estado"].Width = 90;
            }
            if (dgvAlquileres.Columns["NombreCliente"] != null)
                dgvAlquileres.Columns["NombreCliente"].HeaderText = "Cliente";
            if (dgvAlquileres.Columns["MatriculaVehiculo"] != null)
                dgvAlquileres.Columns["MatriculaVehiculo"].HeaderText = "Vehículo";
            if (dgvAlquileres.Columns["IdReserva"] != null)
                dgvAlquileres.Columns["IdReserva"].HeaderText = "Reserva";
            if (dgvAlquileres.Columns["FechaEntregaReal"] != null)
                dgvAlquileres.Columns["FechaEntregaReal"].HeaderText = "F. Entrega";
            if (dgvAlquileres.Columns["FechaEntregaDevolucion"] != null)
                dgvAlquileres.Columns["FechaEntregaDevolucion"].HeaderText = "F. Devolución";
            if (dgvAlquileres.Columns["MontoMora"] != null)
                dgvAlquileres.Columns["MontoMora"].HeaderText = "Mora";

            // Fuel and mileage at delivery/return live in the return screen; keeping them
            // here only pushed the client and the vehicle out of the operator's view.
            string[] ocultas =
            [
                "CombustibleSalida", "CombustibleEntrada", "KilometrajeSalida", "KilometrajeEntrada",
                "Activo", "DniCliente", "DescripcionCliente"
            ];
            foreach (string columna in ocultas)
            {
                if (dgvAlquileres.Columns[columna] != null)
                    dgvAlquileres.Columns[columna].Visible = false;
            }

            OrdenarColumnas();

            ActualizarBotones();
        }

        private void OrdenarColumnas()
        {
            string[] orden =
            [
                "IdAlquiler", "Estado", "NombreCliente", "MatriculaVehiculo", "IdReserva",
                "FechaEntregaReal", "FechaEntregaDevolucion", "MontoMora"
            ];
            for (int i = 0; i < orden.Length; i++)
            {
                if (dgvAlquileres.Columns[orden[i]] != null)
                    dgvAlquileres.Columns[orden[i]].DisplayIndex = i;
            }
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
