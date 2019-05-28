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
    public partial class AgregarTipoTrabajoEmpleado : Form
    {
        Conexion co;
        int ID;
        bool editar;
        int opc;                              // 1 - Tipo de trabajo | 2 - Tipo de empleado
        public AgregarTipoTrabajoEmpleado(Conexion co, int id, bool editar, int opc)
        {
            InitializeComponent();
            Region = Funciones.redondear(Width, Height);

            this.co = co;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.editar = editar;
            this.opc = opc;
            this.ID = id;
            //Si esta en modo edicion se carga el elemento seleccionado en el frame Utilidades
            if (editar)
            {
                //Si es opcion 1 quiere decir que es un Tipo de trabajo
                if (opc == 1)
                {             
                    co.Comando("SELECT NombreTipoTrab, DescripcionTrab FROM TipoTrabajos WHERE ID = " + ID);
                    if (co.LeerRead)
                    {
                        nombre.Text = co.Leer.GetString(0);
                        descripcion.Text = co.Leer.GetString(1);
                    }
                    label1.Text = "TIPO DE TRABAJO";
                }
                //Si no, quiere decir que es un Tipo de empleado
                else
                {

                    nombre.Enabled = false;
                    co.Comando("SELECT NombreTipo, IFNULL(Descripcion,'') FROM TipoEmpleado WHERE ID = "+ID);
                    if (co.LeerRead)
                    {
                        nombre.Text = co.Leer.GetString(0);
                        descripcion.Text = co.Leer.GetString(1);
                    }
                    label1.Text = "TIPO DE EMPLEADO";

                }
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!nombre.Text.Equals("") && !descripcion.Text.Equals(""))
            {
                //En caso de no estar editando, solo se hace un INSERT, caso contrario se hace un UPDATE
                if (!editar)
                {
                    //Si es opcion 1 se inserta en TipoTrabajos
                    if (opc == 1)
                    {
                        co.Comando("CALL PROCEDURE insert_TipoTrabajo("+nombre.Text + ", " + descripcion.Text + ");");
                    }
    
                }
                else
                {
                    //Si es opcion 1 se actualiza TipoTrabajos
                    if (opc == 1)
                    {
                        co.Comando("CALL PROCEDURE update_TipoTrabajo("+ nombre.Text + "," + descripcion.Text + "," + ID+");");
                    }
                    //Si es opcion 2 se actualiza TipoEmpleado
                    else
                    {
                        co.Comando("CALL PROCEDURE update_Desc_TipoTrabajo(" + descripcion.Text + "," + ID + ");");
                    }
                }
                //Se actualizan los datos de las tablas del frame Utilidades
                Utilidades frm2 = Application.OpenForms.OfType<Utilidades>().FirstOrDefault();
                if (frm2 != null)//Si encuentra una instancia abierta
                {
                    frm2.reset();
                    frm2.cargarDatos();
                }
                this.Close();
            }
            else
            {
                MessageBox mens = new MessageBox("Rellene todos los campos", 1);
                mens.ShowDialog();
            }
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Funciones.ReleaseCapture();
            Funciones.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
