﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    public class Tutee : Profile
    {
        //all the private data
        private string[] courses;
        private Schedule tuteeSchedule;
        //Will wait on this one until the schedule class is done


        //all the public functions

        //constructor
        public Tutee() : base() {
            courses = new string[4]; 
            //4 is just a placeholder
            //base is calling the base class constructor
            tuteeSchedule = new Schedule();
        }

        public Tutee(string username, string password) : base(username, password) { }

        public Tutee(string username, string[] courseArray)
            : base(username)
        {
            courses = courseArray;
            //4 is just a placeholder
            //base is calling the base class constructor
            tuteeSchedule = new Schedule();
        }

        public Tutee(string username, string password, string[] courseArray) : base(username, password) {
            courses = courseArray;
            //4 is just a placeholder
            //base is calling the base class constructor
            tuteeSchedule = new Schedule();
        }

        public void manageSchedule() { 
        
        }

        public void confirmTutorRequest() { 
        
        }

        public void declineTutorRequest() { 
        
        }

        public void sendApptRequest() { 
        
        }

        public void addApptToTuteeSchedule(Appointment a) {
            tuteeSchedule.addAppt(a);
        }
    }
}
