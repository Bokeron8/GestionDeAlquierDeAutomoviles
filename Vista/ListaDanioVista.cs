using System;
using System.Linq;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaDanioVista : UserControl
    {
        private readonly DanioController _controller = new();

        public ListaDanioVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            dgvDanios.SelectionChanged += (s, e) => ActualizarBotonBaja();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.cargaDanio.LimpiarFormulario();
            parentForm?.MostrarCarga(parentForm.cargaDanio);
        }

        public void Refrescar()
        {
            string termino = FiltroBusqueda.Normalizar(txtBuscar.Text);
            var lista = _controller.Listar();
            if (termino.Length > 0)
            {
                lista = lista.Where(d =>
                    d.IdDanio.ToString().Contains(termino) ||
                    FiltroBusqueda.Contiene(d.DescripcionCliente, termino) ||
                    FiltroBusqueda.Contiene(d.MatriculaVehiculo, termino) ||
                    FiltroBusqueda.Contiene(d.Zona, termino) ||
                    FiltroBusqueda.Contiene(d.Descripcion, termino) ||
                    FiltroBusqueda.Contiene(d.EvidenciaArchivo, termino) ||
                    FiltroBusqueda.Contiene(d.EstadoAlquiler, termino)).ToList();
            }

            dgvDanios.DataSource = null;
            dgvDanios.DataSource = lista;

            if (dgvDanios.Columns["IdDanio"] != null)
            {
                dgvDanios.Columns["IdDanio"].HeaderText = "ID";
                dgvDanios.Columns["IdDanio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvDanios.Columns["IdDanio"].Width = 50;
            }
            if (dgvDanios.Columns["DescripcionCliente"] != null)
                dgvDanios.Columns["DescripcionCliente"].HeaderText = "Cliente";
            if (dgvDanios.Columns["MatriculaVehiculo"] != null)
                dgvDanios.Columns["MatriculaVehiculo"].HeaderText = "Vehículo";
            if (dgvDanios.Columns["FechaEntregaAlquiler"] != null)
                dgvDanios.Columns["FechaEntregaAlquiler"].HeaderText = "F. Entrega";
            if (dgvDanios.Columns["Zona"] != null)
                dgvDanios.Columns["Zona"].HeaderText = "Zona";
            if (dgvDanios.Columns["Descripcion"] != null)
                dgvDanios.Columns["Descripcion"].HeaderText = "Descripción";
            if (dgvDanios.Columns["EvidenciaArchivo"] != null)
                dgvDanios.Columns["EvidenciaArchivo"].HeaderText = "Evidencia";
            if (dgvDanios.Columns["Activo"] != null)
            {
                dgvDanios.Columns["Activo"].HeaderText = "Activo";
                dgvDanios.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvDanios.Columns["Activo"].Width = 60;
            }

            // The raw rental id and the pieces the combined client label already carries
            // would only steal width from the columns the operator reads.
            string[] ocultas =
            [
                "IdAlquiler", "NombreCliente", "DniCliente", "EstadoAlquiler", "EvidenciaFotografica"
            ];
            foreach (string columna in ocultas)
            {
                if (dgvDanios.Columns[columna] != null)
                    dgvDanios.Columns[columna].Visible = false;
            }

            OrdenarColumnas();
            ActualizarBotonBaja();
        }

        private void OrdenarColumnas()
        {
            string[] orden =
            [
                "IdDanio", "DescripcionCliente", "MatriculaVehiculo", "FechaEntregaAlquiler",
                "Zona", "Descripcion", "EvidenciaArchivo", "Activo"
            ];
            for (int i = 0; i < orden.Length; i++)
            {
                if (dgvDanios.Columns[orden[i]] != null)
                    dgvDanios.Columns[orden[i]].DisplayIndex = i;
            }
        }

        /// <summary>
        /// The same button deactivates and restores, so its label follows the selected row.
        /// </summary>
        private void ActualizarBotonBaja()
        {
            bool hayFila = dgvDanios.CurrentRow != null;
            bool activo = hayFila && Convert.ToBoolean(dgvDanios.CurrentRow!.Cells["Activo"].Value);

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
            if (dgvDanios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un daño para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvDanios.CurrentRow.Cells["IdDanio"].Value);
            var danio = _controller.BuscarPorId(id);
            if (danio == null) return;

            var parentForm = FindForm() as PrincipalForm;
            parentForm?.CargarEdicionDanio(danio);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDanios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un daño para dar de baja o restaurar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvDanios.CurrentRow.Cells["IdDanio"].Value);
            var danio = _controller.BuscarPorId(id);
            if (danio == null) return;

            if (danio.Activo)
            {
                var result = MessageBox.Show(
                    $"¿Desea dar de baja el daño de la zona {danio.Zona} del vehículo {danio.MatriculaVehiculo}?",
                    "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;

                _controller.Eliminar(id);
            }
            else
            {
                var result = MessageBox.Show(
                    $"¿Desea restaurar el daño de la zona {danio.Zona} del vehículo {danio.MatriculaVehiculo}?",
                    "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                _controller.Restaurar(id);
            }

            Refrescar();
        }
    }
}
