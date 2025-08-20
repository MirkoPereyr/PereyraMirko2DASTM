using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public abstract class Cuenta
    {
        public string codigo;
        public string dniTitular;
        public decimal saldo;

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

    }
}
