using System;
using System.Threading;
using System.IO;
using System.Text;//.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace TestLibrary1
{
    public class ByteTransform
    {
        public static void Execute(byte[] bytes)
        {//byte[] test = { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 0, 0, 1 };
            Console.Write("Original Bytes: ");
            PrintBytes(bytes);
            PrintBytesInfo(bytes);
            Pause();
            int[] ints = BytesToInt(bytes);
            byte[] modBytes = IntToBytes(ints);

            Console.Write("Modified Bytes: ");
            PrintBytes(modBytes);
            PrintBytesInfo(modBytes);
            Pause();
        }
        public static void PrintBytesInfo(byte[] bytes)
        {
            string utf8 = Encoding.UTF8.GetString(bytes);
            string ascii = Encoding.ASCII.GetString(bytes);
            string b64 = Convert.ToBase64String(bytes);
            Console.WriteLine("UTF8: " + utf8 + "\n" + "ASCII: " + ascii + "\n" + "B64: " + b64 + "\n\n");
        }
        private static byte[] IntToBytes(int[] ints)
        {
            byte[] toReturn = new byte[ints.Length];
            for (int i = 0; i < ints.Length; i++)
            {
                toReturn[i] = Convert.ToByte(ints[i]);
            }
            return toReturn;
        }
        private static int[] BytesToInt(byte[] bytes)//Transform the bytes
        {//TODO change the way it transforms the bytes
            int[] toReturn = new int[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                int x = bytes[i];
                //Console.Write("Original Byte: " + x + "  \t");
                if (x == 0)
                {
                    toReturn[i] = x + 7;
                }
                else if (x >= 249)
                {
                    toReturn[i] = x - 7;
                }
                else
                {
                    toReturn[i] = x + 7;
                }
                //Console.Write("Changed Byte: " + toReturn[i] + "\n");
            }
            return toReturn;
        }
        private static void PrintBytes(byte[] bytes)//Print all bytes inside the array
        {
            foreach (var b in bytes)
            {
                Console.Write(b + " ");
            }
            Console.WriteLine("\n");
        }
        private static void PrintInts(int[] ints)//Print all integers inside the array
        {
            foreach (var i in ints)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");
        }
        private static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}