using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
	public partial class Empleados : Form
	{
		//PARA OBTENER EL ID DEL EMPLEADO DEL CUAL QUEREMOS VISUALIZAR INFORMACION
		//var idTabla;
		public static int id;
		public int idOtroForm;
		public string nombre = "";
		public string email = "";
		public string calle = "";
		public string colonia = "";
		public string cp;
		public string ciudad = "";
		public string estado = "";
		public string rfc = "";
		public string fnac = "";
		public int sexo;
		public string locImgTrab = "";

		//QUERIES PARA OBTENER CADA ELEMENTO
		public string queryNombre;
		public string queryEmail;
		public string queryCalle;
		public string queryColonia;
		public string queryCP;
		public string queryCiudad;
		public string queryEstado;
		public string queryRFC;
		public string queryFN;
		public string querySexo;
		public string queryImgEmpleado;


		bool clickEmpleado = false;

        Conexion co;
		public Empleados(Conexion co)
		{
			//SE INICIALIZA LA CONEXION
			InitializeComponent();
            this.co = co;
			this.CenterToParent();


        }

		private void Empleados_Load(object sender, EventArgs e)
		{
			//CARGA LOS DATOS DEL EMPLEADO A LA TABLA
			tablaEmpleados.DataSource = getEmpleadosInfo();
            tablaEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Object idTabla = tablaEmpleados[0, 0].Value;
            if (tablaEmpleados[0, 0].Value != null)
            {
                id = Convert.ToInt32(idTabla.ToString());
                idOtroForm = id;
            }
		}

		private DataTable getEmpleadosInfo()
		{
			//OBTIENE LOS DATOS DEL EMPLEADO GRACIAS A UN DATATABLE 
			DataTable dbEmpleados = new DataTable();

			string query = "SELECT emp.ID AS ID,emp.Nombre as NOMBRE,emp.email as EMAIL," +
							"t.Telefono as TELEFONO,(DATEDIFF(CURDATE(),emp.FechaNacimiento))DIV 365 as EDAD FROM Empleado as emp " +
							"INNER JOIN Telefonos as t ON(t.EmpleadoID = emp.ID)" +
							"GROUP BY NOMBRE;";
			try
			{
				//SE EJECUTA EL COMANDO Y SE PASA A LA TABLA CON LEER
				co.Comando(query);

				dbEmpleados.Load(co.Leer);

                
            }

			catch (Exception)
			{
                //System.Windows.Forms.MessageBox.Show("No se ha encontrado la información\nPor ende, no se puede mostrar");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Error al mostrar la información", 3);
                mens.ShowDialog();
			}

			finally
			{//SE CIERRA LA CONEXION
				//if (co != null) co.Cerrar();
			}

			return dbEmpleados;

		}

		public void buscarEmpleado(string nombreEmpleado)
		{
			//FUNCION PARA BUSCAR AL EMPLEADO DEPENDIENDO DEL NOMBRE QUE SE OBTIENE
			DataTable tabla = new DataTable();

			string query = "SELECT emp.ID AS ID,emp.Nombre as NOMBRE,emp.email as EMAIL," +
					"t.Telefono as TELEFONO,(DATEDIFF(CURDATE(),emp.FechaNacimiento))DIV 365 as EDAD FROM Empleado as emp " +
					"INNER JOIN Telefonos as t ON(t.EmpleadoID = emp.ID) " +
					"WHERE emp.Nombre LIKE '" + nombreEmpleado + "%' GROUP BY NOMBRE;";

			try
			{
				co.Comando(query);

				tabla.Load(co.Leer);
			}

			catch (Exception)
			{
                //System.Windows.Forms.MessageBox.Show("No se ha encontrado la información\nPor ende, no se puede mostrar");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Error al mostrar la información", 3);
                mens.ShowDialog();
            }

			finally
			{
				//if (co != null) co.Cerrar();
				tablaEmpleados.DataSource = tabla;
			}
		}

		private void agregarEmpleado_Click(object sender, EventArgs e)
		{//SE ABRE UN NUEVO FORM DE REGISTRO
			registroEmpleado form1 = new registroEmpleado(this,co);
			form1.ShowDialog();
		}

		private void campoNombre_TextChanged(object sender, EventArgs e)
		{//UN EVENTO QUE NOS AYUDA A BUSCAR EL NOMBRE DEPENDIENDO DE LO QUE SE ESCRIBE
			buscarEmpleado(campoNombre.Text);
		}

		public void refreshTable()
		{//REFRESCA LA TABLA CADA QUE SE BUSCA A UN EMPLEADO
			tablaEmpleados.DataSource = getEmpleadosInfo();
		}

		public void refreshTableDELETE()
		{//REFRESCA LA TABLA CADA QUE SE BUSCA A UN EMPLEADO
			tablaEmpleados.DataSource = getEmpleadosInfo();
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
                //System.Windows.Forms.MessageBox.Show("No se ha encontrado la información\nPor ende, no se puede mostrar");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Error al mostrar la información", 3);
                mens.ShowDialog();
            }

			finally
			{
				//if (co != null) co.Cerrar();
				
			}

			//RETORNA EL RESULTADO DE LA CONSULTA EN STRING
			return tabla.Rows[0][0].ToString();
		}

		private void tablaEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			//NO SE USA
		}

		private void btnEliminarEmp_Click(object sender, EventArgs e)
		{
            //Checar esto
            try
            {
                idOtroForm = (int)tablaEmpleados[0, tablaEmpleados.CurrentCell.RowIndex].Value;
                //if (clickEmpleado)
                {
                    DialogResult resultado = System.Windows.Forms.MessageBox.Show("¿Está seguro de que quiere borrar al empleado?", "Click en Sí para confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        //LO USAMOS PARA ELIMINAR A UN EMPLEADO SELECCIONAND DESDE LA TABLA DE EMPLEADOS
                        string delete = "DELETE FROM Empleado WHERE ID = " + id + ";";
                        try
                        {
                            co.Comando(delete);
                        }

                        catch (MySqlException)
                        {//en caso de no poder borrarse
                            //System.Windows.Forms.MessageBox.Show("No se ha podido borrar al usuario");
                            AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Error al borrar el usuario", 3);
                            mens.ShowDialog();
                        }

                        finally
                        {
                            refreshTableDELETE();
                        }
                    }
                }
            }catch(NullReferenceException ex)
			{
                //System.Windows.Forms.MessageBox.Show("Seleccione un elemento");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Seleccione un elemento", 1);
                mens.ShowDialog();
            }
			
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
            editar();
        }

        public void editar()
        {
            try
            {
                idOtroForm = (int)tablaEmpleados[0, tablaEmpleados.CurrentCell.RowIndex].Value;
                //if (clickEmpleado)
                {
                    //OBTIENE LOS DATOS DEL EMPLEADO CON CONSULTAS, UTILZANDO LA FUNCION QUERYTOSTRING
                    queryNombre = "SELECT Nombre FROM Empleado WHERE ID = " + id + ";";
                    queryEmail = "SELECT email FROM Empleado WHERE ID = " + id + ";";
                    queryCalle = "SELECT Calle FROM Empleado WHERE ID = " + id + ";";
                    queryColonia = "SELECT Colonia FROM Empleado WHERE ID = " + id + ";";
                    queryCP = "SELECT CP FROM Empleado WHERE ID = " + id + ";";
                    queryCiudad = "SELECT Ciudad FROM Empleado WHERE ID = " + id + ";";
                    queryEstado = "SELECT Estado FROM Empleado WHERE ID = " + id + ";";
                    queryRFC = "SELECT RFC FROM Empleado WHERE ID = " + id + ";";
                    queryFN = "SELECT DATE_FORMAT(FechaNacimiento,'%d/%m/%Y') FROM Empleado WHERE ID = " + id + ";";
                    querySexo = "SELECT Sexo FROM Empleado WHERE ID = " + id + ";";
                    queryImgEmpleado = "SELECT imagenEmpleado FROM Empleado WHERE ID = " + id + ";";
                    //EL RESULTADO PASA A SER STRING CON LA FUNCION ANTERIORMENTE MENCIONADA Y SE ALMACENA EN UNA VARIABLE STRING
                    nombre = queryToString(queryNombre);
                    email = queryToString(queryEmail);
                    calle = queryToString(queryCalle);
                    colonia = queryToString(queryColonia);
                    cp = queryToString(queryCP);
                    ciudad = queryToString(queryCiudad);
                    estado = queryToString(queryEstado);
                    rfc = queryToString(queryRFC);
                    fnac = queryToString(queryFN);
                    locImgTrab = queryToString(queryImgEmpleado);
                    sexo = Convert.ToInt32(queryToString(querySexo));

                    //ABRE EL FORM DE EDICION 
                    edicionEmpleado form = new edicionEmpleado(this, co);

                    form.ShowDialog();
                }
            }
            catch (NullReferenceException ex)
            {
                //System.Windows.Forms.MessageBox.Show("Seleccione un elemento");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Seleccione un elemento", 1);
                mens.ShowDialog();
            }
        }

		private void tablaEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

        public void visualizar()
        {
            //SE OBTIENE EL ID DEL EMPLEADO QUE SE QUIERE VISUALIZAR O BORRAR
            try
            {

                queryNombre = "SELECT Nombre FROM Empleado WHERE ID = " + id + ";";
                queryEmail = "SELECT email FROM Empleado WHERE ID = " + id + ";";
                queryCalle = "SELECT Calle FROM Empleado WHERE ID = " + id + ";";
                queryColonia = "SELECT Colonia FROM Empleado WHERE ID = " + id + ";";
                queryCP = "SELECT CP FROM Empleado WHERE ID = " + id + ";";
                queryCiudad = "SELECT Ciudad FROM Empleado WHERE ID = " + id + ";";
                queryEstado = "SELECT Estado FROM Empleado WHERE ID = " + id + ";";
                queryRFC = "SELECT RFC FROM Empleado WHERE ID = " + id + ";";
                queryFN = "SELECT DATE_FORMAT(FechaNacimiento,'%d/%m/%Y') FROM Empleado WHERE ID = " + id + ";";
                querySexo = "SELECT Sexo FROM Empleado WHERE ID = " + id + ";";
                queryImgEmpleado = "SELECT imagenEmpleado FROM Empleado WHERE ID = " + id + ";";
                //EL RESULTADO PASA A SER STRING CON LA FUNCION ANTERIORMENTE MENCIONADA Y SE ALMACENA EN UNA VARIABLE STRING
                nombre = queryToString(queryNombre);
                email = queryToString(queryEmail);
                calle = queryToString(queryCalle);
                colonia = queryToString(queryColonia);
                cp = queryToString(queryCP);
                ciudad = queryToString(queryCiudad);
                estado = queryToString(queryEstado);
                rfc = queryToString(queryRFC);
                fnac = queryToString(queryFN);
                locImgTrab = queryToString(queryImgEmpleado);
                sexo = Convert.ToInt32(queryToString(querySexo));


                worker_project_registry form = new worker_project_registry(this);
                form.ShowDialog();
            }

            //EN CASO DE QUE NO SELECCIONE EL RENGLON
            catch (Exception)
            {
                //NO HACE NADA PARA NO ESTORBAR LA EXPERIENCIA DE USUARIO
            }
        }

		private void tablaEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            visualizarSimple();
        }
        public void visualizarSimple()
        {
            //SE OBTIENE EL ID DEL EMPLEADO QUE SE QUIERE VISUALIZAR O BORRAR
            try
            {

                queryNombre = "SELECT Nombre FROM Empleado WHERE ID = " + id + ";";
                queryImgEmpleado = "SELECT imagenEmpleado FROM Empleado WHERE ID = " + id + ";";
                //EL RESULTADO PASA A SER STRING CON LA FUNCION ANTERIORMENTE MENCIONADA Y SE ALMACENA EN UNA VARIABLE STRING
                nombre = queryToString(queryNombre);
                locImgTrab = queryToString(queryImgEmpleado);
                int ren = 1;
                //Se colocan los trabajos del empleado
                co.Comando("SELECT COUNT(*) " +
                           "FROM Trabajos as t INNER JOIN Empleado_Trabajos AS et ON(et.TrabajosID = t.ID) " +
                           "INNER JOIN TipoTrabajos as tt ON(t.TipoTrabajosID = tt.ID) " +
                           "WHERE et.EmpleadoID = " + id + "; ");
                if (co.LeerRead)
                    ren = co.Leer.GetInt32(0);
                if (ren > 0)
                    dataGridView1.RowCount = ren;
                else
                    dataGridView1.RowCount = 1;

                co.Comando("SELECT t.Nombre, tt.NombreTipoTrab " +
                           "FROM Trabajos as t INNER JOIN Empleado_Trabajos AS et ON(et.TrabajosID = t.ID) " +
                           "INNER JOIN TipoTrabajos as tt ON(t.TipoTrabajosID = tt.ID) " +
                           "WHERE et.EmpleadoID = " + id + "; ");
                int i = 0;
                while (co.LeerRead)
                {
                    dataGridView1[0, i].Value = co.Leer.GetString(0);
                    dataGridView1[1, i].Value = co.Leer.GetString(1);
                    i++;
                }

                string tipoEmpleado = "| ";
                co.Comando("SELECT NombreTipo FROM TipoEmpleado AS te " +
                           "INNER JOIN Empleado_TipoEmpleado AS et ON(et.TipoEmpleadoID = te.ID) " +
                           "WHERE et.EmpleadoID = " + id + "; ");
                while (co.LeerRead)
                {
                    tipoEmpleado += co.Leer.GetString(0) + " | ";
                }

                //Se colocan el nombre, la imagen y su tipo de empleado
                nom.Text = nombre;
                imgTrab.ImageLocation = locImgTrab;
                tEmpleado.Text = tipoEmpleado;

                //Se adapta el tamaño del texto del label dependiendo del tamaño de la palabara
                while (tEmpleado.Width > panel1.Width)
                {
                    tEmpleado.Font = new Font("Gothic A1", tEmpleado.Font.Size - 0.5f, tEmpleado.Font.Style);
                }
            }

            //EN CASO DE QUE NO SELECCIONE EL RENGLON
            catch (Exception)
            {
                //NO HACE NADA PARA NO ESTORBAR LA EXPERIENCIA DE USUARIO
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            visualizar();

        }
    }
}
