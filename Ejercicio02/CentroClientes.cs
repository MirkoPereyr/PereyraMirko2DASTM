using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class CentroClientes
    {
        private RepositorioClientes repositorioClientes;

        public CentroClientes()
        {
            repositorioClientes = new RepositorioClientes();
        }


        public void AgregarCliente(string codigoCliente, string nombre, string apellido, string dni, DateTime fechaNacimiento, Paquete paquete)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigoCliente) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(dni))
                    throw new Exception("Todos los campos del cliente son obligatorios.");

                if (fechaNacimiento >= DateTime.Today)
                    throw new ArgumentException("La fecha de nacimiento no puede ser hoy o en el futuro.");

                var cliente = new Cliente();
                cliente.CodigoCliente = codigoCliente;
                cliente.Nombre = nombre;
                cliente.Apellido = apellido;
                cliente.Dni = dni;
                cliente.FechaNacimiento = fechaNacimiento;
                cliente.PaqueteContratado = paquete;




                repositorioClientes.AgregarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar cliente: {ex.Message}");
            }
        }

        public void ModificarCliente(string dni, string nuevoNombre, string nuevoApellido, DateTime nuevaFechaNacimiento, Paquete nuevoPaquete)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nuevoNombre) || string.IsNullOrWhiteSpace(nuevoApellido))
                    throw new Exception("Nombre y apellido no pueden estar vacíos.");


                repositorioClientes.ModificarCliente(dni, nuevoNombre, nuevoApellido, nuevaFechaNacimiento, nuevoPaquete);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al modificar cliente: {ex.Message}");
            }
        }

        public void EliminarCliente(string dni)
        {
            try
            {
                repositorioClientes.EliminarCliente(dni);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar cliente: {ex.Message}");
            }
        }

        public Cliente? BuscarCliente(string dni)
        {
            return repositorioClientes.BuscarCliente(dni);
        }

        public List<Cliente> ObtenerTodos()
        {
            return repositorioClientes.ObtenerTodos();
        }
    }
}
