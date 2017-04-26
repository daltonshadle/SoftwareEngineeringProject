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
        //all private data
        private string apptType;
        private string apptPlace;
        private string apptCourse;
        private DateTime apptStartTime, apptStartDate, apptEndTime, apptEndDate;
        private string freeTimeProf;
        private string firstName;
        private string secondName;
        private int apptId;
        private string user, otherUser;
        private bool isApproved;
        private bool isFreeTime;
        private DateTime prevTime1, prevTime2; //this is just for the 15 minute increments for time
        private bool initialValue1, initialValue2;
        private string source;

        //all functions

        //Constructor by type and id
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

        //Constructor all info from database
        public AppointmentInfoForm(string type, string place, string course, string datetime, string endDateDateTime, string fname, string sname, int id, string username, bool approved, string src)
        {
            InitializeComponent();
            this.Width = 280;

            apptType = type;
            apptPlace = place;
            apptCourse = course;
            firstName = fname;
            secondName = sname;
            apptId = id;
            user = username;
            isApproved = approved;
            source = src;

            assignProfileInfo();
            initMeetingPlacesComboBox();
            displayApproveButton();
        }

        //Sets all of the fields for the appointment local to this page
        private void assignProfileInfo()
        {
            Appointment a = new Appointment();
            Database db = new Database();
            a = db.getAppointmentById(apptId);

            //Set the datetimes
            apptStartDate = a.getStartTime().Date;
            apptStartTime = a.getStartTime();
            apptEndDate = a.getEndTime().Date;
            apptEndTime = a.getEndTime();

            //Set other user (person associated with appointment who isn't currently looking at it)
            if (firstName != "" && secondName != "")
            {
                if (firstName == user)
                    otherUser = secondName;
                else
                    otherUser = firstName;
            }

            //Set type
            if (apptType == "Freetime")
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

            //Set tutor
            if (firstName != "" && firstName != null)
            {
                lblTutorVal.Text = firstName;
            }
            else
            {
                lblTutorVal.Text = "-------";
            }

            //Set tutee
            if (!isFreeTime)
            {
                isFreeTime = false;
                lblTuteeVal.Text = secondName;
            }
            else
            {
                lblTuteeVal.Text = "-------";
            }

            //Set course
            if (apptCourse != "" && apptCourse != null)
            {
                lblCourseVal.Text = apptCourse;
            }
            else
            {
                apptCourse = null;
                lblCourseVal.Text = "-------";
            }

            //Set place
            if (apptPlace != "" && apptPlace != null)
            {
                lblPlaceVal.Text = apptPlace;
            }
            else
            {
                apptPlace = null;
                lblPlaceVal.Text = "-------";
            }

            //Set start time
            if (apptStartTime != null)
            {
                lblTimeVal.Text = apptStartTime.ToShortTimeString();
            }
            else
            {
                lblTimeVal.Text = "-------";
            }

            //Set start date
            if (apptStartDate != null)
            {
                lblDateVal.Text = apptStartDate.ToShortDateString();
            }
            else
            {
                lblDateVal.Text = "-------";
            }

            //Set end date
            if (apptEndDate != null)
            {
                lblEndDateVal.Text = apptEndDate.ToShortDateString();
            }
            else
            {
                lblEndDateVal.Text = "-------";
            }

            //Set end time
            if (apptEndTime != null)
            {
                lblEndTimeVal.Text = apptEndTime.ToShortTimeString();
            }
            else
            {
                lblEndTimeVal.Text = "-------";
            }
        }

        //Changes heights of the panels and visibility of buttons depending on status of appointment and who is viewing
        private void displayApproveButton()
        {
            if ((user == firstName) && (apptType == "Learning") && (isApproved == false) && (apptEndDate > DateTime.Now))
            {
                this.Height = 420;
                panel1.Height = 350;
                panelEdit.Height = 350;
                btnApprove.Visible = true;
                btnReject.Visible = true;
            }
            else
            {
                this.Height = 350;
                panel1.Height = 285;
                panelEdit.Height = 285;
                btnApprove.Visible = false;
                btnReject.Visible = false;
            }
            initializeTimers();
        }

        //Changes what editable fields are visible and able to be changed depending on appointment status
        private void initializePanel()
        {
            panelTime.Visible = true;
            dateTimeDay1.Value = apptStartDate;
            dateTimeTime1.Value = apptStartTime;
            dateTimeDay2.Value = apptEndDate;
            dateTimeTime2.Value = apptEndTime;
            prevTime1 = dateTimeTime1.Value;
            prevTime2 = dateTimeTime2.Value;
            btnConfirmEdit.Visible = true;

            switch (apptType)
            {
                case "Freetime":
                    //free time appoinments can only get their times updated
                    lblCoursePanel.Visible = false;
                    cbxCourseList.Visible = false;
                    lblPlacePanel.Visible = false;
                    cbxMeetingPlace.Visible = false;
                    break;

                case "Learning":
                    lblPlacePanel.Visible = true;
                    cbxMeetingPlace.Visible = true;
                    cbxMeetingPlace.Text = apptPlace;

                    //the tutee is able to change the course for the appointment
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

                    //the tutor can't change course
                    else
                    {
                        lblCoursePanel.Visible = false;
                        cbxCourseList.Visible = false;
                    }
                    break;


            }

        }

        //Function to change the way that the time pickers look and coincide with each other
        private void initializeTimers()
        {
            dateTimeTime1.Format = DateTimePickerFormat.Custom;
            dateTimeTime1.CustomFormat = "hh:mm tt";
            dateTimeTime2.Format = DateTimePickerFormat.Custom;
            dateTimeTime2.CustomFormat = "hh:mm tt";

            dateTimeTime1.Value = apptStartTime;
            dateTimeTime2.Value = apptEndTime;

            prevTime1 = apptStartTime;
            prevTime2 = apptEndTime;
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
                List<Appointment> builderAppoint = db.getDailyAppointments(user);
                List<Appointment> otherAppoint = new List<Appointment>();
                if (apptType == "Learning")
                    otherAppoint = db.getDailyAppointments(otherUser);

                int it = 0;

                while (good && it < builderAppoint.Count)
                {
                    bool temp = true;

                    Appointment a = builderAppoint[it];
                    if(a.getID() != apptId) //don't say time isn't available if it is only clashing with itself.
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
                    bool temp = true;

                    Appointment a = otherAppoint[it];
                    if(a.getID() != apptId) //don't say time isn't available if it is only clashing with itself.
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
                if ((apptType == "Freetime") && good)
                {
                    Database db = new Database();
                    List<Appointment> builderAppoint = db.getDailyAppointments(user);

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

        //Helper function for verifying validity of times
        private bool isTimeInBetween(DateTime startTime, DateTime endTime, DateTime startTimeInQuestion, DateTime endTimeInQuestion)
        {
            return (startTime <= endTimeInQuestion && startTimeInQuestion <= endTime);
        }

        //Updates what meeting places are eligible
        private void initMeetingPlacesComboBox()
        {
            Database db = new Database();
            List<string> placeList = db.getAllLocations();

            for (int i = 0; i < placeList.Count; i++)
            {
                cbxMeetingPlace.Items.Add(placeList[i]);
            }
        }

        //function is just to make sure that appointments don't overlap
        private void offsetStartAndEndTimes()
        {
            //ex. one ends at 3:00:00 and one starts at 3:00:01
            apptStartTime = apptStartTime.AddMilliseconds(-apptStartTime.Millisecond);
            apptStartTime = apptStartTime.AddSeconds(-apptStartTime.Second + 1);
            apptEndTime = apptEndTime.AddMilliseconds(-apptEndTime.Millisecond);
            apptEndTime = apptEndTime.AddSeconds(-apptEndTime.Second);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Registering event listeners~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Width = 645;
            initializePanel();
            panelEdit.Visible = true;
            btnConfirmEdit.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.deleteAppointment(apptId);
            if (!isFreeTime)
                db.sendMessage(user, otherUser, "Appointment deleted", user + " has deleted your appointment for " + apptCourse, true, DateTime.Now, apptCourse, apptId);

            this.Hide();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            //Check to see if all of the fields are filled in. Specifically, Place must be checked
            if (apptPlace != null || cbxMeetingPlace.SelectedItem != null)
            {

                Database db = new Database();
                int messageId = db.getMessageIdFromAppt(apptId);

                db.approveMessageDetailsFromAppointment(messageId, true);
                db.editAppointment(apptId, null, apptPlace, apptCourse, apptStartTime, apptEndTime, firstName, secondName, false, true, "ApprovedInEditForm");
                db.sendMessage(user, otherUser, "Appoinment Request Confirmed", user + " has confirmed your appointment regarding " + apptCourse, true, DateTime.Now, apptCourse, apptId);

                this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show("Appointment needs a place. Add place and click \"Approve\" again.");
                this.Width = 645;
                panelEdit.Visible = true;
                lblPlacePanel.Visible = true;
                cbxMeetingPlace.Visible = true;
                btnConfirmEdit.Visible = true;
                btnConfirmEdit.Visible = false;
            }

        }

        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
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
            if (cbxMeetingPlace.Visible == true)
                apptPlace = cbxMeetingPlace.Text;
            apptStartTime = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            apptEndTime = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;
            offsetStartAndEndTimes();


            //Check if the place is nonempty
            if (apptPlace != "")
            {
                //Check to see if the times work for both people. If so: 
                if (verifyTimes())
                {
                    //Edit the appointment and send the message.
                    Database db = new Database();
                    
                    db.editAppointment(apptId, freeTimeProf, apptPlace, apptCourse, apptStartTime, apptEndTime, firstName, secondName, isFreeTime, isApproved, "EditForm");
                    if (!isFreeTime)
                    {
                        db.sendMessage(user, otherUser, "Appoinment edited", user + " has edited an appointment with you: \n\tCourse now: " + apptCourse
                            + "\n\tPlace now: " + apptPlace
                            + "\n\tNow from: " + apptStartDate.ToShortDateString() + " at " + apptStartTime.ToShortTimeString()
                            + "\n\tUntil: " + apptEndDate.ToShortTimeString() + " at " + apptEndTime.ToShortTimeString()
                            , true, DateTime.Now, apptCourse, apptId);
                    }

                    this.Hide();
                    this.Close();
                }
                else
                {
                    //Times don't work for one or both of the people.
                    MessageBox.Show("This time frame does not work for you or for the other person.");
                    this.Hide();
                    this.Close();
                }
            }
            //If the place is empty
            else
            {
                MessageBox.Show("Place field was left empty. Must be filled.");
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

            DateTime dt = dateTimeTime1.Value;
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

            DateTime dt = dateTimeTime2.Value;
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
                    db.editAppointment(apptId, firstName, null, null, apptStartTime, apptEndTime, null, null, true, false, "EditForm");
                    break;

            }
            this.Hide();
            this.Close();
        }

        private void cbxCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            apptCourse = cbxCourseList.SelectedItem.ToString();
        }

        private void dateTimeDay1_ValueChanged(object sender, EventArgs e)
        {
            apptStartDate = dateTimeDay1.Value;
        }

        private void dateTimeDay2_ValueChanged(object sender, EventArgs e)
        {
            apptEndDate = dateTimeDay2.Value;
        }

        private void cbxMeetingPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            apptPlace = cbxMeetingPlace.SelectedItem.ToString();
        }
    }
}
