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
        private bool isAllEditGood = true;
        private string first, last, user, pass;
        private bool isTutee, isTutor, isFaculty, isAdmin;
        private int numTuteeCourses = 0, numTutorCourses = 0, numApprovedCourses = 0;

        List<string> tuteeCoursesList;
        List<string> tutorCoursesList;
        List<string> tutorCourseApprovedList;
        List<string> profileInfo;

        private bool changePass, changeName, changeTutor, changeTutee;

        private string newFirst, newLast, newPass;
        private bool newIsTutee, newIsTutor, newIsFaculty, newIsAdmin;

        Database db = new Database();

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

            pass = db.getUserPassword(username);

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
            isAllEditGood = true;

            if (changeName)
            {
                changeNameFunction();
            }
            else 
            {
                newFirst = first;
                newLast = last;
            }

            if (changePass && isAllEditGood)
            {
                changePasswordFunction();
            }
            else 
            {
                newPass = pass;
            }

            if (changeTutee && isAllEditGood)
            {
                if (checkTutorAndTuteeCourseOverlap())
                {
                    //don't overlap and all is good
                    changeTuteeFunction();
                }
                else {
                    isAllEditGood = false;
                    MessageBox.Show("Tutor and tutee courses cannot overlap.");
                }
                //tuteeCourseList should be updated
            }
            else
            {
                newIsTutee = isTutee;
            }

            if (changeTutor && isAllEditGood)
            {
                if (checkTutorAndTuteeCourseOverlap())
                {
                    changeTutorFunction();
                    //tutorCourseList should be updated
                    //tutorApprovedCourseList should be updated
                }
                else 
                {
                    isAllEditGood = false;
                    MessageBox.Show("Tutor and tutee courses cannot overlap.");
                }
            }
            else
            {
                newIsTutor = isTutor;
            }

            //all good to go with the edit
            if (isAllEditGood)
            { 
                //confirm edit of person and add info to database
                //close form and have user form refresh
                db.editProfileInfo(user, newFirst, newLast, newPass, newIsTutor, newIsTutee);
                this.Close();
                this.Hide();
            }

        }

        private void changeNameFunction() 
        {
            Database db = new Database();

            if (changeName)
            {
                //checking to see if name had been editted
                if (!txtFirstName.Text.Equals("") && !txtLastName.Text.Equals(""))
                {
                    //update profile first and last in database
                    newFirst = txtFirstName.Text;
                    newLast = txtLastName.Text;
                }
                else
                {
                    MessageBox.Show("Please enter first and last name.");
                    isAllEditGood = false;
                }
            }
            else 
            {
                newFirst = first;
                newLast = last;
            }
        }

        private void changePasswordFunction()
        {
            if (changePass)
            {
                //checking to see if the pass was editted
                if (txtNewPassword.Text.Equals(txtConfirmPassword.Text) && !txtConfirmPassword.Text.Equals(""))
                {
                    if (txtConfirmPassword.Text.ToString().Length >= 6)
                    {
                        //update profile password in database
                        newPass = txtNewPassword.Text;
                    }
                    else
                    {
                        MessageBox.Show("Password must be atleast 6 characters.");
                        isAllEditGood = false;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter matching passwords.");
                    isAllEditGood = false;
                }
            }
            else 
            {
                newPass = pass;
            }
        }

        private void changeTuteeFunction() 
        {
            if (changeTutee)
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

                        for (int x = 0; x < checkListTuteeCourses.CheckedItems.Count; x++)
                        {
                            selected.Add(checkListTuteeCourses.CheckedItems[x].ToString());
                        }

                        //tutee course list know has all selected items, need to add to database
                        tuteeCoursesList = selected;
                        newIsTutee = true;
                        db.deleteTuteeList(user);
                        db.addNewCourseList(user, tuteeCoursesList, false);
                    }
                    else
                    {
                        MessageBox.Show("Must have between 1 - 4 tutee courses selected.");
                        isAllEditGood = false;
                    }
                }
                else
                {
                    //no longer a tutee, change isTutee bool and clear tutee courses
                    newIsTutee = false;
                    db.deleteTuteeList(user);
                }
            }
            else
            {
                newIsTutee = isTutee;
            }

        }

        private void changeTutorFunction()
        {
            if (changeTutor)
            {
                //checking to see if tutor status was editted
                if (checkTutor.Checked)
                {
                    //still a tutor, possibly changing courses
                    if (checkListTutorCourses.CheckedItems.Count <= MAX_NUM_COURSES && checkListTutorCourses.CheckedItems.Count > 0)
                    {
                        //is in the limit for number of courses allowed
                        //update tutor courses in database
                        List<string> selected = new List<string>();
                        List<bool> approvedBoolList = new List<bool>();

                        for (int x = 0; x < checkListTutorCourses.CheckedItems.Count; x++)
                        {
                            selected.Add(checkListTutorCourses.CheckedItems[x].ToString());
                        }

                        for (int i = 0; i < selected.Count; i++)
                        {
                            if (tutorCoursesList.Contains(selected[i]))
                            {
                                //need to check approval here
                                if (tutorCourseApprovedList[tutorCoursesList.IndexOf(selected[i])] == "True")
                                {
                                    approvedBoolList.Add(true);
                                    //tutorCourseApprovedList.Insert(i, "true");
                                }
                                else 
                                {
                                    approvedBoolList.Add(false);
                                    //tutorCourseApprovedList.Insert(i, "false");
                                }
                            }
                            else
                            {
                                //not approved, send message for approval
                                approvedBoolList.Add(false);
                                //tutorCourseApprovedList.Insert(i, "false");
                                string facultyApprover = db.getFacultyApprover(selected[i]);
                                db.sendMessage(user, facultyApprover, "Tutor Request", user + " is requesting to tutor " + selected[i], false, DateTime.Now, selected[i], -1);
                            }
                        }

                        //tutor course list is updated to selected items
                        //approved bools are updated and message sent
                        tutorCoursesList.Clear();
                        tutorCoursesList = selected;

                        newIsTutor = true;
                        db.deleteTutorList(user);

                        db.addNewCourseList(user, tutorCoursesList, true);
                        setApprovedTutorCourses(approvedBoolList, user);

                    }
                    else
                    {
                        MessageBox.Show("Must have between 1 - 4 tutor courses selected.");
                        isAllEditGood = false;
                    }
                }
                else
                {
                    //no longer a tutor, change isTutor bool and clear tutor courses
                    newIsTutor = false;
                    db.deleteTutorList(user);
                }
            }
            else
            {
                newIsTutor = isTutor;
            }

        }

        private void setApprovedTutorCourses(List<bool> courseList, string username)
        {
            List<bool?> approved = new List<bool?>();

            for (int i = 0; i < 4; i++)
            {
                if (i < courseList.Count)
                {
                    if (courseList[i])
                    {
                        approved.Add(true);
                    }
                    else
                    {
                        approved.Add(null);
                    }
                }
                else 
                {
                    approved.Add(null);
                }
            }

            db.setCourseApproval(username, approved[0], approved[1], approved[2], approved[3]);
        }

        private bool checkTutorAndTuteeCourseOverlap() 
        {
            bool good = true;

            List<string> selectedTutee = new List<string>();

            for (int x = 0; x < checkListTuteeCourses.CheckedItems.Count; x++)
            {
                selectedTutee.Add(checkListTuteeCourses.CheckedItems[x].ToString());
            }

            for (int x = 0; x < checkListTutorCourses.CheckedItems.Count; x++)
            {
                if (selectedTutee.Contains(checkListTutorCourses.CheckedItems[x].ToString()))
                {
                    good = false;
                    break;
                }
            }

            return good;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
