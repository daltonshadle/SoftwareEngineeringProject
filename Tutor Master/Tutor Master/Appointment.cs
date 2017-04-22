using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    public class Appointment
    {
       
        //NEW APPOINTMENT CLASS
        private const string FREETYPE = "Free Time Session", TUTORTYPE = "Tutoring Session";

        //all the private data
        private string meetingPlace;
        private string course;
        private DateTime startTime, endTime;
        private string tutorProf;
        private string tuteeProf;
        private string freeTimeProf;
        private bool isFreeTimeSession;
        private bool isApproved;
        private int apptID;
        private string meetingType;
        private string source;

        //all the public functions

        //constructors
        public Appointment()
        {
            meetingPlace = "";
            meetingType = "";
            course = "";
            startTime = new DateTime();
            endTime = new DateTime();
            tutorProf = "";//new Profile();
            tuteeProf = ""; //new Profile();
            freeTimeProf = ""; //new Profile();
            isFreeTimeSession = false;
            isApproved = false;
            apptID = -1;
        }
        public Appointment(string tempMeetingType, string tempPlace, string tempCourse, DateTime tempStartTime, DateTime tempEndTime, string tempTutor,  string tempTutee, bool isAppointApproved, string src)
        {
            meetingPlace = tempPlace;
            course = tempCourse;
            startTime = tempStartTime;
            endTime = tempEndTime;
            tutorProf = tempTutor;
            tuteeProf = tempTutee;
            isFreeTimeSession = meetingTypeStringToBool(tempMeetingType);
            isApproved = isAppointApproved;
            apptID = -1;
            meetingType = tempMeetingType;
            source = src;
            
        }

        //Will work on getting rid of this function
        public Appointment(string tempMeetingType, string tempPlace, string tempCourse, DateTime tempStartTime, DateTime tempEndTime, Profile tempTutor, Profile tempTutee, bool isAppointApproved, string src)

        {
            //validation of these parameters can be done before the creation of the appointment object
            //appointment constructor for tutoring or tuteeing sessions
            meetingPlace = tempPlace;
            course = tempCourse;
            startTime = tempStartTime;
            endTime = tempEndTime;
            tutorProf = tempTutor.getUsername();
            tuteeProf = tempTutee.getUsername();
            isFreeTimeSession = meetingTypeStringToBool(tempMeetingType);
            isApproved = isAppointApproved;
            apptID = -1; 
            meetingType = tempMeetingType;
            source = src;
        }

        public Appointment(DateTime tempStartTime, DateTime tempEndTime, string owner)
        {
            //Freetime appointment constructor
            startTime = tempStartTime;
            endTime = tempEndTime;
            isFreeTimeSession = true;
            freeTimeProf = owner;
            isApproved = true; //will always be approved for a freetime appt.
            apptID = -1;
            meetingType = "Freetime";
        }

        private bool meetingTypeStringToBool(string type) {
            return (type.Equals(FREETYPE));
        }

        //setters and getters for appointment
        public void setID(int id)
        {
            apptID = id;
        }
        public int getID()
        {
            return apptID;
        }

        public void setIsApproved(bool isAppointApproved) {
            isApproved = isAppointApproved;
        }
        public bool getIsApproved() {
            return isApproved;
        }

        public string getSource()
        {
            return source;
        }

        public void setSource(string src)
        {
            source = src;
        }

        public DateTime getStartTime()
        {
            return startTime;
        }
        public void setStartTime(DateTime dt)
        {
            //needs validaiton of the DateTime object
            startTime = dt;
        }

        public DateTime getEndTime()
        {
            return endTime;
        }
        public void setEndTime(DateTime dt)
        {
            //needs validaiton of the DateTime object
            endTime = dt;
        }

        public String getMeetingPlace()
        {
            return meetingPlace;
        }
        public void setMeetingPlace(String p)
        {
            //needs validation of the meeting place p
            meetingPlace = p;
        }

        public String getCourse()
        {
            return course;
        }
        public void setCourse(String c)
        {
            //needs validation of the course c
            course = c;
        }

        public string getTutor()
        {
            return tutorProf;
        }
        public void setTutor(string t)
        {
            //needs validation for the tutor object t
            tutorProf = t;
        }

        public string getTutee()
        {
            return tuteeProf;
        }
        public void setTutee(string t)
        {
            //needs validaiton for the tutee object t
            tuteeProf = t;
        }

        public string getFreeTimeProf()
        {
            return freeTimeProf;
        }
        public void setFreeTimeProf(string freeTime)
        {
            //needs validaiton for the tutee object t
            freeTimeProf = freeTime;
        }

        public void setIsFreeTimeSession(bool isFree)
        {
            isFreeTimeSession = isFree;
        }
        public bool getIsFreeTimeSession()
        {
            return isFreeTimeSession;
        }


        public void setMeetingType(int type)
        {
            switch (type)
            {
                case -1:
                    meetingType = "";
                    break;
                case 1:
                    meetingType = "Freetime";
                    isFreeTimeSession = true;
                    break;
                case 2:
                    meetingType = "Tutoring";
                    isFreeTimeSession = false;
                    break;
                case 3:
                    meetingType = "Tuteeing";
                    isFreeTimeSession = false;
                    break;
                default:
                    //shit didn't work
                    break;
            }
        }

        public int addAppointmentToDatabase()
        {
            //db.addAppointment(null, getMeetingPlace(), getCourse(), getStartTime(), getEndTime(), getTutor(), getTutee());
            Database db = new Database();
            int lastId = -1;

            if (isFreeTimeSession)
            {
                //add freetime appt
                lastId = db.addAppointment(freeTimeProf, null, null, startTime, endTime, null, null, isFreeTimeSession, isApproved, source); 
            }
            else
            { 
                //add tutor/tutee appt
                lastId = db.addAppointment(null, meetingPlace, course, startTime, endTime, tutorProf, tuteeProf, isFreeTimeSession, isApproved, source);
            }

            return lastId;
        }

        public string getMeetingType()
        {
            return meetingType;
        }
    }
}
