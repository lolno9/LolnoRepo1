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

namespace ByteConversor 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isDebug = false;
            string[] testOut = { "ByteConv.byc", (isDebug) ? @"C:\Users\amarin\Desktop\" : @"C:\" };//Default output
            string[] testIn = { "B64.csv", (isDebug) ? @"C:\Users\amarin\Desktop\" : @"C:\" };//Default input
            List<string> testList = new List<string>();//Input (if no custom input select default one)
            Console.Write("File to open: ");
            testList.Add(Console.ReadLine());//Read input file name
            Console.WriteLine(String.IsNullOrWhiteSpace(testList[0]) ? testIn[0] : testList[0]);//If custom input filename empty, set to default
            Console.Write("\nPath of the file: ");
            testList.Add(Console.ReadLine());//Read input file path
            Console.WriteLine(String.IsNullOrWhiteSpace(testList[1]) ? testIn[1] : testList[1]);//If custom input path empty, set to default
            Console.WriteLine(testList[0]);
            Console.WriteLine("\n\n");
            if(testList.Count == 2)
            {
                if (string.IsNullOrWhiteSpace(testList[0]))
                {
                    testList.Remove(testList[0]);
                    testList.Insert(0, testIn[0]);

                }
                if (string.IsNullOrWhiteSpace(testList[1]))
                {
                    testList.Remove(testList[1]);
                    testList.Insert(1, testIn[1]);
                }
            }
            BitConversor bitConversor = new BitConversor(testOut[0], testOut[1]);
            bitConversor.SetFullPATH();
            List<byte> rawData = new List<byte>();
            List<string> byteData = new List<string>();
            string output = testList[1] + testList[0] + "\n";
            if (File.Exists(testList[1] + testList[0]))
            {
                rawData = File.ReadAllBytes(testList[1] + testList[0]).ToList();
                Console.WriteLine("File: " + testList[1] + testList[0] + " Opened");
                foreach (byte b in rawData)
                { //Valorate if use ';' separator on bytes
                    //Console.Write(b);
                    byteData.Add(bitConversor.Get8PBinFromByte(b));
                    output += b + ";";
                    
                }
                Console.WriteLine("\n");
                output += "\n";
                foreach (string s in byteData)
                {//No need of ';' separator here cause bits always 8-Padded
                    //Console.Write(s);
                    output += s;
                }
                if (File.Exists(bitConversor.PATHGS))
                {
                    File.AppendAllText(bitConversor.PATHGS, "\n\n" + output);
                    Console.WriteLine("\nFile " + bitConversor.PATHGS + " Writed Succesfully");
                }
                if (!File.Exists(bitConversor.PATHGS))
                {
                    File.WriteAllText(bitConversor.PATHGS, output);
                    Console.WriteLine("\nFile "+ bitConversor.PATHGS + " Created Succesfully");
                }
                //Console.WriteLine("\n" + bitConversor.PATHGS);
            }
            Pause();   
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }

    }
}