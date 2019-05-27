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
        public pagos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reporte_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fh = new FormularioProgramarPago();
            //fh.ShowDialog();
            //fh.StartPosition = FormStartPosition.CenterScreen;

        }

        private void pagar_Click(object sender, EventArgs e)
        {
            fh = new FormularioPago();
            fh.ShowDialog();
        }

		private void pagos_Load(object sender, EventArgs e)
		{

		}
	}
}
