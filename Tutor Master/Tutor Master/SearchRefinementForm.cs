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

        public SearchRefinementForm()
        {
            InitializeComponent();
            stateOfProgress = 0;
        }

        public SearchRefinementForm(string username)
        {
            InitializeComponent();
            stateOfProgress = 0;
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
            this.Height = 250;

            startDate = DateTime.MinValue;
            endDate = DateTime.MinValue;
            tutor = "";

            populateTutors(course);
        }

        public void populateTutors(string course)
        {
            Database db = new Database();

            HashSet<Appointment> courseSet = getCourseSet(course);
            
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

            bool canTutorThisCourse = false;

            //For every free time appointment
            for (int i = 0; i < allFreeTimeAppointmentsArray.Length; i++)
            {
                string tutor = allFreeTimeAppointmentsArray[i].getFreeTimeProf();

                List<string> tutorCourseList = new List<string>();
                List<string> allTutorInfo = db.getProfileInfo(tutor);
                //Determine if owner of free time can tutor that course
                for (int j = 8; j < 11; j++)
                {
                    if (allTutorInfo[j] != "")
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
                    this.Width = 550;
                    break;
                case 1:
                    stateOfProgress = 0;
                    btnMoreFields.Text = "Show More Criteria";
                    this.Width = 289;
                    startDate = DateTime.MinValue;
                    endDate = DateTime.MinValue;
                    tutor = "";
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
                }                   
                else
                {
                    tutorSet = db.getAppointmentTutorSet(comboTutor.SelectedItem.ToString());
                    masterSearchSet = intersection(masterSearchSet, tutorSet);
                }


            }



            MessageBox.Show(masterSearchSet.Count.ToString());

            //MessageBox.Show("Course = " + course + "\nStart Date = " + startDate + "\nEnd date = " + endDate + "\nTutor = " + tutor + "\nPlace = " + place);


            //Garrett: Going to need a function that retrieves all appointments.
            /*Database function: 
             * private List<Appointment> getCorrespondingAppointments(string course, DateTime date, DateTime time, string tutor, string place)
             * Pre: all arguments could be null or they might have a value
             * Post: returns a list of all of the free time appointments that match the argumental criteria.
             * Function: for the arguments which are not null, function adds appointments to the list if they match the input arguments
             * */
        }

        private void comboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateTutors(comboCourse.SelectedItem.ToString());
        }
    }
}
