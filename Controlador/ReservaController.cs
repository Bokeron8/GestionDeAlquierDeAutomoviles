using System;
using System.Collections.Generic;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class ReservaController
    {
        public List<string> ValidarReserva(Reserva res)
        {
            var errores = new List<string>();
            bool fechasValidas = true;

            if (res.PrecioDiarioPactado <= 0)
                errores.Add("El precio diario pactado debe ser mayor a cero.");
            if (res.FechaInicioReserva < DateTime.Today)
                errores.Add("La fecha de inicio de reserva no puede ser anterior a hoy.");
            if (res.FechaFinReserva <= res.FechaInicioReserva)
            {
                errores.Add("La fecha de fin de reserva debe ser posterior a la fecha de inicio.");
                fechasValidas = false;
            }
            if (res.IdCliente <= 0)
                errores.Add("Debe seleccionar un cliente.");
            if (res.IdVehiculo <= 0)
                errores.Add("Debe seleccionar un vehículo.");
            if (res.IdEmpleado <= 0)
                errores.Add("Debe registrar la reserva desde una sesión de empleado.");

            if (fechasValidas && res.IdVehiculo > 0
                && Reserva.TieneSolapamiento(res.IdVehiculo, res.FechaInicioReserva, res.FechaFinReserva, res.IdReserva))
                errores.Add("El vehículo ya tiene una reserva en ese rango de fechas.");

            if (res.IdReserva > 0)
            {
                var actual = Reserva.ObtenerPorId(res.IdReserva);
                if (actual != null && !EsEditable(actual.IdEstado))
                    errores.Add("Solo se pueden editar reservas pendientes o confirmadas.");
            }

            return errores;
        }

        /// <summary>
        /// Only pending and confirmed reservations can still be changed: once the vehicle is
        /// out (En Curso) the rental owns the data, and Finalizada/Cancelada are history.
        /// </summary>
        public static bool EsEditable(int idEstado)
        {
            return idEstado == EstadosReserva.Pendiente || idEstado == EstadosReserva.Confirmada;
        }

        public List<string> Confirmar(int idReserva)
        {
            var errores = new List<string>();
            var res = Reserva.ObtenerPorId(idReserva);
            if (res == null)
            {
                errores.Add("La reserva no existe.");
                return errores;
            }
            if (res.IdEstado != EstadosReserva.Pendiente)
            {
                errores.Add("Solo se puede confirmar una reserva pendiente.");
                return errores;
            }
            if (Reserva.CambiarEstado(idReserva, EstadosReserva.Confirmada) == 0)
                errores.Add("No se pudo confirmar la reserva.");
            return errores;
        }

        public List<string> Cancelar(int idReserva)
        {
            var errores = new List<string>();
            var res = Reserva.ObtenerPorId(idReserva);
            if (res == null)
            {
                errores.Add("La reserva no existe.");
                return errores;
            }
            if (!EsEditable(res.IdEstado))
            {
                errores.Add("Solo se puede dar de baja una reserva pendiente o confirmada.");
                return errores;
            }
            if (Reserva.Cancelar(idReserva) == 0)
                errores.Add("No se pudo dar de baja la reserva.");
            return errores;
        }


        public List<Reserva> Listar()
        {
            return Reserva.ObtenerTodos();
        }

        public Reserva? BuscarPorId(int id)
        {
            return Reserva.ObtenerPorId(id);
        }

        public int Guardar(Reserva res)
        {
            return Reserva.Guardar(res);
        }

        public List<Cliente> ObtenerClientes()
        {
            return Cliente.ObtenerTodos();
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            return Vehiculo.ObtenerTodos();
        }
    }
}
