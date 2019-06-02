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
        //string trab;
        int IDTrab, opcion;
        VisuaTrabajos frm2;
        Trabajos tra;
        List<int> IDPagosProgra;
        public FormularioProgramarPago(Trabajos tra, List<int> IDEmpleado, int con,int Trab ,int op,Conexion co)
        {
            InitializeComponent();
            Region = Funciones.redondear(Width, Height);
            this.tra = tra;
            //Inicia la transaccioin
            co.Comando("START TRANSACTION;");
            comboBox2.Enabled = false;
            frm2 = Application.OpenForms.OfType<VisuaTrabajos>().FirstOrDefault();
            opcion = op;
            this.co = co;
            estado = false;
            //Plazos de pago
            int[] plazos = new int[50];
            for (int j = 1;j < 51; j++)
                plazos[j-1] = j+1;
            comboBox2.DataSource = plazos;

            
            conta = con;
            IDs = IDEmpleado;
            IDTrab = Trab;
            Iniciar();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void Iniciar()
        {
            int i = 0;
            List<string> nombres = new List<string>();

            //Empleados para programar pago
            while (i < conta)
            {                
                co.Comando("SELECT Nombre FROM Empleado WHERE ID = " + IDs[i]);
                if (co.LeerRead)
                    nombres.Add(co.Leer.GetString(0));
                i++;
            }
            comboBox1.DataSource = nombres;

            //Nombre del trabajo
            if(opcion == 1 || opcion == 3)
            {   if(frm2 != null)
                    trabajo.Text = frm2.textNombre.Text;
                trabajo.Enabled = false;
            }

            IDPagosProgra = new List<int>();
            
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
            //Si da click en cancelar se cancela la transacción
            co.Comando("ROLLBACK;");
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Si esta en modo edicion
                if (opcion == 3)
                {
                    //Se dan de alta los empleados en el Trabajo seleccionado
                    alta();
                }
                else
                {
                    if (opcion == 1)
                    {
                        if (frm2 != null)  //Si encuentra una instancia abierta
                        {
                            string descripcion = frm2.richTextBox1.Text;
                            string nombre = frm2.textNombre.Text;
                            int tiempoEntrega = Convert.ToInt32(frm2.Tentrega.Text);
                            int tipoTrab = frm2.comboBox1.SelectedIndex + 1;
                            int idPro = frm2.ProyectosID[frm2.comboBox2.SelectedIndex];
                            string tiempo;
                            //Se selecciona el intervalo
                            if (frm2.dias.Checked)
                                tiempo = "day";
                            else if (frm2.mes.Checked)
                                tiempo = "month";
                            else
                                tiempo = "year";
                            //Se crea el Trabajo nuevo. Si idPro es 0 no hay proyecto asociado
                            co.Comando("CALL insert_Trabajos('" + descripcion + "','" + nombre + "'," + tiempoEntrega + ",'" + tiempo + "'," + tipoTrab + "," + idPro + ");");

                            //Se selecciona el ID maximo de Trabajos que indica el ultimo trabajo creado y al que se le agregaran los empleados
                            co.Comando("SELECT ID FROM Trabajos WHERE ID = (SELECT MAX(ID) FROM Trabajos);");
                            if (co.LeerRead)
                            {
                                IDTrab = co.Leer.GetInt32(0);
                            }
                        }
                        opcion = 0;

                    }
                    //Se dan de alta los empleados en el ultimo trabajo creado
                    alta();
                }
                if (IDs.Count > 0)
                {
                    Iniciar();
                }
                else
                {

                    tra.DatosTablas();
                    frm2.Close();
                    //Una vez concluido se termina la transacción
                    co.Comando("COMMIT;");
                    this.Close();
                }
            }catch(Exception)
            {
                co.Comando("ROLLBACK;");
                MessageBox mens = new MessageBox("Error al crear los pagos correspondientes", 3);
                mens.ShowDialog();
                frm2.Close();
                this.Close();
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Funciones.ReleaseCapture();
            Funciones.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormularioProgramarPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            tra.DatosTablas();
        }

        private void alta()
        {
            MessageBox mens = new MessageBox("¿Esta seguro que desea guardar?", 1);
            mens.ShowDialog();
            if (estado)
            {
                int maxID = 0;
                //Creo un elemento de la tabla Empleado_Trabajos   (int)frm2.dataGridView1[0, comboBox1.SelectedIndex].Valu
                co.Comando("INSERT INTO Empleado_Trabajos VALUES(" + IDs[comboBox1.SelectedIndex] + "," + IDTrab + ");");

                //Creo un elemento de la tabla PagoProgramado  0 - Contado  1 - Diferido
                co.Comando("INSERT INTO PagoProgramado (Tipo, NumTotalPagos) VALUES(" + (radioButton1.Checked ? 0 : 1) + "," + (radioButton1.Checked ? 1 : (int)comboBox2.SelectedItem) + ");");


                //Selecciono el ultimo pago programado para asignarlo al trabajador
                co.Comando("SELECT MAX(ID) FROM PagoProgramado;");
                if (co.LeerRead)
                {
                    maxID = co.Leer.GetInt32(0);
                }

                //Creo el elemento de la tabla Pago_Empleadp_Trabajos
                co.Comando("INSERT INTO Pago_Empleado_Trabajos VALUES(" + maxID + "," + IDs[comboBox1.SelectedIndex] + "," + IDTrab + ");");
                //Remuevo del arreglo el empleado ya asignado
                IDs.RemoveAt(comboBox1.SelectedIndex);
                conta--;
            }
        }
    }
}
