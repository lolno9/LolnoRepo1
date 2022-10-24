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
using System.Diagnostics;

namespace AMAppTest // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            File.Create("testeo3.db3");
            DBConnector dbc = new DBConnector("testeo3.db3");
            dbc.CreateConnection();
            Console.WriteLine(dbc.CheckConnection() ? "Connection OK" : "Bad Connection");
            //dbc.CreateTable();
            //dbc.InsertData();
            Console.WriteLine(dbc.ReadData());
            dbc.SQLiteCloseConnection();
            /*Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Users\amarin\js\Py\dist\test\test.exe")
            {
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = false,
            };
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            Console.WriteLine(output);*/
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*string[] DefaultFile = { "test.jpg", @"C:\Users\amarin\Desktop\" };
            Console.WriteLine("Introducir nombre de archivo");
            string file = Console.ReadLine();
            Console.WriteLine("\nIntroducir ruta de archivo (en blanco default)");
            string path = Console.ReadLine();
            BitConversor bc;
            if (file == string.Empty)
                file = DefaultFile[0];
            if (path == string.Empty)
                path = DefaultFile[1];
            bc = new BitConversor(file, path);
            bc.Process();*/
            /*string PATH = @"C:\Users\amarin\Desktop\";
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine(PATH);
            Console.Write("Insert File Name: ");
            PATH += Console.ReadLine();
            Console.WriteLine(PATH);
            if (File.Exists(PATH))
            {
                Console.WriteLine("File: " + PATH + "\t Exists");
                var file = File.ReadAllBytes(PATH);
                byte btindx = 0;
                List<string> listBin = new List<string>();
                List<string> listLogs = new List<string>();
                string strBin = string.Empty, strAllBin = string.Empty, ereaser = string.Empty;
                int contador = 0;
                do
                {
                    btindx = file[contador];
                    string log2 = (contador + 1) + ";" + btindx + ";" + Convert.ToString(btindx, 2) + ";" + strBin.PadLeft(8, '0') + ";" + Convert.ToInt32(btindx) + ";" + Convert.ToChar(btindx) + ";";
                    string log = (contador + 1) + ":\t| Byte: " + btindx + "\t| Bin: " + Convert.ToString(btindx, 2) + "\t| 8-Padded Bin: " + strBin.PadLeft(8, '0') + "\tint: " + Convert.ToInt32(btindx) + "    \tASCII: " + Convert.ToChar(btindx);
                    strBin = Convert.ToString(btindx, 2);//Bin
                    strBin = strBin.PadLeft(8, '0');// 8-Padded Bin
                    strAllBin += strBin; //Concatenate 8-Padded Bin bytes
                    listBin.Add(strBin);
                    //Thread.Sleep(50);
                    Console.Write(log2);//Thread.Sleep(1000);
                    foreach (char c in log2)
                    {
                        ereaser += "\b";
                        //Console.Write("\b");
                    }
                    //Console.Write(ereaser);
                    listLogs.Add(log2);
                    Console.Write(ereaser);
                    contador++;
                } while (contador < file.Length);
                FileManage fm = new FileManage("LogByteToBin.log", @"C:\Users\amarin\Desktop\");
                listLogs.Add(fm.endLines());
                string b64file = Convert.ToBase64String(file);
                string test = Library1.UTF8ByteToString(file);
                Console.WriteLine("string data:\n" + test + "\nbytes count: " + file.Count() + " chars: " + test.Count());
                listLogs.Add("string data:\n" + test + "\nbytes count: " + file.Count() + " chars: " + test.Count());
                Console.WriteLine("B64 data:\n" + b64file + "\nbytes count: " + file.Count() + " b64 chars: " + b64file.Count());
                listLogs.Add("B64 data:\n" + b64file + "\nbytes count: " + file.Count() + " b64 chars: " + b64file.Count());
                Console.WriteLine("bit data:\n" + strAllBin + "\ncount: " + file.Count() + " bits: " + file.Count() * 8);
                listLogs.Add("bit data:\n" + strAllBin + "\ncount: " + file.Count() + " bits: " + file.Count() * 8);
                listLogs.Add(fm.endLines());
                Library1.Pause();
                string chk = string.Empty;
                foreach(string str in listBin)
                {
                    Console.Write(str + "   ");
                    chk += str + "   ";
                    
                }
                Console.Write("\nTotal of " + listBin.Count() * 8 + " bits");
                listLogs.Add(chk);
                listLogs.Add("Total of " + listBin.Count() * 8 + " bits");
                if (fm.tryCreateNewFile())
                    Console.WriteLine(fm.appendTextToFile(listLogs) ? "\nSuccess" : "\nError");
                else
                    Console.WriteLine("Can't create file");
                //fm.appendTextToFile(fm);
            }*/
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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