using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public abstract class Cuenta
    {
        public string codigo = string.Empty;
        public string dniTitular = string.Empty;
        public decimal saldo = 0;
        public TipoCuenta tipo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }   

        public string DniTitular
        {
            get { return dniTitular; }
            set { dniTitular = value; }
        }

        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public TipoCuenta Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

    }
}
