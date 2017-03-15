using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tutor_Master
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Database db = new Database();
            Application.Run(new StartForm());
            //db.sendMessage("grbohach", "coolTerry7", "tutor request", "I want to tutor cs1", null, DateTime.Now);
            //db.getInbox("grbohach");
            //Application.Run(new StartForm());
            //db.sendMessage("grbohach", "coolTerry7", "tutor request", "I want to tutor cs1", null, DateTime.Now);
        }
    }
}
