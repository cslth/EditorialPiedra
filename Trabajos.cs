using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace AppProyectoBD
{
    
    public partial class Trabajos : Form
    {
        Conexion co;
        List<int> TrabajosID;
        public Trabajos(Conexion co)
        {
            InitializeComponent();
            this.co = co;
            TrabajosID = new List<int>();
            DatosTablas();
            
        }
        //Modificar dias en fechas al hacer un update en trabajos  **checar**
        public void DatosTablas()
        {
            //------------------Mostrar datos en tablas Tabajos ----Trabajos actuales----------------------
            //Cuento los numeros de Trabajos en dicha fecha
            int rows = 0;
            co.Comando("SELECT COUNT(*) FROM Trabajos WHERE FechaEntrega >= CURDATE();");
           
            if (co.LeerRead)
                rows = co.Leer.GetInt32(0);
            if (rows == 0)
                rows = 1;
            int i = 0;
            dataGridView1.RowCount = rows;
            
            //Coloco los los datos de los Trabajos en la tabla  
            co.Comando("SELECT t.ID, t.nombre, tt.NombreTipoTrab ,IFNULL(p.Nombre,'Sin proyecto'), t.FechaEntrega FROM Proyectos as p " +
                       "RIGHT OUTER JOIN Trabajos as t ON (t.ProyectosID = p.ID) " +
                       "INNER JOIN TipoTrabajos AS tt ON (t.TipoTrabajosID = tt.ID) " +
                       "WHERE t.FechaEntrega >= CURDATE();");
            while (co.LeerRead)
            {
                dataGridView1[0, i].Value = co.Leer.GetInt32(0);
                dataGridView1[1, i].Value = co.Leer.GetString(1);
                dataGridView1[2, i].Value = co.Leer.GetString(2);
                dataGridView1[3, i].Value = co.Leer.GetString(3);
                dataGridView1[4, i].Value = co.Leer.GetMySqlDateTime(4);
                i++;
            }
               
            i = 0;
            //------------------Mostrar datos en tablas Trabajos ----Trabajos pasados----------------------
            //Cuento los numeros de Trabajos en dicha fecha
            co.Comando("SELECT COUNT(*) FROM Trabajos WHERE FechaEntrega < CURDATE();");
            rows = 0;
            if (co.LeerRead)
                rows = co.Leer.GetInt32(0);
            if (rows > 0)
                dataGridView2.RowCount = rows;
            else
                dataGridView2.RowCount = 1;

            //Coloco los los datos de los Trabajos en la tabla 

            co.Comando("SELECT t.ID, t.nombre, tt.NombreTipoTrab ,IFNULL(p.Nombre,'Sin proyecto'), t.FechaEntrega FROM Proyectos as p " +
                        "RIGHT OUTER JOIN Trabajos as t ON (t.ProyectosID = p.ID) " +
                        "INNER JOIN TipoTrabajos AS tt ON (t.TipoTrabajosID = tt.ID) " +
                        "WHERE t.FechaEntrega < CURDATE();");
            while (co.LeerRead)
            {
                dataGridView2[0, i].Value = co.Leer.GetInt32(0);
                dataGridView2[1, i].Value = co.Leer.GetString(1);
                dataGridView2[2, i].Value = co.Leer.GetString(2);
                dataGridView2[3, i].Value = co.Leer.GetString(3);
                dataGridView2[4, i].Value = co.Leer.GetMySqlDateTime(4);
                i++;
            }
            //------------------------------------------------------------------------------
        }

        private void Trabajos_Load(object sender, EventArgs e)
        {

        }

        private void butVisua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.Equals(""))
                {
                    Form visuaTrabajos = new VisuaTrabajos(co, (int)dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value, 1);
                    visuaTrabajos.ShowDialog();
                }
                else
                {
                    Form mensaje = new MessageBox("No hay trabajos que mostrar", 2);
                    mensaje.ShowDialog();
                }
            }
            catch (System.NullReferenceException)
            {
                Form mensaje = new MessageBox("Seleccione un trabajo",1);
                mensaje.ShowDialog();
            }
        }

        private void butVisua2_Click(object sender, EventArgs e)
        {
            try
            {
                Form visuaTrabajos = new VisuaTrabajos(co,(int)dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value, 1);
                visuaTrabajos.ShowDialog();
            }
            catch (System.NullReferenceException)
            {
                Form mensaje = new MessageBox("Seleccione un trabajo",1);
                mensaje.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form visuaTrabajos = new VisuaTrabajos(co,0, 2);
            visuaTrabajos.ShowDialog();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            string fechaInicio = fecha1.Text;
            string año = fechaInicio.Substring(6, 4);
            string mes = fechaInicio.Substring(2, 4);
            string dia = fechaInicio.Substring(0, 2);
            string fechaA = año + mes + dia;

            string fechaFin = fecha2.Text;
            string año2 = fechaFin.Substring(6, 4);
            string mes2 = fechaFin.Substring(2, 4);
            string dia2 = fechaFin.Substring(0, 2);
            string fechaB = año2 + mes2 + dia2;

            buscarTrabajos(fechaA, fechaB, dataGridView1,1);
        }

        private void buscarTrabajos(string fechaA, string fechaB, DataGridView dataGridView, int sel)
        {
            string simbolo = "";
            if (sel == 1)
                simbolo = ">=";
            else
                simbolo = "<";
            // Cuento los Trabajos entre ese rango de fechas
            co.Comando("SELECT COUNT(*) FROM Trabajos WHERE FechaEntrega "+simbolo+" CURDATE() AND FechaEntrega  between '" + fechaA + "' AND '" + fechaB + "';");
            int rows = 0;
            if (co.LeerRead)
                rows = co.Leer.GetInt32(0);

            //Coloco los renglones en los datagridview segun sea el caso
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
            //Selecciono el ID, nombre del trabajo  y proyecto y la fecha de fin
            int i = 0;
            co.Comando("SELECT t.ID, t.nombre, tipo.NombreTipoTrab, IFNULL(p.Nombre,'Sin proyecto'), t.FechaEntrega FROM Trabajos AS t " +
                       "LEFT OUTER JOIN Proyectos AS p ON ( t.ProyectosID = p.ID) " +
                       "INNER JOIN TipoTrabajos AS tipo ON (t.TipoTrabajosID = tipo.ID) " +
                       "WHERE t.FechaEntrega " + simbolo + " CURDATE() AND t.FechaEntrega between '" + fechaA + "' AND '" + fechaB + "';");
            //Lo muestro en el datagridview correspondiente
            
            while (co.LeerRead)
            {
                dataGridView[0, i].Value = co.Leer.GetInt32(0);
                dataGridView[1, i].Value = co.Leer.GetString(1);
                dataGridView[2, i].Value = co.Leer.GetString(2);
                dataGridView[3, i].Value = co.Leer.GetString(3);
                dataGridView[4, i].Value = co.Leer.GetMySqlDateTime(4);
                i++;
            }

        }
    
        private void buscar2_Click(object sender, EventArgs e)
        {
            string fechaInicio = fecha3.Text;
            string año = fechaInicio.Substring(6, 4);
            string mes = fechaInicio.Substring(2, 4);
            string dia = fechaInicio.Substring(0, 2);
            string fechaA = año + mes + dia;

            string fechaFin = fecha4.Text;
            string año2 = fechaFin.Substring(6, 4);
            string mes2 = fechaFin.Substring(2, 4);
            string dia2 = fechaFin.Substring(0, 2);
            string fechaB = año2 + mes2 + dia2;

            buscarTrabajos(fechaA, fechaB,dataGridView2,2);
        }
    }

}

