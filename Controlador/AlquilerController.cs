using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class AlquilerController
    {
        public List<string> ValidarAlquiler(Alquiler alq)
        {
            var errores = new List<string>();

            if (alq.IdReserva <= 0)
                errores.Add("Debe asociar una reserva válida.");
            if (alq.CombustibleSalida < 0 || alq.CombustibleSalida > 100)
                errores.Add("El porcentaje de combustible de salida debe estar entre 0 y 100.");
            if (alq.KilometrajeSalida < 0)
                errores.Add("El kilometraje de salida no puede ser negativo.");
            if (alq.MontoMora < 0)
                errores.Add("El monto de mora no puede ser negativo.");

            if (alq.FechaEntregaDevolucion.HasValue)
            {
                if (alq.FechaEntregaDevolucion.Value < alq.FechaEntregaReal)
                    errores.Add("La fecha de devolución no puede ser anterior a la fecha de entrega real.");
                if (alq.CombustibleEntrada.HasValue && (alq.CombustibleEntrada.Value < 0 || alq.CombustibleEntrada.Value > 100))
                    errores.Add("El porcentaje de combustible de entrada debe estar entre 0 y 100.");
                if (alq.KilometrajeEntrada.HasValue && alq.KilometrajeEntrada.Value < alq.KilometrajeSalida)
                    errores.Add("El kilometraje de entrada no puede ser menor al kilometraje de salida.");
            }

            return errores;
        }

        public List<Alquiler> Listar()
        {
            return Alquiler.ObtenerTodos();
        }

        public Alquiler? BuscarPorId(int id)
        {
            return Alquiler.ObtenerPorId(id);
        }

        public int Guardar(Alquiler alq)
        {
            return Alquiler.Guardar(alq);
        }

        public bool RegistrarDevolucionTransaccional(int idAlquiler, DateTime fechaDevolucion, decimal combustibleEntrada, decimal kilometrajeEntrada, decimal montoMora)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string queryAlquiler = @"UPDATE Alquiler 
                                                 SET fechaEntregaDevolucion = @fechaDevolucion, 
                                                     combustibleEntrada = @combustibleEntrada, 
                                                     kilometrajeEntrada = @kilometrajeEntrada, 
                                                     montoMora = @montoMora 
                                                 WHERE id_alquiler = @idAlquiler";

                        DatabaseHelper.ExecuteNonQuery(queryAlquiler, [
                            new SqlParameter("@fechaDevolucion", fechaDevolucion),
                            new SqlParameter("@combustibleEntrada", combustibleEntrada),
                            new SqlParameter("@kilometrajeEntrada", kilometrajeEntrada),
                            new SqlParameter("@montoMora", montoMora),
                            new SqlParameter("@idAlquiler", idAlquiler)
                        ], conn, transaction);

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool Eliminar(int id)
        {
            return Alquiler.Eliminar(id);
        }

        public List<Reserva> ObtenerReservas()
        {
            return Reserva.ObtenerTodos();
        }
    }
}
