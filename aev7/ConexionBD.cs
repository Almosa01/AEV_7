using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace aev7
{
    static class ConexionBD
    {
        // atributo para gestionar la conexión
        private static MySqlConnection conexion = new MySqlConnection("server=db4free.net;oldguids=true;database=evaluacionBD;uid=alvaroalepuz;pwd=Metamorfo.1;");

        // Propiedad para acceder a la conexión
        public static MySqlConnection Conexion { get { return conexion; } }

        // Método que se encarga de abrir la conexión
        // Devuelve true/false dependiendo si la conexión se ha abierto con éxito o no
        public static bool AbrirConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch   // Inicialmente no es necesario utilizar el objeto ex
            {
                return false;
            }
        }

        // Método que se encarga de cerrar la conexión (evitar dejar conexiones abiertas)
        // Devuelve true/false dependiendo si la conexión se ha cerrado con éxito
        public static bool CerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch  // Inicialmente no es necesario utilizar el objeto ex
            {
                return false;
            }
        }
    }
}
