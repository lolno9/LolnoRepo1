using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.IO.Enumeration;

namespace ConsoleDBWorker
{
    public class DBConnector
    {
        private string DataBaseName {get; set;}
        private string DataBaseLocation { get; set;}
        private SQLiteConnection SQLconn {get; set;}
        private int Version {get; set;}
        private bool IsNew { get; set;}
        private bool Compress { get; set;}

        private const string AppendFileName = ".db3";
        private const string PrefixConnection = "Data Source=";

        public DBConnector() { }
        public DBConnector(string dbName) { DataBaseName = dbName; }
        private string GetFullSource()
        {
            return PrefixConnection + (DataBaseLocation);
        }
        /*public SQLiteConnection CreateConnection()
        {
            string connStr = PrefixConnection + DataBaseName + AppendFileName + ";Version=3";
            SQLconn = new SQLiteConnection(connStr);
            try
            {
                SQLconn.Open();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return SQLconn;
        }*/
        public string GetDataBase()
        {
            if (DataBaseName.Substring(DataBaseName.Length - 3, 3).Equals("db3"))
            {
                return DataBaseName;
            } else
            {
                return DataBaseName+AppendFileName;
            }
        }
        public void CreateConnection() 
        {
            string connStr = PrefixConnection + DataBaseName + ";Version=3";
            SQLconn = new SQLiteConnection(connStr);
            try
            {
                SQLconn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SQLiteCloseConnection()
        {
            SQLconn.Close();
        }
        public bool CheckConnection()
        {
            return (SQLconn.State == ConnectionState.Open) ? true : false;
        }
        public void CreateTable(string createCommand)//General usage (just pass the create command as a parameter)
        {
            SQLiteCommand command;
            command = SQLconn.CreateCommand();
            command.CommandText = createCommand;
            command.ExecuteNonQuery();
        }
        public void CreateTable(string tableName, string[] columns)//hardcoded for this solution 
        {
            SQLiteCommand command;
            string createCommand = String.Format("CREATE TABLE {0} ({1} INT, {2} varchar(20), {3} varchar(20), {4} varchar(20), {5} varchar(20))", tableName, columns[0], columns[1], columns[2], columns[3], columns[4]);
            command = SQLconn.CreateCommand();
            command.CommandText = String.Format("CREATE TABLE {0} ({1} INT, {2} varchar(20), {3} varchar(20), {4} varchar(20), {5} varchar(20))", tableName, columns[0], columns[1], columns[2], columns[3], columns[4]);//createCommand;
            Console.WriteLine(createCommand+"\n"+SQLconn.GetSchema());
            /*Program p = new */Program.Pause();
            if(CheckConnection())
                command.ExecuteNonQuery();
        }

        public void InsertData(string createCommand)//General usage (just pass the create command as a parameter)
        {
            SQLiteCommand command;
            command = SQLconn.CreateCommand();
            command.CommandText = createCommand;
            command.ExecuteNonQuery();
        }
        public void InsertData(string tableName, string[] columns, string[] values)//hardcoded for this solution 
        {
            SQLiteCommand command;
            string createCommand = "INSERT INTO " + tableName + "(" + columns[0]+", "+ columns[1]+", "+ columns[2]+", "+ columns[3]+", "+ columns[4]+") VALUES (" + values[0] + ", " + values[1] + ", " + values[2] + ", " + values[3] + ", " + values[4] + ")";
            command = SQLconn.CreateCommand();
            command.CommandText=createCommand;
            command.ExecuteNonQuery();
            
        }
        public string ReadData(string tableName) //Enter the table name
        {
            SQLiteDataReader SQLReader;
            SQLiteCommand command;
            string read = string.Empty;
            string selectCommand = "SELECT * FROM " + tableName;
            command = SQLconn.CreateCommand();
            command.CommandText = selectCommand;
            SQLReader = command.ExecuteReader();
            while (SQLReader.Read())
            {
                read += SQLReader.GetString(0);
                Console.WriteLine(read);
            }
            return read; 
        }
        public string ReadData(string selectCommand, string read) //Enter de  command and a string empty
        {
            SQLiteDataReader SQLReader;
            SQLiteCommand command;
            command = SQLconn.CreateCommand();
            command.CommandText = selectCommand;
            SQLReader = command.ExecuteReader();
            while (SQLReader.Read())
            {
                read += SQLReader.GetString(0);
                Console.WriteLine(read);
            }
            return read;
        }
        /*
            File.Create("testeo3.db3");
            DBConnector dbc = new DBConnector("testeo3.db3");
            dbc.CreateConnection();
            Console.WriteLine(dbc.CheckConnection() ? "Connection OK" : "Bad Connection");
            //dbc.CreateTable();
            //dbc.InsertData();
            Console.WriteLine(dbc.ReadData());
            dbc.SQLiteCloseConnection();
        */
    }
}
