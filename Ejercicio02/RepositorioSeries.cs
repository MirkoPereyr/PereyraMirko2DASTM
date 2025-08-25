using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class RepositorioSeries
    {
        private List<Serie> series = new List<Serie>();

        public void AgregarSerie(Serie serie)
        {
            if (string.IsNullOrWhiteSpace(serie.Nombre))
                throw new Exception("El nombre de la serie es obligatorio.");

            if (ExisteSerie(serie.Nombre))
                throw new Exception("Ya existe una serie con ese nombre.");

            series.Add(serie);
        }

        public void EliminarSerie(string nombre)
        {
            var serie = BuscarPorNombre(nombre);

            if (serie == null)
                throw new Exception("No se encontró la serie.");

            series.Remove(serie);
        }

        public Serie? BuscarPorNombre(string nombre)
        {
            return series.FirstOrDefault(x => x.Nombre == nombre);
        }

        public bool ExisteSerie(string nombre)
        {
            return series.Any(x => x.Nombre == nombre);
        }

        public List<Serie> ObtenerTodas()
        {
            return series;
        }

        public List<Serie> ObtenerSeriesConRankingMayorA(double limite)
        {
            return series.Where(x => x.Ranking > limite).ToList();
        }
    }
}
