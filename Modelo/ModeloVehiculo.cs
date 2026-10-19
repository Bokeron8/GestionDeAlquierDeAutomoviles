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

        public static List<ModeloVehiculo> ObtenerTodos()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Modelo ORDER BY modelo");
            var lista = new List<ModeloVehiculo>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new ModeloVehiculo
                {
                    IdModelo = Convert.ToInt32(row["id_modelo"]),
                    NombreModelo = row["modelo"].ToString()!,
                    IdMarca = Convert.ToInt32(row["id_marca"]),
                    Activo = Convert.ToBoolean(row["activo"])
                });
            }
            return lista;
        }
    }
}
