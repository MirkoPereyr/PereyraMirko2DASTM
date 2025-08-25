using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class RepositorioClientes
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void AgregarCliente(Cliente cliente)
        {
            if (ExisteCliente(cliente.Dni))
                throw new Exception("El cliente ya existe.");

            if (string.IsNullOrWhiteSpace(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Apellido) || string.IsNullOrWhiteSpace(cliente.Dni))
                throw new Exception("Todos los campos del cliente son obligatorios.");

            clientes.Add(cliente);
        }

        public void ModificarCliente(string dni, string nuevoNombre, string nuevoApellido, DateTime nuevaFechaNacimiento, Paquete nuevoPaqueteContratado)
        {
            var cliente = BuscarCliente(dni);

            if (cliente == null)
                throw new Exception("El cliente no existe.");

            cliente.Nombre = nuevoNombre;
            cliente.Apellido = nuevoApellido;
            cliente.FechaNacimiento = nuevaFechaNacimiento;
            cliente.PaqueteContratado = nuevoPaqueteContratado;
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

        public List<Cliente> ObtenerTodos()
        {
            return clientes;
        }

        public bool ExisteCliente(string dni)
        {
            return clientes.Any(x => x.Dni == dni);
        }
    }
}
