using System.Data;
using Microsoft.Data.SqlClient;
using GestionDeAlquierDeAutomoviles;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string? Descripcion { get; set; }

        public static List<Rol> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT id_rol, rol, descripcion FROM Rol ORDER BY rol");
            var lista = new List<Rol>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Rol
                {
                    IdRol = Convert.ToInt32(row["id_rol"]),
                    NombreRol = row["rol"].ToString()!,
                    Descripcion = row["descripcion"].ToString()
                });
            }
            return lista;
        }
    }
}
