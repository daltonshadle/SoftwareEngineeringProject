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
    public partial class Registration3 : Form
    {
        bool tutorAcc, tuteeAcc;

        public Registration3()
        {
            InitializeComponent();
        }
          
        public Registration3(bool isTutor, bool isTutee)
        {
            InitializeComponent();
            tutorAcc = isTutor;
            tuteeAcc = isTutee;
        }

    }
}
