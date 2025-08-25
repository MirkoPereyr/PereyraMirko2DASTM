using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class PaquetePremium : Paquete
    {
        public TipoPaquete tipo = TipoPaquete.Premium;

        public TipoPaquete Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public PaquetePremium() : base()
        {
        }

        public PaquetePremium(string nombre, decimal precioBase, List<Canal> canales) : base(nombre, precioBase, canales)
        {
        }

        public override decimal CalcularPrecioFinal()
        {
            return precioBase * 1.20m;
        }
    }

}
