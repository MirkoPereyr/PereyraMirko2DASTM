using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CentroOperaciones
    {
        private RepositorioCuentas repositorioCuentas;
        private RepositorioOperaciones repositorioOperaciones;

        public CentroOperaciones(RepositorioCuentas repoCuentas, RepositorioOperaciones repoOperaciones)
        {
            repositorioCuentas = repoCuentas;
            repositorioOperaciones = repoOperaciones;
        }

        public void Depositar(string codigoCuenta, decimal importe)
        {
            try
            {
                if (importe <= 0)
                    throw new ArgumentException("El monto debe ser mayor que cero.");

                var cuenta = repositorioCuentas.BuscarCuenta(codigoCuenta)
                 ?? throw new InvalidOperationException("La cuenta no existe.");

                cuenta.saldo += importe;

                var operacion = new Operacion();
                operacion.CodigoCuenta = codigoCuenta;
                operacion.Fecha = DateTime.Now;
                operacion.Tipo = TipoOperacion.Deposito;
                operacion.Importe = importe;

                repositorioOperaciones.AgregarOperacion(operacion);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al depositar: {ex.Message}");
            }
            
        }

        public void Extraer(string codigoCuenta, decimal importe)
        {
            try
            {
                if (importe <= 0)
                    throw new ArgumentException("El monto debe ser mayor que cero.");

                var cuenta = repositorioCuentas.BuscarCuenta(codigoCuenta)
                    ?? throw new InvalidOperationException("La cuenta no existe.");

                if (cuenta is CajaAhorro caja)
                {
                    if (importe > caja.MontoMaximoExtraccion)
                        throw new InvalidOperationException("El monto excede el límite de extracción de la caja de ahorro.");

                    if (importe > cuenta.saldo)
                        throw new InvalidOperationException("Fondos insuficientes en la cuenta.");
                }
                else if (cuenta is CuentaCorriente corriente)
                {
                    decimal saldoPostExtraccion = cuenta.saldo - importe;

                    if (saldoPostExtraccion < corriente.LimiteDescubierto)
                        throw new InvalidOperationException("Se supera el limite descubierto");
                }

                cuenta.saldo -= importe;

                var operacion = new Operacion();
                operacion.CodigoCuenta = codigoCuenta;
                operacion.Fecha = DateTime.Now;
                operacion.Tipo = TipoOperacion.Extraccion;
                operacion.Importe = importe;

                repositorioOperaciones.AgregarOperacion(operacion);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al extraer: {ex.Message}");
            }
        }

        public List<Operacion> ObtenerOperacionesDeCuenta(string codigoCuenta)
        {
            return repositorioOperaciones.ObtenerOperacionesPorCuenta(codigoCuenta);
        }
    }
}
