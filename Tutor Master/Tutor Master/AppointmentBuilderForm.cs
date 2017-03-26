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
    public partial class AppointmentBuilderForm : Form
    {
        private const string FREETYPE = "Free Time", LEARNTYPE = "Learning (Tuteeing)", TEACHTYPE = "Teaching (Tutoring)";

        //all the private data
        private string meetingPlace;
        private string course;
        private DateTime startTime, endTime;
        private Profile tutorProf;
        private Profile tuteeProf;
        private Profile freeTimeProf;
        private Profile builderProf;
        private bool isFreeTimeSession;
        private int apptID;

        private bool isTutee, isTutor;

        public AppointmentBuilderForm()
        {
            InitializeComponent();
            initViews();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }

        public AppointmentBuilderForm(Profile buildingProfile, bool isTutor, bool isTutee)
        {
            InitializeComponent();
            initViews();
            this.Icon = Tutor_Master.Properties.Resources.favicon;

            this.isTutor = isTutor;
            this.isTutee = isTutee;

            builderProf = buildingProfile;
        }

        private void initViews() {
            panelCourseAndPlace.Visible = false;
            panelOtherProfile.Visible = false;
            dateTimeTime1.ShowUpDown = true;
            dateTimeTime2.ShowUpDown = true;

            initializeCourseCollection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            startTime = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            endTime = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;
            string type = cbxTypeAppt.Text.ToString();
            string place = txtMeetingPlace.Text.ToString();
            string otherProfName = txtOtherProf.Text.ToString();
            string course = cbxCourseList.Text.ToString();

            if (verifyEverything())
            {
                if (isFreeTime(type))
                {
                    Appointment a = new Appointment(startTime, endTime, builderProf);
                    a.addAppointmentToDatabase();
                }
                else 
                { 
                    if (isBuilderTheTutor(type))
                    {
                        tuteeProf = new Profile(otherProfName);
                        tutorProf = builderProf;
                    }
                    else
                    {
                        tuteeProf = builderProf;
                        tutorProf = new Profile(otherProfName);
                    }

                    Appointment a = new Appointment(type, place, course, startTime, endTime, (Tutor)tutorProf, (Tutee)tuteeProf);
                    a.addAppointmentToDatabase();
                }
            }
        }

        private void cbxTypeAppt_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTypeAppt.SelectedIndex) {
                case 0:
                    panelCourseAndPlace.Visible = false;
                    panelOtherProfile.Visible = false;
                    break;
                case 1:

                case 2:
                    panelCourseAndPlace.Visible = true;
                    panelOtherProfile.Visible = true;
                    break;
            }
        }

        private void initializeCourseCollection() {
            //Garrett need a function to get all tutee and tutor courses for builder preferably to string

            int totalNumCourses = 0;

            //intialize totalNumCourses
            for (int i = 0; i < totalNumCourses; i++) { 
                string course = "course";
                //initialize course one at a time
                cbxCourseList.Items.Add(course);   
            }

        }

        private bool verifyApptType() 
        {
            String tempType = cbxTypeAppt.Text.ToString();
            return (!tempType.Equals(""));
        }

        private bool verifyOtherProfile() 
        { 
            //Garrett need a function to check if profile is in database
            String tempProf = txtOtherProf.Text.ToString();

            return (!tempProf.Equals(""));
        }

        private bool verifyMeetingPlace() 
        {
            String tempPlace = txtMeetingPlace.Text.ToString();
            return (!tempPlace.Equals(""));
        }

        private bool verifyTimes()
        {
            bool good = false;

            DateTime firstDate = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            DateTime secondDate = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;

            good = (firstDate > DateTime.Now && secondDate > DateTime.Now &&
                firstDate < secondDate && (secondDate.Hour - firstDate.Hour) < 3);

            return good;
        }

        private bool verifyCourse()
        {
            //verify that the course is available for both the tutor and the tutee
            String tempCourse = cbxCourseList.Text.ToString();
            return (!tempCourse.Equals(""));
        }

        private bool verifyEverything()
        {
            bool good = true;

            if (!verifyApptType())
            {
                good = false;
                MessageBox.Show("Please choose an appointment type.");
            }
            if (courseAndProfilePanelVisisbile() && !verifyCourse())
            {
                good = false;
                MessageBox.Show("Please enter a course.");
            }
            if (courseAndProfilePanelVisisbile() && !verifyMeetingPlace())
            {
                good = false;
                MessageBox.Show("Please enter a meeting place.");
            }
            if (courseAndProfilePanelVisisbile() && !verifyOtherProfile())
            {
                good = false;
                MessageBox.Show("Please enter a valid profile.");
            }
            if (!verifyTimes())
            {
                good = false;
                MessageBox.Show("Please enter valid times.");
            }

            return good;
        }
        
        private bool courseAndProfilePanelVisisbile(){
            return panelCourseAndPlace.Visible && panelOtherProfile.Visible;
        }

        private bool isFreeTime(string meetingType) {
            return (meetingType.Equals(FREETYPE));
        }

        private bool isBuilderTheTutor(string meetingType)
        {
            return (meetingType.Equals(TEACHTYPE) && !meetingType.Equals(FREETYPE));
        }
    }
}
