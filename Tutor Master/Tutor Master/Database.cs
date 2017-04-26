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
        private string connection = @"Data Source=C:\Users\grbohach\Documents\SoftwareEngineering3\Tutor Master\Tutor Master\TutorMaster(1).sdf";

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
   
        //Simply checks if username is in database
        public bool isUsernameInDataBase(string user)
        {
            string query = "SELECT Count(username) AS Count FROM profile WHERE username = @username";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", user);
                int userCount = -1;
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        userCount = (int)dataReader["Count"]; 
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();

                    if (userCount == 1)
                        return true;
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.CloseConnection();
                    return false;
                }
            }
            else
                return false;
            
        }

        //adds an appointment to the appointments table
        public int addAppointment(string free, string meetingPlace, string course, DateTime startTime, DateTime endTime, string tutor, string tutee, bool isFreeTime, bool isApproved, string source, Boolean needReturnValue)
        {
            {
                string query = "INSERT INTO appointment([free time], tutor, tutee, courseName, meetingPlace, startTime, endTime, isFreeTimeSession, isApproved, source) VALUES(@freeTime, @tutor, @tutee, @courseName, @meetingPlace, @startTime, @endTime, @isFreeTime, @isApproved, @source)";
                string idQuery = "SELECT @@IDENTITY";

                int lastId = -1;

                if (this.OpenConnection())
                {
                    SqlCeCommand cmd = new SqlCeCommand();
                    cmd.CommandText = query;
                    if (free == null)
                    {
                        cmd.Parameters.Add("@freeTime", DBNull.Value);
                    }
                    else
                        cmd.Parameters.Add("@freeTime", free);

                    if (tutor == null)
                    {
                        cmd.Parameters.Add("@tutor", DBNull.Value);
                    }
                    else
                        cmd.Parameters.Add("@tutor", tutor);

                    if (tutee == null)
                    {
                        cmd.Parameters.Add("@tutee", DBNull.Value);
                    }
                    else
                        cmd.Parameters.Add("@tutee", tutee);

                    if (meetingPlace == null)
                    {
                        cmd.Parameters.Add("@meetingPlace", DBNull.Value); ;
                    }
                    else
                        cmd.Parameters.Add("@meetingPlace", meetingPlace); ;
                    if (course == null)
                    {
                        cmd.Parameters.Add("@courseName", DBNull.Value);
                    }
                    else
                        cmd.Parameters.Add("@courseName", course);

                    cmd.Parameters.Add("@startTime", startTime);
                    cmd.Parameters.Add("@endTime", endTime);
                    cmd.Parameters.Add("@isFreeTime", isFreeTime);
                    cmd.Parameters.Add("@isApproved", isApproved);
                    if (source == null)
                    {
                        cmd.Parameters.Add("@source", DBNull.Value);
                    }
                    else
                        cmd.Parameters.Add("@source", source);
                    cmd.Connection = con;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        if (needReturnValue)
                        {
                            cmd.CommandText = idQuery;
                            string tempStr = Convert.ToString(cmd.ExecuteScalar());

                            Int32.TryParse(tempStr, out lastId);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return lastId;
                    }

                    this.CloseConnection();
                    return lastId;
                }
                else
                    return lastId;
            }
        }

        /*private List<Appointment> getDailyAppointments(string username, DateTime date);
        Preconditions: Username exists and the date is found already. Function will only be called after a date is selected.
        Post-conditions: List of all of the appointments on the date (date) for that user (username) are returned.
        If no matches are found, returns NULL.
        Function: Fetches all of the appointments for a user on a given date.*/
        public List<Appointment> getDailyAppointments(string username)
        {
            List<Appointment> appointmentList = new List<Appointment>();

            string query;
            query = "SELECT * FROM appointment WHERE  ([free time] = @username OR tutor = @username OR tutee = @username)";

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
                        Appointment newAppointment = new Appointment();
                        newAppointment.setID((int)dataReader["id number"]);
                        if (dataReader["free time"] == DBNull.Value)
                        {
                            newAppointment.setFreeTimeProf(null);
                        }
                        else
                        {
                            newAppointment.setFreeTimeProf(dataReader["free time"].ToString());
                        }
                            
                        if(dataReader["tutor"] == DBNull.Value){
                            newAppointment.setTutor(null);
                        }
                        else {
                            newAppointment.setTutor(dataReader["tutor"].ToString());
                        }
                        if(dataReader["tutee"] == DBNull.Value) {
                            newAppointment.setTutee(null);
                        }
                        else {
                            newAppointment.setTutee(dataReader["tutee"].ToString());
                        }
                        if(dataReader["courseName"] == DBNull.Value){
                            newAppointment.setCourse(null);
                        }
                        else {
                            newAppointment.setCourse(dataReader["courseName"].ToString());
                        }
                        if(dataReader["meetingPlace"] == DBNull.Value){
                            newAppointment.setMeetingPlace(null);
                        }
                        else {
                            newAppointment.setMeetingPlace(dataReader["meetingPlace"].ToString());
                        }
                        if (dataReader["isFreeTimeSession"] == DBNull.Value){
                            newAppointment.setIsFreeTimeSession(false);
                        }
                        else{
                            newAppointment.setIsFreeTimeSession((bool)dataReader["isFreeTimeSession"]);
                        }
                        if (dataReader["isApproved"] == DBNull.Value){
                            newAppointment.setIsApproved(false);
                        }
                        else{
                            newAppointment.setIsApproved((bool)dataReader["isApproved"]);
                        }
                        if (dataReader["source"] == DBNull.Value)
                        {
                            newAppointment.setSource(null);
                        }
                        else
                        {
                            newAppointment.setSource((string)dataReader["source"]);
                        }
                        newAppointment.setStartTime((DateTime)dataReader["startTime"]);
                        newAppointment.setEndTime((DateTime)dataReader["endTime"]);
                        newAppointment.setIsFreeTimeSession((bool)dataReader["isFreeTimeSession"]);
                        newAppointment.setID((int)dataReader["id number"]); //Scott added this.
                        appointmentList.Add(newAppointment);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return appointmentList;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    appointmentList.Clear();
                    this.CloseConnection();
                    return appointmentList;
                }
            }
            return appointmentList;
        }

        //Delete an appointment
        public void deleteAppointment(int apptId)
        {
            string query = "DELETE FROM appointment WHERE [id number] = @ID";
            
            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();

                cmd.CommandText = query;             

                cmd.Parameters.Add("@ID", apptId);              

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

        //Delete old free time appointments
        public void deleteOldFreeTimeAppointments()
        {
            string query = "DELETE FROM appointment WHERE ([isFreeTimeSession] = 'True' AND endTime < GETDATE())";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();

                cmd.CommandText = query;
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

        //Edit an appointment -- just reassign values to everything that makes up an appointment
        public void editAppointment(int apptId, string free, string meetingPlace, string course, DateTime startTime, DateTime endTime, string tutor, string tutee, bool isFreeTime, bool? isApproved, string source)
        {
            string query = "UPDATE appointment SET [free time] = @free, tutor = @tutor, tutee = @tutee, courseName = @course, meetingPlace = @meetingPlace, startTime = @startTime, endTime = @endTime, isFreeTimeSession = @isFreeTime, isApproved = @isApproved, source = @source WHERE [id number] = @apptId";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@apptId", apptId);
                if (free == null)
                    cmd.Parameters.Add("@free", DBNull.Value);
                else
                    cmd.Parameters.Add("@free", free);
                if (meetingPlace == null)
                    cmd.Parameters.Add("@meetingPlace", DBNull.Value);
                else
                    cmd.Parameters.Add("@meetingPlace", meetingPlace);
                if (tutor == null)
                    cmd.Parameters.Add("@tutor", DBNull.Value);
                else
                    cmd.Parameters.Add("@tutor", tutor);
                if (tutee == null)
                    cmd.Parameters.Add("@tutee", DBNull.Value);
                else
                    cmd.Parameters.Add("@tutee", tutee);
                if (course == null)
                    cmd.Parameters.Add("@course", DBNull.Value);
                else
                    cmd.Parameters.Add("@course", course);
                cmd.Parameters.Add("@startTime", startTime);
                cmd.Parameters.Add("@endTime", endTime);
                cmd.Parameters.Add("@isFreeTime", isFreeTime);
                if (isApproved == null)
                    cmd.Parameters.Add("@isApproved", DBNull.Value);
                else
                    cmd.Parameters.Add("@isApproved", isApproved);
                if (source == null)
                    cmd.Parameters.Add("@source", DBNull.Value);
                else
                    cmd.Parameters.Add("@source", source);
                cmd.Connection = con;
                
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }this.CloseConnection();
            }
        }

        /*private Appointment getAppointmentById(int id);
        Preconditions: Appointment with associated id already exists.
        Post-conditions: Appointment is returned with matching id.
        Function: Returns the appointment object with id similar to argument*/
        public Appointment getAppointmentById(int id)
        {
            Appointment appt = new Appointment();

            string query;
            query = "SELECT * FROM appointment WHERE  ([id number] = @id)";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@id", id);
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    { //have to make catches for all of the nulls that might be in the database

                        //appt.setID((int)dataReader["id number"]);
                        if (dataReader["free time"] == DBNull.Value)
                        {
                            appt.setFreeTimeProf(null);
                        }
                        else
                        {
                            appt.setFreeTimeProf(dataReader["free time"].ToString());
                        }

                        if (dataReader["tutor"] == DBNull.Value)
                        {
                            appt.setTutor(null);
                        }
                        else
                        {
                            appt.setTutor(dataReader["tutor"].ToString());
                        }
                        if (dataReader["tutee"] == DBNull.Value)
                        {
                            appt.setTutee(null);
                        }
                        else
                        {
                            appt.setTutee(dataReader["tutee"].ToString());
                        }
                        if (dataReader["courseName"] == DBNull.Value)
                        {
                            appt.setCourse(null);
                        }
                        else
                        {
                            appt.setCourse(dataReader["courseName"].ToString());
                        }
                        if (dataReader["meetingPlace"] == DBNull.Value)
                        {
                            appt.setMeetingPlace(null);
                        }
                        else
                        {
                            appt.setMeetingPlace(dataReader["meetingPlace"].ToString());
                        }
                        appt.setStartTime((DateTime)dataReader["startTime"]);
                        appt.setEndTime((DateTime)dataReader["endTime"]);
                        appt.setIsFreeTimeSession((bool)dataReader["isFreeTimeSession"]);
                        appt.setSource(dataReader["source"].ToString());
                        appt.setID(id); //Scott added this.
                        //appointmentList.Add(newAppointment);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return appt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return appt;
        }

        //Scott made this function for search refinement. Returns all appointments which are free time.
        //Garrett: make sure the EditAppointment function changes the isFreeTimeSession value when it should.
        public HashSet<Appointment> getAllFreeTimeAppointments()
        {
            HashSet<Appointment> appointmentList = new HashSet<Appointment>();

            string query;
            query = "SELECT * FROM appointment WHERE ([isFreeTimeSession] = 'True' AND [endTime] > GETDATE())";

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
                    { //have to make catches for all of the nulls that might be in the database
                        Appointment newAppointment = new Appointment();
                        newAppointment.setID((int)dataReader["id number"]);
                        if (dataReader["free time"] == DBNull.Value)
                        {
                            newAppointment.setFreeTimeProf(null);
                        }
                        else
                        {
                            newAppointment.setFreeTimeProf(dataReader["free time"].ToString());
                        }

                        if (dataReader["tutor"] == DBNull.Value)
                        {
                            newAppointment.setTutor(null);
                        }
                        else
                        {
                            newAppointment.setTutor(dataReader["tutor"].ToString());
                        }
                        if (dataReader["tutee"] == DBNull.Value)
                        {
                            newAppointment.setTutee(null);
                        }
                        else
                        {
                            newAppointment.setTutee(dataReader["tutee"].ToString());
                        }
                        if (dataReader["courseName"] == DBNull.Value)
                        {
                            newAppointment.setCourse(null);
                        }
                        else
                        {
                            newAppointment.setCourse(dataReader["courseName"].ToString());
                        }
                        if (dataReader["meetingPlace"] == DBNull.Value)
                        {
                            newAppointment.setMeetingPlace(null);
                        }
                        else
                        {
                            newAppointment.setMeetingPlace(dataReader["meetingPlace"].ToString());
                        }
                        if (dataReader["isFreeTimeSession"] == DBNull.Value)
                        {
                            newAppointment.setIsFreeTimeSession(false);
                        }
                        else
                        {
                            newAppointment.setIsFreeTimeSession((bool)dataReader["isFreeTimeSession"]);
                        }
                        if (dataReader["isApproved"] == DBNull.Value)
                        {
                            newAppointment.setIsApproved(false);
                        }
                        else
                        {
                            newAppointment.setIsApproved((bool)dataReader["isApproved"]);
                        }
                        newAppointment.setStartTime((DateTime)dataReader["startTime"]);
                        newAppointment.setEndTime((DateTime)dataReader["endTime"]);
                        newAppointment.setIsFreeTimeSession((bool)dataReader["isFreeTimeSession"]);
                        newAppointment.setID((int)dataReader["id number"]); //Scott added this.
                        appointmentList.Add(newAppointment);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return appointmentList;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    appointmentList.Clear();
                    this.CloseConnection();
                    return appointmentList;
                }
            }
            return appointmentList;
        }

        //function cause I wasn't having luck with the built in ones.
        public HashSet<Appointment> getAppointmentCourseSet(string course)
        {
            HashSet<Appointment> appointmentSet = new HashSet<Appointment>();

            string query;
            query = "SELECT * FROM appointment INNER JOIN (SELECT username FROM tutorCourses WHERE (course1 = @course OR course2 = @course OR course3 = @course OR course4 = @course)) temp ON appointment.[free time] = temp.username";
            //query2 = "SELECT username FROM tutorCourses WHERE (course1 = @course OR course2 = @course OR course3 = @course OR course4 = @course)";  WHERE ([courseName] = @course)

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@course", course);
                cmd.Connection = con;

                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    { //have to make catches for all of the nulls that might be in the database
                        Appointment newAppointment = new Appointment();
                        newAppointment.setID((int)dataReader["id number"]);
                        if (dataReader["free time"] == DBNull.Value)
                        {
                            newAppointment.setFreeTimeProf(null);
                        }
                        else
                        {
                            newAppointment.setFreeTimeProf(dataReader["free time"].ToString());
                        }

                        if (dataReader["tutor"] == DBNull.Value)
                        {
                            newAppointment.setTutor(null);
                        }
                        else
                        {
                            newAppointment.setTutor(dataReader["tutor"].ToString());
                        }
                        if (dataReader["tutee"] == DBNull.Value)
                        {
                            newAppointment.setTutee(null);
                        }
                        else
                        {
                            newAppointment.setTutee(dataReader["tutee"].ToString());
                        }
                        if (dataReader["courseName"] == DBNull.Value)
                        {
                            newAppointment.setCourse(null);
                        }
                        else
                        {
                            newAppointment.setCourse(dataReader["courseName"].ToString());
                        }
                        if (dataReader["meetingPlace"] == DBNull.Value)
                        {
                            newAppointment.setMeetingPlace(null);
                        }
                        else
                        {
                            newAppointment.setMeetingPlace(dataReader["meetingPlace"].ToString());
                        }
                        newAppointment.setStartTime((DateTime)dataReader["startTime"]);
                        newAppointment.setEndTime((DateTime)dataReader["endTime"]);
                        newAppointment.setIsFreeTimeSession((bool)dataReader["isFreeTimeSession"]);
                        appointmentSet.Add(newAppointment);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return appointmentSet;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    appointmentSet.Clear();
                    this.CloseConnection();
                    return appointmentSet;
                }
            }
            return appointmentSet;
        }

        //Scott: Look on the Program.cs ... I use the below functions and a homemade intersect 
        //function cause I wasn't having luck with the built in ones.
        public HashSet<Appointment> getAppointmentPlaceSet(string place)
        {
            HashSet<Appointment> appointmentSet = new HashSet<Appointment>();

            string query;
            query = "SELECT * FROM appointment WHERE  ([meetingPlace] = @place)";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@place", place);
                cmd.Connection = con;

                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    { //have to make catches for all of the nulls that might be in the database
                        Appointment newAppointment = new Appointment();
                        newAppointment.setID((int)dataReader["id number"]);
                        if (dataReader["free time"] == DBNull.Value)
                        {
                            newAppointment.setFreeTimeProf(null);
                        }
                        else
                        {
                            newAppointment.setFreeTimeProf(dataReader["free time"].ToString());
                        }

                        if (dataReader["tutor"] == DBNull.Value)
                        {
                            newAppointment.setTutor(null);
                        }
                        else
                        {
                            newAppointment.setTutor(dataReader["tutor"].ToString());
                        }
                        if (dataReader["tutee"] == DBNull.Value)
                        {
                            newAppointment.setTutee(null);
                        }
                        else
                        {
                            newAppointment.setTutee(dataReader["tutee"].ToString());
                        }
                        if (dataReader["courseName"] == DBNull.Value)
                        {
                            newAppointment.setCourse(null);
                        }
                        else
                        {
                            newAppointment.setCourse(dataReader["courseName"].ToString());
                        }
                        if (dataReader["meetingPlace"] == DBNull.Value)
                        {
                            newAppointment.setMeetingPlace(null);
                        }
                        else
                        {
                            newAppointment.setMeetingPlace(dataReader["meetingPlace"].ToString());
                        }
                        newAppointment.setStartTime((DateTime)dataReader["startTime"]);
                        newAppointment.setEndTime((DateTime)dataReader["endTime"]);
                        newAppointment.setIsFreeTimeSession((bool)dataReader["isFreeTimeSession"]);
                        appointmentSet.Add(newAppointment);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return appointmentSet;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    appointmentSet.Clear();
                    this.CloseConnection();
                    return appointmentSet;
                }
            }
            return appointmentSet;
        }

        //Scott: Look on the Program.cs ... I use the below functions and a homemade intersect 
        //function cause I wasn't having luck with the built in ones.
        public HashSet<Appointment> getAppointmentTutorSet(string tutor)
        {
            HashSet<Appointment> appointmentSet = new HashSet<Appointment>();

            string query;
            query = "SELECT * FROM appointment WHERE  ([free time] = @tutor)";  //Scott changed this from [tutor] = @tutor

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@tutor", tutor);
                cmd.Connection = con;

                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    { //have to make catches for all of the nulls that might be in the database
                        Appointment newAppointment = new Appointment();
                        newAppointment.setID((int)dataReader["id number"]);
                        if (dataReader["free time"] == DBNull.Value)
                        {
                            newAppointment.setFreeTimeProf(null);
                        }
                        else
                        {
                            newAppointment.setFreeTimeProf(dataReader["free time"].ToString());
                        }

                        if (dataReader["tutor"] == DBNull.Value)
                        {
                            newAppointment.setTutor(null);
                        }
                        else
                        {
                            newAppointment.setTutor(dataReader["tutor"].ToString());
                        }
                        if (dataReader["tutee"] == DBNull.Value)
                        {
                            newAppointment.setTutee(null);
                        }
                        else
                        {
                            newAppointment.setTutee(dataReader["tutee"].ToString());
                        }
                        if (dataReader["courseName"] == DBNull.Value)
                        {
                            newAppointment.setCourse(null);
                        }
                        else
                        {
                            newAppointment.setCourse(dataReader["courseName"].ToString());
                        }
                        if (dataReader["meetingPlace"] == DBNull.Value)
                        {
                            newAppointment.setMeetingPlace(null);
                        }
                        else
                        {
                            newAppointment.setMeetingPlace(dataReader["meetingPlace"].ToString());
                        }
                        newAppointment.setStartTime((DateTime)dataReader["startTime"]);
                        newAppointment.setEndTime((DateTime)dataReader["endTime"]);
                        newAppointment.setIsFreeTimeSession((bool)dataReader["isFreeTimeSession"]);
                        appointmentSet.Add(newAppointment);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return appointmentSet;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    appointmentSet.Clear();
                    this.CloseConnection();
                    return appointmentSet;
                }
            }
            return appointmentSet;
        }

        //Scott: Look on the Program.cs ... I use the below functions and a homemade intersect 
        //function cause I wasn't having luck with the built in ones.
        public HashSet<Appointment> getAppointmentDateSet(DateTime start, DateTime end)
        {
            HashSet<Appointment> appointmentSet = new HashSet<Appointment>();

            string query;
            if (start.Date == end.Date)
                query = "SELECT * FROM appointment WHERE  ((DATEPART(yyyy, startTime) = DATEPART(yyyy, @start)) AND (DATEPART(mm, startTime) = DATEPART(mm, @start)) AND (DATEPART(dd, startTime) = DATEPART(dd, @start)))";
            else
                query = "SELECT * FROM appointment WHERE  (startTime BETWEEN @start AND @end)";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@start", start);
                cmd.Parameters.Add("@end", end);
                cmd.Connection = con;

                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    { //have to make catches for all of the nulls that might be in the database
                        Appointment newAppointment = new Appointment();
                        newAppointment.setID((int)dataReader["id number"]);
                        if (dataReader["free time"] == DBNull.Value)
                        {
                            newAppointment.setFreeTimeProf(null);
                        }
                        else
                        {
                            newAppointment.setFreeTimeProf(dataReader["free time"].ToString());
                        }

                        if (dataReader["tutor"] == DBNull.Value)
                        {
                            newAppointment.setTutor(null);
                        }
                        else
                        {
                            newAppointment.setTutor(dataReader["tutor"].ToString());
                        }
                        if (dataReader["tutee"] == DBNull.Value)
                        {
                            newAppointment.setTutee(null);
                        }
                        else
                        {
                            newAppointment.setTutee(dataReader["tutee"].ToString());
                        }
                        if (dataReader["courseName"] == DBNull.Value)
                        {
                            newAppointment.setCourse(null);
                        }
                        else
                        {
                            newAppointment.setCourse(dataReader["courseName"].ToString());
                        }
                        if (dataReader["meetingPlace"] == DBNull.Value)
                        {
                            newAppointment.setMeetingPlace(null);
                        }
                        else
                        {
                            newAppointment.setMeetingPlace(dataReader["meetingPlace"].ToString());
                        }
                        newAppointment.setStartTime((DateTime)dataReader["startTime"]);
                        newAppointment.setEndTime((DateTime)dataReader["endTime"]);
                        newAppointment.setIsFreeTimeSession((bool)dataReader["isFreeTimeSession"]);
                        appointmentSet.Add(newAppointment);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return appointmentSet;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    appointmentSet.Clear();
                    this.CloseConnection();
                    return appointmentSet;
                }
            }
            return appointmentSet;
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

        //function to get all the tutor usernames that tutor a specific course
        public List<string> getUsernamesForCourse(string courseName, bool isTutor)
        {
            string query;
            if (isTutor)
                query = "SELECT username FROM tutorCourses WHERE ((course1 = @course AND course1Approved = @approved) OR (course2 = @course AND course2Approved = @approved) OR (course3 = @course AND course3Approved = @approved) OR (course4 = @course AND course4Approved = @approved))";
            else
                query = "SELECT username FROM tuteeCourses WHERE (course1 = @course OR course2 = @course OR course3 = @course OR course4 = @course)";

            List<string> usernameList = new List<string>();

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@course", courseName);
                cmd.Parameters.Add("@approved", "True");
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        usernameList.Add(dataReader["username"] + "");
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return usernameList;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    usernameList.Clear();
                    this.CloseConnection();
                    return usernameList;
                }
            }
            else
                return usernameList;
        }

        //if the courses what someone can tutor, pass in true
        //if the courses what someone wants to be tutored, pass in false
        //only use this function during registration or after courses have been deleted
        public void addNewCourseList(string username, List<string> courseList, bool isTutor)
        {
            string query;
            if (isTutor)
                query = "INSERT into tutorCourses (username, course1, course2, course3, course4, course1Approved, course2Approved, course3Approved, course4Approved) VALUES (@username, @course1, @course2, @course3, @course4, @approved1, @approved2, @approved3, @approved4)";
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
                if (isTutor)
                {
                    int j = 0;
                    for (; j < 4; ++j)
                    {
                        cmd.Parameters.Add("@approved" + (j + 1).ToString(), DBNull.Value);
                    }                   
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

        //Delete a tutors list
        public void deleteTutorList(string username)
        {
            string query = "DELETE FROM tutorCourses WHERE username = @username";
            
            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.Parameters.Add("@username", username);
                cmd.CommandText = query;
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
        
        //Delete a tutees list
        public void deleteTuteeList(string username)
        {
            string query = "DELETE FROM tuteeCourses WHERE username = @username";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.Parameters.Add("@username", username);
                cmd.CommandText = query;
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

        //Set the approved status of courses in the database
        public void setCourseApproval(string username, bool? course1, bool? course2, bool? course3, bool? course4)
        {
            string query = "UPDATE tutorCourses SET course1Approved = @course1, course2Approved = @course2, course3Approved = @course3, course4Approved = @course4 WHERE username = @username";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", username);
                if(course1 == null)
                    cmd.Parameters.Add("@course1", DBNull.Value);
                else
                    cmd.Parameters.Add("@course1", course1);

                if (course2 == null)
                    cmd.Parameters.Add("@course2", DBNull.Value);
                else
                    cmd.Parameters.Add("@course2", course2);

                if (course3 == null)
                    cmd.Parameters.Add("@course3", DBNull.Value);
                else
                    cmd.Parameters.Add("@course3", course3);

                if (course4 == null)
                    cmd.Parameters.Add("@course4", DBNull.Value);
                else
                    cmd.Parameters.Add("@course4", course4);

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

        //gets all of the courses, returned in a list of strings
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

        //gets all locations
        public List<string> getAllLocations()
        {
            string query;
            query = "SELECT name FROM location";

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

        //gets a user password
        public string getUserPassword(string username)
        {
            string query;
            query = "SELECT password FROM profile WHERE username = @username";

            string pass = "";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.Parameters.Add("@username", username);
                cmd.CommandText = query;
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        pass = dataReader["password"].ToString() + "";
                        
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return pass;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.CloseConnection();
                    return pass;
                }
            }
            else
                return pass;
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

        //This function is for the user to delete their account
        public void userDeleteAccount(string username, string password)
        {
            bool isValidDelete = false;
            Database db = new Database();

            if (this.OpenConnection()) 
            {
                db.isValidSignIn(username, password, ref isValidDelete);
                if (isValidDelete)
                {
                    db.deleteAccount(username);
                }

            }
        }

        //This function is called if the X button is hit during the register process to
        //delete any information we may have put into the database
        public void deleteAccount(string username)
        {
            string queryProfile = "DELETE FROM profile WHERE username = @username";
            string queryTuteeCourse = "DELETE FROM tuteeCourses WHERE username = @username";
            string queryTutorCourse = "DELETE FROM tutorCourses WHERE username = @username";
            string queryAppointment = "DELETE FROM appointment WHERE ([free time] = @username)";
            string queryReceivedMessages = "DELETE FROM receivedMessages WHERE toUserName = @username";
            string querySentMessages = "DELETE FROM sentMessages WHERE fromUserName = @username";

            string subject = "Appointment Deleted";

            if (this.OpenConnection())
            {
                SqlCeCommand cmdDeleteProfile = new SqlCeCommand();
                SqlCeCommand cmdDeleteTuteeCourse = new SqlCeCommand();
                SqlCeCommand cmdDeleteTutorCourse = new SqlCeCommand();
                SqlCeCommand cmdDeleteAppointment = new SqlCeCommand();
                SqlCeCommand cmdDeleteReceivedMessages = new SqlCeCommand();
                SqlCeCommand cmdDeleteSentMessages = new SqlCeCommand();

                cmdDeleteProfile.CommandText = queryProfile;
                cmdDeleteTuteeCourse.CommandText = queryTuteeCourse;
                cmdDeleteTutorCourse.CommandText = queryTutorCourse;
                cmdDeleteAppointment.CommandText = queryAppointment;
                cmdDeleteReceivedMessages.CommandText = queryReceivedMessages;
                cmdDeleteSentMessages.CommandText = querySentMessages;

                cmdDeleteProfile.Parameters.Add("@username", username);
                cmdDeleteTuteeCourse.Parameters.Add("@username", username);
                cmdDeleteTutorCourse.Parameters.Add("@username", username);
                cmdDeleteAppointment.Parameters.Add("@username", username);
                cmdDeleteReceivedMessages.Parameters.Add("@username", username);
                cmdDeleteSentMessages.Parameters.Add("@username", username);

                cmdDeleteTutorCourse.Connection = con;
                cmdDeleteTuteeCourse.Connection = con;
                cmdDeleteProfile.Connection = con;
                cmdDeleteAppointment.Connection = con;
                cmdDeleteReceivedMessages.Connection = con;
                cmdDeleteSentMessages.Connection = con;

                try
                {      
                    cmdDeleteProfile.ExecuteNonQuery();
                    cmdDeleteTuteeCourse.ExecuteNonQuery();
                    cmdDeleteTutorCourse.ExecuteNonQuery();
                    cmdDeleteAppointment.ExecuteNonQuery();

                    //Now we need to delete all of the appointments where the profile
                    //was a tutor or tutee and send the appropriate message
                    Database db = new Database();
                    List<Appointment> apptList = db.getDailyAppointments(username);
                    foreach (Appointment appt in apptList)
                    {
                        string otherUser = "";
                        if (appt.getTutee() == username)
                            otherUser = appt.getTutor();
                        else
                            otherUser = appt.getTutee();

                        db.sendMessage(username, otherUser, subject, username + " has deleted your appointment for " + appt.getCourse(), true, DateTime.Now, appt.getCourse(), appt.getID());
                        db.deleteAppointment(appt.getID());
                    }

                    //Delete the correct messages that were just created that notified the other students
                    //that appointments had been deleted
                    cmdDeleteReceivedMessages.ExecuteNonQuery();
                    cmdDeleteSentMessages.ExecuteNonQuery();
                    
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
            query = "SELECT profile.firstName, profile.lastName, profile.isTutor, profile.isTutee, profile.isFaculty, profile.isAdmin, tuteeCourses.course1 AS tuteeCourse1, tuteeCourses.course2 AS tuteeCourse2, tuteeCourses.course3 AS tuteeCourse3, tuteeCourses.course4 AS tuteeCourse4, tutorCourses.course1 AS tutorCourse1, tutorCourses.course2 AS tutorCourse2, tutorCourses.course3 AS tutorCourse3, tutorCourses.course4 AS tutorCourse4, tutorCourses.course1Approved, tutorCourses.course2Approved, tutorCourses.course3Approved, tutorCourses.course4Approved FROM profile LEFT OUTER JOIN tuteeCourses ON profile.username = tuteeCourses.username LEFT OUTER JOIN tutorCourses ON profile.username = tutorCourses.username WHERE profile.username = @username";


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
                        list.Add(dataReader["firstName"] + ""); //0
                        list.Add(dataReader["lastName"] + "");  //1
                        list.Add(dataReader["isTutor"] + "");   //2
                        list.Add(dataReader["isTutee"] + "");   //3 
                        list.Add(dataReader["tuteeCourse1"] + "");  //4
                        list.Add(dataReader["tuteeCourse2"] + "");  //5
                        list.Add(dataReader["tuteeCourse3"] + "");  //6
                        list.Add(dataReader["tuteeCourse4"] + "");  //7
                        list.Add(dataReader["tutorCourse1"] + "");  //8
                        list.Add(dataReader["tutorCourse2"] + "");  //9
                        list.Add(dataReader["tutorCourse3"] + "");  //10
                        list.Add(dataReader["tutorCourse4"] + "");  //11
                        list.Add(dataReader["course1Approved"] + "");   //12
                        list.Add(dataReader["course2Approved"] + "");   //13
                        list.Add(dataReader["course3Approved"] + "");   //14
                        list.Add(dataReader["course4Approved"] + "");   //15
                        list.Add(dataReader["isFaculty"] + ""); //16
                        list.Add(dataReader["isAdmin"] + "");   //17
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

        //Edits a current profile
        //Username is not edited but is needed so that the right profile can be edited
        public void editProfileInfo(string username, string firstName, string lastName, string password, bool isTutor, bool isTutee)
        {
            string query;
            query = "UPDATE profile SET firstName = @firstName, lastName = @lastName, password = @password, isTutor = @isTutor, isTutee = @isTutee WHERE username = @username";

            List<string> list = new List<string>();

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", username);
                cmd.Parameters.Add("@password", password);
                cmd.Parameters.Add("@firstName", firstName);
                cmd.Parameters.Add("@lastName", lastName);
                cmd.Parameters.Add("@isTutor", isTutor);
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

        //Edits a current profile's password
        //Username is not edited but is needed so that the right profile can be edited
        //Function would be called only by administrator
        public void editPassword(string username, string password)
        {
            string query;
            query = "UPDATE profile SET password = @password WHERE username = @username";

            List<string> list = new List<string>();

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@username", username);
                cmd.Parameters.Add("@password", password);

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
        
        //create a message to send between users
        public void sendMessage(string fromUser, string toUser, string subject, string message, bool? approved, DateTime sentTime, string courseName, int appointmentID)
        {
            string querySent, queryReceived;
            querySent = "INSERT INTO sentMessages (fromUserName, toUserName, subject, message, approved, timeSent, courseName, apptId) VALUES (@fromUser, @toUser, @subject, @message, @approved, @sentTime, @course, @apptId)";
            queryReceived = "INSERT INTO receivedMessages (fromUserName, toUserName, subject, message, approved, timeSent, courseName, apptId) VALUES (@fromUser, @toUser, @subject, @message, @approved, @sentTime, @course, @apptId)";

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

                if (subject == null)
                {
                    cmdSent.Parameters.Add("@subject", DBNull.Value);
                    cmdReceived.Parameters.Add("@subject", DBNull.Value);
                }
                else
                {
                    cmdSent.Parameters.Add("@subject", subject);
                    cmdReceived.Parameters.Add("@subject", subject);
                }

                if (message == null)
                {
                    cmdSent.Parameters.Add("@message", DBNull.Value);
                    cmdReceived.Parameters.Add("@message", DBNull.Value);
                }
                else
                {
                    cmdSent.Parameters.Add("@message", message);
                    cmdReceived.Parameters.Add("@message", message);
                }

                if (approved == null)
                {
                    cmdSent.Parameters.Add("@approved", DBNull.Value);
                    cmdReceived.Parameters.Add("@approved", DBNull.Value);
                }
                else
                {
                    cmdSent.Parameters.Add("@approved", approved);
                    cmdReceived.Parameters.Add("@approved", approved);
                }
              
                cmdSent.Parameters.Add("@sentTime", sentTime);
                cmdReceived.Parameters.Add("@sentTime", sentTime);

                if (courseName == null)
                {
                    cmdSent.Parameters.Add("@course", DBNull.Value);
                    cmdReceived.Parameters.Add("@course", DBNull.Value);
                }
                else
                {
                    cmdSent.Parameters.Add("@course", courseName);
                    cmdReceived.Parameters.Add("@course", courseName);
                }

              
                cmdSent.Parameters.Add("@apptId", appointmentID);
                cmdReceived.Parameters.Add("@apptId", appointmentID);

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

        //get one inbox message, received messages that were sent to user
        public Messages getInboxMessage(int messageID)
        {
            Messages message = new Messages();

            string query;
            query = "SELECT * FROM receivedMessages WHERE receivedMessages.[id number] = @messageID";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@messageID", messageID);
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
                            newMessage.setPending((bool?)dataReader["approved"]);
                        newMessage.setDateTime((DateTime)dataReader["timeSent"]);
                        newMessage.setCourseName(dataReader["courseName"].ToString());
                        if (dataReader["apptId"] == DBNull.Value)
                            newMessage.setApptId(-1);
                        else
                            newMessage.setApptId((int)dataReader["apptId"]);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return message;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    message = null;
                    this.CloseConnection();
                    return message;
                }
            }
            message = null;
            return message;
        }

        //get inbox, received messages that were sent to user
        public List<Messages> getInbox(string username)
        {
            List<Messages> messageList = new List<Messages>();

            string query;
            query = "SELECT * FROM receivedMessages WHERE receivedMessages.toUserName = @username";

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
                            newMessage.setPending((bool?)dataReader["approved"]);
                        newMessage.setDateTime((DateTime)dataReader["timeSent"]);
                        newMessage.setCourseName(dataReader["courseName"].ToString());
                        if (dataReader["apptId"] == DBNull.Value)
                            newMessage.setApptId(-1);
                        else
                            newMessage.setApptId((int)dataReader["apptId"]);
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
                    messageList.Clear();
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
                            newMessage.setPending((bool?)dataReader["approved"]);
                        newMessage.setDateTime((DateTime)dataReader["timeSent"]);
                        newMessage.setCourseName(dataReader["courseName"].ToString());
                        if (dataReader["apptId"] == DBNull.Value)
                            newMessage.setApptId(-1);
                        else
                            newMessage.setApptId((int)dataReader["apptId"]);
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
                    messageList.Clear();
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

        //figures out which faculty goes username goes with a course
        public string getFacultyApprover(string courseName) 
        {
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

        //figures out if the profile is a faculty profile or not
        public bool isFacultyAccount(string user)
        {
            string query = "SELECT isFaculty FROM profile WHERE username = @username";

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
                    string isFaculty = "";
                    while (dataReader.Read())
                    {
                        isFaculty = dataReader["isFaculty"] + "";
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();

                    if (isFaculty == "True")
                        return true;
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.CloseConnection();
                    return false;
                }
            }
            else
                return false;

        }

        //figures out if the profile is an admin profile or not
        public bool isAdminAccount(string user)
        {
            string query = "SELECT isAdmin FROM profile WHERE username = @username";

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
                    string isAdmin = "";
                    while (dataReader.Read())
                    {
                        isAdmin = dataReader["isAdmin"] + "";
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();

                    if (isAdmin == "True")
                        return true;
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.CloseConnection();
                    return false;
                }
            }
            else
                return false;

        }

        //Get message idea given an appointment
        public int getMessageIdFromAppt(int apptId)
        {
            string query = "SELECT [id number] FROM sentMessages WHERE (apptId = @apptId AND subject IN ('Free Time Filled.', 'Request for appointment'))";
            int messageId = -1;

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@apptId", apptId);
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        messageId = (int)dataReader["id number"];
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();

                    return messageId;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.CloseConnection();
                    return messageId;
                }
            }
            else
                return messageId;

        }

        //turn the value in messages to true once the tutor approves the session
        public void approveMessageDetailsFromAppointment(int messageID, bool approval)
        {
            string strApproval = approval.ToString();

            Database db = new Database();
            /*List<string> currentCourseList = db.getCourseList(username, true);
            int index = -1;
            for (int i = 0; i < currentCourseList.Count; i++)
            {
                if (currentCourseList[i] == courseName)
                    index = i;
            }

            if (index != -1)
            {*/
                string query2 = "UPDATE sentMessages SET approved = @true WHERE [id number] = @idNum";
                string query3 = "UPDATE receivedMessages SET approved = @true WHERE [id number] = @idNum";

                if (this.OpenConnection())
                {
                    SqlCeCommand cmd2 = new SqlCeCommand();
                    cmd2.CommandText = query2;
                    cmd2.Parameters.Add("@true", strApproval);
                    cmd2.Parameters.Add("@idNum", messageID);
                    cmd2.Connection = con;
                    SqlCeCommand cmd3 = new SqlCeCommand();
                    cmd3.CommandText = query3;
                    cmd3.Parameters.Add("@true", strApproval);
                    cmd3.Parameters.Add("@idNum", messageID);
                    cmd3.Connection = con;
                    try
                    {
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    this.CloseConnection();
                }
            /*}
            else 
            {
                MessageBox.Show("Course not applicable to tutor.");
            }*/
        }
    
        //turn the value in tutor courses to true once the faculty approves the course
        public void approveCourseInTutorCourses(string username, string courseName, int messageID, bool approval)
        {
            string strApproval = approval.ToString();

            Database db = new Database();
            List<string> currentCourseList = db.getCourseList(username, true);
            int index = -1;
            for (int i = 0; i < currentCourseList.Count; i++)
            {
                if (currentCourseList[i] == courseName)
                    index = i;
            }

            if (index != -1)
            {
                string query = "UPDATE tutorCourses SET course"+(index+1)+"Approved = @value WHERE username = @username";
                string query2 = "UPDATE sentMessages SET approved = @true WHERE [id number] = @idNum";
                string query3 = "UPDATE receivedMessages SET approved = @true WHERE [id number] = @idNum";

                if (this.OpenConnection())
                {
                    SqlCeCommand cmd = new SqlCeCommand();
                    cmd.CommandText = query;
                    cmd.Parameters.Add("@username", username);
                    cmd.Parameters.Add("@value", strApproval);
                    cmd.Connection = con;
                    SqlCeCommand cmd2 = new SqlCeCommand();
                    cmd2.CommandText = query2;
                    cmd2.Parameters.Add("@true", "True");
                    cmd2.Parameters.Add("@idNum", messageID);
                    cmd2.Connection = con;
                    SqlCeCommand cmd3 = new SqlCeCommand();
                    cmd3.CommandText = query3;
                    cmd3.Parameters.Add("@true", "True");
                    cmd3.Parameters.Add("@idNum", messageID);
                    cmd3.Connection = con;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    this.CloseConnection();
                }
            }
            else 
            {
                MessageBox.Show("Course not applicable to tutor.");
            }
        }

        //returns list of all profiles
        public List<string> getAllProfiles()
        {
            List<string> allProfiles = new List<string>();
            string query = "SELECT username, isFaculty, isAdmin FROM profile";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                //cmd.Parameters.Add("@username", user);
                cmd.Connection = con;
                try
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    string user = "";
                    string isFaculty = "";
                    string isAdmin = "";
                    while (dataReader.Read())
                    {
                        
                        user = dataReader["username"].ToString() + "";
                        isFaculty = dataReader["isFaculty"].ToString() + "";
                        isAdmin = dataReader["isAdmin"].ToString() + "";

                        if ((!isFaculty.Equals("True")) && (!isAdmin.Equals("True")))
                            allProfiles.Add(user);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return allProfiles;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    allProfiles.Clear();
                    this.CloseConnection();
                    return allProfiles;
                }
            }
            return allProfiles;

        }

        //returns a list of every tutor that's approved for a specific course
        public List<string> getAllTutorsForCourse(string courseName)
        {
            List<string> tutorList = new List<string>();
            string query = "SELECT username FROM tutorCourses WHERE ((course1 = @courseName AND course1Approved = 'True') OR (course2 = @courseName AND course2Approved = 'True') OR (course3 = @courseName AND course3Approved = 'True') OR (course4 = @courseName AND course4Approved = 'True'))";

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
                    string username = "";
                    while (dataReader.Read())
                    {
                        username = dataReader["username"].ToString() + "";
                        tutorList.Add(username);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return tutorList;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    tutorList.Clear();
                    this.CloseConnection();
                    return tutorList;
                }
            }

            return tutorList;
        }

        //returns a list of all the courses a faculty member is approved to tutor
        public List<string> getFacultyMemberCourses(string username)
        {
            List<string> tutorList = new List<string>();
            string query = "SELECT name FROM courses WHERE facultyApprover = @username";

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
                    string course = "";
                    while (dataReader.Read())
                    {
                        course = dataReader["name"].ToString() + "";
                        tutorList.Add(course);
                    }

                    //close Data Reader
                    dataReader.Close();
                    this.CloseConnection();
                    return tutorList;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    tutorList.Clear();
                    this.CloseConnection();
                    return tutorList;
                }
            }

            return tutorList;
        }

    }
}
