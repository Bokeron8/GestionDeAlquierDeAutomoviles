using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public decimal PrecioDiarioPactado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaInicioReserva { get; set; }
        public DateTime FechaFinReserva { get; set; }
        public bool Activo { get; set; }
        public int IdEstado { get; set; }
        public int IdEmpleado { get; set; }
        public int IdVehiculo { get; set; }
        public int IdCliente { get; set; }

        /// <summary>
        /// Nombre del estado resuelto por la consulta de listado. Es de solo lectura y solo
        /// viene poblado por ObtenerTodos.
        /// </summary>
        public string NombreEstado { get; set; } = "";

        public static List<Reserva> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT r.*, e.nombre AS estado_nombre
                  FROM Reserva r
                  INNER JOIN Estado e ON e.id_estado = r.id_estado
                  ORDER BY r.fecha_inicio_reserva DESC");
            var lista = new List<Reserva>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        /// <summary>
        /// True when the vehicle already has a live reservation whose date range overlaps
        /// [inicio, fin]. Ranges are compared inclusively, so a same-day handover counts as
        /// an overlap. idReservaExcluir lets an edit ignore itself.
        /// </summary>
        public static bool TieneSolapamiento(int idVehiculo, DateTime inicio, DateTime fin, int idReservaExcluir = 0)
        {
            if (idVehiculo <= 0) return false;

            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT COUNT(*) AS total FROM Reserva
                  WHERE id_vehiculo = @id_vehiculo
                    AND activo = 1
                    AND id_estado IN (@pendiente, @confirmada, @en_curso)
                    AND id_reserva <> @id_reserva
                    AND @inicio <= fecha_fin_reserva
                    AND @fin >= fecha_inicio_reserva",
                [
                    new SqlParameter("@id_vehiculo", idVehiculo),
                    new SqlParameter("@pendiente", EstadosReserva.Pendiente),
                    new SqlParameter("@confirmada", EstadosReserva.Confirmada),
                    new SqlParameter("@en_curso", EstadosReserva.EnCurso),
                    new SqlParameter("@id_reserva", idReservaExcluir),
                    new SqlParameter("@inicio", inicio),
                    new SqlParameter("@fin", fin)
                ]);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0]["total"]) > 0;
        }

        /// <summary>
        /// Moves a reservation to the given state without touching any other column.
        /// Returns the affected row count so callers can verify the transition landed.
        /// </summary>
        public static int CambiarEstado(int idReserva, int idEstado)
        {
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE Reserva SET id_estado = @id_estado WHERE id_reserva = @id_reserva",
                [
                    new SqlParameter("@id_estado", idEstado),
                    new SqlParameter("@id_reserva", idReserva)
                ]);
        }

        /// <summary>
        /// Same state transition, inside a caller-owned transaction so a rental and its
        /// reservation move together or not at all.
        /// </summary>
        public static int CambiarEstado(int idReserva, int idEstado, Microsoft.Data.SqlClient.SqlConnection conn, Microsoft.Data.SqlClient.SqlTransaction transaction)
        {
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE Reserva SET id_estado = @id_estado WHERE id_reserva = @id_reserva",
                [
                    new SqlParameter("@id_estado", idEstado),
                    new SqlParameter("@id_reserva", idReserva)
                ], conn, transaction);
        }

        /// <summary>
        /// Returns the reservations that can still be rented: confirmed ones with no active
        /// rental recorded, plus the reservation currently assigned to the rental being
        /// edited (idReservaActual) so it never disappears from its own combo.
        /// </summary>
        public static List<Reserva> ObtenerDisponiblesParaAlquiler(int idReservaActual = 0)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT * FROM Reserva r
                  WHERE r.id_reserva = @idReservaActual
                     OR (r.activo = 1
                         AND r.id_estado = @confirmada
                         AND NOT EXISTS (SELECT 1 FROM Alquiler a
                                         WHERE a.id_reserva = r.id_reserva
                                           AND a.activo = 1))
                  ORDER BY r.fecha_inicio_reserva DESC",
                [
                    new SqlParameter("@idReservaActual", idReservaActual),
                    new SqlParameter("@confirmada", EstadosReserva.Confirmada)
                ]);
            var lista = new List<Reserva>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static Reserva? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Reserva WHERE id_reserva = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(Reserva r)
        {
            if (r.IdReserva == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Reserva (precio_diario_pactado, fecha_solicitud, fecha_inicio_reserva, fecha_fin_reserva, activo, id_estado, id_empleado, id_vehiculo, id_cliente) 
                      VALUES (@precio_diario_pactado, GETDATE(), @fecha_inicio_reserva, @fecha_fin_reserva, @activo, @id_estado, @id_empleado, @id_vehiculo, @id_cliente)",
                    [
                        new SqlParameter("@precio_diario_pactado", r.PrecioDiarioPactado),
                        new SqlParameter("@fecha_inicio_reserva", r.FechaInicioReserva),
                        new SqlParameter("@fecha_fin_reserva", r.FechaFinReserva),
                        new SqlParameter("@activo", r.Activo),
                        new SqlParameter("@id_estado", r.IdEstado),
                        new SqlParameter("@id_empleado", r.IdEmpleado),
                        new SqlParameter("@id_vehiculo", r.IdVehiculo),
                        new SqlParameter("@id_cliente", r.IdCliente)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Reserva SET precio_diario_pactado=@precio_diario_pactado, fecha_inicio_reserva=@fecha_inicio_reserva, fecha_fin_reserva=@fecha_fin_reserva, activo=@activo, id_estado=@id_estado, id_empleado=@id_empleado, id_vehiculo=@id_vehiculo, id_cliente=@id_cliente WHERE id_reserva=@id_reserva",
                    [
                        new SqlParameter("@precio_diario_pactado", r.PrecioDiarioPactado),
                        new SqlParameter("@fecha_inicio_reserva", r.FechaInicioReserva),
                        new SqlParameter("@fecha_fin_reserva", r.FechaFinReserva),
                        new SqlParameter("@activo", r.Activo),
                        new SqlParameter("@id_estado", r.IdEstado),
                        new SqlParameter("@id_empleado", r.IdEmpleado),
                        new SqlParameter("@id_vehiculo", r.IdVehiculo),
                        new SqlParameter("@id_cliente", r.IdCliente),
                        new SqlParameter("@id_reserva", r.IdReserva)
                    ]);
            }
        }

        /// <summary>
        /// Soft-cancels a reservation: it stops occupying the vehicle and keeps the
        /// Cancelada state in history. The WHERE clause carries the guard so a
        /// reservation that already moved on cannot be cancelled by a stale screen.
        /// </summary>
        public static int Cancelar(int idReserva)
        {
            return DatabaseHelper.ExecuteNonQuery(
                @"UPDATE Reserva SET id_estado = @cancelada, activo = 0
                  WHERE id_reserva = @id_reserva
                    AND id_estado IN (@pendiente, @confirmada)",
                [
                    new SqlParameter("@cancelada", EstadosReserva.Cancelada),
                    new SqlParameter("@id_reserva", idReserva),
                    new SqlParameter("@pendiente", EstadosReserva.Pendiente),
                    new SqlParameter("@confirmada", EstadosReserva.Confirmada)
                ]);
        }

        private static Reserva Map(DataRow row)
        {
            return new Reserva
            {
                IdReserva = Convert.ToInt32(row["id_reserva"]),
                PrecioDiarioPactado = Convert.ToDecimal(row["precio_diario_pactado"]),
                FechaSolicitud = Convert.ToDateTime(row["fecha_solicitud"]),
                FechaInicioReserva = Convert.ToDateTime(row["fecha_inicio_reserva"]),
                FechaFinReserva = Convert.ToDateTime(row["fecha_fin_reserva"]),
                Activo = Convert.ToBoolean(row["activo"]),
                IdEstado = Convert.ToInt32(row["id_estado"]),
                IdEmpleado = Convert.ToInt32(row["id_empleado"]),
                IdVehiculo = Convert.ToInt32(row["id_vehiculo"]),
                IdCliente = Convert.ToInt32(row["id_cliente"]),
                NombreEstado = row.Table.Columns.Contains("estado_nombre") && row["estado_nombre"] != DBNull.Value
                    ? row["estado_nombre"].ToString() ?? ""
                    : ""
            };
        }
    }
}
