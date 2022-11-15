using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.IO.Enumeration;

namespace TestLibrary1
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
        public SQLiteConnection CreateConnection()
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
        }
        public void SQLiteCloseConnection()
        {
            SQLconn.Close();
        }
        public bool CheckConnection()
        {
            return (SQLconn.State == ConnectionState.Open) ? true : false;
        }
        public void CreateTable()
        {
            SQLiteCommand command;
            string createCommand = "CREATE TABLE Test(Col1 TEXT, Col2 INT)";
            string createCommand1 = "CREATE TABLE Test1(Col1 TEXT, Col2 INT)";
            command = SQLconn.CreateCommand();
            command.CommandText = createCommand;
            command.ExecuteNonQuery();
            command.CommandText = createCommand1;
            command.ExecuteNonQuery();
        }
        public void InsertData()
        {
            SQLiteCommand command;
            command = SQLconn.CreateCommand();
            command.CommandText = "INSERT INTO Test(Col1, Col2) VALUES ('Test Text',1)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Test(Col1, Col2) VALUES ('Test Text',2)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Test(Col1, Col2) VALUES ('Test Text',3)";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO Test1(Col1, Col2) VALUES ('Test Text',3)";
            command.ExecuteNonQuery();
        }
        public string ReadData()
        {
            SQLiteDataReader SQLReader;
            SQLiteCommand command;
            string read = string.Empty;
            command = SQLconn.CreateCommand();
            command.CommandText = "SELECT * FROM test";
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
