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
        private string apptDate;
        private string firstName;
        private string secondName;

    
        public AppointmentInfoForm()
        {
            InitializeComponent();
        }

        public AppointmentInfoForm(string type, string place, string course, string datetime, string fname, string sname)
        {
            apptType = type;
            apptPlace = place;
            apptCourse = course;
            apptTime = datetime;
            //apptDate = date;
            firstName = fname;
            secondName = sname;
            InitializeComponent();


            if (apptType != "" && apptType != null)
                lblTypeVal.Text = apptType;
            else
                lblTypeVal.Text = "-------";


            if (firstName != "" && firstName != null)
                lblTypeVal.Text = firstName;
            else
                lblTypeVal.Text = "-------";


            if (secondName != "" && secondName != null)
                lblTypeVal.Text = secondName;
            else
                lblTypeVal.Text = "-------";


            if (apptCourse != "" && apptCourse != null)
                lblTypeVal.Text = apptCourse;
            else
                lblTypeVal.Text = "-------";


            if (apptPlace != "" && apptPlace != null)
                lblTypeVal.Text = apptPlace;
            else
                lblTypeVal.Text = "-------";


            if (apptTime != "" && apptTime != null)
                lblTypeVal.Text = apptTime;
            else
                lblTypeVal.Text = "-------";


            if (apptDate != "" && apptDate != null)
                lblTypeVal.Text = apptDate;
            else
                lblTypeVal.Text = "-------";
        }
    }
}
