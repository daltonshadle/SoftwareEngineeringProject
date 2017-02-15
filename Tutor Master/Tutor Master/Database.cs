using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Tutor_Master
{
    class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Database()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "tutormaster"; //place schema from MySQL here
            uid = "grbohach";
            password = "grbdjssfm";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		    database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert information for new registration
        public void InsertRegistrationInfo(String user, String password)
        {
            string query = "INSERT INTO profile (username, password) VALUES ('"+user+"', '"+password+"')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command put try catch around this
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("This was a unique key violation.");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }              
                    
                }

                //close connection
                this.CloseConnection();
            }
        }



        //Check that username is in the system when signing in
        //Returns true if the username and password are valid
        //Returns false if username is invalid, connection isn't open, or password is incorrect
        public void isValidSignIn(string user, string password, ref bool correctPassword)
        {
            string query = "SELECT * FROM profile WHERE username = '"+user+"'";

            //Create a list to store the result
            List< string > list = new List< string >();
            
            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(dataReader["personnel id"].ToString());
                        list.Add(dataReader["username"].ToString());
                        list.Add(dataReader["password"].ToString());
                    }

                    //close Data Reader
                    dataReader.Close();

                    correctPassword = password == list[2];
                }

                catch
                {
                    correctPassword = false;
                }
                //close Connection
                this.CloseConnection();
                
            }
            else
            {
                correctPassword = false;
            }
        }

        //Update statement
        //public void Update()
        //{
        //    string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

        //    //Open connection
        //    if (this.OpenConnection() == true)
        //    {
        //        //create mysql command
        //        MySqlCommand cmd = new MySqlCommand();
        //        //Assign the query using CommandText
        //        cmd.CommandText = query;
        //        //Assign the connection using Connection
        //        cmd.Connection = connection;

        //        //Execute query
        //        cmd.ExecuteNonQuery();

        //        //close connection
        //        this.CloseConnection();
        //    }
        //}

        ////Delete statement
        //public void Delete()
        //{
        //    string query = "DELETE FROM tableinfo WHERE name='John Smith'";

        //    if (this.OpenConnection() == true)
        //    {
        //        MySqlCommand cmd = new MySqlCommand(query, connection);
        //        cmd.ExecuteNonQuery();
        //        this.CloseConnection();
        //    }
        //}
    }
}
