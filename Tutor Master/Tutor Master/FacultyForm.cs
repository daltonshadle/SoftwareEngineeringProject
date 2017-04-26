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
    public partial class FacultyForm : Form
    {
        //all private data
        private static bool INBOX = true;

        private List<Messages> sentMessageList;
        private List<Messages> inboxMessageList;
        Database db = new Database();
        int currentIndex = -1;
        private string course;
        List<string> courses;

        string user;

        //all public functions
        //constructor by username
        public FacultyForm(string username)
        {
            InitializeComponent();
            user = username;
            sentMessageList = db.getSentMail(username);
            inboxMessageList = db.getInbox(username);

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnLogout, "Logout");
            initName();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            
            //adding message contents to listview
            for (int i = 0; i < inboxMessageList.Count(); i++)
            {
                ListViewItem listItem = new ListViewItem(inboxMessageList[i].getFromUser());
                listItem.SubItems.Add(inboxMessageList[i].getToUser());
                listItem.SubItems.Add(inboxMessageList[i].getSubject());
                DateTime tempDate = inboxMessageList[i].getTimeSent();
                listItem.SubItems.Add(tempDate.ToString("MM/dd/yyyy h:mm tt"));
                listItem.SubItems.Add(inboxMessageList[i].getPending().ToString());
                lvMessages.Items.Add(listItem);
            }

            courses = db.getFacultyMemberCourses(user);
            initCourseView();
        }

        private void initCourseView()
        {
            //adding message contents to listview
            for (int i = 0; i < courses.Count(); i++)
            {
                ListViewItem listItem = new ListViewItem(courses[i]);
                lvCourses.Items.Add(listItem);
            }
        }

        //fucntion to initialize name textview of form from database
        private void initName() {
            Database db = new Database();
            List<string> listOfProfileInfo = db.getProfileInfo(user);
            string first = listOfProfileInfo[0];
            string last = listOfProfileInfo[1];

            if (first != "")
            {
                this.Text = FirstCharToUpper(first) + " " + FirstCharToUpper(last);
                lblNameAndUser.Text = FirstCharToUpper(first) + " " + FirstCharToUpper(last) + " - " + user;
            }
            else
            {
                this.Text = user;
                lblNameAndUser.Text = user;
            }
        }

        //helper function to capitalize first char in string
        public string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        //Changes what is displayed on the screen in the tutors list view
        private void updatelvTutors()
        {
            lvTutors.Items.Clear();

            if (lvCourses.SelectedItems.Count == 1)
            {
                ListView.SelectedIndexCollection indexes = this.lvCourses.SelectedIndices;
                if (indexes.Count > 1)
                    MessageBox.Show("Can only view one profile at a time.");
                else
                {
                    foreach (int index in indexes)
                        course = courses[index];

                    List<string> tutors = db.getAllTutorsForCourse(course);

                    for (int i = 0; i < tutors.Count; i++)
                    {
                        lvTutors.Items.Add(tutors[i]);
                    }

                }
            }
        }
        //*********************************All listener functions*********************************//
        private void btnInbox_Click(object sender, EventArgs e)
        {
            rtbMessageDetails.Clear();
            currentIndex = -1;
            INBOX = true;
            lblMessages.Text = "Inbox";
            button1.Visible = true;
            button2.Visible = true;
            lvMessages.Items.Clear();
            inboxMessageList.Clear();
            inboxMessageList = db.getInbox(user);

            //loads listview with indox messages of faculty user
            for (int i = 0; i < inboxMessageList.Count(); i++)
            {
                ListViewItem listItem = new ListViewItem(inboxMessageList[i].getFromUser());
                listItem.SubItems.Add(inboxMessageList[i].getSubject());
                listItem.SubItems.Add(inboxMessageList[i].getSubject());
                DateTime tempDate = inboxMessageList[i].getTimeSent();
                listItem.SubItems.Add(tempDate.ToString("MM/dd/yyyy  h:mm tt"));
                listItem.SubItems.Add(inboxMessageList[i].getPending().ToString());
                lvMessages.Items.Add(listItem);
            }
        }

        private void btnSent_Click(object sender, EventArgs e)
        {
            rtbMessageDetails.Clear();
            currentIndex = -1;
            INBOX = false;
            lblMessages.Text = "Sent Messages";
            lvMessages.Items.Clear();
            sentMessageList.Clear();
            sentMessageList = db.getSentMail(user);
            button1.Visible = false;
            button2.Visible = false;

            //loads all sent mail of faculty user
            for (int i = 0; i < sentMessageList.Count(); i++)
            {
                ListViewItem listItem = new ListViewItem(sentMessageList[i].getFromUser());
                listItem.SubItems.Add(sentMessageList[i].getToUser());
                listItem.SubItems.Add(sentMessageList[i].getSubject());
                DateTime tempDate = sentMessageList[i].getTimeSent();
                listItem.SubItems.Add(tempDate.ToString("MM/dd/yyyy  h:mm tt"));
                lvMessages.Items.Add(listItem);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //function to delete selected message from listview and database
            if (lvMessages.SelectedItems.Count == 0)
                MessageBox.Show("No message selected");
            else
            {
                lvMessages.SelectedItems[0].Remove();
                int messageID;
                if (INBOX)
                {
                    messageID = inboxMessageList[currentIndex].getIdNum();
                    db.deleteMessageFromInbox(messageID);
                }
                else
                {
                    messageID = sentMessageList[currentIndex].getIdNum();
                    db.deleteMessageFromSentMail(messageID);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //function for approving a tutor status in a message
            //check if selected index is what you want for "True" and "False" or currentIndex
            if (currentIndex == -1)
                MessageBox.Show("No message selected");
            else
            {
                if (INBOX)
                {
                    if (lvMessages.SelectedItems[0].SubItems[4].Text == "False")
                    {
                        db.approveCourseInTutorCourses(inboxMessageList[currentIndex].getFromUser(), inboxMessageList[currentIndex].getCourseName(), inboxMessageList[currentIndex].getIdNum(), true);
                        db.sendMessage(user, inboxMessageList[currentIndex].getFromUser(), "Tutor Request Approved", user + " has approved you to tutor " + inboxMessageList[currentIndex].getCourseName(), true, DateTime.Now, inboxMessageList[currentIndex].getCourseName(), -1);

                        lvMessages.SelectedItems[0].SubItems[4].Text = "True";
                        rtbMessageDetails.Clear();
                        rtbMessageDetails.AppendText("Done");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //function for rejecting a tutor status in a message
            //check if selected index is what you want for "True" and "False" or currentIndex
            if (currentIndex == -1)
                MessageBox.Show("No message selected");
            else
            {
                if (INBOX)
                {
                    if (lvMessages.SelectedItems[0].SubItems[4].Text == "False")
                    {
                        db.approveCourseInTutorCourses(inboxMessageList[currentIndex].getFromUser(), inboxMessageList[currentIndex].getCourseName(), inboxMessageList[currentIndex].getIdNum(), false);
                        db.sendMessage(user, inboxMessageList[currentIndex].getFromUser(), "Tutor Request REJECTED", user + " has not approved you to tutor " + inboxMessageList[currentIndex].getCourseName(), true, DateTime.Now, inboxMessageList[currentIndex].getCourseName(), -1);

                        lvMessages.SelectedItems[0].SubItems[4].Text = "True";
                        rtbMessageDetails.Clear();
                        rtbMessageDetails.AppendText("Done");
                    }                   
                }
            }
        }

        private void lvMessages_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //function to display message details of a selected message
            if (lvMessages.SelectedItems.Count == 1)
            {
                rtbMessageDetails.Clear();
                ListView.SelectedIndexCollection indexes = this.lvMessages.SelectedIndices;
                if (indexes.Count > 1)
                    MessageBox.Show("Can only view details of one message at a time.");
                else
                {
                    foreach (int index in indexes)
                    {
                        if (INBOX)
                        {
                            rtbMessageDetails.AppendText(inboxMessageList[index].getMessage());
                            currentIndex = index;
                        }
                        else
                        {
                            rtbMessageDetails.AppendText(sentMessageList[index].getMessage());
                            currentIndex = index;
                        }
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var form = new StartForm();
            form.Show();
            this.Hide();
        }

        private void lvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatelvTutors();
        }
    }
}
