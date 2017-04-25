using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tutor_Master
{
    public partial class MonthCalendar : UserControl
    {
        //constructor
        public MonthCalendar()
        {
            InitializeComponent();
            this.lblTempDate.Text = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
        }

    }
}
