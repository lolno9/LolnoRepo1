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
        static string home = Environment.GetEnvironmentVariable("HOMEDRIVE") + Environment.GetEnvironmentVariable("HOMEPATH") + @"\";
        static void Main(string[] args)
        {
            bool isDebug = false;
            string[] testOut = { "ByteConv.byc", (isDebug) ? @"C:\Users\amarin\Desktop\" : home/*@"C:\"*/ };//Default output
            string[] testIn = { "B64.csv", (isDebug) ? @"C:\Users\amarin\Desktop\" : home/*@"C:\"*/ };//Default input
            List<string> testList = new List<string>();//Input (if no custom input select default one)
            Console.Write("File to open: ");
            testList.Add(Console.ReadLine());//Read input file name
            Console.WriteLine(String.IsNullOrWhiteSpace(testList[0]) ? testIn[0] : testList[0]);//If custom input filename empty, set to default
            Console.Write("\nPath of the file: ");
            testList.Add(Console.ReadLine());//Read input file path
            Console.WriteLine(String.IsNullOrWhiteSpace(testList[1]) ? testIn[1] : testList[1]);//If custom input path empty, set to default
            Console.WriteLine("\n"+home+testList[0]);
            Console.WriteLine("\n\n");
            //Check if values inside list are empty strings or not
            if(testList.Count == 2)
            {
                if (string.IsNullOrWhiteSpace(testList[0]))//If empty put default values
                {
                    testList.Remove(testList[0]);
                    testList.Insert(0, testIn[0]);

                }
                if (string.IsNullOrWhiteSpace(testList[1]))//If empty put default values
                {
                    testList.Remove(testList[1]);
                    testList.Insert(1, testIn[1]);
                }
            }
            //Create BitConversor object with path and file name
            BitConversor bitConversor = new BitConversor(testOut[0], testOut[1]);
            bitConversor.SetFullPATH();//Concatenate the path in one string
            //Declare the lists thats gona be using
            List<byte> rawData = new List<byte>();//Read data from fle
            List<string> byteData = new List<string>();//Processed data ready to put in a new/existing file

            string output = testList[1] + testList[0] + "\n";//String used to concatenate data and put inside the new file

            Console.WriteLine("Reading bytes of: " + testList[1] + testList[0]);
            StringBuilder sb = new StringBuilder();
            sb.Append(testList[1] + testList[0] + "\n");
            if (File.Exists(testList[1] + testList[0]))
            {
                rawData = File.ReadAllBytes(testList[1] + testList[0]).ToList();//Read bytes of file and put it in rawData List
                Console.WriteLine("File: " + testList[1] + testList[0] + " Opened");
                int contador = 1;
                string consoleOut = "/" + rawData.Count + " Bytes";
                foreach (byte b in rawData)
                { //Valorate if use ';' separator on bytes
                    //Console.Write(b);
                    byteData.Add(bitConversor.Get8PBinFromByte(b));//Pass each individual byte to bit and put it into byteData List
                    if(contador == rawData.Count())
                    {//Use StringBuilder to optimize work and speed
                        //output += b;
                        sb.Append(b);
                    } else
                    {//Use StringBuilder to optimize work and speed
                        //output += b + ";";
                        sb.Append(b + ";");
                    }
                     //Concatenate all bytes from rawData folowed by ';' in the output String
                    //////////////////////////////////////////////////////
                    ///This loop works for refreshing the progress line
                    /*string*/ //consoleOut = contador + "/" + rawCount + " Bytes";
                    Console.Write(contador+consoleOut);
                    foreach(char c in contador + consoleOut)
                    {
                        Console.Write("\b");
                    }
                    //////////////////////////////////////////////////////
                    contador++;                    
                }///// 660.000 en 15 mins - 1 || 14:50 mins - 2 || 4:57 mins - 3

                Console.WriteLine("\n");
                //output += "\n";//Make new line in output String
                sb.Append("\n");
                Console.WriteLine("Processing bytes of: " + testList[1] + testList[0]);
                contador = 1;
                consoleOut = "/" + byteData.Count() + " Bytes";
                foreach (string s in byteData) 
                {//Use StringBuilder to optimize work and speed
                    //Console.Write(s);
                    sb.Append(s);
                    //output += s; //Concatenate all bits in byteData (As they are allways 8-padded, no need to put separator here)
                    //////////////////////////////////////////////////////
                    ///This loop works for refreshing the progress line
                    /*string *///consoleOut = contador + "/" + byteData.Count() + " Bytes";//
                    Console.Write(contador + consoleOut);//Console.Write(contador+consoleout);
                    foreach (char c in contador + consoleOut)// in contador+consoleout
                    {
                        Console.Write("\b");
                    }
                    //////////////////////////////////////////////////////
                    contador++;
                }
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
            Pause(); 
        }             
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }

    }
}