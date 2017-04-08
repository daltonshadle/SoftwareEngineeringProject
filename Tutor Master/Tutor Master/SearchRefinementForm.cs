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
    public partial class SearchRefinementForm : Form
        //This form will allow people to refine their searches. With no refinements, you will be able to see all tutor set ups.
            //When you refine by course, you can either search then or refine by time, then search or refine by tutor then search
            //If a refinement is not filled, you will not see the other possibilities.

    {
        private int stateOfProgress;    //This variable will tell what search refinements are being used
        private string user;
        private DateTime startTime, endTime, prevTime1, prevTime2;
        private string course;
        private DateTime date;
        private DateTime time;
        private string tutor;
        private string place;
        private bool initialValue1;

        public SearchRefinementForm()
        {
            InitializeComponent();
            initializeTimers();
            stateOfProgress = 0;
        }

        public SearchRefinementForm(string username)
        {
            InitializeComponent();
            initializeTimers();
            stateOfProgress = 0;
            user = username;

            Database db = new Database();
            List<string> allProfileInfo = db.getProfileInfo(user);

            for (int i = 4; i < 7; i++)
            {
                if (allProfileInfo[i] != "")
                    comboCourse.Items.Add(allProfileInfo[i]);
            }

            this.Width = 289;
            this.Height = 300;

            date = DateTime.MinValue;
            time = DateTime.MinValue;
            tutor = "";
            place = "";

        }


        private void initializeTimers()
        {
            dateTimeTime1.Format = DateTimePickerFormat.Custom;
            dateTimeTime1.CustomFormat = "hh:mm tt";

            DateTime dt = DateTime.Now;
            if (dt.Minute % 15 > 15)
            {
                initialValue1 = true;
                dateTimeTime1.Value = dt.AddMinutes(dt.Minute % 15);
            }
            else
            {
                initialValue1 = true;
                dateTimeTime1.Value = dt.AddMinutes(-(dt.Minute % 15));
            }

            prevTime1 = dateTimeTime1.Value;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (initialValue1)
            {
                initialValue1 = false;
                return;
            }

            DateTime dt = dateTimeTime1.Value;
            TimeSpan diff = dt - prevTime1;


            if (diff.Ticks < 0)
                dateTimeTime1.Value = prevTime1.AddMinutes(-15);
            else
                dateTimeTime1.Value = prevTime1.AddMinutes(15);

            prevTime1 = dateTimeTime1.Value;
        }


        private void btnMoreFields_Click(object sender, EventArgs e)
        {
            switch (stateOfProgress)
            {
                case 0:
                    stateOfProgress = 1;
                    btnMoreFields.Text = "Show Less Criteria";
                    this.Width = 516;
                    break;
                case 1:
                    stateOfProgress = 0;
                    btnMoreFields.Text = "Show More Criteria";
                    this.Width = 289;
                    date = DateTime.MinValue;
                    time = DateTime.MinValue;
                    tutor = "";
                    place = "";
                    break;
            }
           

            //course = comboCourse.SelectedItem.ToString();
            lblDate.Visible = true;
            dateTimeDay1.Visible = true;
            //date = dateTimeDay1.Value;
            lblTime.Visible = true;
            dateTimeTime1.Visible = true;
            //time = dateTimeTime1.Value;
            lblTutor.Visible = true;
            comboTutor.Visible = true;
            //tutor = comboTutor.SelectedItem.ToString();
            lblPlace.Visible = true;
            comboPlace.Visible = true;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Get all the search criteria.


            MessageBox.Show("Course = " + course + "\nDate = " + date + "\nTime = " + time + "\nTutor = " + tutor + "\nPlace = " + place);

            Database db = new Database();
            List<Appointment> matchesList;

            switch (stateOfProgress)
            {
                case 0:
                    //matchesList = db.getCorrespondingAppointments(string course);
                    break;
                case 1:
                    //matchesList = db.getCorrespondingAppointments(string course, DateTime date, DateTime time, string tutor, string place);
                    break;
            }


            //Garrett: Going to need a function that retrieves all appointments.
            /*Database function: 
             * private List<Appointment> getCorrespondingAppointments(string course, DateTime date, DateTime time, string tutor, string place)
             * Pre: all arguments could be null or they might have a value
             * Post: returns a list of all of the free time appointments that match the argumental criteria.
             * Function: for the arguments which are not null, function adds appointments to the list if they match the input arguments
             * */
        }

        private void checkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDate.Checked)
                date = dateTimeDay1.Value.Date;
            else
                date = DateTime.MinValue;
        }

        private void checkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTime.Checked)
                time = dateTimeTime1.Value;
            else
                time = DateTime.MinValue;
        }

        private void checkTutor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTutor.Checked)
                tutor = comboTutor.SelectedItem.ToString();
            else
                tutor = "";
        }

        private void checkPlace_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPlace.Checked)
                place = comboPlace.SelectedItem.ToString();
            else
                place = "";
        }

        private void comboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            course = comboCourse.SelectedItem.ToString();
        }


    }
}
