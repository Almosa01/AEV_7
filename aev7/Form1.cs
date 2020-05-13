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
            mantenimiento1.ShowDialog();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            //if (ConexionBD.AbrirConexion())
            //{
            //    ConexionBD.Conexion;
            //}
            //ConexionBD.CerrarConexion();
            pnlOculto.Visible = false;
            if (Empleado.ComprobarDni(txtDni.Text))
                MessageBox.Show("Hermano, que voy to fino");
            else
                MessageBox.Show("Tengo cancerrrrrr");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlOculto.Visible = true;
        }
    }
}
