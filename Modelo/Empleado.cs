using System.Data;
using Microsoft.Data.SqlClient;
using GestionDeAlquierDeAutomoviles;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? Usuario { get; set; }
        public string? Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; }
        public int IdRol { get; set; }

        public static List<Empleado> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Empleado ORDER BY nombre");
            var lista = new List<Empleado>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(Map(row));
            }
            return lista;
        }

        public static Empleado? ObtenerPorId(int id)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM Empleado WHERE id_empleado = @id",
                [new SqlParameter("@id", id)]);
            return dt.Rows.Count > 0 ? Map(dt.Rows[0]) : null;
        }

        public static int Guardar(Empleado emp)
        {
            if (emp.IdEmpleado == 0)
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO Empleado (usuario, contrasenia, nombre, apellido, dni, fecha_nacimiento, direccion, telefono, correo, fecha_contratacion, activo, id_rol) 
                      VALUES (@usuario, @contrasenia, @nombre, @apellido, @dni, @fecha_nacimiento, @direccion, @telefono, @correo, @fecha_contratacion, @activo, @id_rol)",
                    [
                        new SqlParameter("@usuario", emp.Usuario ?? ""),
                        new SqlParameter("@contrasenia", emp.Contrasenia ?? ""),
                        new SqlParameter("@nombre", emp.Nombre),
                        new SqlParameter("@apellido", emp.Apellido),
                        new SqlParameter("@dni", emp.Dni),
                        new SqlParameter("@fecha_nacimiento", emp.FechaNacimiento),
                        new SqlParameter("@direccion", (object?)emp.Direccion ?? DBNull.Value),
                        new SqlParameter("@telefono", (object?)emp.Telefono ?? DBNull.Value),
                        new SqlParameter("@correo", (object?)emp.Correo ?? DBNull.Value),
                        new SqlParameter("@fecha_contratacion", emp.FechaContratacion),
                        new SqlParameter("@activo", emp.Activo),
                        new SqlParameter("@id_rol", emp.IdRol)
                    ]);
            }
            else
            {
                return DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Empleado SET usuario=@usuario, contrasenia=@contrasenia, nombre=@nombre, apellido=@apellido, dni=@dni, fecha_nacimiento=@fecha_nacimiento, direccion=@direccion, telefono=@telefono, correo=@correo, fecha_contratacion=@fecha_contratacion, activo=@activo, id_rol=@id_rol WHERE id_empleado=@id_empleado",
                    [
                        new SqlParameter("@usuario", emp.Usuario ?? ""),
                        new SqlParameter("@contrasenia", emp.Contrasenia ?? ""),
                        new SqlParameter("@nombre", emp.Nombre),
                        new SqlParameter("@apellido", emp.Apellido),
                        new SqlParameter("@dni", emp.Dni),
                        new SqlParameter("@fecha_nacimiento", emp.FechaNacimiento),
                        new SqlParameter("@direccion", (object?)emp.Direccion ?? DBNull.Value),
                        new SqlParameter("@telefono", (object?)emp.Telefono ?? DBNull.Value),
                        new SqlParameter("@correo", (object?)emp.Correo ?? DBNull.Value),
                        new SqlParameter("@fecha_contratacion", emp.FechaContratacion),
                        new SqlParameter("@activo", emp.Activo),
                        new SqlParameter("@id_rol", emp.IdRol),
                        new SqlParameter("@id_empleado", emp.IdEmpleado)
                    ]);
            }
        }

        public static bool Eliminar(int id)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Empleado SET activo = 0 WHERE id_empleado = @id",
                [new SqlParameter("@id", id)]);
            return rows > 0;
        }

        private static Empleado Map(DataRow row)
        {
            return new Empleado
            {
                IdEmpleado = Convert.ToInt32(row["id_empleado"]),
                Usuario = row["usuario"].ToString(),
                Contrasenia = row["contrasenia"].ToString(),
                Nombre = row["nombre"].ToString()!,
                Apellido = row["apellido"].ToString()!,
                Dni = row["dni"].ToString()!,
                FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]),
                Direccion = row["direccion"].ToString(),
                Telefono = row["telefono"].ToString(),
                Correo = row["correo"].ToString(),
                FechaContratacion = Convert.ToDateTime(row["fecha_contratacion"]),
                Activo = Convert.ToBoolean(row["activo"]),
                IdRol = Convert.ToInt32(row["id_rol"])
            };
        }
    }
}
