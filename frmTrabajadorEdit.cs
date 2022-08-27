using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo
{
    public partial class frmTrabajadorEdit : Form
    {
        string cadenaConexion = "server=localhost\\SQLEXPRESS; database=TRABAJOS; Integrated security=true";

        public frmTrabajadorEdit()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                // CARGAR DATOS TRABAJADOR
                var sql = "SELECT * FROM  Trabajador";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Dictionary<string, string> TrabajadorSource = new Dictionary<string, string>();
                            while (lector.Read())
                            {
                                TrabajadorSource.Add(lector[0].ToString(), lector[1].ToString());
                            }
                        }
                    }
                }

                // CARGAR DATOS ESPECIALIDAD
                sql = "SELECT * FROM Especialidad";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Dictionary<string, string> EspecialidadSource = new Dictionary<string, string>();
                            while (lector.Read())
                            {
                                EspecialidadSource.Add(lector[0].ToString(), lector[1].ToString());
                            }
                            cboEspecialidad.DataSource = new BindingSource(EspecialidadSource, null);
                            cboEspecialidad.DisplayMember = "Value";
                            cboEspecialidad.ValueMember = "Key";
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        
        
    }
}
