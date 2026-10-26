using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }

        public static List<Rol> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Rol ORDER BY rol");
            var lista = new List<Rol>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static Rol? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Rol WHERE id_rol = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(Rol r)
        {
            if (r.IdRol == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Rol (rol, descripcion, activo) VALUES (@rol, @descripcion, @activo)",
                    [
                        new SqlParameter("@rol", r.NombreRol),
                        new SqlParameter("@descripcion", (object?)r.Descripcion ?? DBNull.Value),
                        new SqlParameter("@activo", r.Activo)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Rol SET rol = @rol, descripcion = @descripcion, activo = @activo WHERE id_rol = @id_rol",
                    [
                        new SqlParameter("@rol", r.NombreRol),
                        new SqlParameter("@descripcion", (object?)r.Descripcion ?? DBNull.Value),
                        new SqlParameter("@activo", r.Activo),
                        new SqlParameter("@id_rol", r.IdRol)
                    ]);
            }
        }

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Rol SET activo = 0 WHERE id_rol = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        public static bool EsRolDuplicado(string rol, int? idExcluir = null)
        {
            string query = "SELECT COUNT(*) FROM Rol WHERE rol = @rol";
            var parameters = new List<SqlParameter> { new SqlParameter("@rol", rol) };
            if (idExcluir.HasValue)
            {
                query += " AND id_rol <> @idExcluir";
                parameters.Add(new SqlParameter("@idExcluir", idExcluir.Value));
            }
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters.ToArray())) > 0;
        }

        private static Rol Map(DataRow row)
        {
            return new Rol
            {
                IdRol = Convert.ToInt32(row["id_rol"]),
                NombreRol = row["rol"].ToString()!,
                Descripcion = row["descripcion"]?.ToString(),
                Activo = Convert.ToBoolean(row["activo"])
            };
        }
    }
}
