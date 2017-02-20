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

        public Registration()
        {
            InitializeComponent();
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
            
            if (isTutor)
            {
                //Garrett write a query: update base Profile to tutor
                var next = new Registration2(isTutor, isTutee);
                this.Hide();
                next.Show();
            }
            if (isTutee)
            {
                //Garrett write a query: update base Profile to tutee
                var next = new Registration3(isTutor, isTutee);
                this.Hide();
                next.Show();
            }

            
        }

    }
}
