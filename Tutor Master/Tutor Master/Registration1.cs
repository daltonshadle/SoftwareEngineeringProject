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
    public partial class Registration : Form
    {
        private bool isTutee = false, isTutor = false;
        string username;

        public Registration(string user)
        {
            InitializeComponent();
            username = user;
            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            Database db = new Database();
            db.deleteAccount(username);
        }

        private void chkTutor_CheckedChanged(object sender, EventArgs e)
        {

            isTutor = chkTutor.Checked;
        }

        private void chkTutee_CheckedChanged(object sender, EventArgs e)
        {
            isTutee = chkTutee.Checked;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            if (isTutor)    //This loop handles exclusively tutor and both tutor&tutee profiles.
            {
                
                //Garrett write a query: update base Profile to tutor
                Database db = new Database();
                db.setTutorStatus(username, isTutor);

                var next = new Registration2(username, isTutor, isTutee, 1000); //1000 is the code for coming from registration 1
                this.Hide();
                next.Show();
            }
             
            //This is set as an else because if the person is both tutor&tutee, then they will go through
            //the tutor page and then THAT tutor page will decide whether or not the tutee page will run.
            //This loop is only for exclusively tutee profiles.
            else if (isTutee)
            {

                //Garrett write a query: update base Profile to tutee
                Database db = new Database();
                db.setTuteeStatus(username, isTutee);
                //username is a string, isTutee is a bool

                var next = new Registration3(username);
                this.Hide();
                next.Show();
            }
            else
            {
                MessageBox.Show("Must choose at least one type of profile.");
                //User did not click either box.
            }

            
        }

    }
}
