using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    public class Appointment
    {
       
        //NEW APPOINTMENT CLASS
        private const string FREETYPE = "Free Time", LEARNTYPE = "Learning (Tuteeing)", TEACHTYPE = "Teaching (Tutoring)";

        //all the private data
        private string meetingPlace;
        private string course;
        private DateTime startTime, endTime;
        private Profile tutorProf;
        private Profile tuteeProf;
        private Profile freeTimeProf;
        private bool isFreeTimeSession;
        private int apptID;

        //all the public functions

        //constructors
        public Appointment()
        {
            meetingPlace = "";
            course = "";
            startTime = new DateTime();
            endTime = new DateTime();
            tutorProf = new Profile();
            tuteeProf = new Profile();
            freeTimeProf = new Profile();
            isFreeTimeSession = false;
            apptID = -1;
        }
        public Appointment(string tempMeetingType, string tempPlace, string tempCourse, DateTime tempStartTime, DateTime tempEndTime, Tutor tempTutor,  Tutee tempTutee)
        {
            //validation of these parameters can be done before the creation of the appointment object
            //appointment constructor for tutoring or tuteeing sessions
            meetingPlace = tempPlace;
            course = tempCourse;
            startTime = tempStartTime;
            endTime = tempEndTime;
            tutorProf = tempTutor;
            tuteeProf = tempTutee;
            isFreeTimeSession = meetingTypeStringToBool(tempMeetingType);
            apptID = -1;
        }
        public Appointment(DateTime tempStartTime, DateTime tempEndTime, Profile owner)
        {
            //Freetime appointment constructor

            startTime = tempStartTime;
            endTime = tempEndTime;
            isFreeTimeSession = true;
            freeTimeProf = owner;
            apptID = -1;
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

        public Profile getTutor()
        {
            return tutorProf;
        }
        public void setTutor(Tutor t)
        {
            //needs validation for the tutor object t
            tutorProf = t;
        }

        public Profile getTutee()
        {
            return tuteeProf;
        }
        public void setTutee(Tutee t)
        {
            //needs validaiton for the tutee object t
            tuteeProf = t;
        }

        public Profile getFreeTimeProf()
        {
            return freeTimeProf;
        }
        public void setFreeTimeProf(Profile freeTime)
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
                case 1:
                    isFreeTimeSession = true;
                    break;
                case 2:
                case 3:
                    isFreeTimeSession = false;
                    break;
                default:
                    //shit didn't work
                    break;
            }
        }


        public void addAppointmentToDatabase()
        {
            //db.addAppointment(null, getMeetingPlace(), getCourse(), getStartTime(), getEndTime(), getTutor(), getTutee());
            Database db = new Database();

            if (isFreeTimeSession)
            {
                //add freetime appt

            }
            else
            { 
                //add tutor/tutee appt
            }
        }
    }
}
