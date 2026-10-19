using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Matricula { get; set; }
        public string Chasis { get; set; }
        public string Color { get; set; }
        public int Anio { get; set; }
        public bool Activo { get; set; }
        public int IdModelo { get; set; }
        public int IdCategoria { get; set; }

        public static List<Vehiculo> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Vehiculo ORDER BY matricula");
            var lista = new List<Vehiculo>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static Vehiculo? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Vehiculo WHERE id_vehiculo = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(Vehiculo v)
        {
            if (v.IdVehiculo == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Vehiculo (matricula, chasis, color, anio, activo, id_modelo, id_categoria) 
                      VALUES (@matricula, @chasis, @color, @anio, @activo, @id_modelo, @id_categoria)",
                    [
                        new SqlParameter("@matricula", v.Matricula),
                        new SqlParameter("@chasis", v.Chasis),
                        new SqlParameter("@color", v.Color),
                        new SqlParameter("@anio", v.Anio),
                        new SqlParameter("@activo", v.Activo),
                        new SqlParameter("@id_modelo", v.IdModelo),
                        new SqlParameter("@id_categoria", v.IdCategoria)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Vehiculo SET matricula=@matricula, chasis=@chasis, color=@color, anio=@anio, activo=@activo, id_modelo=@id_modelo, id_categoria=@id_categoria WHERE id_vehiculo=@id_vehiculo",
                    [
                        new SqlParameter("@matricula", v.Matricula),
                        new SqlParameter("@chasis", v.Chasis),
                        new SqlParameter("@color", v.Color),
                        new SqlParameter("@anio", v.Anio),
                        new SqlParameter("@activo", v.Activo),
                        new SqlParameter("@id_modelo", v.IdModelo),
                        new SqlParameter("@id_categoria", v.IdCategoria),
                        new SqlParameter("@id_vehiculo", v.IdVehiculo)
                    ]);
            }
        }

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Vehiculo SET activo = 0 WHERE id_vehiculo = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        public static bool EsMatriculaDuplicada(string matricula, int? idExcluir = null)
        {
            string query = "SELECT COUNT(*) FROM Vehiculo WHERE matricula = @matricula";
            var parameters = new List<SqlParameter> { new SqlParameter("@matricula", matricula) };
            if (idExcluir.HasValue)
            {
                query += " AND id_vehiculo <> @idExcluir";
                parameters.Add(new SqlParameter("@idExcluir", idExcluir.Value));
            }
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters.ToArray())) > 0;
        }

        public static bool EsChasisDuplicado(string chasis, int? idExcluir = null)
        {
            string query = "SELECT COUNT(*) FROM Vehiculo WHERE chasis = @chasis";
            var parameters = new List<SqlParameter> { new SqlParameter("@chasis", chasis) };
            if (idExcluir.HasValue)
            {
                query += " AND id_vehiculo <> @idExcluir";
                parameters.Add(new SqlParameter("@idExcluir", idExcluir.Value));
            }
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters.ToArray())) > 0;
        }

        private static Vehiculo Map(DataRow row)
        {
            return new Vehiculo
            {
                IdVehiculo = Convert.ToInt32(row["id_vehiculo"]),
                Matricula = row["matricula"].ToString()!,
                Chasis = row["chasis"].ToString()!,
                Color = row["color"].ToString()!,
                Anio = Convert.ToInt32(row["anio"]),
                Activo = Convert.ToBoolean(row["activo"]),
                IdModelo = Convert.ToInt32(row["id_modelo"]),
                IdCategoria = Convert.ToInt32(row["id_categoria"])
            };
        }
    }
}
