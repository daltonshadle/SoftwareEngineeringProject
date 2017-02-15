using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    class Faculty : Profile
    {
        //all the private data
        private string areaOfStudy;

        
        //all the public functions

        //constructor
        public Faculty() : base() {
            areaOfStudy = "";
        }

        public void approveTutor(Tutor t) { 
        
        }

        public void approveTutorCourses(string course) { 
        
        }
    }
}
