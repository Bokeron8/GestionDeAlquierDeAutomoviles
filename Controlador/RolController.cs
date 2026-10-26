using System;
using System.Collections.Generic;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class RolController
    {
        public List<string> ValidarRol(Rol rol)
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(rol.NombreRol))
                errores.Add("El nombre del rol es obligatorio.");
            else if (Rol.EsRolDuplicado(rol.NombreRol, rol.IdRol == 0 ? null : rol.IdRol))
                errores.Add("Ya existe un rol con ese nombre.");
            return errores;
        }

        public List<Rol> Listar()
        {
            return Rol.ObtenerTodos();
        }

        public Rol? BuscarPorId(int id)
        {
            return Rol.ObtenerPorId(id);
        }

        public int Guardar(Rol rol)
        {
            return Rol.Guardar(rol);
        }

        public bool Eliminar(int id)
        {
            return Rol.Eliminar(id);
        }
    }
}
