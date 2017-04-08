using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//This form is working as expected. Connected to database and all database functions working. 2/23/17

namespace Tutor_Master
{
    public partial class SignIn : Form
    {
        private string username, password;

        public SignIn()
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            initFeaturesList();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            username = tbxUsername.Text;
            password = tbxPassword.Text;
            bool accountValid = false;

            //Run sign in function under Profile class polymorphically
            //check username and password through database
            //check if username is there and if password matches
            Profile person = new Profile();
            person.signIn(username, password, ref accountValid);

            if (accountValid)
            {
                Database db = new Database();
                if (db.isFacultyAccount(username))
                {
                    var profile = new FacultyForm(username);
                    profile.Show();
                    this.Hide();
                }
                else
                {
                    var profile = new UserProfile(username);
                    profile.Show();
                    this.Hide();
                }
                //move to profile form, successfully signed in
            }
            else 
            {
                MessageBox.Show("Sign In error: Password did not match username.");
                
                //username doesn't match database, display error message
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var regis = new RegisterForm();
            regis.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void initFeaturesList() { 
            string l = "-Easy to use, clean and clear interface \n\n-Create tutor session schedules with course, time, place \n\n-Create weekly tutor sessions \n\n-Automated checks - Check for availability and conflicts \n\n-Access with any Windows devices";
            lblFreatures.Text = l;
        }
    }
}
