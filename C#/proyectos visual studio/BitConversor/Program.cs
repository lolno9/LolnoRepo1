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

namespace BitConversor
{
    internal class Program
    {
        static string home = Environment.GetEnvironmentVariable("HOMEDRIVE") + Environment.GetEnvironmentVariable("HOMEPATH") + @"\";
        static void Main(string[] args)
        {
            bool isDebug = false;
            string[] testIn = { "ByteConv.byc", (isDebug) ? @"C:\Users\amarin\Desktop\" : home/*@"C:\"*/ };//Default output
            string[] testOut = { "B64.csv", (isDebug) ? @"C:\Users\amarin\Desktop\" : home/*@"C:\"*/ };//Default input
            List<string> testList = new List<string>();//Input (if no custom input select default one)
            Console.Write("File to open: ");
            testList.Add(Console.ReadLine());//Read input file name
            Console.WriteLine(String.IsNullOrWhiteSpace(testList[0]) ? testIn[0] : testList[0]);//If custom input filename empty, set to default
            Console.Write("\nPath of the file: ");
            testList.Add(Console.ReadLine());//Read input file path
            Console.WriteLine(String.IsNullOrWhiteSpace(testList[1]) ? testIn[1] : testList[1]);//If custom input path empty, set to default
            Console.WriteLine(testList[0]);
            Console.WriteLine("\n\n");
            //Check if values inside list are empty strings or not
            if (testList.Count == 2)
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
            BitConversor bitConversor = new BitConversor(testIn[0], testOut[1]);
            bitConversor.SetFullPATH();//Concatenate the path in one string

            //Declare the lists thats gona be using
            List<string> rawData = new List<string>();//Processed data ready to put in a new/existing file
            Dictionary<int, string> filesAviable = new Dictionary<int, string>();//Headers, file names with paths
            Dictionary<int, string> filesData = new Dictionary<int, string>();//All data splited in lines
            string input = string.Empty;//testList[1] + testList[0] + "\n";//String used to concatenate data and put inside the new file

            Console.WriteLine("Reading lines of: " + testList[1] + testList[0]);
            Console.WriteLine("\n\n");

            if (File.Exists(testList[1] + testList[0]))//Check if file exists
            {
                input = File.ReadAllText(testList[1] + testList[0]);//Read all text from file
            }
            if(input != null)
            {
                foreach(string line in input.Split('\n'))//Split the lines
                {
                    
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        rawData.Add(line);//Add each individual line in a list
                    }
                }
            }
            for(int i = 0; i < rawData.Count; i++)//Put the index and path+filename in the dictionary
            {
                if(rawData[i].Contains(@"C:\"))
                {
                    filesAviable.Add(i, rawData[i].Substring(3));//Add the path+filename in a different dictionary
                    filesData.Add(i, rawData[i].Split('\\')[rawData[i].Split('\\').Length - 1]);
                }
                else 
                { 
                    filesData.Add(i, rawData[i]);//Add all data to a diferend dictionary
                }
            }
            if (filesAviable.Count > 0)
            {
                Console.Write("Choose 1 file to create: \n");
                ShowMenu(filesAviable);//Show the files and indexes we can choose
                bool check = true;//Used to break the while
                int result = 0;
                while (check)//Check if input is number and check if that number is in the dictionary
                {
                    var indexToCheck = Console.ReadLine();
                    if(indexToCheck.ToLower() == "n" || indexToCheck.ToLower() == "no")
                    {
                        return;
                    }
                    if (int.TryParse(indexToCheck, out result))//Check if input is number
                    {
                        result = int.Parse(indexToCheck);//if its a number, cast it as int to use in index search
                        foreach (int key in filesAviable.Keys)//Check if that number is in the dictionary
                        {
                            if (result == key)//if a result matches, set bool to false and break the foreach loop
                            {
                                Console.WriteLine("Match found for index: " + result);
                                check = false;
                                break;
                            }
                        }
                    }
                }
            
                Pause();
                string[] fileToCreate = GetDataOfFile(filesData, result);//Returns splited data of the individual file in 3 rows (Path+name, bytes and bits)
                if(fileToCreate.Length > 0)//If array has data then 
                {
                    Console.WriteLine("Has value");
                    CreateNewFile(fileToCreate);
                } else
                {
                    Console.WriteLine("Not has value");
                }
            }
            Pause();
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
        private static void ShowMenu(Dictionary<int,string> filesAviable)//Use the Dictionary to show which files can be created
        {
            foreach (var data in filesAviable)
            {
                Console.WriteLine(data.ToString().Substring(1, data.ToString().Length - 2));
            }
        }
        //Use the user input index and the dictionary with all the data to retrieve the info of the file
        private static string[] GetDataOfFile(Dictionary<int,string> filesAviable, int index)
        {
            int resultIndex = 0;
            string[] result = new string[3];
            foreach(var file in filesAviable)
            {
                if(file.Key == index)
                {
                    if (file.Key.ToString().Contains(@"C:\"))
                        result[resultIndex] = file.Value.Substring(3);
                    else
                        result[resultIndex] = file.Value;
                    index++;
                    resultIndex++;
                }
                if(resultIndex == 3)
                {
                    break;
                }
            }
            return result;
        }
        //fileInfo[0] = File Name | fileInfo[1] = byte;byte;...byte | fileInfo[2] = 0000110100001010 (concatenated 8-padded bits)
        private static void CreateNewFile(string[] fileInfo)
        {
            string name = fileInfo[0].Substring(3);
            DateTime today = DateTime.Now;
            if (File.Exists(/*fileInfo[0]*//*@"C:\"*/home + name))
            {
                bool check = true;
                string fileName = /*@"C:\"*/home + name + today.Day; ;
                while (check)
                {
                    if (File.Exists(fileName))
                    {
                        fileName = /*@"C:\"*/home + name + today.AddDays(1).Day;
                    } else
                    {
                        check = false;
                    }
                }

                Console.WriteLine("filename: " + fileName);
                WriteFile(fileInfo, fileName);
            } else
            {
                Console.WriteLine("name: "+ /*@"C:\"*/home + name);
                WriteFile(fileInfo, /*@"C:\"*/home + name/*fileInfo[0]*/);
            }
        }
        //Get the dictionary and fileName, add the bytes to a new list and use this list to create the copy of the file
        private static void WriteFile(string[] fileInfo, string fileName)
        {
            string[] tempArr = fileInfo[1].Split(';');
            List<byte> bytes = new List<byte>();
            
            for(int i = 0; i < tempArr.Length; i++)
            {
                if (byte.TryParse(tempArr[i], out byte b))
                {
                    bytes.Add(b);
                    //Console.Write(b + "  ");
                }
                //////////////////////////////////////////////////////
                ///This loop works for refreshing the progress line
                string consoleOut = i+1 + "/" + tempArr.Count() + " Bytes";
                Console.Write(consoleOut);
                foreach (char c in consoleOut)
                {
                    Console.Write("\b");
                }
                //////////////////////////////////////////////////////
            }
            if(bytes.Count > 0)
            {
                File.WriteAllBytes(fileName, bytes.ToArray());
            }
        }

    }
}