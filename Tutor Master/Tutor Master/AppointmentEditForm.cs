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
    public partial class AppointmentEditForm : Form
    {
        private string apptType;
        private string apptPlace;
        private string apptCourse;
        private string apptTime;
        private DateTime apptDateTime;
        private DateTime apptDate;
        private DateTime apptEndDate;
        private DateTime apptEndDateTime;
        private string firstName;
        private string secondName;
        private int apptId;
        private string startString;

        public AppointmentEditForm()
        {
            //initialize();
            InitializeComponent();
        }

        public AppointmentEditForm(string type, string place, string course, string time, DateTime date, DateTime datetime2, string tutor, string tutee, int id)
        {
            apptType = type;
            startString = type;
            apptPlace = place;
            apptCourse = course;
            apptTime = time;
            apptDate = date;
            apptDateTime = date;
            apptEndDate = datetime2;
            firstName = tutor;
            secondName = tutee;
            apptId = id;


            InitializeComponent();
            initialize();
        }

        public void initialize()
        {

            //If old appointment was free time
            if (apptType == "Freetime")
            {
                cbxType.Items.Add("Freetime");
                cbxType.Items.Add("Learning");
                cbxType.SelectedItem = apptType;

                lblTutor.Visible = false;
                lblTutorVal1.Visible = false;
                lblTutee.Visible = false;
                lblTuteeVal1.Visible = false;

                lblCourse.Visible = false;
                cbxCourseList.Visible = false;

                lblPlace.Visible = false;
                txtMeetingPlace.Visible = false;
            }

            //Needs to distinguish between these.
            else if (apptType == "Learning")
            {
                cbxType.Items.Add("Learning");
                cbxType.SelectedItem = apptType;

                lblTutorVal1.Text = firstName;
                lblTuteeVal1.Text = secondName;

                lblTutor.Visible = true;
                lblTutorVal1.Visible = true;
                lblTutee.Visible = true;
                lblTuteeVal1.Visible = true;

                lblCourse.Visible = true;
                cbxCourseList.Visible = true;

                //Fill the course box up
                //Can't finalize this until we know more than just "Learning"
                /*Database db = new Database();
                List<string> tutorInfo = db.getProfileInfo(firstName);
                List<string> tuteeInfo = db.getProfileInfo(firstName);
                List<string> tutorCourses = new List<string>();
                List<string> tuteeCourses = new List<string>();


                for (int i = 8; i < 11; i++)
                {
                    if (tutorInfo[i] != "")
                    {
                        tutorCourses.Add(tutorInfo[i]);
                    }
                }



                for (int i = 4; i < 7; i++)
                {
                    if (tuteeInfo[i] != "")
                    {
                        tuteeCourses.Add(tuteeInfo[i]);
                    }
                }


                if (apptType != "Freetime")
                {
                    foreach (string course in tutorCourses)
                    {
                        foreach (string course2 in tuteeCourses)
                        {
                            if (course == course2)
                            {
                                cbxCourseList.Items.Add(course);
                            }
                        }
                    }
                }
                else
                {
                    foreach (string course in tutorCourses)
                    {
                        cbxCourseList.Items.Add(course);
                    }
                }*/

                cbxCourseList.Items.Add(apptCourse);
                cbxCourseList.SelectedItem = apptCourse;
            }


            cbxCourseList.SelectedItem = apptCourse;
            dateTimeDay1.Value = apptDate;
            dateTimeTime1.Value = apptDateTime;
            dateTimeDay2.Value = apptEndDate;
            dateTimeTime2.Value = apptEndDate;
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxType.SelectedIndex)
            {
                case 0:
                    lblTutor.Visible = false;
                    lblTutorVal1.Visible = false;
                    lblTutee.Visible = false;
                    lblTuteeVal1.Visible = false;

                    lblCourse.Visible = false;
                    cbxCourseList.Visible = false;

                    lblPlace.Visible = false;
                    txtMeetingPlace.Visible = false;
                    break;
                case 1:
                    //add tutor courses here from tutee list
                    cbxCourseList.Items.Clear();

                    //Fill the course box up
                    //Can't finalize this until we know more than just "Learning"
                    /*Database db = new Database();
                    List<string> tutorInfo = db.getProfileInfo(firstName);
                    List<string> tuteeInfo = db.getProfileInfo(firstName);
                    List<string> tutorCourses = new List<string>();
                    List<string> tuteeCourses = new List<string>();


                    for (int i = 8; i < 11; i++)
                    {
                        if (tutorInfo[i] != "")
                        {
                            tutorCourses.Add(tutorInfo[i]);
                        }
                    }



                    for (int i = 4; i < 7; i++)
                    {
                        if (tuteeInfo[i] != "")
                        {
                            tuteeCourses.Add(tuteeInfo[i]);
                        }
                    }


                    if (apptType != "Freetime")
                    {
                        foreach (string course in tutorCourses)
                        {
                            foreach (string course2 in tuteeCourses)
                            {
                                if (course == course2)
                                {
                                    cbxCourseList.Items.Add(course);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (string course in tutorCourses)
                        {
                            cbxCourseList.Items.Add(course);
                        }
                    }*/

                    lblTutor.Visible = true;
                    lblTutorVal1.Visible = true;
                    lblTutee.Visible = true;
                    lblTuteeVal1.Visible = true;

                    lblCourse.Visible = true;
                    cbxCourseList.Visible = true;

                    lblPlace.Visible = true;
                    txtMeetingPlace.Visible = true;

                    if (startString == "Freetime")
                    {
                        lblTutorVal1.Text = firstName;
                        lblTuteeVal1.Text = "------";
                    }
                    else
                    {
                        lblTutorVal1.Text = firstName;
                        lblTuteeVal1.Text = secondName;
                    }

                    //isFreeTimeSession = false;
                    break;
                case 2:
                    //add tutee courses here from tutor list
                    cbxCourseList.Items.Clear();

                    //Fill the course box up
                    //Can't finalize this until we know more than just "Learning"
                    /*Database db = new Database();
                    List<string> tutorInfo = db.getProfileInfo(firstName);
                    List<string> tuteeInfo = db.getProfileInfo(firstName);
                    List<string> tutorCourses = new List<string>();
                    List<string> tuteeCourses = new List<string>();


                    for (int i = 8; i < 11; i++)
                    {
                        if (tutorInfo[i] != "")
                        {
                            tutorCourses.Add(tutorInfo[i]);
                        }
                    }



                    for (int i = 4; i < 7; i++)
                    {
                        if (tuteeInfo[i] != "")
                        {
                            tuteeCourses.Add(tuteeInfo[i]);
                        }
                    }


                    if (apptType != "Freetime")
                    {
                        foreach (string course in tutorCourses)
                        {
                            foreach (string course2 in tuteeCourses)
                            {
                                if (course == course2)
                                {
                                    cbxCourseList.Items.Add(course);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (string course in tutorCourses)
                        {
                            cbxCourseList.Items.Add(course);
                        }
                    }*/

                     lblTutor.Visible = true;
                     lblTutorVal1.Visible = true;
                     lblTutee.Visible = true;
                     lblTuteeVal1.Visible = true;

                     lblCourse.Visible = true;
                    cbxCourseList.Visible = true;

                    lblPlace.Visible = true;
                    txtMeetingPlace.Visible = true;

                    if (startString == "Freetime")
                    {
                        lblTutorVal1.Text = "------";
                        lblTuteeVal1.Text = firstName;
                    }
                    else
                    {
                        lblTutorVal1.Text = firstName;
                        lblTuteeVal1.Text = secondName;
                    }

                    //isFreeTimeSession = false;
                    break;
            }
        }
    }
}