using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CentroCuentas
    {
        private RepositorioClientes repositorioClientes;
        private RepositorioCuentas repositorioCuentas;

        public CentroCuentas(RepositorioClientes repoClientes, RepositorioCuentas repoCuentas)
        {
            repositorioClientes = repoClientes;
            repositorioCuentas = repoCuentas;
        }

        public void CrearCajaAhorro(string codigo, string dniTitular)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(dniTitular))
                    throw new ArgumentException("El código y el DNI del titular no pueden ser nulos o vacios.");

                if (!repositorioClientes.ExisteCliente(dniTitular))
                    throw new InvalidOperationException("El cliente no existe.");

                var cuenta = new CajaAhorro();
                cuenta.Codigo = codigo;
                cuenta.Tipo = TipoCuenta.CajaAhorro;
                cuenta.DniTitular = dniTitular;
                cuenta.Saldo = 0;

                repositorioCuentas.AgregarCuenta(cuenta);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al crear caja ahorro: {ex.Message}");
            }
        }

        public void CrearCuentaCorriente(string codigo, string dniTitular)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(dniTitular))
                    throw new ArgumentException("El código y el DNI del titular no pueden ser nulos o vacios.");

                if (!repositorioClientes.ExisteCliente(dniTitular))
                    throw new InvalidOperationException("El cliente no existe.");

                var cuenta = new CuentaCorriente();
                cuenta.Codigo = codigo;
                cuenta.Tipo = TipoCuenta.CuentaCorriente;
                cuenta.DniTitular = dniTitular;
                cuenta.Saldo = 0;

                repositorioCuentas.AgregarCuenta(cuenta);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException($"Error al crear cuenta corriente: {ex.Message}");
            }
        }

        public void ModificarTitularCuenta(string codigo, string nuevoDniTitular)
        {
            try
            {
               if (!repositorioClientes.ExisteCliente(nuevoDniTitular))
                    throw new InvalidOperationException("El nuevo titular no existe.");

                repositorioCuentas.ModificarCuenta(codigo, nuevoDniTitular);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al modificar titular de la cuenta: {ex.Message}");
            }
        }

        public void EliminarCuenta(string codigo)
        {
            try
            {
                var cuenta = repositorioCuentas.BuscarCuenta(codigo);

                if (cuenta == null)
                    throw new InvalidOperationException("La cuenta no existe.");

                if (cuenta.Saldo != 0)
                    throw new InvalidOperationException("No se puede eliminar una cuenta con saldo distinto de cero.");

                repositorioCuentas.EliminarCuenta(codigo);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al eliminar cuenta: {ex.Message}");
            }
        }


        public Cuenta? BuscarCuenta(string codigo)
        {
            return repositorioCuentas.BuscarCuenta(codigo);
        }

        public List<Cuenta> ObtenerCuentasPorDniTitular(string dniTitular)
        {
            if (string.IsNullOrWhiteSpace(dniTitular))
                throw new ArgumentException("El DNI del titular no puede ser nulo o vacio.");

            return repositorioCuentas.ObtenerCuentasPorDniTitular(dniTitular);
        }
    }
}
