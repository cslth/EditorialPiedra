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
        Conexion co;
        public bool confirmacion;
        public VisuaProyecto(Conexion co,int id, int elem)
        {
            InitializeComponent();
            Region = Funciones.redondear(Width, Height);

            this.co = co;
            //Ajusto el formato de los datetimePicker
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.StartPosition = FormStartPosition.CenterScreen;
            //Opcion seleccionada
            sel = elem;
            //Proyecto seleccionado
            IDPro = id;
            //Incializo la confirmacion de eliminacion
            confirmacion = false;
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
                co.Comando("SELECT * FROM Proyectos WHERE ID ="+id);
                if (co.LeerRead)
                {
                    nombre.Text = co.Leer.GetString(1);
                    richTextBox1.Text = co.Leer.GetString(2);
                    dateTimePicker1.Value = co.Leer.GetDateTime(3);
                    dateTimePicker2.Value = co.Leer.GetDateTime(4);

                }
                //----------------------- REVISAR EN LA COMPUTADORA DE JOSUE ----------------------------------------
                
                /*string fechaInicio = co.Leer.GetString(3);
                string año = fechaInicio.Substring(6, 4);
                string mes = fechaInicio.Substring(3, 2);
                string dia = fechaInicio.Substring(0, 2);
                dateTimePicker1.Value = new DateTime(Convert.ToInt32(año),Convert.ToInt32(mes),Convert.ToInt32(dia));*/

                /*string fechaFin = co.Leer.GetString(4);
                string año2 = fechaFin.Substring(6, 4);
                string mes2 = fechaFin.Substring(3, 2);
                string dia2 = fechaFin.Substring(0, 2);
                dateTimePicker2.Value = new DateTime(Convert.ToInt32(año2), Convert.ToInt32(mes2), Convert.ToInt32(dia2));*/

                List<String> Nombre = new List<String>();
                Nombre.Add(co.Leer.GetString(5));
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
                co.Comando("SELECT Nombre FROM Empleado");

                List<String> Nombres = new List<String>();
                while (co.LeerRead)
                {
                    String Nombre = co.Leer.GetString(0);
                    Nombres.Add(Nombre);
                }
                comboBox1.DataSource = Nombres;
            }
        }

        //Valido los datos del formulario para que no sean nulos
        private bool Validacion()
        {
            if (nombre.Text.Equals("") || richTextBox1.Text.Equals(""))
            {
                MessageBox mens = new MessageBox("Complete el formulario", 12);
                mens.ShowDialog();
                return false;
            }
                
            return true;
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
            if (co.permiso.Equals(co.administrador))
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
                List<String> Nombres = new List<String>();
                string nombreSel = comboBox1.Text;
                Nombres.Add(nombreSel);

                co.Comando("SELECT Nombre FROM Empleado;");
                while (co.LeerRead)
                {
                    string nom = co.Leer.GetString(0);
                    if (nom != nombreSel)
                        Nombres.Add(nom);
                }
                comboBox1.DataSource = Nombres;

            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 1);
                mens.ShowDialog();
            }
        }

        private void butGuardar_Click(object sender, EventArgs e)
        {
            if (Validacion())
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
                    /*string fechaInicio = dateTimePicker1.Text;
                    string año = fechaInicio.Substring(6, 4);
                    string mes = fechaInicio.Substring(2, 4);
                    string dia = fechaInicio.Substring(0, 2);
                    string fecha1 = año + mes + dia;*/
                    string fecha1 = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");

                    /*string fechaFin = dateTimePicker2.Text;
                    string año2 = fechaFin.Substring(6, 4);
                    string mes2 = fechaFin.Substring(2, 4);
                    string dia2 = fechaFin.Substring(0, 2);
                    string fecha2 = año2 + mes2 + dia2;*/
                    string fecha2 = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");

                    co.Comando("CALL PROCEDURE update_Proyectos(" + nombre.Text + "," + richTextBox1.Text + "," + fecha1 + "," + fecha2 + "," + comboBox1.Text + "," + IDPro + ");");
                    //---------------------------------------------------------------------------------
                }
                //Opcion guardar si es desde agregar nuevo proyecto
                else
                {

                    //----------------------Insertar datos en Proyectos--------------------------
                    /*string fechaInicio = dateTimePicker1.Text;
                    string año = fechaInicio.Substring(6, 4);
                    string mes = fechaInicio.Substring(2, 4);
                    string dia = fechaInicio.Substring(0, 2);
                    string fecha1 = año + mes + dia;*/
                    string fecha1 = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");

                    /*string fechaFin = dateTimePicker2.Text;
                    string año2 = fechaFin.Substring(6, 4);
                    string mes2 = fechaFin.Substring(2, 4);
                    string dia2 = fechaFin.Substring(0, 2);
                    string fecha2 = año2 + mes2 + dia2;*/
                    string fecha2 = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");

                    co.Comando("CALL PROCEDURE insert_Proyectos(" + nombre.Text + "," + richTextBox1.Text + "," + fecha1 + "," +
																 fecha2 + "," + comboBox1.Text + ");");

                    //------------------------------------------------------------------------------
                    Form message = new MessageBox("Guardado con exito", 12);
                    message.ShowDialog();
                    this.Close();

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
                this.Close();
            }
           
          
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            Funciones.ReleaseCapture();
            Funciones.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

		private void panel1_Paint_1(object sender, PaintEventArgs e)
		{

		}

		private void butEliminar_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                //-------------------------Eliminar el proyecto seleccionado----------------------------------------
                try
                {
                    //Despliega la confirmacion para eliminar
                    MessageBox confirmar = new MessageBox("¿Seguro que desea eliminar el proyecto?", 12);
                    confirmar.ShowDialog();


                    if (confirmacion)
                    {
                        co.Comando("CALL PROCEDURE delete_Proyectos( "+ IDPro + ");");
                        MessageBox mensaje = new MessageBox("Eliminado con exito", 12);
                        mensaje.ShowDialog();
                        this.Close();
                    }

                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox mensaje = new MessageBox("Este proyecto tiene trabajos asociados", 12);
                    mensaje.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 1);
                mens.ShowDialog();
            }
        }
    }
}
