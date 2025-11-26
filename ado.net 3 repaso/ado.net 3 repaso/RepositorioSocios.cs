using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ado.net_3_repaso
{
    public class RepositorioSocios
    {
        private readonly List<Socio> ListaSocios;
        private string cadenaConexion = "Data Source=PCDEMIRKO\\SQLEXPRESS;Initial Catalog=club;Integrated Security=True;Persist Security Info=False;Pooling=False;Encrypt=False";

        public RepositorioSocios() 
        {
            ListaSocios = new List<Socio>();
        }

        public IReadOnlyCollection<Socio> ListarSocios() 
        {
            try
            {
                ListaSocios.Clear();
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string sql = "SELECT id, nombre, apellido, dni, fecha_nacimiento, numero_socio, cuota_al_dia FROM Socios";
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    using (SqlDataReader reader = comando.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                            ListaSocios.Add(new Socio
                            {
                                Id = (int)reader["id"],
                                Nombre = reader["nombre"].ToString(),
                                Apellido = reader["apellido"].ToString(),
                                Dni = reader["dni"].ToString(),
                                FechaNacimiento = (DateTime)reader["fecha_nacimiento"],
                                NumeroSocio = (int)reader["numero_socio"],
                                CuotaAlDia = (bool)reader["cuota_al_dia"]
                            });

                        }
                    }
                }
                return ListaSocios.AsReadOnly();
            }
            catch (SqlException ex)
            {
                throw new ErrorSqlException($"Error en la BD: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}");
            }
        }

        public void AgregarSocio(Socio socio) 
        {
            try
            {
                ValidarSocio(socio);

                using (SqlConnection conexion = new SqlConnection(cadenaConexion)) 
                {
                    conexion.Open();
                    string sql = "INSERT INTO Socios (nombre, apellido, dni, fecha_nacimiento, numero_socio, cuota_al_dia)" + 
                        "VALUES (@nombre, @apellido, @dni, @fecha_nacimiento, @numero_socio, @cuota_al_dia)";

                    using (SqlCommand comando = new SqlCommand(sql, conexion)) 
                    {
                        comando.Parameters.AddWithValue("@nombre", socio.Nombre);
                        comando.Parameters.AddWithValue("@apellido", socio.Apellido);
                        comando.Parameters.AddWithValue("@dni", socio.Dni);
                        comando.Parameters.AddWithValue("@fecha_nacimiento", socio.FechaNacimiento);
                        comando.Parameters.AddWithValue("@numero_socio", socio.NumeroSocio);
                        comando.Parameters.AddWithValue("@cuota_al_dia", socio.CuotaAlDia);
                        comando.ExecuteNonQuery();
                    }
                    ListarSocios();
                }

            }
            catch (SqlException ex)
            {
                throw new ErrorSqlException($"Error en la BD: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}");
            }
        }

        public void ModificarSocio(Socio socio) 
        {
            try
            {
                ValidarSocio(socio);

                if (socio.Id <= 0)
                    throw new DatosInvalidosException("El ID del socio no es valido.");

                using (SqlConnection conexion = new SqlConnection(cadenaConexion)) 
                {
                    conexion.Open();
                    string sql = "UPDATE Socios SET nombre=@nombre, apellido=@apellido, dni=@dni, fecha_nacimiento=@fecha_nacimiento, numero_socio=@numero_socio, cuota_al_dia=@cuota_al_dia " + 
                        " WHERE id=@id";



                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", socio.Id);
                        comando.Parameters.AddWithValue("@nombre", socio.Nombre);
                        comando.Parameters.AddWithValue("@apellido", socio.Apellido);
                        comando.Parameters.AddWithValue("@dni", socio.Dni);
                        comando.Parameters.AddWithValue("@fecha_nacimiento", socio.FechaNacimiento);
                        comando.Parameters.AddWithValue("@numero_socio", socio.NumeroSocio);
                        comando.Parameters.AddWithValue("@cuota_al_dia", socio.CuotaAlDia);
                        comando.ExecuteNonQuery();
                    }
                    ListarSocios();
                }

            }
            catch (SqlException ex)
            {
                throw new ErrorSqlException($"Error en la BD: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}");
            }
        }

        public void EliminarSocio(int id) 
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion)) 
                {
                    conexion.Open();
                    string sql = "DELETE FROM Socios" + " WHERE id=@id";

                    using (SqlCommand comando = new SqlCommand(sql, conexion)) 
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        comando.ExecuteNonQuery();
                    }
                    ListarSocios();
                }
            }
            catch (SqlException ex)
            {
                throw new ErrorSqlException($"Error en la BD: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}");
            }
        }

        public Socio BuscarSocioPorDni(string dni)
        {
            ListarSocios();
            return ListaSocios.FirstOrDefault(x => x.Dni == dni);
        }
        public int ContarSociosConCuotaAlDia() 
        {
            ListarSocios();
            return ListaSocios.Count(x => x.CuotaAlDia);
        }

        public IReadOnlyCollection<Socio> ListarSociosMayoresA(int edad) 
        {
            if (edad < 0) throw new DatosInvalidosException("La edad no puede ser negativa.");

            ListarSocios();
            DateTime fechaCorte = DateTime.Now.AddYears(-edad);
            return ListaSocios.Where(x => x.FechaNacimiento <= fechaCorte).ToList().AsReadOnly();
        }

        public void ValidarSocio(Socio socio)
        {
            if (socio == null)
                throw new Exception("El socio no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(socio.Nombre) || string.IsNullOrWhiteSpace(socio.Apellido) || string.IsNullOrWhiteSpace(socio.Dni))
                throw new DatosInvalidosException("El nombre, apellido y dni no pueden estar vacios.");

            if (socio.FechaNacimiento > DateTime.Now)
                throw new DatosInvalidosException("La fecha de nacimiento no puede ser mayor a la fecha actual.");

            if (socio.NumeroSocio <= 0)
                throw new DatosInvalidosException("El numero de socio debe ser mayor a cero.");
        }

    }
}
