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
    public partial class UserProfile : Form
    {

        private bool tutorAcc, tuteeAcc;

        public UserProfile(string Title)
        {
            InitializeComponent();
            this.Text = Title;
            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }

    }
}
