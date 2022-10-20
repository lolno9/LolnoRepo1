using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary1
{
    public class BitConversor
    {
        private string Path { get; set; }
        public string PATHGS { get {return Path; } set { Path = value;} }
        private string Name { get; set; }
        public string NAME { get {return Name;} set { Name = value;} }
        public BitConversor() { }
        public BitConversor(string name) { Name = name; }
        public BitConversor(string name, string pATHGS) { Name = name; Path = pATHGS; }
        private string[] DefaultFile = { "Log-ByteToBin.log", @"C:\Users\amarin\Desktop\" };
        public void SetFullPATH()
        {
            Console.WriteLine("1 - "+PATHGS);
            if (NAME == string.Empty)
            {
                Console.Write("Insert File Name: ");
                NAME = Console.ReadLine();
            }
            PATHGS += NAME;
            Console.WriteLine("2 - " + PATHGS);
        }
        public void ReadFile(byte[] file, List<string> listBin, List<string> listLogs, string strBin, string strAllBin, FileManage fm)
        {
            string ereaser = string.Empty;
            int contador = 0;
            byte btindx = 0;
            do
            {
                btindx = file[contador];
                string log2 = (contador + 1) + ";" + btindx + ";" + Convert.ToString(btindx, 2) + ";" + strBin.PadLeft(8, '0') + ";" + Convert.ToInt32(btindx) + ";" + Convert.ToChar(btindx) + ";";
                string log = (contador + 1) + ":\t| Byte: " + btindx + "\t| Bin: " + Convert.ToString(btindx, 2) + "\t| 8-Padded Bin: " + strBin.PadLeft(8, '0') + "\tint: " + Convert.ToInt32(btindx) + "    \tASCII: " + Convert.ToChar(btindx);
                strBin = Convert.ToString(btindx, 2);//Bin
                strBin = strBin.PadLeft(8, '0');// 8-Padded Bin
                strAllBin += strBin + ";"; //Concatenate 8-Padded Bin bytes
                listBin.Add(strBin);
                Console.Write(log2);
                foreach (char c in log2)
                {
                    Console.Write("\b");
                }
                listLogs.Add(log2);
                contador++;
            } while (contador < file.Length);

            listLogs.Add(fm.endLines());
            string b64file = Convert.ToBase64String(file);
            string test = Library1.UTF8ByteToString(file);
            Console.WriteLine("string data:\n" + test + "\nbytes count: " + file.Count() + " chars: " + test.Count());
            listLogs.Add("string data:\n" + test + "\nbytes count: " + file.Count() + " chars: " + test.Count());
            listLogs.Add(fm.endLines());
            Console.WriteLine("B64 data:\n" + b64file + "\nbytes count: " + file.Count() + " b64 chars: " + b64file.Count());
            listLogs.Add("B64 data:\n" + b64file + "\nbytes count: " + file.Count() + " b64 chars: " + b64file.Count());
            listLogs.Add(fm.endLines());
            Console.WriteLine("bit data:\n" + strAllBin + "\ncount: " + file.Count() + " bits: " + file.Count() * 8);
            listLogs.Add("bit data:\n" + strAllBin + "\ncount: " + file.Count() + " bits: " + file.Count() * 8);
            listLogs.Add(fm.endLines());
        }
        public void GetAllBins(List<string> listBin, List<string> listLogs,FileManage fm)
        {
            string chk = string.Empty;
            int cont = 0;
            foreach (string str in listBin)
            {
                if(cont == 8) 
                { 
                    cont = 0;
                    Console.Write(str + "\n");
                    chk += str + "\n";
                } else
                {
                    Console.Write(str + "   ");
                    chk += str + "   ";
                }
                cont++;
            }
            Console.Write("\nTotal of " + listBin.Count() * 8 + " bits");
            listLogs.Add(chk);
            listLogs.Add("Total of " + listBin.Count() * 8 + " bits");
            if (fm.tryCreateNewFile())
                Console.WriteLine(fm.appendTextToFile(listLogs) ? "\nSuccess" : "\nError");
            else
                Console.WriteLine("Can't create file");
        }
        public void Process()
        {
            if (Name == string.Empty)
            {
                Name = "test.jpg";//Console.ReadLine();
                Path = @"C:\Users\amarin\Desktop\"+Name;
                SetFullPATH();
            } else
            {
                SetFullPATH();
            }            
            Console.WriteLine("File: " + Path + "\t Exists");
            Library1.Pause();
            byte[] file = File.ReadAllBytes(Path);
            List<string> listBin = new List<string>();
            List<string> listLogs = new List<string>();
            string strBin = string.Empty, strAllBin = string.Empty;
            FileManage fm = new FileManage(DefaultFile[0], DefaultFile[1]);//"Log-ByteToBin.log", @"C:\Users\amarin\Desktop\"
            ReadFile(file, listBin, listLogs, strBin, strAllBin, fm);
            GetAllBins(listBin, listLogs, fm);
        }
    }
}
