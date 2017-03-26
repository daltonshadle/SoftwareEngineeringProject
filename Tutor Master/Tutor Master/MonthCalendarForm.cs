using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tutor_Master
{
    public partial class MonthCalendarForm : Form
    {

        private string username;
        DateTime now;
        List<Appointment> appointmentList;

        public MonthCalendarForm(string user)
        {
            InitializeComponent();
            username = user;

            this.monthCalendar1.profileMonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.profileMonthCalendar_DateSelected);

            now = DateTime.Now;

            Database db = new Database();
            appointmentList = db.getDailyAppointments(username);
            /*if (appointmentList.Count != 0) {
                panel1.Visible = true;

                for (int i = 0; i < appointmentList.Count; i++)
                {
                    AppointmentBlock a = new AppointmentBlock(appointmentList[i]);
                    panel1.Controls.Add(a);
                }
            }
            else 
                panel1.Visible = false;*/

            //Fill the calendar with bolded dates
            monthCalendar1.profileMonthCalendar.BoldedDates = new System.DateTime[] { };
            for (int i = 0; i < appointmentList.Count; i++)
            {
                DateTime appointmentDate = appointmentList[i].getStartTime();
                monthCalendar1.profileMonthCalendar.AddBoldedDate(appointmentDate);
            }

        }

        private void profileMonthCalendar_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            //Display the date of the selected date
            monthCalendar1.lblTempDate.Text = e.Start.ToShortDateString();
        


            Database db = new Database();
            appointmentList = db.getDailyAppointments(username);

            //Fill up the list for each day.
            List<Appointment> dailyAppointments = new List<Appointment>();
            for (int i = 0; i < appointmentList.Count; i++)
            {
                if (appointmentList[i].getStartTime().Date == e.Start.Date)
                {
                    dailyAppointments.Add(appointmentList[i]);
                }
            }
            
            //Display all of the daily apps
            if (dailyAppointments.Count > 0)
            {
                
                AppointmentBlock a;
                for (int j = 0; j < dailyAppointments.Count; j++)
                {
                    a = new AppointmentBlock(appointmentList[j]);
                    int x = makeX(j);
                    int y = makeY(j);
                    a.Location = new Point(x, y);
                    panel1.Controls.Add(a);
                }
                panel1.Visible = true;
            }
            else
                panel1.Visible = false;

        }

        public int makeX( int iteration)
        {
            int x;
            int col = iteration/5;
            x = (col*120);

            return x;
        }

        public int makeY(int iteration)
        {
            int y;
            int row = iteration % 5;
            y = ((row) * 100);

            return y;
        }

    }
}
