using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Banco
    {
        private RepositorioClientes repositorioClientes;
        private RepositorioCuentas repositorioCuentas;
        private RepositorioOperaciones repositorioOperaciones;

        private CentroClientes centroClientes;
        private CentroCuentas centroCuentas;
        private CentroOperaciones centroOperaciones;

        public Banco()
        {
            repositorioClientes = new RepositorioClientes();
            repositorioCuentas = new RepositorioCuentas();
            repositorioOperaciones = new RepositorioOperaciones();

            centroClientes = new CentroClientes(repositorioClientes, repositorioCuentas);
            centroCuentas = new CentroCuentas(repositorioClientes, repositorioCuentas);
            centroOperaciones = new CentroOperaciones(repositorioCuentas, repositorioOperaciones);
        }

        // === CLIENTES ===
        public void AgregarCliente(string dni, string nombre, string email, string telefono, DateTime fechaNacimiento)
        {
            centroClientes.CrearCliente(dni, nombre, email, telefono, fechaNacimiento);
        }

        public void ModificarCliente(string dni, string nuevoNombre, string nuevoTelefono, string nuevoEmail, DateTime nuevaFechaNacimiento)
        {
            centroClientes.ModificarCliente(dni, nuevoNombre, nuevoTelefono, nuevoEmail, nuevaFechaNacimiento);
        }

        public void EliminarCliente(string dni)
        {
            centroClientes.EliminarCliente(dni);
        }

        public Cliente? BuscarClientePorDni(string dni)
        {
            return centroClientes.BuscarClientePorDni(dni);
        }

        public List<Cliente> BuscarClientesPorNombre(string nombre)
        {
            return centroClientes.BuscarClientesPorNombre(nombre);
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return centroClientes.ObtenerTodosLosClientes();
        }

        // === CUENTAS ===
        public void CrearCajaAhorro(string codigo, string dniTitular)
        {
            centroCuentas.CrearCajaAhorro(codigo, dniTitular);
        }

        public void CrearCuentaCorriente(string codigo, string dniTitular)
        {
            centroCuentas.CrearCuentaCorriente(codigo, dniTitular);
        }

        public void ModificarTitularCuenta(string codigo, string nuevoDniTitular)
        {
            centroCuentas.ModificarTitularCuenta(codigo, nuevoDniTitular);
        }

        public void EliminarCuenta(string codigo)
        {
            centroCuentas.EliminarCuenta(codigo);
        }

        public Cuenta? BuscarCuenta(string codigo)
        {
            return centroCuentas.BuscarCuenta(codigo);
        }

        public List<Cuenta> ObtenerCuentasPorDniTitular(string dni)
        {
            return centroCuentas.ObtenerCuentasPorDniTitular(dni);
        }

        // === OPERACIONES ===
        public void Depositar(string codigoCuenta, decimal importe)
        {
            centroOperaciones.Depositar(codigoCuenta, importe);
        }

        public void Extraer(string codigoCuenta, decimal importe)
        {
            centroOperaciones.Extraer(codigoCuenta, importe);
        }

        public List<Operacion> ObtenerOperacionesDeCuenta(string codigoCuenta)
        {
            return centroOperaciones.ObtenerOperacionesDeCuenta(codigoCuenta);
        }
    }
}

