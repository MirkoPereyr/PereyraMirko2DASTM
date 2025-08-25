using Ejercicio02;
using System;

class Program
{
    private static EmpresaCable empresa;

    static void Main(string[] args)
    {
        empresa = new EmpresaCable();
        Console.WriteLine("=== SISTEMA DE GESTIÓN DE EMPRESA DE CABLE ===\n");

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
        Console.WriteLine("=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Agregar Cliente");
        Console.WriteLine("2. Agregar Paquete (Silver/Premium)");
        Console.WriteLine("3. Agregar Canal");
        Console.WriteLine("4. Agregar Serie");
        Console.WriteLine("5. Agregar Temporada y Episodios");
        Console.WriteLine("6. Mostrar clientes con sus paquetes e importes");
        Console.WriteLine("7. Mostrar total recaudado");
        Console.WriteLine("8. Mostrar paquete más vendido");
        Console.WriteLine("9. Mostrar series con ranking mayor a 3.5");
        Console.WriteLine("0. Salir");
        Console.Write("\nSeleccione una opción: ");
    }

    static int LeerOpcion()
    {
        try
        {
            return int.Parse(Console.ReadLine());
        }
        catch
        {
            throw new Exception("Debe ingresar un número válido.");
        }
    }

    static bool ProcesarOpcion(int opcion)
    {
        Console.Clear();
        try
        {
            switch (opcion)
            {
                case 1:
                    AgregarCliente();
                    break;
                case 2:
                    AgregarPaquete();
                    break;
                case 3:
                    AgregarCanal();
                    break;
                case 4:
                    AgregarSerie();
                    break;
                case 5:
                    AgregarTemporadaYEpisodios();
                    break;
                case 6:
                    empresa.MostrarClientesConPaquetes();
                    break;
                case 7:
                    empresa.MostrarTotalRecaudado();
                    break;
                case 8:
                    empresa.MostrarPaqueteMasVendido();
                    break;
                case 9:
                    empresa.MostrarSeriesConRankingAlto();
                    break;
                case 0:
                    Console.WriteLine("Gracias por usar el sistema.");
                    return false;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
        return true;
    }

    static void AgregarCliente()
    {
        Console.WriteLine("=== AGREGAR CLIENTE ===");
        Console.Write("Código de cliente: ");
        string codigo = Console.ReadLine();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();

        Console.Write("DNI: ");
        string dni = Console.ReadLine();

        Console.Write("Fecha de nacimiento (yyyy-mm-dd): ");
        DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

        Console.Write("Nombre del paquete contratado (exacto): ");
        string paqueteNombre = Console.ReadLine();

        empresa.AgregarCliente(codigo, nombre, apellido, dni, fechaNacimiento, paqueteNombre);
        Console.WriteLine("Cliente agregado correctamente.");
    }

    static void AgregarPaquete()
    {
        Console.WriteLine("=== AGREGAR PAQUETE ===");
        Console.Write("Nombre del paquete: ");
        string nombre = Console.ReadLine();

        Console.Write("Precio base: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        Console.Write("Tipo de paquete (silver/premium): ");
        string tipo = Console.ReadLine().ToLower();

        empresa.AgregarPaquete(nombre, precio, tipo);
        Console.WriteLine("Paquete agregado correctamente.");
    }

    static void AgregarCanal()
    {
        Console.WriteLine("=== AGREGAR CANAL A PAQUETE ===");
        Console.Write("Nombre del paquete: ");
        string paquete = Console.ReadLine();

        Console.Write("Nombre del canal: ");
        string canal = Console.ReadLine();

        empresa.AgregarCanal(paquete, canal);
        Console.WriteLine("Canal agregado correctamente.");
    }

    static void AgregarSerie()
    {
        Console.WriteLine("=== AGREGAR SERIE A CANAL ===");
        Console.Write("Nombre del canal: ");
        string canal = Console.ReadLine();

        Console.Write("Nombre de la serie: ");
        string nombre = Console.ReadLine();

        Console.Write("Director: ");
        string director = Console.ReadLine();

        Console.Write("Ranking: ");
        double ranking = double.Parse(Console.ReadLine());

        Console.Write("Género (Accion, Comedia, Drama, Documental, Otro): ");
        string genero = Console.ReadLine();

        empresa.AgregarSerie(canal, nombre, director, ranking, genero);
        Console.WriteLine("Serie agregada correctamente.");
    }

    static void AgregarTemporadaYEpisodios()
    {
        Console.WriteLine("=== AGREGAR TEMPORADA Y EPISODIOS A SERIE ===");
        Console.Write("Nombre de la serie: ");
        string serie = Console.ReadLine();

        Console.Write("Cantidad de episodios: ");
        int cantidad = int.Parse(Console.ReadLine());

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"--- Episodio {i + 1} ---");
            Console.Write("Nombre del episodio: ");
            string nombre = Console.ReadLine();

            Console.Write("Duración en minutos: ");
            int duracion = int.Parse(Console.ReadLine());

            empresa.AgregarEpisodio(serie, nombre, duracion);
        }

        Console.WriteLine("Episodios agregados correctamente.");
    }
}

