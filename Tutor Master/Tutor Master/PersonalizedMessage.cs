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
    public partial class PersonalizedMessage : Form
    {
        private Messages message;
        private Boolean approved;

        public PersonalizedMessage(Messages message, Boolean approved)
        {
            InitializeComponent();
            this.message = message;
            this.approved = approved;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            RichTextBox myTextBox = rtbMessage;
            string extraMessage = myTextBox.Text.ToString();
            string finalMessage = message.getMessage() + "\n\n" + extraMessage;
            if (finalMessage.Length > 1000)
                MessageBox.Show("Personalized message can't exceed 1000 characters.");
            else 
            {
                Database db = new Database();
                db.approveCourseInTutorCourses(message.getToUser(), message.getCourseName(), message.getIdNum(), approved);
                db.sendMessage(message.getFromUser(), message.getToUser(), message.getSubject(), finalMessage, true, DateTime.Now, message.getCourseName(), -1); 
            }

            this.Hide();
        }

        
    }
}
