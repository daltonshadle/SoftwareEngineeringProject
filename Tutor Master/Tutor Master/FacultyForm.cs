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
        private static bool INBOX = true;

        private List<Messages> sentMessageList;
        private List<Messages> inboxMessageList;
        Database db = new Database();
        int currentIndex = -1;

        string user;

        public FacultyForm(string username)
        {
            InitializeComponent();
            user = username;
            sentMessageList = db.getSentMail(username);
            inboxMessageList = db.getInbox(username);
            

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
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            INBOX = true;
            lblMessages.Text = "Inbox";
            button1.Visible = true;
            button2.Visible = true;
            lvMessages.Items.Clear();
            inboxMessageList.Clear();
            inboxMessageList = db.getInbox(user);
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
            INBOX = false;
            lblMessages.Text = "Sent Messages";
            lvMessages.Items.Clear();
            sentMessageList.Clear();
            sentMessageList = db.getSentMail(user);
            button1.Visible = false;
            button2.Visible = false;
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
            //check if selected index is what you want for "True" and "False" or currentIndex
            if (currentIndex == -1)
                MessageBox.Show("No message selected");
            else
            {
                if (INBOX)
                {
                    //MessageBox.Show("About to approve " + inboxMessageList[currentIndex].getMessage());
                    if (lvMessages.SelectedItems[0].SubItems[4].Text == "False")
                    {
                        db.approveCourseInTutorCourses(inboxMessageList[currentIndex].getFromUser(), inboxMessageList[currentIndex].getCourseName(), inboxMessageList[currentIndex].getIdNum(), true);
<<<<<<< HEAD
=======
<<<<<<< HEAD
                        db.sendMessage(user, inboxMessageList[currentIndex].getFromUser(), "Tutor Request Approved", user + " has approved you to tutor " + inboxMessageList[currentIndex].getCourseName(), true, DateTime.Now, inboxMessageList[currentIndex].getCourseName(), -1);
                        //db.sendMessage(user, inboxMessageList[currentIndex].getFromUser(), "Tutor Request Approved", user + " has approved you to tutor " + inboxMessageList[currentIndex].getCourseName(), true, DateTime.Now, inboxMessageList[currentIndex].getCourseName());
                        db.sendMessage(user, inboxMessageList[currentIndex].getFromUser(), "Tutor Request Approved", user + " has approved you to tutor " + inboxMessageList[currentIndex].getCourseName(), true, DateTime.Now, inboxMessageList[currentIndex].getCourseName(), -1);

=======
>>>>>>> ca475ba45a79d02bd5214e5ce263526545bc5701
                        db.sendMessage(user, inboxMessageList[currentIndex].getFromUser(), "Tutor Request Approved", user + " has approved you to tutor " + inboxMessageList[currentIndex].getCourseName(), true, DateTime.Now, inboxMessageList[currentIndex].getCourseName(), -1);
>>>>>>> 6a2b23e22b9cd7fd4d44aa9939e188240f1b7b90
                        lvMessages.SelectedItems[0].SubItems[4].Text = "True";
                        rtbMessageDetails.Clear();
                        rtbMessageDetails.AppendText("Done");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //check if selected index is what you want for "True" and "False" or currentIndex
            if (currentIndex == -1)
                MessageBox.Show("No message selected");
            else
            {
                if (INBOX)
                {
                    //MessageBox.Show("About to approve " + inboxMessageList[currentIndex].getMessage());
                    if (lvMessages.SelectedItems[0].SubItems[4].Text == "False")
                    {
                        db.approveCourseInTutorCourses(inboxMessageList[currentIndex].getFromUser(), inboxMessageList[currentIndex].getCourseName(), inboxMessageList[currentIndex].getIdNum(), false);
<<<<<<< HEAD
=======
<<<<<<< HEAD
                        //db.sendMessage(user, inboxMessageList[currentIndex].getFromUser(), "Tutor Request REJECTED", user + " has not approved you to tutor " + inboxMessageList[currentIndex].getCourseName(), true, DateTime.Now, inboxMessageList[currentIndex].getCourseName());
                        db.sendMessage(user, inboxMessageList[currentIndex].getFromUser(), "Tutor Request REJECTED", user + " has not approved you to tutor " + inboxMessageList[currentIndex].getCourseName(), true, DateTime.Now, inboxMessageList[currentIndex].getCourseName(), -1);

=======
>>>>>>> ca475ba45a79d02bd5214e5ce263526545bc5701
                        db.sendMessage(user, inboxMessageList[currentIndex].getFromUser(), "Tutor Request REJECTED", user + " has not approved you to tutor " + inboxMessageList[currentIndex].getCourseName(), true, DateTime.Now, inboxMessageList[currentIndex].getCourseName(), -1);
>>>>>>> 6a2b23e22b9cd7fd4d44aa9939e188240f1b7b90
                        lvMessages.SelectedItems[0].SubItems[4].Text = "True";
                        rtbMessageDetails.Clear();
                        rtbMessageDetails.AppendText("Done");
                    }                   
                }
            }
        }

        private void lvMessages_SelectedIndexChanged_1(object sender, EventArgs e)
        {
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



    }
}
