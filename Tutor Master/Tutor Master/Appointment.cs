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
        private DateTime startTime;
        private DateTime endTime
        private Tutor tutor;
        private Tutee tutee;


        //all the public functions

        //constructors
        public Appointment() {
            meetingPlace = "";
            course = "";
            startTime = new DateTime();
            endTime = new DateTime();
            tutor = new Tutor();
            tutee = new Tutee();
        }
        public Appointment(string tempPlace, string tempCourse, DateTime tempStartTime, DateTime tempEndTime, Tutor tempTutor, Tutee tempTutee)
        {
            //validation of these parameters can be done before the creation of the appointment object
            meetingPlace = tempPlace;
            course = tempCourse;
            startTime = tempStartTime;
            endTime = tempEndTime;
            tutor = tempTutor;
            tutee = tempTutee;
        }

        //I don't know if we need this, we have a constructor to do this
        public void createAppt(string tempPlace, string tempCourse, DateTime tempStartTime, DateTime tempEndTime, Tutor tempTutor, Tutee tempTutee) {
            meetingPlace = tempPlace;
            course = tempCourse;
            startTime = tempStartTime;
            endTime = tempEndTime;
            tutor = tempTutor;
            tutee = tempTutee;
        }


        //setters and getters for appointment
        public DateTime getStartTime() {
            return startTime;
        }
        public void setStartTime(DateTime dt) {
            //needs validaiton of the DateTime object
            startTime = dt;
        }

        public DateTime getendTime() {
            return endTime;
        }
        public void setEndTime(DateTime dt) {
            //needs validaiton of the DateTime object
            endTime = dt;
        }

        public String getMeetingPlace() {
            return meetingPlace;
        }
        public void setMeetingPlace(String p) {
            //needs validation of the meeting place p
            meetingPlace = p;
        }

        public String getCourse() {
            return course;
        }
        public void setCourse(String c) {
            //needs validation of the course c
            course = c;
        }

        public Tutor getTutor() {
            return tutor;
        }
        public void setTutor(Tutor t) { 
            //needs validation for the tutor object t
            tutor = t;
        }

        public Tutee getTutee() {
            return tutee;
        }
        public void setTutee(Tutee t) {
            //needs validaiton for the tutee object t
            tutee = t;
        }
    }
}
