using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GestionDeAlquierDeAutomoviles.Modelo
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }

        public static List<Estado> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Estado ORDER BY nombre");
            var lista = new List<Estado>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Estado
                {
                    IdEstado = Convert.ToInt32(row["id_estado"]),
                    Nombre = row["nombre"].ToString()!,
                    Descripcion = row["descripcion"]?.ToString(),
                    Activo = Convert.ToBoolean(row["activo"])
                });
            }
            return lista;
        }
    }
}
