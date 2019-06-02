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
    public partial class AgregarRedesSociales : Form
    {
        Conexion co;
        int ID;
        bool editar;
        public AgregarRedesSociales(Conexion co, int id, bool editar)
        {
            InitializeComponent();
            Region = Funciones.redondear(Width, Height);

            this.co = co;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.editar = editar;
            //Si esta en modo edicion se carga el elemento seleccionado en el frame Utilidades
            if (editar)
            {
                this.ID = id;
                co.Comando("SELECT NombreRedSocial FROM TipoDeRedSocial WHERE ID = " + ID);
                if (co.LeerRead)
                    nombre.Text = co.Leer.GetString(0);
            }
                 
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            //Se comprueba que no este vacio el textbox
            if (!nombre.Text.Equals(""))
            {
                //En caso de no estar editando, solo se hace un INSERT, caso contrario se hace un UPDATE
                if (!editar)
                {
                    co.Comando("INSERT INTO TipoDeRedSocial (NombreRedSocial) VALUES('" + nombre.Text + "');");

                }
                else
                {
                    co.Comando("UPDATE TipoDeRedSocial SET NombreRedSocial = '" + nombre.Text + "' WHERE ID = " + ID + ";");
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
                MessageBox mens = new MessageBox("Rellene todos los campos", 2);
                mens.ShowDialog();
            }
            
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Funciones.ReleaseCapture();
            Funciones.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
