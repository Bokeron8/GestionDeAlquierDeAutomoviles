using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class ModeloVehiculo
    {
        public int IdModelo { get; set; }
        public string NombreModelo { get; set; }
        public int IdMarca { get; set; }
        public bool Activo { get; set; }

        /// <summary>
        /// Resolved brand name populated only by the listing query; empty when the model
        /// was loaded by id, which is why Map guards the optional column.
        /// </summary>
        public string NombreMarca { get; set; } = "";

        /// <summary>
        /// Identity label used by lists: "Toyota Corolla".
        /// </summary>
        public string Descripcion => $"{NombreMarca} {NombreModelo}";

        public static List<ModeloVehiculo> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT mo.*, ma.marca AS marca_nombre
                  FROM Modelo mo
                  INNER JOIN Marca ma ON ma.id_marca = mo.id_marca
                  ORDER BY mo.modelo");
            var lista = new List<ModeloVehiculo>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static ModeloVehiculo? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Modelo WHERE id_modelo = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(ModeloVehiculo m)
        {
            if (m.IdModelo == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Modelo (modelo, id_marca, activo) VALUES (@modelo, @id_marca, @activo)",
                    [
                        new SqlParameter("@modelo", m.NombreModelo),
                        new SqlParameter("@id_marca", m.IdMarca),
                        new SqlParameter("@activo", m.Activo)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Modelo SET modelo = @modelo, id_marca = @id_marca, activo = @activo WHERE id_modelo = @id_modelo",
                    [
                        new SqlParameter("@modelo", m.NombreModelo),
                        new SqlParameter("@id_marca", m.IdMarca),
                        new SqlParameter("@activo", m.Activo),
                        new SqlParameter("@id_modelo", m.IdModelo)
                    ]);
            }
        }

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Modelo SET activo = 0 WHERE id_modelo = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        public static bool Restaurar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Modelo SET activo = 1 WHERE id_modelo = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        public static bool EsNombreDuplicado(string nombre, int idMarca, int? idExcluir = null)
        {
            string query = "SELECT COUNT(*) FROM Modelo WHERE modelo = @modelo AND id_marca = @id_marca";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@modelo", nombre),
                new SqlParameter("@id_marca", idMarca)
            };
            if (idExcluir.HasValue)
            {
                query += " AND id_modelo <> @idExcluir";
                parameters.Add(new SqlParameter("@idExcluir", idExcluir.Value));
            }
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters.ToArray())) > 0;
        }

        private static ModeloVehiculo Map(DataRow row)
        {
            return new ModeloVehiculo
            {
                IdModelo = Convert.ToInt32(row["id_modelo"]),
                NombreModelo = row["modelo"].ToString()!,
                IdMarca = Convert.ToInt32(row["id_marca"]),
                Activo = Convert.ToBoolean(row["activo"]),
                NombreMarca = row.Table.Columns.Contains("marca_nombre") ? row["marca_nombre"].ToString()! : ""
            };
        }
    }
}
