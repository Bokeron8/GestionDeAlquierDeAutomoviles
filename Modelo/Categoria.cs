using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }

        public static List<Categoria> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Categoria ORDER BY nombre");
            var lista = new List<Categoria>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static Categoria? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Categoria WHERE id_categoria = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(Categoria c)
        {
            if (c.IdCategoria == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Categoria (nombre, descripcion, activo) VALUES (@nombre, @descripcion, @activo)",
                    [
                        new SqlParameter("@nombre", c.Nombre),
                        new SqlParameter("@descripcion", (object?)c.Descripcion ?? DBNull.Value),
                        new SqlParameter("@activo", c.Activo)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Categoria SET nombre = @nombre, descripcion = @descripcion, activo = @activo WHERE id_categoria = @id_categoria",
                    [
                        new SqlParameter("@nombre", c.Nombre),
                        new SqlParameter("@descripcion", (object?)c.Descripcion ?? DBNull.Value),
                        new SqlParameter("@activo", c.Activo),
                        new SqlParameter("@id_categoria", c.IdCategoria)
                    ]);
            }
        }

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Categoria SET activo = 0 WHERE id_categoria = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        private static Categoria Map(DataRow row)
        {
            return new Categoria
            {
                IdCategoria = Convert.ToInt32(row["id_categoria"]),
                Nombre = row["nombre"].ToString()!,
                Descripcion = row["descripcion"]?.ToString(),
                Activo = Convert.ToBoolean(row["activo"])
            };
        }
    }
}
