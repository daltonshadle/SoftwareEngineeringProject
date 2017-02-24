﻿using System;
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
                var profile = new UserProfile(username);
                profile.Show();
                this.Hide();
                //move to profile form, successfully signed in
            }
            else 
            {
                MessageBox.Show("Sign In error: Password did not match username.");
                
                //username doesn't match database, display error message
            }
        }
    }
}
