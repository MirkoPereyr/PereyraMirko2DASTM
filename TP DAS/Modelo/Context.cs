using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Context : DbContext
    {
        private string conexion = "Data Source=PCDEMIRKO\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True;Persist Security Info=False;Pooling=False;Encrypt=False";

        public DbSet<Socio> Socios { get; set; }

        public DbSet<Libro> Libros { get; set; }

        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(conexion);
    }
}
