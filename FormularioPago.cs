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
    public partial class FormularioPago : Form
    {
        Conexion co;
        int IDPP;
        List<int> metodosID;
        List<string> metodosNom;
        int opcion;
        public bool acep = false;
        pagos pa;
        // 0 - Pagar | 2 - Ver un gasto | 1 - Ver un pago hecho
        public FormularioPago(pagos pa,int PagPro,int opcion, Conexion co)
        {
            InitializeComponent();
            Region = Funciones.redondear(Width, Height);

            this.pa = pa;
            this.co = co;
            this.opcion = opcion;
            IDPP = PagPro;


            //Metodos de pago
            metodosID = new List<int>();
            metodosNom = new List<string>();
            co.Comando("SELECT ID FROM Metodo;");
            while (co.LeerRead)
                metodosID.Add(co.Leer.GetInt32(0));
            for (int i = 0; i < metodosID.Count; i++)
            {
                co.Comando("SELECT Metodo FROM Metodo WHERE ID = " + metodosID[i] + ";");
                if (co.LeerRead)
                    metodosNom.Add(co.Leer.GetString(0));
            }
            metodoPago.DataSource = metodosNom;

            this.StartPosition = FormStartPosition.CenterScreen;
            //Pago nuevo
            if (opcion == 0)
            {
                //TextsEdit
                PagoGasto.Enabled = true;
                empleado.Enabled = false;
                trabajo.Enabled = false;
                textConcepto.Enabled = true;
                metodoPago.Enabled = true;
                monto.Enabled = true;
                //Labels
                pagosrestantes.Visible = true;
                //Botones
                cerrar.Visible = true;
                eliminar.Visible = false;
                editar.Visible = false;
                guardar.Visible = false;
                aceptar.Visible = true;
               
                //PagoProgrado
                PagoGasto.SelectedIndex = 0;


            }
            //Visualizar pago
            else if(opcion == 1)
            {

                //TextsEdit
                PagoGasto.Enabled = false;
                empleado.Enabled = false;
                trabajo.Enabled = false;
                textConcepto.Enabled = false;
                metodoPago.Enabled = false;
                monto.Enabled = false;
                //Labels
                pagosrestantes.Visible = false;
                //Botones
                cerrar.Visible = true;
                eliminar.Visible = true;
                editar.Visible = true;
                guardar.Visible = false;
                aceptar.Visible = false;

                pago();
                

            }
            //Visuallizar gasto
            else if(opcion == 2)
            {
                int metID = 0;
                PagoGasto.SelectedIndex = 1;
                co.Comando("SELECT p.monto, p.MetodoID, g.Concepto FROM Pagos as p INNER JOIN Gasto as g on(g.ID = p.GastoID);");
                if (co.LeerRead)
                {
                    monto.Text = co.Leer.GetInt32(0).ToString();
                    metID = co.Leer.GetInt32(1);
                    textConcepto.Text = co.Leer.GetString(2);
                }
                int i = 0;
                while (i < metodosID.Count)
                {
                    if (metodosID[i] == metID)
                        metodoPago.SelectedIndex = i;
                    i++;
                }


                //TextsEdit
                PagoGasto.Enabled = false;
                empleado.Enabled = false;
                trabajo.Enabled = false;
                textConcepto.Enabled = false;
                metodoPago.Enabled = false;
                monto.Enabled = false;
                //Labels
                pagosrestantes.Visible = false;
                //Botones
                cerrar.Visible = true;
                eliminar.Visible = true;
                editar.Visible = true;
                guardar.Visible = false;
                aceptar.Visible = false;

            }
            

        }
        //Valido los datos del formulario para que no sean nulos
        private bool Validacion()
        {
            if (PagoGasto.SelectedIndex == 0)
            {
                if (monto.Text.Equals(""))
                {
                    MessageBox mens = new MessageBox("Complete el formulario", 2);
                    mens.ShowDialog();
                    return false;
                }
            }
            if (PagoGasto.SelectedIndex == 1)
            {
                if (monto.Text.Equals("") || textConcepto.Text.Equals(""))
                {
                    MessageBox mens = new MessageBox("Complete el formulario", 2);
                    mens.ShowDialog();
                    return false;
                }
            }
           
            return true;
        }

        public void actualizar()
        {
            pa.datosPagosProgra();
            pa.datosPagosGastos();
        }
        public void pago()
        {
            int ID = 0;
            if(opcion == 1)
            {
                
                //Selecciono el pago programado del pago seleccionado
                co.Comando("SELECT PagoProgramadoID FROM Pagos WHERE ID = " + IDPP + ";");
                if (co.LeerRead)
                    ID = co.Leer.GetInt32(0);
                //Selecciono el monto
                co.Comando("SELECT Monto FROM Pagos WHERE ID = "+IDPP+";");
                if (co.LeerRead)
                    monto.Text = co.Leer.GetString(0);

                //Coloco que es pago y no gasto
                PagoGasto.SelectedIndex = 0;
                int metodoID = 0;

                //Selecciono el metodo de pago seleccionado
                co.Comando("SELECT MetodoID FROM Pagos WHERE ID = " + IDPP + ";");
                if (co.LeerRead)
                    metodoID = co.Leer.GetInt32(0);
                int i = 0;
                while (i < metodosID.Count)
                {
                    if (metodosID[i] == metodoID)
                        metodoPago.SelectedIndex = i;
                    i++;
                }
                

            }
            else
            {
                ID = IDPP;
            }

            if (opcion == 0)
            {
                //Coloco los pagos restantes del empleado
                co.Comando("SELECT NumTotalPagos FROM PagoProgramado WHERE ID = " + ID + ";");
                if (co.LeerRead)
                    pagosrestantes.Text = "Pagos restantes: " + co.Leer.GetString(0);
            }
            //Coloco el nombre del empleado asociado al pagoProgramado
            co.Comando("SELECT e.Nombre FROM Empleado as e INNER JOIN Pago_Empleado_Trabajos AS pet " +
                      "ON(e.ID = pet.EmpleadoID AND pet.PagoProgramadoID = " + ID+ ");");
            if (co.LeerRead)
                empleado.Text = co.Leer.GetString(0);

            //Coloco el trabajo por el que se le esta pagando
            co.Comando("SELECT t.Nombre FROM Trabajos as t INNER JOIN Pago_Empleado_Trabajos AS pet " +
                       "ON(t.ID = pet.TrabajosID AND pet.PagoProgramadoID = " + ID + ");");
            if (co.LeerRead)
                trabajo.Text = co.Leer.GetString(0);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (opcion == 0)
            {

                if (PagoGasto.SelectedIndex == 1)
                {

                    //TextsEdit
                    PagoGasto.Enabled = true;
                    empleado.Enabled = false;
                    trabajo.Enabled = false;
                    textConcepto.Enabled = true;
                    metodoPago.Enabled = true;
                    monto.Enabled = true;
                    //Labels
                    pagosrestantes.Visible = false;
                    //Botones
                    cerrar.Visible = true;
                    eliminar.Visible = false;
                    editar.Visible = false;
                    guardar.Visible = false;
                    aceptar.Visible = true;


                    trabajo.Text = "";
                    empleado.Text = "";
                    pagosrestantes.Text = "";

                }
                else
                {

                    //TextsEdit
                    PagoGasto.Enabled = true;
                    empleado.Enabled = false;
                    trabajo.Enabled = false;
                    textConcepto.Enabled = false;
                    metodoPago.Enabled = true;
                    monto.Enabled = true;
                    //Labels
                    pagosrestantes.Visible = true;
                    //Botones
                    cerrar.Visible = true;
                    eliminar.Visible = false;
                    editar.Visible = false;
                    guardar.Visible = false;
                    aceptar.Visible = true;

                    pago();

                }
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                try
                {
                    //Quiere decir que se va a realizar un pago a un PagoProgramado
                    if (PagoGasto.SelectedIndex == 0)
                    {
                        int numPago = 0;
                        //Cuento los pagos asociados al PagoProgramado para saber que numero de pago es
                        co.Comando("SELECT COUNT(*) FROM Pagos WHERE PagoProgramadoID = " + IDPP + ";");
                        if (co.LeerRead)
                            numPago = co.Leer.GetInt32(0) + 1;
                        //Inserto los datos en Pagos
                        // co.Comando("INSERT INTO Pagos (numPago, Monto, PagoProgramadoID, MetodoID, FechaPago) VALUES (" + numPago + "," + Convert.ToInt32(monto.Text)
                        //           + "," + IDPP + "," + metodosID[metodoPago.SelectedIndex] + ",CURDATE());");
                        co.Comando("INSERT INTO Pagos (numPago, Monto, PagoProgramadoID, MetodoID, FechaPago, ses_id) VALUES (" + numPago + "," + Convert.ToInt32(monto.Text)
                                   + "," + IDPP + "," + metodosID[metodoPago.SelectedIndex] + ",CURDATE(), "+co.sesion+");");

                        //Actualizo el numero total de pagos del PagroProgramado
                        // co.Comando("UPDATE PagoProgramado SET NumTotalPagos = NumTotalPagos-1 WHERE ID = " + IDPP + ";");
                        co.Comando("UPDATE PagoProgramado SET NumTotalPagos = NumTotalPagos-1, ses_id = "+co.sesion+" WHERE ID = " + IDPP + ";");


                        MessageBox mens = new MessageBox("Guardado con éxito", 2);
                        mens.ShowDialog();

                        //Actualizo los datos de la tabla
                        actualizar();

                    }
                    //Quiere decir que se va a realizar un gasto
                    else
                    {
                        int ultiGasto = 0;
                        //Inserto los datos en gastos
                        //co.Comando("Insert into Gasto(Concepto) Values ('" + textConcepto.Text + "'); ");
                        co.Comando("Insert into Gasto(Concepto, ses_id) Values ('" + textConcepto.Text + "', "+co.sesion+"); ");

                        //Selecciono el gasto que se inserto osea el del ID mayor
                        co.Comando("SELECT MAX(ID) FROM Gasto;");
                        if (co.LeerRead)
                            ultiGasto = co.Leer.GetInt32(0);

                        //Se crea el pago asociado a ese gasto
                        //co.Comando("INSERT INTO Pagos(numPago, Monto, GastoID, MetodoID, FechaPago) VALUES(1," + Convert.ToInt32(monto.Text)
                        //          + "," + ultiGasto + "," + metodosID[metodoPago.SelectedIndex] + ",CURDATE());");
                        co.Comando("INSERT INTO Pagos(numPago, Monto, GastoID, MetodoID, FechaPago, ses_id) VALUES(1," + Convert.ToInt32(monto.Text)
                                   + "," + ultiGasto + "," + metodosID[metodoPago.SelectedIndex] + ",CURDATE(), "+co.sesion+");");

                        MessageBox mens = new MessageBox("Guardado con éxito", 2);
                        mens.ShowDialog();

                        //Actualizo los datos de la tabla
                        actualizar();
                    }
                }
                catch (Exception ed)
                {
                    MessageBox mens = new MessageBox("Error", 3);
                    mens.ShowDialog();
                }

                this.Close();
            }
        }

        private void eiminar_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                try
                {
                    MessageBox confirmacion = new MessageBox("¿Seguro que desea eliminar el pago?", 1);
                    confirmacion.ShowDialog();
                    if (acep)
                    {
                        int ID = 0;
                        if (opcion == 1)
                        {

                            //Selecciono el pago programado al que pertence para poder agregar que falta un pago mas
                            co.Comando("SELECT PagoProgramadoID FROM Pagos WHERE ID = " + IDPP + ";");
                            if (co.LeerRead)
                                ID = co.Leer.GetInt32(0);
                            //Elimino el pago
                            co.Comando("CALL delete_Pagos(" + IDPP + ");");
                            //Actualizo el numero total de pagos al que pertence el pago
                            //co.Comando("UPDATE PagoProgramado SET NumTotalPagos = NumTotalPagos + 1 WHERE ID = " + ID + ";");
                            co.Comando("UPDATE PagoProgramado SET NumTotalPagos = NumTotalPagos + 1, ses_id = "+co.sesion+" WHERE ID = " + ID + ";");
                        }
                        else if (opcion == 2)
                        {
                            //Selecciono el gastoID al que pertenece el Pago
                            co.Comando("SELECT GastoID FROM Pagos WHERE ID = " + IDPP + ";");
                            if (co.LeerRead)
                                ID = co.Leer.GetInt32(0);
                            //Elimino el Pago
                            co.Comando("CALL delete_Pagos(" + IDPP + ");");
                            //Agregar UN ON DELETE CASCADE
                            //Elimino el gasto
                            co.Comando("DELETE FROM Gasto WHERE ID = " + ID + ";");
                        }
                        //Actualizo los datos de la tabla
                        actualizar();

                        MessageBox mens = new MessageBox("Eliminado", 2);
                        mens.ShowDialog();
                        this.Close();
                    }


                }
                catch (Exception ef)
                {
                    MessageBox mens = new MessageBox("Error", 3);
                    mens.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 3);
                mens.ShowDialog();
            }
        }

        private void editar_Click(object sender, EventArgs e)
        {
            if (co.permiso.Equals(co.administrador))
            {
                //TextsEdit
                if (opcion == 1)
                {
                    PagoGasto.Enabled = false;
                    empleado.Enabled = false;
                    trabajo.Enabled = false;
                    textConcepto.Enabled = false;
                    metodoPago.Enabled = true;
                    monto.Enabled = true;
                    //Labels
                    pagosrestantes.Visible = false;
                    //Botones
                    cerrar.Visible = true;
                    eliminar.Visible = true;
                    editar.Visible = false;
                    guardar.Visible = true;
                    aceptar.Visible = false;
                }
                else if (opcion == 2)
                {
                    PagoGasto.Enabled = false;
                    empleado.Enabled = false;
                    trabajo.Enabled = false;
                    textConcepto.Enabled = true;
                    metodoPago.Enabled = true;
                    monto.Enabled = true;
                    //Labels
                    pagosrestantes.Visible = false;
                    //Botones
                    cerrar.Visible = true;
                    eliminar.Visible = true;
                    editar.Visible = false;
                    guardar.Visible = true;
                    aceptar.Visible = true;
                }
            }
            else
            {
                AppProyectoBD.MessageBox mens = new AppProyectoBD.MessageBox("No cuenta con los permisos para realizar esta acción", 3);
                mens.ShowDialog();
            }

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                if (opcion == 1)
                {
                    //Actualizo la info en Pagos
                    co.Comando("CALL update_PagosMonto(" + Convert.ToInt32(monto.Text) + "," + metodosID[metodoPago.SelectedIndex] + "," + IDPP + ");");
                }
                else if (opcion == 2)
                {
                    int IDGasto = 0;
                    //Actualizo la info en Gastos
                    co.Comando("CALL update_PagosMonto(" + Convert.ToInt32(monto.Text) + "," + metodosID[metodoPago.SelectedIndex] + "," + IDPP + ");");
                    //Consulto el GasoID para saber a que gasto pertenece 
                    co.Comando("SELECT GastoID FROM Pagos WHERE ID = " + IDPP + ";");
                    if (co.LeerRead)
                        IDGasto = co.Leer.GetInt32(0);
                    //Modifico el Concepto del gasto asignado
                    //co.Comando("UPDATE Gasto SET Concepto = '" + textConcepto.Text + "' WHERE ID = " + IDPP + ";");
                    co.Comando("UPDATE Gasto SET Concepto = '" + textConcepto.Text + "', ses_id = "+co.sesion+" WHERE ID = " + IDPP + ";");
                }
                MessageBox mens = new MessageBox("Guardado con exito", 2);
                mens.ShowDialog();

                PagoGasto.Enabled = false;
                empleado.Enabled = false;
                trabajo.Enabled = false;
                textConcepto.Enabled = false;
                metodoPago.Enabled = false;
                monto.Enabled = false;
                //Labels
                pagosrestantes.Visible = false;
                //Botones
                cerrar.Visible = true;
                eliminar.Visible = true;
                editar.Visible = false;
                guardar.Visible = false;
                aceptar.Visible = false;
            }
        }

        private void FormularioPago_FormClosed(object sender, FormClosedEventArgs e)
        {
            pagos frm = Application.OpenForms.OfType<pagos>().FirstOrDefault();

            if (frm != null)  //Si encuentra una instancia abierta
            {
                frm.datosPagosProgra();
                frm.datosPagosGastos();
                this.Close();
            }
        }

        private void FormularioPago_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Funciones.ReleaseCapture();
            Funciones.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel7_MouseDown_1(object sender, MouseEventArgs e)
        {
        }

        private void monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //EL CODIGO POSTAL TIENE QUE SER NUMERICO, ASI QUE SE LIMITA CON CODIGO
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
    }
}
