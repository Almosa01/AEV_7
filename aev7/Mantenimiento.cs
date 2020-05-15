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
            CargaListaEmpleados();
            CargaListaFichajes();

        }
        private void CargaListaEmpleados()
        {
            string seleccion = "Select * from empleados";
            if (ConexionBD.AbrirConexion())
            {
                dgvEmpleados.DataSource = Empleado.BuscarEmpleado(ConexionBD.Conexion, seleccion);
                ConexionBD.CerrarConexion();
            }
            else
            {
                MessageBox.Show("No se ha podido abrir la conexión con la Base de Datos");
            }
        }
        private void CargaListaFichajes()
        {
            string seleccion = "SELECT id,dia,hora_entrada,hora_salida,nif FROM fichajes";
            if (ConexionBD.AbrirConexion())
            {
                dataGridView2.DataSource = Fichaje.BuscarFichaje(ConexionBD.Conexion, seleccion);
                ConexionBD.CerrarConexion();
            }
            else
            {
                MessageBox.Show("No se ha podido abrir la conexión con la Base de Datos");
            }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Empleado.ComprobarDni(txtNif.Text.ToUpper()))
            {
                try
                {
                    if (ConexionBD.AbrirConexion())
                    {
                        Empleado emp = new Empleado();
                        emp.Nif = txtNif.Text;
                        bool empleadoEliminado = Empleado.EliminaEmpleado(ConexionBD.Conexion, emp);

                        if (empleadoEliminado)
                            MessageBox.Show("Empleado eliminado.");
                        else
                            MessageBox.Show("No se ha podido eliminado el empleado.");
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
        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    } 
}
  