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
using System.Runtime.InteropServices;

namespace ByteConversor
{
    internal class Program
    {
        static string home = Environment.GetEnvironmentVariable("HOMEDRIVE") + Environment.GetEnvironmentVariable("HOMEPATH") + @"\";
        static string inFile = "ByteConv.byc2";
        static string outFile = "BData.byc";
        static void Main(string[] args)
        {
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

            Console.WriteLine("\n" + home + inputFile);
            Console.WriteLine("\n\n");

            //Get the total bytes of the file
            int bytes = File.ReadAllBytes(inputPath + inputFile).Length;
            //Read the bytes of the file
            byte[] rawData = File.ReadAllBytes(inputPath + inputFile);
            //Create a Span of the byte[] data to use inside the loop
            var spanRawData = new Span<byte>(rawData);

            int contador = 1;
            //Create a Span to set the Console output while its inside the loop
            Span<char> outLine = ("/" + bytes + " Bytes").ToCharArray();
            //Set the bytes count to -1 to match with the true number of bytes (from [0] to [count-1] -> from [0] to [count])
            bytes--;
            //StringBuilder to get the 8-padded bits
            StringBuilder streamBit = new StringBuilder();
            //StringBuilder to get only the bytes
            StringBuilder streamByte = new StringBuilder();
            foreach (var b in spanRawData)
            {
                if (contador == bytes)
                {
                    streamByte.Append(b);//Fill StringBuilder bytes
                }
                else
                {
                    streamByte.Append(b + ";");//Fill StringBuilder bytes
                }
                streamBit.Append(Get8PBinFromByte(b));//Fill StringBuilder bits
                Console.Write(contador + outLine.ToString());//Show progress
                foreach (var s in contador + outLine.ToString())
                {
                    Console.Write("\b");//Maintain the progress in just 1 line
                }
                contador++;
            }

            //Write processed data in a file
            if (File.Exists(inputPath + outFile))
            {
                File.AppendAllText(home + outFile, inputPath + inputFile + "\n");
                File.AppendAllText(home + outFile, streamByte.ToString() + "\n");
                File.AppendAllText(home + outFile, streamBit.ToString() + "\n\n");
            }
            if (!File.Exists(inputPath + outFile))
            {
                File.WriteAllText(home + outFile, inputPath + inputFile + "\n");
                File.AppendAllText(home + outFile, streamByte.ToString() + "\n");
                File.AppendAllText(home + outFile, streamBit.ToString() + "\n\n");
            }

            Pause();
        }
        public static string Get8PBinFromByte(byte bt)//Returns 8-padded binary for a byte input
        {
            return GetBinFromByte(bt).PadLeft(8, '0');
        }
        public static string GetBinFromByte(byte bt)//Return a binary for a byte input
        {
            return Convert.ToString(bt, 2);
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}