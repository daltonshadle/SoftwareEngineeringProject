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

        //constructor
        public Faculty(string areaofstudy, string name, string pass) : base(name, pass) {
            //may need validation for this as well
            areaOfStudy = areaofstudy;
        }
    }
}
