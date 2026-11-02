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
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaVehiculo.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaVehiculo);
        }

        public void Refrescar()
        {
            string termino = FiltroBusqueda.Normalizar(txtBuscar.Text);
            var lista = _controller.Listar();
            if (termino.Length > 0)
            {
                lista = lista.Where(v =>
                    v.IdVehiculo.ToString().Contains(termino) ||
                    FiltroBusqueda.Contiene(v.Matricula, termino) ||
                    FiltroBusqueda.Contiene(v.NombreMarca, termino) ||
                    FiltroBusqueda.Contiene(v.NombreModelo, termino)).ToList();
            }

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
            if (dgvVehiculos.Columns["NombreMarca"] != null)
                dgvVehiculos.Columns["NombreMarca"].HeaderText = "Marca";
            if (dgvVehiculos.Columns["NombreModelo"] != null)
                dgvVehiculos.Columns["NombreModelo"].HeaderText = "Modelo";
            if (dgvVehiculos.Columns["NombreCategoria"] != null)
                dgvVehiculos.Columns["NombreCategoria"].HeaderText = "Categoría";
            if (dgvVehiculos.Columns["Anio"] != null)
                dgvVehiculos.Columns["Anio"].HeaderText = "Año";
            if (dgvVehiculos.Columns["Color"] != null)
                dgvVehiculos.Columns["Color"].HeaderText = "Color";
            if (dgvVehiculos.Columns["Activo"] != null)
            {
                dgvVehiculos.Columns["Activo"].HeaderText = "Activo";
                dgvVehiculos.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvVehiculos.Columns["Activo"].Width = 60;
            }

            // The chassis is a paperwork detail, not something the counter operator reads,
            // and the related ids say nothing now that the names are on screen.
            string[] ocultas = ["Chasis", "IdModelo", "IdCategoria", "Descripcion"];
            foreach (string columna in ocultas)
            {
                if (dgvVehiculos.Columns[columna] != null)
                    dgvVehiculos.Columns[columna].Visible = false;
            }

            OrdenarColumnas();
        }

        private void OrdenarColumnas()
        {
            string[] orden =
            [
                "IdVehiculo", "Matricula", "NombreMarca", "NombreModelo",
                "NombreCategoria", "Anio", "Color", "Activo"
            ];
            for (int i = 0; i < orden.Length; i++)
            {
                if (dgvVehiculos.Columns[orden[i]] != null)
                    dgvVehiculos.Columns[orden[i]].DisplayIndex = i;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Refrescar();
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
                    Refrescar();
                }
            }
            else
            {
                MessageBox.Show($"El vehículo {matricula} ya se encuentra inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
