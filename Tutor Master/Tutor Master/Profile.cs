using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    public class Profile
    {
        //all the private data
        private string username;
        private string password;


        //all the public functions

        //constructor
        public Profile() {
            username = "";
            password = "";
        }

        public Profile(string name)
        {
            username = name;
            password = "";
        }

        public Profile(string name, string pass){
            username = name;
            password = pass;
        }

        public Profile(Profile previousPerson)
        {
            username = previousPerson.username;
            password = previousPerson.password;
        }

        public void register() 
        { 
            //runs through profile registration process
        }

        public void signIn(string user, string password, ref bool isValid)
        { 
            //runs through profile sign in process
            Database db = new Database();
            db.isValidSignIn(user, password, ref isValid);
        }

        public string getUsername() {
            return username;
        }
    }
}
