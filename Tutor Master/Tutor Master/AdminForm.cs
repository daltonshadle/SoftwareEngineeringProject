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
        List<string> activeList;

        //constructor
        public AdminForm(string username)
        {
            InitializeComponent();

            //initializing components
            admin = username;
            listOfAllProfiles = new List<string>();
            activeList = new List<string>();
            initName();
            initListView("");

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnLogout, "Logout");
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
                lblNameAndUser.Text = FirstCharToUpper(first) + " " + FirstCharToUpper(last) + " - " + admin;
            }
            else
            {
                this.Text = admin;
                lblNameAndUser.Text = admin;
            }
        }

        //Helper function for setting the name to be correctly displayed
        public string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        //Function to display all profiles from the database in listview
        public void initListView(string searchBy)
        {
            Database db = new Database();
            
            listOfAllProfiles = db.getAllProfiles();

            lvAllProfiles.Items.Clear();
            activeList.Clear();
            for (int i = 0; i < listOfAllProfiles.Count; i++)
            {
                string profileName = listOfAllProfiles[i];

                if (profileName.Contains(searchBy))
                {
                    activeList.Add(listOfAllProfiles[i]);
                    lvAllProfiles.Items.Add(listOfAllProfiles[i]);
                }
            }
            updatelvAllProfiles();

        }

        //Changes what is displayed on the screen and in the list view
        private void updatelvAllProfiles()
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
                        user = activeList[index];
                        btnSignIn.Text = "Sign in as " + user;
                    }
                }
            }
            else
            {
                panelButtons.Visible = false;
            }
        }

        //*************************All listener functions***************************//

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //takes user back to home page
            var form = new StartForm();
            form.Show();
            this.Hide();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //Sign in as ordinary user with admin priviledges
            var profile = new UserProfile(user, true, admin);
            profile.Show();
            this.Hide();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            //Assigns a default password to a user, sends message to user to remind them to change it afterward.
            MessageBox.Show(user + "'s password has been changed to \"tempPass\"");

            Database db = new Database();
            db.editPassword(user, "tempPass");
            db.sendMessage(admin, user, "Password changed", "Your password has been changed to a temporary password by an administrator. Remember to change it to something unique!", true, DateTime.Now, "", -1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Allows the administrator to delete profiles
            if (MessageBox.Show("Delete " + user + " completely?", "My application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Database db = new Database();

                //deleteAccount will remove the profile from the database in all forms except that users who received messages from the profile will still have those messages.
                db.deleteAccount(user);
                initListView("");
            }
        }

        private void lvAllProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatelvAllProfiles();
        }

        private void AdminForm_Activated(object sender, System.EventArgs e)
        {
            initListView("");        
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //updates listview with profile names as text is changed
            string searchBy = txtSearch.Text;
            initListView(searchBy);
        }
    }
}
