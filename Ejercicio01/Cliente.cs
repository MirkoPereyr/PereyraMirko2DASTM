using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Cliente
    {
        public string dni = string.Empty;
        public string nombre = string.Empty;
        public string telefono = string.Empty;
        public string email = string.Empty;
        public DateTime fechaNacimiento;

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public int Edad
        {
            get
            {
                var hoy = DateTime.Today;
                int edad = hoy.Year - fechaNacimiento.Year;
                if (fechaNacimiento > hoy.AddYears(-edad)) edad--;
                return edad;
            }
        }

    }
}
