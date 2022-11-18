using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    public class RNGNumbers
    {
        private byte[] data { get; set; }
        public byte[] DATA { get { return data; } set { data = value; } }
        private RandomNumberGenerator randomNumberGenerator { get; set; }
        private Int32 counter { get; set; }
        public RNGNumbers()
        {
            randomNumberGenerator = RandomNumberGenerator.Create();
            data = new byte[8];
            counter = 0;
            FillNumbers();
        }
        public RNGNumbers(Int32 length)
        {
            randomNumberGenerator = RandomNumberGenerator.Create();
            if (length < 8 || length % 8 != 0)
            {
                length = SetCorrectLength(length);
            }
            data = new byte[length];
            counter = 0;
            FillNumbers();
        }
        public Int64[] GetAllInts()
        {
            Int64[] ints = new Int64[data.Length/8];
            int intsCounter = 0;
            byte[] tempNum = new byte[8];
            for(int i=0, c=0; i<data.Length;i++, c++)
            {
                if (c == 8)
                {
                    ints[intsCounter] = BitConverter.ToInt64(tempNum, 0);
                    intsCounter++;
                    c = 0;
                }
                if(c < 8)
                {
                    tempNum[c] = data[i];
                }
            }
            return ints;
        }
        public Int64 GetInt64()
        {
            Int32 pointer = 0;
            if (data.Length <= 8)
            {
                byte[] tempBytes = new byte[8];
                Array.Copy(data, 0, tempBytes, pointer, 8);
                return BitConverter.ToInt64(tempBytes, 0);
            }
            else
            {
                while (pointer % 8 != 0)
                {
                    pointer--;
                }
                byte[] tempBytes = new byte[8];
                Array.Copy(data, 0, tempBytes, pointer, 8);
                return BitConverter.ToInt64(tempBytes.ToArray(), 0);
            }
        }
        private Int32 SetCorrectLength(Int32 length)
        {
            while (length % 8 != 0)
            {
                length++;
            }
            return length;
        }
        public void FillNumbers()
        {
            randomNumberGenerator.GetBytes(data);
        }
        public void ResetCounter()
        {
            counter = 0;
        }
        private void AddToCounter()
        {
            counter++;
        }
        public Int64 Next()
        {
            if (counter < data.Length)
            {
                AddToCounter();
                return data[counter - 1];
            }
            else
            {
                Console.WriteLine("Index outside bounds of the array");
                return 0;
            }
        }
    }
}
