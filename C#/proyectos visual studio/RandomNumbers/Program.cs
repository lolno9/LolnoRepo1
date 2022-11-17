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
namespace RandomNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            RandomNumbers rn = new RandomNumbers(256);
            rn.ShowContent(rn.NUMBERS);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(rn.ToString());
            Pause();

        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}