using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Tutor_Master
{
    class Schedule
    {
        //all the private data
        private SortedList<DateTime, Appointment> profileSchedule;


        //all the public fucntions

        //constructor
        public Schedule(){
            profileSchedule = new SortedList<DateTime, Appointment>();
        }

        public void addAppt(Appointment a) { 
            //function for adding an appt to the schedule
            //validation of the appointment is done when the appointment is created

            //check for overlapping appointment datetime
            //profileSchedule.Add(a.getDateTime(), a);
        }

        //public void removeAppt(Appointment a) { 
        //    //function for removing an appt from the schedule
        //    Appointment temp;
        //    if (profileSchedule.TryGetValue(a.getDateTime(), out temp)) {
        //        profileSchedule.Remove(a.getDateTime());
        //    }
        //}

        //public Appointment getAppt(Appointment a) {
        //    Appointment temp;
        //    if (profileSchedule.TryGetValue(a.getDateTime(), out temp)) {
        //        temp = a;
        //    }

        //    return temp;
        //}

        public void editAppt(Appointment a) { 
            //function for editting information in the schedule
            
        }

    }
}
