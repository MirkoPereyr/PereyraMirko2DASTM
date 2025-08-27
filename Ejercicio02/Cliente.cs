using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Cliente
    {
        public string codigoCliente = string.Empty;
        public string nombre = string.Empty;
        public string apellido = string.Empty;
        public string dni = string.Empty;
        public DateTime fechaNacimiento;
        public Paquete? paqueteContratado;


        public string CodigoCliente
        {
            get { return codigoCliente; }
            set { codigoCliente = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }


        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }


        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }


        public Paquete? PaqueteContratado
        {
            get { return paqueteContratado; }
            set { paqueteContratado = value; }
        }

        public decimal ObtenerTotalAbono()
        {
            return PaqueteContratado != null ? PaqueteContratado.CalcularPrecioFinal() : 0;
        }

    }
}
