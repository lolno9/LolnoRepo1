using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestLibrary1
{
    public class Logs
    {
        static string fileName;
        static string text;
        static DateTime date;
        public Logs() { date = DateTime.Now; }
        public Logs(string file, string input)
        {
            fileName = file;
            text = input;
            date = DateTime.Now;
        }
        public void setText(string input)
        {
            text = input;
        }
        public void setFileName(string input)
        {
            fileName = input;
        }
        public DateTime getTime()
        {
            return date;
        }
        public string getTimeString()
        {
            return date.ToString();
        }
        public string getFormatedTimeString()
        {
            return date.ToString("d-MM-yyyy_HH-mm-ss");
        }
        private void CreateNewFileName()
        {
            setFileName("Log-" + getFormatedTimeString());
        }
        public string Message(string init, string message)
        {
            return init + ": " + message;
        }
        public void Trace(string init, string message, string path)
        {
            if (!File.Exists(path))
            {
                CreateNewFileName();
                File.WriteAllText(fileName, Message(init, message));
                Console.WriteLine("Trace: final del if is null");
            }
            if (File.Exists(path))
            {
                File.WriteAllText(path, Message(init, message));
                Console.WriteLine("Trace: final del if exists");
            }
        }

    }
}
