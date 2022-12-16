using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.IO.Enumeration;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SQLiteExample
{
    public class Program
    {
        private static string DBPath = @"URI=file:C:\Users\amarin\test2.db";
        public static void Main(string[] args)
        {
            DBWrapper dbW = new DBWrapper();
            string table = "cars2";
            var connection = dbW.CreateConnection(DBPath);
            connection.Open();
            if (!dbW.ExistsTable(connection, table))
            {
                dbW.CreateTable(connection, table);
            }
            bool check = true;
            do
            {
                Console.WriteLine("What do you want to do,");
                Console.WriteLine("Select/Read (S/R), Insert (I), Update(U) or Delete(D)?");
                var answer = Console.ReadLine();
                if (answer.ToLower() == "s" || answer.ToLower() == "r")
                    Select(dbW, connection, table);
                if (answer.ToLower() == "i")
                    Insert(dbW, connection, table);
                if (answer.ToLower() == "d")
                    Delete(dbW, connection, table);
                if(answer.ToLower() == "u")
                    Update(dbW, connection, table);
                check = EscapeLoop();
                if (check)
                    Console.Clear();
            } while (check);
            Pause();
            connection.Close();
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
        public static void IterateList(List<string[]> list, DBWrapper dbW, SQLiteConnection connection, string tableName)
        {
            string[] valueNames = { list[0][0], list[0][1], list[0][2] };
            foreach(var strArr in list)
            {
                if (strArr[0] == "id")
                    continue;
                dbW.Insert(connection, tableName, strArr, valueNames);
            }
        }
        public static bool EscapeLoop()
        {
            Console.WriteLine("Use Escape to exit");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return false;
            }
            return true;
        }
        public static void Insert(DBWrapper dbW, SQLiteConnection connection, string table) 
        { 
            Console.WriteLine("We are in Insert");
            /// Insert Using dictionary
            //var dict = new Dictionary<string, string>();
            //var dict2 = new Dictionary<string, string>();
            //dict.Add("id", "1");
            //dict.Add("name", "test1");
            //dict.Add("price", "100");
            //dict2.Add("id", "2");
            //dict2.Add("name", "test2");
            //dict2.Add("price", "200");
            //dbW.Insert(connection, table, dict);
            //dbW.Insert(connection, table, dict2);

            /// Insert Using List of arrays
            List<string[]> dict = new List<string[]>();
            dict.Add(new string[] { "id", "name", "price" });
            dict.Add(new string[] { "1", "test1", "100" });
            dict.Add(new string[] { "2", "test2", "200" });
            IterateList(dict, dbW, connection, table);
        }
        public static void Select(DBWrapper dbW, SQLiteConnection connection, string table) 
        {
            Console.WriteLine("We are in Select");
            Console.WriteLine(dbW.ReadDB(connection, table));
        }
        public static void Delete(DBWrapper dbW, SQLiteConnection connection, string table) 
        { 
            Console.WriteLine("We are in Delete");
            dbW.Delete(connection, "id=1", table);
            dbW.Delete(connection, "id=2", table);
        }
        //Select and store, modify, delete and insert
        public static void Update(DBWrapper dbW, SQLiteConnection connection, string table) 
        {
            Console.WriteLine("We are in Update");
            string check = "test1";//check by name(can use any column)
            string modifiedValue = "mod1";
            string[] recordToModify = dbW.Select(connection, "name='"+check+"'", table);
            string[] modRecord = { recordToModify[0], modifiedValue, recordToModify[2] };
            Console.WriteLine("\nDelete old record");
            dbW.Delete(connection, "id="+recordToModify[0], table);
            Console.WriteLine("Old record deleted\n");
            Console.WriteLine("\nInsert Modified Record");
            //Console.WriteLine(modRecord[0] + "  " + modRecord[1] + "  " + modRecord[2] + "\n");
            dbW.Insert(connection, table, modRecord, new string[] { "id", "name", "price" });
            Console.WriteLine("Record Modified\n");
        }
    }
}
