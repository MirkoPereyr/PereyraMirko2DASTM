using Entidades;
using Modelo;
using System.Text.RegularExpressions;

namespace Controladora
{
    public class Controladora
    {
        public RepositorioLibros repoLibros = new RepositorioLibros();
        public RepositorioPrestamos repoPrestamos = new RepositorioPrestamos();
        public RepositorioSocios repoSocios = new RepositorioSocios();

        private static Controladora instancia;
        public static Controladora Instancia
        {
            get
            {
                if (instancia == null) //si no existe una instancia de la clase Controladora, la crea
                {
                    return instancia = new Controladora();
                }

                return instancia; // si ya existe una instancia, la devuelve
            }
        }

        private bool ValidarIsbn(string isbn) => Regex.IsMatch(isbn, @"^\d{3}-\d-\d{4}-\d{4}-\d$");
        private bool ValidarDni(string dni) => Regex.IsMatch(dni, @"^\d{8}$");
        private bool ValidarEmail(string email) => Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        private bool ValidarTelefono(string tel) => Regex.IsMatch(tel, @"^\d{2,4}-\d{6,8}$");

        public string AgregarSocio(Socio socio)
        {
            if (!ValidarDni(socio.Dni.ToString()))
            {
                return "DNI invalido.";
            }
            if (!ValidarEmail(socio.Email))
            {
                return "Email invalido.";
            }
            if (!ValidarTelefono(socio.Telefono))
            {
                return "Telefono invalido.";
            }

            repoSocios.Agregar(socio);
            return "Socio registrado correctamente.";
        }

        public string AgregarLibro(Libro libro)
        {
            if (!ValidarIsbn(libro.Isbn))
            {
                return "ISBN invalido.";
            }
            if (string.IsNullOrWhiteSpace(libro.Titulo) || string.IsNullOrWhiteSpace(libro.Autor))
            {
                return "Debe completar titulo y autor.";
            }

            repoLibros.Agregar(libro);
            return "Libro agregado correctamente.";
        }

        public string AsignarPrestamo(Socio socio, Libro libro)
        {
            if (socio is null || libro is null) return "Datos inválidos.";
            if (!libro.Estado) return "El libro ya está prestado.";

            var prestamo = new Prestamo
            {
                SocioId = socio.SocioId,
                LibroId = libro.LibroId,
                FechaPrestamo = DateTime.Now,
            };

            repoPrestamos.Agregar(prestamo);                    // inserta el préstamo
            repoLibros.CambiarEstado(libro.LibroId, false); // 🔁 cambia estado en SU contexto

            return $"Préstamo asignado: {libro.Titulo} → {socio.NombreCompleto}.";
        }

        public string RegistrarDevolucion(Prestamo prestamo)
        {
            if (prestamo is null) return "Préstamo inválido.";

            // 🔁 todo por ID (sin Attach)
            repoPrestamos.MarcarDevolucion(prestamo.PrestamoId, DateTime.Now);
            repoLibros.CambiarEstado(prestamo.LibroId, true);

            return "Devolución registrada.";
        }

    }
}
