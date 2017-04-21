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
    public partial class SearchRefinementForm : Form
        //This form will allow people to refine their searches. With no refinements, you will be able to see all tutor set ups.
            //When you refine by course, you can either search then or refine by time, then search or refine by tutor then search
            //If a refinement is not filled, you will not see the other possibilities.

        //This form is only accessible for tutees.

    {
        private int stateOfProgress;    //This variable will tell what search refinements are being used
        private string user;
        private string course;
        private DateTime startDate;
        private DateTime endDate;
        private string tutor;
        private List<string> tutorList;
        private List<string> placeList;
        HashSet<Appointment> setToDisplay;
        List<Appointment> listToDisplay;
        private int currentIndex = -1;   //used for the selecting items in listview

        public SearchRefinementForm()
        {
            InitializeComponent();
            stateOfProgress = 0;
            setToDisplay = new HashSet<Appointment>();
            listToDisplay = new List<Appointment>();
        }

        public SearchRefinementForm(string username)
        {
            InitializeComponent();
            stateOfProgress = 0;
            setToDisplay = new HashSet<Appointment>();
            listToDisplay = new List<Appointment>();
            user = username;

            Database db = new Database();
            List<string> allProfileInfo = db.getProfileInfo(user);

            for (int i = 4; i < 7; i++)
            {
                if (allProfileInfo[i] != "")
                    comboCourse.Items.Add(allProfileInfo[i]);
            }
            comboCourse.SelectedItem = allProfileInfo[4];
            course = allProfileInfo[4];

            this.Width = 290;
            this.Height = 270;

            startDate = DateTime.MinValue;
            endDate = DateTime.MinValue;
            tutor = "";

            populateTutors(course);
        }

        public void populateTutors(string course)
        {
            Database db = new Database();

            HashSet<Appointment> courseSet = db.getAppointmentCourseSet(course);
            
            Appointment[] list2 = new Appointment[courseSet.Count];
            courseSet.CopyTo(list2);
            
            string[] tutorComboList = new string[list2.Length];

            for (int i = 0; i < courseSet.Count; i++)
            {
                bool add = true;
                for (int j = 0; j < tutorComboList.Length; j++ )
                {
                    if (tutorComboList[j] == list2[i].getFreeTimeProf())
                        add = false;
                }
                
                if (add)
                    tutorComboList[i] = list2[i].getFreeTimeProf();
            }
            
            comboTutor.Items.Clear();

            for (int l = 0; l < tutorComboList.Length; l++)
            {
                if (tutorComboList[l] != null)
                    comboTutor.Items.Add(tutorComboList[l]);
            }
        }

        private HashSet<Appointment> getCourseSet(string course)
        {
            HashSet<Appointment> appointmentSet = new HashSet<Appointment>();

            Database db = new Database();

            HashSet<Appointment> allFreeTimeAppointmentsSet = db.getAllFreeTimeAppointments();
            Appointment[] allFreeTimeAppointmentsArray = new Appointment[allFreeTimeAppointmentsSet.Count];
            allFreeTimeAppointmentsSet.CopyTo(allFreeTimeAppointmentsArray);

            bool canTutorThisCourse;

            //For every free time appointment
            for (int i = 0; i < allFreeTimeAppointmentsArray.Length; i++)
            {
                string tutor = allFreeTimeAppointmentsArray[i].getFreeTimeProf();
                canTutorThisCourse = false;

                List<string> tutorCourseList = new List<string>();
                List<string> allTutorInfo = db.getProfileInfo(tutor);
                //Determine if owner of free time can tutor that course
                for (int j = 8; j < 11; j++)
                {
                    if ((allTutorInfo[j] != "") && (allTutorInfo[j+4] == "True"))
                    {
                        tutorCourseList.Add(allTutorInfo[j]);
                    }
                }

                for (int k = 0; k < tutorCourseList.Count; k++)
                {
                    if (course == tutorCourseList[k])
                        canTutorThisCourse = true;
                }
                //If the owner of the free time can tutor that course, add that tutor.
                if (canTutorThisCourse)
                {
                    appointmentSet.Add(allFreeTimeAppointmentsArray[i]);
                }
            }
            return appointmentSet;
        }

        private void comboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboTutor.ResetText();
            checkTutor.Checked = false;
            populateTutors(comboCourse.SelectedItem.ToString());
            rtbInfo.Clear();
            lvMatches.Clear();
        }

        //Written by Garrett to override the .Intersect() function for a set
        static HashSet<Appointment> intersection(HashSet<Appointment> A, HashSet<Appointment> B)
        {
            HashSet<Appointment> C = new HashSet<Appointment>();
            foreach (Appointment appt in A)
            {
                foreach (Appointment appt2 in B)
                {
                    if (appt.getID() == appt2.getID())
                        C.Add(appt);
                }
            }

            return C;
        }

        private void btnMoreFields_Click(object sender, EventArgs e)
        {
            switch (stateOfProgress)
            {
                case 0:
                    stateOfProgress = 1;
                    btnMoreFields.Text = "Show Less Criteria";
                    this.Width = 570;
                    panel2.Visible = true;
                    lblStartDate.Visible = true;
                    lblEndDate.Visible = true;
                    lblTutor.Visible = true;
                    dateTimeStartDate.Visible = true;
                    dateTimeEndDate.Visible = true;
                    comboTutor.Visible = true;
                    checkDates.Visible = true;
                    checkTutor.Visible = true;
                    break;
                case 1:
                    stateOfProgress = 0;
                    btnMoreFields.Text = "Show More Criteria";

                    if(this.Height != 550)
                        this.Width = 289;

                    panel2.Visible = false;
                    startDate = DateTime.MinValue;
                    endDate = DateTime.MinValue;
                    lblStartDate.Visible = false;
                    lblEndDate.Visible = false;
                    lblTutor.Visible = false;
                    dateTimeStartDate.Visible = false;
                    dateTimeEndDate.Visible = false;
                    comboTutor.Visible = false;
                    checkDates.Visible = false;
                    checkTutor.Visible = false;
                    checkDates.Checked = false;
                    checkTutor.Checked = false;
                    break;
            }        

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            HashSet<Appointment> courseSet;
            HashSet<Appointment> dateSet;
            HashSet<Appointment> tutorSet;
            HashSet<Appointment> masterSearchSet = db.getAllFreeTimeAppointments();
            
            //Get all the search criteria.
            course = comboCourse.SelectedItem.ToString();
            courseSet = getCourseSet(course);

            masterSearchSet = intersection(masterSearchSet, courseSet);

            bool operate = true;
            if (checkDates.Checked)
            {
                dateSet = db.getAppointmentDateSet(dateTimeStartDate.Value, dateTimeEndDate.Value);
                masterSearchSet = intersection(masterSearchSet, dateSet);
            }

            if (checkTutor.Checked)
            {
                if (comboTutor.SelectedItem == null)
                {
                    MessageBox.Show("Search by tutor is checked but not filled.");
                    operate = false;
                }                   
                else
                {
                    tutorSet = db.getAppointmentTutorSet(comboTutor.SelectedItem.ToString());
                    masterSearchSet = intersection(masterSearchSet, tutorSet);
                    operate = true;
                }


            }

            if (operate)
            {
                setToDisplay = masterSearchSet;
                listToDisplay = masterSearchSet.OrderBy(o => o.getStartTime()).ToList<Appointment>();
                displayAppointments();
            }
        }

        private void displayAppointments()
        {
            this.Height = 550;
            this.Width = 570;

            lvMatches.Clear();

            for (int i = 0; i < listToDisplay.Count; i++)
            {
                lvMatches.Items.Add("Appointment with " + listToDisplay[i].getFreeTimeProf());
            }

            if (listToDisplay.Count == 0)
            {
                rtbInfo.Clear();
                MessageBox.Show("No appointments match these criteria.");
            }
        }

        private void lvMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMatches.SelectedItems.Count != 1)
                rtbInfo.Clear();
            else
            {
                rtbInfo.Clear();
                ListView.SelectedIndexCollection indexes = this.lvMatches.SelectedIndices;
                if (indexes.Count > 1)
                    MessageBox.Show("Can only view details of one message at a time.");
                else
                {
                    foreach (int index in indexes)
                    {

                        rtbInfo.AppendText("Free time with " + listToDisplay[index].getFreeTimeProf()
                            + "\nFrom: " + listToDisplay[index].getStartTime().ToShortTimeString()
                            + "\n    On: " + listToDisplay[index].getStartTime().ToShortDateString()
                            + "\nTo: " + listToDisplay[index].getEndTime().ToShortTimeString()
                            + "\n    On: " + listToDisplay[index].getEndTime().ToShortDateString());
                        currentIndex = index;


                    }
                }
            }
        }

        private void dateTimeStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeStartDate.Value.Date < DateTime.Now.Date)
            {
                dateTimeStartDate.Value = DateTime.Now.Date;
            }

            if (dateTimeEndDate.Value.Date < dateTimeStartDate.Value.Date)
            {
                dateTimeEndDate.Value = dateTimeStartDate.Value.Date;
            }
        }

        private void dateTimeEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeEndDate.Value.Date < dateTimeStartDate.Value.Date)
            {
                if (dateTimeEndDate.Value.Date >= DateTime.Now.Date)
                {
                    dateTimeStartDate.Value = dateTimeEndDate.Value.Date;
                }
                else
                {
                    dateTimeEndDate.Value = dateTimeStartDate.Value.Date;
                }
            }
        }

        private void btnAskToJoin_Click(object sender, EventArgs e)
        {
            if (lvMatches.SelectedItems.Count == 1) 
            {

                string tutor = listToDisplay[currentIndex].getFreeTimeProf();
                Appointment a = listToDisplay[currentIndex];

                Database db = new Database();
                db.editAppointment(a.getID(), null, null, course, a.getStartTime(), a.getEndTime(), a.getFreeTimeProf(), user, false, false, "MatchWithExistingAppointment");
                db.sendMessage(user, tutor, "Free Time Filled.", user + " has requested to be tutored by you in " +course+ " on " +a.getStartTime().ToShortDateString()+ " at "+a.getStartTime().ToShortTimeString()+".", false, DateTime.Now, course, a.getID());

                MessageBox.Show("A request message has been sent to " + tutor);
                this.Hide();
                this.Close();
            }
            else 
            {
                MessageBox.Show("One and only one appointment must be selected.");
            }
        }


    }
}
