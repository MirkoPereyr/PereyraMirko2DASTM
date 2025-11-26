using Entidades;
using System.Runtime.CompilerServices;

namespace Modelo
{
    public class RepositorioLibros
    {
        private Context context;

        public RepositorioLibros()
        {
            context = new Context();
        }   

        public IReadOnlyCollection<Libro> Listar()
        {
            return context.Libros.ToList().AsReadOnly();
        }

        public void Agregar(Libro libro)
        {
            context.Libros.Add(libro);
            context.SaveChanges();
        }

        public void Modificar(Libro libro)
        {
            context.Libros.Update(libro);
            context.SaveChanges();  
        }

        public void Eliminar(Libro libro)
        {
            context.Libros.Remove(libro);
            context.SaveChanges();
        }

        public void CambiarEstado(int libroId, bool disponible)
        {
            var libro = context.Libros.FirstOrDefault(l => l.LibroId == libroId);
            if (libro == null) return;

            libro.Estado = disponible;
            context.SaveChanges();
        }
    }
}
