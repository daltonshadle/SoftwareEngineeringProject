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
        public MonthCalendar()
        {
            InitializeComponent();

        }

        private void profileMonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            lblTempDate.Text = profileMonthCalendar.SelectionRange.Start.ToShortDateString();
            

        }

        
    }
}
