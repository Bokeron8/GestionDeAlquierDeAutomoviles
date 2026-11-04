using System;
using System.Linq;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaModeloVista : UserControl
    {
        private readonly ModeloController _controller = new();

        public ListaModeloVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            dgvModelos.SelectionChanged += (_, _) => ActualizarBotonBaja();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaModelo.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaModelo);
        }

        public void Refrescar()
        {
            string termino = FiltroBusqueda.Normalizar(txtBuscar.Text);
            var lista = _controller.Listar();
            if (termino.Length > 0)
            {
                lista = lista.Where(m =>
                    m.IdModelo.ToString().Contains(termino) ||
                    FiltroBusqueda.Contiene(m.NombreModelo, termino) ||
                    FiltroBusqueda.Contiene(m.NombreMarca, termino)).ToList();
            }

            dgvModelos.DataSource = null;
            dgvModelos.DataSource = lista;

            if (dgvModelos.Columns["IdModelo"] != null)
            {
                dgvModelos.Columns["IdModelo"].HeaderText = "ID";
                dgvModelos.Columns["IdModelo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvModelos.Columns["IdModelo"].Width = 50;
            }
            if (dgvModelos.Columns["NombreModelo"] != null)
                dgvModelos.Columns["NombreModelo"].HeaderText = "Modelo";
            if (dgvModelos.Columns["NombreMarca"] != null)
                dgvModelos.Columns["NombreMarca"].HeaderText = "Marca";
            if (dgvModelos.Columns["Activo"] != null)
            {
                dgvModelos.Columns["Activo"].HeaderText = "Activo";
                dgvModelos.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvModelos.Columns["Activo"].Width = 60;
            }

            string[] ocultas = ["IdMarca", "Descripcion"];
            foreach (string columna in ocultas)
            {
                if (dgvModelos.Columns[columna] != null)
                    dgvModelos.Columns[columna].Visible = false;
            }

            OrdenarColumnas();

            ActualizarBotonBaja();
        }

        private void ActualizarBotonBaja()
        {
            bool hayFila = dgvModelos.CurrentRow != null;
            bool activo = hayFila && Convert.ToBoolean(dgvModelos.CurrentRow!.Cells["Activo"].Value);

            btnEliminar.Enabled = hayFila;
            btnEliminar.Text = hayFila && !activo ? "Restaurar" : "Dar de baja";
            btnEliminar.BackColor = hayFila && !activo
                ? System.Drawing.Color.FromArgb(40, 140, 80)
                : System.Drawing.Color.FromArgb(180, 40, 40);
        }

        private void OrdenarColumnas()
        {
            string[] orden = ["IdModelo", "NombreModelo", "NombreMarca", "Activo"];
            for (int i = 0; i < orden.Length; i++)
            {
                if (dgvModelos.Columns[orden[i]] != null)
                    dgvModelos.Columns[orden[i]].DisplayIndex = i;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvModelos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un modelo para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvModelos.CurrentRow.Cells["IdModelo"].Value);
            var modelo = _controller.BuscarPorId(id);
            if (modelo == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionModelo(modelo);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvModelos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un modelo para dar de baja o restaurar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvModelos.CurrentRow.Cells["IdModelo"].Value);
            string nombre = dgvModelos.CurrentRow.Cells["NombreModelo"].Value?.ToString() ?? "";
            bool activo = Convert.ToBoolean(dgvModelos.CurrentRow.Cells["Activo"].Value);

            if (activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja el modelo {nombre}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;

                _controller.Eliminar(id);
            }
            else
            {
                var result = MessageBox.Show(
                    $"¿Desea restaurar el modelo {nombre}?",
                    "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                _controller.Restaurar(id);
            }

            Refrescar();
        }
    }
}
