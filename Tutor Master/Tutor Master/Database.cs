using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace Tutor_Master
{
    class Database
    {
        private SqlCeConnection con;


        private string connection = @"Data Source=C:\TutorMaster (2).sdf";

        //private string connection = @"Data Source=C:\Software\Tutor Master\Tutor Master\TutorMaster.sdf";

        //private string connection = @"Data Source=F:\New Software Engineering\Tutor Master\Tutor Master\TutorMaster.sdf";
        //private string connection = @"Data Source=C:\Users\grbohach\Documents\SoftwareEngineering\Tutor Master\Tutor Master\TutorMaster.sdf";

        public Database()
        {
            con = new SqlCeConnection(connection);
        }

        private bool OpenConnection()
        {
            try
            {
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //if first name and last name don't have data, pass empty strings
        public void isValidRegisterInfo(string user, string password, string firstName, string lastName, ref bool isValid)
        {

            string query = "INSERT INTO profile (username, password, firstName, lastName) VALUES (@username, @password, @firstName, @lastName)";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", user);
                cmd.Parameters.Add("@password", password);
                if (firstName == "")
                    cmd.Parameters.Add("@firstName", DBNull.Value);
                else
                    cmd.Parameters.Add("@firstName", firstName);
                if (lastName == "")
                    cmd.Parameters.Add("@lastName", DBNull.Value);
                else
                    cmd.Parameters.Add("@lastName", lastName);
                cmd.Connection = con;
                try
                {
                    cmd.ExecuteNonQuery();
                    isValid = true;
                }
                catch
                {
                    isValid = false;
                }

                this.CloseConnection();
            }
        }

        public void isValidSignIn(string user, string password, ref bool isValid)
        {
            string query = "SELECT password FROM profile WHERE username = @username";
            List<string> list = new List<string>();

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", user);
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(dataReader["password"] + "");
                    }

                    //close Data Reader
                    dataReader.Close();
                    if (password == list[0])
                        isValid = true;
                    else
                        isValid = false;

                }
                catch
                {
                    isValid = false;
                }

                this.CloseConnection();
            }
        }

        /*
        public void isUsernameInDataBase(string user, bool isValid)
        {
            string query = "SELECT TOP username FROM profile WHERE username = @username";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", user);
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(dataReader["password"] + "");
                    }

                    //close Data Reader
                    dataReader.Close();

                }
                catch
                {
                    isValid = false;
                }

                this.CloseConnection();
            }
            
        }
        */

        public void addAppointment(string meetingPlace, string course, DateTime startTime, DateTime endTime, Tutor tutor, Tutee tutee)
        {
            {

                string query = "INSERT INTO appointments (tutorUsername, tuteeUsername, meetingPlace, course, starTime, endTime) VALUES (@tutor, @tutuee, @meetingPlace, @course, @startTime, @endTime)";


                if (this.OpenConnection())
                {
                    //@tutor, @tutuee, @meetingPlace, @course, @startTime, @endTime
                    //Finish writing query
                    SqlCeCommand cmd = new SqlCeCommand();
                    cmd.CommandText = query;
                    cmd.Parameters.Add("@tutor", tutor);
                    cmd.Parameters.Add("@tutee", tutee);
                    cmd.Parameters.Add("@meetingPlace", meetingPlace);
                    cmd.Parameters.Add("@course", course);
                    cmd.Parameters.Add("@startTime", startTime);
                    cmd.Parameters.Add("@endTime", endTime);
                    cmd.Connection = con;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    this.CloseConnection();
                }
            }
        }

        //if you want the list of course someone tutors, pass in true
        //if you want the list of courses someone is a tutee for, pass false
        public List<string> getCourseList(string username, bool isTutor)
        {
            string query;
            if (isTutor)
                query = "SELECT course1, course2, course3, course4 FROM tutorCourses WHERE username = @username";
            else
                query = "SELECT course1, course2, course3, course4 FROM tuteeCourses WHERE username = @username";

            List<string> list = new List<string>();

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", username);
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(dataReader["course1"] + "");
                        list.Add(dataReader["course2"] + "");
                        list.Add(dataReader["course3"] + "");
                        list.Add(dataReader["course4"] + "");
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return list;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    list.Clear();
                    this.CloseConnection();
                    return list;
                }
            }
            else
                return list;
        }

        //if the courses what someone can tutor, pass in true
        //if the courses what someone wants to be tutored, pass in false
        //only use this function during registration
        public void addNewCourseList(string username, List<string> courseList, bool isTutor)
        {
            string query;
            if (isTutor)
                query = "INSERT into tutorCourses (username, course1, course2, course3, course4) VALUES (@username, @course1, @course2, @course3, @course4)";
            else
                query = "INSERT into tuteeCourses (username, course1, course2, course3, course4) VALUES (@username, @course1, @course2, @course3, @course4)";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", username);
                int number = courseList.Count;
                int i = 0;
                for (; i < number; ++i)
                {
                    cmd.Parameters.Add("@course" + (i + 1).ToString(), courseList[i]);
                }
                for (; i < 4; ++i)
                {
                    cmd.Parameters.Add("@course" + (1 + i).ToString(), DBNull.Value);
                }

                cmd.Connection = con;
                try
                {
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.CloseConnection();
                }
            }
        }

        //gets all of the courses to fill the check boxes during registration process
        public List<string> getAllCourses()
        {
            string query;
            query = "SELECT name FROM courses";

            List<string> list = new List<string>();

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        string tempstring = dataReader.GetString(0);
                        list.Add(tempstring);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return list;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    list.Clear();
                    this.CloseConnection();
                    return list;
                }
            }
            else
                return list;
        }

        //set the isTutor value to the value passed in
        //have to change to update statement
        public void setTutorStatus(string username, bool isTutor)
        {
            string query = "UPDATE profile SET isTutor = @isTutor WHERE username = @username";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", username);
                cmd.Parameters.Add("@isTutor", isTutor);
                cmd.Connection = con;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
            }
        }

        //set the isTutee value to the value passed in
        //have to change to update statement
        public void setTuteeStatus(string username, bool isTutee)
        {
            string query = "UPDATE profile SET isTutee = @isTutee WHERE username = @username";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", username);
                cmd.Parameters.Add("@isTutee", isTutee);
                cmd.Connection = con;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
            }
        }

        //This function is for the user to delete their accound
        public void userDeleteAccount(string username, string password)
        {
            bool isValidDelete = false;
            Database db = new Database();

            string queryProfile = "DELETE FROM profile WHERE username = @username";
            string queryTuteeCourse = "DELETE FROM tuteeCourses WHERE username = @username";
            string queryTutorCourse = "DELETE FROM tutorCourses WHERE username = @username";

            if (this.OpenConnection()) 
            {
                db.isValidSignIn(username, password, ref isValidDelete);
                if (isValidDelete)
                {
                    SqlCeCommand cmdDeleteProfile = new SqlCeCommand();
                    SqlCeCommand cmdDeleteTuteeCourse = new SqlCeCommand();
                    SqlCeCommand cmdDeleteTutorCourse = new SqlCeCommand();

                    cmdDeleteProfile.CommandText = queryProfile;
                    cmdDeleteTuteeCourse.CommandText = queryTuteeCourse;
                    cmdDeleteTutorCourse.CommandText = queryTutorCourse;

                    cmdDeleteProfile.Parameters.Add("@username", username);
                    cmdDeleteTuteeCourse.Parameters.Add("@username", username);
                    cmdDeleteTutorCourse.Parameters.Add("@username", username);

                    cmdDeleteTutorCourse.Connection = con;
                    cmdDeleteTuteeCourse.Connection = con;
                    cmdDeleteProfile.Connection = con;
                    try
                    {
                        cmdDeleteProfile.ExecuteNonQuery();
                        cmdDeleteTuteeCourse.ExecuteNonQuery();
                        cmdDeleteTutorCourse.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    this.CloseConnection();
                }

            }
        }

        //This function is called if the X button is hit during the register process to
        //delete any information we may have put into the database
        public void deleteAccount(string username)
        {
            Database db = new Database();

            string queryProfile = "DELETE FROM profile WHERE username = @username";
            string queryTuteeCourse = "DELETE FROM tuteeCourses WHERE username = @username";
            string queryTutorCourse = "DELETE FROM tutorCourses WHERE username = @username";

            if (this.OpenConnection())
            {
                SqlCeCommand cmdDeleteProfile = new SqlCeCommand();
                SqlCeCommand cmdDeleteTuteeCourse = new SqlCeCommand();
                SqlCeCommand cmdDeleteTutorCourse = new SqlCeCommand();

                cmdDeleteProfile.CommandText = queryProfile;
                cmdDeleteTuteeCourse.CommandText = queryTuteeCourse;
                cmdDeleteTutorCourse.CommandText = queryTutorCourse;

                cmdDeleteProfile.Parameters.Add("@username", username);
                cmdDeleteTuteeCourse.Parameters.Add("@username", username);
                cmdDeleteTutorCourse.Parameters.Add("@username", username);

                cmdDeleteTutorCourse.Connection = con;
                cmdDeleteTuteeCourse.Connection = con;
                cmdDeleteProfile.Connection = con;
                try
                {
                    cmdDeleteProfile.ExecuteNonQuery();
                    cmdDeleteTuteeCourse.ExecuteNonQuery();
                    cmdDeleteTutorCourse.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
            }
        }

        //Returns the first and last name, if the user is a tutor and/or tutee
        //along with all of their courses
        public List<string> getProfileInfo(string username)
        {
            string query;
            query = "SELECT profile.firstName, profile.lastName, profile.isTutor, profile.isTutee, tuteeCourses.course1 AS tuteeCourse1, tuteeCourses.course2 AS tuteeCourse2, tuteeCourses.course3 AS tuteeCourse3, tuteeCourses.course4 AS tuteeCourse4, tutorCourses.course1 AS tutorCourse1, tutorCourses.course2 AS tutorCourse2, tutorCourses.course3 AS tutorCourse3, tutorCourses.course4 AS tutorCourse4 FROM profile LEFT OUTER JOIN tuteeCourses ON profile.username = tuteeCourses.username LEFT OUTER JOIN tutorCourses ON profile.username = tutorCourses.username WHERE profile.username = @username";


            List<string> list = new List<string>();

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", username);
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(dataReader["firstName"] + "");
                        list.Add(dataReader["lastName"] + "");
                        list.Add(dataReader["isTutor"] + "");
                        list.Add(dataReader["isTutee"] + "");
                        list.Add(dataReader["tuteeCourse1"] + "");
                        list.Add(dataReader["tuteeCourse2"] + "");
                        list.Add(dataReader["tuteeCourse3"] + "");
                        list.Add(dataReader["tuteeCourse4"] + "");
                        list.Add(dataReader["tutorCourse1"] + "");
                        list.Add(dataReader["tutorCourse2"] + "");
                        list.Add(dataReader["tutorCourse3"] + "");
                        list.Add(dataReader["tutorCourse4"] + "");
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return list;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    list.Clear();
                    this.CloseConnection();
                    return list;
                }
            }
            else
                return list;
        }

        //create a message to send between users
        public void sendMessage(string fromUser, string toUser, string subject, string message, bool? approved, DateTime sentTime)
        {
            string querySent, queryReceived;
            querySent = "INSERT INTO sentMessages (fromUserName, toUserName, subject, message, approved, timeSent) VALUES (@fromUser, @toUser, @subject, @message, @approved, @sentTime)";
            queryReceived = "INSERT INTO receivedMessages (fromUserName, toUserName, subject, message, approved, timeSent) VALUES (@fromUser, @toUser, @subject, @message, @approved, @sentTime)";

            if (this.OpenConnection())
            {
                SqlCeCommand cmdSent = new SqlCeCommand();
                SqlCeCommand cmdReceived = new SqlCeCommand();

                cmdSent.CommandText = querySent;
                cmdReceived.CommandText = queryReceived;

                cmdSent.Parameters.Add("@fromUser", fromUser);
                cmdReceived.Parameters.Add("@fromUser", fromUser);

                cmdSent.Parameters.Add("@toUser", toUser);
                cmdReceived.Parameters.Add("@toUser", toUser);

                cmdSent.Parameters.Add("@subject", subject);
                cmdReceived.Parameters.Add("@subject", subject);

                cmdSent.Parameters.Add("@message", message);
                cmdReceived.Parameters.Add("@message", message);

                if (approved == null)
                {
                    cmdSent.Parameters.Add("@approved", DBNull.Value);
                    cmdReceived.Parameters.Add("@approved", DBNull.Value);
                }
                else
                {
                    cmdSent.Parameters.Add("@pending", approved);
                    cmdReceived.Parameters.Add("@pending", approved);
                }
              
                cmdSent.Parameters.Add("@sentTime", sentTime);
                cmdReceived.Parameters.Add("@sentTime", sentTime);

                cmdSent.Connection = con;
                cmdReceived.Connection = con;
                try
                {
                    cmdSent.ExecuteNonQuery();
                    cmdReceived.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
            }
        }

        //get inbox, received messages that were sent to user
        public List<Messages> getInbox(string username)
        {
            List<Messages> messageList = new List<Messages>();

            string query;
            query = "SELECT * FROM receivedMessages WHERE receivedMessages.toUserName = @username";


            List<string> list = new List<string>();

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", username);
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    { //have to make catches for all of the nulls that might be in the database
                        Messages newMessage = new Messages();
                        newMessage.setIdNum((int) dataReader["id number"]);
                        newMessage.setFromUser((dataReader["fromUserName"] + "").ToString());
                        newMessage.setToUser((dataReader["toUserName"] + "").ToString());
                        newMessage.setSubject((dataReader["subject"] + "").ToString());
                        newMessage.setMessage((dataReader["message"] + "").ToString());
                        if (dataReader["approved"] == DBNull.Value)
                        {
                            newMessage.setPending(null);
                        }
                        else
                            newMessage.setPending((bool?)dataReader["pending"]);
                        newMessage.setDateTime((DateTime)dataReader["timeSent"]);
                        messageList.Add(newMessage);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return messageList;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    list.Clear();
                    this.CloseConnection();
                    return messageList;
                }
            }
            return messageList;
        }
        
        //get sent, find all the messages send by user
        public List<Messages> getSentMail(string username)
        {
            List<Messages> messageList = new List<Messages>();

            string query;
            query = "SELECT * FROM sentMessages WHERE sentMessages.fromUserName = @username";


            List<string> list = new List<string>();

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", username);
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    { //have to make catches for all of the nulls that might be in the database
                        Messages newMessage = new Messages();
                        newMessage.setIdNum((int)dataReader["id number"]);
                        newMessage.setFromUser((dataReader["fromUserName"] + "").ToString());
                        newMessage.setToUser((dataReader["toUserName"] + "").ToString());
                        newMessage.setSubject((dataReader["subject"] + "").ToString());
                        newMessage.setMessage((dataReader["message"] + "").ToString());
                        if (dataReader["approved"] == DBNull.Value)
                        {
                            newMessage.setPending(null);
                        }
                        else
                            newMessage.setPending((bool?)dataReader["pending"]);
                        newMessage.setDateTime((DateTime)dataReader["timeSent"]);
                        messageList.Add(newMessage);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return messageList;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    list.Clear();
                    this.CloseConnection();
                    return messageList;
                }
            }
            return messageList;
        } //---> Messages will have to be a new class

        //delete a message from your inbox
        public void deleteMessageFromInbox(int messageId)
        {
            string queryMessage = "DELETE FROM receivedMessages WHERE [id number] = @messageID";

            if (this.OpenConnection())
            {
                SqlCeCommand cmdDeleteMessage = new SqlCeCommand();
                
                cmdDeleteMessage.CommandText = queryMessage;
                cmdDeleteMessage.Parameters.Add("@messageID", messageId);

                cmdDeleteMessage.Connection = con;
                try
                {
                    cmdDeleteMessage.ExecuteNonQuery();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();

            }
        } //---> Have to see if this is a way of finding a unique message

        //delete a message you sent
        public void deleteMessageFromSentMail(int messageId)
        {
            string queryMessage = "DELETE FROM sentMessages WHERE [id number] = @messageID";

            if (this.OpenConnection())
            {
                SqlCeCommand cmdDeleteMessage = new SqlCeCommand();

                cmdDeleteMessage.CommandText = queryMessage;
                cmdDeleteMessage.Parameters.Add("@messageID", messageId);

                cmdDeleteMessage.Connection = con;
                try
                {
                    cmdDeleteMessage.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();

            }
        }

        public string getFacultyApprover(string courseName) 
        {
            List<Messages> messageList = new List<Messages>();

            string query;
            query = "SELECT facultyApprover FROM courses WHERE name = @courseName";

            string facultyName = "";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@courseName", courseName);
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        facultyName = dataReader.GetString(0);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return facultyName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.CloseConnection();
                    return facultyName;
                }
            }
            return facultyName;
        }

    }
}
