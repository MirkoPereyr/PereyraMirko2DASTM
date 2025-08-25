using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Serie
    {
        public string nombre = string.Empty;
        public int temporadas;
        public List<Episodio> episodios = new List<Episodio>();
        public double ranking;
        public int duracion;
        public Genero genero;
        public string director = string.Empty;


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public int Temporadas
        {
            get { return temporadas; }
            set { temporadas = value; }
        }


        public List<Episodio> Episodios
        {
            get { return episodios; }
            set { episodios = value; }
        }


        public double Ranking
        {
            get { return ranking; }
            set { ranking = value; }
        }

        public int Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }

        public Genero Genero
        {
            get { return genero; }
            set { genero = value; }
        }


        public string Director
        {
            get { return director; }
            set { director = value; }
        }


    }
}
