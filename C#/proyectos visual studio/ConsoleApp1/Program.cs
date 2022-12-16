using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace ConsoleApp1
{
    public class Program
    {//index	name	decimal	binario	hexadecimal
        private static string DBPath = @"URI=file:C:\Users\amarin\js\LolnoRepo1\C#\Resources\DB\test3.db";
        private static string TableName = "B64Chars";
        private static string[] ColumnNames = {"id", "name", "decimal", "binario", "hexadecimal" };
        private static string FilePath = @"C:\Users\amarin\js\LolnoRepo1\C#\Resources\B64.csv";
        static void Main(string[] args)
        {
            ///DB connect and check data
            DBWrapper dbW = new DBWrapper();
            var connection = dbW.CreateConnection(DBPath);
            connection.Open();
            bool ExistTable = dbW.ExistsTable(connection, TableName);
            bool isTableEmpty = false;
            bool checkDB = false;
            if (ExistTable)
            {
                isTableEmpty = dbW.IsTableEmpty(connection, TableName);
            }
            else
            {
                dbW.CreateTable(connection, TableName, ColumnNames);
                isTableEmpty = true;
            }
            Console.WriteLine("table exists: " + ExistTable + "   table is empty: " + isTableEmpty);
            if (ExistTable && isTableEmpty)
            {
                var data = GetData();
                ShowText(data);
                FillTable(dbW, connection, data);
            }
            if(ExistTable && !isTableEmpty && checkDB)
            {
                Console.WriteLine(dbW.ReadDB(connection, TableName));
            }
            ///

            //Get N random numbers between 0 and 64
            RNGNumbers rng = new RNGNumbers();
            int[] randNumbers = GetInts(rng, 50);
            ShowNumbers(randNumbers);
            ///
            foreach(int randNum in randNumbers)
            {
                var result = dbW.Select(connection, "id=" + randNum, TableName);
                Console.Write("RandomNumber = " + randNum + " || Value = ");
                Console.WriteLine(result[0] + "  " + result[1] + "  " + result[2] + "  " + result[3] + "  " + result[4]);
            }


            Pause();
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
        public static int[] GetInts(RNGNumbers rng, Int32 length)
        {
            int[] randNumbers = new int[length];
            for (int i = 0; i < randNumbers.Length; i++)
            {
                randNumbers[i] = rng.Next(0, 64);
            }
            return randNumbers;
        }
        public static void ShowNumbers(int[] randNumbers)
        {
            Console.WriteLine("Numbers: " + randNumbers.Length);
            int count = 0;
            foreach (int i in randNumbers)
            {
                if (count == 50)
                {
                    Console.Write(i + "\n\n");
                    count = 0;
                }
                else
                {
                    Console.Write(i + " ");
                    count++;
                }
            }
        }
        public static string GetFileText()
        {
            return File.ReadAllText(FilePath);
        }
        public static List<string[]> GetData()
        {
            string[] lines = GetFileText().Split('\n');
            List<string[]> arrLines = new List<string[]>();
            int con = 0;
            foreach(var l in lines)
            {
                if (l == String.Empty)
                    break;
                if (con == 0)
                {
                    con++;
                    continue;
                }
                string[] line = l.Split(';');
                string[] strings = new string[5];
                for( int i = 0; i < line.Length; i++)
                {
                    strings[i] = line[i];
                }
                arrLines.Add(strings);
                con++;
            }
            return arrLines;
        }
        public static void ShowText(List<string[]> lines)
        {
            foreach(var l in lines)
            {
                Console.WriteLine(l[0] + "    " + l[1] + "    " + l[2] + "    " + l[3] + "    " + l[4]);
            }
        }
        public static void FillTable(DBWrapper dbW, SQLiteConnection connection, List<string[]> data)
        {
            foreach(var sArr in data)
            {
                dbW.Insert(connection, TableName, sArr, ColumnNames);
            }
        }
    }
}