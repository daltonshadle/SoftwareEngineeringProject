using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    public class Appointment
    {
        private const string FREETYPE = "Free Time", LEARNTYPE = "Learning (Tuteeing)", TEACHTYPE = "Teaching (Tutoring)";

        //all the private data
        private string meetingPlace;
        private string course;
        private DateTime startTime, endTime;
        private Tutor tutor;
        private Tutee tutee;
        private string meetingType;


        //all the public functions

        //constructors
        public Appointment() {
            meetingPlace = "";
            course = "";
            startTime = new DateTime();
            endTime = new DateTime();
            tutor = new Tutor();
            tutee = new Tutee();
            meetingType = "";
        }
        public Appointment(string tempMeetingType, string tempPlace, string tempCourse, DateTime tempStartTime, DateTime tempEndTime, Tutor tempTutor, Tutee tempTutee)
        {
            //validation of these parameters can be done before the creation of the appointment object
            meetingPlace = tempPlace;
            course = tempCourse;
            startTime = tempStartTime;
            endTime = tempEndTime;
            tutor = tempTutor;
            tutee = tempTutee;
            meetingType = tempMeetingType;
        }
        public Appointment(string tempMeetingType, DateTime tempStartTime, DateTime tempEndTime, Tutor owner) {
            //Freetime appointment constructor for tutor
            
            startTime = tempStartTime;
            endTime = tempEndTime;
            meetingType = tempMeetingType;
            tutor = owner;
            //have to find something for profile and cast to a tutor or tutee
        }
        public Appointment(string tempMeetingType, DateTime tempStartTime, DateTime tempEndTime, Tutee owner)
        {
            //Freetime appointment constructor for tutee

            startTime = tempStartTime;
            endTime = tempEndTime;
            meetingType = tempMeetingType;
            tutee = owner;
            //have to find something for profile and cast to a tutor or tutee
        }

        //setters and getters for appointment
        public DateTime getStartTime() {
            return startTime;
        }
        public void setStartTime(DateTime dt) {
            //needs validaiton of the DateTime object
            startTime = dt;
        }

        public DateTime getEndTime() {
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

        public void setMeetingType(int type) {
            switch (type) { 
                case 1:
                    meetingType = FREETYPE;
                    break;
                case 2:
                    meetingType = LEARNTYPE;
                    break;
                case 3:
                    meetingType = TEACHTYPE;
                    break;
                default:
                    //shit didn't work
                    break;
            }
        }
        

        public void addAppointmentToDatabase() {
            Database db = new Database();

            if (meetingType.Equals(FREETYPE)) {
                if(tutor==null){
                    db.addAppointment(tutee.getUsername(), getMeetingPlace(), getCourse(), getStartTime(), getEndTime(), null, null);
                } else {
                    db.addAppointment(tutor.getUsername(), getMeetingPlace(), getCourse(), getStartTime(), getEndTime(), null, null);
                }
            }
            else {
                db.addAppointment(null, getMeetingPlace(), getCourse(), getStartTime(), getEndTime(), getTutor(), getTutee());
            }
        }

        
    }
}
