using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary1
{
    public class DataProcess
    {
        private string dataToProcess;
        public string DataToProcess { get { return dataToProcess; } set { dataToProcess = value; } }
        //
        private List<byte> listOfBytes;
        public List<byte> ListOfBytes { get { return listOfBytes; } set { listOfBytes = value;  } }
        //
        private List<int> listOfInts;
        public List<int> ListOfInts { get { return listOfInts; } set { listOfInts = value; } }
        //
        private List<int> listOfNewInts;
        public List<int> ListOfNewInts { get { return listOfNewInts; } set { listOfNewInts = value; } }
        //
        private List<int> listOfRandUsed;
        public List<int> ListOfRandUsed{ get { return listOfRandUsed; } set { listOfRandUsed = value; } }
        //
        private Random randomNumberGenerator;
        //
        private int minRandom;
        public int MinRandom { get { return minRandom; } set { minRandom = value; } }
        //
        private int maxRandom;
        public int MaxRandom { get { return maxRandom; } set { maxRandom = value; } }
        public DataProcess() 
        {
            listOfBytes = new List<byte>();
            listOfInts = new List<int>();
            listOfNewInts = new List<int>();
            listOfRandUsed = new List<int>();
            randomNumberGenerator = new Random();
        }
        public DataProcess(string data)
        {
            listOfBytes = new List<byte>();
            listOfInts = new List<int>();
            listOfNewInts = new List<int>();
            listOfRandUsed = new List<int>();
            randomNumberGenerator = new Random();
            dataToProcess = data;
        }
        //

        public byte getByte(char c)
        {

            return Convert.ToByte(c);
        }
        public int getInt(char c)
        {
            return Convert.ToInt32(c);
        }
        public int getMixInt(char c, int i)
        {
            return (Convert.ToInt32(c) + i);
        }
        public void showList(List<object> list)
        {
            foreach(object item in list)
            {
                Console.Write(item + " ");
            }
        }
        public char[] splitData(string data)
        {
            return data.ToCharArray();
        }
        public void initRandom(int min, int max)
        {
            MinRandom = min;
            maxRandom = max;
        }
        public bool fillLists()
        {
            if (!String.IsNullOrWhiteSpace(dataToProcess))
            {
                Console.WriteLine("Error, no se a encontrado ningun dato para procesar");
                return false;
            } else
            {
                int cont = 0;
                int rand = randomNumberGenerator.Next(1, 20);
                foreach(char c in dataToProcess)
                {
                    if (cont == 0)
                        listOfRandUsed.Add(rand);
                    if(cont % 5 == 0)
                    {
                        rand = randomNumberGenerator.Next(0, 20);
                        listOfRandUsed.Add(rand);
                    }

                    listOfBytes.Add(Convert.ToByte(c));
                    listOfInts.Add(Convert.ToInt32(c));
                    listOfNewInts.Add(Convert.ToInt32(c) + rand);
                    
                }

                return true;
            }
        }
        // https://www.tutorialspoint.com/csharp/csharp_bitwise_operators.htm  https://derekwill.com/2015/03/05/bit-processing-in-c/
        public bool processData()
        {
            return true;
        }
    }
}
