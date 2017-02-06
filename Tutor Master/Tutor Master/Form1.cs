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
            SignIn signin = new SignIn();
            signin.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm regis = new RegisterForm();
            regis.Show();
            this.Close();
        }
    }
}
