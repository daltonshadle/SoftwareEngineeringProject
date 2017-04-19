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
        private Appointment buildingAppt;
        private string userProf;
        private bool isApproved;
        private string source;

        public AppointmentBlock()
        {
            InitializeComponent();
        }

        public AppointmentBlock(Appointment a, string username)
        {
            InitializeComponent();
            buildingAppt = a;
            apptCourse = a.getCourse();
            apptPlace = a.getMeetingPlace();
            apptTime = a.getStartTime().ToShortTimeString();
            apptType = a.getMeetingType();
            endDate = a.getEndTime().ToShortTimeString();
            id = a.getID();
            userProf = username;
            isApproved = a.getIsApproved();
            source = a.getSource();

            bool b = a.getIsFreeTimeSession();
            if (b)
            {
                firstName = a.getFreeTimeProf();
                lblSecond.Visible = false;
            }
            else
            {
                firstName = a.getTutor();
                lblSecond.Visible = true;
                secondName = a.getTutee();
            }
            setViews();
        }

        private void setViews() {
            lblCourse.Text = apptCourse;
            lblFirst.Text = firstName;
            lblSecond.Text = secondName;
            lblTimeAndPlace.Text = apptTime + " " + apptPlace;

            setBackColor();
        }

        private void setBackColor() {
            if (!buildingAppt.getIsFreeTimeSession())
            {
                lblAppointmentType.Text = "Learning";
                apptType = "Learning";
                if (buildingAppt.getIsApproved())
                    this.BackColor = Color.LimeGreen;
                else
                    this.BackColor = Color.Red;
            }
            else
            {
                lblAppointmentType.Text = "Freetime";
                apptType = "Freetime";
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
            Form form = new AppointmentInfoForm(this.apptType, this.apptPlace, this.apptCourse, this.apptTime, this.endDate, this.firstName, this.secondName, this.id, this.userProf, this.isApproved, this.source);
            form.FormClosing += new FormClosingEventHandler(AppointmentForm_FormClosing);
            //Form form = new AppointmentInfoForm(this.apptType, this.id);
            form.Show();
            //this.Hide();
        }

        void AppointmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Database db = new Database();
            Appointment a = db.getAppointmentById(id);

            isApproved = a.getIsApproved();

            setViews();

            //need to hide the other form
            //throw new NotImplementedException();
        }


    }
}
