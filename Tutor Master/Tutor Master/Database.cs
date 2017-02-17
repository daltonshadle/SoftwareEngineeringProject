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

        public void Insert()
        {
            string query = "INSERT INTO profile (username, password) VALUES ('fda', 'gssa#1582')";

            if (this.OpenConnection())
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        

        
    }
}
