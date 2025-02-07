using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamos.Config
{
    internal class ConexionDB
    {
    
     private static string cadenaConexion = "Server=DESKTOP-CG6E7MF\\SQLEXPRESS;Database=Banco;Integrated Security=True;";

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la conexión: " + ex.Message);
            }
            return conexion;
        }
    }
}

