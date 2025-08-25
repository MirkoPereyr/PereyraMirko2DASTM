using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class CentroCanales
    {
        private RepositorioCanales repositorioCanales;

        public CentroCanales()
        {
            repositorioCanales = new RepositorioCanales();
        }

        public void CrearCanal(string nombre, List<Serie> series)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new Exception("El nombre del canal no puede estar vacío.");

                Canal canal = new Canal();
                canal.Nombre = nombre;
                canal.Series = series;

                repositorioCanales.AgregarCanal(canal);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear canal: {ex.Message}");
            }
        }

        public List<Canal> ObtenerCanales()
        {
            return repositorioCanales.ObtenerTodos();
        }

        public Canal? BuscarCanal(string nombre)
        {
            return repositorioCanales.BuscarPorNombre(nombre);
        }
    }
}
