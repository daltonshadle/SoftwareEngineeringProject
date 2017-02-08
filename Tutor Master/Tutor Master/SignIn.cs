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
            username = tbxUsername.ToString();
            password = tbxPassword.ToString();

            //check username and password through database
            //check if username is there and if password matches

            bool nameMatch = true; //Set as conditional if username is in database
            bool passMatch = true; //Set as conditional if password matches username

            if (nameMatch)
            {
                if (passMatch)
                {
                    //move to profile form, successfully signed in
                }
                else 
                { 
                    //password doesn't match, display error message
                }
            }
            else 
            { 
                //username doesn't match database, display error message
            }
            
        }
    }
}
