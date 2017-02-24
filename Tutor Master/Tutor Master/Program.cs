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
            bool val = true;
            List<string> list= new List<string>();
            list.Add("cs 1");
            Database db = new Database();
            //db.addNewCourseList("coolTerry7", list, val);
            //db.isValidSignIn("coolTerry7", "rockstar#1", ref val);
            //db.getCourseList("coolTerry7", true);
            db.setTutorStatus("coolTerry7", true);
            //Application.Run(new StartForm());
        }
    }
}
