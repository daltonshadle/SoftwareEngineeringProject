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
    public partial class Registration2 : Form
    {
        bool tutorAcc, tuteeAcc;

        public Registration2()
        {
            InitializeComponent();
        }

        public Registration2(bool isTutor, bool isTutee)
        {
            InitializeComponent();
            tutorAcc = isTutor;
            tuteeAcc = isTutee;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Scott: store the selected classes in a list. 

            //Faculty gets emailed here.

            //Garrett, at this point the user would have selected their classes. Query to send stuff to faculty?

            if (tuteeAcc) 
            {
            //Garrett write a query: update base Profile to tutee
            var next = new Registration3(tutorAcc, tuteeAcc);
            this.Hide();
            next.Show();
            }
                
        }

    }

}
