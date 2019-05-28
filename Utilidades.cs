using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProyectoBD
{
    public partial class Utilidades : Form
    {
        Conexion co;
        bool tipoTrab = false;
        bool redesSoc = false;
        bool tipoEmp = false;
        public bool aceptar = false;
        int ID;
        public Utilidades(Conexion co)
        {
            InitializeComponent();
            this.co = co;
            cargarDatos();
        }
        public void cargarDatos()
        {
            int i = 0;
            int ren = 0;
            //Datos de Tipos de empleado
            co.Comando("SELECT COUNT(*) FROM TipEmp;");
            if (co.LeerRead)
                ren = co.Leer.GetInt32(0);

            if (ren > 0)
                tipoEmpleado.RowCount = ren;
            else
            {
                tipoEmpleado.RowCount = 1;
                tipoEmpleado[0, 0].Value = "";
                tipoEmpleado[1, 0].Value = "";
            }

            //Datos de tipos de trabajos
            co.Comando("SELECT * FROM TipEmp;");
            while (co.LeerRead)
            {
                tipoEmpleado[0, i].Value = co.Leer.GetInt32(0);
                tipoEmpleado[1, i].Value = co.Leer.GetString(1);
                i++;
            }
            
            co.Comando("SELECT COUNT(*) FROM TipoTrabajos;");
            if (co.LeerRead)
                ren = co.Leer.GetInt32(0);

            if (ren > 0)
                tipoTrabajo.RowCount = ren;
            else
            {
                tipoTrabajo.RowCount = 1;
                tipoTrabajo[0, 0].Value = "";
                tipoTrabajo[1, 0].Value = "";
            }

            i = 0;
            co.Comando("SELECT ID, NombreTipoTrab FROM TipoTrabajos;");
            while (co.LeerRead)
            {
                tipoTrabajo[0, i].Value = co.Leer.GetInt32(0);
                tipoTrabajo[1, i].Value = co.Leer.GetString(1);
                i++;
            }

            //Datos de tipos de redes sociales
            co.Comando("SELECT COUNT(*) FROM TipoDeRedSocial;");
            if (co.LeerRead)
                ren = co.Leer.GetInt32(0);

            if (ren > 0)
                redesSociales.RowCount = ren;
            else
            {
                redesSociales.RowCount = 1;
                redesSociales[0, 0].Value = "";
                redesSociales[1, 0].Value = "";
            }

            i = 0;
            co.Comando("SELECT ID, NombreRedSocial FROM TipoDeRedSocial;");
            while (co.LeerRead)
            {
                redesSociales[0, i].Value = co.Leer.GetInt32(0);
                redesSociales[1, i].Value = co.Leer.GetString(1);
                i++;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //Coloco los datos del tipo de trabajo seleccionado en visualizar
            if (!tipoTrabajo[0, tipoTrabajo.CurrentCell.RowIndex].Value.Equals(""))
            {
                ID = Convert.ToInt32(tipoTrabajo[0, tipoTrabajo.CurrentCell.RowIndex].Value);
                label3.Text = "TIPO DE TRABAJO";
                label5.Text = "NOMBRE:";
                richTextBox1.Text = "";
                co.Comando("SELECT * FROM TipoTrabajos WHERE ID = " + ID+";");
                if (co.LeerRead)
                {

                    label5.Text = label5.Text + " " + co.Leer.GetString(1);
                    richTextBox1.Text = co.Leer.GetString(2);
                }
                //Indico que el seleccionado es un tipo de trabajo
                tipoEmp = false;
                tipoTrab = true;
                redesSoc = false;

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //Coloco los datos del tipo de empleado seleccionado en visualizar
            if (!tipoEmpleado[0, tipoEmpleado.CurrentCell.RowIndex].Value.Equals(""))
            {
                ID = Convert.ToInt32(tipoEmpleado[0, tipoEmpleado.CurrentCell.RowIndex].Value);
                label3.Text = "TIPO DE EMPLEADO";
                label5.Text = "NOMBRE: ";
                richTextBox1.Text = "";
                co.Comando("SELECT  NombreTipo, IFNULL(Descripcion,'') FROM TipoEmpleado WHERE ID = " + ID + ";");
                if (co.LeerRead)
                {

                    label5.Text = label5.Text + " " + co.Leer.GetString(0);
                    richTextBox1.Text = co.Leer.GetString(1);
                }
                //Indico que el seleccionado es un tipo de empleado
                tipoEmp = true;
                tipoTrab = false;
                redesSoc = false;
            }
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            //Coloco los datos de la red social seleccionada en visualizar
            if (!redesSociales[0, redesSociales.CurrentCell.RowIndex].Value.Equals(""))
            {
                ID = Convert.ToInt32(redesSociales[0, redesSociales.CurrentCell.RowIndex].Value);
                label3.Text = "RED SOCIAL";
                label5.Text = "NOMBRE: ";
                richTextBox1.Text = "";
                co.Comando("SELECT * FROM TipoDeRedSocial WHERE ID = " + ID + ";");
                if (co.LeerRead)
                {

                    label5.Text = label5.Text + " " + co.Leer.GetString(1);
                }
                //Indico que el seleccionado es una red social
                tipoEmp = false;
                tipoTrab = false;
                redesSoc = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                //Se manda llamar el frame correspondiente en modo edicion segun el elemento que se desea editar
                if (redesSoc)
                {
                    AgregarRedesSociales frame = new AgregarRedesSociales(co, ID, true);
                    frame.ShowDialog();
                }
                if (tipoEmp)
                {

                    AgregarTipoTrabajoEmpleado frame = new AgregarTipoTrabajoEmpleado(co, ID, true, 2);
                    frame.ShowDialog();
                }
                if (tipoTrab)
                {
                    AgregarTipoTrabajoEmpleado frame = new AgregarTipoTrabajoEmpleado(co, ID, true, 1);
                    frame.ShowDialog();
                }
                cargarDatos();
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 1);
                mens.ShowDialog();
            }
        }

        public void reset()
        {
            label3.Text = "NO HAY NADA SELECCIONADO";
            label5.Text = "NOMBRE:";
            richTextBox1.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                //Se elimina el elemento correspondiente pero antes se hace una confirmacion
                //NOTA: Solo se elimina en caso de que no este siendo utilizado por ningun otro elemento de la BD
                int total = 0;
                if (redesSoc)
                {
                    co.Comando("SELECT COUNT(*) FROM RedesSociales WHERE TipoDeRedSocialID = " + ID);
                    if (co.LeerRead)
                        total = co.Leer.GetInt32(0);
                    if (total == 0)
                    {
                        MessageBox mens = new MessageBox("¿Seguro que desea eliminar?", 1);
                        mens.ShowDialog();
                        if (aceptar)
                            co.Comando("CALL PROCEDURE  delete_TipoDeRedSocial(" + ID + ");");

                    }
                    else
                    {
                        MessageBox mens = new MessageBox("Esta siendo utilizado", 2);
                        mens.ShowDialog();
                    }
                }
                if (tipoTrab)
                {
                    co.Comando("SELECT COUNT(*) FROM Trabajos WHERE TipoTrabajosID = " + ID);
                    if (co.LeerRead)
                        total = co.Leer.GetInt32(0);
                    if (total == 0)
                    {
                        MessageBox mens = new MessageBox("¿Seguro que desea eliminar?", 12);
                        mens.ShowDialog();
                        if (aceptar)
                            co.Comando("CALL PROCEDURE  delete_TipoTrabajos(" + ID + ");");

                    }
                    else
                    {
                        MessageBox mens = new MessageBox("Esta siendo utilizado", 2);
                        mens.ShowDialog();
                    }
                }
                if (tipoEmp)
                {
                    MessageBox mens = new MessageBox("Los tipos de empleado no se pueden eliminar", 1);
                    mens.ShowDialog();
                }
                aceptar = false;
                reset();
                cargarDatos();
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 1);
                mens.ShowDialog();
            }
        }

        //Se manda llamar el frame correspondiente para agregar un nuevo elemento
        //------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                AgregarTipoTrabajoEmpleado frame = new AgregarTipoTrabajoEmpleado(co, 0, false, 1);
                frame.ShowDialog();
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 1);
                mens.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                AgregarRedesSociales frame = new AgregarRedesSociales(co, 0, false);
                frame.ShowDialog();
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 1);
                mens.ShowDialog();
            }
        }

        private void butVisua_Click(object sender, EventArgs e)
        {
        }

		private void Utilidades_Load(object sender, EventArgs e)
		{

		}
		//------------------------------------------------------------------------
	}
}
