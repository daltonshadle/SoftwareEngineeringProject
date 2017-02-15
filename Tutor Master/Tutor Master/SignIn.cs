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
    public partial class SignIn : Form
    {
        private string username, password;
        public SignIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            username = tbxUsername.Text;
            password = tbxPassword.Text;
            bool valid = false;

            //Run sign in function under Profile class polimorphically
            Profile person = new Profile();
            person.signIn(username, password, ref valid);

            //check username and password through database
            //check if username is there and if password matches

            //bool nameMatch = true; //Set as conditional if username is in database
            bool passMatch = true; //Set as conditional if password matches username

            //nameMatch = false;
            if (valid)
            {
                if (passMatch)
                {
                    var profile = new UserProfile(username + " Profile");
                    profile.Show();
                    this.Hide();
                    //move to profile form, successfully signed in
                }
                else 
                {
                    lblPassError.Visible = true;
                    //password doesn't match, display error message
                }
            }
            else 
            {
                lblNameError.Visible = true;
                //username doesn't match database, display error message
            }
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
