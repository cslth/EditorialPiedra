using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PruebaA;

namespace AppProyectoBD
{
    public partial class MessageBox : Form
    {
        bool instanciaAbierta;
        /*
         * 1 - Advertencia: Generalmente usada para confirmar la eliminacion de un elemento
         * 2 - Aviso: Se usa para avisar que una accion no se puede llevar a cabo
         * 3 - Error: Indica los errores
         */
        public MessageBox(String texto, int opc)
        {
            InitializeComponent();
            Region = Funciones.redondear(Width, Height);
            button2.Visible = false;

            switch (opc)
            {
                case 1:
                    label1.Text = "ADVERTENCIA";
                    button2.Visible = true;
                    break;
                case 2:
                    label1.Text = "AVISO";
                    break;
                case 3:
                    label1.Text = "ERROR";
                    break;
                default:
                    label1.Text = "AVISO";
                    break;
            }
            int x = panel7.Width / 2;
            label1.Location = new Point(x - label1.Width / 2, label1.Location.Y);

            label2.Text = texto;
            //Se adapta el tamaño del texto del label dependiendo del tamaño de la palabara
            while (label2.Width > this.Width)
            {
                label2.Font = new Font("Gothic A1", label2.Font.Size - 0.5f, label2.Font.Style);
            }
            //Se ajusta su posicion para que se centre
            int c = this.Width / 2;
            int y = this.Height / 2;
            label2.Location = new Point(c - label2.Width / 2,  y - label2.Height/2 );
            instanciaAbierta = false;  
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {      
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Al dar de alta los Pagos de los empleados asignados a un trabajo
            FormularioProgramarPago frm2 = Application.OpenForms.OfType<FormularioProgramarPago>().FirstOrDefault();
            if (frm2 != null)//Si encuentra una instancia abierta
            {
                instanciaAbierta = true;
                frm2.estado = true;
            }

            if (!instanciaAbierta)
            {
                //Al gurdar la edicion de un trabajo
                VisuaTrabajos frm3 = Application.OpenForms.OfType<VisuaTrabajos>().FirstOrDefault();
                if (frm3 != null)//Si encuentra una instancia abierta
                {
                    if (frm3.editando)
                    {
                        frm3.aceptar = true;
                    }
                    else
                    {
                        frm3.aceptarElim = true;
                    }
                    
                    instanciaAbierta = true;
                }
            }

            if (!instanciaAbierta)
            {
                //Eliminar un Proyecto
                VisuaProyecto frm4 = Application.OpenForms.OfType<VisuaProyecto>().FirstOrDefault();
                if(frm4 != null)
                {
                    frm4.confirmacion = true;
                    instanciaAbierta = true;
                }
            }

            if (!instanciaAbierta)
            {
                FormularioPago fp = Application.OpenForms.OfType<FormularioPago>().FirstOrDefault();
                if(fp != null)
                {
                    instanciaAbierta = true;
                    fp.acep = true;
                }
            }
            if (!instanciaAbierta)
            {
                Utilidades fp = Application.OpenForms.OfType<Utilidades>().FirstOrDefault();
                if (fp != null)
                {
                    fp.aceptar = true;
                    instanciaAbierta = true;
                }
            }
            if (!instanciaAbierta)
            {
                registroEmpleado frm3 = Application.OpenForms.OfType<registroEmpleado>().FirstOrDefault();
                if (frm3 != null)
                {
                    frm3.resultado1 = true;
                    instanciaAbierta = true;
                }
            }
            if (!instanciaAbierta)
            {
                edicionEmpleado frm3 = Application.OpenForms.OfType<edicionEmpleado>().FirstOrDefault();
                if (frm3 != null)
                {
                    frm3.resultado = true;
                    instanciaAbierta = true;
                }
            }
            if (!instanciaAbierta)
            {
                Empleados frm7 = Application.OpenForms.OfType<Empleados>().FirstOrDefault();
                if (frm7 != null)
                {
                    frm7.resultado2 = true;
                    instanciaAbierta = true;
                }
            }


            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
