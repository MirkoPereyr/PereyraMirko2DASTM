using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CajaAhorro : Cuenta
    {
        public decimal montoMaximoExtraccion = 20000;

        public decimal MontoMaximoExtraccion
        {
            get {  return montoMaximoExtraccion; }
            set {  montoMaximoExtraccion = value; }
        }


    }
}
