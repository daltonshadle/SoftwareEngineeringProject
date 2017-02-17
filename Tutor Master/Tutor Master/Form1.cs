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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            var signin = new SignIn();
            signin.Visible = true;
            this.Visible = false;
            //signin.Show();
            //this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var regis = new RegisterForm();
            regis.Show();
            this.Hide();
        }
    }
}
