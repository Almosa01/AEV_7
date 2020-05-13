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
            int resultado = 0;

            //try
            //{
            //    if (ConexionBD.AbrirConexion())
            //    {
            //        Empleado usu = new Empleado();
            //        usu.nif = txtDni.Text;
            //        usu.Nombre = txtNombre.Text;
            //        usu.Apellidos = txtApellido.Text;
            //        usu.Administrador = checkBox1.Checked;
            //        usu.Contrasña = txtContraseña.Text;

            //        if (String.IsNullOrEmpty(txtIdentidad.Text))  // Estoy agregando un usuario nuevo
            //        {

            //            if (Usuario.BuscarUsuario(ConexionBD.Conexion, usu.Nombre, usu.Apellidos))
            //            {
            //                DialogResult confirmar = MessageBox.Show("Deseas dar de alta al usuario", "Alta", MessageBoxButtons.YesNo);
            //                if (confirmar == DialogResult.Yes)
            //                {
            //                    resultado = usu.AgregarUsuario(ConexionBD.Conexion, usu);
            //                }
            //            }
            //            else
            //            {
            //                resultado = usu.AgregarUsuario(ConexionBD.Conexion, usu);
            //            }

            //        }
            //        else // Estoy modificando un usuario editado
            //        {
            //            usu.IdUsuario = Convert.ToInt16(txtIdentidad.Text);
            //            resultado = usu.ActualizaUsuario(ConexionBD.Conexion, usu);
            //        }

            //        if (resultado > 0) // Si se ha agregado o modificado limpiamos las cajas de texto
            //        {
            //            txtIdentidad.Clear();
            //            txtNombre.Clear();
            //            txtApellidos.Clear();
            //            txtEmail.Clear();
            //            txtEdad.Clear();
            //            dtpFechaNac.Value = DateTime.Now;
            //            txtCuota.Clear();
            //        }

            //        // Cierro la conexión
            //        ConexionBD.CerrarConexion();
            //        // volvemos a cargar toda la lista de usuarios;
            //        CargaListaUsuarios();

            //    }
            //    else
            //    {
            //        MessageBox.Show("No se ha podido abrir la conexión con la Base de Datos");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            //}
            //finally  // en cualquier caso cierro la conexión (haya error o no)
            //{
            //    ConexionBD.CerrarConexion();
            //}
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
