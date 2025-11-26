using System.Collections.Specialized;

namespace Entidades
{
    public class Socio
    {
        public int SocioId { get; set; }

        public int Dni { get; set; }

        public string NombreCompleto { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public List<Prestamo> prestamos { get; set; } = new();
    }
}
