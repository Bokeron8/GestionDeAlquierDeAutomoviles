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

        /// <summary>
        /// Resolved related names, populated only by the listing query. A rental loaded
        /// by id leaves them empty, which is why Map guards every optional column.
        /// </summary>
        public string NombreCliente { get; set; } = "";
        public string DniCliente { get; set; } = "";
        public string MatriculaVehiculo { get; set; } = "";
        public string DescripcionVehiculo { get; set; } = "";

        /// <summary>
        /// Identity label used by lists: "Pérez, Juan — DNI 30123456".
        /// </summary>
        public string DescripcionCliente => $"{NombreCliente} — DNI {DniCliente}";

        /// <summary>
        /// Short label used by selection combos: "#12 · Pérez, Juan · AB123CD — Toyota Corolla 2020".
        /// </summary>
        public string DescripcionCombo => $"#{IdAlquiler} · {NombreCliente} · {DescripcionVehiculo}";

        private const string SelectConRelaciones =
            @"SELECT a.*,
                     c.apellido + ', ' + c.nombre AS cliente_nombre, c.dni AS cliente_dni,
                     v.matricula AS vehiculo_matricula,
                     v.matricula + ' — ' + ma.marca + ' ' + mo.modelo + ' ' + CONVERT(VARCHAR(4), v.anio) AS vehiculo_descripcion
              FROM Alquiler a
              INNER JOIN Reserva r ON r.id_reserva = a.id_reserva
              INNER JOIN Cliente c ON c.id_cliente = r.id_cliente
              INNER JOIN Vehiculo v ON v.id_vehiculo = r.id_vehiculo
              INNER JOIN Modelo mo ON mo.id_modelo = v.id_modelo
              INNER JOIN Marca ma ON ma.id_marca = mo.id_marca";

        public static List<Alquiler> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                $"{SelectConRelaciones} ORDER BY a.fechaEntregaReal DESC");
            var lista = new List<Alquiler>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        /// <summary>
        /// Rentals whose contract is still open, used where picking an already returned
        /// rental would be a mistake, such as recording a damage.
        /// </summary>
        public static List<Alquiler> ObtenerEnCurso()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                $"{SelectConRelaciones} WHERE a.activo = 1 ORDER BY a.fechaEntregaReal DESC");
            var lista = new List<Alquiler>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        /// <summary>
        /// Income actually earned on rentals returned inside [desde, hasta): the agreed daily
        /// price times the real days, with a minimum of one day so a same-day return is not
        /// billed at zero, plus the late fee. Rentals still open are not income yet.
        /// </summary>
        public static decimal ObtenerIngresos(DateTime desde, DateTime hasta)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT ISNULL(SUM(r.precio_diario_pactado *
                                        CASE
                                            WHEN DATEDIFF(DAY, a.fechaEntregaReal, a.fechaEntregaDevolucion) < 1 THEN 1
                                            ELSE DATEDIFF(DAY, a.fechaEntregaReal, a.fechaEntregaDevolucion)
                                        END
                                      + ISNULL(a.montoMora, 0)), 0) AS ingresos
                  FROM Alquiler a
                  INNER JOIN Reserva r ON r.id_reserva = a.id_reserva
                  WHERE a.activo = 0
                    AND a.fechaEntregaDevolucion >= @desde
                    AND a.fechaEntregaDevolucion < @hasta",
                [
                    new SqlParameter("@desde", desde),
                    new SqlParameter("@hasta", hasta)
                ]);
            return dt.Rows.Count == 0 ? 0m : Convert.ToDecimal(dt.Rows[0]["ingresos"]);
        }

        public static Alquiler? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                $"{SelectConRelaciones} WHERE a.id_alquiler = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static ContratoAlquiler? ObtenerContrato(int idAlquiler)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT a.id_alquiler, a.id_reserva, a.fechaEntregaReal, a.kilometrajeSalida, a.activo,
                         r.fecha_fin_reserva, r.precio_diario_pactado,
                         c.apellido + ', ' + c.nombre + ' — DNI ' + c.dni AS cliente,
                         v.matricula + ' — ' + ma.marca + ' ' + mo.modelo + ' ' + CONVERT(VARCHAR(4), v.anio) AS vehiculo
                  FROM Alquiler a
                  INNER JOIN Reserva r ON r.id_reserva = a.id_reserva
                  INNER JOIN Cliente c ON c.id_cliente = r.id_cliente
                  INNER JOIN Vehiculo v ON v.id_vehiculo = r.id_vehiculo
                  INNER JOIN Modelo mo ON mo.id_modelo = v.id_modelo
                  INNER JOIN Marca ma ON ma.id_marca = mo.id_marca
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
                IdReserva = Convert.ToInt32(row["id_reserva"]),
                NombreCliente = TextoOpcional(row, "cliente_nombre"),
                DniCliente = TextoOpcional(row, "cliente_dni"),
                MatriculaVehiculo = TextoOpcional(row, "vehiculo_matricula"),
                DescripcionVehiculo = TextoOpcional(row, "vehiculo_descripcion")
            };
        }

        /// <summary>
        /// Reads a column that only the listing query selects, so loading a rental by id
        /// never breaks on a missing column.
        /// </summary>
        private static string TextoOpcional(DataRow row, string columna)
        {
            return row.Table.Columns.Contains(columna) && row[columna] != DBNull.Value
                ? row[columna].ToString() ?? ""
                : "";
        }

        public static List<IngresosPorCategoriaDto> ObtenerIngresosPorCategoria()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT cat.nombre AS categoria,
                         COUNT(a.id_alquiler) AS cantidad,
                         ISNULL(SUM(r.precio_diario_pactado *
                                    CASE WHEN DATEDIFF(DAY, a.fechaEntregaReal, a.fechaEntregaDevolucion) < 1 THEN 1
                                         ELSE DATEDIFF(DAY, a.fechaEntregaReal, a.fechaEntregaDevolucion) END
                                   + ISNULL(a.montoMora, 0)), 0) AS total_ingresos
                  FROM Alquiler a
                  INNER JOIN Reserva r ON r.id_reserva = a.id_reserva
                  INNER JOIN Vehiculo v ON v.id_vehiculo = r.id_vehiculo
                  INNER JOIN Categoria cat ON cat.id_categoria = v.id_categoria
                  WHERE a.activo = 0
                  GROUP BY cat.nombre
                  ORDER BY total_ingresos DESC");
            var lista = new List<IngresosPorCategoriaDto>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new IngresosPorCategoriaDto
                {
                    Categoria = row["categoria"].ToString() ?? "",
                    CantidadAlquileres = Convert.ToInt32(row["cantidad"]),
                    TotalIngresos = Convert.ToDecimal(row["total_ingresos"])
                });
            }
            return lista;
        }

        public static List<AlquilerFinalizadoDto> ObtenerFinalizadosRecientes()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT TOP 15 a.id_alquiler,
                                c.apellido + ', ' + c.nombre AS cliente,
                                v.matricula + ' — ' + ma.marca + ' ' + mo.modelo AS vehiculo,
                                a.fechaEntregaReal,
                                a.fechaEntregaDevolucion,
                                (r.precio_diario_pactado *
                                 CASE WHEN DATEDIFF(DAY, a.fechaEntregaReal, a.fechaEntregaDevolucion) < 1 THEN 1
                                      ELSE DATEDIFF(DAY, a.fechaEntregaReal, a.fechaEntregaDevolucion) END
                                 + ISNULL(a.montoMora, 0)) AS monto_total
                  FROM Alquiler a
                  INNER JOIN Reserva r ON r.id_reserva = a.id_reserva
                  INNER JOIN Cliente c ON c.id_cliente = r.id_cliente
                  INNER JOIN Vehiculo v ON v.id_vehiculo = r.id_vehiculo
                  INNER JOIN Modelo mo ON mo.id_modelo = v.id_modelo
                  INNER JOIN Marca ma ON ma.id_marca = mo.id_marca
                  WHERE a.activo = 0
                  ORDER BY a.fechaEntregaDevolucion DESC");
            var lista = new List<AlquilerFinalizadoDto>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new AlquilerFinalizadoDto
                {
                    IdAlquiler = Convert.ToInt32(row["id_alquiler"]),
                    Cliente = row["cliente"].ToString() ?? "",
                    Vehiculo = row["vehiculo"].ToString() ?? "",
                    FechaEntrega = Convert.ToDateTime(row["fechaEntregaReal"]),
                    FechaDevolucion = row["fechaEntregaDevolucion"] != DBNull.Value ? Convert.ToDateTime(row["fechaEntregaDevolucion"]) : null,
                    MontoTotal = Convert.ToDecimal(row["monto_total"])
                });
            }
            return lista;
        }
    }
}
