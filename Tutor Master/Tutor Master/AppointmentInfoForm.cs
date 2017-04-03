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

        public AppointmentInfoForm(string type, string place, string course, string datetime, string fname, string sname, int id)
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
        }
    }
}
