using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            btnActualizar.Click += (_, _) => Refrescar();
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

                lblVehiculosValor.Text = resumen.Vehiculos.ToString("N0", Cultura);
                lblAlquileresValor.Text = resumen.AlquileresEnCurso.ToString("N0", Cultura);
                lblPendientesValor.Text = resumen.ReservasPendientes.ToString("N0", Cultura);
                lblClientesValor.Text = resumen.Clientes.ToString("N0", Cultura);
                lblIngresosValor.Text = resumen.IngresosDelMes.ToString("C0", Cultura);
                lblIngresosEtiqueta.Text = EtiquetaIngresos(resumen.IngresosDelMes, resumen.IngresosMesAnterior);
                lblOcupacionValor.Text =
                    $"{resumen.AlquileresEnCurso} de {resumen.Vehiculos} · " +
                    $"{resumen.PorcentajeOcupacion.ToString("0", Cultura)}%";

                MostrarReservas(resumen.ReservasActivas);
                MostrarVehiculos(resumen.VehiculosDisponibles);
                MostrarIngresosCategoria(resumen.IngresosPorCategoria);
                MostrarAlquileresFinalizados(resumen.AlquileresFinalizadosRecientes);

                lblActualizado.Text = $"Actualizado {DateTime.Now:dd/MM/yyyy HH:mm}";
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
            lblVehiculosValor.Text = "0";
            lblAlquileresValor.Text = "0";
            lblPendientesValor.Text = "0";
            lblClientesValor.Text = "0";
            lblIngresosValor.Text = 0m.ToString("C0", Cultura);
            lblIngresosEtiqueta.Text = "Ingresos del mes";
            lblOcupacionValor.Text = "0 de 0 · 0%";
            lblActualizado.Text = "Sin datos";

            dgvReservas.DataSource = null;
            dgvVehiculos.DataSource = null;
            dgvIngresosCategoria.DataSource = null;
            dgvAlquileresFinalizados.DataSource = null;

            lblSinReservas.Visible = true;
            lblSinVehiculos.Visible = true;
            lblSinIngresos.Visible = true;
            lblSinAlquileresFinalizados.Visible = true;
        }

        private static string EtiquetaIngresos(decimal actual, decimal mesAnterior)
        {
            if (mesAnterior <= 0m)
                return "Ingresos del mes";

            decimal variacion = (actual - mesAnterior) * 100m / mesAnterior;
            if (Math.Abs(variacion) < 0.5m)
                return "Ingresos del mes · sin variación";

            // The sign is explicit so the manager reads growth and drop at a glance.
            return $"Ingresos del mes · {variacion.ToString("+0;-0", Cultura)}%";
        }

        private void MostrarReservas(List<Reserva> reservas)
        {
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = reservas;
            MostrarColumnas(dgvReservas,
                "NombreCliente", "MatriculaVehiculo", "FechaInicioReserva", "FechaFinReserva", "NombreEstado");

            if (dgvReservas.Columns["NombreCliente"] != null)
                dgvReservas.Columns["NombreCliente"].HeaderText = "Cliente";
            if (dgvReservas.Columns["MatriculaVehiculo"] != null)
                dgvReservas.Columns["MatriculaVehiculo"].HeaderText = "Vehículo";
            if (dgvReservas.Columns["FechaInicioReserva"] != null)
            {
                dgvReservas.Columns["FechaInicioReserva"].HeaderText = "Desde";
                dgvReservas.Columns["FechaInicioReserva"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvReservas.Columns["FechaFinReserva"] != null)
            {
                dgvReservas.Columns["FechaFinReserva"].HeaderText = "Hasta";
                dgvReservas.Columns["FechaFinReserva"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvReservas.Columns["NombreEstado"] != null)
            {
                dgvReservas.Columns["NombreEstado"].HeaderText = "Estado";
                dgvReservas.Columns["NombreEstado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvReservas.Columns["NombreEstado"].Width = 110;
            }

            lblSinReservas.Visible = reservas.Count == 0;
        }

        private void MostrarVehiculos(List<Vehiculo> vehiculos)
        {
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = vehiculos;
            MostrarColumnas(dgvVehiculos, "Matricula", "MarcaModelo", "NombreCategoria");

            if (dgvVehiculos.Columns["Matricula"] != null)
            {
                dgvVehiculos.Columns["Matricula"].HeaderText = "Matrícula";
                dgvVehiculos.Columns["Matricula"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvVehiculos.Columns["Matricula"].Width = 100;
            }
            if (dgvVehiculos.Columns["MarcaModelo"] != null)
                dgvVehiculos.Columns["MarcaModelo"].HeaderText = "Marca y modelo";
            if (dgvVehiculos.Columns["NombreCategoria"] != null)
                dgvVehiculos.Columns["NombreCategoria"].HeaderText = "Categoría";

            lblSinVehiculos.Visible = vehiculos.Count == 0;
        }

        private void MostrarIngresosCategoria(List<IngresosPorCategoriaDto> lista)
        {
            dgvIngresosCategoria.DataSource = null;
            dgvIngresosCategoria.DataSource = lista;
            MostrarColumnas(dgvIngresosCategoria, "Categoria", "CantidadAlquileres", "TotalIngresos");

            if (dgvIngresosCategoria.Columns["Categoria"] != null)
                dgvIngresosCategoria.Columns["Categoria"].HeaderText = "Categoría";
            if (dgvIngresosCategoria.Columns["CantidadAlquileres"] != null)
                dgvIngresosCategoria.Columns["CantidadAlquileres"].HeaderText = "Alq.";
            if (dgvIngresosCategoria.Columns["TotalIngresos"] != null)
            {
                dgvIngresosCategoria.Columns["TotalIngresos"].HeaderText = "Ingresos";
                dgvIngresosCategoria.Columns["TotalIngresos"].DefaultCellStyle.Format = "C2";
            }

            lblSinIngresos.Visible = lista.Count == 0;
        }

        private void MostrarAlquileresFinalizados(List<AlquilerFinalizadoDto> lista)
        {
            dgvAlquileresFinalizados.DataSource = null;
            dgvAlquileresFinalizados.DataSource = lista;
            MostrarColumnas(dgvAlquileresFinalizados, "Cliente", "Vehiculo", "FechaDevolucion", "MontoTotal");

            if (dgvAlquileresFinalizados.Columns["Cliente"] != null)
                dgvAlquileresFinalizados.Columns["Cliente"].HeaderText = "Cliente";
            if (dgvAlquileresFinalizados.Columns["Vehiculo"] != null)
                dgvAlquileresFinalizados.Columns["Vehiculo"].HeaderText = "Vehículo";
            if (dgvAlquileresFinalizados.Columns["FechaDevolucion"] != null)
            {
                dgvAlquileresFinalizados.Columns["FechaDevolucion"].HeaderText = "Devolución";
                dgvAlquileresFinalizados.Columns["FechaDevolucion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvAlquileresFinalizados.Columns["MontoTotal"] != null)
            {
                dgvAlquileresFinalizados.Columns["MontoTotal"].HeaderText = "Total Cobrado";
                dgvAlquileresFinalizados.Columns["MontoTotal"].DefaultCellStyle.Format = "C2";
            }

            lblSinAlquileresFinalizados.Visible = lista.Count == 0;
        }

        /// <summary>
        /// Shows exactly the columns this view declares and hides every other one. Binding a
        /// model class produces a column per public property, so a hardcoded list of hidden
        /// columns silently leaks new properties (it already leaked VehiculoDescripcion).
        /// </summary>
        private static void MostrarColumnas(DataGridView grilla, params string[] visibles)
        {
            foreach (DataGridViewColumn columna in grilla.Columns)
                columna.Visible = visibles.Contains(columna.Name);

            for (int i = 0; i < visibles.Length; i++)
            {
                if (grilla.Columns[visibles[i]] != null)
                    grilla.Columns[visibles[i]].DisplayIndex = i;
            }
        }
    }
}
