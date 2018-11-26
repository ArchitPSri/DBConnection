using System;
using MySql.Data;
using MySql.Data.MySqlClient;

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

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnectionClass _instance = null;
        public static DBConnectionClass Instance()
        {
            if (_instance == null)
                _instance = new DBConnectionClass();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=localhost; database={0}; UID=UserName; password=your password", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}