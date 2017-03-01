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
    public partial class UserProfile : Form
    {
        String first, last;

        private bool tutorAcc, tuteeAcc;

        public UserProfile(string Title)
        {
            InitializeComponent();

            //Database db = new Database();
            //Garrett: db.retrieveInfo(string first, string last, .... )

            first = "dalton";
            last = "shadle";
            this.Text = FirstLetterToUpper(first) + " " + FirstLetterToUpper(last);


            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }

        //Function casts the first letter of the string to be capitalized...
        //But not sure if we really want that honestly.

        //This would assume that we automatically cast usernames to lower so that coolTerry7 == coolterry7
        public string FirstLetterToUpper(string str)
        {
            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var form = new StartForm();
            form.Show();
            this.Hide();
        }

    }
}
