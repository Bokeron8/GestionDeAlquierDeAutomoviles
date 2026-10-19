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

            if (res.PrecioDiarioPactado <= 0)
                errores.Add("El precio diario pactado debe ser mayor a cero.");
            if (res.FechaInicioReserva < DateTime.Today)
                errores.Add("La fecha de inicio de reserva no puede ser anterior a hoy.");
            if (res.FechaFinReserva <= res.FechaInicioReserva)
                errores.Add("La fecha de fin de reserva debe ser posterior a la fecha de inicio.");
            if (res.IdCliente <= 0)
                errores.Add("Debe seleccionar un cliente.");
            if (res.IdVehiculo <= 0)
                errores.Add("Debe seleccionar un vehículo.");
            if (res.IdEmpleado <= 0)
                errores.Add("Debe seleccionar un empleado.");
            if (res.IdEstado <= 0)
                errores.Add("Debe seleccionar un estado.");

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

        public bool Eliminar(int id)
        {
            return Reserva.Eliminar(id);
        }

        public List<Cliente> ObtenerClientes()
        {
            return Cliente.ObtenerTodos();
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            return Vehiculo.ObtenerTodos();
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return Empleado.ObtenerTodos();
        }

        public List<Estado> ObtenerEstados()
        {
            return Estado.ObtenerTodos();
        }
    }
}
