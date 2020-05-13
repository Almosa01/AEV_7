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
        private bool administrador;
        private DateTime tiempoTrabajando;

        public string Nif { get { return nif; } set { nif = value; } }

        public string Nombre { get { return nombre; } set { nombre = value; } }

        public string Apellidos { get { return apellidos; } set { apellidos = value; } }

        public bool Administrador { get { return administrador; } set { administrador = value; } }

        public DateTime TiempoTrabajando { get { return tiempoTrabajando; } set { tiempoTrabajando = value; } }




        public Empleado(string ni,string nom, string apell, bool admin,DateTime tiempo)
        {
          
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
            } catch { }
            return false;
        }

        public int AgregarEmpleado(MySqlConnection conexion, Empleado emp)
        {
            string empleadoExiste = $"SELECT * FROM empleado WHERE emplado.nif";

            MySqlCommand comando 
            string consulta = $"INSERT INTO empleados(nif,nombre,apellidos,administrador) VALUES ('{emp.nif}','{emp.nombre}','{emp.apellidos}',{emp.Administrador});";

            MySqlCommand comando = new MySqlCommand(consulta, conexion);

            return comando.ExecuteNonQuery();
        }


    }
}
