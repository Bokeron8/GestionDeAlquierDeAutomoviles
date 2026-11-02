using System;
using System.Linq;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaEmpleadoVista : UserControl
    {
        private readonly EmpleadoController _controller = new();

        public ListaEmpleadoVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            dgvEmpleados.SelectionChanged += (s, e) => ActualizarBotonBaja();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaEmpleado.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaEmpleado);
        }

        public void Refrescar()
        {
            string termino = FiltroBusqueda.Normalizar(txtBuscar.Text);
            var lista = _controller.Listar();
            if (termino.Length > 0)
            {
                lista = lista.Where(e =>
                    e.IdEmpleado.ToString().Contains(termino) ||
                    FiltroBusqueda.Contiene(e.Apellido, termino) ||
                    FiltroBusqueda.Contiene(e.Nombre, termino) ||
                    FiltroBusqueda.Contiene(e.Dni, termino) ||
                    FiltroBusqueda.Contiene(e.Usuario, termino) ||
                    FiltroBusqueda.Contiene(e.NombreRol, termino)).ToList();
            }

            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = lista;

            // The grid is bound to List<Empleado>, so every column name is the property
            // name in PascalCase. Naming them in snake_case silently matches nothing.
            if (dgvEmpleados.Columns["IdEmpleado"] != null)
            {
                dgvEmpleados.Columns["IdEmpleado"].HeaderText = "ID";
                dgvEmpleados.Columns["IdEmpleado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvEmpleados.Columns["IdEmpleado"].Width = 50;
            }
            if (dgvEmpleados.Columns["Apellido"] != null)
                dgvEmpleados.Columns["Apellido"].HeaderText = "Apellido";
            if (dgvEmpleados.Columns["Nombre"] != null)
                dgvEmpleados.Columns["Nombre"].HeaderText = "Nombre";
            if (dgvEmpleados.Columns["Dni"] != null)
                dgvEmpleados.Columns["Dni"].HeaderText = "DNI";
            if (dgvEmpleados.Columns["NombreRol"] != null)
                dgvEmpleados.Columns["NombreRol"].HeaderText = "Rol";
            if (dgvEmpleados.Columns["Telefono"] != null)
                dgvEmpleados.Columns["Telefono"].HeaderText = "Teléfono";
            if (dgvEmpleados.Columns["Correo"] != null)
                dgvEmpleados.Columns["Correo"].HeaderText = "Correo";
            if (dgvEmpleados.Columns["FechaContratacion"] != null)
                dgvEmpleados.Columns["FechaContratacion"].HeaderText = "F. Contratación";
            if (dgvEmpleados.Columns["Activo"] != null)
            {
                dgvEmpleados.Columns["Activo"].HeaderText = "Activo";
                dgvEmpleados.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvEmpleados.Columns["Activo"].Width = 60;
            }

            // User, password, address, birth date and the raw role id are either sensitive
            // or already represented by a resolved column.
            string[] ocultas =
            [
                "Usuario", "Contrasenia", "Direccion", "FechaNacimiento", "IdRol", "Descripcion"
            ];
            foreach (string columna in ocultas)
            {
                if (dgvEmpleados.Columns[columna] != null)
                    dgvEmpleados.Columns[columna].Visible = false;
            }

            OrdenarColumnas();
            ActualizarBotonBaja();
        }

        private void OrdenarColumnas()
        {
            string[] orden =
            [
                "IdEmpleado", "Apellido", "Nombre", "Dni", "NombreRol", "Telefono",
                "Correo", "FechaContratacion", "Activo"
            ];
            for (int i = 0; i < orden.Length; i++)
            {
                if (dgvEmpleados.Columns[orden[i]] != null)
                    dgvEmpleados.Columns[orden[i]].DisplayIndex = i;
            }
        }

        /// <summary>
        /// The same button deactivates and restores, so its label has to follow the
        /// selected row instead of the action the operator already clicked.
        /// </summary>
        private void ActualizarBotonBaja()
        {
            bool hayFila = dgvEmpleados.CurrentRow != null;
            bool activo = hayFila && Convert.ToBoolean(dgvEmpleados.CurrentRow!.Cells["Activo"].Value);

            btnEliminar.Enabled = hayFila;
            btnEliminar.Text = hayFila && !activo ? "Restaurar" : "Dar de baja";
            btnEliminar.BackColor = hayFila && !activo
                ? System.Drawing.Color.FromArgb(40, 140, 80)
                : System.Drawing.Color.FromArgb(180, 40, 40);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
            var emp = _controller.BuscarPorId(id);
            if (emp == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionEmpleado(emp);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado para dar de baja o restaurar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
            var emp = _controller.BuscarPorId(id);
            if (emp == null) return;

            if (emp.Activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja al empleado {emp.Descripcion}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;

                _controller.Eliminar(id);
            }
            else
            {
                var result = MessageBox.Show(
                    $"¿Desea restaurar al empleado {emp.Descripcion}?",
                    "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                _controller.Restaurar(id);
            }

            Refrescar();
        }
    }
}
