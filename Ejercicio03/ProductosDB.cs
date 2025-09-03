using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ejercicio03
{
    public class ProductosDB
    {
        private string connectionString
            = "Server=localhost\\SQLEXPRESS;Database=CrudWindowsForm;User Id=Mirko;Password=M!rko2006#Server;";

        public List<Producto> Obtener()
        {
            List<Producto> productos = new List<Producto>();


            string query = "select id,nombre,precio from Productos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Producto oProducto = new Producto();
                        oProducto.Id = reader.GetInt32(0);
                        oProducto.Nombre = reader.GetString(1);
                        oProducto.Precio = reader.GetDecimal(2);
                        productos.Add(oProducto);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {                  
                    throw new Exception("Hay un error en la BD " + ex.Message);
                }

            }

            return productos;
        }

        public Producto Obtener(int Id)
        {
            string query = "select id,nombre,precio from productos" + " where id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Producto oProducto = new Producto();
                    oProducto.Id = reader.GetInt32(0);
                    oProducto.Nombre = reader.GetString(1);
                    oProducto.Precio = reader.GetDecimal(2);

                    reader.Close();

                    connection.Close();

                    return oProducto;
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la BD " + ex.Message);
                }
            }
        }

        public void Agregar(string Nombre, decimal Precio)
        {
            string query = "insert into productos(nombre, precio) values" + "(@nombre, @precio) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@precio", Precio);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la BD " + ex.Message);
                }

            }
        }

        public void Modificar(string Nombre, decimal Precio, int Id)
        {
            string query = "update productos set nombre=@nombre, precio=@precio" + " where id=@id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@precio", Precio);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la BD " + ex.Message);
                }

            }
        }

        public void Eliminar(int Id)
        {
            string query = "delete from productos" + " where id=@id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la BD " + ex.Message);
                }

            }
        }
    }



    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
