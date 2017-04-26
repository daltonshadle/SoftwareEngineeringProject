using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tutor_Master
{
    public partial class MatchingAppointmentForm : Form
    {
        //constants
        private const string FREETYPE = "Free Time Session", TUTORTYPE = "Tutoring Session";

        //all the private data
        private string course;
        private DateTime startTime, endTime;
        private DateTime prevTime1, prevTime2; //this is just for the 15 minute increments for time
        private DateTime prevDate1, prevDate2; //this is just for syncing the date pickers
        private string tutorProf;
        private string tuteeProf;
        private string builderProf;
        private bool isFreeTimeSession;
        private int type;

        private List<string> builderTutorCourses;
        private List<string> builderTuteeCourses;
        private List<string> builderCourseApprovedList;

        private bool isTutee, isTutor, initialValue1, initialValue2;

        //all functions
        //constructor
        public MatchingAppointmentForm()
        {
            InitializeComponent();
            initializeTimers();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }

        //constructor by username and bools
        public MatchingAppointmentForm(string builderProfileName, bool isTutor, bool isTutee)
        {
            InitializeComponent();
            initializeTimers();
            this.Icon = Tutor_Master.Properties.Resources.favicon;

            this.isTutee = isTutee;
            this.isTutor = isTutor;
            builderProf = builderProfileName;

            initViews();
        }

        //function for initializing data in the views of the form
        private void initViews() 
        {
            panelCourse.Visible = false;
            panelMeetingPlace.Visible = false;
            panelOtherProfile.Visible = false;
            dateTimeTime1.ShowUpDown = true;
            dateTimeTime2.ShowUpDown = true;
            course = "";

            prevDate1 = dateTimeDay1.Value;
            prevDate2 = dateTimeDay2.Value;

            initializeBuilderApptTypeCollection();
            initializeBuilderCourseCollection();
            initMeetingPlacesComboBox();
            
        }

        //function to initialize appt type by tutor/tutee status
        private void initializeBuilderApptTypeCollection()
        {
            cbxTypeAppt.Items.Clear();
            if (isTutor)
            {
                cbxTypeAppt.Items.Add(FREETYPE);
            }

            if (isTutee)
            {
                cbxTypeAppt.Items.Add(TUTORTYPE);
            }
        }

        //function that initializes courses by appt type and username
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

        //function gets all profiles that match with the course and appt type
        private void getValidProfiles(int type)
        {
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

                    for (int i = 0; i < usernameList.Count; i++)
                    {
                        cbxProfileList.Items.Add(usernameList[i]);
                    }

                }
                else
                {
                    //Figure out if there are any tutors
                    List<string> tutors = db.getAllTutorsForCourse(course);
                    if (tutors.Count == 0)
                    {
                        //If there are no tutors available for a course, the faculty should be notified.
                        if (MessageBox.Show("Notify faculty to add a tutor?", "No tutors available for " + course, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string faculty = db.getFacultyApprover(course);
                            db.sendMessage(builderProf, faculty, "Tutor needed for " + course, "No tutor available for course: " + course + ".\n" + builderProf + " requested that you consult a student about becoming a tutor for this course.", true, DateTime.Now, course, -1);
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



        }

        //function is just to make sure that appointments don't overlap
        private void offsetStartAndEndTimes()
        {
            //ex. one ends at 3:00:00 and one starts at 3:00:01
            startTime = startTime.AddMilliseconds(-startTime.Millisecond);
            startTime = startTime.AddSeconds(-startTime.Second + 1);
            endTime = endTime.AddMilliseconds(-endTime.Millisecond);
            endTime = endTime.AddSeconds(-endTime.Second);
        }

        //checks to see if there is a time conflict
        private bool isTimeInBetween(DateTime startTime, DateTime endTime, DateTime startTimeInQuestion, DateTime endTimeInQuestion)
        {
            return (startTime <= endTimeInQuestion && startTimeInQuestion <= endTime);
        }

        //checks to see if builder is tutor
        private bool isBuilderTheTutor(string meetingType)
        {
            return (meetingType.Equals(FREETYPE));
        }

        //checks to see if panels are visible
        private bool courseAndProfilePanelVisisbile()
        {
            return panelCourse.Visible && panelOtherProfile.Visible && panelMeetingPlace.Visible;
        }

        private bool verifyMeetingPlace()
        {
            String tempPlace = cbxMeetingPlace.Text.ToString();
            return (!tempPlace.Equals(""));
        }

        private bool verifyTimes()
        {
            bool good = false;
            startTime = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            endTime = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;
            TimeSpan apptSpan = endTime - startTime;

            good = (startTime > DateTime.Now && endTime > DateTime.Now &&
                    startTime < endTime && apptSpan.TotalMilliseconds <= 3 * 60 * 60 * 1000); //appt time up to 3 hours

            //commenting this to fix the overflow on datetime problem

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
                    if (!good)
                    {
                        MessageBox.Show("One of your appointments is already scheduled for this time.");
                    }
                    it++;
                }

                it = 0;
                while (good && it < otherAppoint.Count)
                {
                    bool temp = false;

                    Appointment a = otherAppoint[it];
                    temp = !isTimeInBetween(a.getStartTime(), a.getEndTime(), startTime, endTime);

                    good = temp;
                    if (!good)
                    {
                        MessageBox.Show("One of the tutor's appointments is already scheduled for this time.");
                    }
                    it++;
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

                    if (!good)
                    {
                        MessageBox.Show("One of your appointments is already scheduled for this time.");
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

        private bool verifyWeeklyTimes()
        {
            bool good = true;
            Database db = new Database();
            startTime = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            endTime = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;
            DateTime apptStart = startTime;
            DateTime apptEnd = endTime;

            good = (apptStart > DateTime.Now && apptEnd > DateTime.Now &&
                    apptStart < apptEnd && (apptEnd.Hour - apptStart.Hour) <= 3);

            //commenting this to fix the overflow on datetime problem
            if (good)
            {
                List<Appointment> builderAppoint = db.getDailyAppointments(builderProf);
                List<Appointment> otherAppoint = db.getDailyAppointments(cbxProfileList.Text.ToString());

                int temp = 0;
                int currentWeeklyAppt = 0;
                int totalWeeklyAppt = (int)udbWeeks.Value;

                //free time session check
                if (isFreeTimeSession)
                {
                    while (good && currentWeeklyAppt < totalWeeklyAppt)
                    {
                        apptStart = apptStart.AddDays(currentWeeklyAppt * 7);
                        apptEnd = apptEnd.AddDays(currentWeeklyAppt * 7);
                        temp = 0;
                        while (good && temp < builderAppoint.Count)
                        {
                            Appointment a = builderAppoint[temp];
                            good = !isTimeInBetween(a.getStartTime(), a.getEndTime(), apptStart, apptEnd);

                            temp++;
                        }
                        currentWeeklyAppt++;
                    }
                }
                else
                {
                    //checking both profile times to see if they conflict with the start and end times
                    currentWeeklyAppt = 0;
                    apptStart = startTime;
                    apptEnd = endTime;

                    while (good && currentWeeklyAppt < totalWeeklyAppt)
                    {
                        temp = 0;
                        apptStart = apptStart.AddDays(currentWeeklyAppt * 7);
                        apptEnd = apptEnd.AddDays(currentWeeklyAppt * 7);

                        while (good && temp < builderAppoint.Count)
                        {
                            Appointment a = builderAppoint[temp];
                            good = !isTimeInBetween(a.getStartTime(), a.getEndTime(), apptStart, apptEnd);

                            temp++;
                        }

                        temp = 0;
                        while (good && temp < otherAppoint.Count)
                        {
                            Appointment a = otherAppoint[temp];
                            good = !isTimeInBetween(a.getStartTime(), a.getEndTime(), apptStart, apptEnd);

                            temp++;
                        }

                        currentWeeklyAppt++;
                    }
                }

            }

            return good;
        }

        //function that combines all verify functions to see if all is good
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

        private void initializeTimers()
        {
            dateTimeTime1.Format = DateTimePickerFormat.Custom;
            dateTimeTime1.CustomFormat = "hh:mm tt";
            dateTimeTime2.Format = DateTimePickerFormat.Custom;
            dateTimeTime2.CustomFormat = "hh:mm tt";

            DateTime dt = DateTime.Now;
            if (dt.Minute % 15 > 15)
            {
                initialValue1 = true;
                initialValue2 = true;
                dateTimeTime1.Value = dt.AddMinutes(dt.Minute % 15 + 15);
                dateTimeTime2.Value = dt.AddMinutes(dt.Minute % 15 + 30);
            }
            else
            {
                initialValue1 = true;
                initialValue2 = true;
                dateTimeTime1.Value = dt.AddMinutes(-(dt.Minute % 15) + 15);
                dateTimeTime2.Value = dt.AddMinutes(-(dt.Minute % 15) + 30);
            }

            prevTime1 = dateTimeTime1.Value;
            prevTime2 = dateTimeTime2.Value;
        }

        //*********************************All listener functions*********************************//
        private void cbxTypeAppt_SelectedIndexChanged(object sender, EventArgs e)
        {
                if(cbxTypeAppt.Text.ToString().Equals(FREETYPE)){
                    //freetime appt for type FREETYPE
                    panelCourse.Visible = false;
                    panelMeetingPlace.Visible = false;
                    panelOtherProfile.Visible = false;
                    isFreeTimeSession = true;
                }   

                if(cbxTypeAppt.Text.ToString().Equals(TUTORTYPE)){
                    //add tutee courses here for type TUTORTYPE
                    type = 2;

                    cbxCourseList.Items.Clear();
                    cbxCourseList.Text = "";

                    for (int x = 0; x < builderTuteeCourses.Count; x++) { 
                        if (builderTuteeCourses[x] != "")
                            cbxCourseList.Items.Add(builderTuteeCourses[x]);
                    }

                    panelCourse.Visible = true;
                    panelMeetingPlace.Visible = true;
                    panelOtherProfile.Visible = true;
                    isFreeTimeSession = false;
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
            string place = cbxMeetingPlace.Text.ToString();
            string otherProfName = cbxProfileList.Text.ToString();
            course = cbxCourseList.Text.ToString();

            int numWeeks = (int) udbWeeks.Value;

            if (verifyEverything())
            {
                if (isFreeTimeSession)
                {
                    if (cbxWeeklyApt.Checked)
                    {
                        if (verifyWeeklyTimes()) 
                        {
                            for (int i = 0; i < udbWeeks.Value; i++) {
                                offsetStartAndEndTimes();
                                DateTime tempStart = startTime, tempEnd = endTime;
                                tempStart = tempStart.AddDays(7 * i);
                                tempEnd = tempEnd.AddDays(7 * i);

                                Appointment a = new Appointment(tempStart, tempEnd, builderProf);
                                //free time needs no message
                                a.addAppointmentToDatabase(false);
                            }
                        }
                    }
                    else
                    {
                        offsetStartAndEndTimes();
                        Appointment a = new Appointment(startTime, endTime, builderProf);
                        //free time needs no message
                        a.addAppointmentToDatabase(false);
                    }
                }
                else
                {
                    if (isBuilderTheTutor(type))
                    {
                        tutorProf = builderProf;
                        tuteeProf = otherProfName;
                    }
                    else
                    {
                        tuteeProf = builderProf;
                        tutorProf = otherProfName;
                    }

                    if (cbxWeeklyApt.Checked)
                    {
                        if (verifyWeeklyTimes())
                        {
                            for (int i = 0; i < udbWeeks.Value; i++)
                            {
                                offsetStartAndEndTimes();
                                DateTime tempStart = startTime, tempEnd = endTime;
                                tempStart = tempStart = tempStart.AddDays(7 * i);
                                tempEnd = tempEnd = tempEnd.AddDays(7 * i);

                                Appointment a = new Appointment(type, place, course, tempStart, tempEnd, tutorProf, tuteeProf, false, "TuteeMatch");
                                int lastId = a.addAppointmentToDatabase(true);
                                

                                string msg = builderProf + " has requested to make a weekly tutoring appointment for course: " + course + " at " + startTime.ToShortTimeString() + " on " + startTime.DayOfWeek.ToString() + "s";
                                Database db = new Database();
                              
                                db.sendMessage(builderProf, otherProfName, "Request for appointment", msg, false, DateTime.Now, course, lastId);
                            }
                        }
                    }
                    else
                    {
                        offsetStartAndEndTimes();
                        Appointment a = new Appointment(type, place, course, startTime, endTime, tutorProf, tuteeProf, false, "TuteeMatch");
                        int lastId = a.addAppointmentToDatabase(true);

                        //This is where we will send a message if a person is doing a learning appointment
                        //send message to other person.

                        string msg = builderProf + " has requested to make a tutoring appointment for course: " + course + " at " + startTime.ToShortTimeString() + " on " + startTime.ToShortDateString();
                        Database db = new Database();
                        db.sendMessage(builderProf, otherProfName, "Request for appointment", msg, false, DateTime.Now, course, lastId);
                    }
                }
                this.Hide();
                this.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (initialValue1)
            {
                initialValue1 = false;
                return;
            }
            
            DateTime dt = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            DateTime tempHold = dt;
            TimeSpan diff = dt - prevTime1;

            double totalMin = diff.TotalHours * 60;

            //just checking to see if user invoked or program invoked
            if (Math.Abs(totalMin) != 15)
            {
                //user invoked and the checking if minutes were changed
                if (Math.Abs(totalMin) <= 59)
                {
                    //minutes were changed
                    if (totalMin < 0)
                    {
                        //minutes were lowered and checking for the wrap around
                        //at the top of the hour
                        if (totalMin == -59)
                        {
                            tempHold = prevTime1.AddMinutes(15);
                        }
                        else
                        { 
                            tempHold = prevTime1.AddMinutes(-15);
                        }
                    }
                    else
                    {
                        //minutes were raised and checking for the wrap around
                        //at the top of the hour
                        if (totalMin > 0)
                        {
                            if (totalMin == 59)
                            {
                                tempHold = prevTime1.AddMinutes(-15);
                            }
                            else
                            {
                                tempHold = prevTime1.AddMinutes(15);
                            }
                        }
                    }
                }
            }

            if (tempHold >= dateTimeTime2.Value)
            {
                dateTimeTime2.Value = tempHold.AddMinutes(15);
            }

            dateTimeTime1.Value = tempHold;
            prevTime1 = dateTimeTime1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (initialValue2)
            {
                initialValue2 = false;
                return;
            }

            DateTime dt = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;
            DateTime tempHold = dt;
            TimeSpan diff = dt - prevTime2;

            double totalMin = diff.TotalHours * 60;

            //just checking to see if user invoked or program invoked
            if (Math.Abs(totalMin) != 15)
            {
                //user invoked and the checking if minutes were changed
                if (Math.Abs(totalMin) <= 59)
                {
                    //minutes were changed
                    if (totalMin < 0)
                    {
                        //minutes were lowered and checking for the wrap around
                        //at the top of the hour
                        if (totalMin == -59)
                        {
                            tempHold = prevTime2.AddMinutes(15);
                        }
                        else
                        {
                            tempHold = prevTime2.AddMinutes(-15);
                        }
                    }
                    else
                    {
                        if (totalMin > 0)
                        {
                            //minutes were raised and checking for wrap around
                            //at the top of the hour
                            if (totalMin == 59)
                            {
                                tempHold = prevTime2.AddMinutes(-15);
                            }
                            else
                            {
                                tempHold = prevTime2.AddMinutes(15);
                            }
                        }
                    }
                }
            }

            if (tempHold <= dateTimeTime1.Value)
            {
                dateTimeTime1.Value = tempHold.AddMinutes(-15);
            }

            dateTimeTime2.Value = tempHold;
            prevTime2 = dateTimeTime2.Value;
        }

        private void cbxWeeklyApt_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxWeeklyApt.Checked)
            {
                panelNumberWeeklyAppts.Visible = true;
            }
            else 
            {
                panelNumberWeeklyAppts.Visible = false;
            }
        }

        private void dateTimeDay1_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan dateSpan = dateTimeDay1.Value - dateTimeDay2.Value;

            if (Math.Abs(dateSpan.TotalDays) > 1) {
                dateTimeDay2.Value = dateTimeDay1.Value;
            }
        }

        private void dateTimeDay2_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan dateSpan = dateTimeDay1.Value - dateTimeDay2.Value;

            if (Math.Abs(dateSpan.TotalDays) > 1)
            {
                dateTimeDay1.Value = dateTimeDay2.Value;
            }
        }

        private void initMeetingPlacesComboBox() 
        {
            Database db = new Database();
            List<string> placeList = db.getAllLocations();

            for(int i = 0; i < placeList.Count; i++)
            {
                cbxMeetingPlace.Items.Add(placeList[i]);
            }
        }



    }
}
