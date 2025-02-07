using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPrestamos.Modelos;

namespace SistemaPrestamos.Controladores
{
    public class CuentaController
    {
        public static List<Cuenta> ObtenerCuentas()
        {
            List<Cuenta> listaCuentas = new List<Cuenta>();
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "SELECT * FROM Cuenta";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cuenta cuenta = new Cuenta
                    {
                        ID = reader.GetInt32(0),
                        ID_Cliente = reader.GetInt32(1),
                        Saldo = reader.GetDecimal(2)
                    };
                    listaCuentas.Add(cuenta);
                }
            }
            return listaCuentas;
        }

        public static bool AgregarCuenta(Cuenta cuenta)
        {
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "INSERT INTO Cuenta (ID_Cliente, Saldo) VALUES (@ID_Cliente, @Saldo)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@ID_Cliente", cuenta.ID_Cliente);
                comando.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool ActualizarCuenta(Cuenta cuenta)
        {
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Cuenta SET Saldo = @Saldo WHERE ID = @ID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@ID", cuenta.ID);
                comando.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool EliminarCuenta(int id)
        {
            using (SqlConnection conexion = Config.ConexionDB.ObtenerConexion())
            {
                string query = "DELETE FROM Cuenta WHERE ID = @ID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@ID", id);
                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
