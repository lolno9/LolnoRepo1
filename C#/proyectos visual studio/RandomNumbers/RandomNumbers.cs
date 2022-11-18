using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    public class RandomNumbers
    {
        private byte[] numbers { get; set; }
        public byte[] NUMBERS { get{ return numbers; } set { numbers = value; } }
        private Int32 counter { get; set; }

        private RandomNumberGenerator randomGenerator { get; set; }

        public RandomNumbers(int length) 
        {
            randomGenerator = RandomNumberGenerator.Create();
            numbers = new byte[length];
            counter = 0;
            FillNumbers();
        }
        public void FillNumbers()
        {
            randomGenerator.GetBytes(numbers);
        }
        public void ResetCounter()
        {
            counter = 0;
        }
        public long[] GetLongs(byte[] bytes)
        {
            long[] longs = new long[bytes.Length];
            for(int i=0; i<bytes.Length; i++)
            {
                longs[i] = bytes[i];
            }
            return longs;
        }
        //Show content methods
        public void ShowContent(byte[] array)//byte and int
        {
            foreach(var b in array)
            {
                Console.Write(b + " ");
            }
        }
        public void ShowContent(long[] array)//byte and int
        {
            foreach(var b in array)
            {
                Console.Write(b + " ");
            }
        }
        public Int16 GetInt16(byte[] bytes)
        {
            if(bytes.Length >= 2 && bytes.Length <= 8)
                return BitConverter.ToInt16(bytes);
            else
            {
                Console.WriteLine("GetInt16 - The array length is incorrect");
                return 0;
            }
        }
        public Int32 GetInt32(byte[] bytes)
        {
            if (bytes.Length >= 4 && bytes.Length <= 8)
                return BitConverter.ToInt32(bytes);
            else
            {
                Console.WriteLine("GetInt32 - The array length is incorrect");
                return 0;
            }
        }
        public Int64 GetInt64(byte[] bytes)
        {
            if (bytes.Length == 8)
                return BitConverter.ToInt64(bytes);
            else
            {
                Console.WriteLine("GetInt64 - The array length is incorrect");
                return 0;
            }
        }
        private void AddToCounter()
        {
            counter++;
        }
        public Int64 Next()
        {
            if(counter < numbers.Length)
            {
                AddToCounter();
                return numbers[counter-1];
            }
            else
            {
                Console.WriteLine("Index outside bounds of the array");
                return 0;
            }
        }
        public byte[] BreakIntoBytes(long longs)
        {                    
            return BitConverter.GetBytes(longs);
        }
        public override string ToString()
        {
            ResetCounter();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (long v in NUMBERS)//foreach(var v in test)
            {
                stringBuilder.Append("Byte: " + Next() + " \tInt64: " + v + " \t"); //Console.Write("Byte: " + rn.Next() + " \tInt64: " + v + " \t");
                Span<byte> tempArray = BreakIntoBytes(v); //BitConverter.GetBytes(v);
                for (int i = 0; i < tempArray.Length; i++)//foreach(var a in tempArray)
                {

                    if (i == tempArray.Length - 1)
                    {
                        stringBuilder.Append(tempArray[i]);//Console.Write(tempArray[i]);
                    }
                    else
                    {
                        stringBuilder.Append(tempArray[i] + ","); //Console.Write(tempArray[i] + ",");
                    }
                }
                stringBuilder.Append("\n"); //Console.Write("\n");
            }
            return stringBuilder.ToString();
        }
        /*
             //rn.ShowContent(test);
            //RandomNumbers rand16 = new RandomNumbers(2);
            //RandomNumbers rand32 = new RandomNumbers(4);
            //RandomNumbers rand64 = new RandomNumbers(8);
            //Console.WriteLine();
            //Console.WriteLine(Int64.MinValue + "  " + Int64.MaxValue);
            //Console.WriteLine();
            //Console.WriteLine(rn.GetInt16(rand16.NUMBERS));
            //Console.WriteLine(rn.GetInt32(rand32.NUMBERS));
            //Console.WriteLine(rn.GetInt64(rand64.NUMBERS));
          
         */
    }
}