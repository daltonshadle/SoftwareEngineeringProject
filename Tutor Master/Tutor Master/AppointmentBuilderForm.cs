﻿using System;
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

                    //something is wrong here
                    Appointment a = new Appointment(type, place, course, startTime, endTime, tutorProf, tuteeProf);
                    a.addAppointmentToDatabase();
                }
                this.Hide();
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
                    //add tutor courses here from tutee list
                    int i = 0;
                    cbxCourseList.Items.Clear();
                    if (builderTutorCourses.Count > 0)
                    {
                        string tempTutorCourse = builderTutorCourses[i];

                        while (!tempTutorCourse.Equals(""))
                        {
                            cbxCourseList.Items.Add(tempTutorCourse);
                            i++;
                            tempTutorCourse = builderTutorCourses[i];
                        }
                    }

                    panelCourseAndPlace.Visible = true;
                    panelOtherProfile.Visible = true;
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
            }
            else 
            { 
                builderTutorCourses = new List<string>();
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

            if (verifyOtherProfile())
            {
                DateTime firstDate = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
                DateTime secondDate = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;

                good = (firstDate > DateTime.Now && secondDate > DateTime.Now &&
                    firstDate < secondDate && (secondDate.Hour - firstDate.Hour) < 3);

                if (good)
                {
                    Database db = new Database();
                    List<Appointment> builderAppoint = db.getDailyAppointments(builderProf.getUsername());
                    List<Appointment> otherAppoint = db.getDailyAppointments(txtOtherProf.Text.ToString());



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

        private bool isTimeInBetween(DateTime startTime, DateTime endTime, DateTime timeInQuestion) {
            return ((timeInQuestion>startTime)&&(timeInQuestion<endTime));
        }
    }
}
