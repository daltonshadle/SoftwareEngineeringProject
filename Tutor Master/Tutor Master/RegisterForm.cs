using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//This form is working as expected. 2/23/17 

namespace Tutor_Master
{
    public partial class RegisterForm : Form
    {
        private string username, password, passConfirm, firstName, lastName;
        bool accountValid = false;

        public RegisterForm()
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            initFeaturesList();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            username = tbxUsername.Text;
            password = tbxPassword.Text;
            passConfirm = tbxPassConfirm.Text;
            firstName = tbxFirstName.Text;
            lastName = tbxLastName.Text;
           

            //Check to see if the username is available or not. Function returns bool by ref. Garrett
            
            bool passValid = ((password.Length > 5) && (!password.Contains(" ")));
            bool passesMatch = (passValid && (password == passConfirm));

            if (username != "" && password != "" && passConfirm != "")
            {
                if (passesMatch)
                {
                    Database db = new Database();
                    db.isValidSignIn(username, password, ref accountValid);
                    db.isValidRegisterInfo(username, password, firstName, lastName, ref accountValid);

                    if (accountValid)
                    {
                        //MessageBox.Show("Your account has been successfully registered.");

                        Form nextForm = new Registration(username);
                        this.Hide();
                        nextForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username not available.");
                        //username doesn't match database, display error message
                    }
                }
                else
                {
                    MessageBox.Show("Invalid password. Passwords must match and be at least 6 characters, no spaces");
                    //password doesn't match, display error message
                }
            }
            else
            {
                MessageBox.Show("Required fields must not be empty.");
                //All 3 of the required items were not submitted.
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            var signInform = new SignIn();
            signInform.Show();
            this.Hide();
        }

        private void initFeaturesList()
        {
            string l = "-Easy to use, clean and clear interface \n\n-Create tutor session schedules with course, time, place \n\n-Create weekly tutor sessions \n\n-Automated checks - Check for availability and conflicts \n\n-Access with any Windows devices";
            lblFreatures.Text = l;
        }
    }
}
