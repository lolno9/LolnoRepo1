using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestLibrary1;
using System.Threading;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace AMAppTest // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {

            /*string str = "main";
            Program p = new Program();

            ThreadStart ts = new ThreadStart(Threader.MultiSimple);
            Thread t = new Thread(ts);

            ParameterizedThreadStart pts = new ParameterizedThreadStart(Threader.MultiParam);
            Thread t2 = new Thread(pts);
            t2.Start("Parametro con valor - Main Thread: ");
            Thread.Sleep(6000);
            t.Start();
            do
            {
                Thread.Sleep(1000);
            } while (t.IsAlive);*/

            //
            //DataProcess process = new DataProcess();

            /*string prueba = "Hello World!" + "\n" + "ASCII B64:\t" + Library1.B64Encode(Library1.ASCIIStringToBytes("Hello World!"));
            List<string> pruebaList = new List<string>{"hola","adios","qwe","egdw","dfba" };
            Console.WriteLine(prueba);
            Console.WriteLine("Introduce el Nombre del Archivo:");
            FileManage fm = new FileManage();
            //FileManage fm = new FileManage("testeo1");//"testeo1"
            if(String.IsNullOrWhiteSpace(fm.FileName))
                fm.setManualFileName();
            Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory());
            if(String.IsNullOrWhiteSpace(fm.Path))
                fm.setManualPath();
            Console.WriteLine(fm.tryCreateNewFile());
            Console.WriteLine(fm.appendTextToFile(prueba));
            Console.WriteLine(fm.appendTextToFile(pruebaList));*/

            Library1.Pause();

            /*Library1.Pause();*/

            //Logs test1 = new Logs("md1.txt", prueba);
            //Console.WriteLine(test1.Message("Message From Logs Library", prueba));
            //test1.Trace("prueba1 Trace", prueba, Directory.GetCurrentDirectory());
            //Console.WriteLine("Hello World!");
            //Console.WriteLine(Library1.B64Encode(Library1.ASCIIStringToBytes("Hello World!")));
            /* try
             {
                 if (!File.Exists("test.txt"))
                 {
                     File.Create("test.txt");
                     Console.WriteLine("False");
                 } else
                 {
                     File.WriteAllText("test.txt", prueba);
                     Console.WriteLine("True");
                 }

             } catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
             */
            //Console.WriteLine(Directory.GetCurrentDirectory());
        }
        
    }
}