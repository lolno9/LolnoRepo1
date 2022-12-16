using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DBWrapper
    {
        public SQLiteConnection CreateConnection(string path)
        {
            return new SQLiteConnection(path);
        }
        public static SQLiteCommand CreateCommand(string query, SQLiteConnection connection)
        {
            return new SQLiteCommand(query, connection);
        }
        public static string DBCheck(SQLiteCommand command)
        {
            return command.ExecuteScalar().ToString();
        }
        public void CreateTable(SQLiteConnection connection, string tableName, string[] columns)
        {//"(index INTEGER PRIMARY KEY, name TEXT, decimal INT, binario TEXT, hexadecimal TEXT)";
            string query = "DROP TABLE IF EXISTS " + tableName;
            using var command = CreateCommand(query, connection);
            ExecuteCommand(command);
            command.CommandText = @"CREATE TABLE " + tableName + "(" + columns[0] + " INTEGER PRIMARY KEY, " + columns[1] + " TEXT, " + columns[2] + " INT, " + columns[3] + " TEXT, " + columns[4] + " TEXT)";
            ExecuteCommand(command);
        }
        public bool ExistsTable(SQLiteConnection connection, string tableName)
        {
            string query = "SELECT name FROM sqlite_master WHERE type='table' AND name='" + tableName + "'";
            using var command = CreateCommand(query, connection);
            using var reader = GetReader(command);
            if (reader.HasRows)
            {
                return true;
            } else
            {
                return false;
            }
        }
        private static void ExecuteCommand(SQLiteCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void Insert(SQLiteConnection connection, string tableName, string[] values, string[] valueNames)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + tableName + "(" + valueNames[0] + "," + valueNames[1] + "," + valueNames[2] + "," + valueNames[3] + "," + valueNames[4] + ") VALUES(@" + valueNames[0] + ",@" + valueNames[1] + ",@" + valueNames[2] + ",@" + valueNames[3] + ",@" + valueNames[4] + ")");
            using var command = CreateCommand(sb.ToString(), connection);
            for(int i = 0; i < values.Length; i++)
            {
                command.Parameters.AddWithValue("@" + valueNames[i], values[i]);
            }
            command.Prepare();
            ExecuteCommand(command);
        }
        public void Delete(SQLiteConnection connection, string check, string tableName)
        {
            string query = "DELETE FROM " + tableName + " WHERE " + check;
            using var command = CreateCommand(query, connection);
            ExecuteCommand(command);
        }
        public bool IsTableEmpty(SQLiteConnection connection, string tableName)
        {
            string query = "SELECT * FROM " + tableName;
            using var command = CreateCommand(query, connection);
            using var reader = GetReader(command);
            if (reader.HasRows) { return false; } else { return true; }
        }
        public string ReadDB(SQLiteConnection connection, string tableName)
        {
            string query = "SELECT * FROM " + tableName;
            using var command = CreateCommand(query, connection);
            using var reader = GetReader(command);
            StringBuilder sb = new StringBuilder();
            sb.Append(reader.GetTableName(0) + "\n");
            while (reader.Read())
            {
                sb.Append(reader.GetInt32(0) + "  \t" + reader.GetString(1) + "  \t" + reader.GetInt32(2) + "  \t" + reader.GetString(3) + "  \t" + reader.GetString(4) + "\n");
            }
            return sb.ToString();
        }
        public string[] Select(SQLiteConnection connection, string check, string tableName)
        {//update single record
            string query = "SELECT * FROM " + tableName + " WHERE " + check;
            using var command = CreateCommand(query, connection);
            using var reader = GetReader(command);
            StringBuilder sb = new StringBuilder();
            reader.Read();
            string[] result = new string[reader.FieldCount];
            if (reader.HasRows)
            {
                result[0] = reader.GetInt32(0).ToString();
                result[1] = reader.GetString(1);
                result[2] = reader.GetInt32(2).ToString();
                result[3] = reader.GetString(3);
                result[4] = reader.GetString(4);
            }
            Console.WriteLine("\nRecord found:\n");
            //Console.WriteLine(result[0] + "  " + result[1] + "  " + result[2] + "  " + result[3] + "  " + result[4] + "\n");
            return result;
        }
        public static SQLiteDataReader GetReader(SQLiteCommand command)
        {
            return command.ExecuteReader();
        }
    }
}
