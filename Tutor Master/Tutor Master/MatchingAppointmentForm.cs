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
    public partial class MatchingAppointmentForm : Form
    {
        private const string FREETYPE = "Free Time", LEARNTYPE = "Learning (Tuteeing)", TEACHTYPE = "Teaching (Tutoring)";

        //all the private data
        private string meetingPlace;
        private string course;
        private DateTime startTime, endTime;
        private string tutorProf;
        private string tuteeProf;
        private string freeTimeProf;
        private string builderProf;
        private bool isFreeTimeSession;
        private int type;

        private List<string> builderTutorCourses;
        private List<string> builderTuteeCourses;

        private bool isTutee, isTutor;

        public MatchingAppointmentForm()
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }

        public MatchingAppointmentForm(string builderProfileName, bool isTutor, bool isTutee)
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;

            this.isTutee = isTutee;
            this.isTutor = isTutor;
            builderProf = builderProfileName;

            initViews();
        }

        private void initViews() 
        {
            panelCourse.Visible = false;
            panelMeetingPlace.Visible = false;
            panelOtherProfile.Visible = false;
            dateTimeTime1.ShowUpDown = true;
            dateTimeTime2.ShowUpDown = true;
            course = "";

            initializeBuilderCourseCollection();
        }

        private void cbxTypeAppt_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTypeAppt.SelectedIndex)
            {
                case 0:
                    panelCourse.Visible = false;
                    panelMeetingPlace.Visible = false;
                    panelOtherProfile.Visible = false;
                    isFreeTimeSession = true;
                    break;
                case 1:
                    //add tutor courses here from tutee list
                    type = 1;

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

                    panelCourse.Visible = true;
                    panelMeetingPlace.Visible = true;
                    panelOtherProfile.Visible = true;
                    isFreeTimeSession = false;
                    break;
                case 2:
                    //add tutee courses here from tutor list
                    type = 2;

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

                    panelCourse.Visible = true;
                    panelMeetingPlace.Visible = true;
                    panelOtherProfile.Visible = true;
                    isFreeTimeSession = false;
                    break;
            }
        }

        private void initializeBuilderCourseCollection()
        {
            Database db = new Database();
            string tempName = builderProf;
            List<string> builderInfo = db.getProfileInfo(builderProf);

            bool isBuilderTutor;
            bool isBuilderTutee;

            if (builderInfo[2].Equals("True"))
            {
                isBuilderTutor = true;
            }
            else
            {
                isBuilderTutor = false;
            }

            if (builderInfo[3].Equals("True"))
            {
                isBuilderTutee = true;
            }
            else
            {
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

        private void getValidProfiles(int type) 
        { 
            //function gets all profiles that match with the course and appt type
            Database db = new Database();
            bool builderNeedsTutee = (type == 1);
            List<string> usernameList = new List<string>();

            if (!course.Equals(""))
            {
                cbxProfileList.Items.Clear();

                if (builderNeedsTutee)
                {
                    //find relevant profile with correct tutee course
                    usernameList = db.getUsernamesForCourse(course, false);

                    for(int i = 0; i < usernameList.Count; i++) {
                        cbxProfileList.Items.Add(usernameList[i]);
                    }

                }
                else
                {
                    //find relevant profile with correct tutor course
                    usernameList = db.getUsernamesForCourse(course, true);

                    for (int i = 0; i < usernameList.Count; i++)
                    {
                        cbxProfileList.Items.Add(usernameList[i]);
                    }
                }
            }



        }

        private void cbxCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            course = cbxCourseList.Text.ToString();
            getValidProfiles(type);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            startTime = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            endTime = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;
            string type = cbxTypeAppt.Text.ToString();
            string place = txtMeetingPlace.Text.ToString();
            string otherProfName = cbxProfileList.Text.ToString();
            course = cbxCourseList.Text.ToString();

            if (verifyEverything())
            {
                if (isFreeTimeSession)
                {
                    Appointment a = new Appointment(startTime, endTime, builderProf);
                    a.addAppointmentToDatabase();
                }
                else
                {
                    if (isBuilderTheTutor(type))
                    {
                        tutorProf = builderProf;
                    }
                    else
                    {
                        tuteeProf = builderProf;
                    }

                    //something is wrong here
                    Appointment a = new Appointment(type, place, course, startTime, endTime, tutorProf, tuteeProf);
                    a.addAppointmentToDatabase();
                }
                this.Hide();
                this.Close();
            }
        }

 

        private bool isTimeInBetween(DateTime startTime, DateTime endTime, DateTime startTimeInQuestion, DateTime endTimeInQuestion)
        {
            return (((startTimeInQuestion > startTime) && (startTimeInQuestion < endTime)) && ((endTimeInQuestion > startTime) && (endTimeInQuestion < endTime)));
        }

        private bool isBuilderTheTutor(string meetingType)
        {
            return (meetingType.Equals(TEACHTYPE) && !meetingType.Equals(FREETYPE));
        }

        private bool courseAndProfilePanelVisisbile()
        {
            return panelCourse.Visible && panelOtherProfile.Visible && panelMeetingPlace.Visible;
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

            if (good)
            {


                if (good)
                {
                    //checking both profile times to see if they conflict with the start and end times
                    Database db = new Database();
                    List<Appointment> builderAppoint = db.getDailyAppointments(builderProf);
                    List<Appointment> otherAppoint = db.getDailyAppointments(cbxProfileList.Text.ToString());

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
                if (isFreeTimeSession && good)
                {
                    Database db = new Database();
                    List<Appointment> builderAppoint = db.getDailyAppointments(builderProf);

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

        private bool verifyApptType()
        {
            String tempType = cbxTypeAppt.Text.ToString();
            return (!tempType.Equals(""));
        }

        private bool verifyOtherProfile()
        {
            return (!cbxProfileList.Text.Equals(""));
        }

        private bool verifyCourse()
        {
            return (!cbxCourseList.Text.Equals(""));
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

    }
}
