using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Alquiler
    {
        public int IdAlquiler { get; set; }
        public DateTime FechaEntregaReal { get; set; }
        public DateTime? FechaEntregaDevolucion { get; set; }
        public decimal CombustibleSalida { get; set; }
        public decimal? CombustibleEntrada { get; set; }
        public decimal KilometrajeSalida { get; set; }
        public decimal? KilometrajeEntrada { get; set; }
        public decimal MontoMora { get; set; }
        public bool Activo { get; set; }
        public int IdReserva { get; set; }

        public static List<Alquiler> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Alquiler ORDER BY fechaEntregaReal DESC");
            var lista = new List<Alquiler>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static Alquiler? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Alquiler WHERE id_alquiler = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(Alquiler a)
        {
            if (a.IdAlquiler == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Alquiler (fechaEntregaReal, fechaEntregaDevolucion, combustibleSalida, combustibleEntrada, kilometrajeSalida, kilometrajeEntrada, montoMora, activo, id_reserva) 
                      VALUES (@fechaEntregaReal, @fechaEntregaDevolucion, @combustibleSalida, @combustibleEntrada, @kilometrajeSalida, @kilometrajeEntrada, @montoMora, @activo, @id_reserva)",
                    [
                        new SqlParameter("@fechaEntregaReal", a.FechaEntregaReal),
                        new SqlParameter("@fechaEntregaDevolucion", (object?)a.FechaEntregaDevolucion ?? DBNull.Value),
                        new SqlParameter("@combustibleSalida", a.CombustibleSalida),
                        new SqlParameter("@combustibleEntrada", (object?)a.CombustibleEntrada ?? DBNull.Value),
                        new SqlParameter("@kilometrajeSalida", a.KilometrajeSalida),
                        new SqlParameter("@kilometrajeEntrada", (object?)a.KilometrajeEntrada ?? DBNull.Value),
                        new SqlParameter("@montoMora", a.MontoMora),
                        new SqlParameter("@activo", a.Activo),
                        new SqlParameter("@id_reserva", a.IdReserva)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Alquiler SET fechaEntregaReal=@fechaEntregaReal, fechaEntregaDevolucion=@fechaEntregaDevolucion, combustibleSalida=@combustibleSalida, combustibleEntrada=@combustibleEntrada, kilometrajeSalida=@kilometrajeSalida, kilometrajeEntrada=@kilometrajeEntrada, montoMora=@montoMora, activo=@activo, id_reserva=@id_reserva WHERE id_alquiler=@id_alquiler",
                    [
                        new SqlParameter("@fechaEntregaReal", a.FechaEntregaReal),
                        new SqlParameter("@fechaEntregaDevolucion", (object?)a.FechaEntregaDevolucion ?? DBNull.Value),
                        new SqlParameter("@combustibleSalida", a.CombustibleSalida),
                        new SqlParameter("@combustibleEntrada", (object?)a.CombustibleEntrada ?? DBNull.Value),
                        new SqlParameter("@kilometrajeSalida", a.KilometrajeSalida),
                        new SqlParameter("@kilometrajeEntrada", (object?)a.KilometrajeEntrada ?? DBNull.Value),
                        new SqlParameter("@montoMora", a.MontoMora),
                        new SqlParameter("@activo", a.Activo),
                        new SqlParameter("@id_reserva", a.IdReserva),
                        new SqlParameter("@id_alquiler", a.IdAlquiler)
                    ]);
            }
        }

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Alquiler SET activo = 0 WHERE id_alquiler = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        private static Alquiler Map(DataRow row)
        {
            return new Alquiler
            {
                IdAlquiler = Convert.ToInt32(row["id_alquiler"]),
                FechaEntregaReal = Convert.ToDateTime(row["fechaEntregaReal"]),
                FechaEntregaDevolucion = row["fechaEntregaDevolucion"] != DBNull.Value ? Convert.ToDateTime(row["fechaEntregaDevolucion"]) : null,
                CombustibleSalida = Convert.ToDecimal(row["combustibleSalida"]),
                CombustibleEntrada = row["combustibleEntrada"] != DBNull.Value ? Convert.ToDecimal(row["combustibleEntrada"]) : null,
                KilometrajeSalida = Convert.ToDecimal(row["kilometrajeSalida"]),
                KilometrajeEntrada = row["kilometrajeEntrada"] != DBNull.Value ? Convert.ToDecimal(row["kilometrajeEntrada"]) : null,
                MontoMora = Convert.ToDecimal(row["montoMora"]),
                Activo = Convert.ToBoolean(row["activo"]),
                IdReserva = Convert.ToInt32(row["id_reserva"])
            };
        }
    }
}
