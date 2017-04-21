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
            db.getAppointmentCourseSet("CS2");
            //MessageBox.Show("Good?");
            /*DateTime dt = new DateTime(2017, 4, 1);

            HashSet<Appointment> courses = db.getAppointmentCourseSet("CS1");
            HashSet<Appointment> places = db.getAppointmentPlaceSet("library");
            HashSet<Appointment> tutors = db.getAppointmentTutorSet("coolTerry7");
            HashSet<Appointment> dates = db.getAppointmentDateSet(dt, DateTime.Now);

            HashSet<Appointment> intersect = intersection(tutors, courses);*/

            //db.editAppointment(1, null, "library", null, DateTime.Now, DateTime.Now, null, null, false, true);
            Application.Run(new StartForm());
        }


        static HashSet<Appointment> intersection(HashSet<Appointment> A, HashSet<Appointment> B)
        {
            HashSet<Appointment> C = new HashSet<Appointment>();
            foreach( Appointment appt in A )
            {
                foreach (Appointment appt2 in B)
                {
                    if (appt.getID() == appt2.getID())
                        C.Add(appt);
                }
            }

            return C;
        }
    }
}
