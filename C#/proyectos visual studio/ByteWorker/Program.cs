using System;
using System.Threading;
using System.IO;
using System.Text;//.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public class Program
{//Define paths to the Byte and Bit apps, he name of the app and the version
    const string byteConversorPath = @"C:\Users\amarin\js\LolnoRepo1\C#\ByteWorker\ByteConversor\ByteConversorV0.0.3\ByteConversor.exe";
    const string bitConversorPath = @"C:\Users\amarin\js\LolnoRepo1\C#\ByteWorker\BitConversor\BitConversorV0.0.3\BitConversor.exe";
    const string name = "ByteWorker";
    const string version = "V.0.0.1";
    public static void Main(string[] args)
    {
        Menu();
        Pause();
    }
    private static void Pause()
    {
        do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
    }
    private static void Menu()
    {
        int menuChoice = 0;
        bool inMenu = true;
        while (inMenu)
        {
            CreateMenu();
            var choice = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(choice))
                menuChoice = int.Parse(choice);
            else
                continue;
            if(menuChoice == 1)
            {
                Console.WriteLine("Open ByteConversorV0.0.3");
                Console.Clear();
                var process = new System.Diagnostics.Process {
                    StartInfo = new System.Diagnostics.ProcessStartInfo {
                        FileName = byteConversorPath 
                    } 
                };
                process.Start();
                process.WaitForExit();
            }
            if (menuChoice == 2)
            {
                Console.WriteLine("Open BitConversorV0.0.3");
                Console.Clear();
                var process = new System.Diagnostics.Process { 
                    StartInfo = new System.Diagnostics.ProcessStartInfo {
                        FileName = bitConversorPath 
                    } 
                };
                process.Start();
                process.WaitForExit();
            }
            if(menuChoice == 9)
            {
                inMenu = false;
            }
        }
    }
    private static void CreateMenu()
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        Console.WriteLine(name+version);
        Separation();
        Console.WriteLine("\n");
        Console.WriteLine(" 1 - \t ByteConversorV0.0.3");
        Console.WriteLine(" 2 - \t BitConversorV0.0.3");
        Console.WriteLine(" 9 - \t Exit");
        Separation();
        Separation();
        Console.WriteLine("\n\nChoose an option: ");
    }
    private static void Separation()
    {
        foreach (char c in byteConversorPath)
        {
            Console.Write("-");
        }
    }
}