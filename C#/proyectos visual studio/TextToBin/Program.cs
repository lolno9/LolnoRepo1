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
/// Converor de texto a binario
namespace TextToBin
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            bool isText = true;
            bool textOrBin = true;
            int cont = 0;
            string input = string.Empty;
            string bins = string.Empty;
            string output = string.Empty;
            while (textOrBin)
            {
                Console.WriteLine("Text or Binary? (t or b)");
                string input1 = Console.ReadLine();
                if (input1.ToLower().Equals("t"))
                {
                    isText = true;
                } else if (input1.ToLower().Equals("b"))
                {
                    isText = false;
                }
                if (isText)
                {
                    while (check)
                    {
                        Console.WriteLine("Intoduce Texto: ");
                        input = Console.ReadLine();
                        GetBinaryRepresentation(input);
                        Console.WriteLine("TextToBin - Presiona Esc para salir");
                        check = EscapeLoop();
                        Console.WriteLine("\n");
                    }
                }
                else if (!isText)
                {
                    while (check)
                    {
                        Console.WriteLine("Intoduce Texto (8-P Bin): ");
                        input = Console.ReadLine();
                        bins = GetData(input);
                        GetTextRepresentation(bins);
                        Console.WriteLine("BinToText - Presiona Esc para salir");
                        check = EscapeLoop();
                        Console.WriteLine("\n");
                    }
                }
                Console.WriteLine("Text or Bin - Presiona Esc para salir");
                textOrBin = EscapeLoop();
                check = true;
            }
            Pause();
        }
        public static string GetData(string data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0, c = 1; i < data.Length; i++, c++)
            {
                if (c == 8)
                {
                    sb.Append(data[i] + ";");
                    c = 0;
                }
                else
                {
                    sb.Append(data[i]);
                }
            }
            return sb.ToString();
        }
        public static void GetTextRepresentation(string data)
        {
            string[] testeoFinal = data.Split(';');
            List<byte> lb = new List<byte>();
            foreach (string s in testeoFinal)
            {
                if (string.IsNullOrWhiteSpace(s)) { continue; }
                lb.Add(GetByteFromBin(s));
            }
            var ttt = lb.ToArray();
            Console.WriteLine(Encoding.UTF8.GetString(ttt));
        }
        public static string GetTextRepresentationRet(string data)
        {
            string[] testeoFinal = data.Split(';');
            List<byte> lb = new List<byte>();
            foreach (string s in testeoFinal)
            {
                if (string.IsNullOrWhiteSpace(s)) { continue; }
                lb.Add(GetByteFromBin(s));
            }
            var ttt = lb.ToArray();
            return Encoding.UTF8.GetString(ttt);
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
        public static string GetBinFromByte(byte bt)//Return a binary for a byte input
        {
            return Convert.ToString(bt, 2);
        }
        public static string Get8PBinFromByte(byte bt)//Returns 8-padded binary for a byte input
        {
            return GetBinFromByte(bt).PadLeft(8, '0');

        }
        public static bool EscapeLoop()
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return false;
            }
            return true;
        }
        public static void GetBinaryRepresentation(string data)
        {
            for(int i=0; i < data.Length; i++)
            {
                if(i == data.Length - 1)
                {
                    Console.Write(Get8PBinFromByte(Convert.ToByte(Convert.ToInt32(data[i]))) + "\n");
                }
                else
                {
                    Console.Write(Get8PBinFromByte(Convert.ToByte(Convert.ToInt32(data[i])))/* + "  "*/);
                }
            }
        }
        public static string GetBinaryRepresentationRet(string data)
        {
            string toReturn = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                if (i == data.Length - 1)
                {
                    toReturn +=(Get8PBinFromByte(Convert.ToByte(Convert.ToInt32(data[i]))) + "\n");
                }
                else
                {
                    toReturn +=(Get8PBinFromByte(Convert.ToByte(Convert.ToInt32(data[i]))));
                }
            }
            return toReturn;
        }
        public static byte GetByteFromBin(string singleBin)//Return a single byte from a single binary input
        {
            return Convert.ToByte(singleBin, 2);
        }
        public static byte[] GetBytesFromBins(string[] allBins)//Returns array of bytes from array of binarys
        {
            byte[] bins = new byte[allBins.Length];
            for (int i = 0; i < allBins.Length; i++)
            {
                bins[i] = GetByteFromBin(allBins[i]);
            }
            return bins;
        }
    }
}