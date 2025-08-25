using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class RepositorioEpisodios
    {
        private List<Episodio> episodios = new List<Episodio>();

        public void AgregarEpisodio(Episodio episodio)
        {
            if (string.IsNullOrWhiteSpace(episodio.Nombre))
                throw new Exception("El nombre del episodio es obligatorio.");

            episodios.Add(episodio);
        }

        public List<Episodio> ObtenerTodos()
        {
            return episodios;
        }
    }
}
