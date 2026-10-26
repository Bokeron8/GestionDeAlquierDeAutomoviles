using System;
using System.Collections.Generic;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class ModeloController
    {
        public List<string> ValidarModelo(ModeloVehiculo modelo)
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(modelo.NombreModelo))
                errores.Add("El nombre del modelo es obligatorio.");
            if (modelo.IdMarca <= 0)
                errores.Add("Debe seleccionar una marca.");
            if (!string.IsNullOrWhiteSpace(modelo.NombreModelo) && modelo.IdMarca > 0
                && ModeloVehiculo.EsNombreDuplicado(modelo.NombreModelo, modelo.IdMarca, modelo.IdModelo == 0 ? null : modelo.IdModelo))
                errores.Add("Ya existe un modelo con ese nombre para esa marca.");
            return errores;
        }

        public List<ModeloVehiculo> Listar()
        {
            return ModeloVehiculo.ObtenerTodos();
        }

        public ModeloVehiculo? BuscarPorId(int id)
        {
            return ModeloVehiculo.ObtenerPorId(id);
        }

        public int Guardar(ModeloVehiculo modelo)
        {
            return ModeloVehiculo.Guardar(modelo);
        }

        public bool Eliminar(int id)
        {
            return ModeloVehiculo.Eliminar(id);
        }

        public List<Marca> ObtenerMarcas()
        {
            return Marca.ObtenerTodos();
        }
    }
}
