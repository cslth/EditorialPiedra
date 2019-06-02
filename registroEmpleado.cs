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
	public partial class registroEmpleado : Form
	{
		//SE ESTABLECE UNA CONEXION PARA PODER USARSE EN MYSQLADAPTER
		MySqlConnection connection = new MySqlConnection("server=localhost;database=EditorialPiedra;Uid=root;pwd=1016;");
		Conexion co;
		Empleados f1;
		//TABLAS INTERNAS PARA AGREGAR A LAS TABLAS DEL DISEÑO
		DataTable tels = new DataTable();
		DataTable redes = new DataTable();

		//lista de trabajos
		List<string> works = new List<string>();
		List<int> idRedes = new List<int>();

        //Variables
        public bool resultado1 = false;
        Bitmap bmp;
        //public bool resultado2 = false;

        public registroEmpleado(Empleados form, Conexion co)
		{
			InitializeComponent();
            Region = Funciones.redondear(Width, Height);

            f1 = form;
            this.co = co;
			this.CenterToScreen();
			
			tels.Columns.Add("Número de teléfono", typeof(Int64));
			
			redes.Columns.Add("Red social", typeof(string));
			redes.Columns.Add("Usuario", typeof(string));
			
			tablaTels.DataSource = tels;
			
			tablaRedes.DataSource = redes;
		}

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

		private void registroEmpleado_Load(object sender, EventArgs e)
		{
			
				//PASA TODOS LOS DATOS AL COMBOBOX
				cargarEmpleos();
				cargarRedes();
			
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
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No se puede moestrar la información",3);
                mens.ShowDialog();
			}

			finally
			{
				//if (co != null) co.Cerrar();

			}

			//RETORNA EL RESULTADO DE LA CONSULTA EN STRING
			return tabla.Rows[0][0].ToString();
		}

		public void cargarEmpleos()
		{
			//COMPLETO
			ArrayList listaTipoEmpleado = new ArrayList { "Diseñador", "Editor", "Fotografo", "Maquetador", "Ilustrador", "Imprenta", "Publicidad" };
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
                //System.Windows.Forms.MessageBox.Show("No se han podido cargar los tipos de redes sociales");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No se han podido cargar los tipos de redes sociales", 3);
                mens.ShowDialog();
            }
			
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
				label13.Visible = false;
				label2.Visible = false;
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
            this.Close();
		}
        private Bitmap Redimensionar(Image imagenOriginal, int ancho, int alto)
        {
            Bitmap ImagenRedimencionda = new Bitmap(ancho, alto);
            Graphics.FromImage(ImagenRedimencionda).DrawImage(imagenOriginal, 0, 0, ancho, alto);
            Bitmap imagenFinal = new Bitmap(ImagenRedimencionda);
            return imagenFinal;
        }

		private void btnAceptar_Click(object sender, EventArgs e)
		{
            bool textos = tbNombre.Text != "" && tbEmail.Text != "" && tbCP.Text != "";// && imgTrab1.ImageLocation != null;
			bool telefonos = tablaTels.Rows.Count > 1 && tablaTels.Rows != null;
			bool redes = tablaRedes.Rows.Count > 1 && tablaRedes.Rows != null;
			bool worksL = works.Count >= 1;
            int IdEmp = 0;
            string insertDatosEmpleado;
            co.Comando("START TRANSACTION;");
            //Se consulta el ID del empleado para poder saber que idetificador tendra la imagen
            try
            {
                co.Comando("SELECT MAX(ID) FROM Empleado;");
                if (co.LeerRead)
                    IdEmp = co.Leer.GetInt32(0);
            }catch(System.Data.SqlTypes.SqlNullValueException exe)
            {
                IdEmp = 0;
            }
            string destino = Path.Combine("C:\\Imagenes\\","imagen"+(IdEmp+1)+".jpeg").Replace(@"\", @"\\");

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

                    insertDatosEmpleado = "CALL insert_Empleado('"+nombre+"','"+email+"','"+calle+"','"+colonia+"',"+cp+",'"+ciudad+"'," +
                                            "'"+estado+"','"+rfc+"','"+fechaNac+"','"+destino+"',"+sexo+");";
					try
					{
						try
						{
							co.Comando(insertDatosEmpleado);
						}

						catch (MySqlException ef)
						{
                            co.Comando("ROLLBACK;");
                            AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Algo salió mal al insertar datos del empleado", 3);
                            mens.ShowDialog();
                            this.Close();
                        }

						try
						{
							for (int i = 0; i < tablaTels.Rows.Count - 1; i++)
							{
                            co.Comando("CALL insert_Telefonos('" + tablaTels.Rows[i].Cells[0].Value + "')");
                            }
						}
						catch (Exception)
						{
                            co.Comando("ROLLBACK;");
                            AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Algo salió mal al insertar datos de los teléfonos del empleado", 3);
                            mens.ShowDialog();
                            this.Close();
                        }

						try
						{
							for (int i = 0; i < works.Count; i++)
							{
								switch (works[i])
								{
									case "Diseñador":
                                    co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 1 + ");");
										break;

									case "Editor":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 2 + ");");
                                        break;

									case "Fotografo":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 3 + ");");
                                        break;
	
									case "Maquetador":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 4 + ");");
                                        break;

									case "Ilustrador":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 5 + ");");
                                        break;

									case "Imprenta":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 6 + ");");
                                        break;

									case "Publicidad":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 7 + ");");
                                        break;
								}

							}

                            AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Los datos se guardaron con éxito", 2);
                            mens.ShowDialog();
                            f1.refreshTable();
							this.Close();
						}

						catch (Exception)
						{
                            co.Comando("ROLLBACK;");
                            AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Hubo un error al guardar el o los tipos de empleado", 3);
                            mens.ShowDialog();
                            this.Close();
                        }

				    try
					{
						//PARA REDES
						for (int i = 0; i < tablaRedes.Rows.Count - 1; i++)
						{
							string selectIDRedes = " SELECT ID FROM TipoDeRedSocial WHERE NombreRedSocial ='" + tablaRedes.Rows[i].Cells[0].Value + "';";

							idRedes.Add(Convert.ToInt32(queryToString(selectIDRedes)));
						}

					}
					catch (Exception)
					{
                        co.Comando("ROLLBACK;");
                        AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No se han encontrado las redes sociales insertadas\nSi desea agregar una nueva red nueva debes hacerlo en\n UTILIDADES", 3);
                        mens.ShowDialog();
                    }

					try
						{

							for (int i = 0; i < tablaRedes.Rows.Count - 1; i++)
							{
								co.Comando("INSERT INTO RedesSociales VALUES" +
									"((SELECT MAX(ID) FROM Empleado),'" + tablaRedes.Rows[i].Cells[1].Value + "',"+idRedes[i]+");");
							}
						}

						catch (Exception)
						{
                            co.Comando("ROLLBACK;");
                            AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Algo salió mal al guardar las redes\n sociales del empleado", 3);
                            mens.ShowDialog();
                            this.Close();
                        }

					}

					catch (Exception)
					{
                        co.Comando("ROLLBACK;");
                        AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Algo ha salido mal al guardar los datos del empleado", 3);
                        mens.ShowDialog();
                        this.Close();
                    }

					finally
					{
                        bmp.Save(destino);
                    }
			}
			
			//CASO 2: SIN REDES SOCIALES
			else if (textos && telefonos && redes == false && worksL)
			{
                AppProyectoBD.MessageBox res = new AppProyectoBD.MessageBox("¿Está seguro de que quiere continuar sin redes sociales?", 1);
                res.ShowDialog();
                if (resultado1)
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

                    insertDatosEmpleado = "CALL insert_Empleado('" + nombre + "','" + email + "','" + calle + "','" + colonia + "'," + cp + ",'" + ciudad + "'," +
                                           "'" + estado + "','" + rfc + "','" + fechaNac + "','" + destino + "'," + sexo + ");";
                    try
					{
						try
						{
							co.Comando(insertDatosEmpleado);
						}

						catch (Exception)
						{
                            co.Comando("ROLLBACK;");
                            AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Algo ha salido mal al guardar los datos del empleado", 3);
                            mens.ShowDialog();
                            this.Close();
                        }

						try
						{
							for (int i = 0; i < tablaTels.Rows.Count - 1; i++)
							{
                                co.Comando("CALL insert_Telefonos('"+ tablaTels.Rows[i].Cells[0].Value + "')");
							}
						}

						catch (Exception)
						{
                            co.Comando("ROLLBACK;");
                            AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Algo salió mal al guardar los telefonos del empleado", 3);
                            mens.ShowDialog();
                            this.Close();
                        }

						try
						{
							for (int i = 0; i < works.Count; i++)
							{
								switch (works[i])
								{
                                    case "Diseñador":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 1 + ");");
                                        break;

                                    case "Editor":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 2 + ");");
                                        break;

                                    case "Fotografo":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 3 + ");");
                                        break;

                                    case "Maquetador":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 4 + ");");
                                        break;

                                    case "Ilustrador":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 5 + ");");
                                        break;

                                    case "Imprenta":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 6 + ");");
                                        break;

                                    case "Publicidad":
                                        co.Comando("CALL insert_EmpleadoTipoEmpleado(" + 7 + ");");
                                        break;
                                }

							}

                            AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("El empleado se creo con éxito", 2);
                            mens.ShowDialog();
                            f1.refreshTable();
							this.Close();
						}

						catch (Exception)
						{
                            co.Comando("ROLLBACK;");
                            AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Se ha producido un error al crear al empleado", 3);
                            mens.ShowDialog();
                            this.Close();
                        }

					}

					catch (Exception)
					{
                        co.Comando("ROLLBACK;");
                        AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Se ha producido un error al crear al empleado", 3);
                        mens.ShowDialog();
                        this.Close();
                    }

					finally
					{
                        bmp.Save(destino);
                    }
				}
			}

			//CASO 3: DATOS INSUFICIENTES
			else
			{
                co.Comando("COMMIT;");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Llene los datos del usuario mínimos:\n DATOS PERSONALES, TIPO DE EMPLEO Y TELEFONOS", 3);
                mens.ShowDialog();
            }

            co.Comando("COMMIT;");

        }
		private void btnAddTelNum_Click(object sender, EventArgs e)
		{
            try
            {
                tels.Rows.Add(tbTel.Text);
                tablaTels.DataSource = tels;
            }
            catch (ArgumentException)
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("Ingrese un numero de telefono", 3);
                mens.ShowDialog();
            }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				tablaTels.Rows.RemoveAt(tablaTels.CurrentRow.Index);
			}

			catch (Exception)
			{
				//NADA
			}
			
		}

		private void tbCP_KeyPress(object sender, KeyPressEventArgs e)
		{
			//EL CODIGO POSTAL TIENE QUE SER NUMERICO, ASI QUE SE LIMITA CON CODIGO
			const char Delete = (char)8;
			e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
		}

		private void btn_addWork_Click(object sender, EventArgs e)
		{	
			//ACUMULAR EN CADENA DEPENDIENDO DE CIERTOS FACTORES, ADEMÁS DE PROHIBIR QUE SE PUEDA INGRESAR IMPRENTA Y PUBLICIDAD
			if(works.Count != 0 && (cbTipoTrab.Text == "Imprenta" || cbTipoTrab.Text == "Publicidad"))
			{
                //System.Windows.Forms.MessageBox.Show("No puedes agregar imprenta y publicidad teniendo a otros trabajos");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No puedes agregar imprenta y publicidad teniendo otros tipos selecconaodos", 2);
                mens.ShowDialog();
            }

			else if (works.Count !=0 &&(works[works.Count - 1] == "Imprenta" || works[works.Count - 1] == "Publicidad") && (cbTipoTrab.Text != "Imprenta" || cbTipoTrab.Text != "Publicidad"))
			{
                //System.Windows.Forms.MessageBox.Show("No se puede agregar otro trabajo teniendo a imprenta o publicidad");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No se puede agregar otro tipo teniendo a imprenta o publicidad", 2);
                mens.ShowDialog();
            }

			else if(works.Count !=0 && works.Contains(cbTipoTrab.Text))
			{
                //System.Windows.Forms.MessageBox.Show("No se pueden duplicar los datos");
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No se puede elegir dos veces la misma opción", 2);
                mens.ShowDialog();
            }

			else
			{
				works.Add(cbTipoTrab.Text);
				labelwork.Text = string.Join("/", works.ToArray());
			}
		}

		private void btnAddNet_Click(object sender, EventArgs e)
		{

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
			

		private void btnDelRedes_Click(object sender, EventArgs e)
		{
			try
			{
				tablaRedes.Rows.RemoveAt(tablaRedes.CurrentRow.Index);
			}

			catch (Exception)
			{
				//NADA
			}
			
		}

		private void btn_DelWork_Click(object sender, EventArgs e)
		{
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

		private void tbTel_KeyPress(object sender, KeyPressEventArgs e)
		{
			//se prohibe la entrada de caracteres que no sean digitos
			const char Delete = (char)8;
			e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void tablaTels_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void tbTel_TextChanged(object sender, EventArgs e)
		{

		}

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Funciones.ReleaseCapture();
            Funciones.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
