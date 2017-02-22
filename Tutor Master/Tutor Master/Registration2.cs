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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                // If so, loop through all checked items and print results.  
                string s = "";
                for (int x = 0; x <= checkedListBox1.CheckedItems.Count - 1; x++)
                {
                    s = s + "Checked Item " + (x + 1).ToString() + " = " + checkedListBox1.CheckedItems[x].ToString() + "\n";
                }
                MessageBox.Show(s);
            }  

            //Scott: store the selected classes in a list. 

            //Faculty gets emailed here.

            //Garrett, at this point the user would have selected their classes. Query to send stuff to faculty?

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

        

    }

}
