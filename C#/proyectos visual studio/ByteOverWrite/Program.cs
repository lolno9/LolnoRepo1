using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Text.RegularExpressions;

public class Program
{
    const int MIN = 1;
    const int MAX = 99;
    const string PATH = @"C:\Users\amarin\Desktop\Entorno de prueba\JS.txt";
    public static void Main(string[] args)
    {
        //int[] test = { 67, 58, 92, 85, 115, 101, 114, 115, 92, 97, 109, 97, 114, 105, 110, 92, 70, 105, 99, 104, 97, 46, 100, 111, 99, 120, 10, 56, 48, 59, 55, 53, 59, 51, 59, 52, 59, 50, 48, 59, 48, 59, 54, 59, 48, 59, 56, 59, 48, 59, 49, 56, 54, 59, 55, 56, 59, 51, 52, 59, 56, 53, 59, 49, 55, 59, 51, 57, 59, 49, 56, 57, 59, 49, 49, 52, 59, 49, 56, 57, 59, 49, 59, 48, 59, 48, 59, 49, 54, 57, 59, 49, 50, 59, 48, 59, 48, 59, 49, 57, 59, 48, 59, 56, 59, 50, 59, 57, 49, 59, 54, 55, 59, 49, 49, 49, 59, 49, 49, 48, 59, 49, 49, 54, 59, 49, 48, 49, 59, 49, 49, 48, 59, 49, 49, 54, 59, 57, 53, 59, 56, 52, 59, 49, 50, 49, 59, 49, 49, 50, 59, 49, 48, 49, 59, 49, 49, 53, 59, 57, 51, 59, 52, 54, 59, 49, 50, 48, 59, 49, 48, 57, 59, 49, 48, 56, 59, 51, 50, 59, 49, 54, 50, 59, 52, 59, 50, 59, 52, 48, 59, 49, 54, 48, 59, 48, 59, 50, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48, 59, 48 };
        //Console.WriteLine("Texto: \n");
        string userInput = Console.ReadLine();//Get user input
        if (!File.Exists(userInput))
        {
            return;
        }
        string input = File.ReadAllText(/*PATH*/userInput);//File input
        if (String.IsNullOrWhiteSpace(input))
            return;
        while(input.Length % 8 != 0)//If user input is not divisible by 8 padd 0's to de left
        {
            input = 0 + input; //Keep adding 0 to the left until suitable length is reached
        }
        
        List<int> list = new List<int>();//Declare a new list of int's
        foreach (byte b in input)
        {
            list.Add(b);//Fill the list
        }
        //foreach(byte b in list)
        //{
        //    Console.Write(b + "  ");//Show list content
        //}
        int[] test = list.ToArray();//Declare a new array with data in list
        list.Clear();//Clear the list beacouse we are using it again
        //Pause();
        Random r = new Random();//Declare a new random number generator we gonna use to process bytes
        bool check = true;//Boolean to check the first while loop
        int randInt = r.Next(MIN, MAX);//Variable used to store temp random int
        List<int> listRands = new List<int>();//Declare a new list to put the randoms used
        Console.WriteLine("Original Bytes Length = " + test.Length);//Show Length of the original bytes (length still be the same after process)
        while (check)//First While
        {
            var loop = true;//Boolean to check the second while	loop		
            for (int i = 0, c = 1; i < test.Length; i++, c++)//Iterate the integer array
            {
                loop = true;//Put here so we can restart the while loop if for is active
                while (loop)//Second While
                {
                    if (c == 8)
                    {
                        randInt = r.Next(MIN, MAX);//Get a new random
                        if (test[i] + randInt > 0 && test[i] + randInt < 255)//Check if we can use it
                        {
                            list.Add(test[i] + randInt);//Add new byte as int in the list
                            listRands.Add(randInt);//Add the rand used for this byte
                            loop = false;//Break the second while
                            c = 0;
                        }
                    }
                    else
                    {
                        if (test[i] + randInt > 0 && test[i] + randInt < 255)//Check if we can use it
                        {
                            list.Add(test[i] + randInt);//Calculate and add new byte as int in the list
                            loop = false;//Break the second loop so we can keep processing bytes
                        }
                    }
                }
                if (i == test.Length - 1)//If we reach the end of the original array, break the first while loop
                {
                    check = false;
                }
                //Show progress
                Console.Write(i+"/"+test.Length);
                foreach(var v in i + "/" + test.Length)
                {
                    Console.Write("\b");
                }
            }
        }
        //Show length of the lists
        Console.WriteLine("\n\nBytes final length = " + list.Count() + "\nRands final length = " + listRands.Count());
        Console.WriteLine(test.Length);
        //Pause();
        CheckArrays(test, list.ToArray(), listRands.ToArray());//Check if array has or not same values in same position
        byte[] output = IntToBytes(list.ToArray());//Convert the int's to bytes and return an array
        //foreach(byte b in output) { Console.Write(b); }
        var file = userInput.Split(@"\")[userInput.Split(@"\").Length - 1];//Get file name
        //Console.WriteLine(/*file*/listRands.ToString());
        if(!File.Exists(@"C:\Users\amarin\Desktop\" + file + ".enc"))//Check if new file already exists
            File.WriteAllBytes(@"C:\Users\amarin\Desktop\" + file + ".enc", output);//Write the new file
        List<string> randsOut = new List<string>();
        foreach(int i in listRands) { randsOut.Add(i.ToString()); }
        if(!File.Exists(@"C:\Users\amarin\Desktop\" + file + ".rnd"))//Check if new file already exists
            File.WriteAllLines(@"C:\Users\amarin\Desktop\" + file + ".rnd", randsOut.ToArray());//Write file with rands used
        Pause();
    }
    //Convert array of int's to array of bytes
    private static byte[] IntToBytes(int[] ints)
    {
        byte[] toReturn = new byte[ints.Length];
        for (int i = 0; i < ints.Length; i++)
        {
            toReturn[i] = Convert.ToByte(ints[i]);
        }
        return toReturn;
    }
    public static void Pause()
    {
        do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
    }
    //Check contents of 2 arrays to see if there are coincidences
    public static void CheckArrays(int[] test1, int[] test2, int[] rands)
    {
        int count = 0;
        int count2 = 0;
        for(int i=0, c=1; i<test1.Length; i++, c++)
        {
            if (i == test1.Length)
            {
                if(c != 8)
                {

                }
                break;
            }
            //If not equal
            if(test1[i] != test2[i])
            {
                Console.WriteLine(test1[i] + "\t no es igual a \t" + test2[i] + "\t con rand: \t" + rands[count2]);
                count++;
            } else//If equal
            {
                Console.WriteLine(test1[i] + "\t es igual a \t" + test2[i] + "\t con rand: \t" + rands[count2]);
            }
            if (c == 8)
            {
                c = 0;
                count2++;
            }
        }
        Console.WriteLine("Total diferent bytes: " + count);
    }
}