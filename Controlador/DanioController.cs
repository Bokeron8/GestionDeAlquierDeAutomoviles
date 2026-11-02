using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Restaurar(int id)
        {
            return Danio.Restaurar(id);
        }

        /// <summary>
        /// Rentals selectable when recording a damage: only the ones still open, plus the
        /// rental the damage already points to, so editing an old record never has to
        /// reassign it to a different contract.
        /// </summary>
        public List<Alquiler> ObtenerAlquileres(int? incluirId = null)
        {
            var lista = Alquiler.ObtenerEnCurso();
            if (incluirId is int id && lista.All(a => a.IdAlquiler != id))
            {
                var actual = Alquiler.ObtenerPorId(id);
                if (actual != null) lista.Insert(0, actual);
            }
            return lista;
        }
    }
}
