using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoFarmer
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isTest = true;
            bool isDebug = true;
            ///////////////////////////////////////////////////
            //AutoMouse autoMouse = new AutoMouse(50, 60);
            //AutoMouse.Execute();
            //Pause();
            ///////////////////////////////////////////////////

            /**/
            ///////////////////////////////////////////////////
            AutoKeys ak = new AutoKeys();
            Process[] processes = ak.GetRunningProcesses();
            Process teams = ak.IterateProcesses(processes, "Xavier");

            string message = "" + ConsoleKey.D + ":" + ((byte)ConsoleKey.D) + ConsoleKey.S + ":" + ((byte)ConsoleKey.S) + ConsoleKey.A + ":" + ((byte)ConsoleKey.A) + ConsoleKey.W + ":" + ((byte)ConsoleKey.W) + "From Console";//string.Empty;
            if (teams != null)
            {
                Console.WriteLine("\n");
                if (!isTest)
                    ak.Execute(teams, isDebug ? string.Empty : message);
                else
                    Console.WriteLine(message, isDebug ? string.Empty : message);
            }
            Console.WriteLine(ak.GetProcessInfo(teams));
            ///////////////////////////////////////////////////
            Pause();

        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}