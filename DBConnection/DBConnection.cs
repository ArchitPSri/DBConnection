using System;
using System.Data;
using System.Data.SqlClient;

namespace DBConnection
{
    public class DBConnectionClass
    {
        public DBConnectionClass()
        {
        }

        public int Demo(int a)
        {
            return a + 10;
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }
        
        private SqlConnection connection = null;
        public SqlConnection Connection
        {
            get { return connection; }
        }

        public bool IsConnect()
        {
            try
            {
                if (Connection == null)
                {
                    if (String.IsNullOrEmpty(databaseName))
                        return false;
                    string connstring = @"Data Source=DESKTOP-VI9R21J\SQLSERVER_ARCHIT;Initial Catalog=" + databaseName + "; user id=sa; password=Password@123";
                    
                    connection = new SqlConnection(connstring);
                    
                    connection.Open();
                }

                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                System.Diagnostics.Debug.WriteLine("CATCH -> IsConnect");
                throw e;
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}