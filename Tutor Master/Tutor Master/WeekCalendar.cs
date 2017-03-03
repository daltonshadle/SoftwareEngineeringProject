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
            //drawAppoint(panelSun);
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
            DateTime d = DateTime.Now;
            Profile user = new Profile("Tommy", "asdfghj");
            AppointmentBlock a = new AppointmentBlock("Learning", "Library", d, "CS1", user);
            a.Location = new Point(9, 30);
            p.Controls.Add(a);
        }

        public void drawAppointment(Appointment appt, string type) {
            DateTime time = appt.getStartTime();
            string course = appt.getCourse();
            string place = appt.getMeetingPlace();
            Profile user = appt.getTutee();


            AppointmentBlock a = new AppointmentBlock(type, place, time, course, user);
            a.Location = new Point(9, 30);
            Panel panelDay = findRightPanel(time);
            panelDay.Controls.Add(a);
        }

        private Panel findRightPanel(DateTime time) {
            if (time.DayOfWeek == DayOfWeek.Sunday)
                return panelSun;
            if (time.DayOfWeek == DayOfWeek.Monday)
                return panelMon;
            if (time.DayOfWeek == DayOfWeek.Tuesday)
                return panelTues;
            if (time.DayOfWeek == DayOfWeek.Wednesday)
                return panelWed;
            if (time.DayOfWeek == DayOfWeek.Thursday)
                return panelThur;
            if (time.DayOfWeek == DayOfWeek.Friday)
                return panelFri;
            if (time.DayOfWeek == DayOfWeek.Saturday)
                return panelSat;

            Panel p = new Panel();
            return p;
        }

    }
}
