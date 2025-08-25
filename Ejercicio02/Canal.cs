using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Canal
    {
        public string nombre = string.Empty;
        public List<Serie> series = new List<Serie>();

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Serie> Series
        {
            get { return series; }
            set { series = value; }
        }
    }
}
