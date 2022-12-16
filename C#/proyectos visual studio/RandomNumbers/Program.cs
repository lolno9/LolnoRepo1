using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace RandomNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            //RandomNumbers rn = new RandomNumbers(256);
            //rn.ShowContent(rn.NUMBERS);
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine(rn.ToString());

            RNGNumbers rng = new RNGNumbers(8,0,64);
            bool is64 = false;
            Int32 check = (rng.DATA.Length > 8) ? rng.DATA.Length / 8 : rng.DATA.Length;
            //Console.Write(rng.GetInt64());
            //int contador = 0;

            //for (int i = 0; i < rng.DATA.Length /*check*/; i++)
            //{
            //    //contador++;
            //    Console.Write(rng.Next() + " ");
            //    if (i % 8 == 0 && i >= 8 )
            //    {
            //        Console.WriteLine();
            //    }
            //}

            //Console.WriteLine("\n\n" + contador);
            if(rng.DATA.Length <= 8)
            {
                Int64 num = 0;
                if(is64)
                {
                    num = rng.GetInt64(0);
                    Console.WriteLine(num);
                }
                //
                if (!is64)
                {
                    num = rng.GetInt16(0, 64);
                    Console.WriteLine(num);
                }

                foreach (var v2 in BitConverter.GetBytes(num))
                {
                    Console.Write(v2 + " ");
                }
            } 
            if(rng.DATA.Length > 8)
            {
                var returned = rng.GetAllInts();
                var cont = 0;
                foreach (var v in returned)
                {
                    if (cont == 10)
                        Console.Write(v + "\n");
                    else
                        Console.Write(v + " \t");
                    foreach(var v2 in BitConverter.GetBytes(v))
                    {
                        Console.Write(v2 + " ");
                    }
                    Console.WriteLine();
                }
            }
            
            Pause();
            //Random r = new Random();
            //Console.WriteLine(r.NextInt64(Int64.MinValue, Int64.MaxValue));

            //Pause();
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}