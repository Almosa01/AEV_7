﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace aev7
{
    class ConexionBD
    {
        // atributo para gestionar la conexión
        private MySqlConnection conexion;

        // Propiedad para acceder a la conexión
        public MySqlConnection Conexion { get { return conexion; } }

        // Constructor que instancia la conexión, definiendo la cadena de conexión (ConnectionString)

        public ConexionBD()
        {
            // Conexión Local
            //string server = "server=127.0.0.1;";
            //string port = "port=3306;";
            //string database = "database=BDUsuarios;";
            //string usuario = "uid=root;";
            //string password = "pwd=;";

            //string dateTimeAvailable = "Convert Zero Datetime=True";
            //string connectionstring = server + port + database + usuario + password + dateTimeAvailable;

            // Ejemplo de Conexión remota: db4free.net
            string server = "server=db4free.net;";
            string oldguids = "oldguids=true;";
            string database = "database=evaluacionBD;";
            string usuario = "uid=alvaroalepuz;";
            string password = "pwd=Metamorfo.1;";
            string connectionstring = server + oldguids + database + usuario + password;

            conexion = new MySqlConnection(connectionstring);
        }

        // Método que se encarga de abrir la conexión
        // Devuelve true/false dependiendo si la conexión se ha abierto con éxito o no
        public bool AbrirConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)  // Inicialmente no es necesario utilizar el objeto ex
            {
                return false;
            }
        }

        // Método que se encarga de cerrar la conexión (evitar dejar conexiones abiertas)
        // Devuelve true/false dependiendo si la conexión se ha cerrado con éxito
        public bool CerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (MySqlException ex) // Inicialmente no es necesario utilizar el objeto ex
            {
                return false;
            }
        }
    }
}
