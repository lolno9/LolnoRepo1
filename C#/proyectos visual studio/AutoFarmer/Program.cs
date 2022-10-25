using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoFarmer
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isTest = true; //True blocks message send, False lets message be sended
            bool isDebug = true; //True uses default message, False uses custom message
            bool TMouseFKeys = false; //True execute AutoMouse, False execute AutoKeys

            if(TMouseFKeys)
            {
                AutoMouse autoMouse = new AutoMouse(50, 60);
                AutoMouse.Execute();
                Pause();               
            }

            if (!TMouseFKeys)
            {
                string name = "Xavier"; //Name of the windows (part of the name at least) to search throught processes
                AutoKeys ak = new AutoKeys();
                Process[] processes = ak.GetRunningProcesses();
                Process teams = ak.IterateProcesses(processes, name);
                //Custom message
                string message = "" + ConsoleKey.D + ":" + ((byte)ConsoleKey.D) + ConsoleKey.S + ":" + ((byte)ConsoleKey.S) + ConsoleKey.A + ":" + ((byte)ConsoleKey.A) + ConsoleKey.W + ":" + ((byte)ConsoleKey.W) + "From Console";
                if (teams != null)
                {
                    Console.WriteLine("\n");
                    if (!isTest)
                        ak.Execute(teams, isDebug ? string.Empty : message);
                    else
                        Console.WriteLine(message, isDebug ? string.Empty : message);
                }
                Console.WriteLine(ak.GetProcessInfo(teams));
                Pause();
            }
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}