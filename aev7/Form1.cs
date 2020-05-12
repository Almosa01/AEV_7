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
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento1 = new Mantenimiento();
            mantenimiento1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void CargaListaUsuarios()
        {
            string seleccion = "Select * from usuarios";
            if (bdatos.AbrirConexion())
            {
                dgvEmpleados.DataSource = Usuario.BuscarUsuario(bdatos.Conexion, seleccion);
                bdatos.CerrarConexion();
            }
            else
            {
                MessageBox.Show("No se ha podido abrir la conexión con la Base de Datos");
            }
        }
    }
}
