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
        private string username, password;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            username = tbxUsername.Text;
            password = tbxPassword.Text;
            bool accountValid = false;

            //Check to see if the username is available or not. Function returns bool by ref. Garrett
            
            bool passValid = ((password.Length > 5) && (!password.Contains(" ")));
            if (passValid)
            {
                Database db = new Database();
                db.isValidRegisterInfo(username, password, ref accountValid);

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
                MessageBox.Show("Invalid password- must be at least 6 characters, no spaces");
                //password doesn't match, display error message
            }
        }
    }
}
