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
        private string first, last, user;
        private bool tutorAcc, tuteeAcc, facultyAcc, adminAcc;

        public UserProfile(string username)
        {
            InitializeComponent();

            List<string> tuteeCoursesList = new List<string>();
            List<string> tutorCoursesList = new List<string>();

            List<string> listOfProfileInfo;
            Database db = new Database();
            listOfProfileInfo = db.getProfileInfo(username);
            user = username;
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

            string facultya = listOfProfileInfo[12];
            if (facultya == "true")
            {
                facultyAcc = true;
            }
            else
                facultyAcc = false;

            string admina = listOfProfileInfo[13];
            if (admina == "true")
                adminAcc = true;
            else
                adminAcc = false;

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
                lblNameAndUser.Text = FirstLetterToUpper(first) + " " + FirstLetterToUpper(last) + " - " + username;
            }
            else
            {
                this.Text = username;
                lblNameAndUser.Text = username;
            }

            

            this.Icon = Tutor_Master.Properties.Resources.favicon;

            //MessageBox.Show(tutorCoursesList[0] + tutorCoursesList[1] + tutorCoursesList[2] + tutorCoursesList[3]);


            var tutorListView = listView1;
            
            //Point a = tutorListView.Location;
            //MessageBox.Show("tutor list box " + a.X + " " + a.Y);


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
                button.Name = "buttAddTutor";
                button.Text = "Add courses";
                button.Left = listView1.Left + 160;
                button.Top = listView1.Top + 100;
                this.Controls.Add(button);

                button.Click += new EventHandler(NewButton_Click);
            }

            var tuteeListView = listView2;
            ;
            //Point b = tuteeListView.Location;
            //MessageBox.Show("tutee list box " + b.X + " " + b.Y);


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
                button.Name = "buttAddTutee";
                button.Text = "Add courses";
                button.Left = listView2.Left + 170;
                button.Top = listView2.Top + 100;
                this.Controls.Add(button);


                button.Click += new EventHandler(NewButton_Click);
            }

            //Update the week calendar
            weekCalendar.assignWeeklyAppointments(user);
        }
   

    // In event method.
    private void NewButton_Click(object sender, EventArgs e)
    {
        Button btn = (Button) sender;

        // Find the programatically created button and assign its onClick event
        if (btn.Name == ("buttAddTutor"))
        {
            var next = new Registration2(user, tutorAcc, tuteeAcc, 2000);   //2000 is the id for coming from userprofile
            this.Hide();
            next.Show();
           
        }
        if (btn.Name == ("buttAddTutee"))
        {
            var next = new Registration3(user);
            this.Hide();
            next.Show();
            
        }
        
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

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            Profile temp = new Profile(user);
            var appBuilder = new AppointmentBuilderForm(temp, tutorAcc, tuteeAcc);
            appBuilder.FormClosing += new FormClosingEventHandler(appBuilder_FormClosing);
            appBuilder.Show();
            //this.Hide();
        }

        void appBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            weekCalendar.assignWeeklyAppointments(user);
            //throw new NotImplementedException();
        }

        private void btnViewCal_Click(object sender, EventArgs e)
        {
            var monthCal = new MonthCalendarForm(user);
            monthCal.StartPosition = FormStartPosition.CenterParent;
            monthCal.Show();
        }

        private void weekCalendar_Load(object sender, EventArgs e)
        {

        }

       

    }
}
