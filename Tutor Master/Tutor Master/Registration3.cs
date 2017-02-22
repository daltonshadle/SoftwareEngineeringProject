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
    public partial class Registration3 : Form
    {
        bool tutorAcc, tuteeAcc;
        string username;

        public Registration3(string user)  //If this constructor is run, it means the profile is only a tutee.
        {
            InitializeComponent();
            tutorAcc = false;
            tuteeAcc = true;
            username = user;
        }
          
        public Registration3(string user, bool isTutor, bool isTutee)    //if this file is run, it means profile is both tutor and tutee
        {
            InitializeComponent();
            tutorAcc = isTutor;
            tuteeAcc = isTutee;
            user = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Garrett write a query: update base Profile to tutee
            var next = new UserProfile(username);
            this.Hide();
            next.Show();
            
        }



    }
}
