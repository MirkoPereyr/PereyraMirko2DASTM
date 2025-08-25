using System;
using System.Collections.Generic;

namespace Ejercicio01
{
    internal class Program
    {
        private static Banco banco;

        static void Main(string[] args)
        {
            banco = new Banco();
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
            Console.WriteLine("=== MENÚ PRINCIPAL - BANCO ===");
            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Modificar cliente");
            Console.WriteLine("3. Eliminar cliente");
            Console.WriteLine("4. Crear caja de ahorro");
            Console.WriteLine("5. Crear cuenta corriente");
            Console.WriteLine("6. Modificar titular de cuenta");
            Console.WriteLine("7. Depositar");
            Console.WriteLine("8. Extraer");
            Console.WriteLine("9. Listar clientes");
            Console.WriteLine("10. Listar cuentas por DNI");
            Console.WriteLine("11. Ver operaciones por cuenta");
            Console.WriteLine("12. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static int LeerOpcion()
        {
            if (int.TryParse(Console.ReadLine(), out int opcion))
                return opcion;
            throw new Exception("Debe ingresar un número válido.");
        }

        static bool ProcesarOpcion(int opcion)
        {
            try
            {
                switch (opcion)
                {
                    case 1: AgregarCliente(); break;
                    case 2: ModificarCliente(); break;
                    case 3: EliminarCliente(); break;
                    case 4: CrearCajaAhorro(); break;
                    case 5: CrearCuentaCorriente(); break;
                    case 6: ModificarTitularCuenta(); break;
                    case 7: Depositar(); break;
                    case 8: Extraer(); break;
                    case 9: ListarClientes(); break;
                    case 10: ListarCuentasPorDni(); break;
                    case 11: VerOperacionesPorCuenta(); break;
                    case 12:
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

        // Métodos de menú

        static void AgregarCliente()
        {
            Console.Write("DNI: ");
            string dni = Console.ReadLine();

            Console.Write("Nombre y Apellido: ");
            string nombre = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Fecha de nacimiento (yyyy-mm-dd): ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            banco.AgregarCliente(dni, nombre, email, telefono, fecha);
            Console.WriteLine("Cliente agregado correctamente.");
        }

        static void ModificarCliente()
        {
            Console.Write("DNI del cliente a modificar: ");
            string dni = Console.ReadLine();

            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Nuevo teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Nuevo email: ");
            string email = Console.ReadLine();

            Console.Write("Nueva fecha de nacimiento (yyyy-mm-dd): ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            banco.ModificarCliente(dni, nombre, telefono, email, fecha);
            Console.WriteLine("Cliente modificado.");
        }

        static void EliminarCliente()
        {
            Console.Write("DNI del cliente a eliminar: ");
            string dni = Console.ReadLine();

            banco.EliminarCliente(dni);
            Console.WriteLine("Cliente eliminado.");
        }

        static void CrearCajaAhorro()
        {
            Console.Write("Código de cuenta: ");
            string codigo = Console.ReadLine();

            Console.Write("DNI del titular: ");
            string dni = Console.ReadLine();

            banco.CrearCajaAhorro(codigo, dni);
            Console.WriteLine("Caja de ahorro creada.");
        }

        static void CrearCuentaCorriente()
        {
            Console.Write("Código de cuenta: ");
            string codigo = Console.ReadLine();

            Console.Write("DNI del titular: ");
            string dni = Console.ReadLine();

            banco.CrearCuentaCorriente(codigo, dni);
            Console.WriteLine("Cuenta corriente creada.");
        }

        static void ModificarTitularCuenta()
        {
            Console.Write("Código de cuenta: ");
            string codigo = Console.ReadLine();

            Console.Write("Nuevo DNI del titular: ");
            string nuevoDni = Console.ReadLine();

            banco.ModificarTitularCuenta(codigo, nuevoDni);
            Console.WriteLine("Titular modificado.");
        }

        static void Depositar()
        {
            Console.Write("Código de cuenta: ");
            string codigo = Console.ReadLine();

            Console.Write("Importe a depositar: ");
            decimal importe = decimal.Parse(Console.ReadLine());

            banco.Depositar(codigo, importe);
            Console.WriteLine("Depósito realizado.");
        }

        static void Extraer()
        {
            Console.Write("Código de cuenta: ");
            string codigo = Console.ReadLine();

            Console.Write("Importe a extraer: ");
            decimal importe = decimal.Parse(Console.ReadLine());

            banco.Extraer(codigo, importe);
            Console.WriteLine("Extracción realizada.");
        }

        static void ListarClientes()
        {
            Console.WriteLine("=== CLIENTES DEL BANCO ===");
            var clientes = banco.ObtenerTodosLosClientes();
            foreach (var c in clientes)
            {
                Console.WriteLine($"DNI: {c.Dni}, Nombre: {c.Nombre}, Tel: {c.Telefono}, Email: {c.Email}");
            }
        }

        static void ListarCuentasPorDni()
        {
            Console.Write("DNI del cliente: ");
            string dni = Console.ReadLine();

            var cuentas = banco.ObtenerCuentasPorDniTitular(dni);
            foreach (var cuenta in cuentas)
            {
                Console.WriteLine($"Código: {cuenta.Codigo}, Saldo: {cuenta.Saldo}, Tipo: {cuenta.GetType().Name}");
            }
        }

        static void VerOperacionesPorCuenta()
        {
            Console.Write("Código de cuenta: ");
            string codigo = Console.ReadLine();

            var operaciones = banco.ObtenerOperacionesDeCuenta(codigo);
            foreach (var op in operaciones)
            {
                Console.WriteLine($"{op.Fecha} - {op.Tipo} - ${op.Importe}");
            }
        }
    }
}




