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
        private DateTime apptDateTime;
        private DateTime apptDate;
        private string apptDateEndTime;
        private DateTime apptDateEndDate;
        private DateTime apptDateEnd;
        private string firstName;
        private string secondName;
        private int apptId;
        private string user, otherUser;
        private bool isApproved;
        
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

        public AppointmentInfoForm(string type, string place, string course, string datetime, string endDateDateTime, string fname, string sname, int id, string username, bool approved)
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

            InitializeComponent();

            displayApproveButton();
            this.Width = 280;

            apptDateTime = a.getStartTime();
            apptDate = apptDateTime.Date;

            apptDateEndTime = endDateDateTime;
            apptDateEnd = a.getEndTime();
            apptDateEndDate = apptDateEnd.Date;
            
            //Problem here: Can't get username so I can't distinguish between tutoring and tuteeing for learning
            /*if (apptType == "Learning")
            {
                if (username == db.getAppointmentById(id).getTutor())
                    apptType = "Tutoring";
                else
                    apptType = "Tuteeing";
            }*/

            if (apptType != "" && apptType != null){
                lblTypeVal.Text = apptType;
            }
            else{
                lblTypeVal.Text = "-------";
            }


            if (firstName != "" && firstName != null){
                lblTutorVal.Text = firstName;
            }
            else{
                lblTutorVal.Text = "-------";
            }


            if (secondName != "" && secondName != null){
                lblTuteeVal.Text = secondName;
            }
            else
            {
                lblTuteeVal.Text = "-------";
            }


            if (apptCourse != "" && apptCourse != null){
                lblCourseVal.Text = apptCourse;
            }
            else{
                lblCourseVal.Text = "-------";
            }


            if (apptPlace != "" && apptPlace != null){
                lblPlaceVal.Text = apptPlace;
            }
            else{
                lblPlaceVal.Text = "-------";
            }


            if (apptTime != "" && apptTime != null){
                lblTimeVal.Text = apptTime;
            }
            else{
                lblTimeVal.Text = "-------";
            }


            if (apptDate != null){
                lblDateVal.Text = apptDate.ToShortDateString();
            }
            else{
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
                this.Height = 360;
                btnApprove.Visible = true;
            }
            else
            {
                this.Height = 330;
                btnApprove.Visible = false;
            }
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
            //var appointmentEditor = new AppointmentEditForm(apptType, apptPlace, apptCourse, apptTime, apptDateTime, apptDateEnd, firstName, secondName, apptId);
            //appointmentEditor.Show();
            //this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.deleteAppointment(apptId);
            this.Hide();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.editAppointment(apptId, null, apptPlace, apptCourse, apptDateTime, apptDateEnd, firstName, secondName, false, true);
            db.sendMessage(user, otherUser, "Appoinment Request Confirmed", user + " has confirmed your appointment regarding " + apptCourse, true, DateTime.Now, apptCourse, apptId);
            this.Hide();
            this.Close();
        }

        private void initializePanel()
        {
            switch (apptType)
            {
                case "Freetime":
                    lblTypePanel.Visible = false;
                    cbxType.Visible = false;
                    lblTutorPanel.Visible = false;
                    lblTutorValPanel.Visible = false;
                    lblTuteePanel.Visible = false;
                    lblTuteeValPanel.Visible = false;
                    lblCoursePanel.Visible = false;
                    cbxCourseList.Visible = false;
                    lblPlacePanel.Visible = false;
                    txtMeetingPlace.Visible = false;
                    dateTimeDay1.Value = apptDateTime;
                    dateTimeTime1.Value = apptDateTime;
                    dateTimeDay2.Value = apptDateEnd;
                    dateTimeTime2.Value = apptDateEnd;



                    break;

            }

        }


    }
}
