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
    public partial class AppointmentInfoForm : Form
    {

        private string apptType;
        private string apptPlace;
        private string apptCourse;
        private string apptTime;
        private DateTime apptDateStartTime;
        private DateTime apptDateStartDate;
        private string apptDateEndTime;
        private DateTime apptDateEndDate;
        private DateTime apptDateEnd;
        private string firstName;
        private string secondName;
        private int apptId;
        private string user, otherUser;
        private bool isApproved;
        private bool isFreeTime;
        private DateTime prevTime1, prevTime2; //this is just for the 15 minute increments for time
        private DateTime prevDate1, prevDate2; //this is just for syncing the date pickers
        private bool initialValue1, initialValue2;
        private string source;
        private bool courseChanged = false;

        //private Appointment infoAppointment;


        public AppointmentInfoForm()
        {
            InitializeComponent();
            this.Width = 280;
            displayApproveButton();
        }

        public AppointmentInfoForm(string type, int id)
        {
            InitializeComponent();
            apptId = id;
            Appointment a = new Appointment();
            Database db = new Database();
            a = db.getAppointmentById(apptId);
            displayApproveButton();
            this.Width = 280;

        }

        public AppointmentInfoForm(string type, string place, string course, string datetime, string endDateDateTime, string fname, string sname, int id, string username, bool approved, string src)
        {
            apptId = id;
            Appointment a = new Appointment();
            Database db = new Database();
            a = db.getAppointmentById(apptId);

            apptType = type;
            apptTime = datetime;
            apptPlace = place;
            apptCourse = course;
            firstName = fname;
            secondName = sname;
            apptId = id;
            user = username;

            if (firstName != "" && secondName != "")
            {
                if (firstName == user)
                    otherUser = secondName;
                else
                    otherUser = firstName;
            }

            isApproved = approved;
            source = src;

            InitializeComponent();

            displayApproveButton();
            this.Width = 280;

            apptDateStartTime = a.getStartTime();
            apptDateStartDate = apptDateStartTime.Date;

            apptDateEndTime = endDateDateTime;
            apptDateEnd = a.getEndTime();
            apptDateEndDate = apptDateEnd.Date;

            if (apptType == "Free time")
            {
                isFreeTime = true;
                lblTypeVal.Text = apptType;
                secondName = null;
            }
            else if (apptType == "Learning")
            {
                isFreeTime = false;
                lblTypeVal.Text = apptType;
            }

            if (firstName != "" && firstName != null)
            {
                lblTutorVal.Text = firstName;
            }
            else
            {
                lblTuteeVal.Text = "-------";
            }

            if (!isFreeTime)
            {
                isFreeTime = false;
                lblTuteeVal.Text = secondName;
            }
            else
            {
                lblTuteeVal.Text = "-------";
            }


            if (apptCourse != "" && apptCourse != null)
            {
                lblCourseVal.Text = apptCourse;
            }
            else
            {
                apptCourse = null;
                lblCourseVal.Text = "-------";
            }


            if (apptPlace != "" && apptPlace != null)
            {
                lblPlaceVal.Text = apptPlace;
            }
            else
            {
                apptPlace = null;
                lblPlaceVal.Text = "-------";
            }


            if (apptTime != "" && apptTime != null)
            {
                lblTimeVal.Text = apptTime;
            }
            else
            {
                lblTimeVal.Text = "-------";
            }


            if (apptDateStartDate != null)
            {
                lblDateVal.Text = apptDateStartDate.ToShortDateString();
            }
            else
            {
                lblDateVal.Text = "-------";
            }

            if (apptDateEndDate != null)
            {
                lblEndDateVal.Text = apptDateEndDate.ToShortDateString();
            }
            else
            {
                lblEndDateVal.Text = "-------";
            }

            if (apptDateEndTime != null)
            {
                lblEndTimeVal.Text = apptDateEndTime;
            }
            else
            {
                lblEndTimeVal.Text = "-------";
            }
        }

        private void displayApproveButton()
        {
            if ((user == firstName) && (apptType == "Learning") && (isApproved == false))
            {
                this.Height = 390;
                btnApprove.Visible = true;
                btnReject.Visible = true;
            }
            else
            {
                this.Height = 330;
                btnApprove.Visible = false;
                btnReject.Visible = false;
            }
            initializeTimers();
        }



        /*
         *  If someone wishes to edit an appointment, this is what should happen:
         *      Starts an ApptEditForm filled with the existing info,
         *      when that form is complete and user chooses to finish
         *      free time: deletes old appointment, notifies other person if someone used to be pair, adds new appt (just edit?)    
         *      non free time: appointment becomes pending and other person is messaged (Appt has been edited, needs to be approved)
         *      
         *      What can't be edited:  the type, and all profiles involved.
         */
        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Width = 680;
            panelEdit.Visible = true;
            initializePanel();
            btnConfirmEdit.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.deleteAppointment(apptId);
            this.Hide();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            //Check to see if all of the fields are filled in. Specifically, Place must be checked
            Database db = new Database();
            int messageId = db.getMessageIdFromAppt(apptId);
            db.approveMessageDetailsFromAppointment(messageId, true);
            db.editAppointment(apptId, null, apptPlace, apptCourse, apptDateStartTime, apptDateEnd, firstName, secondName, false, true, "ApprovedInEditForm");
            db.sendMessage(user, otherUser, "Appoinment Request Confirmed", user + " has confirmed your appointment regarding " + apptCourse, true, DateTime.Now, apptCourse, apptId);



            if (apptPlace != null)
            {
                //Database db = new Database();

                db.editAppointment(apptId, null, apptPlace, apptCourse, apptDateStartTime, apptDateEnd, firstName, secondName, false, true, "ApprovedInEditForm");
                db.sendMessage(user, otherUser, "Appoinment Request Confirmed", user + " has confirmed your appointment regarding " + apptCourse, true, DateTime.Now, apptCourse, apptId);

                this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show("Appointment needs a place. Add place and click \"Approve\" again.");
                this.Width = 680;
                panelEdit.Visible = true;
                lblPlacePanel.Visible = true;
                txtMeetingPlace.Visible = true;
                btnConfirmEdit.Visible = true;
            }
        }

        private void initializePanel()
        {
            panelTime.Visible = true;
            dateTimeDay1.Value = apptDateStartTime.Date;
            dateTimeTime1.Value = apptDateStartTime;
            dateTimeDay2.Value = apptDateEnd.Date;
            dateTimeTime2.Value = apptDateEnd;
            btnConfirmEdit.Visible = true;

            switch (apptType)
            {
                case "Freetime":
                    lblCoursePanel.Visible = false;
                    cbxCourseList.Visible = false;
                    lblPlacePanel.Visible = false;
                    txtMeetingPlace.Visible = false;
                    break;

                case "Learning":
                    lblPlacePanel.Visible = true;
                    txtMeetingPlace.Visible = true;
                    txtMeetingPlace.Text = apptPlace;

                    if (user == secondName)
                    {
                        lblCoursePanel.Visible = true;
                        cbxCourseList.Visible = true;
                        cbxCourseList.Text = apptCourse;
                        cbxCourseList.SelectedItem = apptCourse;

                        Database db = new Database();
                        List<string> tutorCourses = db.getCourseList(firstName, true);
                        List<string> tuteeCourses = db.getCourseList(secondName, false);

                        HashSet<string> comboBoxSet = new HashSet<string>();
                        for (int a = 0; a < tutorCourses.Count; a++)
                        {
                            for (int b = 0; b < tuteeCourses.Count; b++)
                            {
                                if (tutorCourses[a] == tuteeCourses[b] && tuteeCourses[b] != "")
                                    comboBoxSet.Add(tuteeCourses[b]);
                            }
                        }
                        string[] comboBoxArray = new string[comboBoxSet.Count];
                        comboBoxSet.CopyTo(comboBoxArray);
                        cbxCourseList.Items.Clear();
                        for (int c = 0; c < comboBoxArray.Length; c++)
                        {
                            cbxCourseList.Items.Add(comboBoxArray[c]);
                        }
                    }
                    else
                    {
                        lblCoursePanel.Visible = false;
                        cbxCourseList.Visible = false;
                    }
                    break;


            }

        }

        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            string freeTimeProf;
            //Re-assign all of the info for course, place, startTime, and endTime
            if (apptType == "Learning")
                freeTimeProf = null;
            else
            {
                freeTimeProf = firstName;
                firstName = null;
                secondName = null;
            }
            //if (sourceChanged == true)
            //    apptCourse = cbxCourseList.SelectedItem.ToString();
            if (txtMeetingPlace.Visible == true)
                apptPlace = txtMeetingPlace.Text;
            apptDateStartTime = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            apptDateEnd = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;



            //Check if the place is nonempty
            if (apptPlace != "")
            {
                //Check to see if the times work for both people. If so: 
                if (verifyTimes())
                {
                    //Edit the appointment and send the message.
                    Database db = new Database();

                    db.editAppointment(apptId, freeTimeProf, apptPlace, apptCourse, apptDateStartTime, apptDateEnd, firstName, secondName, isFreeTime, isApproved, "EditForm");
                    db.sendMessage(user, otherUser, "Appoinment edited", user + " has edited an appointment with you: \n\tCourse now: " + apptCourse
                        + "\n\tPlace now: " + apptPlace
                        + "\n\tNow from: " + apptDateStartDate.ToShortDateString() + " at " + apptDateStartTime.ToShortTimeString()
                        + "\n\tUntil: " + apptDateEndDate.ToShortTimeString() + " at " + apptDateEnd.ToShortTimeString()
                        , true, DateTime.Now, apptCourse, apptId);

                    this.Hide();
                    this.Close();
                }
                else
                {
                    //Times don't work for one or both of the people.
                    MessageBox.Show("This time frame does not work for you or for the other person.");

                }
            }
            //If the place is empty
            else
            {
                MessageBox.Show("Place field was left empty. Must be filled.");
            }

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (initialValue2)
            {
                initialValue2 = false;
                return;
            }

            DateTime dt = dateTimeTime2.Value;
            TimeSpan diff = dt - prevTime2;


            if (diff.Ticks < 0)
            {
                dateTimeTime2.Value = prevTime2.AddMinutes(-15);
            }
            else
            {
                dateTimeTime2.Value = prevTime2.AddMinutes(15);
            }

            //Debug.WriteLine("Timer 2 " + diff.Ticks.ToString());

            if (dateTimeTime1.Value >= dateTimeTime2.Value)
            {
                dateTimeTime1.Value = prevTime2.AddMinutes(-15);
            }

            prevTime2 = dateTimeTime2.Value;
            apptDateEnd = dateTimeTime2.Value;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            string message = "Your request to be tutored by " + user + " was rejected.";
            string subject = "Appointment Rejected";
            switch (source)
            {
                //Run this if the appointment was created by a tutee
                case "TuteeMatch":
                    int messageId = db.getMessageIdFromAppt(apptId);
                    db.approveMessageDetailsFromAppointment(messageId, true);
                    db.sendMessage(user, otherUser, subject, message, false, DateTime.Now, apptCourse, apptId);
                    db.deleteAppointment(apptId);
                    break;

                //Run this if the appointment was a free time that got paired with.
                case "MatchWithExistingAppointment":
                    messageId = db.getMessageIdFromAppt(apptId);
                    db.approveMessageDetailsFromAppointment(messageId, true);
                    db.sendMessage(user, otherUser, subject, message, false, DateTime.Now, apptCourse, apptId);
                    db.editAppointment(apptId, firstName, null, null, apptDateStartTime, apptDateEnd, null, null, true, false, "EditForm");
                    break;

            }
            this.Hide();
            this.Close();
        }

        private void cbxCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            apptCourse = cbxCourseList.SelectedItem.ToString();
            courseChanged = true;
        }

        private void dateTimeDay1_ValueChanged(object sender, EventArgs e)
        {
            apptDateStartDate = dateTimeDay1.Value;
        }

        private void dateTimeDay2_ValueChanged(object sender, EventArgs e)
        {
            apptDateEndDate = dateTimeDay2.Value;
        }

        //Check to see if the times work for both people
        private bool verifyTimes()
        {
            bool good = false;
            DateTime startTime = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            DateTime endTime = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;
            TimeSpan apptSpan = endTime - startTime;

            good = (startTime > DateTime.Now && endTime > DateTime.Now &&
                    startTime < endTime && apptSpan.TotalMilliseconds <= 3 * 60 * 60 * 1000); //appt time up to 3 hours

            //commenting this to fix the overflow on datetime problem

            if (good)
            {

                //checking both profile times to see if they conflict with the start and end times
                Database db = new Database();
                List<Appointment> builderAppoint = db.getDailyAppointments(firstName);
                List<Appointment> otherAppoint = db.getDailyAppointments(secondName);

                int it = 0;

                while (good && it < builderAppoint.Count)
                {
                    bool timeConflict = false;
                    bool sameIds = false;

                    Appointment a = builderAppoint[it];
                    timeConflict = isTimeInBetween(a.getStartTime(), a.getEndTime(), startTime, endTime);
                    sameIds = (apptId == a.getID());

                    if (!timeConflict)
                    {
                        //Good if there is no time conflict
                        good = true;
                    }
                    else
                    {
                        if (!sameIds)
                        {
                            //Good if there is a time conflict but the only conflict is itself.
                            good = false;
                        }
                    }
                    it++;
                }

                it = 0;
                while (good && it < otherAppoint.Count)
                {
                    bool timeConflict = false;
                    bool sameIds = false;

                    Appointment a = otherAppoint[it];
                    timeConflict = isTimeInBetween(a.getStartTime(), a.getEndTime(), startTime, endTime);
                    sameIds = (apptId == a.getID());

                    if (!timeConflict)
                    {
                        //Good if there is no time conflict
                        good = true;
                    }
                    else
                    {
                        if (!sameIds)
                        {
                            //Good if there is a time conflict but the only conflict is itself.
                            good = false;
                        }
                    }
                    it++;
                }

            }
            else
            {
                if (apptType == "FreeTime" && good)
                {
                    Database db = new Database();
                    List<Appointment> builderAppoint = db.getDailyAppointments(firstName);

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

        //Helper function for verifying validity of times
        private bool isTimeInBetween(DateTime startTime, DateTime endTime, DateTime startTimeInQuestion, DateTime endTimeInQuestion)
        {
            return (startTime <= endTimeInQuestion && startTimeInQuestion <= endTime);
        }
    }
}
