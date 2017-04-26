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
    public partial class EditProfileStart : Form
    {
        //private data
        private string username;

        //public functions
        //constructor be username and bools
        public EditProfileStart(string name, bool isTutee, bool isTutor)
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            username = name;
        }

        //function that check to see if atleast one checkbox is checked
        private bool isOneChecked()
        {
            return checkBoxPassword.Checked || checkBoxName.Checked || checkBoxTutor.Checked || checkBoxTutee.Checked;
        }

        //*********************************All listener functions*********************************//
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if(isOneChecked())
            {
                var newEditForm = new EditProfileInfo(username, checkBoxPassword.Checked, checkBoxName.Checked, checkBoxTutor.Checked, checkBoxTutee.Checked);
                newEditForm.Show();
                this.Close();
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }

        private void buttonPasswordCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonPasswordConfirm_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            string pass = txtPassword.Text;

            if (db.getUserPassword(username).Equals(pass))
            {
                panelPasswordCheck.Visible = false;
            }
            else 
            {
                MessageBox.Show("Invalid password");
            }
        }

        private void buttonEditOnSecondPanel_Click(object sender, EventArgs e)
        {
            panelEditOrDelete.Visible = false;
        }

        private void buttonDeleteStuff_Click(object sender, EventArgs e)
        {
            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to delete your profile?", "Deleting Profile", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    Database db = new Database();
                    db.deleteAccount(username);
                    List<Form> openForms = new List<Form>();

                    foreach (Form f in Application.OpenForms)
                        openForms.Add(f);

                    foreach (Form f in openForms)
                    {
                        if (f.Name != "Menu")
                            f.Hide();
                    }

                    var mainForm = new StartForm();
                    mainForm.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
