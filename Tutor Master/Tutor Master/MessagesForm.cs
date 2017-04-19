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
        private static bool INBOX = true;

        private List<Messages> sentMessageList;
        private List<Messages> inboxMessageList;
        Database db = new Database();
        int currentIndex = -1;

        string user;

        public MessagesForm(string username)
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
            lvMessages.Items.Clear();
            inboxMessageList.Clear();
            inboxMessageList = db.getInbox(user);
            rtbMessageDetails.Clear();
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
            btnApprove.Visible = false;
            btnReject.Visible = false;
            lvMessages.Items.Clear();
            sentMessageList.Clear();
            sentMessageList = db.getSentMail(user);
            rtbMessageDetails.Clear();
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
                rtbMessageDetails.Clear();
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


        private void btnApprove_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            Messages message = inboxMessageList[currentIndex];
            Appointment appt = db.getAppointmentById(message.getApptId());
            int messageId = message.getIdNum();

            if (messageId != -1)
            {
                if (lvMessages.SelectedItems[0].SubItems[4].Text == "False" && appt.getEndTime() > DateTime.Now)
                {
                    db.approveMessageDetailsFromAppointment(messageId, true);
                    db.editAppointment(appt.getID(), null, appt.getMeetingPlace(), appt.getCourse(), appt.getStartTime(), appt.getEndTime(), appt.getTutor(), appt.getTutee(), false, true, "ApprovedInMessage");
                    db.sendMessage(user, appt.getTutee(), "Appoinment Request Confirmed", user + " has confirmed your appointment regarding " + appt.getCourse(), true, DateTime.Now, appt.getCourse(), appt.getID());
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
            Database db = new Database();

            Messages message = inboxMessageList[currentIndex];
            Appointment appt = db.getAppointmentById(message.getApptId());
            int messageId = message.getIdNum();

            if (messageId != -1)
            {
                db.approveMessageDetailsFromAppointment(messageId, false);
                db.editAppointment(appt.getID(), null, appt.getMeetingPlace(), appt.getCourse(), appt.getStartTime(), appt.getEndTime(), appt.getTutor(), appt.getTutee(), false, true, "ApprovedInMessage");
                //db.editAppointment(
                db.sendMessage(user, appt.getTutee(), "Appoinment Request Confirmed", user + " has confirmed your appointment regarding " + appt.getCourse(), true, DateTime.Now, appt.getCourse(), appt.getID());
            }
        }




    }
}
