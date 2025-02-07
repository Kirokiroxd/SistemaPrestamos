using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPrestamos.Modelos;

namespace SistemaPrestamos.Controladores
{
    public class PrestamoController
    {
        public static List<Prestamo> ObtenerPrestamos()
        {
            List<Prestamo> listaPrestamos = new List<Prestamo>();
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "SELECT * FROM Prestamo";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Prestamo prestamo = new Prestamo
                    {
                        ID = reader.GetInt32(0),
                        ID_Cliente = reader.GetInt32(1),
                        Monto = reader.GetDecimal(2),
                        Interes = reader.GetDecimal(3),
                        Plazo = reader.GetInt32(4)
                    };
                    listaPrestamos.Add(prestamo);
                }
            }
            return listaPrestamos;
        }

        public static bool AgregarPrestamo(Prestamo prestamo)
        {
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "INSERT INTO Prestamo (ID_Cliente, Monto, Interes, Plazo) VALUES (@ID_Cliente, @Monto, @Interes, @Plazo)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@ID_Cliente", prestamo.ID_Cliente);
                comando.Parameters.AddWithValue("@Monto", prestamo.Monto);
                comando.Parameters.AddWithValue("@Interes", prestamo.Interes);
                comando.Parameters.AddWithValue("@Plazo", prestamo.Plazo);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool ActualizarPrestamo(Prestamo prestamo)
        {
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Prestamo SET Monto = @Monto, Interes = @Interes, Plazo = @Plazo WHERE ID = @ID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@ID", prestamo.ID);
                comando.Parameters.AddWithValue("@Monto", prestamo.Monto);
                comando.Parameters.AddWithValue("@Interes", prestamo.Interes);
                comando.Parameters.AddWithValue("@Plazo", prestamo.Plazo);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool EliminarPrestamo(int id)
        {
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "DELETE FROM Prestamo WHERE ID = @ID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@ID", id);
                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
