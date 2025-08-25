using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class CentroPaquetes
    {
        private RepositorioPaquetes repositorioPaquetes;

        public CentroPaquetes()
        {
            repositorioPaquetes = new RepositorioPaquetes();
        }

        public void CrearPaquete(string nombre, decimal precioBase, List<Canal> canales, TipoPaquete tipo)
        {
            try
            {
                Paquete paquete;

                if (tipo == TipoPaquete.Silver)
                    paquete = new PaqueteSilver(nombre, precioBase, canales);
                else if (tipo == TipoPaquete.Premium)
                    paquete = new PaquetePremium(nombre, precioBase, canales);
                else
                    throw new Exception("Tipo de paquete inválido.");

                repositorioPaquetes.AgregarPaquete(paquete);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear paquete: {ex.Message}");
            }
        }

        public List<Paquete> ObtenerPaquetes()
        {
            return repositorioPaquetes.ObtenerTodos();
        }

        public Paquete? BuscarPorNombre(string nombre)
        {
            return repositorioPaquetes.BuscarPorNombre(nombre);
        }
    }
}
