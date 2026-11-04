using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Controlador;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ReporteVista : UserControl
    {
        private static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("es-AR");

        private readonly ReporteController _controller = new();

        public ReporteVista()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the whole dashboard. The manager reaches it from the main menu, so a database
        /// failure reports once and leaves the screen at zero instead of tearing down the
        /// application.
        /// </summary>
        public void Refrescar()
        {
            try
            {
                var resumen = _controller.ObtenerResumen();

                lblMetricVehiculos.Text = $"Vehículos: {resumen.Vehiculos}";
                lblMetricClientes.Text = $"Clientes: {resumen.Clientes}";
                lblMetricEmpleados.Text = $"Empleados: {resumen.Empleados}";
                lblMetricAlquileres.Text = $"Alquileres en curso: {resumen.AlquileresEnCurso}";
                lblMetricIngresos.Text = $"Ingresos (mes actual): {resumen.IngresosDelMes.ToString("C0", Cultura)}";

                MostrarReservas(resumen.ReservasActivas);
                MostrarVehiculos(resumen.VehiculosDisponibles);
            }
            catch (Exception ex)
            {
                Limpiar();
                MessageBox.Show("No se pudo cargar el tablero. " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            lblMetricVehiculos.Text = "Vehículos: 0";
            lblMetricClientes.Text = "Clientes: 0";
            lblMetricEmpleados.Text = "Empleados: 0";
            lblMetricAlquileres.Text = "Alquileres en curso: 0";
            lblMetricIngresos.Text = $"Ingresos (mes actual): {0m.ToString("C0", Cultura)}";

            dgvReservas.DataSource = null;
            dgvVehiculos.DataSource = null;
        }

        private void MostrarReservas(List<Reserva> reservas)
        {
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = reservas;

            if (dgvReservas.Columns["NombreCliente"] != null)
                dgvReservas.Columns["NombreCliente"].HeaderText = "Cliente";
            if (dgvReservas.Columns["MatriculaVehiculo"] != null)
                dgvReservas.Columns["MatriculaVehiculo"].HeaderText = "Vehículo";
            if (dgvReservas.Columns["FechaInicioReserva"] != null)
                dgvReservas.Columns["FechaInicioReserva"].HeaderText = "Desde";
            if (dgvReservas.Columns["FechaFinReserva"] != null)
                dgvReservas.Columns["FechaFinReserva"].HeaderText = "Hasta";
            if (dgvReservas.Columns["NombreEstado"] != null)
            {
                dgvReservas.Columns["NombreEstado"].HeaderText = "Estado";
                dgvReservas.Columns["NombreEstado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvReservas.Columns["NombreEstado"].Width = 100;
            }

            string[] ocultas =
            [
                "IdReserva", "PrecioDiarioPactado", "FechaSolicitud", "Activo",
                "IdEstado", "IdEmpleado", "IdVehiculo", "IdCliente",
                "DniCliente", "NombreEmpleado", "DescripcionCliente", "DescripcionCombo"
            ];
            foreach (string columna in ocultas)
            {
                if (dgvReservas.Columns[columna] != null)
                    dgvReservas.Columns[columna].Visible = false;
            }

            OrdenarColumnas(dgvReservas,
            [
                "NombreCliente", "MatriculaVehiculo", "FechaInicioReserva",
                "FechaFinReserva", "NombreEstado"
            ]);
        }

        private void MostrarVehiculos(List<Vehiculo> vehiculos)
        {
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = vehiculos;

            if (dgvVehiculos.Columns["Matricula"] != null)
            {
                dgvVehiculos.Columns["Matricula"].HeaderText = "Matrícula";
                dgvVehiculos.Columns["Matricula"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvVehiculos.Columns["Matricula"].Width = 90;
            }
            if (dgvVehiculos.Columns["MarcaModelo"] != null)
                dgvVehiculos.Columns["MarcaModelo"].HeaderText = "Marca y modelo";
            if (dgvVehiculos.Columns["NombreCategoria"] != null)
                dgvVehiculos.Columns["NombreCategoria"].HeaderText = "Categoría";

            string[] ocultas =
            [
                "IdVehiculo", "Chasis", "Color", "Anio", "Activo", "IdModelo", "IdCategoria",
                "NombreMarca", "NombreModelo", "Descripcion"
            ];
            foreach (string columna in ocultas)
            {
                if (dgvVehiculos.Columns[columna] != null)
                    dgvVehiculos.Columns[columna].Visible = false;
            }

            OrdenarColumnas(dgvVehiculos, ["Matricula", "MarcaModelo", "NombreCategoria"]);
        }

        /// <summary>
        /// Both grids are narrow, so the column order is explicit instead of whatever the
        /// binding happens to produce.
        /// </summary>
        private static void OrdenarColumnas(DataGridView grilla, string[] orden)
        {
            for (int i = 0; i < orden.Length; i++)
            {
                if (grilla.Columns[orden[i]] != null)
                    grilla.Columns[orden[i]].DisplayIndex = i;
            }
        }
    }
}
