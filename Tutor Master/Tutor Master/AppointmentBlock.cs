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
    public partial class AppointmentBlock : UserControl
    {

        private string apptType;
        private string apptPlace;
        private string apptCourse;
        private string apptTime;
        private string firstName;
        private string secondName;

        public AppointmentBlock()
        {
            InitializeComponent();
        }

        public AppointmentBlock(Appointment a)
        {
            InitializeComponent();
            apptCourse = a.getCourse();
            apptPlace = a.getMeetingPlace();
            apptTime = a.getStartTime().ToShortTimeString();


            bool b = a.getIsFreeTimeSession();
            if (b) {
                apptType = "Freetime";
                firstName = a.getFreeTimeProf();
                lblSecond.Visible = false;
            }
            else {
                apptType = "Learning";
                firstName = a.getTutor();
                lblSecond.Visible = true;
                secondName = a.getTutee();
            }
            setViews();
        }

        private void setViews() {
            lblAppointmentType.Text = apptType;
            lblCourse.Text = apptCourse;
            lblFirst.Text = firstName;
            lblSecond.Text = secondName;
            lblTimeAndPlace.Text = apptTime + " " + apptPlace;

            setBackColor();
        }

        private void setBackColor() {
            if (apptType.Equals("Learning"))
            {
                this.BackColor = Color.Cyan;
            }
            if (apptType.Equals("Freetime"))
            {
                this.BackColor = Color.Yellow;
            }
        }
        
        public string getAppointmentName() {
            return apptType;
        }

        public void setAppointmentName(string type) {
            lblAppointmentType.Text = type;
            apptType = type;

            setBackColor();
        }

        public string getTimeAndPlace()
        {
            return apptTime + " " + apptPlace;
        }

        public void setTimeAndPlace(string place, DateTime time)
        {
            lblTimeAndPlace.Text = time.ToShortTimeString() + " " + place;
        }

        public string getCourse()
        {
            return apptCourse;
        }

        public void setCourse(string course)
        {
            lblCourse.Text = course;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public void setAppointmentOwnerName(string user)
        {
            string name = user;
            lblAppointmentType.Text = name;
        }

        private void AppointmentBlock_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Appointment clicked");
            Form form = new AppointmentInfoForm(this.apptType, this.apptPlace, this.apptCourse, this.apptTime, this.firstName, this.secondName);
            form.Show();
            //this.Hide();
        }

    }
}
