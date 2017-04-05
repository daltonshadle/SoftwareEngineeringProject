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

        private List<string> builderTutorCourses;
        private List<string> builderTuteeCourses;
        private List<string> builderCourseApprovedList;

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
            this.isTutor = isTutor;
            this.isTutee = isTutee;

            builderProf = buildingProfile;

            initViews();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }

        private void initViews() {
            panelCourseAndPlace.Visible = false;
            panelOtherProfile.Visible = false;
            dateTimeTime1.ShowUpDown = true;
            dateTimeTime2.ShowUpDown = true;

            initializeBuilderCourseCollection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            startTime = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            endTime = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;
            string type = cbxTypeAppt.Text.ToString();
            string place = txtMeetingPlace.Text.ToString();
            string otherProfName = txtOtherProf.Text.ToString();
            course = cbxCourseList.Text.ToString();

            if (verifyEverything())
            {
                if (isFreeTime(type))
                {
                    Appointment a = new Appointment(startTime, endTime, builderProf.getUsername());
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

                    Appointment a = new Appointment(type, place, course, startTime, endTime, tutorProf, tuteeProf, false);
                    a.addAppointmentToDatabase();

                    //This is where we will send a message if a person is doing a learning appointment
                    //send message to other person.

                    
                    string msg = builderProf + " has requested to make a tutoring appointment for course: " + course + " at " + startTime.ToShortDateString();
                    Database db = new Database();
                    db.sendMessage(builderProf.getUsername(), otherProfName, "Request for appointment", msg, true, DateTime.Now, course, a.getID());
                    db.sendMessage(builderProf.getUsername(), otherProfName, "Request for appointment", msg, true, DateTime.Now, course, a.getID());
                    db.sendMessage(builderProf.getUsername(), otherProfName, "Request for appointment", msg, true, DateTime.Now, course, a.getID());
                    db.sendMessage(builderProf.getUsername(), otherProfName, "Request for appointment", msg, true, DateTime.Now, course, a.getID());                 
                }
                this.Hide();
                this.Close();
            }

            
        }

        private void cbxTypeAppt_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTypeAppt.SelectedIndex) {
                case 0:
                    panelCourseAndPlace.Visible = false;
                    panelOtherProfile.Visible = false;
                    isFreeTimeSession = true;
                    break;
                case 1:
                    //add tutor courses here from tutee list
                    int i = 0;
                    cbxCourseList.Items.Clear();
                    if (builderTutorCourses.Count > 0)
                    {
                        string tempTutorCourse = builderTutorCourses[i];

                        while (!tempTutorCourse.Equals(""))
                        {
                            if (builderCourseApprovedList[i] == "True")
                            {
                                cbxCourseList.Items.Add(tempTutorCourse);
                            }
                            i++;
                            tempTutorCourse = builderTutorCourses[i];
                        }
                    }

                    panelCourseAndPlace.Visible = true;
                    panelOtherProfile.Visible = true;
                    isFreeTimeSession = false;
                    break;
                case 2:
                    //add tutee courses here from tutor list
                    int j = 0;
                    cbxCourseList.Items.Clear();
                    if (builderTuteeCourses.Count > 0)
                    {
                        string tempTuteeCourse = builderTuteeCourses[j];

                        while (!tempTuteeCourse.Equals(""))
                        {
                            cbxCourseList.Items.Add(tempTuteeCourse);
                            j++;
                            tempTuteeCourse = builderTuteeCourses[j];
                        }
                    }

                    panelCourseAndPlace.Visible = true;
                    panelOtherProfile.Visible = true;
                    isFreeTimeSession = false;
                    break;
            }
        }

        private void initializeBuilderCourseCollection() {
            //might need to rework stuff

            //Garrett need a function to get all tutee and tutor courses for builder preferably to string
            Database db = new Database();
            string tempName = builderProf.getUsername();
            List<string> builderInfo = db.getProfileInfo(builderProf.getUsername());
            
            bool isBuilderTutor;
            bool isBuilderTutee;

            if(builderInfo[2].Equals("True")){
                isBuilderTutor = true;
            }else{
                isBuilderTutor = false;
            }

            if(builderInfo[3].Equals("True")){
                isBuilderTutee = true;
            }else{
                isBuilderTutee = false;
            }


            if (isBuilderTutor)
            {
                builderTutorCourses = builderInfo.GetRange(8, 4);
                builderCourseApprovedList = builderInfo.GetRange(12, 4);
            }
            else 
            { 
                builderTutorCourses = new List<string>();
                builderCourseApprovedList = new List<string>();
            }
            if (isBuilderTutee)
            {
                builderTuteeCourses = builderInfo.GetRange(4, 4);
            }
            else
            {
                builderTuteeCourses = new List<string>();
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
            Database db = new Database();
            bool isGood = (db.isUsernameInDataBase(tempProf) && !tempProf.Equals(builderProf.getUsername()));
 
            return (isGood);
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

            if (verifyOtherProfile()&&good)
            {
                

                if (good)
                {
                    //checking both profile times to see if they conflict with the start and end times
                    Database db = new Database();
                    List<Appointment> builderAppoint = db.getDailyAppointments(builderProf.getUsername());
                    List<Appointment> otherAppoint = db.getDailyAppointments(txtOtherProf.Text.ToString());

                    int it = 0;

                    while (good && it < builderAppoint.Count)
                    {
                        bool temp = false;

                        Appointment a = builderAppoint[it];
                        temp = !isTimeInBetween(a.getStartTime(), a.getEndTime(), startTime, endTime);

                        good = temp;
                        it++;
                    }

                    it = 0;
                    while (good && it < otherAppoint.Count)
                    {
                        bool temp = false;

                        Appointment a = otherAppoint[it];
                        temp = !isTimeInBetween(a.getStartTime(), a.getEndTime(), startTime, endTime);

                        good = temp;
                        it++;
                    }
                }

            }
            else 
            {
                if (isFreeTimeSession) {
                    Database db = new Database();
                    List<Appointment> builderAppoint = db.getDailyAppointments(builderProf.getUsername());

                    int it = 0;

                    while (good && it < builderAppoint.Count)
                    {
                        bool temp = false;

                        Appointment a = builderAppoint[it];
                        temp = !isTimeInBetween(a.getStartTime(), a.getEndTime(), startTime, endTime);

                        good = temp;
                        it++;
                    }
                }
            }
            return good;
        }

        private bool verifyCourse()
        {
            //verify that the course is available for both the tutor and the tutee
            List<string> otherTutorCourses;
            List<string> otherTuteeCourses;

            Database db = new Database();
            string tempName = txtOtherProf.Text.ToString();
            List<string> otherInfo = db.getProfileInfo(tempName);

            bool builderNeedsTutor = cbxTypeAppt.Text.ToString().Equals(LEARNTYPE);
            bool isOtherTutor;
            bool isOtherTutee;
            bool good = false;

            if (otherInfo[2].Equals("True"))
            {
                isOtherTutor = true;
            }
            else
            {
                isOtherTutor = false;
            }

            if (otherInfo[3].Equals("True"))
            {
                isOtherTutee = true;
            }
            else
            {
                isOtherTutee = false;
            }

            if (builderNeedsTutor)
            {
                if (isOtherTutor)
                {
                    otherTutorCourses = otherInfo.GetRange(8, 4);
                    good = otherTutorCourses.Contains(course);
                }
                else
                {
                    otherTutorCourses = new List<string>();
                }
            }
            else
            {
                if (isOtherTutee)
                {
                    otherTuteeCourses = otherInfo.GetRange(4, 4);
                    good = otherTuteeCourses.Contains(course);
                }
                else
                {
                    otherTuteeCourses = new List<string>();
                }
            }
            
            return good;
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

        private bool isTimeInBetween(DateTime startTime, DateTime endTime, DateTime startTimeInQuestion, DateTime endTimeInQuestion) {
            return (((startTimeInQuestion > startTime) && (startTimeInQuestion < endTime)) && ((endTimeInQuestion > startTime) && (endTimeInQuestion < endTime)));
        }
    }
}
