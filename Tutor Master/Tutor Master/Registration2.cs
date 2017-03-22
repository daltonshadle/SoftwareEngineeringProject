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
    public partial class Registration2 : Form
    {
        bool tutorAcc, tuteeAcc;
        string username;
        List<string> tutorClassesList;
        int code = 0;

        Database db = new Database();

        public Registration2(int fromCode)
        {
            code = fromCode;
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;

            //Here we will try to fill the checkboxes
            List<string> courses = db.getAllCourses();

            var checkBox = (CheckedListBox)checkedListBox1;
            for (int i = 0; i < courses.Count(); i++)
            {
                checkBox.Items.Add(courses[i]);
            }
        }

        public Registration2(string user, bool isTutor, bool isTutee, int fromCode)
        {
            code = fromCode;
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            tutorAcc = isTutor;
            tuteeAcc = isTutee;
            username = user;
            tutorClassesList = new List<string>();

            //Here we will try to fill the checkboxes
            List<string> courses = db.getAllCourses();

            var checkBox = (CheckedListBox)checkedListBox1;
            for (int i = 0; i < courses.Count(); i++)
            {
                checkBox.Items.Add(courses[i]);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            Database db = new Database();
            db.deleteAccount(username);
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                    db.sendMessage(username, facultyApprover, "Tutor Request", username+" is requesting to tutor "+tutorClassesList[x], false, DateTime.Now);
                }

                if (tuteeAcc)
                {
                    //Garrett: update base Profile to tutee
                   
                    db.setTuteeStatus(username, tuteeAcc);
                    //username is a string, isTutee is a bool

                    if (code == 1000) {
                        var next = new Registration3(username, tutorAcc, tuteeAcc);
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
    }
}
