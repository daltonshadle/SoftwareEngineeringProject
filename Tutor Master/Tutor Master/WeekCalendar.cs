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

        List<Appointment> appointmentList;
        string username;

        public WeekCalendar()
        {
            InitializeComponent();
            //drawAppoint(panelSun);
            updateWeekLabel();
        }

        public void assignWeeklyAppointments(string user)
        {
            username = user;
            //fetch the appointments
            Database db = new Database();
            appointmentList = db.getDailyAppointments(user);

            //fetch the dates of the week
            DateTime date = DateTime.Now;
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                date = date.AddDays(-1);
            }
            DateTime Sunday = date;
            DateTime Monday = date.AddDays(1);
            DateTime Tuesday = date.AddDays(2);
            DateTime Wednesday = date.AddDays(3);
            DateTime Thursday = date.AddDays(4);
            DateTime Friday = date.AddDays(5);
            DateTime Saturday = date.AddDays(6);
         
            displayDay(Sunday, panelSun);
            displayDay(Monday, panelMon);
            displayDay(Tuesday, panelTues);
            displayDay(Wednesday, panelWed);
            displayDay(Thursday, panelThur);
            displayDay(Friday, panelFri);
            displayDay(Saturday, panelFri);
        }

        public void displayDay(DateTime date, Panel p)
        {
            Database db = new Database();
            appointmentList = db.getDailyAppointments(username);

            //Fill up the list for each day.
            List<Appointment> dailyAppointments = new List<Appointment>();
            for (int i = 0; i < appointmentList.Count; i++)
            {
                if (appointmentList[i].getStartTime().Date == date.Date)
                {
                    dailyAppointments.Add(appointmentList[i]);
                }
            }

            //Display all of the daily apps
            if (dailyAppointments.Count > 0 && dailyAppointments.Count <= 3)
            {

                AppointmentBlock a;
                for (int j = 0; j < dailyAppointments.Count; j++)
                {
                    a = new AppointmentBlock(appointmentList[j]);
                    //int x = makeX(j);
                    //int y = makeY(j);
                    a.Location = new Point(10, (j*90) + 30);
                    p.Controls.Add(a);
                    //drawAppointment(dailyAppointments[j], "Free Time");
                }
                p.Visible = true;
            }

            else if(dailyAppointments.Count > 3)
            {

                AppointmentBlock a;
                for (int j = 0; j < 3; j++)
                {
                    a = new AppointmentBlock(appointmentList[j]);
                    //int x = makeX(j);
                    //int y = makeY(j);
                    a.Location = new Point(10, (j * 90) + 30);
                    p.Controls.Add(a);
                    //drawAppointment(dailyAppointments[j], "Free Time");
                }

                Button button = new Button();
                button.Name = "btnSeeMore";
                button.Text = "See More";
                button.Location = new Point(45, 300);
                this.Controls.Add(button);
                p.Controls.Add(button);
                button.Click += new EventHandler(NewButton_Click);

                p.Visible = true;
            }
            
        }

        // In event method.
        private void NewButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Find the programatically created button and assign its onClick event
            if (btn.Name == ("btnSeeMore"))
            {
                var monthCal = new MonthCalendarForm(username);
                monthCal.Show();
            }
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
