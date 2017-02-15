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
        private List<Schedule> profileSchedule;


        //all the public fucntions

        //constructor
        public Schedule(){
            profileSchedule = new List<Schedule>();
        }

        public void addAppt(Appointment a) { 
            //function for adding an appt to the schedule
        }

        public void removeAppt(Appointment a) { 
            //function for removing an appt from the schedule
        }

        public void editAppt(Appointment a) { 
            //function for editting information in the schedule
        }

    }
}
