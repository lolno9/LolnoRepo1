using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows;

namespace Testeo1
{
    public class Program 
    {
        static void Main(string[] args)
        {
            //AutoMouse autoMouse = new AutoMouse(50, 60);
            //AutoMouse.Execute();
            //Pause();
            [DllImport("User32.dll")]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [DllImport("User32.dll")]
            static extern int SetForegroundWindow(IntPtr hWnd);


            IntPtr ptrFF = FindWindow(null,"Microsoft Teams");
            SetForegroundWindow(ptrFF);
            

            Console.WriteLine(""+ConsoleKey.D + ConsoleKey.S + ConsoleKey.A + ConsoleKey.W);

            if (Console.ReadKey().Equals(ConsoleKey.LeftWindows))
            {
                Console.WriteLine("Tecla windows izquierda pulsada");
            }

            if (Console.ReadKey().Equals(ConsoleKey.RightWindows))
            {
                Console.WriteLine("Tecla windows derecha pulsada");
            }
            Pause();
            
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }

    }
}