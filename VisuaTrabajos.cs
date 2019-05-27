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
        //int numPro;
        int IDTrab;
        Conexion co;
        int TipoTrab;
        int ProID;
        public VisuaTrabajos(int x, int elem)
        {
            InitializeComponent();
            co = new Conexion();
            this.StartPosition = FormStartPosition.CenterParent;

            //Opcion seleccionada en el frame anterior
            sel = elem;

            //Renglones usados en el dataGridView
            rows = 0;

            //Arreglos para guardar los IDs de los Proyectos y empleados totales
            ProyectosID = new List<int>();
            EmpleadosID = new List<int>();

            //Arreglos para guardar los IDs y nombres de los empleados del trabajo seleccionado
            EmpleadosVisua = new List<int>();
            EmpleadosNom = new List<string>();

            //numPro = 0;
            //---------- El id del trabajo seleccionado --- Su proyecto ---- su TipoTrabjo ---------------
            IDTrab = x;
            ProID = 0;
            TipoTrab = 0;

            //----------------------Desplegar opciones en combo box--------------------------
            co.Comando("SELECT NombreTipoTrab FROM TipoTrabajos;");
            List<String> Tipos = new List<String>();
            while (co.LeerRead)
            {
                String tipoTrb = co.Leer.GetString(0);
                Tipos.Add(tipoTrb);
            }

            co.Comando("SELECT ID,Nombre FROM Proyectos;");
            List<String> Proyectos = new List<String>();
            while (co.LeerRead)
            {
                int id = co.Leer.GetInt32(0);
                ProyectosID.Add(id);
                // numPro++;
                String Pro = co.Leer.GetString(1);
                Proyectos.Add(Pro);
            }
            co.Comando("SELECT ID,Nombre FROM Empleado;");
            //Empleados
            List<String> Nombres = new List<String>();
            while (co.LeerRead)
            {
                int id = co.Leer.GetInt32(0);
                EmpleadosID.Add(id);
                //numPro++;
                String Nom = co.Leer.GetString(1);
                Nombres.Add(Nom);
            }

            comboBox1.DataSource = Tipos;
            comboBox2.DataSource = Proyectos;
            comboBox3.DataSource = Nombres;
            //------------------------------------------------------------------------------

            if (elem == 1)
            {
                butGuardar.Visible = false;
                butEliminar.Visible = true;
                butCancelar.Visible = false;
                butEditar.Visible = true;
                butCerrar.Visible = true;
                AgreEmpleado.Visible = false;
                EliEmpleado.Visible = false;
                textNombre.Enabled = false;
                comboBox3.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                Tentrega.Enabled = false;
                richTextBox1.Enabled = false;
                PrograPago.Visible = false;
                //------------------Editar trabajo---------------------------------------------
                co.Comando("SELECT Descripcion, Nombre,TiempoEntrega,TipoTrabajosID,ProyectosID FROM Trabajos WHERE ID = " + IDTrab+";");

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
                    MessageBox mensaje = new MessageBox("No se encuentra");
                    mensaje.ShowDialog();
                }
                //-----------------Consigo los IDs de los empleados del trabajo seleccionado
                co.Comando("SELECT EmpleadoID FROM Empleado_Trabajos WHERE " + IDTrab + "= TrabajosID;");
                while (co.LeerRead)
                {
                    EmpleadosVisua.Add(co.Leer.GetInt32(0));
                }
                int i = EmpleadosVisua.Count;
                int sub = 0;
                dataGridView1.RowCount = i;
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
            else
            {
                butGuardar.Visible = false;
                butEliminar.Visible = false;
                butCancelar.Visible = true;
                butEditar.Visible = false;
                butCerrar.Visible = false;
                textNombre.Enabled = true;
                comboBox3.Enabled = true;
                comboBox2.Enabled = true;
                Tentrega.Enabled = true;
                richTextBox1.Enabled = true;
                PrograPago.Visible = true;
            }
        }

        private void butGuardar_Click(object sender, EventArgs e)
        {
            //Opcion guardar si es desde visualizar
            if (sel == 1)
            {
                butEliminar.Visible = true;
                butEditar.Visible = true;
                butGuardar.Visible = false;
                textNombre.Enabled = false;
                comboBox3.Enabled = false;
                comboBox2.Enabled = false;
                Tentrega.Enabled = false;
                richTextBox1.Enabled = false;
                PrograPago.Visible = false;

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
            //Opcion editar
            butEliminar.Visible = false;
            butEditar.Visible = false;
            butGuardar.Visible = true;
            textNombre.Enabled = true;
            comboBox3.Enabled = true;
            //textTipo.Enabled = true;
            comboBox2.Enabled = true;
            //textTiempo.Enabled = true;
            richTextBox1.Enabled = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Eliminar un empleado seleccionado
            try
            {
                if (dataGridView1.CurrentCell.RowIndex < dataGridView1.RowCount - 1)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                }
                else
                {
                    int id = (int)dataGridView1[0, dataGridView1.CurrentCell.RowIndex-1].Value;
                    string nombre = (string)dataGridView1[1, dataGridView1.CurrentCell.RowIndex-1].Value;
                    dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value = id;
                    dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value = nombre;
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex-1);
                    rows++;
                }

            }
            catch (System.ArgumentOutOfRangeException)
            {
                dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value = "";
                dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value = "";
                rows = 0;
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> IDs = new List<int>();
            for (int i = 0;i < dataGridView1.RowCount;i++)
                IDs.Add((int)dataGridView1[0,i].Value);
            FormularioProgramarPago fpp = new FormularioProgramarPago(IDs, dataGridView1.RowCount,1);
            fpp.Show();
        }

        private void butEliminar_Click(object sender, EventArgs e)
        {
            List<int> PagoProgra = new List<int>();
            co.Comando("SELECT PagoProgramadoID FROM Pago_Empleado_Trabajos WHERE TrabajosID = " + IDTrab);
            while (co.LeerRead)
            {
                PagoProgra.Add(co.Leer.GetInt32(0));
            }

            int pagos = 0;
            int PagosProgra = PagoProgra.Count;
            int i = 0;
            while(PagosProgra > 0)
            {
                co.Comando("SELECT ID FROM Pagos WHERE PagoProgramadoID = " + PagoProgra[i]);
                while (co.LeerRead)
                {
                    pagos++;
                }
                i++;
                PagosProgra--;
            }
            if(pagos == 0)
            {
                List<int> IDPagosProgra = new List<int>();
                //Guardo los IDs de los pagos programados asociados al trabajo 
                co.Comando("SELECT PagoProgramadoID FROM Pago_Empleado_Trabajos WHERE TrabajosID = "+IDTrab);
                if (co.LeerRead)
                    IDPagosProgra.Add(co.Leer.GetInt32(0));

                //Elimino el registro de Empleado_Trabajos
                co.Comando("DELETE * FROM Empleado_Trabajos WHERE TrabajosID = "+IDTrab+";");

                //Elimino el registro de Pago_Empleado_Trabajos
                co.Comando("DELETE * FROM Pago_Empleado_Trabajos WHERE TrabajosID = "+IDTrab+";");

                //Elimino los Pagos Programados
                PagosProgra = IDPagosProgra.Count;
                i = 0;
                while(PagosProgra > 0)
                {
                    co.Comando("DELETE * FROM  PagoProgramado WHERE ID = " + IDPagosProgra[i] + ";");
                    i++;
                    PagosProgra--;
                }

                //Elimino el trabajo
                co.Comando("DELETE * FROM Trabajos WHERE ID = " + IDTrab+";");

                MessageBox mens = new MessageBox("ELiminado con exito");
                mens.ShowDialog();
            }
            else
            {
                MessageBox men = new MessageBox("No se puede eliminar tiene" + pagos+ " pagos asociados");
                men.Show();
            }
            

        }

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
        {
            bool chec = false;
            int i = dataGridView1.RowCount;
            //Compruebo que la casilla tenga info. Si row = 1 tiene info la primera
            if (rows > 0)
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
                //Agrega uno en la casilla por default
                if (dataGridView1.RowCount > rows)
                {

                    dataGridView1[0, rows].Value = EmpleadosID[comboBox3.SelectedIndex];
                    dataGridView1[1, rows].Value = comboBox3.SelectedItem;
                    rows++;


                }
                //Agrega un nuevo renglon una vez agregado el primer elemento
                else
                {
                    dataGridView1.Rows.Insert(0, EmpleadosID[comboBox3.SelectedIndex], comboBox3.SelectedItem);
                    rows++;
                }
            }
            
        }
    }
}
