using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tutor_Master
{
    public partial class AppointmentBlock : UserControl
    {

        private string apptType;
        private string apptPlace;
        private string apptCourse;
        private string apptTime;
        private string firstName;
        private string secondName;

        public AppointmentBlock()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        /*public AppointmentBlock(string type, string place, DateTime time, string course, Profile user)
=======
        public AppointmentBlock(string type, string place, DateTime time, string course, string user)
>>>>>>> ba4c67a7a20a9e92b5579658fb5894cf31e3c622
        {
            InitializeComponent();
            apptCourse = course;
            apptPlace = place;
            apptTime = time.ToShortTimeString();
<<<<<<< HEAD
            

            if (b)
            {
                apptType = "Freetime";
            }
            else
            {
                apptType = "Learning";
            }
=======
            apptType = type;
<<<<<<< HEAD
            otherProfileName = user;
=======
>>>>>>> ba4c67a7a20a9e92b5579658fb5894cf31e3c622
            otherProfileName = "temp name"; //NEEDS TO BE REWORKED.

            setViews();
        }*/

        public AppointmentBlock(Appointment a)
        {
            InitializeComponent();
            apptCourse = a.getCourse();
            apptPlace = a.getMeetingPlace();
            apptTime = a.getStartTime().ToShortTimeString();


            bool b = a.getIsFreeTimeSession();
            if (b) {
                apptType = "Freetime";
                firstName = a.getFreeTimeProf();
                lblSecond.Visible = false;
            }
            else {
                apptType = "Learning";
                firstName = a.getTutor();
                lblSecond.Visible = true;
                secondName = a.getTutee();
            }

<<<<<<< HEAD
=======
            otherProfileName = "temp name"; //NEEDS TO BE REWORKED.
>>>>>>> 35be280fbf29fe9d8e2ab8aae66acde70afa9c65
>>>>>>> ba4c67a7a20a9e92b5579658fb5894cf31e3c622

            setViews();
        }

        private void setViews() {
            lblAppointmentType.Text = apptType;
            lblCourse.Text = apptCourse;
            lblFirst.Text = firstName;
            lblSecond.Text = secondName;
            lblTimeAndPlace.Text = apptTime + " " + apptPlace;

            setBackColor();
        }

        private void setBackColor() {
            if (apptType.Equals("Learning"))
            {
                this.BackColor = Color.Green;
            }
            if (apptType.Equals("Freetime"))
            {
                this.BackColor = Color.Yellow;
            }
        }
        
        public string getAppointmentName() {
            return apptType;
        }

        public void setAppointmentName(string type) {
            lblAppointmentType.Text = type;
            apptType = type;

            setBackColor();
        }

        public string getTimeAndPlace()
        {
            return apptTime + " " + apptPlace;
        }

        public void setTimeAndPlace(string place, DateTime time)
        {
            lblTimeAndPlace.Text = time.ToShortTimeString() + " " + place;
        }

        public string getCourse()
        {
            return apptCourse;
        }

        public void setCourse(string course)
        {
            lblCourse.Text = course;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public void setAppointmentOwnerName(string user)
        {
            string name = user;
            lblAppointmentType.Text = name;
        }

    }
}
