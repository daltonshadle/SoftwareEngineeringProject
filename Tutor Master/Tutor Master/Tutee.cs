using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    class Tutee : Profile
    {
        //all the private data
        private string[] courses;
        //private schedule tuteeSchedule;
        //Will wait on this one until the schedule class is done


        //all the public functions

        //constructor
        public Tutee() : base() {
            courses = new string[4]; 
            //4 is just a placeholder
            //base is calling the base class constructor
        }

        public void manageSchedule() { 
        
        }

        public void confirmTutorRequest() { 
        
        }

        public void declineTutorRequest() { 
        
        }

        public void sendApptRequest() { 
        
        }
    }
}
