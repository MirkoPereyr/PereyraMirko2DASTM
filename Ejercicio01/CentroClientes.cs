using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CentroClientes
    {
        private RepositorioClientes repositorioClientes;

        public CentroClientes()
        {
            repositorioClientes = new RepositorioClientes();
        }

        public void CrearCliente(string dni, string nombre, string email, string telefono, DateTime fechaNacimiento)
        {
			try
			{
				if (string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(telefono))
					throw new ArgumentException("Todos los campos son obligatorios");

                if (fechaNacimiento >= DateTime.Today)
                    throw new ArgumentException("La fecha de nacimiento no puede ser hoy o en el futuro");


                var client = new Cliente();
                client.Dni = dni;
                client.Nombre = nombre;
                client.Email = email;
                client.Telefono = telefono;
                client.FechaNacimiento = fechaNacimiento;

                repositorioClientes.AgregarCliente(client);
            }
			catch (Exception ex)
			{

				throw new ArgumentException($"Error al ingresar cliente: {ex.Message}");
			}
        }

        public void ModificarCliente(string dni, string nuevoNombre, string nuevoTelefono, string nuevoEmail, DateTime nuevaFechaNacimiento)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(nuevoNombre) || string.IsNullOrWhiteSpace(nuevoTelefono) || string.IsNullOrWhiteSpace(nuevoEmail))
                    throw new ArgumentException("Todos los campos son obligatorios");

                if (nuevaFechaNacimiento >= DateTime.Today)
                    throw new ArgumentException("La fecha de nacimiento no puede ser hoy o en el futuro");

                repositorioClientes.ModificarCliente(dni, nuevoNombre, nuevoTelefono, nuevoEmail, nuevaFechaNacimiento);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al modificar cliente: {ex.Message}");
            }
            
        }

        public void EliminarCliente(string dni)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dni))
                    throw new ArgumentException("El DNI es obligatorio");

                repositorioClientes.EliminarCliente(dni);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al eliminar cliente: {ex.Message}");
            }
        }

        public Cliente BuscarClientePorDni(string dni)
        {
            return repositorioClientes.BuscarCliente(dni);
        }

        public List<Cliente> BuscarClientesPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacio.");
            return repositorioClientes.BuscarClientesPorNombre(nombre);
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return repositorioClientes.ObtenerTodosLosClientes();
        }
    }
}
