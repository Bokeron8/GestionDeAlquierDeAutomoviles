using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class ClienteController
    {
        public List<string> ValidarCliente(Cliente cli, bool esNuevo)
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(cli.Nombre))
                errores.Add("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(cli.Apellido))
                errores.Add("El apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(cli.Dni))
                errores.Add("El DNI es obligatorio.");
            else if (!Regex.IsMatch(cli.Dni, @"^\d+$"))
                errores.Add("El DNI debe contener solo dígitos numéricos.");
            if (string.IsNullOrWhiteSpace(cli.Telefono))
                errores.Add("El teléfono es obligatorio.");
            if (string.IsNullOrWhiteSpace(cli.Correo))
                errores.Add("El correo electrónico es obligatorio.");
            else if (!Regex.IsMatch(cli.Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errores.Add("El correo electrónico no tiene un formato válido.");
            if (string.IsNullOrWhiteSpace(cli.NroLicencia))
                errores.Add("El número de licencia es obligatorio.");
            if (string.IsNullOrWhiteSpace(cli.Provincia))
                errores.Add("La provincia es obligatoria.");

            if (cli.FechaNacimiento > DateTime.Today)
                errores.Add("La fecha de nacimiento no puede ser futura.");
            if (cli.VencimientoLicencia < DateTime.Today)
                errores.Add("La licencia de conducir se encuentra vencida.");

            if (!string.IsNullOrWhiteSpace(cli.Dni) && Cliente.EsDniDuplicado(cli.Dni, esNuevo ? null : cli.IdCliente))
                errores.Add("El DNI ya se encuentra registrado en otro cliente.");
            if (!string.IsNullOrWhiteSpace(cli.Correo) && Cliente.EsCorreoDuplicado(cli.Correo, esNuevo ? null : cli.IdCliente))
                errores.Add("El correo electrónico ya se encuentra registrado en otro cliente.");

            return errores;
        }

        public List<Cliente> Listar()
        {
            return Cliente.ObtenerTodos();
        }

        public Cliente? BuscarPorId(int id)
        {
            return Cliente.ObtenerPorId(id);
        }

        public int Guardar(Cliente cli)
        {
            return Cliente.Guardar(cli);
        }

        public bool Eliminar(int id)
        {
            return Cliente.Eliminar(id);
        }
    }
}
