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
    public partial class VisuaProyecto : Form
    {
        int sel, IDPro;
        //Proyectos pro;
        public VisuaProyecto(int id, int elem)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            sel = elem;
            IDPro = id;
            //pro = f1;
            

            //Abro conexion con el servidor
            MySqlConnection conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=334920179;");
            conect.Open();
            MySqlCommand codigo = new MySqlCommand();
            codigo.Connection = conect;

            //Habilito botones dependiendo de la opcion de la ventana
            //Si se esta visualizando un proyecto
            if (elem == 1)
            {
                butGuardar.Visible = false;
                butEliminar.Visible = true;
                butCancelar.Visible = false;
                butCerrar.Visible = true;
                nombre.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                comboBox1.Enabled = false;
                richTextBox1.Enabled = false;

                //----------------------Muestro la info del proyecto seleccionado--------------------------
                codigo.CommandText = ("SELECT * FROM Proyectos WHERE ID ="+id);
                MySqlDataReader leer = codigo.ExecuteReader();

                leer.Read();
                nombre.Text = leer.GetString(1);
                richTextBox1.Text = leer.GetString(2);

                string fechaInicio = leer.GetString(3);
                string año = fechaInicio.Substring(6, 4);
                string mes = fechaInicio.Substring(3, 2);
                string dia = fechaInicio.Substring(0, 2);
                dateTimePicker1.Value = new DateTime(Convert.ToInt32(año),Convert.ToInt32(mes),Convert.ToInt32(dia));

                string fechaFin = leer.GetString(4);
                string año2 = fechaFin.Substring(6, 4);
                string mes2 = fechaFin.Substring(3, 2);
                string dia2 = fechaFin.Substring(0, 2);
                dateTimePicker2.Value = new DateTime(Convert.ToInt32(año2), Convert.ToInt32(mes2), Convert.ToInt32(dia2));

                List<String> Nombre = new List<String>();
                Nombre.Add(leer.GetString(5));
                comboBox1.DataSource = Nombre;
                

            }
            //Si se dese agregar un nuevo proyecto
            else
            {
                butGuardar.Visible = true;
                butEliminar.Visible = false;
                butCancelar.Visible = true;
                butEditar.Visible = false;
                butCerrar.Visible = false;
                nombre.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                comboBox1.Enabled = true;
                richTextBox1.Enabled = true;

                //----------------------Mostrar empleados en comboBox--------------------------
                codigo.CommandText = ("SELECT Nombre FROM Empleado");

                MySqlDataReader leer = codigo.ExecuteReader();

                List<String> Nombres = new List<String>();
                while (leer.Read())
                {
                    String Nombre = leer.GetString(0);
                    Nombres.Add(Nombre);
                }
                comboBox1.DataSource = Nombres;
            }
            conect.Close();
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Opcion editar 
            butGuardar.Visible = true;
            butEliminar.Visible = false;
            butEditar.Visible = false;
            nombre.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            comboBox1.Enabled = true;
            richTextBox1.Enabled = true;

            //---------------Mostramos todos los empleados en el comboBox si se da en editar--------------------------
            MySqlConnection conect2 = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");
            conect2.Open();
            MySqlCommand codigo2 = new MySqlCommand();
            codigo2.Connection = conect2;

            List<String> Nombres = new List<String>();
            string nombreSel = comboBox1.Text;
            Nombres.Add(nombreSel);

            codigo2.CommandText = ("SELECT Nombre FROM Empleado;");
            MySqlDataReader leer2 = codigo2.ExecuteReader();

            while (leer2.Read())
            {
                string nom = leer2.GetString(0);
                if (nom != nombreSel)
                    Nombres.Add(nom);
            }
            comboBox1.DataSource = Nombres;
            conect2.Close();


        }

        private void butGuardar_Click(object sender, EventArgs e)
        {
            //Opcion guardar si es desde visualizar
            if (sel == 1)
            {
                butGuardar.Visible = false;
                butEliminar.Visible = true;
                butEditar.Visible = true;
                nombre.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                comboBox1.Enabled = false;
                richTextBox1.Enabled = false;

                //----------------------Guaradr un proyecto editado------------------------------
                MySqlConnection conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");

                conect.Open();

                MySqlCommand codigo = new MySqlCommand();

                codigo.Connection = conect;

                string fechaInicio = dateTimePicker1.Text;
                string año = fechaInicio.Substring(6, 4);
                string mes = fechaInicio.Substring(2, 4);
                string dia = fechaInicio.Substring(0, 2);
                string fecha1 = año + mes + dia;

                string fechaFin = dateTimePicker2.Text;
                string año2 = fechaFin.Substring(6, 4);
                string mes2 = fechaFin.Substring(2, 4);
                string dia2 = fechaFin.Substring(0, 2);
                string fecha2 = año2 + mes2 + dia2;

                codigo.CommandText = ("UPDATE Proyectos SET Nombre ='" + nombre.Text + "',Descripcion = '" + richTextBox1.Text + "',FechaInicio ='" + fecha1 + "',FechaFin ='" + fecha2 + "',Encargado ='" + comboBox1.Text + "'" +
                                        "WHERE ID=" + IDPro + ";");
                MySqlDataReader leer = codigo.ExecuteReader();

                leer.Read();


                conect.Close();
                //---------------------------------------------------------------------------------
            }
            //Opcion guardar si es desde agregar nuevo proyecto
            else
            {
                
                //----------------------Insertar datos en Proyectos--------------------------
                MySqlConnection conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");
                conect.Open();

                MySqlCommand codigo = new MySqlCommand();
                MySqlConnection conect2 = new MySqlConnection();
                codigo.Connection = conect;

                string fechaInicio = dateTimePicker1.Text;
                string año = fechaInicio.Substring(6, 4);
                string mes = fechaInicio.Substring(2, 4);
                string dia = fechaInicio.Substring(0, 2);
                string fecha1 = año + mes + dia;

                string fechaFin = dateTimePicker2.Text;
                string año2 = fechaFin.Substring(6, 4);
                string mes2 = fechaFin.Substring(2, 4);
                string dia2 = fechaFin.Substring(0, 2);
                string fecha2 = año2 + mes2 + dia2;

                
                codigo.CommandText = ("INSERT INTO Proyectos (Nombre,Descripcion,FechaInicio, FechaFin, Encargado ) " +
                                     " VALUES('" + nombre.Text + "','" + richTextBox1.Text + "','"+fecha1+"'," +
                                     "'"+fecha2+"','"+comboBox1.Text+"');");

                MySqlDataReader leer = codigo.ExecuteReader();


                conect.Close();
                //------------------------------------------------------------------------------
                Form message = new MessageBox("Guardado con exito");
                message.ShowDialog();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //pro.refrescar();
            this.Close();
            
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VisuaProyecto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Proyectos frm2 = Application.OpenForms.OfType<Proyectos>().FirstOrDefault();

            if (frm2 != null)  //Si encuentra una instancia abierta
            {
                frm2.DatosTablas();
            }
           
          
        }

		private void panel1_Paint_1(object sender, PaintEventArgs e)
		{

		}

		private void panel1_Paint_2(object sender, PaintEventArgs e)
		{

		}

		private void butEliminar_Click(object sender, EventArgs e)
        {
            //-------------------------Eliminar el proyecto seleccionado----------------------------------------
            MySqlConnection conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");
            conect.Open();
            MySqlCommand codigo = new MySqlCommand();
            codigo.Connection = conect;

            codigo.CommandText = ("DELETE FROM Proyectos WHERE ID =" + IDPro+";");
            MySqlDataReader leer = codigo.ExecuteReader();

            conect.Close();
            MessageBox mensaje = new MessageBox("Eliminado con exito");
            mensaje.ShowDialog();
            this.Close();

        }
    }
}
