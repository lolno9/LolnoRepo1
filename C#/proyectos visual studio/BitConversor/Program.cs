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

namespace BitConversor
{
    internal class Program
    {//Default values, home as default path, infile as input default
        static string home = Environment.GetEnvironmentVariable("HOMEDRIVE") + Environment.GetEnvironmentVariable("HOMEPATH") + @"\";
        static string outFile = "BitConv.byc";
        static string inFile = "BData.byc";
        static void Main(string[] args)
        {//Choose a file for input
            Console.Write("File to open: ");
            var inputFile = Console.ReadLine();//Read input file name
            if (String.IsNullOrWhiteSpace(inputFile))
            {
                inputFile = inFile;
                Console.WriteLine(inputFile);
            }
            else
            {
                Console.WriteLine(inputFile);
            }
            //Choose a path for input
            Console.Write("\nPath of the file: ");
            var inputPath = Console.ReadLine();//Read input file path
            if (String.IsNullOrWhiteSpace(inputPath))
            {
                inputPath = home;
                Console.WriteLine(inputPath);
            }
            else
            {
                Console.WriteLine(inputPath);
            }
            //Show path+file
            Console.WriteLine("\n" + home + inputFile);
            Console.WriteLine("\n\n");
            //Declare 3 dictionaries, 1 for the names, 1 for the bytes (data) and one for the bits (not used right now)
            var fileNames = new Dictionary<int, string>();
            var fileData = new Dictionary<int, string>();
            var fileBits = new Dictionary<int, string>();
            var nameDataRefs = new Dictionary<int, int>();
            //Regex to control we only have 0 and 1 inside the string
            Regex bitRegex = new Regex(@"[0-1]{1,2}\d{8}");
            //Regex to control we only have numbers (not binarys) inside the string
            Regex byteRegex = new Regex(@"\b([00]?[0-9][0-9]?|2[0-4][0-9]|25[0-5])");
            if (File.Exists(inputPath + inputFile))
            {
                //Get text in file
                var data = File.ReadAllText(inputPath + inputFile).Split('\n');
                var spanData = new Span<string>(data);
                for (int i = 0, by=0, bi=0, fn=0; i < spanData.Length; i++)
                {

                    if (spanData[i].Contains(@"C:\"))
                    {
                        //Console.WriteLine(spanData[i]);
                        fileNames.Add(fn, spanData[i]);
                        fileData.Add(by, spanData[i]);
                        fileBits.Add(bi, spanData[i]);
                        Console.WriteLine("IndexNames: " + fn + "  indexBytes: " + by);
                        by++;
                        bi++;
                        fn++;
                        nameDataRefs.Add(fn, by);
                    }else if (bitRegex.IsMatch(spanData[i]))
                    {
                        //Console.WriteLine("BitRegex");
                        //Console.WriteLine(spanData[i]);
                        fileBits.Add(bi, spanData[i]);
                        bi++;
                    }
                    else if (byteRegex.IsMatch(spanData[i]))
                    {
                        //Console.WriteLine("ByteRegex");
                        //Console.WriteLine(spanData[i]);
                        fileData.Add(by, spanData[i]);
                        by++;
                    }
                    else if (String.IsNullOrWhiteSpace(spanData[i])/*spanData[i].Equals("\n")*/)
                    {
                        //Console.WriteLine("linejump");
                        fileData.Add(by, spanData[i]);
                        fileBits.Add(bi, spanData[i]);
                        by++;
                        bi++;
                    }

                }
            }
            ShowMenu(fileNames);
            bool check = true;//Used to break the while
            int result = 0;//Index of selected file
            int index = 0;
            while (check)//Check if input is number and check if that number is in the dictionary
            {
                var indexToCheck = Console.ReadLine();
                if (indexToCheck.ToLower() == "n" || indexToCheck.ToLower() == "no")
                {
                    return;
                }
                if (int.TryParse(indexToCheck, out result))//Check if input is number
                {
                    result = int.Parse(indexToCheck);//if its a number, cast it as int to use in index search
                    foreach (int key in fileNames.Keys)//Check if that number is in the dictionary
                    {
                        if (result == key)//if a result matches, set bool to false and break the foreach loop
                        {//Show file path and name
                            Console.WriteLine("Match found for index: " + result + "\n");
                            Console.WriteLine("--------------------------------------------------------------------------------");
                            Console.WriteLine(fileNames[key]);
                            Console.WriteLine("--------------------------------------------------------------------------------");
                            check = false;
                            index = nameDataRefs.Values.ElementAt(key);/**/
                            break;
                        }
                    }
                }
            }
            //Declare a new byte list to get the final bytes for file creation
            List<byte> bytesSB = new List<byte>();
            //Convert.ToInt32(nameDataRefs[result]);
            Console.WriteLine(index);
            Pause();
            foreach(var v in nameDataRefs)
            {
                Console.WriteLine("Key: " + v.Key + "   Value: " + v.Value);
            }
            //Pause();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (var i = index; i < fileData.Count; i++)//foreach(byte b in bytesSB)foreach(var b in fileData)
            {
                //Console.WriteLine("Iteration counter: " + i);
                //Pause();
                if (fileData[i].Contains(fileNames[result].Split(@"\")[fileNames[result].Split(@"\").Length - 1]))//(b.Value.Equals(fileNames.GetValueOrDefault(result)))
                {
                    //Console.WriteLine("Equals: "+b.Value.Split(@"\")[b.Value.Split(@"\").Length - 1]);
                    continue;
                } else
                {//Splited by ; means it can get 2 bytes concatenated in 1, test and if so, modify to split by \n then ;
                    string[] splited = fileData[i].Split(';');
                    foreach(var s in splited)
                    {
                        if (!String.IsNullOrWhiteSpace(s))
                        {
                            byte.TryParse(s, out byte b);
                            bytesSB.Add(b);
                        } else
                        {
                            break;
                        }
                    }
                }
                if (string.IsNullOrWhiteSpace(fileData[i]))
                {
                    break;
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
          
            //Declare path+name for file
            string path = home + fileNames[result].Split(@"\")[fileNames[result].Split(@"\").Length - 1];
            Console.WriteLine(path);
            if (FileExists(path))//Check if file exists in that path
            {//If true change the name and create the file
                Console.WriteLine("El archivo ya existe, renombrando y creando archivo nuevo");
                path = home + fileNames[result].Split(@"\")[fileNames[result].Split(@"\").Length - 1] + DateTime.Now.Day;
                Console.WriteLine("Bytes: " + bytesSB.Count);
                File.WriteAllBytes(path, bytesSB.ToArray());
            }
            else
            {//If false, create the file
                Console.WriteLine("El archivo no existe, creando archivo nuevo");
                Console.WriteLine("Bytes: " + bytesSB.Count);
                File.WriteAllBytes(path, bytesSB.ToArray());
            }/**/
            Pause();
        }
        public static void Pause()
        {
            do 
            { 
                Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); 
            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
        private static void ShowMenu(Dictionary<int, string> filesAviable)//Use the Dictionary to show which files can be created
        {
            foreach (var data in filesAviable)
            {
                Console.WriteLine(data.Key + "  " + data.Value/*data.ToString().Substring(1, data.ToString().Length - 2)*/);
            }
        }
        private static bool FileExists(string file)
        {//Checks if file exists
            if (File.Exists(file))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}