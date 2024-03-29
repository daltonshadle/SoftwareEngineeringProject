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
    public partial class Registration2 : Form
    {
        //private data
        bool tutorAcc, tuteeAcc;
        string username;
        List<string> tutorClassesList;
        List<string> tuteeClassesList;
        int code = 0;

        Database db = new Database();

        //all functions
        //constructor
        public Registration2(int fromCode)
        {
            code = fromCode;
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            initFeaturesList();

            //Here we fill the checkboxes in the list
            List<string> courses = db.getAllCourses();
            var checkBox = (CheckedListBox)checkedListBox1;
            for (int i = 0; i < courses.Count(); i++)
            {
                checkBox.Items.Add(courses[i]);
            }
        }

        //constructor sent from registration1 with all parameters
        public Registration2(string user, bool isTutor, bool isTutee, int fromCode)  //if this constructor is run, means user is adding courses from profile page
        {   
            //if this constructor is run, means user is sent from registration1
            code = fromCode;
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            initFeaturesList();

            tutorAcc = isTutor;
            tuteeAcc = isTutee;
            username = user;
            tutorClassesList = new List<string>();

            //Here we fill the checkboxes in the list
            List<string> courses = db.getAllCourses();
            var checkBox = (CheckedListBox)checkedListBox1;
            for (int i = 0; i < courses.Count(); i++)
            {
                checkBox.Items.Add(courses[i]);
            }
        }

        //constructor sent from adding courses from profile page with all parameters
        public Registration2(string user, bool isTutor, bool isTutee, List<string> list, int fromCode)  //if this constructor is run, means user is adding courses from profile page
        {   //if this constructor is run, means user is adding courses from profile page
            code = fromCode;
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            initFeaturesList();

            tutorAcc = isTutor;
            tuteeAcc = isTutee;
            username = user;
            tuteeClassesList = list;
            tutorClassesList = new List<string>();

            //Here we fill the checkboxes in the list
            List<string> courses = db.getAllCourses();
            var checkBox = (CheckedListBox)checkedListBox1;
            for (int i = 0; i < courses.Count(); i++)
            {
                if (!tuteeClassesList.Contains(courses[i]))
                    checkBox.Items.Add(courses[i]);
            }
        }

        //function for initializing the feature textbox
        private void initFeaturesList()
        {
            string l = "-Easy to use, clean and clear interface \n\n-Create tutor session schedules with course, time, place \n\n-Create weekly tutor sessions \n\n-Automated checks - Check for availability and conflicts \n\n-Access with any Windows devices";
            lblFreatures.Text = l;
        }

        //*********************************All listener functions*********************************//
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //function listening for form to close to delete profile
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            Database db = new Database();
            db.deleteAccount(username);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //function for verifying all info and adding to profile
            //then moves on to next form
            if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox1.CheckedItems.Count < 5)
            {
                // If so, loop through all checked items and print results.  
                for (int x = 0; x <= checkedListBox1.CheckedItems.Count - 1; x++)
                {
                    tutorClassesList.Add(checkedListBox1.CheckedItems[x].ToString());
                }

                Database db = new Database();
                db.addNewCourseList(username, tutorClassesList, true);

                //Faculty gets emailed here.
                string facultyApprover = "";
                for (int x = 0; x < tutorClassesList.Count(); x++)
                {
                    facultyApprover = db.getFacultyApprover(tutorClassesList[x]);
                    db.sendMessage(username, facultyApprover, "Tutor Request", username+" is requesting to tutor "+tutorClassesList[x], false, DateTime.Now, tutorClassesList[x], -1);

                }

                db.setTutorStatus(username, true);
                if (tuteeAcc)
                {
                    db.setTuteeStatus(username, tuteeAcc);
                    //username is a string, isTutee is a bool

                    if (code == 1000) {
                        var next = new Registration3(username, tutorAcc, tuteeAcc, tutorClassesList);
                        this.Hide();
                        next.Show();
                    }
                    else if (code == 2000) {
                        var next = new UserProfile(username);
                        this.Hide();
                        next.Show();
                    }
                }
                else
                {
                    var next = new UserProfile(username);
                    this.Hide();
                    next.Show();
                }
            }
            else if (checkedListBox1.CheckedItems.Count == 0 || checkedListBox1.CheckedItems.Count > 4)
            {
                MessageBox.Show("Must choose from 1 to 4 courses.");
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //function for button to go to sign in form
            var signInform = new SignIn();
            signInform.Show();
            this.Hide();
        }

    }
}
