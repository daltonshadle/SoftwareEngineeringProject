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


            Application.Run(new StartForm());

            bool val = true;
            List<string> list= new List<string>();
            list.Add("cs 1");
            list.Add("calc 1");
<<<<<<< HEAD
            list.Add("gen phys 1");*/
=======
            list.Add("gen phys 1");
>>>>>>> df7678b6d78b6f991da665212445aac917b9d46e
            Database db = new Database();
            //db.addNewCourseList("coolTerry7", list, val);
            //db.isValidSignIn("coolTerry7", "rockstar#1", ref val);
            //db.getCourseList("coolTerry7", true);
            //db.setTutorStatus("coolTerry7", true);
            //db.addNewCourseList("bbailey", list, false);
            //db.deleteAccount("coolTerry7", "rockstar#1");
<<<<<<< HEAD
            db.getProfileInfo("coolTerry7");
=======

            db.getAllCourses();

>>>>>>> df7678b6d78b6f991da665212445aac917b9d46e
            //Application.Run(new StartForm());
        }
    }
}
