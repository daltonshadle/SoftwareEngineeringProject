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

        //private string connection = @"Data Source=C:\Users\grbohach\Documents\SoftwareEngineering\Tutor Master\Tutor Master\TutorMaster.sdf";

        //private string connection = @"Data Source=C:\Users\User\Documents\SoftwareEngineering\Tutor Master\Tutor Master\TutorMaster.sdf";
        private string connection = @"Data Source=F:\Software Engineering\Tutor Master\Tutor Master\Tutor Master\TutorMaster.sdf";


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
            string query = "SELECT * FROM profile WHERE username = @username";
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
                        list.Add(dataReader["username"] + "");
                        list.Add(dataReader["password"] + "");
                    }

                    //close Data Reader
                    dataReader.Close();
                    if (password == list[1])
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
        

        
    }
}
