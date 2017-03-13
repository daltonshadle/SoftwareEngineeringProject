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
        private string first, last;
       
        private string tutorAcc, tuteeAcc;

        public UserProfile(string username)
        {
            InitializeComponent();

            List<string> tuteeCoursesList = new List<string>();
            List<string> tutorCoursesList = new List<string>();

            List<string> listOfProfileInfo;
            Database db = new Database();
            listOfProfileInfo = db.getProfileInfo(username);
            first = listOfProfileInfo[0];
            last = listOfProfileInfo[1];
            tutorAcc = listOfProfileInfo[2];
            tuteeAcc = listOfProfileInfo[3];

            tuteeCoursesList.Add(listOfProfileInfo[4]);
            tuteeCoursesList.Add(listOfProfileInfo[5]);
            tuteeCoursesList.Add(listOfProfileInfo[6]);
            tuteeCoursesList.Add(listOfProfileInfo[7]);
            tutorCoursesList.Add(listOfProfileInfo[8]); 
            tutorCoursesList.Add(listOfProfileInfo[9]);
            tutorCoursesList.Add(listOfProfileInfo[10]);
            tutorCoursesList.Add(listOfProfileInfo[11]);

            if (first != "")
            {
                this.Text = FirstLetterToUpper(first) + " " + FirstLetterToUpper(last);
            }
            else
            {
                this.Text = username;
            }

            this.Icon = Tutor_Master.Properties.Resources.favicon;

            MessageBox.Show(tutorCoursesList[0] + tutorCoursesList[1] + tutorCoursesList[2] + tutorCoursesList[3]);

            // If so, loop through all checked items and print results. 
            if (tutorCoursesList[0] != "")
            {
                var tutorListView = listView1;
                for (int x = 0; x < tutorCoursesList.Count; x++)
                {
                    if (tutorCoursesList[x] != "")
                    {
                        tutorListView.Items.Add(tutorCoursesList[x]);
                    }
                }
                tutorListView.Visible = true;
            }
            else
            {
                Button button = new Button();
                button.Text = "Add courses";
                button.Left = listView1.Left;
                button.Top = listView1.Top + 50;
                this.Controls.Add(button);
            }

            if (tuteeCoursesList[0] != "")
            {
                var tuteeListView = listView2;
                for (int x = 0; x < tuteeCoursesList.Count; x++)
                {
                    if (tuteeCoursesList[x] != "")
                    {
                        tuteeListView.Items.Add(tuteeCoursesList[x]);
                    }
                }
                tuteeListView.Visible = true;
            }
            else
            {
                Button button = new Button();
                button.Text = "Add courses";
                button.Left = listView2.Left;
                button.Top = listView2.Top + 50;
                this.Controls.Add(button);
            }
        }

        private void btnButton_Click(object sender, EventArgs e)
        {
            var form = new StartForm();
            form.Show();
            this.Hide();
        }

        //Function casts the first letter of the string to be capitalized...
        //But not sure if we really want that honestly.

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



    }
}
