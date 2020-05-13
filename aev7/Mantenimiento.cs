using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aev7
{
    public partial class Mantenimiento : Form
    {
        public Mantenimiento()
        {
            InitializeComponent();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Empleado.ComprobarDni(txtNif.Text.ToUpper()))
            {
                try
                {
                    if (ConexionBD.AbrirConexion())
                    {
                        Empleado emp = new Empleado();
                        emp.Nif = txtNif.Text;
                        emp.Nombre = txtNombre.Text;
                        emp.Apellidos = txtApellido.Text;
                        if (checkBox1.Checked)
                            emp.Administrador = 1;
                        else
                            emp.Administrador = 0;

                        emp.Contraseña = txtContraseña.Text;

                        bool empleadoCreado = Empleado.AgregarEmpleado(ConexionBD.Conexion, emp);

                        if (empleadoCreado)
                            MessageBox.Show("Empleado creado.");
                        else
                            MessageBox.Show("No se ha podido crear el empleado.");
                    }
                    else
                        MessageBox.Show("No hay conexión con la Base de Datos");

                    ConexionBD.CerrarConexion();
                }
                catch { }
            }
            else
                MessageBox.Show("DNI inválido");
        }

        private void Mantenimiento_Load(object sender, EventArgs e)
        {

        }
        //private void CargaListaUsuarios()
        //{
        //    string seleccion = "Select * from usuarios";
        //    if (ConexionBD.AbrirConexion())
        //    {
        //        dgvEmpleados.DataSource = Empleado.AgregarEmpleado(ConexionBD.Conexion, seleccion);
        //        ConexionBD.CerrarConexion();
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se ha podido abrir la conexión con la Base de Datos");
        //    }
        //}
    }
}
