using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RNGNumbers
    {
        private byte[] data { get; set; }//Array to fill with randm bytes
        public byte[] DATA { get { return data; } set { data = value; } }//Acces to array from other classes
        private RandomNumberGenerator randomNumberGenerator { get; set; }//Random generator
        private Int32 counter { get; set; }//Counter used to get Integers
        public RNGNumbers()//Empty constructor, sets array to 8 bytes and fills it
        {
            randomNumberGenerator = RandomNumberGenerator.Create();
            data = new byte[100];
            counter = 0;
            FillBytes();//Fill array
        }
        public void FillBytes()
        {
            randomNumberGenerator.GetBytes(data);
        }
        private Int16 GetInt16(Int32 min, Int32 max)
        {
            Int16 check = 0;
            bool isgood = false;
            do
            {
                try
                {
                    check = BitConverter.ToInt16(DATA, counter/*0*/);
                } catch (Exception ex){}
                if (check >= min && check <= max)
                    isgood = true;
                else
                    AddToCounter();
                if (counter == data.Length)
                {
                    ResetCounter();
                    FillBytes();
                }
            } while (!isgood);
            return check;
        }
        public void ResetCounter()
        {
            counter = 0;
        }
        private void AddToCounter()
        {
            counter += 2;
        }
        public Int16 Next(Int32 min, Int32 max)
        {
            if (counter < data.Length)
            {
                AddToCounter();
                return GetInt16(min, max);
            }
            else
            {
                Console.WriteLine("Index outside bounds of the array");
                return 0;
            }
        }
    }
}
