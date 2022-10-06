using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace TestLibrary1
{
    // Pause and some usefull functions here
    public class Library1
    {
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
        //Get Bytes from String
        public static byte[] UTF7StringToBytes(string toEncode)
        {
            return Encoding.UTF7.GetBytes(toEncode);
        }
        public static byte[] UTF8StringToBytes(string toEncode)
        {
            return Encoding.UTF8.GetBytes(toEncode);
        }
        public static byte[] UTF32StringToBytes(string toEncode)
        {
            return Encoding.UTF32.GetBytes(toEncode);
        }
        public static byte[] ASCIIStringToBytes(string toEncode)
        {
            return Encoding.ASCII.GetBytes(toEncode);
        }
        public static byte[] UNICODEStringToBytes(string toEncode)
        {
            return Encoding.Unicode.GetBytes(toEncode);
        }
        //Get String from Bytes
        public static string UTF7ByteToString(byte[] toDecode)
        {
            return Encoding.UTF7.GetString(toDecode);
        }
        public static string UTF8ByteToString(byte[] toDecode)
        {
            return Encoding.UTF8.GetString(toDecode);
        }
        public static string UTF32ByteToString(byte[] toDecode)
        {
            return Encoding.UTF32.GetString(toDecode);
        }
        public static string ASCIIByteToString(byte[] toDecode)
        {
            return Encoding.ASCII.GetString(toDecode);
        }
        public static string UNICODEByteToString(byte[] toDecode)
        {
            return Encoding.Unicode.GetString(toDecode);
        }
        //B64 D/Encode
        public static string B64Encode(byte[] toEncode)
        {
            return Convert.ToBase64String(toEncode);
        }
        public static byte[] B64Decode(string toDecode)
        {
            return Convert.FromBase64String(toDecode);
        }
    }
}
