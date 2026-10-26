using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }

        public static List<Estado> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Estado ORDER BY nombre");
            var lista = new List<Estado>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static Estado? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Estado WHERE id_estado = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(Estado e)
        {
            if (e.IdEstado == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Estado (nombre, descripcion, activo) VALUES (@nombre, @descripcion, @activo)",
                    [
                        new SqlParameter("@nombre", e.Nombre),
                        new SqlParameter("@descripcion", (object?)e.Descripcion ?? DBNull.Value),
                        new SqlParameter("@activo", e.Activo)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Estado SET nombre = @nombre, descripcion = @descripcion, activo = @activo WHERE id_estado = @id_estado",
                    [
                        new SqlParameter("@nombre", e.Nombre),
                        new SqlParameter("@descripcion", (object?)e.Descripcion ?? DBNull.Value),
                        new SqlParameter("@activo", e.Activo),
                        new SqlParameter("@id_estado", e.IdEstado)
                    ]);
            }
        }

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Estado SET activo = 0 WHERE id_estado = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        public static bool EsNombreDuplicado(string nombre, int? idExcluir = null)
        {
            string query = "SELECT COUNT(*) FROM Estado WHERE nombre = @nombre";
            var parameters = new List<SqlParameter> { new SqlParameter("@nombre", nombre) };
            if (idExcluir.HasValue)
            {
                query += " AND id_estado <> @idExcluir";
                parameters.Add(new SqlParameter("@idExcluir", idExcluir.Value));
            }
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters.ToArray())) > 0;
        }

        private static Estado Map(DataRow row)
        {
            return new Estado
            {
                IdEstado = Convert.ToInt32(row["id_estado"]),
                Nombre = row["nombre"].ToString()!,
                Descripcion = row["descripcion"]?.ToString(),
                Activo = Convert.ToBoolean(row["activo"])
            };
        }
    }
}
