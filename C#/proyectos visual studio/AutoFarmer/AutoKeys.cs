using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoFarmer
{

    public class AutoKeys
    {
        //Import the the needed functions to work with windows
        [DllImport("User32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr hWnd);

        //Get all running processes
        public Process[] GetRunningProcesses()
        {
            return Process.GetProcesses();
        }
        //Iterate the processes array an look for a specific process
        public Process IterateProcesses(Process[] processes, string toCheck)
        {
            if (string.IsNullOrWhiteSpace(toCheck))
            {
                toCheck = "Studio";//Default value if toCheck comes null
            }
            foreach(Process process in processes)
            {
                if (process.MainWindowTitle.Contains(toCheck))
                {
                    Console.WriteLine("Process: " + process.ProcessName);
                    Console.WriteLine("Machine Name: " + process.MachineName);
                    Console.WriteLine("Main Window Title: " + process.MainWindowTitle);
                    Console.WriteLine("Process Id " + process.Id);
                    Console.WriteLine("Process Found");
                    Console.WriteLine("\n" + GetProcessInfo(process));
                    return process;
                }
            }
            return null;
        }
        //Send the Keys to the process
        public void Execute(Process process, string? message)//TODO Add Message on parameters
        {
            IntPtr intPtr = process.MainWindowHandle;
            SetForegroundWindow(intPtr);
            if(message != string.Empty)
            {
                SendKeys.SendWait(message+"\n");
            }
            else
            {
                SendKeys.SendWait("Testeo con AutoKeys como clase con metodos\n");
            }
        }
        public string GetProcessInfo(Process process)
        {
            return process.MainModule.FileVersionInfo.ToString();
        }
    }
}
