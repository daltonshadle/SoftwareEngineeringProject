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


            //Application.Run(new StartForm());

            /*bool val = true;
            List<string> list= new List<string>();
            list.Add("cs 1");
            list.Add("calc 1");
            list.Add("gen phys 1");
            Database db = new Database();*/
            //db.addNewCourseList("coolTerry7", list, val);
            //db.isValidSignIn("coolTerry7", "rockstar#1", ref val);
            //db.getCourseList("coolTerry7", true);
            //db.setTutorStatus("coolTerry7", true);
            //db.addNewCourseList("bbailey", list, false);
            //db.deleteAccount("coolTerry7", "rockstar#1");
<<<<<<< HEAD
=======
            db.getAllCourses();
>>>>>>> 02506ba197a8654f9496b2e78534bb143b9499f7
            //Application.Run(new StartForm());
        }
    }
}
