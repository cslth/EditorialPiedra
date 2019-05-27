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
    public partial class FormularioProgramarPago : Form
    {
        List<int> IDs;
        int conta;
        Conexion co;
        public bool estado;
        string trab;
        int IDTrab, opcion;
        VisuaTrabajos frm2;
        public FormularioProgramarPago(List<int> IDEmpleado, int con, int op)
        {
            InitializeComponent();
            comboBox2.Enabled = false;
            frm2 = Application.OpenForms.OfType<VisuaTrabajos>().FirstOrDefault();
            opcion = op;
            co = new Conexion();
            estado = false;
            //Plazos de pago
            int[] plazos = new int[50];
            for (int j = 1;j < 51; j++)
                plazos[j-1] = j+1;
            comboBox2.DataSource = plazos;

            
            conta = con;
            IDs = IDEmpleado;
            Iniciar();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void Iniciar()
        {
            int i = 0;
            List<string> nombres = new List<string>();
            while (i < conta)
            {                
                co.Comando("SELECT Nombre FROM Empleado WHERE ID = " + IDs[i]);
                if (co.LeerRead)
                    nombres.Add(co.Leer.GetString(0));
                i++;
            }
            comboBox1.DataSource = nombres;

            //Nombre del trabajo
            if(opcion == 1)
            {   if(frm2 != null)
                    trabajo.Text = frm2.textNombre.Text;
                trabajo.Enabled = false;
            }
            

            /*co.Comando("SELECT Nombre,ID FROM Trabajos WHERE ID = (SELECT MAX(ID) FROM Trabajos);");
            if (co.LeerRead)
            {
                trab = co.Leer.GetString(0);
                trabajo.Text = trab;
                IDTrab = co.Leer.GetInt32(1);
            }*/


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

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
        }

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void aceptar_Click(object sender, EventArgs e)
        {
           if(opcion == 1)
            {
                //VisuaTrabajos frm2 = Application.OpenForms.OfType<VisuaTrabajos>().FirstOrDefault();

                if (frm2 != null)  //Si encuentra una instancia abierta
                {
                    string descripcion = frm2.richTextBox1.Text;
                    string nombre = frm2.textNombre.Text;
                    int tiempoEntrega = Convert.ToInt32(frm2.Tentrega.Text);
                    int tipoTrab = frm2.comboBox1.SelectedIndex + 1;
                    int idPro = frm2.ProyectosID[frm2.comboBox2.SelectedIndex];

                    co.Comando("INSERT INTO Trabajos (Descripcion,Nombre,TiempoEntrega,FechaEntrega,TipoTrabajosID, ProyectosID  ) VALUES('"
                                        + descripcion + "','" + nombre + "'," + tiempoEntrega + "," + "adddate(CURDATE(),"
                                        + tiempoEntrega + ")," + tipoTrab + "," + idPro + ");");
                    co.Comando("SELECT ID FROM Trabajos WHERE ID = (SELECT MAX(ID) FROM Trabajos);");
                    if (co.LeerRead)
                    {
                        IDTrab = co.Leer.GetInt32(0);
                    }
                }
                opcion = 0;
   
            }

            //Checar la logica de esto
            int maxID = 0;
            MessageBox mens = new MessageBox("¿Esta seguro que desea guardar?");
            mens.ShowDialog();
            if (estado)
            {
                //Creo un elemento de la tabla Empleado_Trabajos   (int)frm2.dataGridView1[0, comboBox1.SelectedIndex].Valu
                co.Comando("INSERT INTO Empleado_Trabajos VALUES(" + IDs[comboBox1.SelectedIndex] + "," + IDTrab + ");");


                //Creo un elemento de la tabla PagoProgramado  0 - Contado  1 - Diferido
                co.Comando("INSERT INTO PagoProgramado (Tipo, NumTotalPagos) VALUES(" + (radioButton1.Checked ? 0 : 1) + "," + (radioButton1.Checked ? 1 : (int)comboBox2.SelectedItem)+");");


                //Selecciono el ultimo pago programado para asignarlo al trabajador
                co.Comando("SELECT MAX(ID) FROM PagoProgramado;");
                if (co.LeerRead)
                {
                    maxID = co.Leer.GetInt32(0);
                }

                //Creo el elemento de la tabla Pago_Empleadp_Trabajos
                co.Comando("INSERT INTO Pago_Empleado_Trabajos VALUES(" + maxID + ","+IDs[comboBox1.SelectedIndex]+","+IDTrab+");");
                //Remuevo del arreglo el empleado ya asignado
                IDs.RemoveAt(comboBox1.SelectedIndex);
                conta--;
            }
            //Comprueba si hay empleados que agregar
            if(IDs.Count > 0)
            {
                Iniciar();
            }
            else
            {
                frm2.Close();
                this.Close();
            }


            
        }
    }
}
