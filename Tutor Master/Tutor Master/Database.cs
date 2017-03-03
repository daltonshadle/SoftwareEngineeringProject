using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace Tutor_Master
{
    class Database
    {
        private SqlCeConnection con;

        private string connection = @"Data Source=C:\TutorMaster.sdf";

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

        public List<string> getProfileInfo(string username)
        {
            string query;
            query = "SELECT profile.firstName, profile.lastName, tuteeCourses.course1 AS tuteeCourse1, tuteeCourses.course2 AS tuteeCourse2, tuteeCourses.course3 AS tuteeCourse3, tuteeCourses.course4 AS tuteeCourse4, tutorCourses.course1 AS tutorCourse1, tutorCourses.course2 AS tutorCourse2, tutorCourses.course3 AS tutorCourse3, tutorCourses.course4 AS tutorCourse4 FROM profile LEFT OUTER JOIN tuteeCourses ON profile.username = tuteeCourses.username LEFT OUTER JOIN tutorCourses ON profile.username = tutorCourses.username WHERE profile.username = @username";


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
    }
}
