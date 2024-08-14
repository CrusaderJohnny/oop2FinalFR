using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SQLite;



namespace OOP2FINAL.Persistence
{
    internal class DataBase
    {
        private readonly SQLiteAsyncConnection _database;
        public string server;
        public string database;
        public string uid;
        public string password;

        //constructor for database connection
        public DataBase()
        {
            Initialize();
        }
        public void Initialize()
        {
            server = "localdb";
            database = "alexandriadatabase.db";
            uid = "MSI/chris";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + ";";

            connection = new MySqlConnection(connectionString);
        }
        //This will open a connection to the library database
        public bool OpenConnection()
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
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        //this will close the connection to the library data base
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

