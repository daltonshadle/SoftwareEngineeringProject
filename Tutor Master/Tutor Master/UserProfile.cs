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
    public partial class UserProfile : Form
    {
        private string first, last, user, adminName;
        private bool tutorAcc, tuteeAcc, adminAcc;

        List<string> tuteeCoursesList = new List<string>();
        List<string> tutorCoursesList = new List<string>();
        List<string> courseAppList = new List<string>();

        //Normal constructor. Will be called by tutors and tutees, not by admin
        public UserProfile(string username)
        {
            InitializeComponent();

            user = username;

            //Clear old free time appointments so they can't be matched with in the future
            Database db = new Database();
            db.deleteOldFreeTimeAppointments();

            //Assign all of the info
            assignProfileInfo();

            //Display appropriate information
            updateAllDisplays();
        }

        //This constructor will only be called by the administrator. Updates information accordingly
        public UserProfile(string username, bool admin, string adminName)
            : this(username)
        {
            adminAcc = admin;
            this.adminName = adminName;
            lblAdmin.Visible = true;
            btnAdmin.Visible = true;
            panelAdmin.Visible = true;
        }

        //Retrieves information about user and sets all the values
        public void assignProfileInfo()
        {
            Database db = new Database();
            List<string> listOfProfileInfo = db.getProfileInfo(user);

            //Sets editable information for user profile
            assignEditableProfileInfo();

            adminAcc = false;   //bool isAdmin is set to false in this constructor. Only other constructor can make it true

            for (int i = 4; i < 8; i++)
            {
                if (listOfProfileInfo[i] != "")
                    tuteeCoursesList.Add(listOfProfileInfo[i]); //list of tutee courses
            }
            for (int i = 8; i < 12; i++)
            {
                if (listOfProfileInfo[i] != "") 
                {
                    tutorCoursesList.Add(listOfProfileInfo[i]); //list of tutor courses                    
                }
                courseAppList.Add(listOfProfileInfo[i + 4]);//list of tutor courses eligible for tutoring (not pending or rejected)
            }
        }

        //Sets all values that might be editable
        public void assignEditableProfileInfo()
        {
            Database db = new Database();
            List<string> listOfProfileInfo = db.getProfileInfo(user);

            first = listOfProfileInfo[0];   //string first name
            last = listOfProfileInfo[1];    //string last name

            string tutora = listOfProfileInfo[2];   //bool isTutor
            if (tutora == "True")
                tutorAcc = true;
            else
                tutorAcc = false;

            string tuteea = listOfProfileInfo[3];   //bool isTutee
            if (tuteea == "True")
                tuteeAcc = true;
            else
                tuteeAcc = false;
        }

        //Updates the name panel and the form name
        public void displayName()
        {
            if (first != "")
            {
                this.Text = FirstLetterToUpper(first) + " " + FirstLetterToUpper(last);
                lblNameAndUser.Text = FirstLetterToUpper(first) + " " + FirstLetterToUpper(last) + " - " + user;
            }
            else
            {
                this.Text = user;
                lblNameAndUser.Text = user;
            }
        }

        //Helper function for displaying name
        //This would assume that we automatically cast usernames to lower so that coolTerry7 == coolterry7
        public string FirstLetterToUpper(string str)
        {
            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        //Updates list view for tutor courses 
        public void updateTutorListView()
        {
            tutorListView.Clear();
            if (tutorCoursesList.Count > 0)
            {
                for (int x = 0; x < tutorCoursesList.Count; x++)
                {
                    if (tutorCoursesList[x] != "")
                    {
                        if (courseAppList[x] == "False")
                            tutorListView.Items.Add(tutorCoursesList[x] + " - Rejected");
                        else if (courseAppList[x] == "")
                            tutorListView.Items.Add(tutorCoursesList[x] + " - Pending");
                        else
                            tutorListView.Items.Add(tutorCoursesList[x] + "\n");
                    }
                }
                tutorListView.Visible = true;
            }
            else
            {
                btnAddTutorCourses.Visible = true;
            }
        }

        //Updates list view for tutee courses 
        public void updateTuteeListView()
        {
            tuteeListView.Clear();
            if (tuteeCoursesList.Count > 0)
            {
                for (int x = 0; x < tuteeCoursesList.Count; x++)
                {
                    if (tuteeCoursesList[x] != "")
                    {
                        if (courseAppList[x] == "False")
                            tuteeListView.Items.Add(tuteeCoursesList[x] + " - Rejected");
                        else if (courseAppList[x] == "")
                            tuteeListView.Items.Add(tuteeCoursesList[x] + " - Pending");
                        else
                            tuteeListView.Items.Add(tuteeCoursesList[x] + "\n");
                    }
                }
                tuteeListView.Visible = true;
            }
            else
            {
                btnAddTuteeCourses.Visible = true;
            }
        }

        //Action when this page becomes active again
        private void UserProfile_Activated(object sender, System.EventArgs e)
        {
            updateAllDisplays();
        }

        //Run both on creation of page and whenever page becomes active again
        private void updateAllDisplays() 
        {
            //Some profile info must be re-assigned here. If user edits their profile info, the new info must be set
            assignEditableProfileInfo();

            //Update all the displays
            displayName();
            updateTutorListView();
            updateTuteeListView();
            weekCalendar.assignWeeklyAppointments(user);   
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Registering button clicks~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void btnAddTutorCourses_Click(object sender, EventArgs e)
        {
            var next = new Registration2(user, tutorAcc, tuteeAcc, tuteeCoursesList, 2000);   //2000 is the id for coming from userprofile
            this.Hide();
            next.Show();
        }

        private void buttAddTuteeCourses_Click(object sender, EventArgs e)
        {
            var next = new Registration3(user, tutorCoursesList);
            this.Hide();
            next.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var form = new StartForm();
            form.Show();
            this.Hide();
        }

        private void btnViewCal_Click(object sender, EventArgs e)
        {
            var monthCal = new MonthCalendarForm(user);
            monthCal.StartPosition = FormStartPosition.CenterParent;
            monthCal.Show();
        }

        private void btnMatchingAppoint_Click(object sender, EventArgs e)
        {
            var matchingForm = new MatchingAppointmentForm(user, tutorAcc, tuteeAcc);
            //matchingForm.FormClosing += new FormClosingEventHandler(matchingForm_FormClosing);
            matchingForm.Show();
        }

        private void btnViewMessages_Click(object sender, EventArgs e)
        {
            var messagePage = new MessagesForm(user);
            messagePage.Show();
        }

        private void btnRefinedSearch_Click(object sender, EventArgs e)
        {
            //If user is a tutee:
            if (tuteeCoursesList.Count > 0)
            {
                var refine = new SearchRefinementForm(user);
                //refine.FormClosing += new FormClosingEventHandler(matchingForm_FormClosing);
                refine.Show();
            }
            //If user is not a tutee:
            else
            {
                MessageBox.Show("This search is for users looking for someone to tutor them.");
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            var profile = new AdminForm(adminName);
            profile.Show();
            this.Hide();
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            var newForm = new EditProfileStart(user, tuteeAcc, tutorAcc);
            newForm.Show();
        }
    }
}
