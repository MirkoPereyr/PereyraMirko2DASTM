using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado.net_3_repaso
{
    public class DatosInvalidosException : Exception
    {
        public DatosInvalidosException(string mensaje) : base(mensaje) { }
    }
}
