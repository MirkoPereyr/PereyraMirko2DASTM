using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class EmpresaCable
    {
        private CentroClientes centroClientes;
        private CentroPaquetes centroPaquetes;
        private CentroSeries centroSeries;

        public Empresa()
        {
            centroClientes = new CentroClientes();
            centroPaquetes = new CentroPaquetes();
            centroSeries = new CentroSeries();
        }

        // === CLIENTES ===
        public void AgregarCliente(string codigo, string nombre, string apellido, string dni, DateTime fechaNacimiento)
        {
            centroClientes.CrearCliente(codigo, nombre, apellido, dni, fechaNacimiento);
        }

        public void ModificarCliente(string dni, string nuevoNombre, string nuevoApellido, DateTime nuevaFechaNacimiento)
        {
            centroClientes.ModificarCliente(dni, nuevoNombre, nuevoApellido, nuevaFechaNacimiento);
        }

        public void EliminarCliente(string dni)
        {
            centroClientes.EliminarCliente(dni);
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return centroClientes.ObtenerTodos();
        }

        public Cliente? BuscarCliente(string dni)
        {
            return centroClientes.BuscarCliente(dni);
        }

        public void AsignarPaqueteACliente(string dni, string nombrePaquete)
        {
            centroClientes.AsignarPaquete(dni, nombrePaquete);
        }

        // === PAQUETES ===
        public void CrearPaqueteSilver(string nombre, decimal precioBase)
        {
            centroPaquetes.CrearPaqueteSilver(nombre, precioBase);
        }

        public void CrearPaquetePremium(string nombre, decimal precioBase)
        {
            centroPaquetes.CrearPaquetePremium(nombre, precioBase);
        }

        public void AgregarCanalAPaquete(string nombrePaquete, Canal canal)
        {
            centroPaquetes.AgregarCanalAPaquete(nombrePaquete, canal);
        }

        public List<Paquete> ObtenerTodosLosPaquetes()
        {
            return centroPaquetes.ObtenerTodos();
        }

        public Paquete? BuscarPaquete(string nombre)
        {
            return centroPaquetes.BuscarPorNombre(nombre);
        }

        public string ObtenerPaqueteMasVendido()
        {
            return centroClientes.ObtenerPaqueteMasVendido();
        }

        public decimal CalcularRecaudacionMensual()
        {
            return centroClientes.CalcularRecaudacionMensual();
        }

        // === SERIES ===
        public void CrearSerie(string nombre, int temporadas, int episodios, double duracion, double ranking, Genero genero, string director)
        {
            centroSeries.CrearSerie(nombre, temporadas, episodios, duracion, ranking, genero, director);
        }

        public Serie? BuscarSerie(string nombre)
        {
            return centroSeries.BuscarSerie(nombre);
        }

        public List<Serie> ObtenerSeriesConRankingMayorA(double minimo)
        {
            return centroSeries.ObtenerSeriesRankingMayorA(minimo);
        }

        public List<Serie> ObtenerTodasLasSeries()
        {
            return centroSeries.ObtenerTodas();
        }

        // === CANALES ===
        public void CrearCanal(string nombre)
        {
            centroSeries.CrearCanal(nombre);
        }

        public void AgregarSerieACanal(string nombreCanal, Serie serie)
        {
            centroSeries.AgregarSerieACanal(nombreCanal, serie);
        }

        public List<Canal> ObtenerTodosLosCanales()
        {
            return centroSeries.ObtenerTodosLosCanales();
        }

        public Canal? BuscarCanal(string nombre)
        {
            return centroSeries.BuscarCanal(nombre);
        }
    }
