using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using MySqlX.XDevAPI;
using System.Net;
using System.Net.Sockets;

namespace AppProyectoBD
{
	public partial class Login : Form
	{
		bool estado;
		MySqlConnection connection = new MySqlConnection("datasource=localhost;database=EditorialPiedra;username=root;password = 1016;Integrated Security=True;");
		Conexion co;

		String sesion = System.Diagnostics.Process.GetCurrentProcess().SessionId.ToString();
        
		
		public Login()
		{
			InitializeComponent();
            Region = Funciones.redondear(Width, Height);
			co = new Conexion(connection);
            AcceptButton = this.button1;
			this.StartPosition = FormStartPosition.CenterScreen;
		}

		
		public static string GetOSFriendlyName()
		{
			string result = string.Empty;
			ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
			foreach (ManagementObject os in searcher.Get())
			{
				result = os["Caption"].ToString();
				break;
			}
			return result;
		}

		public static string GetLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					return ip.ToString();
				}
			}
			throw new Exception("No network adapters with an IPv4 address in the system!");
		}

		private void Login_Load(object sender, EventArgs e)
		{
            ses.Text = co.ultSesion;
            int x = this.Width / 2;
            ses.Location = new Point(x - ses.Width / 2, ses.Location.Y);
            button1.Location = new Point(x - button1.Width / 2, button1.Location.Y);
        }

		private void pbCerrar_Click(object sender, EventArgs e)
		{
			timer1.Start();
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


		private void timer1_Tick(object sender, EventArgs e)
		{
			if(this.Opacity > 0.0)
			{
				this.Opacity -= 0.845;
			}

			else
			{
				timer1.Stop();
				Application.Exit();
			}
		}


		public string queryToString(string query)
		{//NOS TRANSFORMA EL RESULTADO DE UNA QUERY A STRING
			DataTable tabla = new DataTable();

            try
            {
                co.Comando(query);
                tabla.Load(co.Leer);
            }
            catch (Exception)
            {
                
            }
   
            //RETORNA EL RESULTADO DE LA CONSULTA EN STRING
            return tabla.Rows[0][0].ToString();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            Funciones.ReleaseCapture();
            Funciones.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string user = tbUser.Text;
                string pwd = tbPwd.Text;
                string queryUsr = queryToString("SELECT usr_login FROM Usuarios WHERE usr_login = '" + user + "';");
                string queryPwd = queryToString("SELECT usr_pwd FROM Usuarios WHERE usr_login = '" + user + "';");
                int idUsr = Convert.ToInt32(queryToString("SELECT usr_id FROM Usuarios WHERE usr_login = '" + user + "';"));
                int numToken = Convert.ToInt32(queryToString("SELECT MAX(ses_id) AS SES_ID FROM Sesiones;"));

                if (user == queryUsr && pwd == queryPwd)
                {
                    co.Comando("INSERT INTO Sesiones(ses_cadena,ses_inicio,ses_ip,ses_so,usr_id)" +
                                "VALUES('sesion" + (numToken + 1) + "',now(),'" + GetLocalIPAddress() + "','" + GetOSFriendlyName() + "'," + idUsr + ");");

                    co.Comando("SELECT p.perm_permisos FROM Permisos AS p " +
                               "INNER JOIN Roles AS r ON(r.rol_id = p.rol_id) " +
                               "INNER JOIN Roles_Usuarios AS ru ON(r.rol_id = ru.rol_id) " +
                               "INNER JOIN Usuarios AS u ON(u.usr_id = ru.usr_id) WHERE u.usr_id = " + idUsr + ";");
                    if (co.LeerRead)
                        co.permiso = co.Leer.GetString(0);
                    Form principal = new Form1(idUsr, numToken + 1, co);
                    principal.Show();
                    this.Close();
                }
                else
                {
                    MessageBox mens = new MessageBox("Contraseña o usuario incorrectos", 3);
                    mens.ShowDialog();
                }
            }

            catch (Exception)
            {
                MessageBox mens = new MessageBox("Error de conexión", 3);
                mens.ShowDialog();
            }

        }
    }
}
