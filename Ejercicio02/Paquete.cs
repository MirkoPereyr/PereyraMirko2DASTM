using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public abstract class Paquete
    {
        public string nombre = string.Empty;
        public List<Canal> canales = new List<Canal>();
        public decimal precioBase = 0;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public List<Canal> Canales
        {
            get { return canales; }
            set { canales = value; }
        }


        public decimal PrecioBase
        {
            get { return precioBase; }
            set { precioBase = value; }
        }

        public Paquete() { }

        public Paquete(string nombre, decimal precioBase, List<Canal> canales)
        {
            this.nombre = nombre;
            this.canales = canales;
            this.precioBase = precioBase;
        }


        public virtual decimal CalcularPrecioFinal()
        {
            return precioBase;
        }
    }
}
