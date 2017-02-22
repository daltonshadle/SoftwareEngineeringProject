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
        bool isTutee = false, isTutor = false;
        string username;

        public Registration(string user)
        {
            InitializeComponent();
            username = user;
        }

        private void chkTutor_CheckedChanged(object sender, EventArgs e)
        {
            isTutor = true;
        }

        private void chkTutee_CheckedChanged(object sender, EventArgs e)
        {
            isTutee = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            if (isTutor)    //This loop handles exclusively tutor and both tutor&tutee profiles.
            {
                //Garrett write a query: update base Profile to tutor
                var next = new Registration2(username, isTutor, isTutee);
                this.Hide();
                next.Show();
            }
             
            //This is set as an else because if the person is both tutor&tutee, then they will go through
            //the tutor page and then THAT tutor page will decide whether or not the tutee page will run.
            //This loop is only for exclusively tutee profiles.
            else    
            {  

                //Garrett write a query: update base Profile to tutee
                var next = new Registration3(username);
                this.Hide();
                next.Show();
            }

            
        }

    }
}
