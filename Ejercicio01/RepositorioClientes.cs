using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class RepositorioClientes
    {
        private List<Cliente> clientes;

        public RepositorioClientes()
        {
            clientes = new List<Cliente>();
        }

        public void AgregarCliente(Cliente client)
        {
            if (client == null) 
                throw new ArgumentNullException("El cliente no puede ser nulo.");

            if (ExisteCliente(client.Dni))
                throw new InvalidOperationException("El cliente ya existe.");

            clientes.Add(client);
        }

        public void ModificarCliente(string dni, string nuevoNombre, string nuevoTelefono, string nuevoEmail, DateTime nuevaFechaNacimiento)
        {
            var cliente = BuscarCliente(dni);

            if (cliente == null)
                throw new InvalidOperationException("El cliente no existe.");

            cliente.Nombre = nuevoNombre;
            cliente.Telefono = nuevoTelefono;
            cliente.Email = nuevoEmail;
            cliente.FechaNacimiento = nuevaFechaNacimiento;

        }

        public void EliminarCliente(string dni)
        {
            var cliente = BuscarCliente(dni);

            if (cliente == null)
                throw new InvalidOperationException("El cliente no existe.");

            clientes.Remove(cliente);
        }

        public Cliente? BuscarCliente(string dni)
        {
            return clientes.FirstOrDefault(x => x.Dni == dni);
        }

        public List<Cliente> BuscarClientesPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacio.");

            return clientes.Where(x => x.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return clientes.ToList();
        }

        public bool ExisteCliente(string dni)
        {
            return clientes.Any(x => x.Dni == dni);
        }
    }
}
