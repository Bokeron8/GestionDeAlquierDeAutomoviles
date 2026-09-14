using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class EmpleadoController
    {
        public List<string> ValidarEmpleado(Empleado emp, bool esNuevo)
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(emp.Nombre))
                errores.Add("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(emp.Apellido))
                errores.Add("El apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(emp.Dni))
                errores.Add("El DNI es obligatorio.");
            else if (!Regex.IsMatch(emp.Dni, @"^\d+$"))
                errores.Add("El DNI debe contener solo dígitos numéricos.");
            if (string.IsNullOrWhiteSpace(emp.Usuario))
                errores.Add("El usuario es obligatorio.");
            if (esNuevo && string.IsNullOrWhiteSpace(emp.Contrasenia))
                errores.Add("La contraseña es obligatoria para un nuevo empleado.");
            else if (!string.IsNullOrWhiteSpace(emp.Contrasenia) && emp.Contrasenia.Length < 6)
                errores.Add("La contraseña debe tener al menos 6 caracteres.");
            if (emp.IdRol <= 0)
                errores.Add("Debe seleccionar un rol.");

            if (emp.FechaNacimiento > DateTime.Today)
                errores.Add("La fecha de nacimiento no puede ser futura.");
            if (emp.FechaContratacion > DateTime.Today)
                errores.Add("La fecha de contratación no puede ser futura.");

            if (!string.IsNullOrWhiteSpace(emp.Correo) && !Regex.IsMatch(emp.Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errores.Add("El correo electrónico no tiene un formato válido.");

            if (!string.IsNullOrWhiteSpace(emp.Telefono) && !Regex.IsMatch(emp.Telefono, @"^[\d+\-\s()]+$"))
                errores.Add("El teléfono contiene caracteres no permitidos.");

            if (Empleado.EsDniDuplicado(emp.Dni, esNuevo ? null : emp.IdEmpleado))
                errores.Add("El DNI ya está registrado en otro empleado.");
            if (!string.IsNullOrWhiteSpace(emp.Correo) && Empleado.EsCorreoDuplicado(emp.Correo, esNuevo ? null : emp.IdEmpleado))
                errores.Add("El correo electrónico ya está registrado en otro empleado.");
            if (Empleado.EsUsuarioDuplicado(emp.Usuario, esNuevo ? null : emp.IdEmpleado))
                errores.Add("El nombre de usuario ya está registrado en otro empleado.");

            return errores;
        }

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
