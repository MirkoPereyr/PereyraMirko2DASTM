using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class RepositorioOperaciones
    {
        private List<Operacion> operaciones;

        public RepositorioOperaciones()
        {
            operaciones = new List<Operacion>();    
        }

        public void AgregarOperacion(Operacion operacion)
        {
            if (operacion == null)
                throw new ArgumentNullException("La operacion no puede ser nula.");

            operaciones.Add(operacion);
        }

        public List<Operacion> ObtenerOperacionesPorCuenta(string codigoCuenta)
        {
            return operaciones.Where(x => x.CodigoCuenta == codigoCuenta).ToList();
        }

        public List<Operacion> ObtenerTodasLasOperaciones()
        {
            return operaciones.ToList();
        }
    }
}
