using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tutor_Master
{
    public partial class EditProfileInfo : Form
    {
        private const int MAX_NUM_COURSES = 4;
        private string first, last, user, pass;
        private bool isTutee, isTutor, isFaculty, isAdmin;
        private int numTuteeCourses = 0, numTutorCourses = 0, numApprovedCourses = 0;

        List<string> tuteeCoursesList;
        List<string> tutorCoursesList;
        List<string> tutorCourseApprovedList;
        List<string> profileInfo;

        private bool changePass, changeName, changeTutor, changeTutee;

        public EditProfileInfo(string username)
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;

            user = username;
            initInfo(username);
        }

        public EditProfileInfo(string username, bool password, bool name, bool tutor, bool tutee)
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;

            user = username;
            changePass = password;
            changeName = name;
            changeTutor = tutor;
            changeTutee = tutee;

            initInfo(username);
            initViews();

        }

        private void initInfo(string username)
        {
            Database db = new Database();
            profileInfo = db.getProfileInfo(username);

            first = profileInfo[0];
            last = profileInfo[1];
            if(!profileInfo[2].Equals(""))
                isTutor = bool.Parse(profileInfo[2]);
            if (!profileInfo[3].Equals(""))
                isTutee = bool.Parse(profileInfo[3]);
            tuteeCoursesList = profileInfo.GetRange(4, 4);
            tutorCoursesList = profileInfo.GetRange(8, 4);
            tutorCourseApprovedList = profileInfo.GetRange(12, 4);
            if (!profileInfo[16].Equals(""))
                isFaculty = bool.Parse(profileInfo[16]);
            if (!profileInfo[17].Equals(""))
                isAdmin = bool.Parse(profileInfo[17]);

            numApprovedCourses = getNumCourses(tutorCourseApprovedList);
            numTuteeCourses = getNumCourses(tuteeCoursesList);
            numTutorCourses = getNumCourses(tutorCoursesList);
        }

        private void initViews() 
        {
            //need to put all info into the views as well
            txtFirstName.Text = first;
            txtLastName.Text = last;

            checkTutee.Checked = isTutee;
            checkTutor.Checked = isTutor;

            Database db = new Database();
            List<string> allCourses = db.getAllCourses();

            for(int i = 0; i < allCourses.Count; i++){
                checkListTuteeCourses.Items.Add(allCourses[i]);
                checkListTutorCourses.Items.Add(allCourses[i]);

                if (tuteeCoursesList.Contains(allCourses[i])) {
                    checkListTuteeCourses.SetItemChecked(i, true);
                }
                if (tutorCoursesList.Contains(allCourses[i]))
                {
                    checkListTutorCourses.SetItemChecked(i, true);
                }
            }

            if (!changeName)
                panelName.Visible = false;
            if (!changePass)
                panelPassword.Visible = false;
            if (!changeTutee)
                panelTutee.Visible = false;
            if (!changeTutor)
                panelTutor.Visible = false;
        }

        private int getNumCourses(List<string> courseList) {
            int num = 0;
            for (int i = 0; i < courseList.Count; i++)
            {
                if (courseList[i].Equals(""))
                    return num;
                else
                    num++;
            }
            return num;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (changeName)
            {
                changeNameFunction();
            }
            if (changePass)
            {
                changePasswordFunction();
            }
            if (changeTutee)
            {
                changeTuteeFunction();
                //tuteeCourseList should be updated
            }
            if (changeTutor)
            {
                changeTutorFunction();
                //tutorCourseList should be updated
                //tutorApprovedCourseList should be updated
            }

        }

        private void changeNameFunction() 
        {
            if (!txtFirstName.Text.Equals("") && !txtLastName.Text.Equals(""))
            {
                //update profile first and last in database
            }
            else 
            {
                MessageBox.Show("Please enter first and last name.");
            }
        }

        private void changePasswordFunction()
        {
            if (txtNewPassword.Text.Equals(txtConfirmPassword.Text) && !txtConfirmPassword.Text.Equals(""))
            {
                if (txtConfirmPassword.Text.Length < 6)
                {
                    //update profile password in database
                }
                else 
                {
                    MessageBox.Show("Password must be atleast 6 characters.");
                }
            }
            else
            {
                MessageBox.Show("Please enter mathcing passwords.");
            }
        }

        private void changeTuteeFunction() 
        {
            if (checkTutee.Checked)
            {
                //still a tutee, possibly changing courses
                if (checkListTuteeCourses.CheckedItems.Count <= MAX_NUM_COURSES && checkListTuteeCourses.CheckedItems.Count > 0)
                {
                    //is in the limit for number of courses allowed
                    //update tutee courses in database
                    tuteeCoursesList.Clear();
                    List<string> selected = new List<string>();

                    foreach (CheckBox item in checkListTuteeCourses.Items)
                    {
                        //makes selected item list
                        if (item.Checked)
                            selected.Add(item.Text);
                    }

                    //tutee course list know has all selected items, need to add to database
                    tuteeCoursesList = selected;
                }
                else 
                {
                    MessageBox.Show("Must have between 1 - 4 tutee courses selected.");
                }
            }
            else 
            { 
                //no longer a tutee, change isTutee bool and clear tutee courses
            }
        }

        private void changeTutorFunction() //Dalton: editProfile is now a function. 
            //To change courses you have to delete the old ones and then add the new ones. 
            //Kind of a pain in the ass but it was easiest on my end
        {
            if (checkTutor.Checked)
            {
                //still a tutor, possibly changing courses
                if (checkListTutorCourses.CheckedItems.Count <= MAX_NUM_COURSES && checkListTutorCourses.CheckedItems.Count > 0)
                {
                    //is in the limit for number of courses allowed
                    //update tutor courses in database
                    List<string> selected = new List<string>();
                    List<bool> approvedBoolList = new List<bool>();

                    Database db = new Database();

                    foreach (CheckBox item in checkListTutorCourses.Items)
                    {
                        //makes selected item list
                        if (item.Checked)
                            selected.Add(item.Text);
                    }

                    for (int i = 0; i < selected.Count; i++) 
                    {
                        if (tutorCourseApprovedList.Contains(selected[i]))
                        {
                            approvedBoolList.Add(true);
                            tutorCourseApprovedList.Insert(i, "true");
                        }
                        else 
                        {
                            //not approved, send message for approval
                            approvedBoolList.Add(false);
                            tutorCourseApprovedList.Insert(i, "false");
                            //Messages m = new Messages();
                        }
                    }

                    //tutor course list is updated to selected items
                    //approved bools are updated and message sent
                    tutorCoursesList.Clear();
                    tutorCoursesList = selected;



                }
                else
                {
                    MessageBox.Show("Must have between 1 - 4 tutor courses selected.");
                }
            }
            else
            {
                //no longer a tutor, change isTutor bool and clear tutor courses
            }
        }



    }
}
