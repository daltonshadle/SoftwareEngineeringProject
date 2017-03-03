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
>>>>>>> 9331f0fa2c7c50a2a4ded867482622d6eb435200
            //Application.Run(new StartForm());

            Database db = new Database();
            db.sendMessage("grbohach", "coolTerry7", "tutor request", "I want to tutor cs1", null, DateTime.Now);
<<<<<<< HEAD

=======
>>>>>>> 9331f0fa2c7c50a2a4ded867482622d6eb435200
            Application.Run(new StartForm());
        }
    }
}
