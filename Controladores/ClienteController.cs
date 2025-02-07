using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPrestamos.Modelos;

namespace SistemaPrestamos.Controladores
{
    public class ClienteController
    {
        public static List<Cliente> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "SELECT * FROM Cliente";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        ID = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Telefono = reader.GetString(2)
                    };
                    listaClientes.Add(cliente);
                }
            }
            return listaClientes;
        }

        public static bool AgregarCliente(Cliente cliente)
        {
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "INSERT INTO Cliente (Nombre, Telefono) VALUES (@Nombre, @Telefono)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Cliente SET Nombre = @Nombre, Telefono = @Telefono WHERE ID = @ID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@ID", cliente.ID);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool EliminarCliente(int id)
        {
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "DELETE FROM Cliente WHERE ID = @ID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@ID", id);
                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
