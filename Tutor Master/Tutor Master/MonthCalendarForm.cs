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

            //The vision for this:
            //Garrett write a function. public List<Appointment> getDailyAppointments(string username, DateTime date)
            //Pre: username in database and date is not NULL
            //Post: returns list of all appointments on a given date for any user

            /*Database db = new Database();
             appointmentList = db.getDailyAppointments(username, now);
            if (!appointmentList.IsEmpty()) {
                ListView newLV = new ListView;
                newLV.Left = monthCalendar1.profileMonthCalendar.Left + 50;
                newLV.Top = monthCalendar1.profileMonthCalendar.Top;

                for (int i = 0; i < appointmentList.size(); i++)
                {
                    newLV.Items.Add(appointmentList.get(i));
                }
            }*/

            //Fill the calendar with bolded dates
            //monthCalendar1.profileMonthCalendar.BoldedDates = new System.DateTime[] { };
            //for (int i = 0; i < appointmentList.size(); i++)
            //{
            //    DateTime appointmentDate = appointmentList.get(i).getDate();
            //    monthCalendar1.profileMonthCalendar.AddBoldedDate(appointmentDate);
            //}

            //monthCalendar1.profileMonthCalendar.BoldedDates = new System.DateTime[] { new System.DateTime(2017, 3, 5, 0, 0, 0, 0) };
            //monthCalendar1.profileMonthCalendar.AddBoldedDate(new System.DateTime(2017, 3, 15, 0, 0, 0, 0));
            
            
        
        }

        private void profileMonthCalendar_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            // Show the start and end dates in the text box.
            monthCalendar1.lblTempDate.Text = e.Start.ToShortDateString();

            MessageBox.Show("Date Selected: Start = " +
            e.Start.ToShortDateString() + " : End = " + e.End.ToShortDateString() + "for " + username);

            /*if (appointmentList.size() != 0)
            {
                List<Appointment> dailyAppointments = new List<Appointment>();
                for (int i = 0; i < appointmentList.size(); i++)
                {
                    if (appointmentList.get(i).getDate() == e.Start)
                    {
                        dailyAppointments.Add(appointmentList.get(i));
                    }
                }
            }

            if (dailyAppointments.size() > 0)
            {
                ListView dailyAppLV = new ListView();
                for (int j = 0; j < dailyAppointments.size(); j++)
                {
                    dailyAppLV.Items.Add(dailyAppointments.get(j));
                }
                dailyAppLV.Left = monthCalendar1.Left + 200;
                dailyAppLV.Top = monthCalendar1.Top;
            }*/

        }     

    }
}
