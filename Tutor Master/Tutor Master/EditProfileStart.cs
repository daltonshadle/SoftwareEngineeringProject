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
        private string username;

        public EditProfileStart(string name, bool isTutee, bool isTutor)
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
            username = name;

            checkBoxTutee.Visible = isTutee;
            checkBoxTutor.Visible = isTutor;

        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            var newEditForm = new EditProfileInfo(username, checkBoxPassword.Checked, checkBoxName.Checked, checkBoxTutor.Checked, checkBoxTutee.Checked);
            newEditForm.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
