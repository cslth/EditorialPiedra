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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace AppProyectoBD
{
    public partial class Login : Form
    {
        bool estado;
        public Login()
        {
            InitializeComponent();
            //Coloca el frame en el centro
            this.StartPosition = FormStartPosition.CenterScreen;
            estado = false;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        public void AbrirForm(object form2)
        {
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

        //Codigo para dar funciones a la barra superior
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conect = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=334920179");
            conect.Open();

            MySqlCommand codigo = new MySqlCommand();
           // MySqlConnection conect2 = new MySqlConnection();
            codigo.Connection = conect;

            codigo.CommandText = ("SELECT * FROM Usuario WHERE nombre= '" + usuario.Text + "' AND contraseña='" + pwd.Text+"'");

            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                Form principal = new Form1();
                principal.Show();
                Close();
            }
            else
            {
                Form mensa = new MessageBox("Usuario o contraseña incorrectos");
                mensa.ShowDialog();
            }
            conect.Close();
            
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void pbCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbMin_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel7_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
