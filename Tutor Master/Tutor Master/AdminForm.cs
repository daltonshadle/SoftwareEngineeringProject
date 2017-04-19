﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tutor_Master
{
    public partial class AdminForm : Form
    {
        string admin;
        string user;
        List<string> listOfAllProfiles;

        public AdminForm(string username)
        {
            InitializeComponent();
            admin = username;
            listOfAllProfiles = new List<string>();
            initName();
            initListView();
        }

        //Function to display name at top of screen
        private void initName()
        {
            Database db = new Database();
            List<string> listOfProfileInfo = db.getProfileInfo(admin);
            string first = listOfProfileInfo[0];
            string last = listOfProfileInfo[1];

            if (first != "")
            {
                this.Text = FirstCharToUpper(first) + " " + FirstCharToUpper(last);
                lblNameAndUser.Text = FirstCharToUpper(first) + " " + FirstCharToUpper(last) + " - " + user;
            }
            else
            {
                this.Text = user;
                lblNameAndUser.Text = user;
            }
        }

        //Helper function for setting the name to be correctly displayed
        public string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public void initListView()
        {
            Database db = new Database();

            listOfAllProfiles = db.getAllProfiles();

            lvAllProfiles.Items.Clear();
            for (int i = 0; i < listOfAllProfiles.Count; i++)
            {
                lvAllProfiles.Items.Add(listOfAllProfiles[i]);
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var form = new StartForm();
            form.Show();
            this.Hide();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //Sign in as ordinary user
            var profile = new UserProfile(user, true, admin);
            profile.Show();
            this.Hide();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {

        }

        //Allows the administrator to delete profiles
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            //Needs to be more updated. Needs to delete appointments (and messages)
            db.deleteAccount(user);
        }

        private void lvAllProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAllProfiles.SelectedItems.Count == 1)
            {
                panelButtons.Visible = true;
               
                ListView.SelectedIndexCollection indexes = this.lvAllProfiles.SelectedIndices;
                if (indexes.Count > 1)
                    MessageBox.Show("Can only view one profile at a time.");
                else
                {

                    foreach (int index in indexes)
                    {
                        user = listOfAllProfiles[index];
                        btnSignIn.Text = "Sign in as " + user;
                    }
                }
            }
        }

    }
}
