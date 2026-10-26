using System;
using System.Collections.Generic;
using System.Data;
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

        public static List<Danio> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Danio ORDER BY id_alquiler, zona");
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
                "SELECT * FROM Danio WHERE id_danio = @id",
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

        private static Danio Map(DataRow row)
        {
            return new Danio
            {
                IdDanio = Convert.ToInt32(row["id_danio"]),
                Zona = row["zona"].ToString()!,
                Descripcion = row["descripcion"].ToString()!,
                EvidenciaFotografica = row["evidenciaFotografica"]?.ToString(),
                Activo = Convert.ToBoolean(row["activo"]),
                IdAlquiler = Convert.ToInt32(row["id_alquiler"])
            };
        }
    }
}
