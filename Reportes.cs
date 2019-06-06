using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace AppProyectoBD
{
    public partial class Reportes : Form
    {
        Conexion co;
        List<bool> PPP; // Pagos programados pendientes
        List<bool> PPC; // Pagos programados completados
        List<bool> PR; // Pagos realizados
        List<bool> GR; // Gastos realizados
        List<int> indices;
        String fechaA, fechaB;
        int renglones, columnas;

        public Reportes(Conexion co)
        {
            InitializeComponent();
            this.co = co;
            this.StartPosition = FormStartPosition.CenterScreen;
            Region = Funciones.redondear(Width, Height);


            indices = new List<int>();

            // Es necesario?
            PPP = new List<bool>();
            PPP.Add(false);
            PPP.Add(false);
            PPP.Add(false);
            PPP.Add(false);
            PPP.Add(false);

            PPC = new List<bool>();
            PPC.Add(false);
            PPC.Add(false);
            PPC.Add(false);
            PPC.Add(false);

            PR = new List<bool>();
            PR.Add(false);
            PR.Add(false);
            PR.Add(false);
            PR.Add(false);
            PR.Add(false);
            PR.Add(false);

            GR = new List<bool>();
            GR.Add(false);
            GR.Add(false);
            GR.Add(false);
            GR.Add(false);
            GR.Add(false);
            GR.Add(false);

            fechaA = "";
            fechaB = "";
        }

        private void crearDocumento()
        {
            
            renglones = 1;
            columnas = 1;
            try
            {
                // Se crea una variable string donde se almacenará la ruta y nombre del archivo
                // Poner el saveDialog
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Title = "Guardar archivo";
                guardar.Filter = "Documento de word|*.docx";
                guardar.ShowDialog();
                // ---------------------------------------------------------------
                string nombreArchivo = guardar.FileName;
                string nombreProvisional = nombreArchivo;
                string [] arregloProvisional = nombreProvisional.Split(System.IO.Path.DirectorySeparatorChar);
                arregloProvisional[arregloProvisional.Length - 1] = arregloProvisional[arregloProvisional.Length - 1].Replace(" ", "_");
                nombreArchivo = "";
                for (int i = 0; i < arregloProvisional.Length; i++)
                    nombreArchivo = nombreArchivo + arregloProvisional[i] + (i == arregloProvisional.Length - 1 ? "" : System.IO.Path.DirectorySeparatorChar.ToString());
                // ---------------------------------------------------------------
                var doc = DocX.Create(nombreArchivo);

                // Se crea el formato para los títulos
                Formatting formatoTitulo = new Formatting();
                // Se especifica la fuente, tamaño, color, etc;
                formatoTitulo.FontFamily = new Xceed.Words.NET.Font("Gothic A1");
                formatoTitulo.Size = 18;
                formatoTitulo.Position = 0;
                formatoTitulo.Bold = true;

                // Se crea el formato para el texto de los títulos de las columnas 
                Formatting formatoTituloColumna = new Formatting();
                // Se especifican las características de la fuente
                formatoTituloColumna.FontFamily = new Xceed.Words.NET.Font("Gothic A1");
                formatoTituloColumna.Size = 16;
                formatoTituloColumna.Bold = true;

                // Se crea el formato para el texto dentro de las columnas 
                Formatting formatoTexto = new Formatting();
                // Se especifican las características de la fuente
                formatoTexto.FontFamily = new Xceed.Words.NET.Font("Gothic A1");
                formatoTexto.Size = 10;
                formatoTexto.Spacing = 2;

                // Apartado para el título e imagen
                string imgPath = "C:\\Imagenes\\ImagenPiedra.PNG";
                var pic = doc.AddImage(imgPath).CreatePicture();

                var drawingImg = System.Drawing.Image.FromFile(imgPath);
                int ratio = drawingImg.Width / drawingImg.Height;
                int newWidth = (int)doc.PageWidth - (int)(doc.MarginLeft + doc.MarginRight)-300;
                pic.Width = newWidth;
                pic.Height = newWidth / ratio;

                Paragraph titulo = doc.InsertParagraph("REPORTE                                                          ", false, formatoTitulo);
                titulo.AppendPicture(pic);

                // Si hay al menos un true en PPP entonces se ejecuta el método para Pagos Programados Pendientes
                if (PPP.Contains(true))
                {
                    procesoPPP(doc, formatoTituloColumna);
                }

                // Solamente se corre este método si hay al menos un true en el arreglo de pagos programados completados
                if (PPC.Contains(true))
                {
                    procesoPPC(doc, formatoTituloColumna);
                }

                // Misma lógica que con los anteriores
                if (PR.Contains(true))
                {
                    procesoPR(doc, formatoTituloColumna);
                }

                // Misma lógica que con los anteriores
                if (GR.Contains(true))
                {
                    procesoGR(doc, formatoTituloColumna, nombreArchivo);
                }

                // No guarda o abre el documento
                doc.Save();
                Process.Start("WINWORD.EXE", nombreArchivo);
                
            }
            catch(Exception ex) {
                // Agregar mensaje de error -----------------------------------------------------------------------------
                Console.WriteLine(ex);
            }

            
        }

        private void procesoPPP(DocX doc, Formatting formatoTituloColumna)
        {
            
            indices.Clear();
            renglones = 1;
            columnas = 1;

            // Se recorre el arreglo para saber agregar los indices que indicarán qué valores 
            // serán mostrados en la tabla, el tamaño del arreglo serán las columnas
            for (int ind = 0; ind < PPP.Count; ind++)
                if (PPP[ind])
                    indices.Add(ind);
            columnas = indices.Count;

            // Primero que nada se consulta el número de pagos pendientes para los renglones
            co.Comando("SELECT COUNT(*) FROM PagoProgramado WHERE NumTotalPagos > 0;");
            if (co.LeerRead)
                renglones = co.Leer.GetInt32(0);

            if (renglones != 0)
            {
                doc.InsertParagraph("Pagos programados pendientes", false, formatoTituloColumna);
            }
            else
            {
                doc.InsertParagraph("No hay pagos programados pendientes", false, formatoTituloColumna);
                return;
            }

            Table t = doc.AddTable(renglones + 1, columnas);
            t.Alignment = Alignment.left;
            t.Design = TableDesign.LightGridAccent3;

            // Columna por columna se le agrega el título que es obtenido de la siguiente manera:
            // El contador "col" va de 0 hasta el tamaño del arreglo de indices
            // Se recorren los índices para mandarlo al metodo de los nombres y así obtener
            //    de qué columna se trata
            for (int col = 0; col < indices.Count; col++)
                t.Rows[0].Cells[col].Paragraphs.First().Append(columnasPPP(indices[col]));

            co.Comando("SELECT p.ID, e.Nombre, t.Nombre, IFNULL(pro.Nombre,'Sin Proyecto'), p.NumTotalPagos  " +
                   "FROM Empleado AS e " +
                   "INNER JOIN Pago_Empleado_Trabajos AS pet ON(pet.EmpleadoID = e.ID) " +
                   "INNER JOIN PagoProgramado AS p ON(pet.PagoProgramadoID = p.ID) " +
                   "INNER JOIN Trabajos AS t ON(t.ID = pet.TrabajosID) " +
                   "LEFT OUTER JOIN Proyectos AS pro ON(pro.ID = t.ProyectosID) " +
                   "WHERE p.NumTotalPagos > 0");

            int i = 0;
            while (co.LeerRead)
            {
                for (int col = 0; col < columnas; col++)
                {
                    t.Rows[i + 1].Cells[col].Paragraphs.First().Append(valoresPPP(indices[col]));
                }
                i++;
            }
            doc.InsertTable(t);
            doc.InsertParagraph("\n");
        }

        private void procesoPPC(DocX doc, Formatting formatoTituloColumna)
        {
            
            indices.Clear();
            renglones = 1;
            columnas = 1;

            // Se recorre el arreglo para saber agregar los indices que indicarán qué valores 
            // serán mostrados en la tabla, el tamaño del arreglo serán las columnas
            for (int ind = 0; ind < PPC.Count; ind++)
                if (PPC[ind])
                    indices.Add(ind);
            columnas = indices.Count;

            // Primero que nada se consulta el número de pagos completados para los renglones
            co.Comando("SELECT COUNT(*) FROM PagoProgramado WHERE NumTotalPagos = 0;");
            if (co.LeerRead)
                renglones = co.Leer.GetInt32(0);

            if (renglones != 0)
            {
                doc.InsertParagraph("Pagos programados completados", false, formatoTituloColumna);
            }
            else
            {
                doc.InsertParagraph("No hay pagos programados completados", false, formatoTituloColumna);
                return;
            }

            Table t = doc.AddTable(renglones + 1, columnas);
            t.Alignment = Alignment.left;
            t.Design = TableDesign.LightGridAccent3;

            // Columna por columna se le agrega el título que es obtenido de la siguiente manera:
            // El contador "col" va de 0 hasta el tamaño del arreglo de indices
            // Se recorren los índices para mandarlo al metodo de los nombres y así obtener
            //    de qué columna se trata
            for (int col = 0; col < indices.Count; col++)
                t.Rows[0].Cells[col].Paragraphs.First().Append(columnasPPC(indices[col]));

            co.Comando("SELECT p.ID, e.Nombre, t.Nombre, IFNULL(pro.Nombre,'Sin Proyecto'), p.NumTotalPagos  " +
                   "FROM Empleado AS e " +
                   "INNER JOIN Pago_Empleado_Trabajos AS pet ON(pet.EmpleadoID = e.ID) " +
                   "INNER JOIN PagoProgramado AS p ON(pet.PagoProgramadoID = p.ID) " +
                   "INNER JOIN Trabajos AS t ON(t.ID = pet.TrabajosID) " +
                   "LEFT OUTER JOIN Proyectos AS pro ON(pro.ID = t.ProyectosID) " +
                   "WHERE p.NumTotalPagos = 0");

            int i = 0;
            while (co.LeerRead)
            {
                for (int col = 0; col < columnas; col++)
                {
                    t.Rows[i + 1].Cells[col].Paragraphs.First().Append(valoresPPC(indices[col]));
                }
                i++;
            }
            doc.InsertTable(t);
            doc.InsertParagraph("\n");
        }

        private void procesoPR(DocX doc, Formatting formatoTituloColumna)
        {
            bool band = true;
            
            indices.Clear();
            renglones = 1;
            columnas = 1;

            // Se recorre el arreglo para saber agregar los indices que indicarán qué valores 
            // serán mostrados en la tabla, el tamaño del arreglo serán las columnas
            for (int ind = 0; ind < PR.Count; ind++)
                if (PR[ind])
                    indices.Add(ind);
            columnas = indices.Count;

            // Se obtienen el total de pagos realizados y se almacena en renglones
            // -------------------------------------------------------------------------------
            co.Comando("SELECT COUNT(*) FROM Pagos WHERE PagoProgramadoID IS NOT NULL AND FechaPago BETWEEN '" + fechaA + "' AND '" + fechaB + "';");
            if (co.LeerRead)
                renglones = co.Leer.GetInt32(0);

            if (renglones != 0)
            {
                doc.InsertParagraph("Pagos realizados", false, formatoTituloColumna);
            }
            else
            {
                doc.InsertParagraph("No hay pagos realizados", false, formatoTituloColumna);
                return;
            }

            // En caso de que se pida el total, entonces se agrega un renglón donde se mostrará el total
            if (indices.Contains(5))
            {
                columnas--;
                renglones++;
                if (columnas <= 1)
                    columnas = 2;
            }

            // Primera parte para la generación de tabla solamente con totales
            if (indices.Count == 1 && indices[0] == 5)
            {
                columnas = 2;
                renglones = 0;
            }

            Table t = doc.AddTable(renglones + 1, columnas);
            t.Alignment = Alignment.left;
            t.Design = TableDesign.LightGridAccent3;

            // Segunda parte para la generación de tabla solamente con totales
            if (indices.Count == 1 && indices[0] == 5)
            {
                columnas = 2;
                renglones = 1;
                t.Rows[t.RowCount - 1].Cells[columnas - 2].Paragraphs.First().Append("Total");
                t.Rows[t.RowCount - 1].Cells[columnas - 1].Paragraphs.First().Append("$ " + totalPR());
                band = false;
            }

            if (band)
            {
                // Columna por columna se le agrega el título que es obtenido de la siguiente manera:
                // El contador "col" va de 0 hasta el tamaño del arreglo de indices
                // Se recorren los índices para mandarlo al método de los nombres y así obtener
                //    de qué columna se trata
                for (int col = 0; col < columnas; col++)
                    if (indices[col] != 5)
                        t.Rows[0].Cells[col].Paragraphs.First().Append(columnasPR(indices[col]));

                //De los pagos realizados se obtien el ID, nombre del empleado y trabajo, fecha de pago
                co.Comando("SELECT Distinct  p.ID, e.Nombre, t.Nombre ,concat(DAY(p.FechaPago), '/', MONTH(p.FechaPago), '/', YEAR(p.FechaPago)), p.monto " +
                            "FROM Pagos as p INNER JOIN PagoProgramado as PaPr ON(p.PagoProgramadoID = PaPr.ID) " +
                            "INNER JOIN Pago_Empleado_Trabajos as Pet ON(Papr.ID = Pet.PagoProgramadoID)" +
                            "INNER JOIN Empleado_Trabajos as Et ON(Pet.EmpleadoID = Et.EmpleadoID)" +
                            "INNER JOIN Empleado as e ON(Pet.EmpleadoID = e.ID)" +
                            "INNER JOIN Trabajos as t ON(Pet.TrabajosID = t.ID)" +
                            "WHERE p.FechaPago BETWEEN '" + fechaA + "' AND '" + fechaB + "' ;");

                int i = 0;
                while (co.LeerRead)
                {
                    for (int col = 0; col < columnas; col++)
                    {
                        if (indices[col] != 5)
                            t.Rows[i + 1].Cells[col].Paragraphs.First().Append(valoresPR(indices[col]));
                    }
                    i++;
                }
                if (indices.Contains(5))
                {
                    t.Rows[t.RowCount - 1].Cells[columnas - 2].Paragraphs.First().Append("Total");
                    t.Rows[t.RowCount - 1].Cells[columnas - 1].Paragraphs.First().Append("$ " + totalPR());
                }
            }
            doc.InsertTable(t);
            doc.InsertParagraph("\n");
        }

        private void procesoGR(DocX doc, Formatting formatoTituloColumna, String nombreArchivo)
        {
            
            indices.Clear();
            renglones = 1;
            columnas = 1;

            // Se recorre el arreglo para saber agregar los indices que indicarán qué valores 
            // serán mostrados en la tabla, el tamaño del arreglo serán las columnas
            for (int ind = 0; ind < GR.Count; ind++)
                if (GR[ind])
                    indices.Add(ind);
            columnas = indices.Count;

            // Se obtienen el total de gastos realizados y se almacena en renglones
            co.Comando("SELECT renglonesGR('"+fechaA+"', '"+fechaB+"');");
            if (co.LeerRead)
                renglones = co.Leer.GetInt32(0);

            if (renglones != 0)
            {
                doc.InsertParagraph("Gastos realizados", false, formatoTituloColumna);
            }
            else
            {
                doc.InsertParagraph("No hay gastos realizados", false, formatoTituloColumna);
                return;
            }

            // En caso de que se pida el total, entonces se agrega un renglón donde se mostrará el total
            if (indices.Contains(5))
            {
                columnas--;
                renglones++;
                if (columnas <= 1)
                    columnas = 2;
            }

            // Primera parte para la generación de tabla solamente con totales
            if (indices.Count == 1 && indices[0] == 5)
            {
                columnas = 2;
                renglones = 0;
            }

            Table t = doc.AddTable(renglones + 1, columnas);
            t.Alignment = Alignment.left;
            t.Design = TableDesign.LightGridAccent3;

            // Segunda parte para la generación de tabla solamente con totales
            if (indices.Count == 1 && indices[0] == 5)
            {
                columnas = 2;
                renglones = 1;
                t.Rows[t.RowCount - 1].Cells[columnas - 2].Paragraphs.First().Append("Total");
                t.Rows[t.RowCount - 1].Cells[columnas - 1].Paragraphs.First().Append("$ " + totalGR());
                doc.InsertTable(t);
                doc.InsertParagraph("\n");
                doc.Save();
                Process.Start("WINWORD.EXE", nombreArchivo);
                return;
            }

            // Columna por columna se le agrega el título que es obtenido de la siguiente manera:
            // El contador "col" va de 0 hasta el tamaño del arreglo de indices
            // Se recorren los índices para mandarlo al metodo de los nombres y así obtener
            //    de qué columna se trata
            for (int col = 0; col < columnas; col++)
                if (indices[col] != 5)
                    t.Rows[0].Cells[col].Paragraphs.First().Append(columnasGR(indices[col]));

            //Saco los datos de cada gasto y los coloco en la tabla
            co.Comando("SELECT p.ID, g.Concepto, m.Metodo, concat(DAY(p.FechaPago), '/', MONTH(p.FechaPago), '/', YEAR(p.FechaPago)), p.Monto " +
                                       "FROM Pagos AS p INNER JOIN Metodo AS m ON(m.ID = p.MetodoID) " +
                                       "INNER JOIN Gasto AS g ON(g.ID = p.GastoID) " +
                                       "WHERE p.GastoID IS NOT NULL " +
                                       "AND p.FechaPago BETWEEN '" + fechaA + "' AND '" + fechaB + "' ;");
            int i = 0;
            while (co.LeerRead)
            {
                for (int col = 0; col < columnas; col++)
                {
                    if (indices[col] != 5)
                        t.Rows[i + 1].Cells[col].Paragraphs.First().Append(valoresGR(indices[col]));
                }
                i++;
            }
            if (indices.Contains(5))
            {
                t.Rows[t.RowCount - 1].Cells[columnas - 2].Paragraphs.First().Append("Total");
                t.Rows[t.RowCount - 1].Cells[columnas - 1].Paragraphs.First().Append("$ " + totalGR());
            }
            doc.InsertTable(t);
            doc.InsertParagraph("\n");
        }

        // En este método se introducen todos los true y false de los checkBox en los arreglos correspondientes
        private int arreglos()
        {
            int c = 0;
            PPP[0] = checkBox7.Checked;
            PPP[1] = checkBox1.Checked;
            PPP[2] = checkBox2.Checked;
            PPP[3] = checkBox3.Checked;
            PPP[4] = checkBox4.Checked;

            PPC[0] = checkBox8.Checked;
            PPC[1] = checkBox16.Checked;
            PPC[2] = checkBox15.Checked;
            PPC[3] = checkBox14.Checked;

            PR[0] = checkBox9.Checked;
            PR[1] = checkBox19.Checked;
            PR[2] = checkBox18.Checked;
            PR[3] = checkBox17.Checked;
            PR[4] = checkBox13.Checked;
            PR[5] = checkBox5.Checked;

            GR[0] = checkBox10.Checked;
            GR[1] = checkBox27.Checked;
            GR[2] = checkBox26.Checked;
            GR[3] = checkBox25.Checked;
            GR[4] = checkBox24.Checked;
            GR[5] = checkBox6.Checked;

            // Validación para saber si al menos un checkBox fue activado
            foreach (bool check in PPP)
                if (check == false)
                    c++;
            foreach (bool check in PPC)
                if (check == false)
                    c++;
            foreach (bool check in PR)
                if (check == false)
                    c++;
            foreach (bool check in GR)
                if (check == false)
                    c++;

            if (c == (PPP.Count + PPC.Count + GR.Count + PR.Count))
                return 0;
            else
                return 1;

        }

        // Checar las fechas en mi compu y en la de alguien más --------------------------------------------------------
        private void fechas()
        {
            fechaA = fecha1.Value.Date.ToString("yyyy-MM-dd");
            fechaB = fecha2.Value.Date.ToString("yyyy-MM-dd");
        }

        // En estos métodos se encuentran los títulos de las tablas de las 4 opciones
        private String columnasPPP(int col)
        {
            String nombre = "";

            switch (col)
            {
                case 0: nombre = "ID";
                    break;
                case 1: nombre = "Empleado";
                    break;
                case 2: nombre = "Trabajo";
                    break;
                case 3: nombre = "Proyecto";
                    break;
                case 4: nombre = "Pagos faltantes";
                    break;
                default: nombre = "";
                    break;
            }
            return nombre;
        }

        private String columnasPPC(int col)
        {
            String nombre = "";

            switch (col)
            {
                case 0: nombre = "ID";
                    break;
                case 1: nombre = "Empleado";
                    break;
                case 2: nombre = "Trabajo";
                    break;
                case 3: nombre = "Proyecto";
                    break;
                default: nombre = "";
                    break;
            }
            return nombre;
        }

        private String columnasPR(int col)
        {
            String nombre = "";

            switch (col)
            {
                case 0: nombre = "ID";
                    break;
                case 1: nombre = "Empleado";
                    break;
                case 2: nombre = "Trabajo";
                    break;
                case 3: nombre = "Fecha de pago";
                    break;
                case 4: nombre = "Monto";
                    break;
                default: nombre = "";
                    break;
            }
            return nombre;
        }

        private String columnasGR(int col)
        {
            String nombre = "";

            switch (col)
            {
                case 0: nombre = "ID";
                    break;
                case 1: nombre = "Concepto";
                    break;
                case 2: nombre = "Método";
                    break;
                case 3: nombre = "Fecha de pago";
                    break;
                case 4: nombre = "Monto";
                    break;
                case 5: nombre = "Total";
                    break;
                default: nombre = "";
                    break;
            }
            return nombre;
        }

        // En estos métodos se elige la sintaxis para la consulta
        private String valoresPPP(int col)
        {
            String valor = "";

            switch (col)
            {
                case 1: case 2: case 3:
                    valor = co.Leer.GetString(col);
                    break;
                default:
                    valor = co.Leer.GetInt32(col) + "";
                    break;
            }
            
            return valor;
        }

        private String valoresPPC(int col)
        {
            String valor = "";

            switch (col)
            {
                case 0: valor = co.Leer.GetInt32(col)+"";
                    break;
                default: valor = co.Leer.GetString(col);
                    break;
            }
            return valor;
        }

        private String valoresPR(int col)
        {
            String valor = "";
            
            switch (col)
            {
                case 0: case 4:
                    valor = co.Leer.GetInt32(col) + "";
                    break;
                default:
                    valor = co.Leer.GetString(col);
                    break;
            }
            return valor;
        }

        private String valoresGR(int col)
        {
            String valor = "";

            switch (col)
            {
                case 0: case 4:
                    valor = co.Leer.GetInt32(col) + "";
                    break;
                default:
                    valor = co.Leer.GetString(col);
                    break;
            }
            return valor;
        }

        private String totalPR()
        {
            int total = 0;
            co.Comando("SELECT Distinct  p.ID, p.monto " +
                                "FROM Pagos as p INNER JOIN PagoProgramado as PaPr ON(p.PagoProgramadoID = PaPr.ID) " +
                                "INNER JOIN Pago_Empleado_Trabajos as Pet ON(Papr.ID = Pet.PagoProgramadoID)" +
                                "INNER JOIN Empleado_Trabajos as Et ON(Pet.EmpleadoID = Et.EmpleadoID)" +
                                "INNER JOIN Empleado as e ON(Pet.EmpleadoID = e.ID)" +
                                "INNER JOIN Trabajos as t ON(Pet.TrabajosID = t.ID)" +
                                "WHERE p.FechaPago BETWEEN '" + fechaA + "' AND '" + fechaB + "' ;");
            while (co.LeerRead)
            {
                total += co.Leer.GetInt32(1);
            }

            return total + "";
        }

        private String totalGR()
        {
            int total = 0;
            co.Comando("SELECT totalGR('"+fechaA+"', '"+fechaB+"');");
            if (co.LeerRead)
                total = co.Leer.GetInt32(0);
            return total + "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Funciones.ReleaseCapture();
            Funciones.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void checkBoxt1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxt1.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox7.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBoxt2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxt2.Checked == true)
            {
                checkBox14.Checked = true;
                checkBox15.Checked = true;
                checkBox16.Checked = true;
                checkBox8.Checked = true;
            }
            else
            {
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBoxt3_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxt3.Checked == true)
            {
                checkBox5.Checked = true;
                checkBox13.Checked = true;
                checkBox17.Checked = true;
                checkBox18.Checked = true;
                checkBox19.Checked = true;
                checkBox9.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
                checkBox13.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBoxt4_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxt4.Checked == true)
            {
                checkBox24.Checked = true;
                checkBox25.Checked = true;
                checkBox26.Checked = true;
                checkBox27.Checked = true;
                checkBox10.Checked = true;
                checkBox6.Checked = true;
            }
            else
            {
                checkBox24.Checked = false;
                checkBox25.Checked = false;
                checkBox26.Checked = false;
                checkBox27.Checked = false;
                checkBox10.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Reporte_Click(object sender, EventArgs e)
        {
            if (arreglos() == 0)
            {
                // Agregar mensaje de "no se seleccionó nignuna opcion"
                MessageBox mens = new MessageBox("No se ha seleccion ninguna opción", 2);
                mens.ShowDialog();
                return;
            }
            fechas();
            crearDocumento();
            
            
        }
    }
}
