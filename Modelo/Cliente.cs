using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string NroLicencia { get; set; }
        public DateTime VencimientoLicencia { get; set; }
        public string Provincia { get; set; }
        public bool Activo { get; set; }

        public static List<Cliente> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Cliente ORDER BY apellido, nombre");
            var lista = new List<Cliente>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static Cliente? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Cliente WHERE id_cliente = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(Cliente c)
        {
            if (c.IdCliente == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Cliente (nombre, apellido, dni, fecha_nacimiento, direccion, telefono, correo, nroLicencia, vencimientoLicencia, provincia, activo) 
                      VALUES (@nombre, @apellido, @dni, @fecha_nacimiento, @direccion, @telefono, @correo, @nroLicencia, @vencimientoLicencia, @provincia, @activo)",
                    [
                        new SqlParameter("@nombre", c.Nombre),
                        new SqlParameter("@apellido", c.Apellido),
                        new SqlParameter("@dni", c.Dni),
                        new SqlParameter("@fecha_nacimiento", c.FechaNacimiento),
                        new SqlParameter("@direccion", (object?)c.Direccion ?? DBNull.Value),
                        new SqlParameter("@telefono", c.Telefono),
                        new SqlParameter("@correo", c.Correo),
                        new SqlParameter("@nroLicencia", c.NroLicencia),
                        new SqlParameter("@vencimientoLicencia", c.VencimientoLicencia),
                        new SqlParameter("@provincia", c.Provincia),
                        new SqlParameter("@activo", c.Activo)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Cliente SET nombre=@nombre, apellido=@apellido, dni=@dni, fecha_nacimiento=@fecha_nacimiento, direccion=@direccion, telefono=@telefono, correo=@correo, nroLicencia=@nroLicencia, vencimientoLicencia=@vencimientoLicencia, provincia=@provincia, activo=@activo WHERE id_cliente=@id_cliente",
                    [
                        new SqlParameter("@nombre", c.Nombre),
                        new SqlParameter("@apellido", c.Apellido),
                        new SqlParameter("@dni", c.Dni),
                        new SqlParameter("@fecha_nacimiento", c.FechaNacimiento),
                        new SqlParameter("@direccion", (object?)c.Direccion ?? DBNull.Value),
                        new SqlParameter("@telefono", c.Telefono),
                        new SqlParameter("@correo", c.Correo),
                        new SqlParameter("@nroLicencia", c.NroLicencia),
                        new SqlParameter("@vencimientoLicencia", c.VencimientoLicencia),
                        new SqlParameter("@provincia", c.Provincia),
                        new SqlParameter("@activo", c.Activo),
                        new SqlParameter("@id_cliente", c.IdCliente)
                    ]);
            }
        }

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Cliente SET activo = 0 WHERE id_cliente = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        public static bool EsDniDuplicado(string dni, int? idExcluir = null)
        {
            string query = "SELECT COUNT(*) FROM Cliente WHERE dni = @dni";
            var parameters = new List<SqlParameter> { new SqlParameter("@dni", dni) };
            if (idExcluir.HasValue)
            {
                query += " AND id_cliente <> @idExcluir";
                parameters.Add(new SqlParameter("@idExcluir", idExcluir.Value));
            }
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters.ToArray())) > 0;
        }

        public static bool EsCorreoDuplicado(string correo, int? idExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(correo)) return false;
            string query = "SELECT COUNT(*) FROM Cliente WHERE correo = @correo";
            var parameters = new List<SqlParameter> { new SqlParameter("@correo", correo) };
            if (idExcluir.HasValue)
            {
                query += " AND id_cliente <> @idExcluir";
                parameters.Add(new SqlParameter("@idExcluir", idExcluir.Value));
            }
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters.ToArray())) > 0;
        }

        private static Cliente Map(DataRow row)
        {
            return new Cliente
            {
                IdCliente = Convert.ToInt32(row["id_cliente"]),
                Nombre = row["nombre"].ToString()!,
                Apellido = row["apellido"].ToString()!,
                Dni = row["dni"].ToString()!,
                FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]),
                Direccion = row["direccion"]?.ToString(),
                Telefono = row["telefono"].ToString()!,
                Correo = row["correo"].ToString()!,
                NroLicencia = row["nroLicencia"].ToString()!,
                VencimientoLicencia = Convert.ToDateTime(row["vencimientoLicencia"]),
                Provincia = row["provincia"].ToString()!,
                Activo = Convert.ToBoolean(row["activo"])
            };
        }
    }
}
