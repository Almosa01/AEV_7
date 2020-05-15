 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aev7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tmrHora.Enabled = true;
            txtFecha.Text = DateTime.Today.ToString("dd-MM-yyyy");



        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento1 = new Mantenimiento();

            if (ConexionBD.AbrirConexion())
            {
                if (Empleado.ComprobarAdmin(ConexionBD.Conexion, txtDni.Text))
                {
                    ConexionBD.CerrarConexion();
                    mantenimiento1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El usuario no es administrador");
                }
            }
            ConexionBD.CerrarConexion();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            if (ConexionBD.AbrirConexion())
            {
                Fichaje.AgregarEntrada(ConexionBD.Conexion, txtDni.Text);
            }
            else
            {
                MessageBox.Show("No se ha establecido la conexion");
            }
            ConexionBD.CerrarConexion();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlOculto.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSalida_Click(object sender, EventArgs e)
        {

            if (ConexionBD.AbrirConexion())
            {
                Fichaje.AgregarSalida(ConexionBD.Conexion, txtDni.Text);
            }
            else
            {
                MessageBox.Show("No se ha establecido la conexion");
            }
            ConexionBD.CerrarConexion();
        }

        private void btnPresencia_Click(object sender, EventArgs e)
        {
            pnlOculto.Visible = false;
            
            if (ConexionBD.AbrirConexion())
            {
                string fichajesPresentes="";
                string seleccion = string.Format("SELECT e.nombre, e.apellidos, f.hora_entrada FROM empleados e INNER JOIN fichajes f ON e.nif=f.nif  WHERE entrada=1 AND salida=0;");
                MySqlCommand comando = new MySqlCommand(seleccion, ConexionBD.Conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                fichajesPresentes += "Empleados presentes: \n\n";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        fichajesPresentes += $"{reader.GetString(0)} {reader.GetString(1)} {reader.GetTimeSpan(2)}";
                    }
                }
                
                reader.Close();
                txtBajofoto.Text = fichajesPresentes;


            }
            else
            {
                MessageBox.Show("fallo de mierda");
            }
            ConexionBD.CerrarConexion();
        }

        private void btnPermanencia_Click(object sender, EventArgs e)
        {
            pnlOculto.Visible = false;
            Fichaje fich = new Fichaje();
            if (ConexionBD.AbrirConexion())
            {
                string seleccion = string.Format("SELECT hora_entrada,hora_salida FROM fichajes");
                MySqlCommand comando = new MySqlCommand(seleccion, ConexionBD.Conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    fich.Hora_Entrada = reader.GetTimeSpan(0);
                    if (reader[1].ToString() != "")//para saber si es null
                    {
                        fich.Hora_Salida = reader.GetTimeSpan(1);
                    }
                    else
                    {
                        fich.Hora_Salida = TimeSpan.MinValue;


                    }
                }
                reader.Close();
               txtBajofoto.Text=Fichaje.CalcularTrabajo(ConexionBD.Conexion, fich.Hora_Entrada, fich.Hora_Salida);
 
                
            }
            else
            {
                MessageBox.Show("No se ha abierto la conexion");
            }
            ConexionBD.CerrarConexion();
        }
    }
}
