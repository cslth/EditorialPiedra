using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppProyectoBD;

namespace Inicio
{
    public partial class VentanaPrincipal : Form
    {
        // Objeto para manipular la base de datos
        Conexion co;

        

        // Bandera para evitar actualizar innecesariamente los flowLayoutPanel
        bool mostrandoProyectos;

        // Se utilizarán para guardar el ID del proyecto o trabajo que deben mostrarse
        int proyectoActivo;
        int trabajoActivo;
        int labels;
        Label label1;


        List<int> ID;

        public VentanaPrincipal(Conexion co)
        {
            InitializeComponent();
            this.co = co;
            mostrandoProyectos = true;
            proyectoActivo = 0;
            trabajoActivo = 0;
            labels = 0;
            label1 = new Label();
            ID = new List<int>();

            MostrarEmpleados(); // Se utiliza para mostrar los empleados activos
            MostrarPanelesProyectos(); // Se utiliza para mostrar los paneles con los proyectos activos
        }

        private void MostrarEmpleados()
        {
            List<int> id = new List<int>();
            String nombre = "";
            String trabajo = "";
            String proyecto = "";
            String ruta = "";

            // Realizo la consulta para obtener los ID's de los empleados activos
            co.Comando("SELECT DISTINCT E.ID " +
                "FROM Empleado AS E WHERE E.ID IN (SELECT ET.EmpleadoID FROM Empleado_Trabajos as ET, Trabajos as T " +
                                                    "WHERE T.FechaFin > CURDATE());");

            // Guardo en un arreglo los ID's
            while (co.LeerRead)
                id.Add(co.Leer.GetInt32(0));
            if (id.Count == 0)
                return;
            else
            {
                for (int i = 0; i < id.Count; i++)
                {
                    co.Comando("SELECT DISTINCT E.Nombre as NombreTrabajador, T.Nombre as NombreTrabajo, E.imagenEmpleado as Imagen " +
                           "FROM Empleado as E, Trabajos as T, Empleado_Trabajos as ET " +
                           "WHERE (E.ID = " + id[i] + " AND E.ID = ET.EmpleadoID AND ET.TrabajosID = T.ID) " +
                           "GROUP BY E.Nombre;");
                    if (co.LeerRead)
                    {
                        // Se guardan el nombre y trabajo en el que participa el empleado en cuestión
                        nombre = co.Leer.GetString(0);
                        trabajo = co.Leer.GetString(1);
                        ruta = co.Leer.GetString(2);
                    }
                    //if (ruta == null || ruta.Equals(""))
                    

                    co.Comando("SELECT P.Nombre " +
                               "FROM proyectos AS P, Trabajos AS T " +
                               "WHERE T.Nombre = '" + trabajo + "' AND T.ProyectosID = P.ID;");
                    if (co.LeerRead)
                    {
                        // Se guardan el nombre del proyecto si es que hay uno asociado
                        proyecto = co.Leer.GetString(0);
                    }
                    else
                    {
                        proyecto = "No hay proyecto asociado";
                    }

                    // Aquí se crea el panel que contendrá todos los datos
                    Panel panelImg = new Panel
                    {
                        Size = new Size(140, 150),
                        BackColor = Color.LightSkyBlue,
                        Cursor = Cursors.Hand
                    };

                    // Label que contiene el nombre del empleado
                    Label labelN = new Label
                    {
                        Text = nombre,
                        ForeColor = Color.Black,
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    // Nombre del trabajo en el que está participando el empleado
                    Label labelT = new Label
                    {
                        Text = trabajo,
                        ForeColor = Color.Black,
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                    };


                    // Nombre del proyecto en el que está participando el empleado
                    Label labelP = new Label
                    {
                        Text = proyecto,
                        ForeColor = Color.Black,
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                    };


                    // Código para cortar una imagen y dejarla en círculo
                    int radio = 110, x = 135, y = 135;
                    Bitmap tmp = new Bitmap(2 * radio, 2 * radio);
                    Graphics g = Graphics.FromImage(tmp);
                    g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(0 - radio, 0 - radio, 2 * radio, 2 * radio);
                    Region region = new Region(path);
                    g.SetClip(region, CombineMode.Replace);
                    Bitmap bmp;
                    try
                    {
                        bmp = new Bitmap(ruta); //Ruta de la imagen
                    }catch(Exception e)
                    {
                        ruta = Path.Combine(Application.StartupPath, "sin foto.png");
                        bmp = new Bitmap(ruta); //Ruta de la imagen en caso de error
                    }
                    g.DrawImage(bmp, new Rectangle(-radio, -radio, 2 * radio, 2 * radio), new Rectangle(x - radio, y - radio, 2 * radio, 2 * radio), GraphicsUnit.Pixel);
                    PictureBox cuadro = new PictureBox();
                    cuadro.Size = new Size(80, 80);               
                    cuadro.Image = tmp;
                    cuadro.SizeMode = PictureBoxSizeMode.StretchImage;

                    cuadro.Location = new Point(27, 10);

                    // Creación del panel donde se encontrarán todos los elementos
                    PanelJosue panel = new PanelJosue(panelImg, cuadro, labelN, labelT, labelP)
                    {
                        Size = new Size(140, 150),
                        Cursor = Cursors.Hand
                    };

                    label1 = panel.labelNombre;
                    ajustarLabels();
                    label1 = panel.labelTrabajo;
                    ajustarLabels();
                    label1 = panel.labelProyecto;
                    ajustarLabels();

                    // Se añade el panel ya preparado al carrusel
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
        }
        

        // Métodos utilizados para mostrar la información de los trabajos

        // Añadir un panel que diga que no hay trabajos activos
        private void MostrarPanelesTrabajos()
        {
            String nombre = "";
            flowLayoutPanel2.Controls.Clear();
            labels = 0;

            // Consulta para obtener la cantidad de trabajos activos en el momento
            co.Comando("SELECT COUNT(*) FROM Trabajos WHERE FechaFin > CURDATE();");

            int paneles = 0;
            if (co.LeerRead)
                paneles = co.Leer.GetInt32(0);
            if (paneles == 0)
                return; // <- Añadir un panel diciendo que no hay trabajos activos
            else
            {
                ID.Clear();
                // Solamente se mostrará el nombre del trabajo y se mostrará en un panel
                // Se añade el ID al arreglo para accesar luego a su información si es necesario
                co.Comando("SELECT ID, Nombre FROM Trabajos WHERE FechaFin > CURDATE();");
                for (int i = 0; i < paneles; i++)
                {
                    if (co.LeerRead)
                    {
                        ID.Add(co.Leer.GetInt32(0));
                        nombre = co.Leer.GetString(1);
                    }
                        

                    // Panel que contendrá la label con el nombre del trabajo
                    Panel panel = new Panel
                    {
                        Size = new Size(283, 62),
                        BackColor = Color.FromArgb (127, 181, 181),
                        Cursor = Cursors.Hand
                    };

                    // Label que contendrá el nombre del trabajo
                    Label labelT = new Label
                    {
                        Text = nombre,
                        ForeColor = Color.Black,
                        AutoSize = false,
                        Size = new Size(panel.Width, panel.Height),
                        Location = new Point(0, 15),
                        Font = new Font("Gothic A1", 14),
                        Name = labels++.ToString(),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    // Aquí se reacomodan los labels si es necesario
                    label1 = labelT;
                    reacomodarLabels();

                    //Se añade la label al panel y el panel al flowLayoutPanel
                    labelT.MouseClick += Label_MouseClick;
                    panel.Controls.Add(labelT);
                    panel.MouseClick += Panel_MouseClick;
                    flowLayoutPanel2.Controls.Add(panel);
                }
            }
        }

        private void MostrarInfoTrabajos()
        {
            int dias;
            // Se realiza una consulta para obtener toda la información del trabajo seleccionado en el flowLayoutPanel2
            // Se ignorará la información del ID pues no es necesaria para el usuario
            labelProy.Text = "Proyecto:\n";
            labelEncargados.Text = "Encargados: ";
            labelFechas.Text = "Período:\n";
            labelDias.Text = "Tiempo restante:\n";
            labelDescripcion.Text = "Descripción:\n";

            co.Comando("SELECT T.Nombre, T.Descripcion, CONCAT(date_format(T.FechaInicio,'%d/%m/%Y'), ' - ', date_format(T.FechaFin,'%d/%m/%Y')) AS Fechas, " +
                       "DATEDIFF(T.FechaFin, CURDATE()) AS Dias, GROUP_CONCAT('\n', E.Nombre) AS Encargados " +
                       "FROM Trabajos as T, Empleado as E, Empleado_Trabajos as ET " +
                       "WHERE E.ID = ET.EmpleadoID AND ET.TrabajosID = T.ID AND T.ID = "+trabajoActivo+";");

            // Se muestra toda la información en los labels
            if (co.LeerRead)
            {
                labelNombre.Text = co.Leer.GetString(0);
                labelDescripcion.Text += co.Leer.GetString(1);
                labelFechas.Text += co.Leer.GetString(2);
                dias = co.Leer.GetInt32(3);
                labelDias.Text += dias + (dias>1?" días":" día");
                labelEncargados.Text += co.Leer.GetString(4);
                
            }
            labelEncargados.Text = labelEncargados.Text.Replace(",", "");
            //Debido a los trabajos sin proyectos se realiza la consulta del nombre del proyecto por separado
            int proyecto = 0;
            co.Comando("SELECT IFNULL(ProyectosID,0) FROM Trabajos WHERE ID = "+ trabajoActivo +";");
            if (co.LeerRead)
                proyecto = co.Leer.GetInt32(0);
            //Si es mayor a cero se consulta el nombre, si es menor quiere decir que no hay proyecto
            if (proyecto > 0)
            {
                co.Comando("SELECT Nombre FROM Proyectos WHERE ID ="+proyecto+";");
                if(co.LeerRead)
                {
                    labelProy.Text +=  co.Leer.GetString(0);
                    labelProy.Font = new Font("Gothic A1", 8.25f, labelProy.Font.Style);
                }
            }
            else
            {
                labelProy.Text += "Este trabajo no pertenece a ningún proyecto";
            }

            // Aquí se ajusta el tamaño de la fuente de la label si es necesario
            label1 = labelNombre;
            ajustarLabels();
        }


        // Métodos utilizados para mostrar la información de los proyectos 
        private void MostrarPanelesProyectos()
        {
            String nombre = "";
            flowLayoutPanel2.Controls.Clear();
            labels = 0;

            // Consulta para obtener la cantidad de proyectos activos en el momento
            co.Comando("SELECT COUNT(*) FROM Proyectos WHERE FechaFin > CURDATE();");

            int paneles = 0;
            if (co.LeerRead)
                paneles = co.Leer.GetInt32(0);
            if (paneles == 0)
                return;
            else
            {
                // Se limpia el arreglo para hacer el cambio entre ID de trabajos y proyectos
                ID.Clear();
                labels = 0;
                co.Comando("SELECT ID, Nombre FROM Proyectos WHERE FechaFin > CURDATE();");
                for (int i = 0; i < paneles; i++)
                {
                    if (co.LeerRead)
                    {
                        // Solamente se mostrará el nombre del proyecto en el label que se pondrá en el panel
                        // Se añade el ID al arreglo para accesar luego a su información si es necesario 
                        ID.Add(co.Leer.GetInt32(0));
                        nombre = co.Leer.GetString(1);
                    }

                    Panel panel = new Panel
                    {
                        Size = new Size(283, 62),
                        BackColor = Color.FromArgb(127, 181, 181),
                        Cursor = Cursors.Hand
                    };

                    Label labelT = new Label
                    {
                        Text = nombre,
                        ForeColor = Color.Black,
                        AutoSize = false,
                        Size = new Size(panel.Width, panel.Height),
                        Location = new Point(0, 15),
                        Font = new Font("Gothic A1", 14),
                        Name = labels++.ToString(),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    // Aquí se reajusta y reacomoda las labels para que el texto quepa
                    label1 = labelT;
                    ajustarLabels();
                    reacomodarLabels();

                    //Se añade el label al panel y el panel al flowLayoutPanel
                    labelT.MouseClick += Label_MouseClick;
                    panel.Controls.Add(labelT);
                    panel.MouseClick += Panel_MouseClick;
                    flowLayoutPanel2.Controls.Add(panel);
                }
            }
        }

        private void MostrarInfoProyecto()
        {
            // Se realiza una consulta para obtener el nombre, descripción, fechas de inicio y fin, encargado
            // del proyecto elegido en el flowLayoutPanel2
            labelFechas.Text = "Período:\n";
            labelDias.Text = "Tiempo restante:\n";
            labelDescripcion.Text = "Descripción:\n";

            co.Comando("SELECT Nombre, Descripcion, date_format(FechaInicio, '%d/%m/%Y'), date_format(FechaFin, '%d/%m/%Y'), Encargado " +
                       "FROM proyectos " +
                       "WHERE ID = " + proyectoActivo + ";");

            // Se muestra toda la información en los labels
            if (co.LeerRead)
            {
                labelNombre.Text = co.Leer.GetString(0);
                labelDescripcion.Text += co.Leer.GetString(1);
                labelFechas.Text += co.Leer.GetString(2) + " - " + co.Leer.GetString(3);
                labelProy.Text = "Encargado: " + co.Leer.GetString(4);
            }
            labelProy.Font = new Font("Gothic A1", 13, labelProy.Font.Style);
            label1 = labelNombre;
            ajustarLabels();

            // Se realiza una resta para obtener los días restantes para la finalización del proyecto
            co.Comando("SELECT datediff(FechaFin, CURDATE()) FROM proyectos WHERE ID = " + proyectoActivo + ";");
            int dias = 0;
            if (co.LeerRead)
                dias = co.Leer.GetInt32(0);
            labelDias.Text += dias + " " + (dias == 1 ? "dia restante" : "dias restantes");

            // Hago una consulta a parte para obtener todos los trabajos asociados al proyecto en cuestión
            co.Comando("SELECT nombre FROM Trabajos WHERE ProyectosID = " + proyectoActivo + ";");
            labelEncargados.Text = "Trabajos asociados:";
            while (co.LeerRead)
                labelEncargados.Text += "\n" + co.Leer.GetString(0);
        }


        // Métodos que se añaden a los paneles y labels para mostrar la información
        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            int index = Convert.ToInt32(label.Name);
            if (mostrandoProyectos)
            {
                proyectoActivo = ID[index];
                MostrarInfoProyecto();
            }
            else
            {
                trabajoActivo = ID[index];
                MostrarInfoTrabajos();
            }
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            // Se obtiene el índice correspondiente al panel en el flowLayoutPanel
            // y se guarda en el arreglo de índices
            Panel panel = (Panel) sender;
            int index = flowLayoutPanel2.Controls.GetChildIndex(panel);
            if (mostrandoProyectos)
            {
                proyectoActivo = ID[index];
                MostrarInfoProyecto();
            }
            else
            {
                trabajoActivo = ID[index];
                MostrarInfoTrabajos();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        // Aquí empieza el timer1
        private void panelIzq_MouseHover(object sender, EventArgs e)
        {
            timer1.Start();
        }

        // Este timer tiene la función de mover a la izquierda los paneles
        private void timer1_Tick(object sender, EventArgs e)
        {
            int cambio = flowLayoutPanel1.HorizontalScroll.Value - flowLayoutPanel1.HorizontalScroll.SmallChange;
            cambio = cambio < 0 ? 0 : cambio;
            flowLayoutPanel1.AutoScrollPosition = new Point(cambio, 0);
        }

        // Aquí se detiene el timer1
        private void panelIzq_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        // Este timer tiene la función de mover a la derecha los paneles
        private void timer2_Tick(object sender, EventArgs e)
        {
            int cambio = flowLayoutPanel1.HorizontalScroll.Value + flowLayoutPanel1.HorizontalScroll.SmallChange;
            cambio = cambio > flowLayoutPanel1.HorizontalScroll.Maximum ? flowLayoutPanel1.HorizontalScroll.Maximum : cambio;
            flowLayoutPanel1.AutoScrollPosition = new Point(cambio, 0);
        }

        // Aquí empieza el timer2
        private void panel21_MouseHover(object sender, EventArgs e)
        {
            timer2.Start();
        }

        // Aquí se detiene el timer2
        private void panel21_MouseLeave(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cambio = flowLayoutPanel1.HorizontalScroll.Value - flowLayoutPanel1.HorizontalScroll.SmallChange * 5;
            flowLayoutPanel1.AutoScrollPosition = new Point(cambio, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int cambio = flowLayoutPanel1.HorizontalScroll.Value + flowLayoutPanel1.HorizontalScroll.SmallChange * 5;
            flowLayoutPanel1.AutoScrollPosition = new Point(cambio, 0);
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            timer3.Stop();
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            timer4.Start();
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            timer4.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int cambio = flowLayoutPanel2.VerticalScroll.Value - flowLayoutPanel2.VerticalScroll.SmallChange;
            flowLayoutPanel2.AutoScrollPosition = new Point(0, cambio);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            int cambio = flowLayoutPanel2.VerticalScroll.Value + flowLayoutPanel2.VerticalScroll.SmallChange;
            flowLayoutPanel2.AutoScrollPosition = new Point(0, cambio);
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            int cambio = flowLayoutPanel2.VerticalScroll.Value - flowLayoutPanel2.VerticalScroll.SmallChange * 5;
            flowLayoutPanel2.AutoScrollPosition = new Point(0, cambio);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int cambio = flowLayoutPanel2.VerticalScroll.Value + flowLayoutPanel2.VerticalScroll.SmallChange;
            flowLayoutPanel2.AutoScrollPosition = new Point(0, cambio);
        }

        private void panel16_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Aquí se crea el panel que contendrá todos los datos
            Panel panelImg = new Panel
            {
                Size = new Size(140, 150),
                BackColor = Color.LightSkyBlue,
                Cursor = Cursors.Hand
            };

            // Label que contiene el nombre del empleado
             Label labelN = new Label
            {
                Text = "Josue Manuel Romero Canaan",
                ForeColor = Color.Black,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter
            };
            
            // Nombre del trabajo en el que está participando el empleado
            Label labelT = new Label
            {
                Text = " Portada de libro: El soñador",
                ForeColor = Color.Black,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
            };

            // Nombre del proyecto en el que está participando el empleado
            Label labelP = new Label
            {
                Text = "El soñador",
                ForeColor = Color.Black,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
            };

            // Código para cortar una imagen y dejarla en círculo
            int radio = 18, x = 23, y = 24;
            Bitmap tmp = new Bitmap(2 * radio, 2 * radio);
            Graphics g = Graphics.FromImage(tmp);
            g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0 - radio, 0 - radio, 2 * radio, 2 * radio);
            Region region = new Region(path);
            g.SetClip(region, CombineMode.Replace);
            Bitmap bmp = new Bitmap("C:\\Users\\tote_\\Desktop\\ImagenLol.jpg"); //Ruta de la imagen
            g.DrawImage(bmp, new Rectangle(-radio, -radio, 2 * radio, 2 * radio), new Rectangle(x - radio, y - radio, 2 * radio, 2 * radio), GraphicsUnit.Pixel);
            PictureBox cuadro = new PictureBox();
            cuadro.Size = new Size(80, 80);
            cuadro.SizeMode = PictureBoxSizeMode.StretchImage;
            cuadro.Image = tmp;
            
            cuadro.Location = new Point(27, 10);
            
            // Creación del panel donde se encontrarán todos los elementos
            PanelJosue panel = new PanelJosue(panelImg, cuadro, labelN, labelT, labelP)
            {
                Size = new Size(140, 150),
                Cursor = Cursors.Hand
            };

            // Se añade el panel ya preparado al carrusel
            flowLayoutPanel1.Controls.Add(panel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            panel.Size = new Size(283, 62);
            panel.BackColor = Color.CornflowerBlue;
            panel.Cursor = Cursors.Hand;
            flowLayoutPanel2.Controls.Add(panel);
        }

        private void buttonTrabajos_Click(object sender, EventArgs e)
        {
            if (mostrandoProyectos == true)
            {
                MostrarPanelesTrabajos();
                mostrandoProyectos = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mostrandoProyectos == false)
            {
                MostrarPanelesProyectos();
                mostrandoProyectos = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelDias_Click(object sender, EventArgs e)
        {

        }

        // Método para ajustar el tamaño de la fuente de las labels
        private void ajustarLabels()
        {
            while (label1.Width * 1.7 < System.Windows.Forms.TextRenderer.MeasureText(label1.Text,
                    new Font(label1.Font.FontFamily, label1.Font.Size, label1.Font.Style)).Width)
            {
                label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size - 0.5f, label1.Font.Style);
            }
        }

        // Método para ajustar la localización de las labels
        private void reacomodarLabels()
        {
            if (label1.Width < System.Windows.Forms.TextRenderer.MeasureText(label1.Text,
                    new Font(label1.Font.FontFamily, label1.Font.Size, label1.Font.Style)).Width)
            {
                label1.Location = new Point(label1.Location.X, label1.Location.Y-15);
            }
            else
            {
                label1.Location = new Point(label1.Location.X, label1.Location.Y - 18);
            }
        }

        private void VentanaPrincipal_SizeChanged(object sender, EventArgs e)
        {
            buttonDer.Location = new Point(this.Width - 55, buttonDer.Location.Y);
            buttonIzq.Location = new Point(8, buttonIzq.Location.Y);

            panelFLP1.Location = new Point(64, panelFLP1.Location.Y);
            panelFLP1.Width = this.Width - 65;

            panelFLP2.Location = new Point(8, panelFLP2.Location.Y);
            buttonProyectos.Location = new Point(8, buttonProyectos.Location.Y);
            buttonTrabajos.Location = new Point(147, buttonTrabajos.Location.Y);

            buttonUp.Location = new Point(261, buttonUp.Location.Y);
            buttonDwn.Location = new Point(261, buttonDwn.Location.Y);

            panelInfo.Location = new Point(289, panelInfo.Location.Y);
            panelInfo.Width = this.Width - 294;

            labelNombre.Width = panelInfo.Width - 12;
            labelEncargados.Width = panelInfo.Width - 356;
        }
    }
}
