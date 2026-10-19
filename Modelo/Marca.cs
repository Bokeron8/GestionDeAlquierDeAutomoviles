using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static List<Marca> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Marca ORDER BY marca");
            var lista = new List<Marca>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static Marca? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Marca WHERE id_marca = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(Marca m)
        {
            if (m.IdMarca == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Marca (marca, activo) VALUES (@marca, @activo)",
                    [
                        new SqlParameter("@marca", m.Nombre),
                        new SqlParameter("@activo", m.Activo)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Marca SET marca = @marca, activo = @activo WHERE id_marca = @id_marca",
                    [
                        new SqlParameter("@marca", m.Nombre),
                        new SqlParameter("@activo", m.Activo),
                        new SqlParameter("@id_marca", m.IdMarca)
                    ]);
            }
        }

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Marca SET activo = 0 WHERE id_marca = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        private static Marca Map(DataRow row)
        {
            return new Marca
            {
                IdMarca = Convert.ToInt32(row["id_marca"]),
                Nombre = row["marca"].ToString()!,
                Activo = Convert.ToBoolean(row["activo"])
            };
        }
    }
}
