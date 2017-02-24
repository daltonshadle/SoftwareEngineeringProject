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
        bool tutorAcc, tuteeAcc;
        string username;
        List<String> tutorClassesList;

        public Registration2()
        {
            InitializeComponent();
        }

        public Registration2(string user, bool isTutor, bool isTutee)
        {
            InitializeComponent();
            tutorAcc = isTutor;
            tuteeAcc = isTutee;
            username = user;
            tutorClassesList = new List<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0 && checkedListBox1.CheckedItems.Count < 5)
            {
                // If so, loop through all checked items and print results.  
                for (int x = 0; x <= checkedListBox1.CheckedItems.Count - 1; x++)
                {
                    tutorClassesList.Add(checkedListBox1.CheckedItems[x].ToString());
                }

                //Faculty gets emailed here.

                //Database db = new Database();
                //Garrett: db.addCourseList();

                if (tuteeAcc)
                {
                    //Garrett write a query: update base Profile to tutee
                    var next = new Registration3(username, tutorAcc, tuteeAcc);
                    this.Hide();
                    next.Show();
                }
                else
                {
                    //Garrett write a query: update base Profile to tutee
                    var next = new UserProfile(username);
                    this.Hide();
                    next.Show();
                }
            }
            else if (checkedListBox1.CheckedItems.Count > 4)
            {
                MessageBox.Show("May not select more than 4 courses to tutor.");
            }
        }
    }
}
