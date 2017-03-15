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

            string tutora = listOfProfileInfo[2];
            if (tutora == "true")
                    tutorAcc = true;
            else
                tutorAcc = false;

            string tuteea = listOfProfileInfo[3];
            if (tuteea == "true")
                tuteeAcc = true;
            else
                tuteeAcc = false;

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

            //MessageBox.Show(tutorCoursesList[0] + tutorCoursesList[1] + tutorCoursesList[2] + tutorCoursesList[3]);


            var tutorListView = listView1;
            Point a = tutorListView.Location;
            MessageBox.Show("tutor list box " + a.X + " " + a.Y);


            // If so, loop through all checked items and print results. 
            if (tutorCoursesList[0] != "")
            {
                for (int x = 0; x < tutorCoursesList.Count; x++)
                {
                    if (tutorCoursesList[x] != "")
                    {
                        tutorListView.Items.Add(tutorCoursesList[x] + "\n");
                    }
                }
                tutorListView.Visible = true;
            }
            else
            {
                Button button = new Button();
                button.Text = "Add courses";
                button.Left = listView1.Left+160;
                button.Top = listView1.Top + 100;
                //button.Location = new Point(100, 100);  
                this.Controls.Add(button);

                var next = new Registration2(username, tutorAcc, tuteeAcc);
                this.Hide();
                next.Show();
            }

            var tuteeListView = listView2;
            Point b = tuteeListView.Location;
            MessageBox.Show("tutee list box " + b.X + " " + b.Y);


            if (tuteeCoursesList[0] != "")
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
                Button button = new Button();
                button.Text = "Add courses";
                button.Left = listView2.Left + 170;
                button.Top = listView2.Top + 100;
                //button.Location = new Point(100, 100);  
                this.Controls.Add(button);

                //button.Click += new EventHandler(button_Click, username);
            }
        }

        protected void button_Click (object sender, EventArgs e, string username) 
        {
            Button button = sender as Button;

            var next = new Registration3(username);
            this.Hide();
            next.Show();
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
