using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace aev7
{
    class Fichaje
    {
        private int id;
        private string nif;
        private DateTime dia;
        private TimeSpan hora_entrada;
        private TimeSpan hora_salida;
        private bool salida;
        private bool entrada;

        public int Id { get { return id; } }
        public string Nif { get { return nif; } }
        public DateTime Dia { get { return dia; } }
        public TimeSpan Hora_Entrada { get { return hora_entrada; } set { hora_entrada = value; } }
        public TimeSpan Hora_Salida { get { return hora_salida; } set { hora_salida = value; } }
        public bool Salida { get { return salida; } set { salida = value; } }
        public bool Entrada { get { return entrada; } set { entrada = value; } }


        public Fichaje(int id, DateTime dia, TimeSpan hora_entrada, TimeSpan hora_salida, bool salida,bool entrada ,string nif)
        {
            this.id = id;
            this.dia = dia;
            this.hora_entrada = hora_entrada;
            this.hora_salida = hora_salida;
            this.salida = salida;
            this.entrada=entrada;
            this.nif = nif;

        }
        public Fichaje() { }




        public static List<Fichaje> BuscarFichaje(MySqlConnection conexion, string consulta)
        {
            List<Fichaje> lista = new List<Fichaje>();


            MySqlCommand comando = new MySqlCommand(consulta, conexion);


            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Fichaje fich = new Fichaje ();
                    fich.id = reader.GetInt32(0);
                    fich.nif = reader.GetString(1);
                    fich.dia = reader.GetDateTime(2);
                    fich.hora_entrada = reader.GetTimeSpan(3);
                    if (reader[3].ToString()!="")//para saber si es null
                    {
                        fich.hora_salida = reader.GetTimeSpan(4);
                    }
                    else
                    {
                        fich.hora_salida = TimeSpan.MinValue;


                    }
                    lista.Add(fich);
                }
            }

            return lista;
        }


        public static bool ComprobarSalida(MySqlConnection conexion,string nif)
        {
                string consulta = String.Format("SELECT salida FROM fichajes WHERE nif LIKE '{0}';", nif);


                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
            

        }
        public static void AgregarEntrada(MySqlConnection conexion, string nif)
        {

            if (Empleado.ComprobarEmpleado(conexion,nif)==false)
            {
                if (ComprobarSalida(ConexionBD.Conexion, nif)==false)
                { 
                    string consulta =$"INSERT INTO fichajes (dia,hora_entrada,entrada,salida,nif)" +
                    $"VALUES ('{DateTime.Now.ToString("yyyy/MM/dd")}','{DateTime.Now.ToString("HH:mm:ss")}',{1},{0},'{nif}')";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    int  comand = comando.ExecuteNonQuery();
                    if (comand > 0)
                    {
                        MessageBox.Show("El fichaje se ha añadido");
                    }
                    else
                    {
                        MessageBox.Show("El fichaje no se ha añadido");
                    }
                }
                else
                {
                    MessageBox.Show("Existe un fichaje de entrada sin cerrar (se ha de fichar de salida)");
                }
            }
            else
            {
                MessageBox.Show("El DNI no existe en la Base de Datos");
            }
        }
        public static void AgregarSalida(MySqlConnection conexion, string nif)
        {

            if (Empleado.ComprobarEmpleado(conexion, nif) == false)
            {
                if (ComprobarSalida(ConexionBD.Conexion, nif) == false)
                {
                    string consulta = $"UPDATE salida SET = 1 WHERE entrada = 1 and nif = '{nif}'";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    int comand = comando.ExecuteNonQuery();
                    if (comand > 0)
                    {
                        MessageBox.Show("El fichaje se ha añadido");
                    }
                    else
                    {
                        MessageBox.Show("El fichaje no se ha añadido");
                    }
                }
                else
                {
                    MessageBox.Show("Existe un fichaje de entrada sin cerrar (se ha de fichar de salida)");
                }
            }
            else
            {
                MessageBox.Show("El DNI no existe en la Base de Datos");
            }
        }
    }
}


//(reader.GetInt32(0), reader.GetDateTime(1), reader.GetTimeSpan(2),reader.GetTimeSpan(3), reader.GetBoolean(4), reader.GetBoolean(4), reader.GetString(5));
//lista.Add(fich)



//int i = dataGridView1.Rows.Add();


//    if (fich.hora_salida == TimeSpan.MinValue)
//    dataGridView1.Rows[i].Cells[2].Value = "NULL";
//else
//    dataGridView1.Rows[i].Cells[2].Value = fich.hora_salida;