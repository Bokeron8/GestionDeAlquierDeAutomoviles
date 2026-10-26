using System;
using System.Collections.Generic;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class EstadoController
    {
        public List<string> ValidarEstado(Estado estado)
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(estado.Nombre))
                errores.Add("El nombre del estado es obligatorio.");
            else if (Estado.EsNombreDuplicado(estado.Nombre, estado.IdEstado == 0 ? null : estado.IdEstado))
                errores.Add("Ya existe un estado con ese nombre.");
            return errores;
        }

        public List<Estado> Listar()
        {
            return Estado.ObtenerTodos();
        }

        public Estado? BuscarPorId(int id)
        {
            return Estado.ObtenerPorId(id);
        }

        public int Guardar(Estado estado)
        {
            return Estado.Guardar(estado);
        }

        public bool Eliminar(int id)
        {
            return Estado.Eliminar(id);
        }
    }
}
