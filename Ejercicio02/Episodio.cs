using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Episodio
    {
        public string nombre = string.Empty;
        public int duracion;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }

        public Episodio(string nombre, int duracion)
        {
            this.nombre = nombre;
            this.duracion = duracion;
        }

        // Constructor por defecto
        public Episodio() { }
    }
}
