using System;
using System.Collections.Generic;
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

            cuenta.dniTitular = nuevoDniTitular;
        }

        public void EliminarCuenta(string codigo)
        {
            var cuenta = BuscarCuenta(codigo);

            if (cuenta == null)
                throw new InvalidOperationException("La cuenta no existe.");

            cuentas.Remove(cuenta);
        }

        public Cuenta BuscarCuenta(string codigo)
        {
            return cuentas.FirstOrDefault(x => x.Codigo == codigo);
        }

        public bool ExisteCuenta(string codigo)
        {
            return cuentas.Any(x => x.Codigo == codigo);
        }


    }
}
