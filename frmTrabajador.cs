using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo
{
    public partial class frmTrabajador : Form
    {
        string cadenaConexion = "server=localhost\\SQLEXPRESS; database=TRABAJOS; Integrated security=true";
        public frmTrabajador()
        {
            InitializeComponent();
        }
        string Operacion = "Insertar";
        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {

            dgvListado.Rows.Clear();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = " SELECT T.ID,T.Nombres + ' ' + Apellidos AS Nombre_Apellido,T.Direccion,E.Nombre_Esp" +
                          " FROM Trabajador T " +
                          " INNER JOIN Especialidad E ON T.IdEspecialidad = E.ID ";
                          
                          
                using (var comando = new SqlCommand(sql, conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            while (lector.Read())
                            {
                                dgvListado.Rows.Add(lector[0], lector[1], lector[2], lector[3]);
                            }
                        }
                    }
                }
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frm = new frmTrabajadorEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var nombre = ((TextBox)frm.Controls["txtNombre"]).Text;
                var Apellido = ((TextBox)frm.Controls["txtApellido"]).Text;
                var direccion = ((TextBox)frm.Controls["txtDireccion"]).Text;
                var telefono = ((TextBox)frm.Controls["txtTelefono"]).Text;
                var especialidad = ((ComboBox)frm.Controls["cboEspecialidad"]).SelectedValue.ToString();
                


                using (var conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    var sql = " INSERT INTO Trabajador (Nombres ,Apellidos,Direccion,Telefono, IdEspecialidad) " +
                        " VALUES(@nombre, @apellido, @direccion,@telefono, @Nombre_esp) ";

                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@apellido", Apellido);
                        comando.Parameters.AddWithValue("@direccion", direccion);
                        comando.Parameters.AddWithValue("@telefono", telefono);
                        comando.Parameters.AddWithValue("@Nombre_esp", especialidad);
                      
                        int resultado = comando.ExecuteNonQuery();
                        if (resultado > 0)
                        {
                            MessageBox.Show("El Trabajador ha sido registrado", "Sistemas",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("Error de registro", "Sistemas",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    conexion.Close();
                }
            }
            
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        
    }
}
