using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        public int LibroId { get; set; }

        public string Isbn { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public bool Estado { get; set; } = true;

        public List<Prestamo> prestamos { get; set; } = new();
    }
}
