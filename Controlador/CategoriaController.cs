using System;
using System.Collections.Generic;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class CategoriaController
    {
        public List<string> ValidarCategoria(Categoria cat)
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(cat.Nombre))
                errores.Add("El nombre de la categoría es obligatorio.");
            return errores;
        }

        public List<Categoria> Listar()
        {
            return Categoria.ObtenerTodos();
        }

        public Categoria? BuscarPorId(int id)
        {
            return Categoria.ObtenerPorId(id);
        }

        public int Guardar(Categoria cat)
        {
            return Categoria.Guardar(cat);
        }

        public bool Eliminar(int id)
        {
            return Categoria.Eliminar(id);
        }
    }
}
