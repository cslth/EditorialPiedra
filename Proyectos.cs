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
    public partial class Proyectos : Form
    {
        Conexion co;
        public Proyectos(Conexion co)
        {
            InitializeComponent();
            
            //Conexion
            this.co = co;

            //Actualiza las tablas
            DatosTablas();
            
        }
        public void DatosTablas()
        {
           //Cuento los proyectos vigentes
            co.Comando("SELECT COUNT(*) FROM Proyectos WHERE FechaFin >= CURDATE();");
            int rows = 0;
            if (co.LeerRead)
                rows = co.Leer.GetInt32(0);

            if (rows == 0)
            {
                dataGridView1.RowCount = 1;
                dataGridView1[0, 0].Value = "";
                dataGridView1[1, 0].Value = "";
                dataGridView1[2, 0].Value = "";
                dataGridView1[3, 0].Value = "";
                dataGridView1[4, 0].Value = "";

            }
            else
            {
                dataGridView1.RowCount = rows;
            }
                
            

            //Selecciono todos sus datos y los coloco en el dataGridView1
            co.Comando("SELECT * FROM Proyectos WHERE FechaFin >= CURDATE();");
            int i = 0;

            while (co.LeerRead)
            {
                dataGridView1[0, i].Value = co.Leer.GetInt32(0);
                dataGridView1[1, i].Value = co.Leer.GetString(1);
                dataGridView1[2, i].Value = co.Leer.GetMySqlDateTime(3);
                dataGridView1[3, i].Value = co.Leer.GetMySqlDateTime(4);
                dataGridView1[4, i].Value = co.Leer.GetString(5);
                i++;
            }


            //------------------Mostrar datos en tablas Proyectos ----Proyectos pasados----------------------
            //Cuento los proyectos pasados 
            co.Comando("SELECT COUNT(*) FROM Proyectos WHERE FechaFin < CURDATE();");
            rows = 0;
            if (co.LeerRead)
                rows = co.Leer.GetInt32(0);

            if (rows == 0)
            {
                dataGridView2.RowCount = 1;
                dataGridView2[0, 0].Value = "";
                dataGridView2[1, 0].Value = "";
                dataGridView2[2, 0].Value = "";
                dataGridView2[3, 0].Value = "";
                dataGridView2[4, 0].Value = "";

            }
            else
            {
                dataGridView2.RowCount = rows;
            }

            i = 0;
            

            //Selecciono todos sus datos y los coloco en el dataGridView
            co.Comando("SELECT * FROM Proyectos WHERE FechaFin < CURDATE();");
            while (co.LeerRead)
            {
                dataGridView2[0, i].Value = co.Leer.GetInt32(0);
                dataGridView2[1, i].Value = co.Leer.GetString(1);
                dataGridView2[2, i].Value = co.Leer.GetMySqlDateTime(3);
                dataGridView2[3, i].Value = co.Leer.GetMySqlDateTime(4);
                dataGridView2[4, i].Value = co.Leer.GetString(5);
                i++;
            }
       
            //------------------------------------------------------------------------------
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Visualizar un proyecto existente
            try
            {
                //Comprueba que la cadena no sea nula
                if (!dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.Equals(""))
                {
                    Form visuaProy = new VisuaProyecto(this,co, (int)dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value, 1);
                    visuaProy.ShowDialog();
                }
                else
                {
                    Form mensaje = new MessageBox("No hay proyectos que mostrar", 2);
                    mensaje.ShowDialog();
                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox mensaje = new MessageBox("Seleccione un proyecto",2);
                mensaje.ShowDialog();
            }
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                //Agergar un proyecto nuevo
                Form visuaProy = new VisuaProyecto(this,co, 0, 2);
                visuaProy.ShowDialog();
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 3);
                mens.ShowDialog();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Visualizar(Le mando el id del proyecto)
            try
            {
                //Comprueba que la cadena no sea nula
                if (!dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.Equals(""))
                {
                    Form visuaProy = new VisuaProyecto(this,co, (int)dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value, 1);
                    visuaProy.ShowDialog();
                }
                else
                {
                    Form mensaje = new MessageBox("No hay proyectos que mostrar", 2);
                    mensaje.ShowDialog();
                }
            }
            catch (System.NullReferenceException)
            {
                Form mensaje = new MessageBox("Seleccione un proyecto",2);
                mensaje.ShowDialog();
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            string fechaA = fecha1.Value.Date.ToString("yyyy-MM-dd");

            string fechaB = fecha2.Value.Date.ToString("yyyy-MM-dd");

            buscarProyecto(fechaA, fechaB, dataGridView1, 1);

        }
        private void buscarProyecto(string fechaA, string fechaB, DataGridView dataGridView, int sel)
        {
            //Selecciono el simbolo correcto
            string simbolo = "";
            if (sel == 1)
                simbolo = ">=";
            else
                simbolo = "<";
            //Cuento los proyectos que se hayan encontrado segun el caso
            co.Comando("SELECT COUNT(*) FROM Proyectos WHERE FechaFin "+simbolo+" CURDATE() AND FechaFin between '" + fechaA + "' AND '" + fechaB + "';");
            int rows = 0;
            if (co.LeerRead)
                rows = co.Leer.GetInt32(0);

            if (rows > 0)
                dataGridView.RowCount = rows;
            else
            {
                dataGridView.RowCount = 1;
                dataGridView[0, 0].Value = "";
                dataGridView[1, 0].Value = "";
                dataGridView[2, 0].Value = "";
                dataGridView[3, 0].Value = "";
                dataGridView[4, 0].Value = "";
            }

            //Selecciono la info de tales proyectos
            co.Comando("SELECT * FROM Proyectos WHERE  FechaFin " + simbolo + " CURDATE() AND FechaFin between '" + fechaA + "' AND '" + fechaB + "';");
            int i = 0;
            while (co.LeerRead)
            {
                dataGridView[0, i].Value = co.Leer.GetInt32(0);
                dataGridView[1, i].Value = co.Leer.GetString(1);
                dataGridView[2, i].Value = co.Leer.GetMySqlDateTime(3);
                dataGridView[3, i].Value = co.Leer.GetMySqlDateTime(4);
                dataGridView[4, i].Value = co.Leer.GetString(5);
                i++;
            }


        }

        private void buscar2_Click(object sender, EventArgs e)
        {

            string fechaA = fecha3.Value.Date.ToString("yyyy-MM-dd");

            string fechaB = fecha4.Value.Date.ToString("yyyy-MM-dd");

            buscarProyecto(fechaA, fechaB, dataGridView2, 2);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Proyectos_SizeChanged(object sender, EventArgs e)
        {
            label1.Location = new Point(43, label1.Location.Y);
            dataGridView1.Location = new Point(43, dataGridView1.Location.Y);
            dataGridView1.Width = this.Width - 94;

            label2.Location = new Point(43, label2.Location.Y);
            dataGridView2.Location = new Point(43, dataGridView2.Location.Y);
            dataGridView2.Width = this.Width - 94;

            butVisua.Location = new Point(this.Width - 197, butVisua.Location.Y);
            butVisua2.Location = new Point(this.Width - 197, butVisua2.Location.Y);

            button3.Location = new Point(this.Width - 92, button3.Location.Y);
        }
    }
}
