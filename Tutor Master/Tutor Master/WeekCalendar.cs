using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tutor_Master
{
    public partial class WeekCalendar : UserControl
    {
        public WeekCalendar()
        {
            InitializeComponent();
            drawAppoint(panelSun);
        }

        private void lblThursday_Click(object sender, EventArgs e)
        {

        }

        public void drawAppoint(Panel p) {
            Graphics g = p.CreateGraphics();
            Brush b = new SolidBrush(Color.Red);

            g.FillRectangle(b, 10, 25, p.Width - 20, 30);
        }
    }
}
