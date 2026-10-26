using System;
using System.Collections.Generic;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class MarcaController
    {
        public List<string> ValidarMarca(Marca marca)
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(marca.Nombre))
                errores.Add("El nombre de la marca es obligatorio.");
            else if (Marca.EsNombreDuplicado(marca.Nombre, marca.IdMarca == 0 ? null : marca.IdMarca))
                errores.Add("Ya existe una marca con ese nombre.");
            return errores;
        }

        public List<Marca> Listar()
        {
            return Marca.ObtenerTodos();
        }

        public Marca? BuscarPorId(int id)
        {
            return Marca.ObtenerPorId(id);
        }

        public int Guardar(Marca marca)
        {
            return Marca.Guardar(marca);
        }

        public bool Eliminar(int id)
        {
            return Marca.Eliminar(id);
        }
    }
}
