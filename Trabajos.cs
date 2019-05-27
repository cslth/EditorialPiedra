using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace AppProyectoBD
{
    
    public partial class Trabajos : Form
    {
        Conexion co;
        public Trabajos()
        {
            InitializeComponent();
            co = new Conexion();
            DatosTablas();
            
        }
        public void DatosTablas()
        {
            //------------------Mostrar datos en tablas Tabajos ----Trabajos actuales----------------------
            /*MySqlConnection conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");
            MySqlConnection conect2 = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");

            conect.Open();
            conect2.Open();

            MySqlCommand codigo = new MySqlCommand();
            MySqlCommand codigo2 = new MySqlCommand();

            codigo.Connection = conect;
            codigo2.Connection = conect2;

            codigo.CommandText = ("SELECT * FROM Trabajos WHERE FechaEntrega > CURDATE();");
            codigo2.CommandText = ("SELECT COUNT(*) FROM Trabajos WHERE FechaEntrega > CURDATE();");

            MySqlDataReader leer = codigo.ExecuteReader();
            MySqlDataReader leer2 = codigo2.ExecuteReader();


            int rows = 0;
            if (leer2.Read())
                rows = leer2.GetInt32(0);
            if (rows == 0)
                rows = 1;
            int i = 0;
            dataGridView1.RowCount = rows;
            while (leer.Read())
            {

                dataGridView1[0, i].Value = leer.GetInt32(0);
                dataGridView1[1, i].Value = leer.GetString(2);
                dataGridView1[2, i].Value = leer.GetString(5);
                dataGridView1[3, i].Value = leer.GetInt32(6);
                i++;
            }*/
            co.Comando("SELECT COUNT(*) FROM Trabajos WHERE FechaEntrega > CURDATE();");
            int rows = 0;
            if (co.LeerRead)
                rows = co.Leer.GetInt32(0);
            if (rows == 0)
                rows = 1;
            int i = 0;
            dataGridView1.RowCount = rows;
            co.Comando("SELECT t.ID, t.nombre, p.Nombre FROM Trabajos AS t, Proyectos AS p WHERE t.ProyectosID = p.ID AND  t.FechaEntrega > CURDATE(); ");
            while (co.LeerRead)
            {
                dataGridView1[0, i].Value = co.Leer.GetInt32(0);
                dataGridView1[1, i].Value = co.Leer.GetString(1);
                dataGridView1[3, i].Value = co.Leer.GetString(2);
                i++;
            }
            i = 0;
            co.Comando("SELECT tipo.NombreTipoTrab FROM Trabajos AS t, TipoTrabajos AS tipo WHERE t.TipoTrabajosID = tipo.ID AND t.FechaEntrega > CURDATE(); ");
            while (co.LeerRead)
            {

                dataGridView1[2, i].Value = co.Leer.GetString(0);
                i++;
            }

            //------------------Mostrar datos en tablas Tabajos ----Trabajos pasados----------------------

            MySqlConnection conect3 = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=334920179;");
            MySqlConnection conect4 = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=334920179;");

            MySqlCommand codigo3 = new MySqlCommand();
            MySqlCommand codigo4 = new MySqlCommand();

            conect3.Open();
            conect4.Open();

            codigo3.Connection = conect3;
            codigo4.Connection = conect4;

            codigo3.CommandText = ("SELECT * FROM Trabajos WHERE FechaEntrega <= CURDATE();");
            codigo4.CommandText = ("SELECT COUNT(*) FROM Trabajos WHERE FechaEntrega <= CURDATE();");

            MySqlDataReader leer3 = codigo3.ExecuteReader();
            MySqlDataReader leer4 = codigo4.ExecuteReader();

            rows = 0;
            if (leer4.Read())
                rows = leer4.GetInt32(0);
            if (rows == 0)
                rows = 1;
            i = 0;
            dataGridView2.RowCount = rows;
            while (leer3.Read())
            {

                dataGridView2[0, i].Value = leer3.GetInt32(0);
                dataGridView2[1, i].Value = leer3.GetString(2);
                dataGridView2[2, i].Value = leer3.GetString(5);
                dataGridView2[3, i].Value = leer3.GetInt32(6);
                i++;
            }

           // conect.Close();
            //conect2.Close();
            conect3.Close();
            conect4.Close();
            //------------------------------------------------------------------------------
        }

        private void Trabajos_Load(object sender, EventArgs e)
        {

        }

        private void butVisua_Click(object sender, EventArgs e)
        {
            try
            {
                Form visuaTrabajos = new VisuaTrabajos((int)dataGridView1[0,dataGridView1.CurrentCell.RowIndex].Value, 1);
                visuaTrabajos.ShowDialog();
            }
            catch (System.NullReferenceException)
            {
                Form mensaje = new MessageBox("Seleccione un trabajo");
                mensaje.ShowDialog();
            }
        }

        private void butVisua2_Click(object sender, EventArgs e)
        {
            try
            {
                Form visuaTrabajos = new VisuaTrabajos((int)dataGridView1[0, dataGridView2.CurrentCell.RowIndex].Value, 1);
                visuaTrabajos.ShowDialog();
            }
            catch (System.NullReferenceException)
            {
                Form mensaje = new MessageBox("Seleccione un trabajo");
                mensaje.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form visuaTrabajos = new VisuaTrabajos(0, 2);
            visuaTrabajos.ShowDialog();
        }
    }
}
