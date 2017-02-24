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
            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            username = tbxUsername.Text;
            password = tbxPassword.Text;
            bool userValid = false;

            //Check to see if the username is available or not. Function returns bool by ref. Garrett
            //checkValidity(username, ref userValid);

            //bool passValid = ((password.Length > 5) && (!password.Contains(" ")));

            bool passValid = true;
            userValid = true;
            if (passValid)  //valid username means the username is available.
            {
                if (userValid)  //valid password means it is at least
                {
                    //MessageBox.Show("Your account has been successfully registered.");

                    Form nextForm = new Registration(username);
                    this.Hide();
                    nextForm.Show();

                }
                else
                {
                    MessageBox.Show("Invalid password- must be at least 6 characters, no spaces");
                    //password doesn't match, display error message
                }
            }
            else
            {
                MessageBox.Show("Username not available.");
                //username doesn't match database, display error message
            }
        }
    }
}
