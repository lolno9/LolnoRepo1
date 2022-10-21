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
        private string[] DefaultFile = { "Log-ByteToBin.log", @"C:\Users\amarin\Desktop\" }; //OUTPUT
        public string[] DEFAULTFILE { get { return DefaultFile; } }
        public void SetFullPATH()//Concatenate path and name in the same string
        {//TODO valorate if is necessary put the console.read here or just set the full path
            Console.WriteLine("1 - "+PATHGS);
            if (NAME == string.Empty)
            {
                Console.Write("Insert File Name: ");
                NAME = Console.ReadLine();
            }
            PATHGS += NAME;
            Console.WriteLine("2 - " + PATHGS);
        }
        public string GetBinFromByte(byte bt)//Return a binary for a byte input
        {
            return Convert.ToString(bt, 2);
        }
        public string Get8PBinFromByte(byte bt)//Returns 8-padded binary for a byte input
        {
            return GetBinFromByte(bt).PadLeft(8, '0');
        }
        public string[] GetBinsFromBytes(byte[] bts, bool is8Padded)//Returns array of Binarys for a byte array input
        {
            string[] bins = new string[bts.Length];
            for (int i = 0; i < bts.Length; i++)
            {
                bins[i] = is8Padded ? Get8PBinFromByte(bts[i]) : GetBinFromByte(bts[i]);
            }
            return bins;
        }
        public byte GetByteFromBin(string singleBin)//Return a single byte from a single binary input
        {
            return Convert.ToByte(singleBin, 2);
        }
        public byte[] GetBytesFromBins(string[] allBins)//Returns array of bytes from array of binarys
        {
            byte[] bins = new byte[allBins.Length];
            for (int i = 0; i < allBins.Length; i++)
            {
                bins[i] = GetByteFromBin(allBins[i]);
            }
            return bins;
        }
        public void SetDefaultValues()//If no values for name and/or path are entered do this steps
        {
            if (Name == string.Empty) // Default values if nothing entered
                Name = "test.jpg";//Console.ReadLine();
            if (Path == string.Empty)
                Path = @"C:\Users\amarin\Desktop\" + Name;
            SetFullPATH();
        }
        public void ReadFile(byte[] file, List<string> listBin, List<string> listLogs, string strBin, string strAllBin, FileManage fm)
        {//TODO Read file outside class, input result and do logic here
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
        public void GetAllBins(List<string> listBin, List<string> listLogs,FileManage fm)//Print all binarys for a input list of bytes
        {//TODO convert to a List<string> or string[] return method (do file write somewhere else), also just input a list/array of bins and create the other inside
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
        public void ShowAllBytes(string allBins)//Prints All bytes for input Binarys Input: Binaris concatenated in string format with ';' separation on right side
        {
            //string tst = "11111111;11011000;11111111;11100000;00000000;00010000;01001010;01000110;01001001;01000110;00000000;00000001;00000001;00000001;00000000;01100000;00000000;01100000;00000000;00000000;11111111;11011011;00000000;01000011;00000000;00001010;";
            string[] test = allBins.Split(';');
            Console.WriteLine("Total bits: " + test.Length + "\n");
            for (int i = 0, cont = 0; i < test.Length; i++, cont++)
            {
                if (!string.IsNullOrWhiteSpace(test[i]))
                {
                    Console.Write((i + 1) + ": " + test[i] + " = " + Convert.ToByte(test[i], 2));
                    if (cont == 8)
                    {
                        Console.Write("\n");
                        cont = 0;
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
            }
        }
        public void Process()//If no values entered takes defalt values, read file and get all bytes as binarys, then creates a file with data
        {//TODO take out file manage from this class, input the data from file and concatenate methods here (automated bit conversor call)
            if (Name == string.Empty || Path == string.Empty) // Default values if nothing entered
                SetDefaultValues(); 

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
