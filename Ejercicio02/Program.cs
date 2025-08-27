using System;
using System.Collections.Generic;

namespace Ejercicio02
{
    internal class Program
    {
        private static EmpresaCable empresa = new EmpresaCable();

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                try
                {
                    MostrarMenu();
                    int opcion = LeerOpcion();
                    continuar = ProcesarOpcion(opcion);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE EMPRESA DE CABLE ===");
            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Ver todos los clientes");
            Console.WriteLine("3. Crear paquete");
            Console.WriteLine("4. Ver paquetes");
            Console.WriteLine("5. Crear serie");
            Console.WriteLine("6. Ver series");
            Console.WriteLine("7. Crear canal");
            Console.WriteLine("8. Ver canales");
            Console.WriteLine("9. Crear episodio");
            Console.WriteLine("10. Ver episodios");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static int LeerOpcion()
        {
            if (int.TryParse(Console.ReadLine(), out int opcion))
                return opcion;
            else
                throw new Exception("La opción debe ser un número.");
        }

        static bool ProcesarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    AgregarCliente();
                    break;
                case 2:
                    VerClientes();
                    break;
                case 3:
                    CrearPaquete();
                    break;
                case 4:
                    VerPaquetes();
                    break;
                case 5:
                    CrearSerie();
                    break;
                case 6:
                    VerSeries();
                    break;
                case 7:
                    CrearCanal();
                    break;
                case 8:
                    VerCanales();
                    break;
                case 9:
                    CrearEpisodio();
                    break;
                case 10:
                    VerEpisodios();
                    break;
                case 0:
                    return false;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            return true;
        }

        // === FUNCIONES ===

        static void AgregarCliente()
        {
            Console.Write("Código: ");
            string codigo = Console.ReadLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("DNI: ");
            string dni = Console.ReadLine();
            Console.Write("Fecha de nacimiento (yyyy-MM-dd): ");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Nombre del paquete contratado: ");
            string nombrePaquete = Console.ReadLine();

            var paquete = empresa.BuscarPaquete(nombrePaquete);
            if (paquete == null)
                throw new Exception("Paquete no encontrado.");

            empresa.AgregarCliente(codigo, nombre, apellido, dni, fechaNacimiento, paquete);
            Console.WriteLine("Cliente agregado correctamente.");
        }

        static void VerClientes()
        {
            var clientes = empresa.ObtenerTodosLosClientes();
            foreach (var c in clientes)
            {
                Console.WriteLine($"[{c.Dni}] {c.Nombre} {c.Apellido} - Paquete: {c.PaqueteContratado?.Nombre} - Total Abono: ${c.ObtenerTotalAbono()}");
            }
        }

        static void CrearPaquete()
        {
            Console.Write("Nombre del paquete: ");
            string nombre = Console.ReadLine();
            Console.Write("Precio base: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            List<Canal> canales = new List<Canal>();
            Console.Write("¿Cuántos canales tendrá el paquete?: ");
            int cantidad = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Nombre del canal {i + 1}: ");
                string canalNombre = Console.ReadLine();
                var canal = empresa.BuscarCanal(canalNombre);
                if (canal != null)
                    canales.Add(canal);
            }

            Console.Write("Tipo de paquete (1: Silver, 2: Premium): ");
            int tipo = int.Parse(Console.ReadLine());
            TipoPaquete tipoPaquete = (TipoPaquete)(tipo - 1);

            empresa.CrearPaquete(nombre, precio, canales, tipoPaquete);
            Console.WriteLine("Paquete creado exitosamente.");
        }

        static void VerPaquetes()
        {
            var paquetes = empresa.ObtenerPaquetes();
            foreach (var p in paquetes)
            {
                Console.WriteLine($"[{p.Nombre}] - Precio final: ${p.CalcularPrecioFinal()} - Canales: {p.Canales.Count}");
            }
        }

        static void CrearSerie()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Temporadas: ");
            int temporadas = int.Parse(Console.ReadLine());
            Console.Write("Duración total: ");
            int duracion = int.Parse(Console.ReadLine());
            Console.Write("Ranking (0-5): ");
            double ranking = double.Parse(Console.ReadLine());
            Console.Write("Director: ");
            string director = Console.ReadLine();

            Console.Write("Género (0: Drama, 1: Comedia, 2: Accion, 3: CienciaFiccion): ");
            int genero = int.Parse(Console.ReadLine());

            List<Episodio> episodios = empresa.ObtenerEpisodios();

            empresa.CrearSerie(nombre, temporadas, episodios, duracion, ranking, (Genero)genero, director);
            Console.WriteLine("Serie creada correctamente.");
        }

        static void VerSeries()
        {
            var series = empresa.ObtenerSeries();
            foreach (var s in series)
            {
                Console.WriteLine($"[{s.Nombre}] - {s.Temporadas} temp. - {s.Director} - Ranking: {s.Ranking} - Género: {s.Genero}");
            }
        }

        static void CrearCanal()
        {
            Console.Write("Nombre del canal: ");
            string nombre = Console.ReadLine();

            List<Serie> series = empresa.ObtenerSeries();

            empresa.CrearCanal(nombre, series);
            Console.WriteLine("Canal creado correctamente.");
        }

        static void VerCanales()
        {
            var canales = empresa.ObtenerCanales();
            foreach (var c in canales)
            {
                Console.WriteLine($"[{c.Nombre}] - Series: {c.Series.Count}");
            }
        }

        static void CrearEpisodio()
        {
            Console.Write("Nombre del episodio: ");
            string nombre = Console.ReadLine();
            Console.Write("Duración (minutos): ");
            int duracion = int.Parse(Console.ReadLine());

            empresa.CrearEpisodio(nombre, duracion);
            Console.WriteLine("Episodio creado correctamente.");
        }

        static void VerEpisodios()
        {
            var episodios = empresa.ObtenerEpisodios();
            foreach (var e in episodios)
            {
                Console.WriteLine($"[{e.Nombre}] - {e.Duracion} min.");
            }
        }
    }
}

