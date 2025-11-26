using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RepositorioPrestamos
    {
        private Context context;

        public RepositorioPrestamos()
        {
            context = new Context();
        }

        public IReadOnlyCollection<Prestamo> Listar()
        {
            return context.Prestamos
                .Include(p => p.libro)
                .Include(p => p.socio)
                .AsNoTracking()
                .ToList()
                .AsReadOnly();
        }

        public void Agregar(Prestamo prestamo)
        {
            context.Prestamos.Add(prestamo);
            context.SaveChanges();
        }

        public void Modificar(Prestamo prestamo)
        {
            context.Prestamos.Update(prestamo);
            context.SaveChanges();
        }

        public void Eliminar(Prestamo prestamo)
        {
            context.Prestamos.Remove(prestamo);
            context.SaveChanges();
        }

        public void MarcarDevolucion(int prestamoId, DateTime fecha)
        {
            var existente = context.Prestamos.FirstOrDefault(p => p.PrestamoId == prestamoId);
            if (existente == null) return;

            existente.FechaDevolucion = fecha;
            context.SaveChanges();
        }

    }
}
