﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    class Tutor : Profile
    {
        //all the private data
        private string[] approvedCourses;
        //private schedule tutorSchedule;
        //We will wait on this until the tutor class is made


        //all the public functions

        //constructor
        public Tutor() : base() {
            approvedCourses = new string[4];
            //4 is just a placeholder
        }

        public void manageSchedule() {
        
        }

        public void confirmTuteeRequest() { 
        
        }

        public void declineTuteeRequest() { 
        
        }

        public void sendApptRequest() { 
        
        }

    }
}