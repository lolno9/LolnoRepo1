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
        private byte[] data { get; set; }//Array to fill with randm bytes
        public byte[] DATA { get { return data; } set { data = value; } }//Acces to array from other classes
        private RandomNumberGenerator randomNumberGenerator { get; set; }//Random generator
        private Int32 counter { get; set; }//Counter used to get Integers
        public RNGNumbers()//Empty constructor, sets array to 8 bytes and fills it
        {
            randomNumberGenerator = RandomNumberGenerator.Create();
            data = new byte[8];
            counter = 0;
            FillNumbers();//Fill array
        }
        public RNGNumbers(Int32 length)//Constructor with length, recieves the desired length for the array
        {
            randomNumberGenerator = RandomNumberGenerator.Create();
            if (length < 8 || length % 8 != 0)//If array length is less than 8 or not divisible by 8
            {
                length = SetCorrectLength(length);//Set correct length
            }
            data = new byte[length];
            counter = 0;
            FillNumbers();//Fill array
        }
        public RNGNumbers(Int32 length, Int32 min, Int32 max)//Constructor with length, recieves the desired length for the array
        {
            randomNumberGenerator = RandomNumberGenerator.Create();
            if (length < 8 || length % 8 != 0)//If array length is less than 8 or not divisible by 8
            {
                length = SetCorrectLength(length);//Set correct length
            }
            data = new byte[length];
            counter = 0;
            FillNumbers();//Fill array
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
        public Int64 GetInt64(Int32 count)//Retrieve a single Int64 number.
        {//TODO Recieve 8 bytes array or do it in another method?
            Int32 pointer = 0;
            if (count != 0)
                pointer = count;
            byte[] tempBytes = new byte[8];
            if (data.Length <= 8)
            {
                Array.Copy(data, 0, tempBytes, pointer, 8);
                return BitConverter.ToInt64(tempBytes, 0);
            }
            else
            {
                while (pointer % 8 != 0)
                {
                    pointer--;
                }
                Array.Copy(data, 0, tempBytes, pointer, 8);
                return BitConverter.ToInt64(tempBytes.ToArray(), 0);
            }
        }
        private Int32 SetCorrectLength(Int32 length)//Substract to length until reaches a number divisible by 8
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
        public Int16 GetInt16(Int32 min, Int32 max)
        {
            Int16 check = 0;
            bool isgood = false;
            //randomNumberGenerator.GetBytes(data);
            do
            {
                randomNumberGenerator.GetBytes(data);
                check = BitConverter.ToInt16(data, 0);
                if (check >= min && check <= max)
                    isgood = true;
            } while (!isgood);
            return check;
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
