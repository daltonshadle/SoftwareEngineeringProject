using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Tutor_Master
{
    public partial class WeekCalendar : UserControl
    {

        List<Appointment> appointmentList;
        string username;
        DateTime currentDate;

        public WeekCalendar()
        {
            InitializeComponent();
            updateWeekLabel(DateTime.Now);
            WeekCalendar_Load();
        }

        private void WeekCalendar_Load()
        {
            // Define the points in the polygonal path.
            Point[] ptsRight = {
        new Point(12,  6),
        new Point(24,  6),
        new Point(24,  2),
        new Point(32, 10),
        new Point(24, 18),
        new Point(24, 14),
        new Point(12, 14)
    };
            Point[] ptsLeft = {
        new Point(12,  10),
        new Point(20,  2),
        new Point(20,  6),
        new Point(32,  6),
        new Point(32, 14),
        new Point(20, 14),
        new Point(20, 18)
    };

            // Make the GraphicsPath.
            GraphicsPath polygon_path = new GraphicsPath(FillMode.Winding);
            polygon_path.AddPolygon(ptsRight);
            GraphicsPath polygon_path2 = new GraphicsPath(FillMode.Winding);
            polygon_path2.AddPolygon(ptsLeft);

            // Convert the GraphicsPath into a Region.
            Region polygon_region = new Region(polygon_path);
            Region polygon_region2 = new Region(polygon_path2);

            // Constrain the button to the region.
            btnRightArrow.Region = polygon_region;
            btnLeftArrow.Region = polygon_region2;

            // Make the button big enough to hold the whole region.
            btnRightArrow.SetBounds(
                btnRightArrow.Location.X,
                btnRightArrow.Location.Y,
                ptsRight[3].X + 5, ptsRight[4].Y + 5);

            btnLeftArrow.SetBounds(
                btnLeftArrow.Location.X,
                btnLeftArrow.Location.Y,
                ptsLeft[3].X + 5, ptsLeft[4].Y + 5);
        }

        public void assignWeeklyAppointments(string user)
        {
            username = user;
            currentDate = DateTime.Now;
            //fetch the appointments
            assignWeeklyAppointmentsHelper(currentDate);
        }

        private void assignWeeklyAppointmentsHelper(DateTime date)
        {
            Database db = new Database();
            appointmentList = db.getDailyAppointments(username);

            //fetch the dates of the week
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                date = date.AddDays(-1);
            }

            clearWeeklyCalendar();

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
            displayDay(Saturday, panelSat);
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

            List<Appointment> SortedList = dailyAppointments.OrderBy(o => o.getStartTime()).ToList();

            //Display all of the daily apps
            if (SortedList.Count > 0 && SortedList.Count <= 3)
            {

                AppointmentBlock a;
                for (int j = 0; j < SortedList.Count; j++)
                {
                    a = new AppointmentBlock(SortedList[j], username);
                    //int x = makeX(j);
                    //int y = makeY(j);
                    a.Location = new Point(10, (j*90) + 30);
                    p.Controls.Add(a);
                    //drawAppointment(dailyAppointments[j], "Free Time");
                }
                p.Visible = true;
            }

            else if(SortedList.Count > 3)
            {

                AppointmentBlock a;
                for (int j = 0; j < 3; j++)
                {
                    a = new AppointmentBlock(SortedList[j], username);
                    //int x = makeX(j);
                    //int y = makeY(j);
                    a.Location = new Point(10, (j * 90) + 30);
                    p.Controls.Add(a);
                    //drawAppointment(dailyAppointments[j], "Free Time");
                }

                Button button = new Button();
                button.Name = "btnSeeMore";
                button.Text = "See More";
                button.Location = new Point(22, 300);
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
                monthCal.StartPosition = FormStartPosition.CenterParent;
                monthCal.Show();
            }
        }

        public void updateWeekLabel(DateTime date) {

            while (date.DayOfWeek != DayOfWeek.Saturday)
            {
                date = date.AddDays(-1);
            }

            DateTime startDate = date;
            DateTime endDate = date.AddDays(7);

            lblWeek.Text = startDate.ToShortDateString() + " - " + endDate.ToShortDateString();
        }

        public void clearWeeklyCalendar()
        {
            panelSun.Controls.Clear();
            panelMon.Controls.Clear();
            panelTues.Controls.Clear();
            panelWed.Controls.Clear();
            panelThur.Controls.Clear();
            panelFri.Controls.Clear();
            panelSat.Controls.Clear();
            panelSun.Controls.Add(lblSunday);
            panelMon.Controls.Add(lblMonday);
            panelTues.Controls.Add(lblTuesday);
            panelWed.Controls.Add(lblWednesday);
            panelThur.Controls.Add(lblThursday);
            panelFri.Controls.Add(lblFriday);
            panelSat.Controls.Add(lblSaturday);
            
        }

        private void btnRightArrow_Click(object sender, EventArgs e)
        {
            //fetch the appointments
            currentDate = currentDate.AddDays(7);
            updateWeekLabel(currentDate);
            assignWeeklyAppointmentsHelper(currentDate);
        }

        private void btnLeftArrow_Click(object sender, EventArgs e)
        {
            //fetch the appointments
            currentDate = currentDate.AddDays(-7);
            updateWeekLabel(currentDate);
            assignWeeklyAppointmentsHelper(currentDate);
        }

    }
}
