﻿using System;
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
        private bool tutorAcc, tuteeAcc, facultyAcc, adminAcc;
        private string courseapp1, courseapp2, courseapp3, courseapp4;

        List<string> tuteeCoursesList;
        List<string> tutorCoursesList;
        List<string> courseAppList;

        public UserProfile(string username)
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;

            tuteeCoursesList = new List<string>();
            tutorCoursesList = new List<string>();
            courseAppList = new List<string>();

            List<string> listOfProfileInfo;
            Database db = new Database();
            db.deleteOldFreeTimeAppointments();
            listOfProfileInfo = db.getProfileInfo(username);
            user = username;
            first = listOfProfileInfo[0];
            last = listOfProfileInfo[1];

            string tutora = listOfProfileInfo[2];
            if (tutora == "True")
                tutorAcc = true;
            else
                tutorAcc = false;

            string tuteea = listOfProfileInfo[3];
            if (tuteea == "True")
                tuteeAcc = true;
            else
                tuteeAcc = false;

            string facultya = listOfProfileInfo[16];
            if (facultya == "True")
            {
                facultyAcc = true;
            }
            else
                facultyAcc = false;

            adminAcc = false;

            for (int i = 4; i < 8; i++)
            {
                if (listOfProfileInfo[i] != "")
                    tuteeCoursesList.Add(listOfProfileInfo[i]);
            }
            for (int i = 8; i < 12; i++)
            {
                if (listOfProfileInfo[i] != "")
                {
                    tutorCoursesList.Add(listOfProfileInfo[i]);
                    courseAppList.Add(listOfProfileInfo[i + 4]);
                }
            }

            if (first != "")
            {
                this.Text = FirstLetterToUpper(first) + " " + FirstLetterToUpper(last);
                lblNameAndUser.Text = FirstLetterToUpper(first) + " " + FirstLetterToUpper(last) + " - " + username;
            }
            else
            {
                this.Text = username;
                lblNameAndUser.Text = username;
            }

            //MessageBox.Show(tutorCoursesList[0] + tutorCoursesList[1] + tutorCoursesList[2] + tutorCoursesList[3]);


            var tutorListView = listView1;

            //Point a = tutorListView.Location;
            //MessageBox.Show("tutor list box " + a.X + " " + a.Y);


            // If so, loop through all checked items and print results. 
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

            var tuteeListView = listView2;
            ;
            //Point b = tuteeListView.Location;
            //MessageBox.Show("tutee list box " + b.X + " " + b.Y);


            if (tuteeCoursesList.Count > 0)
            {
                for (int x = 0; x < tuteeCoursesList.Count; x++)
                {
                    if (tuteeCoursesList[x] != "")
                    {
                        tuteeListView.Items.Add(tuteeCoursesList[x] + "\n");
                    }
                }
                tuteeListView.Visible = true;
            }
            else
            {
                btnAddTuteeCourses.Visible = true;
            }

            //Update the week calendar
            weekCalendar.assignWeeklyAppointments(user);
        }

        public UserProfile(string username, bool admin, string adminName)
            : this(username)
        //This constructor will only be called by the administrator. Updates information accordingly
        {
            adminAcc = admin;
            this.adminName = adminName;
            lblAdmin.Visible = true;
            btnAdmin.Visible = true;
            panelAdmin.Visible = true;
        }

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

        //This would assume that we automatically cast usernames to lower so that coolTerry7 == coolterry7
        public string FirstLetterToUpper(string str)
        {
            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var form = new StartForm();
            form.Show();
            this.Hide();
        }

        void appBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            weekCalendar.assignWeeklyAppointments(user);

            //need to hide the other form
            //throw new NotImplementedException();
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
            matchingForm.FormClosing += new FormClosingEventHandler(matchingForm_FormClosing);
            matchingForm.Show();
        }

        void matchingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            weekCalendar.assignWeeklyAppointments(user);

            //need to hide the other form
            //throw new NotImplementedException();
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
                refine.FormClosing += new FormClosingEventHandler(matchingForm_FormClosing);
                refine.Show();
            }
            //If user is not a tutee:
            else
            {
                MessageBox.Show("This search is for users looking for someone to tutor them.");
            }
        }

        private void UserProfile_Activated(object sender, System.EventArgs e)
        {
            updateAllTexts();
            weekCalendar.assignWeeklyAppointments(user);
        }

        private void updateAllTexts() 
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

            var tutorListView = listView1;
            listView1.Clear();
 
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

            var tuteeListView = listView2;
            listView2.Clear();

            if (tuteeCoursesList.Count > 0)
            {
                for (int x = 0; x < tuteeCoursesList.Count; x++)
                {
                    if (tuteeCoursesList[x] != "")
                    {
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
