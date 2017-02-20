using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    class Appointment
    {
        //all the private data
        private string meetingPlace;
        private string course;
        private DateTime startTime, endTime;
        private Tutor tutor;
        private Tutee tutee;


        //all the public functions

        //constructor
        public Appointment() {
            meetingPlace = "";
            course = "";
            startTime = new DateTime();
            endTime = new DateTime();
            tutor = new Tutor();
            tutee = new Tutee();
        }

        public void createAppt() { 
        
        }

    }
}
