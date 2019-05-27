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
    public partial class MessageBox : Form
    {
        public MessageBox(String texto)
        {
            InitializeComponent();
            label2.Text = texto;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {      
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormularioProgramarPago frm2 = Application.OpenForms.OfType<FormularioProgramarPago>().FirstOrDefault();

            if (frm2 != null)  //Si encuentra una instancia abierta
            {
                frm2.estado = true;
            }
            this.Close();
        }
    }
}
