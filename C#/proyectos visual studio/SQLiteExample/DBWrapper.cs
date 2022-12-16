using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExample
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
        public void CreateTable(SQLiteConnection connection, string tableName)
        {
            string query = "DROP TABLE IF EXISTS " + tableName;
            using var command = CreateCommand(query, connection);
            ExecuteCommand(command);
            command.CommandText = @"CREATE TABLE " + tableName + "(id INTEGER PRIMARY KEY, name TEXT, price INT)";
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
        {//WORKING
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + tableName + "(" + valueNames[0] + "," + valueNames[1] + "," + valueNames[2] + ") VALUES(@" + valueNames[0] + ",@" + valueNames[1] + ",@" + valueNames[2] + ")");
            //Console.WriteLine(sb.ToString());
            using var command = CreateCommand(sb.ToString(), connection);
            for(int i = 0; i < values.Length; i++)
            {
                command.Parameters.AddWithValue("@" + valueNames[i], values[i]);
            }
            command.Prepare();
            ExecuteCommand(command);
        }
        public void Insert(SQLiteConnection connection, string tableName, Dictionary<string, string> fieldValues)
        {//WORKING
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + tableName + "(");
            int contador = 0;
            foreach (var v in fieldValues)
            {
                if (contador == fieldValues.Count - 1)
                {
                    sb.Append(v.Key + ")");
                }
                else
                {
                    sb.Append(v.Key + ",");
                }
                contador++;
            }
            sb.Append(" VALUES(");
            contador = 0;
            foreach (var v in fieldValues)
            {
                if (contador == fieldValues.Count - 1)
                {
                    sb.Append("@" + v.Key + ")");
                }
                else
                {
                    sb.Append("@" + v.Key + ",");
                }
                contador++;
            }
            using var command = CreateCommand(sb.ToString(), connection);
            foreach (var v in fieldValues)
            {
                command.Parameters.AddWithValue("@" + v.Key, v.Value);
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
        public string ReadDB(SQLiteConnection connection, string tableName)
        {
            string query = "SELECT * FROM " + tableName;
            using var command = CreateCommand(query, connection);
            using var reader = GetReader(command);
            StringBuilder sb = new StringBuilder();
            sb.Append(reader.GetTableName(0) + "\n");
            while (reader.Read())
            {
                sb.Append(reader.GetInt32(0) + "  \t" + reader.GetString(1) + "  \t" + reader.GetInt32(2) + "\n");
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
            }
            Console.WriteLine("\nRecord found:\n");
            Console.WriteLine(result[0] + "  " + result[1] + "  " + result[2] + "\n");
            return result;
        }
        public static SQLiteDataReader GetReader(SQLiteCommand command)
        {
            return command.ExecuteReader();
        }
    }
}
