using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AppProyectoBD;

namespace PruebaA
{
	public partial class edicionEmpleado : Form
	{
		//SE ESTABLECE UNA CONEXION PARA PODER USARSE EN MYSQLADAPTER
		MySqlConnection connection = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;Integrated Security = True");
		Conexion co;
		Empleados f1;
		//TABLAS INTERNAS PARA AGREGAR A LAS TABLAS DEL DISEÑO
		DataTable tels;
		DataTable redes;

		//lista de trabajos
		List<string> works = new List<string>();
		List<int> idRedes = new List<int>();

        public bool resultado = false;
        Bitmap bmp;
        bool cambioFoto = false;

        //DECLARACION DE VARIABLES DONDE SE ALMACENARÁ INFORMACIÓN
        public static string nombre = "";
		public static string email = "";
		public static string calle = "";
		public static string colonia = "";
		public static int cp;
		public static string ciudad = "";
		public static string estado = "";
		public static string rfc = "";
		public static string fechaNac = "";
		public static string sexo = "";
		public static string imgTrabajador1Loc = "";
		public static string tipoEmpleo = "";


		public edicionEmpleado(Empleados form, Conexion co)
		{
			InitializeComponent();
            Region = Funciones.redondear(Width, Height);

            f1 = form;
			this.co = co;
			this.CenterToScreen();

			//MUESTRA LOS DATOS DE LOS EMPLEADOS
			mostrarTipos();
			mostrarTelefonosEmpleado();
			mostrarRedes();
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
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No se puede mostrar la información",3);
                mens.ShowDialog();
			}

			finally
			{
				//if (co != null) co.Cerrar();

			}

			//RETORNA EL RESULTADO DE LA CONSULTA EN STRING
			return tabla.Rows[0][0].ToString();
		}

		private void btnAddNet_Click(object sender, EventArgs e)
		{
			//AÑADE RENGLONES A LA TABLA VIRTUAL Y EL DATASOURCE DELDATAGRIDVIEW TOMA SUS DATOS
			try
			{
                if (!tbCuenta.Text.Equals(null) && !tbCuenta.Text.Equals(""))
                {
                    redes.Rows.Add(cbRedes.Text, tbCuenta.Text);
                    tablaRedes.DataSource = redes;
                }
			}

			catch (Exception)
			{
				//NADA
			}
		}

		private void edicionEmpleado_Load(object sender, EventArgs e)
		{
			cargarEmpleos();
			cargarRedes();

			//DATOS PERSONALES
			tbNombre.Text += f1.nombre;
			tbEmail.Text += f1.email;
			tbCalle.Text += f1.calle;
			tbColonia.Text += f1.colonia;
			tbCP.Text += f1.cp;
			tbCiudad.Text += f1.ciudad;
			tbEstado.Text += f1.estado;
			tbRFC.Text += f1.rfc;
			imgTrab1.ImageLocation = f1.locImgTrab;

			fechaN.Value = DateTime.Parse(f1.fnac);

			if (f1.sexo == 1)
			{
				radioButton1.Checked = true;
			}

			else
			{
				radioButton2.Checked = true;
			}
			
		}

		public void mostrarTipos()
		{

			//TRABAJOS
			string comandoWorks = "SELECT tp.NombreTipo FROM TipoEmpleado AS tp " +
									"INNER JOIN Empleado_TipoEmpleado AS tpe ON(tpe.TipoEmpleadoID = tp.ID) " +
									"INNER JOIN Empleado AS e ON(tpe.EmpleadoID = e.ID) " +
									"WHERE e.ID = " + f1.idOtroForm + "; ";
			try
			{
				MySqlCommand cmdSel = new MySqlCommand(comandoWorks, connection);
				DataTable dt = new DataTable();
				MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
				da.Fill(dt);

				works = dt.AsEnumerable()
					  .Select(r => r.Field<string>("NombreTipo"))
					  .ToList();

				labelwork.Text = String.Join("/", works);
			}


			catch (Exception)
			{
                //System.Windows.Forms.MessageBox.Show("No se han podido cargar los tipos de empleo");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No se han podido cargar los tipos de empleo", 3);
                mens.ShowDialog();
            }
		}

