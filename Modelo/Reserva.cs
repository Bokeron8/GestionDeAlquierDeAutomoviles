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

        public static List<Reserva> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Reserva ORDER BY fecha_inicio_reserva DESC");
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

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Reserva SET activo = 0 WHERE id_reserva = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
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
                IdCliente = Convert.ToInt32(row["id_cliente"])
            };
        }
    }
}
