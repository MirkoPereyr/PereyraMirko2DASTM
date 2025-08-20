using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class RepositorioCuentas
    {
        private List<Cuenta> cuentas;

        public RepositorioCuentas()
        {
            cuentas = new List<Cuenta>();
        }

        public void AgregarCuenta(Cuenta cuenta)
        {
            if (cuenta == null)
                throw new ArgumentNullException("La cuenta no puede ser nula.");

            if (ExisteCuenta(cuenta.Codigo))
                throw new InvalidOperationException("La cuenta ya existe.");
            cuentas.Add(cuenta);
        }

        public void ModificarCuenta(string codigo, string nuevoDniTitular)
        {
            var cuenta = BuscarCuenta(codigo);

            if (cuenta == null)
                throw new InvalidOperationException("La cuenta no existe.");

            if (string.IsNullOrWhiteSpace(nuevoDniTitular))
                throw new ArgumentException("El nuevo DNI del titular no puede ser nulo o vacio.");

            cuenta.dniTitular = nuevoDniTitular;
        }

        public void EliminarCuenta(string codigo)
        {
            var cuenta = BuscarCuenta(codigo);

            if (cuenta == null)
                throw new InvalidOperationException("La cuenta no existe.");

            if (cuenta.saldo != 0)
                throw new ArgumentException("No se puede eliminar una cuenta con saldo diferente de cero.");

            cuentas.Remove(cuenta);
        }

        public Cuenta? BuscarCuenta(string codigo)
        {
            return cuentas.FirstOrDefault(x => x.Codigo == codigo);
        }

        public bool ExisteCuenta(string codigo)
        {
            return cuentas.Any(x => x.Codigo == codigo);
        }

        public List<Cuenta> ObtenerCuentasPorDniTitular(string dniTitular)
        {
            return cuentas.Where(x => x.DniTitular == dniTitular).ToList();
        }

        public List<Cuenta> ObtenerTodasLasCuentas()
        {
            return cuentas.ToList();
        }
    }
}
