using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProyectoBD
{
    public partial class pagos : Form
    {
        Form fh;
        Conexion co;
        public pagos(Conexion co)
        {
            InitializeComponent();
            this.co = co;
            dataGridView3.Visible = false;

            //Metodos de datos de las tablas
            datosPagosProgra();
            datosPagosGastos();

        }

        public void datosPagosProgra()
        {
         
            int TotalPP = 0;
            string simbolo;
            //Checo si son presentes o los pagos hechos
            if (presentes.Checked)
                simbolo = ">";
            else
                simbolo = "=";


            //Cuento los PagosProgramados 
            co.Comando("SELECT COUNT(*) FROM PagoProgramado WHERE NumTotalPagos "+simbolo+" 0;");
            if (co.LeerRead)
                TotalPP = co.Leer.GetInt32(0);

            if (TotalPP > 0)
                dataGridView1.RowCount = TotalPP;
            else
            {
                dataGridView1.RowCount = 1;
                dataGridView1[0, 0].Value = "";
                dataGridView1[1, 0].Value = "";
                dataGridView1[2, 0].Value = "";
                dataGridView1[3, 0].Value = "";
                dataGridView1[4, 0].Value = "";

            }

            //Coloco los datos de la tabla de PagosProgramados
            co.Comando("SELECT p.ID, e.Nombre, t.Nombre, IFNULL(pro.Nombre,'Sin Proyecto'), p.NumTotalPagos  " +
                           "FROM Empleado AS e " +
                           "INNER JOIN Pago_Empleado_Trabajos AS pet ON(pet.EmpleadoID = e.ID) " +
                           "INNER JOIN PagoProgramado AS p ON(pet.PagoProgramadoID = p.ID) " +
                           "INNER JOIN Trabajos AS t ON(t.ID = pet.TrabajosID) " +
                           "LEFT OUTER JOIN Proyectos AS pro ON(pro.ID = t.ProyectosID) " +
                           "WHERE p.NumTotalPagos "+simbolo+" 0");
            int i = 0;
            while (co.LeerRead)
            {
                dataGridView1[0, i].Value = co.Leer.GetInt32(0);
                dataGridView1[1, i].Value = co.Leer.GetString(1);
                dataGridView1[2, i].Value = co.Leer.GetString(2);
                dataGridView1[3, i].Value = co.Leer.GetString(3);
                dataGridView1[4, i].Value = co.Leer.GetInt32(4);
                i++;
            }

        }
        public void datosPagosGastos()
        {
            if (pags.Checked)
            {

                //Cuento los pagos que sean Pagos a empleados
                int ren = 1;
                co.Comando("SELECT COUNT(*) FROM Pagos WHERE PagoProgramadoID IS NOT NULL;");
                if (co.LeerRead)
                    ren = co.Leer.GetInt32(0);
                if (ren > 1)
                    dataGridView2.RowCount = ren;
                else
                {
                    dataGridView2.RowCount = 1;
                    dataGridView2[0, 0].Value = "";
                    dataGridView2[1, 0].Value = "";
                    dataGridView2[2, 0].Value = "";
                    dataGridView2[3, 0].Value = "";
                    dataGridView2[4, 0].Value = "";
                }
                //Muestra los datos completos del pago, trabajo por el que se pago, monto entre otras cosas
                co.Comando("SELECT Distinct  p.ID, e.Nombre, t.Nombre ,p.FechaPago, p.monto " +
                            "FROM Pagos as p INNER JOIN PagoProgramado as PaPr ON(p.PagoProgramadoID = PaPr.ID) " +
                            "INNER JOIN Pago_Empleado_Trabajos as Pet ON(Papr.ID = Pet.PagoProgramadoID)" +
                            "INNER JOIN Empleado_Trabajos as Et ON(Pet.EmpleadoID = Et.EmpleadoID)" +
                            "INNER JOIN Empleado as e ON(Pet.EmpleadoID = e.ID)" +
                            "INNER JOIN Trabajos as t ON(Pet.TrabajosID = t.ID); ");

                int k = 0;
                //Coloco los resultados
                while (co.LeerRead)
                {
                    dataGridView2[0, k].Value = co.Leer.GetUInt32(0);
                    dataGridView2[1, k].Value = co.Leer.GetString(1);
                    dataGridView2[2, k].Value = co.Leer.GetString(2);
                    dataGridView2[3, k].Value = co.Leer.GetMySqlDateTime(3);
                    dataGridView2[4, k].Value = co.Leer.GetString(4);
                    k++;
                }
            }
            else
            {
                int gastosTotales = 1;
                //Cuento cuantos gastos hay para colocar los renglones en la tabla
                co.Comando("SELECT COUNT(*) FROM Gasto;");
                if (co.LeerRead)
                    gastosTotales = co.Leer.GetInt32(0);
                if (gastosTotales > 0)
                    dataGridView3.RowCount = gastosTotales;
                else
                {
                    dataGridView3.RowCount = 1;
                    dataGridView3[0, 0].Value = "";
                    dataGridView3[1, 0].Value = "";
                    dataGridView3[2, 0].Value = "";
                    dataGridView3[3, 0].Value = "";
                    dataGridView3[4, 0].Value = "";
                }

                //Saco los datos de cada gasto y los coloco en la tabla
                co.Comando("SELECT p.ID, g.Concepto, m.Metodo, p.FechaPago, p.Monto " +
                                           "FROM Pagos AS p INNER JOIN Metodo AS m ON(m.ID = p.MetodoID) " +
                                           "INNER JOIN Gasto AS g ON(g.ID = p.GastoID) " +
                                           "WHERE p.GastoID IS NOT NULL ;");
                int j = 0;
                while (co.LeerRead)
                {
                    dataGridView3[0, j].Value = co.Leer.GetInt32(0);
                    dataGridView3[1, j].Value = co.Leer.GetString(1);
                    dataGridView3[2, j].Value = co.Leer.GetString(2);
                    dataGridView3[3, j].Value = co.Leer.GetMySqlDateTime(3);
                    dataGridView3[4, j].Value = co.Leer.GetInt32(4);
                    j++;

                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reporte_Click(object sender, EventArgs e)
        {
            Reportes rep = new Reportes(co);
            rep.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Comprobaciones 
            try
            {
                if (pags.Checked)
                {
                    if (!dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.Equals(""))
                    {
                        fh = new FormularioPago(this,Convert.ToInt32(dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value), 1, co);
                        fh.ShowDialog();
                    }
                    else
                    {
                        MessageBox mens = new MessageBox("No hay pagos", 2);
                        mens.ShowDialog();
                    }
                }
                else
                {
                    if (!dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.Equals(""))
                    {
                        fh = new FormularioPago(this,Convert.ToInt32(dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value), 2, co);
                        fh.ShowDialog();
                    }
                    else
                    {
                        MessageBox mens2 = new MessageBox("No hay gastos", 2);
                        mens2.ShowDialog();
                    }
                }
            }catch(Exception ef)
            {
                MessageBox mens3 = new MessageBox("Seleccione un elemento", 2);
                mens3.ShowDialog();
            }
        }

        private void pagar_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                try
                {
                    if (!dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.Equals(""))
                    {
                        fh = new FormularioPago(this,(int)dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value, 0, co);
                        fh.ShowDialog();
                    }
                    else
                    {
                        MessageBox mens = new MessageBox("No hay pagos que realizar", 3);
                        mens.ShowDialog();
                    }
                }
                catch (System.NullReferenceException)
                {
                    MessageBox mensaje = new MessageBox("Seleccione un pago", 2);
                    mensaje.ShowDialog();
                }
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 3);
                mens.ShowDialog();
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pasados_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void gastos_CheckedChanged(object sender, EventArgs e)
        {
            //Coloco los titulos y hago visible las tablas correspondientes
            if (dataGridView2.Visible)
            {
                titulo.Text = "GASTOS";
                dataGridView2.Visible = false;
                dataGridView3.Visible = true;
                datosPagosGastos();
            }
            else
            {
                titulo.Text = "PAGOS REALIZADOS ";
                dataGridView2.Visible = true;
                dataGridView3.Visible = false;
                datosPagosGastos();
            }
        }

        private void presentes_CheckedChanged(object sender, EventArgs e)
        {
            //Actualizo los datos de la tabla
            datosPagosProgra();
        }

        private void pags_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pagos_Load(object sender, EventArgs e)
        {

        }


        private void empleado_TextChanged(object sender, EventArgs e)
        {
            //Depende de en cual tabla este coloco el simbolo correspondiente a la consulta
            string simbolo;
            if (presentes.Checked)
                simbolo = ">";
            else
                simbolo = "=";
            
            int reng = 1;
            if (!empleado.Text.Equals(""))
            {
                co.Comando("SELECT COUNT(*) FROM Empleado AS e " +
                           "INNER JOIN Pago_Empleado_Trabajos AS pet ON(pet.EmpleadoID = e.ID) " +
                           "INNER JOIN PagoProgramado AS p ON(pet.PagoProgramadoID = p.ID) " +
                           "WHERE e.Nombre LIKE '" + empleado.Text + "%' AND p.NumTotalPagos " + simbolo + " 0; ");
                if (co.LeerRead)
                    reng = co.Leer.GetInt32(0);
                if (reng > 0)
                    dataGridView1.RowCount = reng;
                else
                    dataGridView1.RowCount = 1;
                if (reng > 0)
                {
                    co.Comando("SELECT p.ID, e.Nombre, t.Nombre, IFNULL(pro.Nombre,'Sin Proyecto'), p.NumTotalPagos  " +
                               "FROM Empleado AS e " +
                               "INNER JOIN Pago_Empleado_Trabajos AS pet ON(pet.EmpleadoID = e.ID) " +
                               "INNER JOIN PagoProgramado AS p ON(pet.PagoProgramadoID = p.ID) " +
                               "INNER JOIN Trabajos AS t ON(t.ID = pet.TrabajosID) " +
                               "LEFT OUTER JOIN Proyectos AS pro ON(pro.ID = t.ProyectosID) " +
                               "WHERE e.Nombre LIKE '" + empleado.Text + "%' AND p.NumTotalPagos "+simbolo+" 0");
                    int i = 0;
                    while (co.LeerRead)
                    {
                        dataGridView1[0, i].Value = co.Leer.GetInt32(0);
                        dataGridView1[1, i].Value = co.Leer.GetString(1);
                        dataGridView1[2, i].Value = co.Leer.GetString(2);
                        dataGridView1[3, i].Value = co.Leer.GetString(3);
                        dataGridView1[4, i].Value = co.Leer.GetInt32(4);
                        i++;
                    }
                }
                else
                {
                    dataGridView1[0, 0].Value = "";
                    dataGridView1[1, 0].Value = "";
                    dataGridView1[2, 0].Value = "";
                    dataGridView1[3, 0].Value = "";
                    dataGridView1[4, 0].Value = "";
                }
            }
        }

        private void buscar2_Click(object sender, EventArgs e)
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

            if (pags.Checked)
            {

                //Cuento los pagos que sean Pagos a empleados
                int ren = 1;
                co.Comando("SELECT COUNT(*) FROM Pagos WHERE PagoProgramadoID IS NOT NULL AND FechaPago BETWEEN '"+fechaA+"' AND '"+ fechaB+"';");
                if (co.LeerRead)
                    ren = co.Leer.GetInt32(0);
                if (ren > 0)
                    dataGridView2.RowCount = ren;
                else
                {
                    dataGridView2.RowCount = 1;
                    dataGridView2[0, 0].Value = "";
                    dataGridView2[1, 0].Value = "";
                    dataGridView2[2, 0].Value = "";
                    dataGridView2[3, 0].Value = "";
                    dataGridView2[4, 0].Value = "";
                }
                //Muestra los datos completos del pago, trabajo por el que se pago, monto entre otras cosas
                co.Comando("SELECT Distinct  p.ID, e.Nombre, t.Nombre ,p.FechaPago, p.monto " +
                            "FROM Pagos as p INNER JOIN PagoProgramado as PaPr ON(p.PagoProgramadoID = PaPr.ID) " +
                            "INNER JOIN Pago_Empleado_Trabajos as Pet ON(Papr.ID = Pet.PagoProgramadoID)" +
                            "INNER JOIN Empleado_Trabajos as Et ON(Pet.EmpleadoID = Et.EmpleadoID)" +
                            "INNER JOIN Empleado as e ON(Pet.EmpleadoID = e.ID)" +
                            "INNER JOIN Trabajos as t ON(Pet.TrabajosID = t.ID)" +
                            "WHERE p.FechaPago BETWEEN '" + fechaA + "' AND '" + fechaB + "';");

                int k = 0;
                //Coloco los resultados
                while (co.LeerRead)
                {
                    dataGridView2[0, k].Value = co.Leer.GetUInt32(0);
                    dataGridView2[1, k].Value = co.Leer.GetString(1);
                    dataGridView2[2, k].Value = co.Leer.GetString(2);
                    dataGridView2[3, k].Value = co.Leer.GetMySqlDateTime(3);
                    dataGridView2[4, k].Value = co.Leer.GetString(4);
                    k++;
                }
            }
            else
            {
               
                int gastosTotales = 1;
                co.Comando("SELECT COUNT(*) FROM Pagos WHERE GastoID IS NOT NULL AND FechaPago BETWEEN '" + fechaA + "' AND '" + fechaB + "';");
                if (co.LeerRead)
                    gastosTotales = co.Leer.GetInt32(0);
                if (gastosTotales > 0)
                    dataGridView3.RowCount = gastosTotales;
                else
                {
                    dataGridView3.RowCount = 1;
                    dataGridView3[0, 0].Value = "";
                    dataGridView3[1, 0].Value = "";
                    dataGridView3[2, 0].Value = "";
                    dataGridView3[3, 0].Value = "";
                    dataGridView3[4, 0].Value = "";
                }
                co.Comando("SELECT p.ID, g.Concepto, m.Metodo, p.FechaPago, p.Monto " +
                           "FROM Pagos AS p INNER JOIN Metodo AS m ON(m.ID = p.MetodoID) " +
                           "INNER JOIN Gasto AS g ON(g.ID = p.GastoID) " +
                           "WHERE p.GastoID IS NOT NULL AND  FechaPago BETWEEN '" + fechaA + "' AND '" + fechaB + "';");
                int j = 0;
                while (co.LeerRead)
                {
                    dataGridView3[0, j].Value = co.Leer.GetInt32(0);
                    dataGridView3[1, j].Value = co.Leer.GetString(1);
                    dataGridView3[2, j].Value = co.Leer.GetString(2);
                    dataGridView3[3, j].Value = co.Leer.GetMySqlDateTime(3);
                    dataGridView3[4, j].Value = co.Leer.GetInt32(4);
                    j++;

                }
               
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Depende del radioButton que este seleccionado se cambia el simbolo de la busqueda
            string simbolo;
            if (presentes.Checked)
                simbolo = ">";
            else
                simbolo = "=";

            int reng = 1;
            if (!trabajo.Text.Equals(""))
            {

                //Cuento los trabajos que conocinciden con el nombre para darle tamaño al datagridview
                co.Comando("SELECT COUNT(*)  " +
                           "FROM Trabajos AS t " +
                           "INNER JOIN Pago_Empleado_Trabajos AS pet ON(pet.TrabajosID = t.ID) " +
                           "INNER JOIN PagoProgramado AS p ON(pet.PagoProgramadoID = p.ID) " +
                           "WHERE t.Nombre LIKE '" + trabajo.Text + "%' AND p.NumTotalPagos " + simbolo + " 0");
                if (co.LeerRead)
                    reng = co.Leer.GetInt32(0);
                if (reng > 0)
                    dataGridView1.RowCount = reng;
                else
                    dataGridView1.RowCount = 1;
                if (reng > 0)
                {
                    co.Comando("SELECT p.ID, e.Nombre, t.Nombre, IFNULL(pro.Nombre,'Sin Proyecto'), p.NumTotalPagos  " +
                               "FROM Empleado AS e " +
                               "INNER JOIN Pago_Empleado_Trabajos AS pet ON(pet.EmpleadoID = e.ID) " +
                               "INNER JOIN PagoProgramado AS p ON(pet.PagoProgramadoID = p.ID) " +
                               "INNER JOIN Trabajos AS t ON(t.ID = pet.TrabajosID) " +
                               "LEFT OUTER JOIN Proyectos AS pro ON(pro.ID = t.ProyectosID) " +
                               "WHERE t.Nombre LIKE '" + trabajo.Text + "%' AND p.NumTotalPagos " + simbolo + " 0");
                    int i = 0;
                    while (co.LeerRead)
                    {
                        dataGridView1[0, i].Value = co.Leer.GetInt32(0);
                        dataGridView1[1, i].Value = co.Leer.GetString(1);
                        dataGridView1[2, i].Value = co.Leer.GetString(2);
                        dataGridView1[3, i].Value = co.Leer.GetString(3);
                        dataGridView1[4, i].Value = co.Leer.GetInt32(4);
                        i++;
                    }
                }
                else
                {
                    dataGridView1[0, 0].Value = "";
                    dataGridView1[1, 0].Value = "";
                    dataGridView1[2, 0].Value = "";
                    dataGridView1[3, 0].Value = "";
                    dataGridView1[4, 0].Value = "";
                }
            }
        }

        private void pagos_SizeChanged(object sender, EventArgs e)
        {
            label1.Location = new Point(27, label1.Location.Y);
            dataGridView1.Location = new Point(27, dataGridView1.Location.Y);
            dataGridView1.Width = this.Width - 150;

            dataGridView2.Location = new Point(27, dataGridView2.Location.Y);
            dataGridView2.Width = this.Width - 150;

            dataGridView3.Location = new Point(27, dataGridView3.Location.Y);
            dataGridView3.Width = this.Width - 150;
            titulo.Location = new Point(27, titulo.Location.Y);

            groupBox1.Location = new Point(this.Width - 110, groupBox1.Location.Y);
            groupBox2.Location = new Point(this.Width - 110, groupBox2.Location.Y);
            reporte.Location = new Point(this.Width - 90, reporte.Location.Y);
            visualizar.Location = new Point(this.Width - 216, visualizar.Location.Y);
            pagar.Location = new Point(this.Width - 125, pagar.Location.Y);
        }
    }
}
