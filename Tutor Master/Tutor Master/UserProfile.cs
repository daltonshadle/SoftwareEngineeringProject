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
        private string first;
        private string last;
       
        private bool tutorAcc, tuteeAcc;

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

            tuteeCoursesList.Add(listOfProfileInfo[2]);
            tuteeCoursesList.Add(listOfProfileInfo[3]);
            tuteeCoursesList.Add(listOfProfileInfo[4]);
            tuteeCoursesList.Add(listOfProfileInfo[5]);
            tutorCoursesList.Add(listOfProfileInfo[6]); 
            tutorCoursesList.Add(listOfProfileInfo[7]);
            tutorCoursesList.Add(listOfProfileInfo[8]);
            tutorCoursesList.Add(listOfProfileInfo[9]);


            if (first != "")
            {
                this.Text = FirstLetterToUpper(first) + " " + FirstLetterToUpper(last);
            }
            else
            {
                this.Text = username;
            }

            this.Icon = Tutor_Master.Properties.Resources.favicon;

            // If so, loop through all checked items and print results. 
            if (tutorCoursesList[0] != "")
            {
                var listBox = new ListBox();
                for (int x = 0; x <= tutorCoursesList.Count - 1; x++)
                {
                    listBox.Items.Add(tutorCoursesList[x]);
                }
            }
            else
            {
                var button = new Button();
                button.Text = "Click here to add courses for tutoring.";
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
