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
        bool tutorAcc, tuteeAcc;
        string username;
        List<String> tuteeClassesList;

        public Registration3(string user)  //If this constructor is run, it means the profile is only a tutee.
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            tutorAcc = false;
            tuteeAcc = true;
            username = user;
            tuteeClassesList = new List<string>();
        }
          
        public Registration3(string user, bool isTutor, bool isTutee)    //if this file is run, it means profile is both tutor and tutee
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            tutorAcc = isTutor;
            tuteeAcc = isTutee;
            user = username;
            tuteeClassesList = new List<string>();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //Garrett write a query: update base Profile to tutee
        //    var next = new UserProfile(username);
        //    this.Hide();
        //    next.Show();
            
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0 && checkedListBox1.CheckedItems.Count < 5)
            {
                // If so, loop through all checked items and print results.  
                for (int x = 0; x <= checkedListBox1.CheckedItems.Count - 1; x++)
                {
                    tuteeClassesList.Add(checkedListBox1.CheckedItems[x].ToString());
                }

                //Faculty gets emailed here.

                //Database db = new Database();
                //Garrett: db.addCourseList();

                
                //Garrett write a query: update base Profile to tutee
                var next = new UserProfile(username);
                this.Hide();
                next.Show();
                
            }
            else if (checkedListBox1.CheckedItems.Count > 4)
            {
                MessageBox.Show("May not select more than 4 courses.");
            }
        }
    }
}

