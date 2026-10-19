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
                lista.Add(new Categoria
                {
                    IdCategoria = Convert.ToInt32(row["id_categoria"]),
                    Nombre = row["nombre"].ToString()!,
                    Descripcion = row["descripcion"]?.ToString(),
                    Activo = Convert.ToBoolean(row["activo"])
                });
            }
            return lista;
        }
    }
}