		public void mostrarRedes()
		{
			string consulta = "SELECT tr.NombreRedSocial AS RED, r.Cuenta FROM TipoDeRedSocial as tr " +
								"INNER JOIN RedesSociales AS r ON(r.TipoDeRedSocialID = tr.ID) " +
								"INNER JOIN Empleado AS emp ON(emp.ID = r.EmpleadoID) " +
								"WHERE emp.ID = " + f1.idOtroForm + ";";

			MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, connection);
			redes = new DataTable();
			//PASAR DATOS A LA TABLA 
			adaptador.Fill(redes);
			//DATA GRID VIEW TOMA LOS VALORES DE LA TABLA LLENADA DE DATOS DEL ADAPTADOR
			tablaRedes.DataSource = redes;
		}

		public void mostrarTelefonosEmpleado()
		{

			string consulta = "SELECT t.Telefono as TELEFONO FROM TELEFONOS AS t " +
							"INNER JOIN Empleado as emp ON(t.EmpleadoID = emp.ID) " +
							"WHERE emp.ID = " + f1.idOtroForm +
							" ORDER BY t.Telefono;";

			MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, connection);
			tels= new DataTable();
			//PASAR DATOS A LA TABLA 
			adaptador.Fill(tels);
			//DATA GRID VIEW TOMA LOS VALORES DE LA TABLA LLENADA DE DATOS DEL ADAPTADOR
			tablaTels.DataSource = tels;
		}

		public void cargarEmpleos()
		{
			//COMPLETO
			ArrayList listaTipoEmpleado = new ArrayList {"Diseñador", "Editor", "Fotografo", "Maquetador", "Ilustrador", "Imprenta", "Publicidad" };
			cbTipoTrab.DataSource = listaTipoEmpleado;
			cbTipoTrab.SelectedIndex = 0;
		}

		public void cargarRedes()
		{
			List<string> listaTipoCuentas;
			//REDES SOCIALES
			string comandoNets = "SELECT NombreRedSocial FROM TipoDeRedSocial;";
			try
			{
				MySqlCommand cmdSel = new MySqlCommand(comandoNets, connection);
				DataTable dt = new DataTable();
				MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
				da.Fill(dt);

				listaTipoCuentas = dt.AsEnumerable()
					  .Select(r => r.Field<string>("NombreRedSocial"))
					  .ToList();

				cbRedes.DataSource = listaTipoCuentas;
				cbRedes.SelectedIndex = 0;
			}


			catch (Exception)
			{
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No se han podido cargar los tipos de redes sociales", 3);
                mens.ShowDialog();
            }
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		private void imgTrab1_Click(object sender, EventArgs e)
		{
			//ABRE UN DIÁLOGO PARA PODER SELECCIONAR LA IMAGEN
			OpenFileDialog seleccion = new OpenFileDialog();
			seleccion.InitialDirectory = "C:\\";
			seleccion.Filter = "Archivos de imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";

			if (seleccion.ShowDialog() == DialogResult.OK)
			{
                Bitmap orig = new Bitmap(Path.GetFullPath(seleccion.FileName).Replace(@"\", @"\\"));
                bmp = new Bitmap(Redimensionar(orig, 270, 270));
                imgTrab1.Image = bmp;
                cambioFoto = true;
                label13.Visible = false;
				label2.Visible = false;
			}

		}

		private void label13_Click(object sender, EventArgs e)
		{
			//ABRE UN DIÁLOGO PARA PODER SELECCIONAR LA IMAGEN, AL IGUAL QUE EL CIRCULAR PICTURE BOX
			OpenFileDialog seleccion = new OpenFileDialog();
			seleccion.InitialDirectory = "C:\\";
			seleccion.Filter = "Archivos de imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";

			if (seleccion.ShowDialog() == DialogResult.OK)
			{
                Bitmap orig = new Bitmap(Path.GetFullPath(seleccion.FileName).Replace(@"\", @"\\"));
                bmp = new Bitmap(Redimensionar(orig, 270, 270));
                imgTrab1.Image = bmp;
                cambioFoto = true;
                label13.Visible = false;
				label2.Visible = false;
			}

		}
        private Bitmap Redimensionar(Image imagenOriginal, int ancho, int alto)
        {
            Bitmap ImagenRedimencionda = new Bitmap(ancho, alto);
            Graphics.FromImage(ImagenRedimencionda).DrawImage(imagenOriginal, 0, 0, ancho, alto);
            Bitmap imagenFinal = new Bitmap(ImagenRedimencionda);
            return imagenFinal;
        }
        private void btn_addWork_Click(object sender, EventArgs e)
		{
			//ACUMULAR EN CADENA DEPENDIENDO DE CIERTOS FACTORES, ADEMÁS DE PROHIBIR QUE SE PUEDA INGRESAR IMPRENTA Y PUBLICIDAD
			if (works.Count != 0 && (cbTipoTrab.Text == "Imprenta" || cbTipoTrab.Text == "Publicidad"))
			{
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No puedes agregar imprenta y publicidad teniendo a otros trabajos", 2);
                mens.ShowDialog();
            }

			else if (works.Count != 0 && (works[works.Count - 1] == "Imprenta" || works[works.Count - 1] == "Publicidad") && (cbTipoTrab.Text != "Imprenta" || cbTipoTrab.Text != "Publicidad"))
			{
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No se puede agregar otro trabajo teniendo a imprenta o publicidad", 2);
                mens.ShowDialog();
            }

			else if (works.Count != 0 && works.Contains(cbTipoTrab.Text))
			{
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No se pueden duplicar los datos", 2);
                mens.ShowDialog();
            }

			else
			{
				works.Add(cbTipoTrab.Text);
				labelwork.Text = string.Join("/", works.ToArray());
			}
		}

		private void btn_DelWork_Click(object sender, EventArgs e)
		{
			//BORRA EL ÚLTIMO DATO DE LA LISTA Y DE LA LABEL
			try
			{
				works.RemoveAt(works.Count - 1);
				labelwork.Text = string.Join("/", works.ToArray());
			}

			catch (Exception)
			{
				//NADA
			}
		}

		private void btnAddTelNum_Click(object sender, EventArgs e)
		{
			//AÑADE RENGLONES A LA TABLA VIRTUAL Y EL DATASOURCE DELDATAGRIDVIEW TOMA SUS DATOS
			try
			{
				tels.Rows.Add(tbTel.Text);
				tablaTels.DataSource = tels;
			}

			catch (Exception)
			{
				//nada
			}
		}

		private void btnDelRedes_Click(object sender, EventArgs e)
		{
			//BORRA EL RENGLON QUE ESTÁ ESCOGIDO
			try
			{
				tablaRedes.Rows.RemoveAt(tablaRedes.CurrentRow.Index);
			}

			catch (Exception)
			{
				//NADA
			}
		}

		private void btnDelTels_Click(object sender, EventArgs e)
		{
			//BORRA EL RENGLON QUE ESTÁ ESCOGIDO
			try
			{
				tablaTels.Rows.RemoveAt(tablaTels.CurrentRow.Index);
			}

			catch (Exception)
			{
				//NADA
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			//VARIABLES BOOLEANAS QUE AYUDAN A COMPROBAR CIERTAS CONDICIONES
			bool textos = tbNombre.Text != "" && tbEmail.Text != "" && tbCP.Text != "";
			bool telefonos = tablaTels.Rows.Count > 1 && tablaTels.Rows != null;
			bool redes = tablaRedes.Rows.Count > 1 && tablaRedes.Rows != null;
			bool worksL = works.Count >= 1;
			string updateDatosEmpleado;
            // Inicia la transacción
            co.Comando("START TRANSACTION;");
            if (cambioFoto)
                imgTrabajador1Loc = Path.Combine("C:\\Imagenes\\", "imagen" + (f1.idOtroForm) + ".jpeg").Replace(@"\", @"\\");
            else
                imgTrabajador1Loc = Path.GetFullPath(imgTrab1.ImageLocation).Replace(@"\", @"\\");

            
            //CASO 1: TENER LOS DATOS
            if (textos && telefonos && redes && worksL)
			{
				nombre = tbNombre.Text;
				email = tbEmail.Text;
				calle = tbCalle.Text;
				colonia = tbColonia.Text;
				cp = Convert.ToInt32(tbCP.Text);
				ciudad = tbCiudad.Text;
				estado = tbEstado.Text;
				rfc = tbRFC.Text;
				int sexo = radioButton1.Checked ? 1 : 0;
               
                //ADAPTAMOS AL FORMATO
                fechaNac = fechaN.Value.Date.ToString("yyyy-MM-dd");

                updateDatosEmpleado = "CALL update_EdicionEmpleado('"+nombre+"', '"+email+"', '"+calle+"','"+colonia+"', "+cp+"," +
                                        " '"+ciudad+"', '"+estado+"', '"+rfc+"', '"+fechaNac+"', '"+imgTrabajador1Loc+"', "+sexo+", "+f1.idOtroForm+","+co.sesion+");";
                try
                {
                        co.Comando(updateDatosEmpleado);
                        f1.refreshTable();
                    
                    //ELIMINA LOS DATOS PARA PODER SUSTITUIRLOS

                        // co.Comando("DELETE FROM Telefonos WHERE EmpleadoID = " + f1.idOtroForm + ";");
                        co.Comando("CALL delete_EdicionEmpleado(" + f1.idOtroForm + ");");

                        for (int i = 0; i < tablaTels.Rows.Count - 1; i++)
                        {
                            //co.Comando("INSERT INTO Telefonos VALUES(" +
                            //    f1.idOtroForm + ",'" + tablaTels.Rows[i].Cells[0].Value + "');");
                            co.Comando("CALL insertTel_EdicionEmpleado("+f1.idOtroForm+", '"+ tablaTels.Rows[i].Cells[0].Value + "',"+co.sesion+");");
                        }

                    //ELIMINA LOS DATOS PARA PODER SUSTITUIRLOS
                    
                        co.Comando("CALL delete_e_te("+f1.idOtroForm+");");

                        for (int i = 0; i < works.Count; i++)
                        {
                            switch (works[i])
                            {
                                case "Diseñador":
                                    co.Comando("CALL insert_e_te("+f1.idOtroForm+", 1,"+co.sesion+");");
                                    break;

                                case "Editor":
                                    co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 2," + co.sesion + ");");
                                    break;

                                case "Fotografo":
                                    co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 3," + co.sesion + ");");
                                    break;

                                case "Maquetador":
                                    co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 4," + co.sesion + ");");
                                    break;

                                case "Ilustrador":
                                    co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 5," + co.sesion + ");");
                                    break;

                                case "Imprenta":
                                    co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 6," + co.sesion + ");");
                                    break;


                                case "Publicidad":
                                    co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 7," + co.sesion + ");");
                                    break;
                            }                 
                    }

                    //ELIMINA LOS DATOS PARA PODER SUSTITUIRLOS
                    
                        co.Comando("CALL delete_RedesSociales("+f1.idOtroForm+");");
                    
                        //PARA REDES
                        for (int i = 0; i < tablaRedes.Rows.Count - 1; i++)
                        {
                            string selectIDRedes = " SELECT ID FROM TipoDeRedSocial WHERE NombreRedSocial ='" + tablaRedes.Rows[i].Cells[0].Value + "';";

                            idRedes.Add(Convert.ToInt32(queryToString(selectIDRedes)));
                        }

                        for (int i = 0; i < tablaRedes.Rows.Count - 1; i++)
                        {
                            co.Comando("CALL insert_RedesSociales("+f1.idOtroForm+", '"+ tablaRedes.Rows[i].Cells[1].Value + "', "+ idRedes[i] + ","+co.sesion+");");
						}

                        AppProyectoBD.MessageBox mensaje6 = new AppProyectoBD.MessageBox("Cambios guardados con éxito", 2);
                        mensaje6.ShowDialog();
                        
                        f1.refreshTable();
                        this.Close();
                }
				
                catch (Exception ex)
                {
					Console.WriteLine(ex.ToString());
                    AppProyectoBD.MessageBox mensaje8 = new AppProyectoBD.MessageBox("Algo ha salido mal en la edición de datos del empleado", 3);
                    mensaje8.ShowDialog();
                    co.Comando("ROLLBACK;");
                    this.Close();
                }

                finally
                {
                    co.Comando("COMMIT;");
                    bmp.Save(imgTrabajador1Loc);
                }

			}
			
			//CASO 2: SIN REDES SOCIALES
			else if (textos && telefonos && redes == false && worksL)
			{
                AppProyectoBD.MessageBox res = new AppProyectoBD.MessageBox("¿Está seguro de que quiere continuar sin redes sociales?", 1);
                res.ShowDialog();
      
                if (resultado)
                {
					nombre = tbNombre.Text;
					email = tbEmail.Text;
					calle = tbCalle.Text;
					colonia = tbColonia.Text;
					cp = Convert.ToInt32(tbCP.Text);
					ciudad = tbCiudad.Text;
					estado = tbEstado.Text;
					rfc = tbRFC.Text;
					int sexo = radioButton1.Checked ? 1 : 0;
					//ADAPTAMOS AL FORMATO
					fechaNac = fechaN.Value.Date.ToString("yyyy-MM-dd");

					updateDatosEmpleado = "CALL update_EdicionEmpleado(" + nombre + ", " + email + ", " + calle + ", " + colonia + ", " + cp + "," +
                                        " " + ciudad + ", " + estado + ", " + rfc + ", " + fechaNac + ", " + imgTrabajador1Loc + ", " + sexo + ", " + f1.idOtroForm + ","+co.sesion+");";
					try
					{

						co.Comando(updateDatosEmpleado);



						AppProyectoBD.MessageBox mensaje9 = new AppProyectoBD.MessageBox("Algo salió mal al insertar datos del empleado", 3);
						mensaje9.ShowDialog();
						co.Comando("ROLLBACK;");
						this.Close();



						co.Comando("CALL delete_EdicionEmpleado(" + f1.idOtroForm + ");");

						for (int i = 0; i < tablaTels.Rows.Count - 1; i++)
						{
							co.Comando("CALL insertTel_EdicionEmpleado(" + f1.idOtroForm + ", '" + tablaTels.Rows[i].Cells[0].Value + "',"+co.sesion+");");
						}



						AppProyectoBD.MessageBox mensaje10 = new AppProyectoBD.MessageBox("Algo salió mal al editar los teléfonos del empleado", 3);
						mensaje10.ShowDialog();
						co.Comando("ROLLBACK;");
						this.Close();



						co.Comando("CALL delete_e_te(" + f1.idOtroForm + ");");

						for (int i = 0; i < works.Count; i++)
						{
							switch (works[i])
							{
								case "Diseñador":
									co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 1," + co.sesion + ");");
									break;

								case "Editor":
									co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 2," + co.sesion + ");");
									break;

								case "Fotografo":
									co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 3," + co.sesion + ");");
									break;

								case "Maquetador":
									co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 4," + co.sesion + ");");
									break;

								case "Ilustrador":
									co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 5," + co.sesion + ");");
									break;

								case "Imprenta":

									co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 6," + co.sesion + ");");
									break;


								case "Publicidad":
									co.Comando("CALL insert_e_te(" + f1.idOtroForm + ", 7," + co.sesion + ");");
									break;
							}

						}

						AppProyectoBD.MessageBox mensaje11 = new AppProyectoBD.MessageBox("Empleado guardado con éxito", 2);
						bmp.Save(imgTrabajador1Loc);
						mensaje11.ShowDialog();
						f1.refreshTable();
						co.Comando("COMMIT;");
						this.Close();



						co.Comando("DELETE FROM RedesSociales WHERE EmpleadoID = " + f1.idOtroForm + ";");

					}

					catch (Exception)
					{
						AppProyectoBD.MessageBox mensaje14 = new AppProyectoBD.MessageBox("Algo ha salido mal en la inserción de datos del empleado", 3);
						mensaje14.ShowDialog();
						co.Comando("ROLLBACK;");
						this.Close();
					}
				}
			}

			//CASO 3: DATOS INSUFICIENTES
			else
			{
                AppProyectoBD.MessageBox mensaje15 = new AppProyectoBD.MessageBox("Llene los datos del usuario mínimos: DATOS PERSONALES, TIPO DE EMPLEO Y TELEFONOS", 2);
                mensaje15.ShowDialog();
            }
		}

		private void tbTel_KeyPress(object sender, KeyPressEventArgs e)
		{
			//se prohibe la entrada de caracteres que no sean digitos
			const char Delete = (char)8;
			e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
		}

		private void tbCP_KeyPress(object sender, KeyPressEventArgs e)
		{
			//se prohibe la entrada de caracteres que no sean digitos
			const char Delete = (char)8;
			e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
		}

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Funciones.ReleaseCapture();
            Funciones.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
