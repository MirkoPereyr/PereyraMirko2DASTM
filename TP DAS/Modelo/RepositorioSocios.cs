using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RepositorioSocios
    {
        private Context context;

        public RepositorioSocios()
        {
            context = new Context();
        }

        public IReadOnlyCollection<Socio> Listar()
        {
            return context.Socios.ToList().AsReadOnly();
        }

        public void Agregar(Socio socio)
        {
            context.Socios.Add(socio);
            context.SaveChanges();
        }

        public void Modificar(Socio socio)
        {
            context.Socios.Update(socio);
            context.SaveChanges();
        }

        public void Eliminar(Socio socio)
        {
            context.Socios.Remove(socio);
            context.SaveChanges();
        }
    }
}
