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
        //private DateTime startTime, endTime, prevTime1, prevTime2;
        private string course;
        private DateTime date;
        private DateTime time;
        private string tutor;
        private string place;

        public SearchRefinementForm()
        {
            InitializeComponent();
            //initializeTimers();
            stateOfProgress = 0;
        }

        public SearchRefinementForm(string username)
        {
            InitializeComponent();
            //initializeTimers();
            stateOfProgress = 0;
            user = username;

            Database db = new Database();
            List<string> allProfileInfo = db.getProfileInfo(user);

            for (int i = 4; i < 7; i++)
            {
                if (allProfileInfo[i] != "")
                    comboCourse.Items.Add(allProfileInfo[i]);
            }

        }
        
        private void comboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            course = comboCourse.SelectedItem.ToString();
            lblDate.Visible = true;
            dateTimeDay1.Visible = true;
            stateOfProgress = 1;
        }

        private void dateTimeDay1_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimeDay1.Value;
            lblTime.Visible = true;
            dateTimeTime1.Visible = true;
            stateOfProgress = 2;
        }

        private void dateTimeTime1_ValueChanged(object sender, EventArgs e)
        {
            time = dateTimeTime1.Value;
            lblTutor.Visible = true;
            comboTutor.Visible = true;
            stateOfProgress = 3;
        }

        private void comboTutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            tutor = comboTutor.SelectedItem.ToString();
            lblPlace.Visible = true;
            comboPlace.Visible = true;
            stateOfProgress = 4;
        }

        /*private void initializeTimers()
        {
            dateTimeTime1.Format = DateTimePickerFormat.Custom;
            dateTimeTime1.CustomFormat = "hh:mm tt";

            DateTime dt = DateTime.Now;
            if (dt.Minute % 15 > 15)
            {
                dateTimeTime1.Value = dt.AddMinutes(dt.Minute % 15);

            }
            else
            {
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
        }*/

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            //Garrett: Going to need a function that retrieves all appointments.
            /*Database function: 
             * private List<Appointment> getCorrespondingAppointments(string course, DateTime date, DateTime time, string tutor, string place)
             * Pre: all arguments could be null or they might have a value
             * Post: returns a list of all of the free time appointments that match the argumental criteria.
             * Function: for the arguments which are not null, function adds appointments to the list if they match the input arguments
             * */


            /*switch (stateOfProgress)
            {
                case 0:
                    lblTime.Visible = false;
                    lblTutor.Visible = false;
                    lblPlace.Visible = false;


                    break;
                case 1:

                    break;
                case 2:
                    break;
                default:
                    break;

                    
            }*/
        }
    }
}
