using System;
using System.Collections.Generic;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class DanioController
    {
        public List<string> ValidarDanio(Danio danio)
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(danio.Zona))
                errores.Add("La zona es obligatoria.");
            if (string.IsNullOrWhiteSpace(danio.Descripcion))
                errores.Add("La descripción es obligatoria.");
            if (danio.IdAlquiler <= 0)
                errores.Add("Debe seleccionar un alquiler.");
            return errores;
        }

        public List<Danio> Listar()
        {
            return Danio.ObtenerTodos();
        }

        public Danio? BuscarPorId(int id)
        {
            return Danio.ObtenerPorId(id);
        }

        public int Guardar(Danio danio)
        {
            return Danio.Guardar(danio);
        }

        public bool Eliminar(int id)
        {
            return Danio.Eliminar(id);
        }

        public List<Alquiler> ObtenerAlquileres()
        {
            return Alquiler.ObtenerTodos();
        }
    }
}
