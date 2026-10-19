using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Controlador
{
    public class VehiculoController
    {
        public List<string> ValidarVehiculo(Vehiculo veh, bool esNuevo)
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(veh.Matricula))
                errores.Add("La matrícula es obligatoria.");
            if (string.IsNullOrWhiteSpace(veh.Chasis))
                errores.Add("El número de chasis es obligatorio.");
            if (string.IsNullOrWhiteSpace(veh.Color))
                errores.Add("El color es obligatorio.");
            if (veh.Anio < 1900 || veh.Anio > DateTime.Today.Year + 1)
                errores.Add("El año del vehículo no es válido.");
            if (veh.IdModelo <= 0)
                errores.Add("Debe seleccionar un modelo.");
            if (veh.IdCategoria <= 0)
                errores.Add("Debe seleccionar una categoría.");

            if (!string.IsNullOrWhiteSpace(veh.Matricula) && Vehiculo.EsMatriculaDuplicada(veh.Matricula, esNuevo ? null : veh.IdVehiculo))
                errores.Add("La matrícula ya se encuentra registrada en otro vehículo.");
            if (!string.IsNullOrWhiteSpace(veh.Chasis) && Vehiculo.EsChasisDuplicado(veh.Chasis, esNuevo ? null : veh.IdVehiculo))
                errores.Add("El número de chasis ya se encuentra registrado en otro vehículo.");

            return errores;
        }

        public List<Vehiculo> Listar()
        {
            return Vehiculo.ObtenerTodos();
        }

        public Vehiculo? BuscarPorId(int id)
        {
            return Vehiculo.ObtenerPorId(id);
        }

        public int Guardar(Vehiculo veh)
        {
            return Vehiculo.Guardar(veh);
        }

        public bool Eliminar(int id)
        {
            return Vehiculo.Eliminar(id);
        }

        public List<ModeloVehiculo> ObtenerModelos()
        {
            return ModeloVehiculo.ObtenerTodos();
        }

        public List<Categoria> ObtenerCategorias()
        {
            return Categoria.ObtenerTodos();
        }
    }
}
