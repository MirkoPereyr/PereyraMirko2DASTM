using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class RepositorioPaquetes
    {
        private List<Paquete> paquetes = new List<Paquete>();

        public void AgregarPaquete(Paquete paquete)
        {
            if (string.IsNullOrWhiteSpace(paquete.Nombre))
                throw new Exception("El nombre del paquete es obligatorio.");

            if (ExistePaquete(paquete.Nombre))
                throw new Exception("Ya existe un paquete con ese nombre.");

            paquetes.Add(paquete);
        }

        public Paquete? BuscarPorNombre(string nombre)
        {
            return paquetes.FirstOrDefault(x => x.Nombre == nombre);
        }

        public bool ExistePaquete(string nombre)
        {
            return paquetes.Any(x => x.Nombre == nombre);
        }

        public List<Paquete> ObtenerTodos()
        {
            return paquetes;
        }
    }
}
