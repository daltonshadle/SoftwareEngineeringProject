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
    public partial class MessagesForm : Form
    {
        //all private data
        private bool INBOX = true;
        private List<Messages> sentMessageList;
        private List<Messages> inboxMessageList;
        Database db = new Database();
        int currentIndex = -1;

        string user;

        //all functions
        //constructor
        public MessagesForm(string username)
        {
            InitializeComponent();
            user = username;
            sentMessageList = db.getSentMail(username);
            inboxMessageList = db.getInbox(username);
            //loading all the messages into listview
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

        //constructor
        public MessagesForm(string username, int index)
        {
            InitializeComponent();
            user = username;
            sentMessageList = db.getSentMail(username);
            inboxMessageList = db.getInbox(username);

            //loading all messages into listview
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

            if (lvMessages.Items.Count > 0)
            {
                lvMessages.Items[index].Selected = true;
                lvMessages.Select();
            }
        }

        //*********************************All listener functions*********************************//
        private void btnInbox_Click(object sender, EventArgs e)
        {
            //function for button to load all inbox messages
            INBOX = true;
            lblMessages.Text = "Inbox";
            lvMessages.Items.Clear();
            inboxMessageList.Clear();
            inboxMessageList = db.getInbox(user);
            rtbMessageDetails.Clear();

            //loading all inbox messages into the listview
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
            //function for button to load all sent messages
            INBOX = false;
            lblMessages.Text = "Sent Messages";
            btnApprove.Visible = false;
            btnReject.Visible = false;
            lvMessages.Items.Clear();
            sentMessageList.Clear();
            sentMessageList = db.getSentMail(user);
            rtbMessageDetails.Clear();

            //loading all sent messages into listview
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
            //function for button to delet a certain message from databse and listview 
            if (lvMessages.SelectedItems.Count == 0)
                MessageBox.Show("No message selected");
            else
            {
                lvMessages.SelectedItems[0].Remove();
                int messageID;
                if (INBOX)
                {
                    //deleting message from inbox, database and listview
                    messageID = inboxMessageList[currentIndex].getIdNum();
                    db.deleteMessageFromInbox(messageID);
                    inboxMessageList.Clear();
                    inboxMessageList = db.getInbox(user);
                }
                else
                {
                    //deleting message from sent box, database and listview
                    messageID = sentMessageList[currentIndex].getIdNum();
                    db.deleteMessageFromSentMail(messageID);
                    sentMessageList.Clear();
                    sentMessageList = db.getSentMail(user);
                }
                rtbMessageDetails.Clear();
            }
        }

        private void lvMessages_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //function to listen for a selected item in listview
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
                            //setting details of the messge in the textbox
                            rtbMessageDetails.AppendText(inboxMessageList[index].getMessage());
                            currentIndex = index;
                            Messages message = inboxMessageList[currentIndex];
                            Appointment appt = db.getAppointmentById(message.getApptId());

                            //showing or hiding buttons based on whether it has been answered or not
                            if (lvMessages.SelectedItems[0].SubItems[4].Text == "True" || appt.getEndTime() < DateTime.Now)
                            {
                                btnApprove.Visible = false;
                                btnReject.Visible = false;
                            }
                            else
                            {
                                btnApprove.Visible = true;
                                btnReject.Visible = true;
                            }
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

        private void btnApprove_Click(object sender, EventArgs e)
        {
            //function for button to approve appointment based on message
            Database db = new Database();

            Messages message = inboxMessageList[currentIndex];
            Appointment appt = db.getAppointmentById(message.getApptId());
            int messageId = message.getIdNum();

            if (messageId != -1)
            {
                if (lvMessages.SelectedItems[0].SubItems[4].Text == "False" && appt.getEndTime() > DateTime.Now)
                {
                    //database functions to approve message, edit appointment, and send message
                    db.approveMessageDetailsFromAppointment(messageId, true);
                    db.editAppointment(appt.getID(), null, appt.getMeetingPlace(), appt.getCourse(), appt.getStartTime(), appt.getEndTime(), appt.getTutor(), appt.getTutee(), false, true, "ApprovedInMessage");
                    db.sendMessage(user, appt.getTutee(), "Appoinment Request Confirmed", user + " has confirmed your appointment regarding " + appt.getCourse(), true, DateTime.Now, appt.getCourse(), appt.getID());

                    //reseting the textbox to affirm that process is done
                    lvMessages.SelectedItems[0].SubItems[4].Text = "True";
                    rtbMessageDetails.Clear();
                    rtbMessageDetails.AppendText("Done");
                }
                else {
                    if (appt.getEndTime() < DateTime.Now)
                        MessageBox.Show("Appointment end time has passed.");
                    else
                        MessageBox.Show("Appointment has already by handled.");
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            //function for rejecting appointment based on the message
            Database db = new Database();

            Messages message = inboxMessageList[currentIndex];
            Appointment appt = db.getAppointmentById(message.getApptId());
            string source = appt.getSource();
            int messageId = message.getIdNum();

            if (messageId != -1)
            {
                if (lvMessages.SelectedItems[0].SubItems[4].Text == "False" && appt.getEndTime() > DateTime.Now)
                {
                    string messageStr = "Your request to be tutored by " + user + " was rejected.";
                    string subject = "Appointment Rejected";
                    switch (source)
                    {
                        //Run this if the appointment was created by a tutee
                        case "TuteeMatch":
                            //database functions for setting message approval, sending a message, and deleting the appointment
                            db.approveMessageDetailsFromAppointment(messageId, true);
                            db.sendMessage(user, appt.getTutee(), subject, messageStr, false, DateTime.Now, appt.getCourse(), appt.getID());
                            db.deleteAppointment(appt.getID());
                            lvMessages.SelectedItems[0].SubItems[4].Text = "True";
                            rtbMessageDetails.Clear();
                            rtbMessageDetails.AppendText("Done");
                            break;

                        //Run this if the appointment was a free time that got paired with.
                        case "MatchWithExistingAppointment":
                            //database functions for setting message approval, sending a message, and reseting the appointment
                            db.approveMessageDetailsFromAppointment(messageId, true);
                            db.sendMessage(user, appt.getTutee(), subject, messageStr, false, DateTime.Now, appt.getCourse(), appt.getID());
                            db.editAppointment(appt.getID(), user, null, null, appt.getStartTime(), appt.getEndTime(), null, null, true, false, "EditForm");
                            
                            lvMessages.SelectedItems[0].SubItems[4].Text = "True";
                            rtbMessageDetails.Clear();
                            rtbMessageDetails.AppendText("Done");
                            break;

                        }
                    }
                else
                {
                    if (appt.getEndTime() < DateTime.Now)
                        MessageBox.Show("Appointment end time has passed.");
                    else
                        MessageBox.Show("Appointment has already by handled.");
                }
            }
        }

    }
}
