using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    public class Messages
    {
        //private data
        private int id, apptId;
        private string toUser, fromUser, subject, message, course;
        private bool? pending;
        private DateTime timeSent;


        //all functions
        //default constructor
        public Messages() 
        {
            id = -1;
            toUser = "";
            fromUser = "";
            subject = "";
            message = "";
            course = "";
            pending = null;
            timeSent = DateTime.Now;
            apptId = -1;
        }

        //constructor with all parameters
        public Messages(int idNum, string toUserName, string fromUserName, string subj, string mess, bool pend, DateTime sent, string courseName, int appointmentId)
        {
            id = idNum;
            toUser = toUserName;
            fromUser = fromUserName;
            subject = subj;
            message = mess;
            pending = pend;
            timeSent = sent;
            course = courseName;
            apptId = appointmentId;
        }

        //setters and getters
        public int getIdNum() { return id; }
        public void setIdNum(int idNum) { id = idNum; }

        public string getToUser() {return toUser; }
        public void setToUser(string toUserName) { toUser = toUserName; }

        public string getFromUser() { return fromUser; }
        public void setFromUser(string fromUserName) { fromUser = fromUserName; }

        public string getSubject() { return subject; }
        public void setSubject(string subj) { subject = subj; }

        public string getMessage() { return message; }
        public void setMessage(string mess) { message = mess; }

        public bool? getPending() { return pending; }
        public void setPending(bool? pend) { pending = pend; }

        public DateTime getTimeSent() { return timeSent; }
        public void setDateTime(DateTime sentTime) { timeSent = sentTime; }

        public string getCourseName() { return course; }
        public void setCourseName(string c) { course = c; }

        public int getApptId() { return apptId; }
        public void setApptId(int id) { apptId = id; }
    }
}
