using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ByteConversor
{
    public class BitConversor
    {
        //Attributes
        private string Path { get; set; }
        public string PATHGS { get {return Path; } set { Path = value;} }
        private string Name { get; set; }
        public string NAME { get {return Name;} set { Name = value;} }
        private string AllBinarys { get; set; }
        public string ALLBINARYS { get {return AllBinarys;} set { AllBinarys = value;} }
        private string B64Data { get; set; }
        public string B64DATA { get {return B64Data;} set { B64Data = value;} }
        private string Utf8Data { get; set; }
        public string UTF8DATA { get {return Utf8Data;} set { Utf8Data = value;} }

        //Constructors
        public BitConversor() { }
        public BitConversor(string name) { Name = name; }
        public BitConversor(string name, string pATHGS) { Name = name; Path = pATHGS; }
        private string[] DefaultFile = { "Log-ByteToBin.log", @"C:\Users\amarin\Desktop\" }; //OUTPUT
        public string[] DEFAULTFILE { get { return DefaultFile; } }

        //Methods
        public void SetFullPATH()//Concatenate path and name in the same string
        {//TODO valorate if is necessary put the console.read here or just set the full path
            //Console.WriteLine("1 - "+PATHGS);
            if (NAME == string.Empty)
            {
                Console.Write("Insert File Name: ");
                NAME = Console.ReadLine();
            }
            PATHGS += NAME;
            //Console.WriteLine("2 - " + PATHGS);
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
        public List<string> ConvertData(byte[] file)//Return a list with the data ready to put in a file Input: byte[] with file data
        {
            List<string> data = new List<string>();
            string processedData = string.Empty, toPrint = string.Empty, binaryString = string.Empty, binary8PString = string.Empty, allBinarys = string.Empty;
            for (int i=0; i<file.Length; i++)
            {
                binaryString = GetBinFromByte(file[i]);
                binary8PString = Get8PBinFromByte(file[i]);
                allBinarys += binary8PString; //AllBinarys
                toPrint = (i + 1) + ":\t| Byte: " + file[i] + "\t| Bin: " + binaryString + "\t| 8-Padded Bin: " + binary8PString + "\tInt: " + Convert.ToInt32(file[i]) + "\t| ASCII: " + Convert.ToChar(file[i]);
                processedData = (i + 1) + ";" + file[i] + ";" + binaryString + ";" + binary8PString + ";" + Convert.ToInt32(file[i]) + ";" + Convert.ToChar(file[i]) + ";";
                data.Add(processedData);
                Console.WriteLine(toPrint);
            }
            AllBinarys = "BIT Data:\n" + allBinarys + "\nBytes count: " + file.Count() + " bits: " + file.Count() * 8;
            B64Data = Convert.ToBase64String(file);
            B64Data = "Base64 Data:\n" + B64Data + "\nBytes count: " + file.Count() + " B64 chars: " + B64Data.Count();
            Utf8Data = Encoding.UTF8.GetString(file);
            Utf8Data = "UTF8 Data:\n" + Utf8Data + "\nBytes count: " + file.Count() + " chars: " + Utf8Data.Count();
            return data;
        }
        public string GetAllBins(List<string> listBin)//Print all binarys for a input list of bytes and returns a string with all binarys concatenated with 3 whitespaces
        {//TODO? change the separation of "   " to ';' ??
            string concatenateBins = string.Empty;
            string lastLine = "Total of " + listBin.Count() + " Bytes & " + listBin.Count() * 8 + " bits";
            for (int i=0, cont=0;i>listBin.Count();i++, cont++)
            {
                if(cont == 8)
                {
                    cont = 0;
                    Console.Write(listBin[i] + "\n");
                    concatenateBins += listBin[i] + "\n";
                } else
                {
                    Console.Write(listBin[i] + "   ");
                    concatenateBins += listBin[i] + "   ";
                }
                if(i == (listBin.Count()-1) && cont != 8)
                {
                    concatenateBins += "\n";
                }
            }
            concatenateBins += lastLine;
            return concatenateBins; //Use this return to write in a file instead of writing inside the method
        }
        public List<byte> GetAllBytes(string allBins)//Return a List<byte> of all bytes and Prints All bytes for input Binarys Input: Binaris concatenated in string format with ';' separation on right side
        {
            //string tst = "11111111;11011000;11111111;11100000;00000000;00010000;01001010;01000110;01001001;01000110;00000000;00000001;00000001;00000001;00000000;01100000;00000000;01100000;00000000;00000000;11111111;11011011;00000000;01000011;00000000;00001010;";
            string[] binaryArray = allBins.Split(';');
            List<byte> allBytes = new List<byte>();
            byte bt = 0;
            Console.WriteLine("Total bits: " + binaryArray.Length + "\n");
            for (int i = 0, cont = 0; i < binaryArray.Length; i++, cont++)
            {
                if (!string.IsNullOrWhiteSpace(binaryArray[i]))
                {
                    bt = Convert.ToByte(binaryArray[i], 2);
                    allBytes.Add(bt);
                    Console.Write((i + 1) + ": " + binaryArray[i] + " = " + bt);
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
            return allBytes;
        }
        /*public void Process()//If no values entered takes defalt values, read file and get all bytes as binarys, then creates a file with data
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
        }*/
    }
}
