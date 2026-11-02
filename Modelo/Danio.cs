using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Danio
    {
        public int IdDanio { get; set; }
        public string Zona { get; set; }
        public string Descripcion { get; set; }
        public string? EvidenciaFotografica { get; set; }
        public bool Activo { get; set; }
        public int IdAlquiler { get; set; }

        /// <summary>
        /// Resolved rental data, populated only by the queries that join the client and
        /// vehicle. A plain SELECT * leaves them empty, which is why Map guards them.
        /// </summary>
        public string NombreCliente { get; set; } = "";
        public string DniCliente { get; set; } = "";
        public string MatriculaVehiculo { get; set; } = "";
        public DateTime? FechaEntregaAlquiler { get; set; }
        public bool? AlquilerActivo { get; set; }

        /// <summary>
        /// Identity label used by the list: "Pérez, Juan — DNI 30123456".
        /// </summary>
        public string DescripcionCliente => NombreCliente.Length == 0
            ? ""
            : $"{NombreCliente} — DNI {DniCliente}";

        /// <summary>
        /// Lifecycle label of the rental the damage belongs to.
        /// </summary>
        public string EstadoAlquiler => AlquilerActivo switch
        {
            true => "En curso",
            false => "Devuelto",
            _ => ""
        };

        /// <summary>
        /// Only the file name reaches the grid: the full path would eat the whole column
        /// and tells the operator nothing extra.
        /// </summary>
        public string EvidenciaArchivo => string.IsNullOrWhiteSpace(EvidenciaFotografica)
            ? ""
            : Path.GetFileName(EvidenciaFotografica);

        private const string SelectConAlquiler =
            @"SELECT d.*,
                     c.apellido + ', ' + c.nombre AS cliente_nombre, c.dni AS cliente_dni,
                     v.matricula AS vehiculo_matricula,
                     a.fechaEntregaReal AS alquiler_fecha_entrega, a.activo AS alquiler_activo
              FROM Danio d
              INNER JOIN Alquiler a ON a.id_alquiler = d.id_alquiler
              INNER JOIN Reserva r ON r.id_reserva = a.id_reserva
              INNER JOIN Cliente c ON c.id_cliente = r.id_cliente
              INNER JOIN Vehiculo v ON v.id_vehiculo = r.id_vehiculo";

        public static List<Danio> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                $"{SelectConAlquiler} ORDER BY c.apellido, c.nombre, d.zona");
            var lista = new List<Danio>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static Danio? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                $"{SelectConAlquiler} WHERE d.id_danio = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(Danio d)
        {
            if (d.IdDanio == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Danio (zona, descripcion, evidenciaFotografica, activo, id_alquiler) VALUES (@zona, @descripcion, @evidenciaFotografica, @activo, @id_alquiler)",
                    [
                        new SqlParameter("@zona", d.Zona),
                        new SqlParameter("@descripcion", d.Descripcion),
                        new SqlParameter("@evidenciaFotografica", (object?)d.EvidenciaFotografica ?? DBNull.Value),
                        new SqlParameter("@activo", d.Activo),
                        new SqlParameter("@id_alquiler", d.IdAlquiler)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Danio SET zona = @zona, descripcion = @descripcion, evidenciaFotografica = @evidenciaFotografica, activo = @activo, id_alquiler = @id_alquiler WHERE id_danio = @id_danio",
                    [
                        new SqlParameter("@zona", d.Zona),
                        new SqlParameter("@descripcion", d.Descripcion),
                        new SqlParameter("@evidenciaFotografica", (object?)d.EvidenciaFotografica ?? DBNull.Value),
                        new SqlParameter("@activo", d.Activo),
                        new SqlParameter("@id_alquiler", d.IdAlquiler),
                        new SqlParameter("@id_danio", d.IdDanio)
                    ]);
            }
        }

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Danio SET activo = 0 WHERE id_danio = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        public static bool Restaurar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Danio SET activo = 1 WHERE id_danio = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        private static Danio Map(DataRow row)
        {
            return new Danio
            {
                IdDanio = Convert.ToInt32(row["id_danio"]),
                Zona = row["zona"].ToString()!,
                Descripcion = row["descripcion"].ToString()!,
                EvidenciaFotografica = row["evidenciaFotografica"]?.ToString(),
                Activo = Convert.ToBoolean(row["activo"]),
                IdAlquiler = Convert.ToInt32(row["id_alquiler"]),
                NombreCliente = TextoOpcional(row, "cliente_nombre"),
                DniCliente = TextoOpcional(row, "cliente_dni"),
                MatriculaVehiculo = TextoOpcional(row, "vehiculo_matricula"),
                FechaEntregaAlquiler = row.Table.Columns.Contains("alquiler_fecha_entrega")
                    && row["alquiler_fecha_entrega"] != DBNull.Value
                    ? Convert.ToDateTime(row["alquiler_fecha_entrega"])
                    : null,
                AlquilerActivo = row.Table.Columns.Contains("alquiler_activo")
                    && row["alquiler_activo"] != DBNull.Value
                    ? Convert.ToBoolean(row["alquiler_activo"])
                    : null
            };
        }

        /// <summary>
        /// Reads a column that only the joined query selects, so loading a damage through
        /// a plain SELECT * never breaks on a missing column.
        /// </summary>
        private static string TextoOpcional(DataRow row, string columna)
        {
            return row.Table.Columns.Contains(columna) && row[columna] != DBNull.Value
                ? row[columna].ToString() ?? ""
                : "";
        }
    }
}
