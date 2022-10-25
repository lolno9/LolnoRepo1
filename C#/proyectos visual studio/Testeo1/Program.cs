using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Testeo1
{
    public class Program 
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////
            //AutoMouse autoMouse = new AutoMouse(50, 60);
            //AutoMouse.Execute();
            //Pause();
            ///////////////////////////////////////////////////
            [DllImport("User32.dll")]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [DllImport("User32.dll")]
            static extern int SetForegroundWindow(IntPtr hWnd);
            Process[] p = Process.GetProcesses();
            int cont = 0;
            Process toWork;
            foreach (Process proc in p)
            {
                if (proc.ProcessName.Contains("eams"))
                {
                    Console.WriteLine("Process found: " + proc.ProcessName);
                    Console.WriteLine("Machine Name: " + proc.MachineName);
                    Console.WriteLine("Main Window Title: " + proc.MainWindowTitle);
                    Console.WriteLine("Process Id " + proc.Id);
                    if (proc.MainWindowTitle.Contains("Consultores"))
                    {
                        cont = proc.Id;
                        Console.WriteLine("ID get");
                        break;
                    }
                }
            }
            Pause();
            toWork = Process.GetProcessById(cont);
            IntPtr ptrFF = toWork.MainWindowHandle;
            SetForegroundWindow(ptrFF);
            SendKeys.SendWait("" + ConsoleKey.D+":"+((byte)ConsoleKey.D) + ConsoleKey.S + ":" + ((byte)ConsoleKey.S) + ConsoleKey.A + ":" + ((byte)ConsoleKey.A) + ConsoleKey.W + ":" + ((byte)ConsoleKey.W) + "From Console"+"\n");
            Pause();
        }
        public static void Pause()
        {
            do { Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\tPress SpaceBar to Exit"); } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}