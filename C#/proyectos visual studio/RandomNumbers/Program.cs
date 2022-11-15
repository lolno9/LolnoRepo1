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
namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Declare de array with desired length
            byte[] test = new byte[256];
            //Declare de RNG
            var rng = RandomNumberGenerator.Create();
            //Get our first 256 Random bytes
            rng.GetBytes(test);
            
            //Show bytes
            foreach(var v in test)
            {
                Console.Write(v);
            }
            Console.WriteLine("\nTotal length = " + test.Length + "\n");
            //Get B64 string from bytes
            Console.WriteLine("\n\n"+Convert.ToBase64String(test));
            Console.WriteLine("\n\n");

            //Convert byte to char
            foreach(byte b in test)
            {
                Console.Write(Convert.ToChar(b));
            }
            Pause();
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}