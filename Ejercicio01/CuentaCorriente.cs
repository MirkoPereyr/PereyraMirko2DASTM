using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CuentaCorriente : Cuenta
    {
        public decimal limiteDescubierto = -10000;

        public decimal LimiteDescubierto
        {
            get {  return limiteDescubierto; }
            set {  limiteDescubierto = value; }
        }
    }
}
