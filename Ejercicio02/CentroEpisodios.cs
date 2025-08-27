using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class CentroEpisodios
    {
        private RepositorioEpisodios repositorioEpisodios;

        public CentroEpisodios()
        {
            repositorioEpisodios = new RepositorioEpisodios();
        }

        public void CrearEpisodio(string nombre, int duracion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new Exception("El nombre del episodio es obligatorio.");

                if (duracion <= 0)
                    throw new Exception("La duración del episodio debe ser mayor a cero.");

                Episodio episodio = new Episodio();
                episodio.Nombre = nombre;
                episodio.Duracion = duracion;

                repositorioEpisodios.AgregarEpisodio(episodio);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear episodio: {ex.Message}");
            }
        }

        public List<Episodio> ObtenerEpisodios()
        {
            return repositorioEpisodios.ObtenerTodos();
        }
    }
}
