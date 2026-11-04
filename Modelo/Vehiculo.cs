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

        /// <summary>
        /// Resolved names populated only by the listing queries. A vehicle loaded by id
        /// leaves them empty, which is why Map guards every optional column.
        /// </summary>
        public string NombreMarca { get; set; } = "";
        public string NombreModelo { get; set; } = "";
        public string NombreCategoria { get; set; } = "";

        /// <summary>
        /// Identity label used by lists and pickers: "AB123CD — Toyota Corolla 2020".
        /// </summary>
        public string Descripcion => $"{Matricula} — {NombreMarca} {NombreModelo} {Anio}";

        /// <summary>
        /// Single column label for the narrow dashboard grid, where brand and model do not
        /// fit as two separate columns: "Toyota Corolla".
        /// </summary>
        public string MarcaModelo => $"{NombreMarca} {NombreModelo}".Trim();

        /// <summary>
        /// Only the vehicles that can still be picked for a new reservation. The
        /// management list keeps using ObtenerTodos so retired vehicles stay visible.
        /// </summary>
        public static List<Vehiculo> ObtenerActivos()
        {
            return ObtenerTodos().FindAll(v => v.Activo);
        }

        /// <summary>
        /// Vehicles the manager can rent right now: active, with no open rental and with no
        /// pending or confirmed reservation covering today. A reservation already in progress
        /// is excluded through its rental, so the two conditions never double count.
        /// </summary>
        public static List<Vehiculo> ObtenerDisponibles()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT v.*, ma.marca AS marca_nombre, mo.modelo AS modelo_nombre, ca.nombre AS categoria_nombre
                  FROM Vehiculo v
                  INNER JOIN Modelo mo ON mo.id_modelo = v.id_modelo
                  INNER JOIN Marca ma ON ma.id_marca = mo.id_marca
                  INNER JOIN Categoria ca ON ca.id_categoria = v.id_categoria
                  WHERE v.activo = 1
                    AND NOT EXISTS (SELECT 1
                                    FROM Alquiler a
                                    INNER JOIN Reserva r ON r.id_reserva = a.id_reserva
                                    WHERE r.id_vehiculo = v.id_vehiculo
                                      AND a.activo = 1)
                    AND NOT EXISTS (SELECT 1
                                    FROM Reserva r2
                                    WHERE r2.id_vehiculo = v.id_vehiculo
                                      AND r2.activo = 1
                                      AND r2.id_estado IN (@pendiente, @confirmada)
                                      AND @hoy BETWEEN r2.fecha_inicio_reserva AND r2.fecha_fin_reserva)
                  ORDER BY v.matricula",
                [
                    new SqlParameter("@pendiente", EstadosReserva.Pendiente),
                    new SqlParameter("@confirmada", EstadosReserva.Confirmada),
                    new SqlParameter("@hoy", DateTime.Today)
                ]);
            var lista = new List<Vehiculo>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static List<Vehiculo> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                @"SELECT v.*, ma.marca AS marca_nombre, mo.modelo AS modelo_nombre, ca.nombre AS categoria_nombre
                  FROM Vehiculo v
                  INNER JOIN Modelo mo ON mo.id_modelo = v.id_modelo
                  INNER JOIN Marca ma ON ma.id_marca = mo.id_marca
                  INNER JOIN Categoria ca ON ca.id_categoria = v.id_categoria
                  ORDER BY v.matricula");
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
                @"SELECT v.*, ma.marca AS marca_nombre, mo.modelo AS modelo_nombre, ca.nombre AS categoria_nombre
                  FROM Vehiculo v
                  INNER JOIN Modelo mo ON mo.id_modelo = v.id_modelo
                  INNER JOIN Marca ma ON ma.id_marca = mo.id_marca
                  INNER JOIN Categoria ca ON ca.id_categoria = v.id_categoria
                  WHERE v.id_vehiculo = @id",
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
                IdCategoria = Convert.ToInt32(row["id_categoria"]),
                NombreMarca = row.Table.Columns.Contains("marca_nombre") ? row["marca_nombre"].ToString()! : "",
                NombreModelo = row.Table.Columns.Contains("modelo_nombre") ? row["modelo_nombre"].ToString()! : "",
                NombreCategoria = row.Table.Columns.Contains("categoria_nombre") ? row["categoria_nombre"].ToString()! : ""
            };
        }
    }
}
