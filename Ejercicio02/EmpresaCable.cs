using System;
using System.Collections.Generic;

namespace Ejercicio02
{
    public class EmpresaCable
    {
        private CentroClientes centroClientes;
        private CentroPaquetes centroPaquetes;
        private CentroSeries centroSeries;
        private CentroCanales centroCanales;
        private CentroEpisodios centroEpisodios;

        public EmpresaCable()
        {
            centroClientes = new CentroClientes();
            centroPaquetes = new CentroPaquetes();
            centroSeries = new CentroSeries();
            centroCanales = new CentroCanales();
            centroEpisodios = new CentroEpisodios();
        }

        // === CLIENTES ===
        public void AgregarCliente(string codigo, string nombre, string apellido, string dni, DateTime fechaNacimiento, Paquete paquete)
        {
            centroClientes.AgregarCliente(codigo, nombre, apellido, dni, fechaNacimiento, paquete);
        }

        public void ModificarCliente(string dni, string nuevoNombre, string nuevoApellido, DateTime nuevaFechaNacimiento, Paquete nuevoPaquete)
        {
            centroClientes.ModificarCliente(dni, nuevoNombre, nuevoApellido, nuevaFechaNacimiento, nuevoPaquete);
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

        // === PAQUETES ===
        public void CrearPaquete(string nombre, decimal precioBase, List<Canal> canales, TipoPaquete tipo)
        {
            centroPaquetes.CrearPaquete(nombre, precioBase, canales, tipo);
        }

        public List<Paquete> ObtenerPaquetes()
        {
            return centroPaquetes.ObtenerPaquetes();
        }

        public Paquete? BuscarPaquete(string nombre)
        {
            return centroPaquetes.BuscarPorNombre(nombre);
        }

        // === SERIES ===
        public void CrearSerie(string nombre, int temporadas, List<Episodio> episodios, int duracion, double ranking, Genero genero, string director)
        {
            centroSeries.CrearSerie(nombre, temporadas, episodios, duracion, ranking, genero, director);
        }

        public List<Serie> ObtenerSeries()
        {
            return centroSeries.ObtenerTodas();
        }

        public Serie? BuscarSerie(string nombre)
        {
            return centroSeries.BuscarSerie(nombre);
        }

        public List<Serie> ObtenerSeriesConRankingMayorA(double minimo)
        {
            return centroSeries.ObtenerSeriesRankingMayorA(minimo);
        }

        // === CANALES ===
        public void CrearCanal(string nombre, List<Serie> series)
        {
            centroCanales.CrearCanal(nombre, series);
        }

        public List<Canal> ObtenerCanales()
        {
            return centroCanales.ObtenerCanales();
        }

        public Canal? BuscarCanal(string nombre)
        {
            return centroCanales.BuscarCanal(nombre);
        }

        // === EPISODIOS ===
        public void CrearEpisodio(string nombre, int duracion)
        {
            centroEpisodios.CrearEpisodio(nombre, duracion);
        }

        public List<Episodio> ObtenerEpisodios()
        {
            return centroEpisodios.ObtenerEpisodios();
        }
    }
}
