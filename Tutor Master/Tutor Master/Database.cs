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

        public void isValidRegisterInfo(string user, string password, ref bool isValid)
        {

            string query = "INSERT INTO profile (username, password) VALUES (@username, @password)";





            //string query = "INSERT INTO profile (username, password) VALUES ('fda', 'gssa#1582')";


            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", user);
                cmd.Parameters.Add("@password", password);
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
    }
}
