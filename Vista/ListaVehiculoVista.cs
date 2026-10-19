using System;
using System.Linq;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaVehiculoVista : UserControl
    {
        private readonly VehiculoController _controller = new();

        public ListaVehiculoVista()
        {
            InitializeComponent();
            Load += ListaVehiculoVista_Load;
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void ListaVehiculoVista_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaVehiculo.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaVehiculo);
        }

        private void CargarDatos()
        {
            var lista = _controller.Listar();
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = lista;

            if (dgvVehiculos.Columns["IdVehiculo"] != null)
            {
                dgvVehiculos.Columns["IdVehiculo"].HeaderText = "ID";
                dgvVehiculos.Columns["IdVehiculo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvVehiculos.Columns["IdVehiculo"].Width = 50;
            }
            if (dgvVehiculos.Columns["Matricula"] != null)
                dgvVehiculos.Columns["Matricula"].HeaderText = "Matrícula";
            if (dgvVehiculos.Columns["Chasis"] != null)
                dgvVehiculos.Columns["Chasis"].HeaderText = "Chasis";
            if (dgvVehiculos.Columns["Color"] != null)
                dgvVehiculos.Columns["Color"].HeaderText = "Color";
            if (dgvVehiculos.Columns["Anio"] != null)
                dgvVehiculos.Columns["Anio"].HeaderText = "Año";
            if (dgvVehiculos.Columns["Activo"] != null)
            {
                dgvVehiculos.Columns["Activo"].HeaderText = "Activo";
                dgvVehiculos.Columns["Activo"].Width = 60;
            }
            if (dgvVehiculos.Columns["IdModelo"] != null)
                dgvVehiculos.Columns["IdModelo"].HeaderText = "ID Modelo";
            if (dgvVehiculos.Columns["IdCategoria"] != null)
                dgvVehiculos.Columns["IdCategoria"].HeaderText = "ID Categoría";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVehiculos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un vehículo para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvVehiculos.CurrentRow.Cells["IdVehiculo"].Value);
            var veh = _controller.BuscarPorId(id);
            if (veh == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionVehiculo(veh);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVehiculos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un vehículo para dar de baja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvVehiculos.CurrentRow.Cells["IdVehiculo"].Value);
            string matricula = dgvVehiculos.CurrentRow.Cells["Matricula"].Value?.ToString() ?? "";
            bool activo = Convert.ToBoolean(dgvVehiculos.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja el vehículo con matrícula {matricula}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _controller.Eliminar(id);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show($"El vehículo {matricula} ya se encuentra inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
