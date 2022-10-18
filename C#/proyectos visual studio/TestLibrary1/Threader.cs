using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary1
{
    public class Threader
    {
        public static void MultiSimple()
        {
            ///*
            ///ThreadStart ts = new ThreadStart(Testeo);
            ///Thread t = new Thread(Testeo);
            ///
            int cont = 0;
            string usage = "";
            do
            {
                usage = "Worker Thread: " + cont;
                Console.Write(usage);
                Thread.Sleep(1000);
                cont++;
                foreach (char c in usage)
                {
                    Console.Write("\b");
                }
            } while (cont <= 10);
            Console.WriteLine();
        }
        public static void MultiParam(object txt)
        {
            ///*
            ///ParameterizedThreadStart pts = new ParameterizedThreadStart(TesteoParam);
            ///Thread t2 = new Thread(TesteoParam);
            ///t2.Start("Parametro con valor - Main Thread: ");
            ///
            string usage = "";
            int cont = 0;
            do
            {
                usage = (txt.GetType().ToString().Contains("String")) ? txt.ToString() + cont : "Parametro sin valor - Main Thread: " + cont;
                Console.Write(usage);
                Thread.Sleep(500);
                cont++;
                foreach (char c in usage)
                {
                    Console.Write("\b");
                }
            } while (cont <= 10);
            Console.WriteLine();
        }
    }
}
