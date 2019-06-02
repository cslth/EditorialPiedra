using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppProyectoBD
{
    public partial class VisuaTrabajos : Form
    {
        int sel, rows;
        public List<int> ProyectosID;
        List<int> EmpleadosID;
        List<int> EmpleadosVisua;
        List<string> EmpleadosNom;
        List<int> EmpleadosModoEdicion;
        int IDTrab;
        public bool editando;
        public bool aceptar;
        Conexion co;
        int TipoTrab;
        int ProID;
        int ProyectoOriginal;
        Trabajos tra;
        public bool aceptarElim = false;
                        //1 - Visualizar 2 - Crear un trabajo nuevo 
        public VisuaTrabajos(Trabajos tra,Conexion co,int x, int elem)
        {
            InitializeComponent();
            Region = Funciones.redondear(Width, Height);
            this.tra = tra;
            this.co = co;
            editando = false;
            aceptar = false;

            this.StartPosition = FormStartPosition.CenterParent;

            //Arrego para guardar los empleados extras en el modo edicion
            EmpleadosModoEdicion = new List<int>();

            //Opcion seleccionada en el frame anterior
            sel = elem;

            //Renglones usados en el dataGridView
            if (editando)
                rows = dataGridView1.RowCount;
            else
                rows = 0;

            //Arreglos para guardar los IDs de los Proyectos y empleados totales
            ProyectosID = new List<int>();
            EmpleadosID = new List<int>();

            //Arreglos para guardar los IDs y nombres de los empleados del trabajo seleccionado
            EmpleadosVisua = new List<int>();
            EmpleadosNom = new List<string>();

            //---------- El id del trabajo seleccionado --- Su proyecto ---- su TipoTrabjo ---------------
            IDTrab = x;
            ProID = 0;
            TipoTrab = 0;

            //----------------------Desplegar opciones en combobox--------------------------
            //Tipo de Trabajo
            co.Comando("SELECT NombreTipoTrab FROM TipoTrabajos;");
            List<String> Tipos = new List<String>();
            while (co.LeerRead)
            {
                String tipoTrb = co.Leer.GetString(0);
                Tipos.Add(tipoTrb);
            }
            //Proyecto del trabajo
            int numProSel = 0;
            List<String> Proyectos = new List<String>();
            co.Comando("SELECT IFNULL(ProyectosID,0) FROM Trabajos WHERE ID ="+ IDTrab+";");
            if (co.LeerRead)
                numProSel = co.Leer.GetInt32(0);
            //Coloco el nombre del proyecto del trabajo, si no tiene se coloca 0 y "sin proyecto"
            co.Comando("SELECT ID, Nombre FROM Proyectos WHERE ID ="+ numProSel+";");
            if (co.LeerRead)
            {
                ProyectosID.Add(co.Leer.GetInt32(0));
                Proyectos.Add(co.Leer.GetString(1));
                ProyectosID.Add(0);
                Proyectos.Add("Sin proyecto");
            }
            else
            {
                ProyectosID.Add(0);
                Proyectos.Add("Sin proyecto");
            }    
            //Proyectos
            co.Comando("SELECT ID,Nombre FROM Proyectos WHERE ID !="+numProSel+";");
            
            while (co.LeerRead)
            {
                int id = co.Leer.GetInt32(0);
                ProyectosID.Add(id);
                String Pro = co.Leer.GetString(1);
                Proyectos.Add(Pro);
            }

            //Empleados
            co.Comando("SELECT ID,Nombre FROM Empleado;");
            List<String> Nombres = new List<String>();
            while (co.LeerRead)
            {
                int id = co.Leer.GetInt32(0);
                EmpleadosID.Add(id);
                String Nom = co.Leer.GetString(1);
                Nombres.Add(Nom);
            }

            comboBox1.DataSource = Tipos;
            comboBox2.DataSource = Proyectos;
            comboBox3.DataSource = Nombres;
            ProyectoOriginal = ProyectosID[comboBox2.SelectedIndex];
            //------------------------------------------------------------------------------
            //Se esta visualizando un Trabajo
            if (elem == 1)
            {
                //Botones
                butEditar.Visible = true;
                butGuardar.Visible = false;
                butEliminar.Visible = true;
                butCerrar.Visible = true;
                editarEncargados.Visible = true;
                //butCancelar.Visible = false;
                AgreEmpleado.Visible = false;
                EliEmpleado.Visible = false;
                PrograPago.Visible = false;
                //TextBox
                textNombre.Enabled = false;
                richTextBox1.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                Tentrega.Enabled = false;
                comboBox3.Enabled = false;
                dataGridView1.Enabled = false;
                
                //------------------Editar trabajo---------------------------------------------
                co.Comando("SELECT Descripcion, Nombre,TiempoEntrega,TipoTrabajosID, IFNULL(ProyectosID,0) FROM Trabajos WHERE ID = " + IDTrab+";");

                if (co.LeerRead)
                {
                    richTextBox1.Text = co.Leer.GetString(0);
                    textNombre.Text = co.Leer.GetString(1);
                    Tentrega.Text = co.Leer.GetInt32(2).ToString();
                    TipoTrab = co.Leer.GetInt32(3);
                    ProID = co.Leer.GetInt32(4);

                }
                else
                {
                    MessageBox mensaje = new MessageBox("No se encuentra",3);
                    mensaje.ShowDialog();
                }

                //Cargo los empleados asignados al proyecto
                cargarEmpleados();


            }
            //Crear nuevo trabajo
            else
            {

                //Botones
                butEditar.Visible = false;
                butGuardar.Visible = false;
                butEliminar.Visible = false;
                butCerrar.Visible = true;
                editarEncargados.Visible = false;
                //butCancelar.Visible = false;
                cancelar.Visible = false;
                AgreEmpleado.Visible = true;
                EliEmpleado.Visible = true;
                PrograPago.Visible = true;
                //TextBox
                textNombre.Enabled = true;
                richTextBox1.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                Tentrega.Enabled = true;
                comboBox3.Enabled = true;
                dataGridView1.Enabled = true;

            }
        }
        private void cargarEmpleados()
        {
            //-----------------Consigo los IDs de los empleados del trabajo seleccionado
            co.Comando("SELECT EmpleadoID FROM Empleado_Trabajos WHERE " + IDTrab + "= TrabajosID;");
            while (co.LeerRead)
            {
                EmpleadosVisua.Add(co.Leer.GetInt32(0));
            }
            int i = EmpleadosVisua.Count;
            int sub = 0;
            if (i > 0)
                dataGridView1.RowCount = i;
            else
                dataGridView1.RowCount = 1;
            while (i > 0)
            {
                co.Comando("SELECT ID,Nombre FROM Empleado WHERE " + EmpleadosVisua[sub] + " = ID;");
                if (co.LeerRead)
                {
                    EmpleadosNom.Add(co.Leer.GetString(1));
                    dataGridView1[0, sub].Value = co.Leer.GetInt32(0);
                    dataGridView1[1, sub].Value = EmpleadosNom[sub];
                    sub++;
                }
                i--;
            }
        }
        //Validacion del formulario
        private bool Validacion()
        {
            if(textNombre.Text.Equals("") || richTextBox1.Text.Equals("") || Tentrega.Text.Equals(""))
            {
                MessageBox mens = new MessageBox("Complete el formulario", 2);
                mens.ShowDialog();
                return false;
            }
            return true;
        }

        private void butGuardar_Click(object sender, EventArgs e)
        {
            
            if (Validacion())
            {
                //Opcion guardar si es desde visualizar
                if (sel == 1)
                {
                    //Botones
                    butEditar.Visible = true;
                    butGuardar.Visible = false;
                    butEliminar.Visible = true;
                    butCerrar.Visible = true;
                    editarEncargados.Visible = true;
                    //butCancelar.Visible = false;
                    AgreEmpleado.Visible = false;
                    EliEmpleado.Visible = false;
                    PrograPago.Visible = false;
                    //TextBox
                    textNombre.Enabled = false;
                    richTextBox1.Enabled = false;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    Tentrega.Enabled = false;
                    comboBox3.Enabled = false;
                    dataGridView1.Enabled = false;

                    //-----------------Editar unicamente Trabajo--------------------
                    int tiempoEntrega = Convert.ToInt32(Tentrega.Text);
                    co.Comando("UPDATE Trabajos SET Nombre  = '" + textNombre.Text + "',Descripcion = '" + richTextBox1.Text + "',TipoTrabajosID = " +
                                    (comboBox1.SelectedIndex + 1) + ",TiempoEntrega = " + tiempoEntrega +
                                    ",FechaEntrega = adddate(CURDATE()," + tiempoEntrega + ") WHERE ID = " + IDTrab + ";");

                    //Si el proyecto es nulo y se le asigna un proyecto
                    if (ProyectoOriginal == 0 && ProyectosID[comboBox2.SelectedIndex] != 0)
                    {
                        co.Comando("UPDATE Trabajos SET ProyectosID = " + ProyectosID[comboBox2.SelectedIndex] + " WHERE ID = " + IDTrab + ";");
                    }
                    //Si el proyecto NO es nulo y se le asiga nulo
                    if (ProyectoOriginal != 0 && ProyectosID[comboBox2.SelectedIndex] == 0)
                    {
                        co.Comando("UPDATE Trabajos SET ProyectosID = null WHERE ID = " + IDTrab + ";");
                    }
                    //Si el proyecto NO es nulo y se le asigna otro proyecto 
                    if (ProyectoOriginal != 0 && ProyectosID[comboBox2.SelectedIndex] != 0)
                    {
                        co.Comando("UPDATE Trabajos SET ProyectosID = " + ProyectosID[comboBox2.SelectedIndex] + " WHERE ID = " + IDTrab + ";");
                    }
                    //Si el proyecto es nulo y se le asigna otro nulo, simplemente no se hace nada

                }
            }

        }

        private void butCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butEditar_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                //Botones
                butEditar.Visible = false;
                butGuardar.Visible = true;
                butEliminar.Visible = false;
                butCerrar.Visible = true;
                editarEncargados.Visible = true;
                //butCancelar.Visible = false;
                AgreEmpleado.Visible = false;
                EliEmpleado.Visible = false;
                PrograPago.Visible = false;
                //TextBox
                textNombre.Enabled = true;
                richTextBox1.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                Tentrega.Enabled = true;
                comboBox3.Enabled = true;
                dataGridView1.Enabled = false;
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 3);
                mens.ShowDialog();
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                try
                {
                    //Solo para comprobar que esta seleccionado un elemento de la tabla y pueda saltar el error de NullReferenceException
                    int comp = (int)dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value;

                    //Eliminar un empledo seleccionado de la BD desde visualizar
                    int numPagos = 0;
                    if (editando)
                    {
                        bool noEstaba = false;
                        //Este ciclo revisa si el empleado seleccionado fue agregado en modo edicion o no
                        for (int i = 0; i < EmpleadosModoEdicion.Count; i++)
                        {
                            if ((int)dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value == EmpleadosModoEdicion[i])
                            {
                                noEstaba = true;
                                EmpleadosModoEdicion.RemoveAt(i);
                            }

                        }
                        //Si no estaba entonces se elimina normalmente
                        if (noEstaba)
                            eliminarElemento(numPagos);
                        else
                        {
                            //Si ya estaba quiere decir que pertenece al trabajo y procede a eliminarse de la BD
                            //Mensaje que al acpetar se cambia la variable aceptar a TRUE desde el otro frame
                            MessageBox mensaje = new MessageBox("¿Seguro que desea eliminar?", 1);
                            mensaje.ShowDialog();
                        }


                        if (aceptar)
                        {
                            int IDPago = 0;
                            //Cuenta los pagos para saber si hay mas de 1 y asi evitar que un trabajo se quede sin empleados
                            co.Comando("SELECT COUNT(*) FROM Pago_Empleado_Trabajos WHERE TrabajosID = " + IDTrab + ";");
                            if (co.LeerRead)
                            {
                                numPagos = co.Leer.GetInt32(0);
                            }
                            //Si hay mas de un pago, procede a eliminar el seleccionado
                            if (numPagos > 1)
                            {
                                //Guarda el ID del PagoProgramado asociado a ese empleado
                                co.Comando("SELECT PagoProgramadoID FROM Pago_Empleado_Trabajos WHERE EmpleadoID = " + (int)dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value
                                           + " AND TrabajosID = " + IDTrab + ";");
                                if (co.LeerRead)
                                    IDPago = co.Leer.GetInt32(0);

                                //Elimina el PagoProgramado de PagoProgramado y en cascada de Pago_Empleados_Trabajos
                                co.Comando("DELETE FROM PagoProgramado WHERE ID =" + IDPago + ";");

                                //Finalmente elimina la asignacion del empleado al trabajoe en Empleado_Trabajos
                                co.Comando("DELETE FROM Empleado_Trabajos WHERE EmpleadoID = " + (int)dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value + " AND TrabajosID =" + IDTrab + ";");


                                eliminarElemento(0);

                                //Mensaje de confirmacion
                                MessageBox confirmacion = new MessageBox("Eliminado con exito", 2);
                                confirmacion.ShowDialog();
                            }
                            else
                            {
                                //En caso de ser <= 1 Entonces lanza la advertencia
                                MessageBox advertencia = new MessageBox("Un trabajo no puede quedarse sin empleados", 2);
                                advertencia.Show();
                                numPagos = 0;
                            }

                        }

                    }
                    else
                    {
                        eliminarElemento(numPagos);
                    }
                }
                catch (System.NullReferenceException)
                {
                    Form mensaje = new MessageBox("Seleccione un empleado", 2);
                    mensaje.ShowDialog();
                }
                catch (System.InvalidCastException)
                {
                    Form mensaje = new MessageBox("La tabla esta vacia", 2);
                    mensaje.ShowDialog();
                }

                //Si esta vacio quiere decir que no se agregaron nuevos empleados al Trabajo
                if (EmpleadosModoEdicion.Count == 0 && editando)
                    PrograPago.Visible = false;
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 2);
                mens.ShowDialog();
            }

        }
        //Metodo para eliminar elementos de la tabla
        private void eliminarElemento(int numPagos)
        {
            //Eliminar un empleado seleccionado
            if (numPagos == 0)
            {
                try
                {
                    //Si hay mas de 2 renglon y esta seleccionado el primero remuevoe el seleccionado
                    if (dataGridView1.CurrentCell.RowIndex < dataGridView1.RowCount - 1)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                    }
                    //Si no intercambio los valores del primero y segundo renglon 
                    else
                    {
                        int id = (int)dataGridView1[0, dataGridView1.CurrentCell.RowIndex - 1].Value;
                        string nombre = (string)dataGridView1[1, dataGridView1.CurrentCell.RowIndex - 1].Value;
                        dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value = id;
                        dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value = nombre;
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex - 1);
                        rows++;
                    }

                }
                //Si sucede un error entonces quiere decir que solo queda 1 renglon asi que pongo los valores en nulo
                catch (System.ArgumentOutOfRangeException)
                {
                    dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value = "";
                    dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value = "";
                    rows = 0;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                FormularioProgramarPago fpp;
                //Si no esta editando quiere decir que se creo un trabajo nuevo
                if (!editando)
                {
                    List<int> IDs = new List<int>();
                    //Se guardan los IDs de los empleados seleccionados para el trabajo
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                            IDs.Add((int)dataGridView1[0, i].Value);

                        //Se mandan al siguiente Frame para ser dados de alta, tambien se manda cuantos son y se pone
                        // 0 en Trabajo porque apenas se va a crear y se manda la opcion 1 que es crear un nuevo trabajo
                        fpp = new FormularioProgramarPago(tra,IDs, dataGridView1.RowCount, 0, 1, co);
                        fpp.Show();
                    }
                    catch (NullReferenceException er)
                    {
                        MessageBox error = new MessageBox("No hay ningun empleado asignado", 3);
                        error.ShowDialog();
                    }
                    catch (InvalidCastException)
                    {
                        MessageBox error = new MessageBox("No hay ningun empleado asignado", 3);
                        error.ShowDialog();
                    }

                }
                else
                {
                    //Se manda el arreglo con los nuevos empleados, su tamaño, el ID del trabajo al que van a ser agregados
                    // y la opcion 3 que indica dar de alta empleados en trabajo existente
                    fpp = new FormularioProgramarPago(tra,EmpleadosModoEdicion, EmpleadosModoEdicion.Count, IDTrab, 3, co);
                    fpp.ShowDialog();
                }
            }
        }

        private void butEliminar_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                List<int> PagoProgra = new List<int>();
                //Selecciono los pagosProgramados asociados al Trabjo y los almaceno
                co.Comando("SELECT PagoProgramadoID FROM Pago_Empleado_Trabajos WHERE TrabajosID = " + IDTrab);
                while (co.LeerRead)
                {
                    PagoProgra.Add(co.Leer.GetInt32(0));
                }

                int pagos = 0;
                int PagosProgra = PagoProgra.Count;
                int i = 0;
                while (PagosProgra > 0)
                {
                    //Compruebo si los pagosProgrmados tienen pagos realizados, si es asi aumento la variable
                    co.Comando("SELECT ID FROM Pagos WHERE PagoProgramadoID = " + PagoProgra[i]);
                    while (co.LeerRead)
                    {
                        pagos++;
                    }
                    i++;
                    PagosProgra--;
                }
                //Si no tiene pagos asociados a ningun pagoProgramado
                if (pagos == 0)
                {
                    MessageBox mens = new MessageBox("¿Seguro que desea eliminar el trabajo?", 1);
                    mens.ShowDialog();
                    if (aceptarElim)
                    {
                        List<int> IDPagosProgra = new List<int>();
                        //Guardo los IDs de los pagos programados asociados al trabajo 
                        co.Comando("SELECT PagoProgramadoID FROM Pago_Empleado_Trabajos WHERE TrabajosID = " + IDTrab);
                        while (co.LeerRead)
                            IDPagosProgra.Add(co.Leer.GetInt32(0));


                        //Elimino el trabajo y se elimina el registro de Empleado_Trabajos y Pago_Empleado_Trabajos en cascada
                        co.Comando("DELETE FROM Trabajos WHERE ID = " + IDTrab + ";");

                        //Elimino los Pagos Programados
                        PagosProgra = IDPagosProgra.Count;
                        i = 0;
                        while (PagosProgra > 0)
                        {
                            co.Comando("DELETE FROM  PagoProgramado WHERE ID = " + IDPagosProgra[i] + ";");
                            i++;
                            PagosProgra--;
                        }

                        MessageBox mens1 = new MessageBox("Eliminado con exito", 2);
                        mens1.ShowDialog();

                        this.Close();
                    }

                }
                else
                {
                    MessageBox men;
                    //En caso contrario muestro los pagos asociados al trabajo
                    if (pagos > 1)
                        men = new MessageBox("No se puede eliminar tiene " + pagos + " pagos asociados", 2);
                    else
                        men = new MessageBox("No se puede eliminar tiene " + pagos + " pago asociado", 2);
                    men.Show();
                }
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 3);
                mens.ShowDialog();
            }
            //Actualizo la info de trabajos
            tra.DatosTablas();

        }

        private void VisuaTrabajos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Trabajos frm1 = Application.OpenForms.OfType<Trabajos>().FirstOrDefault();

            if (frm1 != null)  //Si encuentra una instancia abierta
            {
                frm1.DatosTablas();
                //Cierra el frame
                this.Close();
            }

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void encargados_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                //Botones
                butEditar.Visible = false;
                butGuardar.Visible = false;
                butEliminar.Visible = false;
                butCerrar.Visible = true;
                editarEncargados.Visible = false;
                cancelar.Visible = true;
                AgreEmpleado.Visible = true;
                EliEmpleado.Visible = true;
                PrograPago.Visible = false;
                //TextBox
                textNombre.Enabled = false;
                richTextBox1.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                Tentrega.Enabled = false;
                comboBox3.Enabled = true;
                dataGridView1.Enabled = true;

                editando = true;
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 3);
                mens.ShowDialog();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //Cancelar edicion de empleados seleccionados
            //Botones
            butEditar.Visible = true;
            butGuardar.Visible = false;
            butEliminar.Visible = true;
            butCerrar.Visible = true;
            editarEncargados.Visible = true;
            //butCancelar.Visible = false;
            AgreEmpleado.Visible = false;
            EliEmpleado.Visible = false;
            PrograPago.Visible = false;
            //TextBox
            textNombre.Enabled = false;
            richTextBox1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            Tentrega.Enabled = false;
            comboBox3.Enabled = false;
            dataGridView1.Enabled = false;
            //Creo otra instancia con los datos correctos
            VisuaTrabajos frame2 = new VisuaTrabajos(tra, co, IDTrab, sel);
            frame2.ShowDialog();
            this.Close();
        }

        private void reasignar_Click(object sender, EventArgs e)
        {
        }

        private void mes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            Funciones.ReleaseCapture();
            Funciones.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Tentrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            //EL CODIGO POSTAL TIENE QUE SER NUMERICO, ASI QUE SE LIMITA CON CODIGO
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool chec = false;
            int i = dataGridView1.RowCount;
            //Compruebo que la casilla tenga info. Si row = 1 tiene info la primera
            if (rows > 0 || editando)
            {
                while (i > 0)
                {
                    //Compruebo que ningun id sea igual al seleccionado en el combobox3
                    if (EmpleadosID[comboBox3.SelectedIndex] == (int)dataGridView1[0, i-1].Value)
                        chec = true;
                    i--;
                }
            }
            //Si chec es false quiere decir que ninguno se repite
            if (chec == false)
            {
                //Agrega uno en la casilla por default si no se esta editando, si se edita tiene que haber alguien en la casilla 0
                if (dataGridView1.RowCount > rows && !editando)
                {
                    dataGridView1[0, rows].Value = EmpleadosID[comboBox3.SelectedIndex];
                    dataGridView1[1, rows].Value = comboBox3.SelectedItem;
                    rows++;                    
                }
                //Agrega un nuevo renglon una vez agregado el primer elemento
                else
                {
                    dataGridView1.Rows.Insert(0, EmpleadosID[comboBox3.SelectedIndex], comboBox3.SelectedItem);

                    //Si esta editando se guardan los IDs adicionales a los del trabajo y se habilita el boton de ProgramarPagos
                    if (editando)
                    {
                        EmpleadosModoEdicion.Add(EmpleadosID[comboBox3.SelectedIndex]);
                        PrograPago.Visible = true;
                    }
                    rows++;
                }
 
            }
                      
        }
    }
}
