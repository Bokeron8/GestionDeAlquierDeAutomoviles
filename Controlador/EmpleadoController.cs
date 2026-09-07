using System.Collections.Generic;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class EmpleadoController
    {
        public List<Empleado> Listar()
        {
            return Empleado.ObtenerTodos();
        }

        public Empleado? BuscarPorId(int id)
        {
            return Empleado.ObtenerPorId(id);
        }

        public List<Empleado> Buscar(string termino)
        {
            return Empleado.Buscar(termino);
        }

        public int Guardar(Empleado emp)
        {
            return Empleado.Guardar(emp);
        }

        public bool Eliminar(int id)
        {
            return Empleado.Eliminar(id);
        }

        public List<Rol> ObtenerRoles()
        {
            return Rol.ObtenerTodos();
        }
    }
}
