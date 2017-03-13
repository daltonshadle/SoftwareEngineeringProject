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
<<<<<<< HEAD
=======

>>>>>>> 480b3c9f6f74907dd6e438c5a59f203b62c64931

            Database db = new Database();
            Application.Run(new StartForm());
            //db.sendMessage("grbohach", "coolTerry7", "tutor request", "I want to tutor cs1", null, DateTime.Now);
<<<<<<< HEAD
=======
            //db.getInbox("grbohach");
            //Application.Run(new StartForm());
            //db.sendMessage("grbohach", "coolTerry7", "tutor request", "I want to tutor cs1", null, DateTime.Now);
>>>>>>> 480b3c9f6f74907dd6e438c5a59f203b62c64931

        }
    }
}
