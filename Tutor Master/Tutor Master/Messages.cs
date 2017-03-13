using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutor_Master
{
    class Messages
    {
        private string toUser, fromUser, subject, message;
        private bool? pending;
        private DateTime timeSent;

        public Messages() 
        {
            toUser = "";
            fromUser = "";
            subject = "";
            message = "";
            pending = null;
            timeSent = DateTime.Now;
        }

        public Messages(string toUserName, string fromUserName, string subj, string mess, bool pend, DateTime sent)
        {
            toUser = toUserName;
            fromUser = fromUserName;
            subject = subj;
            message = mess;
            pending = pend;
            timeSent = sent;
        }

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
    }
}
