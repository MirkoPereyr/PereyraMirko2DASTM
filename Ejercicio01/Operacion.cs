using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Operacion
    {
        public string codigoCuenta = string.Empty;
        public DateTime fecha;
        public TipoOperacion tipo;
        public decimal importe;

        public string CodigoCuenta
        {
            get { return codigoCuenta; }
            set { codigoCuenta = value; }
        }



        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public TipoOperacion Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public decimal Importe
        { 
            get { return importe; } 
            set { importe = value; } 
        }

    }
}
