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
            updateWeekLabel();
        }

        public void updateWeekLabel() {

            DateTime date = DateTime.Now;
            while (date.DayOfWeek != DayOfWeek.Saturday)
            {
                date = date.AddDays(-1);
            }

            DateTime startDate = date;
            DateTime endDate = date.AddDays(7);

            lblWeek.Text = startDate.ToShortDateString() + " - " + endDate.ToShortDateString();
        }

        public void drawAppoint(Panel p) {
            Graphics g = p.CreateGraphics();
            Brush b = new SolidBrush(Color.Red);

            g.FillRectangle(b, 10, 25, p.Width - 22, 30);
            AppointmentBlock a = new AppointmentBlock();
            a.Location = new Point(9, 30);
            p.Controls.Add(a);
        }

    }
}
