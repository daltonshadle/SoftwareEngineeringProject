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
        //private Appointment infoAppointment;

    
        public AppointmentInfoForm()
        {
            InitializeComponent();
        }

        public AppointmentInfoForm(string type, int id)
        {
            apptId = id;
            Appointment a = new Appointment();
            Database db = new Database();
            a = db.getAppointmentById(apptId);



        }

        public AppointmentInfoForm(string type, string place, string course, string datetime, string endDateDateTime, string fname, string sname, int id)
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
            InitializeComponent();

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
            var appointmentEditor = new AppointmentEditForm(apptType, apptPlace, apptCourse, apptTime, apptDateTime, apptDateEnd, firstName, secondName, apptId);
            appointmentEditor.Show();
            this.Hide();
        }
    }
}
