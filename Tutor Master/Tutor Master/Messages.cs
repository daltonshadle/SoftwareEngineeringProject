using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    class Messages
    {
        private int id;
        private string toUser, fromUser, subject, message, course;
        private bool? pending;
        private DateTime timeSent;

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
        }

        public Messages(int idNum, string toUserName, string fromUserName, string subj, string mess, bool pend, DateTime sent, string courseName)
        {
            id = idNum;
            toUser = toUserName;
            fromUser = fromUserName;
            subject = subj;
            message = mess;
            pending = pend;
            timeSent = sent;
            course = courseName;
        }

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
    }
}
