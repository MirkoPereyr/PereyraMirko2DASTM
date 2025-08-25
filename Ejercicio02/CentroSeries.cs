using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class CentroSeries
    {
        private RepositorioSeries repositorioSeries;

        public CentroSeries()
        {
            repositorioSeries = new RepositorioSeries();
        }

        public void CrearSerie(string nombre, int temporadas, List<Episodio> episodios, int duracion, double ranking, Genero genero, string director)
        {
            try
            {
                if (temporadas <= 0)
                    throw new Exception("La cantidad de temporadas debe ser mayor a 0.");
                if (duracion <= 0)
                    throw new Exception("La duración debe ser mayor a 0.");
                if (ranking < 0 || ranking > 5)
                    throw new Exception("El ranking debe estar entre 0 y 5.");

                Serie serie = new Serie();
                serie.Nombre = nombre;
                serie.Temporadas = temporadas;
                serie.Episodios = episodios;
                serie.Duracion = duracion;
                serie.Ranking = ranking;
                serie.Genero = genero;
                serie.Director = director;

                repositorioSeries.AgregarSerie(serie);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear serie: {ex.Message}");
            }
        }

        public List<Serie> ObtenerSeriesRankingMayorA(double valor)
        {
            return repositorioSeries.ObtenerSeriesConRankingMayorA(valor);
        }

        public List<Serie> ObtenerTodas()
        {
            return repositorioSeries.ObtenerTodas();
        }

        public Serie? BuscarSerie(string nombre)
        {
            return repositorioSeries.BuscarPorNombre(nombre);
        }
    }
}
