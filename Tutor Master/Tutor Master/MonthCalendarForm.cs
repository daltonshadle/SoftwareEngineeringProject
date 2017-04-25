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
        //private data
        private string username;
        List<Appointment> appointmentList;
        DateTime selectedDate;

        //Constructor
        public MonthCalendarForm(string user)
        {
            InitializeComponent();

            //Fill the calendar with bolded dates
            Database db = new Database();
            appointmentList = db.getDailyAppointments(user);
            monthCalendar1.profileMonthCalendar.BoldedDates = new System.DateTime[] { };
            for (int i = 0; i < appointmentList.Count; i++)
            {
                DateTime appointmentDate = appointmentList[i].getStartTime();
                monthCalendar1.profileMonthCalendar.AddBoldedDate(appointmentDate);
            }

            username = user;
            selectedDate = DateTime.Now;
            displayPanel();

        }

        //Updates the display of panel depending on which date is selected.
        private void displayPanel()
        {
            //Clear all items inside
            clearPanel();

            //Fill up the list for each day.
            List<Appointment> dailyAppointments = new List<Appointment>();
            for (int i = 0; i < appointmentList.Count; i++)
            {
                if (appointmentList[i].getStartTime().Date == selectedDate.Date)
                {
                    dailyAppointments.Add(appointmentList[i]);
                }
            }

            //Sort all of the appointments by start time
            dailyAppointments = dailyAppointments.OrderBy(o => o.getStartTime()).ToList();

            //Display all of the daily apps
            if (dailyAppointments.Count > 0)
            {
                panel1.Visible = true;

                AppointmentBlock a;
                for (int j = 0; j < dailyAppointments.Count; j++)
                {
                    a = new AppointmentBlock(dailyAppointments[j], username);
                    int x = makeX(j);
                    int y = makeY(j);
                    a.Location = new Point(x +10, y +10);
                    panel1.Controls.Add(a);
                }
            }
            else
                panel1.Visible = false;
        }

        //Clears items in the panel
        public void clearPanel()
        {
            panel1.Controls.Clear();
        }

        //Sets the x position of the appointment block added to panel & adjusts width of form
        public int makeX(int iteration)
        {
            int x;
            int col = iteration/3;
            panel1.Width = 125 + col * 120;
            x = (col*120);

            if (col > 1)
                this.Width = 440 + col * 120;

            return x;
        }

        //Sets the y position of the appointment block added to panel
        public int makeY(int iteration)
        {
            int y;
            int row = iteration % 3;
            y = ((row) * 100);

            return y;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Registering event listeners~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void MonthCalendarForm_Activated(object sender, EventArgs e)
        {
            displayPanel();
        }

        private void profileMonthCalendar_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            //Display the date of the selected date
            monthCalendar1.lblTempDate.Text = e.Start.ToShortDateString();

            //updates the selected date so that displayPanel() can use it
            selectedDate = e.Start.Date;
            displayPanel();
        }

    }
}
