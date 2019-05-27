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

namespace AppProyectoBD
{
    public partial class Proyectos : Form
    {
        Conexion co;
        public Proyectos()
        {
            InitializeComponent();
            co = new Conexion();
            DatosTablas();
            
        }
        public void DatosTablas()
        {
            //------------------Mostrar datos en tablas Proyectos ----Proyectos en curso----------------------
            /*MySqlConnection conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");
            MySqlConnection conect2 = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");

            MySqlCommand codigo = new MySqlCommand();
            MySqlCommand codigo2 = new MySqlCommand();

            conect.Open();
            conect2.Open();

            codigo.Connection = conect;
            codigo2.Connection = conect2;


            codigo.CommandText = ("SELECT * FROM Proyectos WHERE FechaFin > CURDATE();");
            codigo2.CommandText = ("SELECT COUNT(*) FROM Proyectos WHERE FechaFin > CURDATE();");


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
                dataGridView1[1, i].Value = leer.GetString(1);
                dataGridView1[2, i].Value = leer.GetDateTime(3);
                dataGridView1[3, i].Value = leer.GetDateTime(4);
                dataGridView1[4, i].Value = leer.GetString(5);
                i++;
            }*/
            co.Comando("SELECT COUNT(*) FROM Proyectos WHERE FechaFin > CURDATE();");
            int rows = 0;
            if (co.LeerRead)
                rows = co.Leer.GetInt32(0);

            if (rows == 0)
                rows = 1;

            co.Comando("SELECT * FROM Proyectos WHERE FechaFin > CURDATE();");
            int i = 0;
            dataGridView1.RowCount = rows;
            while (co.LeerRead)
            {
                dataGridView1[0, i].Value = co.Leer.GetInt32(0);
                dataGridView1[1, i].Value = co.Leer.GetString(1);
                dataGridView1[2, i].Value = co.Leer.GetDateTime(3);
                dataGridView1[3, i].Value = co.Leer.GetDateTime(4);
                dataGridView1[4, i].Value = co.Leer.GetString(5);
                i++;
            }
            

                //------------------Mostrar datos en tablas Proyectos ----Proyectos pasados----------------------

            MySqlConnection conect3 = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=334920179;");
            MySqlConnection conect4 = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=334920179;");

            MySqlCommand codigo3 = new MySqlCommand();
            MySqlCommand codigo4 = new MySqlCommand();

            conect3.Open();
            conect4.Open();

            codigo3.Connection = conect3;
            codigo4.Connection = conect4;

            codigo3.CommandText = ("SELECT * FROM Proyectos WHERE FechaFin <= CURDATE();");
            codigo4.CommandText = ("SELECT COUNT(*) FROM Proyectos WHERE FechaFin <= CURDATE();");

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
                dataGridView2[1, i].Value = leer3.GetString(1);
                dataGridView2[2, i].Value = leer3.GetDateTime(3);
                dataGridView2[3, i].Value = leer3.GetDateTime(4);
                dataGridView2[4, i].Value = leer3.GetString(5);
                i++;
            }

            //conect.Close();
            //conect2.Close();
            co.Cerrar();
            conect3.Close();
            conect4.Close();
            //------------------------------------------------------------------------------

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form visuaProy = new VisuaProyecto((int)dataGridView1[0,dataGridView1.CurrentCell.RowIndex].Value,1);
                visuaProy.ShowDialog();
            }
            catch (System.NullReferenceException)
            {
                Form mensaje = new MessageBox("Seleccione un proyecto");
                mensaje.ShowDialog();
            }
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form visuaProy = new VisuaProyecto(0, 2);
            visuaProy.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Visualizar(Le mando el id del proyecto)
            try
            {
                Form visuaProy = new VisuaProyecto((int)dataGridView2[ 0, dataGridView2.CurrentCell.RowIndex].Value, 1);
                visuaProy.ShowDialog();
            }
            catch (System.NullReferenceException)
            {
                Form mensaje = new MessageBox("Seleccione un proyecto");
                mensaje.ShowDialog();
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            //------------------Mostrar datos en tablas Proyectos (en curso)----Realizando busqueda entre fechas----------------------
            MySqlConnection conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");
            MySqlConnection conect2 = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");

            MySqlCommand codigo = new MySqlCommand();
            MySqlCommand codigo2 = new MySqlCommand();

            conect.Open();
            conect2.Open();

            codigo.Connection = conect;
            codigo2.Connection = conect2;

            string fechaInicio = fecha1.Text;
            string año = fechaInicio.Substring(6, 4);
            string mes = fechaInicio.Substring(2, 4);
            string dia = fechaInicio.Substring(0, 2);
            string fechaA = año + mes + dia;

            string fechaFin = fecha2.Text;
            string año2 = fechaFin.Substring(6, 4);
            string mes2 = fechaFin.Substring(2, 4);
            string dia2 = fechaFin.Substring(0, 2);
            string fechaB = año2 + mes2 + dia2;

            codigo.CommandText = ("SELECT * FROM Proyectos WHERE FechaFin between '"+fechaA+"' AND '"+fechaB+"';");
            codigo2.CommandText = ("SELECT COUNT(*) FROM Proyectos WHERE FechaFin  between '" + fechaA + "' AND '" + fechaB + "';");


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
                dataGridView1[1, i].Value = leer.GetString(1);
                dataGridView1[2, i].Value = leer.GetDateTime(3);
                dataGridView1[3, i].Value = leer.GetDateTime(4);
                dataGridView1[4, i].Value = leer.GetString(5);
                i++;
            }

            conect.Close();
            conect2.Close();

        }

        private void buscar2_Click(object sender, EventArgs e)
        {
            //------------------Mostrar datos en tablas Proyectos(finalizados)----Realizando busqueda entre fechas----------------------
            MySqlConnection conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");
            MySqlConnection conect2 = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");

            MySqlCommand codigo = new MySqlCommand();
            MySqlCommand codigo2 = new MySqlCommand();

            conect.Open();
            conect2.Open();

            codigo.Connection = conect;
            codigo2.Connection = conect2;

            string fechaInicio = fecha2.Text;
            string año = fechaInicio.Substring(6, 4);
            string mes = fechaInicio.Substring(2, 4);
            string dia = fechaInicio.Substring(0, 2);
            string fechaA = año + mes + dia;

            string fechaFin = fecha3.Text;
            string año2 = fechaFin.Substring(6, 4);
            string mes2 = fechaFin.Substring(2, 4);
            string dia2 = fechaFin.Substring(0, 2);
            string fechaB = año2 + mes2 + dia2;

            codigo.CommandText = ("SELECT * FROM Proyectos WHERE FechaFin between '" + fechaA + "' AND '" + fechaB + "';");
            codigo2.CommandText = ("SELECT COUNT(*) FROM Proyectos WHERE FechaFin  between '" + fechaA + "' AND '" + fechaB + "';");


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
                dataGridView2[0, i].Value = leer.GetInt32(0);
                dataGridView2[1, i].Value = leer.GetString(1);
                dataGridView2[2, i].Value = leer.GetDateTime(3);
                dataGridView2[3, i].Value = leer.GetDateTime(4);
                dataGridView2[4, i].Value = leer.GetString(5);
                i++;
            }

            conect.Close();
            conect2.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
        }

		private void Proyectos_Load(object sender, EventArgs e)
		{

		}
	}
}
