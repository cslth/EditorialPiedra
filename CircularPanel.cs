using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PruebaA
{
	public class CircularPanel : Panel
	{
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawEllipse(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);
		}

		protected override void OnResize(EventArgs e)
		{
			this.Width = this.Height;
			base.OnResize(e);
		}
	}


}
