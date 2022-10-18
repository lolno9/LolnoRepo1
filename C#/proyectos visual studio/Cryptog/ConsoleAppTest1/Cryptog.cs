using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace ConsoleAppTest1
{
    internal class Cryptog
    {
        public static void Main(string[] args)
        {
            //Creamos el objeto del Algoritmo AES
            SymmetricAlgorithm aes = Aes.Create("AesManaged");//new AesManaged()
            byte[] key = aes.Key;
            Console.WriteLine("Enter you message here to encrypt:");
            string message = Console.ReadLine();
            EncryptText(aes, message, "encryptedData.dat");
            readFiles();
            Console.WriteLine("Decrypted message: {0}", DecryptData(aes, "encryptedData.dat"));
            Console.ReadLine();
        }
        static void EncryptText(SymmetricAlgorithm aesAlgorithm, string text, string fileName)
        {
            ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor(aesAlgorithm.Key, aesAlgorithm.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(cs))
                    {
                        writer.Write(text);
                    }
                }
                byte[] encryptedDataBuffer = ms.ToArray();
                File.WriteAllBytes(fileName, encryptedDataBuffer);
            }
        }
        static string DecryptData(SymmetricAlgorithm aesAlgorithm, string fileName)
        {
            ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor(aesAlgorithm.Key, aesAlgorithm.IV);
            byte[] encryptedDataBuffer = File.ReadAllBytes(fileName);
            using (MemoryStream ms = new MemoryStream(encryptedDataBuffer))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cs))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
        static void readFiles()
        {
            string path = File.ReadAllText(@"C:\Users\amarin\source\repos\ConsoleAppTest1\ConsoleAppTest1\bin\Debug\net6.0\encryptedData.dat");
            Console.WriteLine(path);
        }
    }

}

