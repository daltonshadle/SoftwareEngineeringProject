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
        private int id;
        private int user;
        private string endDate;

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
            apptType = a.getMeetingType();
            endDate = a.getEndTime().ToShortTimeString();
            id = a.getID();

            bool b = a.getIsFreeTimeSession();
            if (b) {
                firstName = a.getFreeTimeProf();
                lblSecond.Visible = false;
            }
            else {
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
            if (apptType.Equals("Tutoring"))
            {
                this.BackColor = Color.Cyan;
            }
            else if (apptType.Equals("Tuteeing"))
            {
                this.BackColor = Color.Cyan;
            }
            else if (apptType.Equals("Freetime"))
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
            Form form = new AppointmentInfoForm(this.apptType, this.apptPlace, this.apptCourse, this.apptTime, this.endDate, this.firstName, this.secondName, this.id);
            //Form form = new AppointmentInfoForm(this.apptType, this.id);
            form.Show();
            //this.Hide();
        }

    }
}
