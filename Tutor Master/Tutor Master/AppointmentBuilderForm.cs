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
    public partial class AppointmentBuilderForm : Form
    {
        public AppointmentBuilderForm()
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }

        public AppointmentBuilderForm(Profile buildingProfile)
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;
        }


    }
}
