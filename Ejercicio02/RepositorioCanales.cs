using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class RepositorioCanales
    {
        private List<Canal> canales = new List<Canal>();

        public void AgregarCanal(Canal canal)
        {
            if (string.IsNullOrWhiteSpace(canal.Nombre))
                throw new Exception("El nombre del canal es obligatorio.");

            if (ExisteCanal(canal.Nombre))
                throw new Exception("Ya existe un canal con ese nombre.");

            canales.Add(canal);
        }

        public Canal? BuscarPorNombre(string nombre)
        {
            return canales.FirstOrDefault(x => x.Nombre == nombre);
        }

        public bool ExisteCanal(string nombre)
        {
            return canales.Any(x => x.Nombre == nombre);
        }

        public List<Canal> ObtenerTodos()
        {
            return canales;
        }
    }
}
