using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio
{
    class PanelJosue : Panel
    {
        private Panel fondo;
        public Label labelNombre;
        public Label labelTrabajo;
        public Label labelProyecto;
        private PictureBox imagen;

        private Timer timerSubir;
        private Timer timerBajar;
        private Timer timerVerificar;
        private Timer timerStop;

        // Levantado indicará si el panel está arriba, es decir, mostrando la información de trabajo y proyecto
        private bool levantado;
        // Disponible indicará si el panel no está ejecutando una acción y permite empezar un proceso
        private bool disponible;
        // Mouse indicará si el mouse se encuentra o no encima del panel
        private bool mouse;

        public PanelJosue(Panel panelFondo, PictureBox cuadro, Label nombre, Label trabajo, Label proyecto) : base()
        {
            // Se deben enviar los componentes con la información necesaria pero las posiciones son
            // configuradas aquí
            fondo = panelFondo;
            imagen = cuadro;

            // Esta localización es la que se toma como bandera para los movimientos
            imagen.Location = new Point(27, 10);
            // ---------------------------------------------------------------------

            labelNombre = nombre;
            labelNombre.Location = new Point(2, 90);
            labelNombre.Font = new Font("Gothic A1", 12);
            labelNombre.Size = new Size(fondo.Width - 4, 50);
            labelTrabajo = trabajo;
            labelTrabajo.Location = new Point(2, 146);
            labelTrabajo.Font = new Font("Gothic A1", 11);
            labelTrabajo.Size = new Size(fondo.Width - 4, 50);
            labelProyecto = proyecto;
            labelProyecto.Location = new Point(2, 190);
            labelProyecto.Font = new Font("Gothic A1", 11);
            labelProyecto.Size = new Size(fondo.Width - 4, 50);

            // Es el timer encargado de hacer subir el panel de forma fluida
            timerSubir = new Timer();
            timerSubir.Interval = 20;
            timerSubir.Tick += SubirPanel;

            // Es el timer encargado de hacer bajar el panel de forma fluida
            timerBajar = new Timer();
            timerBajar.Interval = 20;
            timerBajar.Tick += BajarPanel;

            // Es el timer que se encarga de verificar si el mouse está dentro o fuera del panel y
            // activar los métodos correspondientes
            timerVerificar = new Timer();
            timerVerificar.Interval = 20;
            timerVerificar.Tick += Checar;

            // Stop es el timer que creará un tiempo muerto de procesos para esperar a que los 
            // métodos se realicen sin estorbarse
            timerStop = new Timer();
            timerStop.Interval = 1000;
            timerStop.Tick += Esperar;

            this.Controls.Add(fondo);
            fondo.Controls.Add(imagen);
            fondo.Controls.Add(labelNombre);
            fondo.Controls.Add(labelTrabajo);
            fondo.Controls.Add(labelProyecto);
            levantado = false;
            disponible = true;
            mouse = false;

            fondo.MouseEnter += EntraMouse;
            imagen.MouseEnter += EntraMouse;
            labelNombre.MouseEnter += EntraMouse;
            labelProyecto.MouseEnter += EntraMouse;
            labelTrabajo.MouseEnter += EntraMouse;
            fondo.MouseLeave += SaleMouse;
            //imagen.MouseLeave += SaleMouse;
            labelNombre.MouseLeave += SaleMouse;
            labelProyecto.MouseLeave += SaleMouse;
            labelTrabajo.MouseLeave += SaleMouse;

            this.BringToFront();
            timerVerificar.Start();

            fondo.BackColor = BackColor = Color.FromArgb(127, 181, 181);
        }

        public void SubirPanel(object sender, EventArgs e)
        {
            // Si el fondo no ha subido del todo, entonces el panel no está disponible para otros procesos y 
            // se sigue modificando la posición
            if (imagen.Location.Y > -80)
            {
                disponible = false;
                imagen.Location = new Point(imagen.Location.X, imagen.Location.Y - 10);
                labelNombre.Location = new Point(labelNombre.Location.X, labelNombre.Location.Y - 10);
                labelTrabajo.Location = new Point(labelTrabajo.Location.X, labelTrabajo.Location.Y - 10);
                labelProyecto.Location = new Point(labelProyecto.Location.X, labelProyecto.Location.Y - 10);
            }

            // Si el fondo ya subió, entonces el proceso se terminó. El panel ya está disponible y 
            // se encuentra "levantado"
            else
            {
                disponible = true;
                levantado = true;
                timerSubir.Stop();
            }
        }

        public void BajarPanel(object sender, EventArgs e)
        {
            // Si el fondo no ha bajado del todo, entonces el panel no está disponible para otros procesos y 
            // se sigue modificando la posición
            if (imagen.Location.Y < 10)
            {
                disponible = false;
                imagen.Location = new Point(imagen.Location.X, imagen.Location.Y + 10);
                labelNombre.Location = new Point(labelNombre.Location.X, labelNombre.Location.Y + 10);
                labelTrabajo.Location = new Point(labelTrabajo.Location.X, labelTrabajo.Location.Y + 10);
                labelProyecto.Location = new Point(labelProyecto.Location.X, labelProyecto.Location.Y + 10);
            }
            // Si el fondo ya bajó, entonces el proceso se terminó. El panel ya está disponible y 
            // no se encuentra "levantado"
            else
            {
                disponible = true;
                levantado = false;
                timerBajar.Stop();
            }
        }

        public void Checar(object sender, EventArgs e)
        {
            // Si el panel no está realizando una acción, el mouse se encuentra encima del panel y este no
            // está levantado, entonces se subirá, el check se deshabilitará y el tiempo muerto empezará
            if (disponible == true && mouse == true && levantado == false)
            {
                timerSubir.Start();
                timerVerificar.Stop();
                timerStop.Start();
            }

            // Si el panel no está realizando una acción, el mouse se encuentra encima del panel y este
            // está levantado, entonces se bajará, el check se deshabilitará y el tiempo muerto empezará
            if (disponible == true && mouse == false && levantado == true)
            {
                timerBajar.Start();
                timerVerificar.Stop();
                timerStop.Start();
            }

            // Si el panel no está realizando una acción, el mouse no se encuentra encima del panel y este
            // está levantado, entonces se bajará, el check se deshabilitará y el tiempo muerto empezará
            if (disponible == true && mouse == false && levantado == true)
            {
                timerBajar.Start();
                timerVerificar.Stop();
                timerStop.Start();
            }     
        }

        public void Esperar(object sender, EventArgs e)
        {
            // Después de esperar a que el método se active, el timer para verificar el estado del panel
            // se reiniciará y el de esperar terminará
            timerVerificar.Start();
            timerStop.Stop();
        }

        public void EntraMouse(object sender, EventArgs e)
        {
            mouse = true;
        }

        public void SaleMouse(object sender, EventArgs e)
        {
            mouse = false;
        }

         // Código para realizar un panel transparente
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }


    }
}
