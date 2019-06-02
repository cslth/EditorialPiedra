using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AppProyectoBD;

namespace PruebaA
{

	public partial class worker_project_registry : Form
	{
		MySqlConnection connection = new MySqlConnection("datasource=localhost;database=EditorialPiedra;port = 3306;username=root;password = 1016");

        Empleados f;
		public worker_project_registry(Empleados f)
		{
			InitializeComponent();
            Region = Funciones.redondear(Width, Height);

            this.f = f;
			this.CenterToParent();
		}

		private void Form3_Load(object sender, EventArgs e)
		{
			ponerDatos();
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void lblTipoEmpleado_Click(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		public void mostrarRedes()
		{
			string consulta = "SELECT tr.NombreRedSocial AS RED, r.Cuenta FROM TipoDeRedSocial as tr " + 
								"INNER JOIN RedesSociales AS r ON(r.TipoDeRedSocialID = tr.ID) " +
								"INNER JOIN Empleado AS emp ON(emp.ID = r.EmpleadoID) " + 
								"WHERE emp.ID = " + f.idOtroForm + ";";

			MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, connection);
			DataTable tabla = new DataTable();
			//PASAR DATOS A LA TABLA 
			adaptador.Fill(tabla);
			//DATA GRID VIEW TOMA LOS VALORES DE LA TABLA LLENADA DE DATOS DEL ADAPTADOR
			tablaRedes.DataSource = tabla;
		}

		public void mostrarTelefonosEmpleado()
		{
			string consulta = "SELECT emp.ID as ID, t.Telefono as TELEFONO FROM Empleado AS emp " +
							"INNER JOIN Telefonos as t ON(t.EmpleadoID = emp.ID) " +
							"WHERE emp.ID = " + f.idOtroForm + 
							" ORDER BY t.Telefono;";

			MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, connection);
			DataTable tabla = new DataTable();
			//PASAR DATOS A LA TABLA 
			adaptador.Fill(tabla);
			//DATA GRID VIEW TOMA LOS VALORES DE LA TABLA LLENADA DE DATOS DEL ADAPTADOR
			tablaTels.DataSource = tabla;
		}
        
		public void mostrarTipos()
		{
			string consulta = "SELECT te.NombreTipo as 'TIPO DE EMPLEADO' FROM TipoEmpleado as te " +
								"INNER JOIN Empleado_TipoEmpleado as tee ON(tee.TipoEmpleadoID = te.ID) " +
								"INNER JOIN Empleado as emp ON(emp.ID = tee.EmpleadoID)" +
								" WHERE emp.ID =" + f.idOtroForm + ";";

			MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, connection);
			DataTable tabla = new DataTable();
			//PASAR DATOS A LA TABLA 
			adaptador.Fill(tabla);
			//DATA GRID VIEW TOMA LOS VALORES DE LA TABLA LLENADA DE DATOS DEL ADAPTADOR
			tablaTipoEmpleado.DataSource = tabla;
		}

		public void ponerDatos()
		{
			lblNombre.Text += " " + f.nombre;
			lblEmail.Text += " " + f.email;
			lblCalle.Text += " " + f.calle;
			lblColonia.Text += " " + f.colonia;
			lblCP.Text += " " + Convert.ToString(f.cp);
			lblCiudad.Text += " " + f.ciudad;
			lblEstado.Text += " " + f.estado;
			lblRFC.Text += " " + f.rfc;
			lblFN.Text += " " + f.fnac;
			lblSexo.Text += f.sexo == 1 ? " Masculino " : " Femenino";
			imgTrab.ImageLocation = f.locImgTrab;
			mostrarRedes();
			mostrarTelefonosEmpleado();
			mostrarTipos();

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
