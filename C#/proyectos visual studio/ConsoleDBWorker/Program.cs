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
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Controls;
////*
/// Read data from B64.csv file, show it and process it (if necessary) and put it inside a DB or embedded DB
/// 
////

namespace ConsoleDBWorker // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool hasData = false;
            string filePath = @"C:\B64.csv";//@"C:\Users\amarin\Desktop\B64.csv"; //Path of the file
            string rawData = string.Empty;//Raw file data
            string toSave = string.Empty;
            if (File.Exists(filePath))//Check if file exist and read all its content
            {
                rawData = File.ReadAllText(filePath);
                hasData = true;
            }
            Console.WriteLine(!String.IsNullOrWhiteSpace(rawData) ? rawData : "Data not found"); //Show if data has been read
            //Pause();
            toSave += rawData;////
            List<string> files = new List<string>();
            string[] rawArray = rawData.Split(';');//Split rawData using ';' as separator

            string[] header = { rawArray[0], rawArray[1], rawArray[2], rawArray[3], rawArray[4] }; //header for create table
            foreach (string raw in rawArray)
            {//Add each value inside a list
                if (!String.IsNullOrWhiteSpace(raw))
                {
                    files.Add(raw);
                    //Console.WriteLine(raw +"  Added");
                } else
                {
                    Console.WriteLine("Line is Is Null ////////////////////");
                }
            }

            Pause();
            //////////////////////////////////////////////
            ///Print Formated Data
            string separator = string.Empty;
            string data = string.Empty;
            List<string> querys = new List<string>();
            for (int i = 0; i < files.Count; i++)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3)
                {
                    separator = "   ";
                }
                else
                {
                    separator = "\t";
                }
                {
                    Console.Write(files[i] + separator);
                    if (i >= 5)
                    {
                        data += files[i] + ";";
                    }
                }
                if (i == 28) { Console.Write("\t"); }
            }
            toSave += "\n\nHeader: \n" + header[0] + ";" + header[1] + ";" + header[2] + ";" + header[3] + ";" + header[4] + "\n\n";////
            toSave += "\nData: \n" + data + "\n\n";
            ////////////////////////////////////////////////
            //Pause();
            //Show Header (Columns) and Data.
            Console.WriteLine("\nHeader: \n" + header[0] + ";" + header[1] + ";" + header[2] + ";" + header[3] + ";" + header[4] + "\n");
            Console.WriteLine("Data: " + data);
            Pause();

            string[] tst = data.Split('\n');

            string table = "DBTesteo.db3";
            foreach (string s in tst)
            {
                Console.WriteLine("Connection is true");
                string[] last = s.Split(';');
                if (string.IsNullOrWhiteSpace(last[0]))
                {
                    continue;
                }
                Console.WriteLine(s+"\n"+table+"\t"+ last[0]+ "\t" + last[1]+ "\t" + last[2]+ "\t" + last[3]+ "\t" + last[4]);
                Console.Write("\n");
                toSave += s + "\n" + table + "\t" + last[0] + "\t" + last[1] + "\t" + last[2] + "\t" + last[3] + "\t" + last[4] + "\n";////
            }
            Pause();
            Console.WriteLine("Log saved");
            File.WriteAllText("Test.log", toSave);
            Pause();
        }
        private static bool isNull(string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}