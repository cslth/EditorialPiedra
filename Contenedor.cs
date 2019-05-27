using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Threading;

namespace AppProyectoBD
{
    public partial class Form1 : Form
    {
        bool estado;
        Form fh;
        public Form1()
        {
            InitializeComponent();
            estado = false;
            //Coloca el frame en el centro
            this.StartPosition = FormStartPosition.CenterScreen;
            //Mando llamar el panel de inicio
            AbrirForm(new inicio());
        }
        
        public static class Util
        {
            public enum Effect {Roll, Slide, Center, Blend}
            public static void Animate(Control ctl, Effect effect, int msec, int angle)
            {
                int flags = effmap[(int)effect];

                if (ctl.Visible)
                {
                    flags |= 0x10000; angle += 180;
                }
                else
                {
                    if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                    else if (effect == Effect.Blend) throw new ArgumentException();
                }

                flags |= dirmap[(angle % 360) / 45];
                bool ok = AnimateWindow(ctl.Handle, msec, flags);
                if (!ok) throw new Exception("Animation failed");
                ctl.Visible = !ctl.Visible;
                
            }

            private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };
            private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

            [DllImport("user32.dll")]
            private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void principal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menu_Click_1(object sender, EventArgs e)
        {
            
            Util.Animate(sideBar, Util.Effect.Roll, 40, 360);
        }


        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbMax_Click(object sender, EventArgs e)
        {

            if (estado == false)
            {
                this.WindowState = FormWindowState.Maximized;
                estado = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                estado = false;
            }

        }

        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        } 
        //Codigo para dar funcion a la barra superior
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
           
        }

        private void empleados_Click(object sender, EventArgs e)
        {
            lbTitulo.Text = "EMPLEADOS";
        }

        private void proyectos_Click(object sender, EventArgs e)
        {
            lbTitulo.Text = "PROYECTOS";
            AbrirForm(new Proyectos());
        }

        private void trabajos_Click(object sender, EventArgs e)
        {
            lbTitulo.Text = "TRABAJOS";
            AbrirForm(new Trabajos());
        }

        private void reportes_Click(object sender, EventArgs e)
        {
            lbTitulo.Text = "PAGOS";
            AbrirForm(new pagos());
            //Util.Animate(sideBar, Util.Effect.Roll, 150, 360);
        }

        private void inicio_Click(object sender, EventArgs e)
        {
            lbTitulo.Text = "INICIO";
            AbrirForm(new inicio());
        }
        public void AbrirForm(object form2)
        {
            if(this.panelInfo.Controls.Count > 0)
                this.panelInfo.Controls.RemoveAt(0);
            fh = form2 as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelInfo.Controls.Add(fh);
            this.panelInfo.Tag = fh;
            fh.Show();
            fh.StartPosition = FormStartPosition.CenterParent;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void panelInfo_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login lo = new Login();
            lo.Show();
            this.Close();
        }
    }
}
