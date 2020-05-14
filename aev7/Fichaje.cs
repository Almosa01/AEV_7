using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace aev7
{
    class Fichaje
    {
        private int id;
        private string nif;
        private DateTime fecha;
        private TimeSpan hora_entrada;
        private TimeSpan hora_salida;
        private bool salida;
        private bool entrada;

        public int Id { get { return id; } }
        public string Nif { get { return nif; } }
        public DateTime Fecha { get { return fecha; } }
        public TimeSpan Hora_Entrada { get { return hora_entrada; } set { hora_entrada = value; } }
        public TimeSpan Hora_Salida { get { return hora_salida; } set { hora_salida = value; } }
        public bool Salida { get { return salida; } set { salida = value; } }
        public bool Entrada { get { return entrada; } set { entrada = value; } }


        public Fichaje(int id, string nif, DateTime fecha, TimeSpan hora_entrada, TimeSpan hora_salida, bool salida,bool entrada)
        {
            this.id = id;
            this.nif = nif;
            this.fecha = fecha;
            this.hora_entrada = hora_entrada;
            this.hora_salida = hora_salida;
            this.salida = salida;
            this.entrada=entrada;

        }




        public static List<Fichaje> BuscarFichaje(MySqlConnection conexion, string consulta)
        {
            List<Fichaje> lista = new List<Fichaje>();


            MySqlCommand comando = new MySqlCommand(consulta, conexion);


            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Fichaje fich = new Fichaje (reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2),
                        reader.GetTimeSpan(3), reader.GetTimeSpan(4), reader.GetBoolean(4), reader.GetBoolean(5));
                    lista.Add(fich);
                }
            }

            return lista;
        }


        public static bool ComprobarEntrada(MySqlConnection conexion,string nif)
        {
                string consulta = String.Format("SELECT entrada FROM fichaje WHERE nif LIKE '{0}';", nif);


                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                bool entrada = reader.GetBoolean(0);
                reader.Close();
                return entrada;

        }
        public static bool AgregarEntrada()
        {

            if (ComprobarEntraa(ConexionBD.Conexion,nif)
            {

            }
        }
    }
}
