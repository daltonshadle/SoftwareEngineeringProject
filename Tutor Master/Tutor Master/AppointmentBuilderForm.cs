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
    public partial class AppointmentBuilderForm : Form
    {

        private const String LEARN = "Learning (Tuteeing)";
        private const String TEACH = "Teaching (Tutoring)";
        private const String FREE = "Free Time";
        private Profile builderProf;

        public AppointmentBuilderForm()
        {
            InitializeComponent();
            initViews();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }

        public AppointmentBuilderForm(Profile buildingProfile)
        {
            InitializeComponent();
            initViews();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            builderProf = buildingProfile;
        }

        private void initViews() {
            panelCourseAndPlace.Visible = false;
            panelOtherProfile.Visible = false;
            dateTimeTime1.ShowUpDown = true;
            dateTimeTime2.ShowUpDown = true;
        }

        private bool correctTimes() {
            bool good = false;

            DateTime firstDate = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            DateTime secondDate = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;

            good = (firstDate > DateTime.Now && secondDate > DateTime.Now &&
                firstDate < secondDate && (secondDate.Hour - firstDate.Hour) < 3);

            return good;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime firstDate = dateTimeDay1.Value.Date + dateTimeTime1.Value.TimeOfDay;
            DateTime secondDate = dateTimeDay2.Value.Date + dateTimeTime2.Value.TimeOfDay;
            string type = cbxTypeAppt.Text.ToString();

            if (type.Equals(FREE)) { 
                //move on and check dates for free time
                if (correctTimes()) {
                    Appointment a = new Appointment(type, firstDate, secondDate, builderProf);
                }

            }
            else if (type.Equals(LEARN)) { 
                //check dates and times, courses, meeting place, profile

            }
        }

        private void cbxTypeAppt_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTypeAppt.SelectedIndex) {
                case 0:
                    panelCourseAndPlace.Visible = false;
                    panelOtherProfile.Visible = false;
                    break;
                case 1:

                case 2:
                    panelCourseAndPlace.Visible = true;
                    panelOtherProfile.Visible = true;
                    break;
            }
        }

        private void initializeCourseCollection() {
            //Garrett need a function to get all courses preferably to string
            int totalNumCourses = 0;

            //intialize totalNumCourses
            for (int i = 0; i < totalNumCourses; i++) { 
                string course = "course";
                //initialize course one at a time
                cbxCourseList.Items.Add(course);   
            }

        }

    }
}
