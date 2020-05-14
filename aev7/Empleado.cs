using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aev7
{
    class Empleado
    {

        private string nif;
        private string nombre;
        private string apellidos;
        private byte administrador;
        //private DateTime tiempoTrabajando;
        private string contraseña;

        public string Nif { get { return nif; } set { nif = value; } }

        public string Nombre { get { return nombre; } set { nombre = value; } }

        public string Apellidos { get { return apellidos; } set { apellidos = value; } }

        public byte Administrador { get { return administrador; } set { administrador = value; } }

        //public DateTime TiempoTrabajando { get { return tiempoTrabajando; } set { tiempoTrabajando = value; } }

        public string Contraseña { get { return contraseña; } set { contraseña = value; } }




        public Empleado(string ni, string nom, string apell, byte admin, string contra)
        {
            nif = ni;
            nombre = nom;
            apellidos = apell;
            administrador = admin;
            contraseña = contra;
        }
        public Empleado()
        {
        }



        public static bool ComprobarDni(string nif)
        {
            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            try
            {
                if (nif.Length == 9)
                {
                    string letrilla = nif.Substring(8, 1);
                    if (letrilla == letras[int.Parse(nif.Substring(0, 8)) % 23].ToString())
                        return true;
                }
            }
            catch { }
            return false;
        }

        public static bool ComprobarEmpleado(MySqlConnection conexion, string nif)
        {
            string consulta = String.Format("SELECT * FROM empleados WHERE nif LIKE '{0}';", nif);


            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return false; //ya existe
            }
            else
            {
                reader.Close();
                return true;//no exixte
            }
        }

        public static bool AgregarEmpleado(MySqlConnection conexion, Empleado emp)
        {
            if (ComprobarEmpleado(conexion, emp.nif))
            {
                string consulta = $"INSERT INTO empleados (nif,nombre,apellidos,administrador,`password`)" +
                    $"VALUES ('{emp.nif}','{emp.nombre}','{emp.apellidos}',{emp.administrador},'{emp.contraseña}')";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                int result = comando.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public static bool EliminaEmpleado(MySqlConnection conexion, Empleado emp)
        {
            if (ComprobarEmpleado(conexion, emp.nif) == false)
            {
                string consulta = $"DELETE FROM empleados WHERE nif='{emp.nif}'";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                int result = comando.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public static List<Empleado> BuscarEmpleado(MySqlConnection conexion, string consulta)
        {
            List<Empleado> lista = new List<Empleado>();


            MySqlCommand comando = new MySqlCommand(consulta, conexion);


            MySqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Empleado emp = new Empleado(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetByte(3), reader.GetString(4));
                    lista.Add(emp);
                }
            }

            return lista;
        }

        public static bool ComprobarAdmin(MySqlConnection conexion, string nif)
        {
            if (Empleado.ComprobarEmpleado(conexion, nif) == false)
            {
                string consulta = String.Format("SELECT administrador FROM empleados WHERE nif LIKE '{0}';", nif);


                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                bool admin = reader.GetBoolean(0);
                reader.Close();
                return admin;
            }
            else
            {
                return false;
            }

        }


    }


}
