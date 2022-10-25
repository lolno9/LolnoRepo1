using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Testeo1
{
    public class Program 
    {
        static void Main(string[] args)
        {
            bool isDebug = false;
            ///////////////////////////////////////////////////
            //AutoMouse autoMouse = new AutoMouse(50, 60);
            //AutoMouse.Execute();
            //Pause();
            ///////////////////////////////////////////////////

            ///////////////////////////////////////////////////
            AutoKeys ak = new AutoKeys();
            Process[] processes = ak.GetRunningProcesses();
            Process teams = ak.IterateProcesses(processes, "Xavier");
            string message = "" + ConsoleKey.D + ":" + ((byte)ConsoleKey.D) + ConsoleKey.S + ":" + ((byte)ConsoleKey.S) + ConsoleKey.A + ":" + ((byte)ConsoleKey.A) + ConsoleKey.W + ":" + ((byte)ConsoleKey.W) + "From Console";//string.Empty;
            if (teams != null)
            {
                //if isDebug then send string.Empty, if isDebug is false send custom message
                ak.Execute(teams, isDebug ? string.Empty : message);
            }
            ///////////////////////////////////////////////////
            Pause();
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}