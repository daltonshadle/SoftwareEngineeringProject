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
    public partial class Registration3 : Form
    {
        //private data
        bool tutorAcc, tuteeAcc;
        string username;
        List<string> tutorClassesList;
        List<string> tuteeClassesList;

        Database db = new Database();

        //constructor if the profile is only a tutee.
        public Registration3(string user) 
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            initFeaturesList();

            tutorAcc = false;
            tuteeAcc = true;
            username = user;
            tuteeClassesList = new List<string>();

            //Here we will try to fill the checkboxes
            List<string> courses = db.getAllCourses();

            var checkBox = (CheckedListBox)checkedListBox1;
            for (int i = 0; i < courses.Count(); i++)
            {
                checkBox.Items.Add(courses[i]);
            }
        }

        //constructpr if the profile is adding courses from profile page
        public Registration3(string user, List<string> list) 
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            initFeaturesList();

            tuteeAcc = true;
            username = user;
            tutorClassesList = list;
            tuteeClassesList = new List<string>();

            //Here we will try to fill the checkboxes
            List<string> courses = db.getAllCourses();

            var checkBox = (CheckedListBox)checkedListBox1;
            for (int i = 0; i < courses.Count(); i++)
            {
                if (!tutorClassesList.Contains(courses[i]))
                    checkBox.Items.Add(courses[i]);
            }
        }

        //constructor is profile is both tutor and tutee
        public Registration3(string user, bool isTutor, bool isTutee, List<string> list) 
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            initFeaturesList();

            tutorAcc = isTutor;
            tuteeAcc = isTutee;
            username = user;
            tutorClassesList = list;
            tuteeClassesList = new List<string>();

            //Here we will try to fill the checkboxes
            List<string> courses = db.getAllCourses();

            var checkBox = (CheckedListBox)checkedListBox1;
            for (int i = 0; i < courses.Count(); i++)
            {
                if (!tutorClassesList.Contains(courses[i]))
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
            //function listening for form closing and then deleting profile
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            Database db = new Database();
            db.deleteAccount(username);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //function for verifying all info, updating profile in database, and moving to next form
            if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox1.CheckedItems.Count < 5)
            {
                // If so, loop through all checked items and print results.  
                for (int x = 0; x <= checkedListBox1.CheckedItems.Count - 1; x++)
                {
                    tuteeClassesList.Add(checkedListBox1.CheckedItems[x].ToString());
                }
                
                //Faculty gets emailed here.

                Database db = new Database();
                db.setTuteeStatus(username, true);
                db.addNewCourseList(username, tuteeClassesList, false);

                var next = new UserProfile(username);
                this.Hide();
                next.Show();
                
            }
            else if (checkedListBox1.CheckedItems.Count == 0 || checkedListBox1.CheckedItems.Count > 4)
            {
                MessageBox.Show("Must choose from 1 to 4 courses.");
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //function for going to sign in page
            var signInform = new SignIn();
            signInform.Show();
            this.Hide();
        }



    }
}

