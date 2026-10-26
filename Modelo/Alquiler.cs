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

        /// <summary>
        /// Lifecycle label for the grid: a rental is "En curso" until it is returned and
        /// "Devuelto" once the return data is recorded.
        /// </summary>
        public string Estado => Activo ? "En curso" : "Devuelto";

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

        public static ContratoAlquiler? ObtenerContrato(int idAlquiler)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT a.id_alquiler, a.id_reserva, a.fechaEntregaReal, a.kilometrajeSalida, a.activo,
                         r.fecha_fin_reserva, r.precio_diario_pactado,
                         c.nombre + ' ' + c.apellido AS cliente,
                         v.matricula AS vehiculo
                  FROM Alquiler a
                  INNER JOIN Reserva r ON r.id_reserva = a.id_reserva
                  INNER JOIN Cliente c ON c.id_cliente = r.id_cliente
                  INNER JOIN Vehiculo v ON v.id_vehiculo = r.id_vehiculo
                  WHERE a.id_alquiler = @id",
                [new SqlParameter("@id", idAlquiler)]);
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new ContratoAlquiler
            {
                IdAlquiler = Convert.ToInt32(row["id_alquiler"]),
                IdReserva = Convert.ToInt32(row["id_reserva"]),
                FechaEntregaReal = Convert.ToDateTime(row["fechaEntregaReal"]),
                FechaFinReserva = Convert.ToDateTime(row["fecha_fin_reserva"]),
                PrecioDiarioPactado = Convert.ToDecimal(row["precio_diario_pactado"]),
                KilometrajeSalida = Convert.ToDecimal(row["kilometrajeSalida"]),
                Activo = Convert.ToBoolean(row["activo"]),
                Cliente = row["cliente"].ToString() ?? "",
                Vehiculo = row["vehiculo"].ToString() ?? ""
            };
        }

        /// <summary>
        /// True when the reservation already has an active rental, ignoring the rental
        /// passed in idAlquilerExcluir so an edit does not collide with itself.
        /// </summary>
        public static bool TieneAlquilerActivo(int idReserva, int idAlquilerExcluir = 0)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT COUNT(*) AS total FROM Alquiler
                  WHERE id_reserva = @id_reserva
                    AND activo = 1
                    AND id_alquiler <> @id_alquiler",
                [
                    new SqlParameter("@id_reserva", idReserva),
                    new SqlParameter("@id_alquiler", idAlquilerExcluir)
                ]);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0]["total"]) > 0;
        }

        public static int Guardar(Alquiler a)
        {
            if (a.IdAlquiler == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(InsertSql, InsertParams(a));
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(UpdateSql, UpdateParams(a));
            }
        }

        /// <summary>
        /// Same save, inside a caller-owned transaction so the rental and the reservation
        /// state move together.
        /// </summary>
        public static int Guardar(Alquiler a, SqlConnection conn, SqlTransaction transaction)
        {
            if (a.IdAlquiler == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(InsertSql, InsertParams(a), conn, transaction);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(UpdateSql, UpdateParams(a), conn, transaction);
            }
        }

        private const string InsertSql =
            @"INSERT INTO Alquiler (fechaEntregaReal, fechaEntregaDevolucion, combustibleSalida, combustibleEntrada, kilometrajeSalida, kilometrajeEntrada, montoMora, activo, id_reserva) 
              VALUES (@fechaEntregaReal, @fechaEntregaDevolucion, @combustibleSalida, @combustibleEntrada, @kilometrajeSalida, @kilometrajeEntrada, @montoMora, @activo, @id_reserva)";

        private const string UpdateSql =
            @"UPDATE Alquiler SET fechaEntregaReal=@fechaEntregaReal, fechaEntregaDevolucion=@fechaEntregaDevolucion, combustibleSalida=@combustibleSalida, combustibleEntrada=@combustibleEntrada, kilometrajeSalida=@kilometrajeSalida, kilometrajeEntrada=@kilometrajeEntrada, montoMora=@montoMora, activo=@activo, id_reserva=@id_reserva WHERE id_alquiler=@id_alquiler";

        private static SqlParameter[] InsertParams(Alquiler a)
        {
            return
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
            ];
        }

        private static SqlParameter[] UpdateParams(Alquiler a)
        {
            return
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
            ];
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
