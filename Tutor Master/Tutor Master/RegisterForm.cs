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
    public partial class RegisterForm : Form
    {
        private string username, password;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            username = tbxUsername.Text;
            password = tbxPassword.Text;
            bool userValid = false;

            //Check to see if the username is available or not. Function returns bool by ref. Garrett
            //checkValidity(username, ref userValid);

            if (userValid)  //valid username means the username is available.
            {
                bool passValid = ((password.Length > 5) && (!password.Contains(" ")));
                if (passValid)  //valid password means it is at least
                {
                    //Register the account username/password combination to database. Both are valid. Garrett.
                    //registerUser(username, password);
                    MessageBox.Show("Your account has been successfully registered.");

                }
                else
                {
                    lblPassError.Visible = true;
                    //password doesn't match, display error message
                }
            }
            else
            {
                lblUserError.Visible = true;
                //username doesn't match database, display error message
            }
        }

        private void lblPassError_Click(object sender, EventArgs e)
        {

        }
    }
}
