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

        public void CrearEpisodio(string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new Exception("El nombre del episodio es obligatorio.");

                Episodio episodio = new Episodio();
                episodio.Nombre = nombre;

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
