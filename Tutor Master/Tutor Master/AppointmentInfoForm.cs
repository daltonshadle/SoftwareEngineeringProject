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
        private string firstName;
        private string secondName;

    
        public AppointmentInfoForm()
        {
            InitializeComponent();
        }

        public AppointmentInfoForm(string type, string place, string course, string time, string fname, string sname)
        {
            apptType = type;
            apptPlace = place;
            apptCourse = course;
            apptTime = time;
            firstName = fname;
            secondName = sname;
            InitializeComponent();

        }

    }
}
