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

        private const String LEARN = "Learning (Tuteeing)";
        private const String TEACH = "Teaching (Tutoring)";
        private const String FREE = "Free Time";
        private Profile builderProf;
        private Tutor builderTutorProf;
        private Tutee builderTuteeProf;
        private Tutor otherTutorProf;
        private Tutee otherTuteeProf;
        private DateTime firstDate;
        private DateTime secondDate;
        private bool isTutor;
        private bool isTutee;

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

            builderProf = buildingProfile;
            this.isTutor = isTutor;
            this.isTutee = isTutee;

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
            firstDate = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            secondDate = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;
            string type = cbxTypeAppt.Text.ToString();
            string place = txtMeetingPlace.Text.ToString();
            string otherProfName = txtOtherProf.Text.ToString();
            string course = cbxCourseList.Text.ToString();

            if (verifyEverything())
            {

                if (type.Equals(FREE))
                {
                    //move on and check dates for free time
                    if (isTutee)
                    {
                        Appointment a = new Appointment(type, firstDate, secondDate, (Tutee)builderProf);
                        Tutee temp = (Tutee)builderProf;
                        temp.addApptToTuteeSchedule(a);
                        a.addAppointmentToDatabase();
                    }
                    else 
                    {
                        Appointment a = new Appointment(type, firstDate, secondDate, (Tutor)builderProf);
                        Tutor temp = (Tutor)builderProf;
                        temp.addApptToTutorSchedule(a);
                        a.addAppointmentToDatabase();
                    }
                }
                else if (type.Equals(LEARN))
                {
                    //check dates and times, courses, meeting place, profile
                    if (verifyEverything()) 
                    {
                        Database db = new Database();
                        List<string> info = db.getProfileInfo(otherProfName);
                        string[] courses = new string[4];

                        //maybe write a for loop for it later
                        course.Insert(0, info[8]);
                        course.Insert(1, info[9]);
                        course.Insert(2, info[10]);
                        course.Insert(3, info[11]);

                        otherTutorProf = new Tutor(otherProfName, courses);

                        Tutee temp = (Tutee)builderProf;
                        //Dalton, yo really fricked the pooch on this one. Need to go through this again and sort shit out.
                        Appointment a = new Appointment(type, place, course, firstDate, secondDate, otherTutorProf, temp);
                    }
                }
                else {
                    Database db = new Database();
                    List<string> info = db.getProfileInfo(otherProfName);
                    string[] courses = new string[4];

                    //maybe write a for loop for it later
                    course.Insert(0, info[4]);
                    course.Insert(1, info[5]);
                    course.Insert(2, info[6]);
                    course.Insert(3, info[7]);

                    otherTuteeProf = new Tutee(otherProfName, courses);

                    Tutor temp = (Tutor)builderProf;
                    //Dalton, yo really fricked the pooch on this one. Need to go through this again and sort shit out.
                    Appointment a = new Appointment(type, place, course, firstDate, secondDate, temp, otherTuteeProf);
                
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
            //Garrett need a function to get all courses preferably to string
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
    }

    
}
