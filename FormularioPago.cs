using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AppProyectoBD
{
    public partial class FormularioPago : Form
    {
        public FormularioPago()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            comboEmpleado.Enabled = false;
            comboTrabajo.Enabled = false;
            textConcepto.Enabled = false;
            labEmpleado.Enabled = false;
            labConcepto.Enabled = false;
            labTrabajo.Enabled = false;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 1)
            {
                comboEmpleado.Enabled = false;
                comboTrabajo.Enabled = false;
                labEmpleado.Enabled = false;
                labTrabajo.Enabled = false;
                textConcepto.Enabled = true;
                labConcepto.Enabled = true;
            }
            else
            {
                textConcepto.Enabled = false;
                labConcepto.Enabled = false;
                comboEmpleado.Enabled = true;
                comboTrabajo.Enabled = true;
                labEmpleado.Enabled = true;
                labTrabajo.Enabled = true;
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

		private void label1_Click_1(object sender, EventArgs e)
		{

		}

		private void aceptar_Click(object sender, EventArgs e)
		{

		}
	}
}
