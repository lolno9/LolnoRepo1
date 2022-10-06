///*
/// appendTextToFile can be overloaded with string or List<string> 
/// three ways of calling a constructor: 
///     FileManage fm = new FileManage(); (Empty)
///     FileManage fm = new FileManage("fileName"); (With file name)
///     FileManage fm = new FileManage("fileName", "creation"DateTime); (with file name and path of the file) (Use this one only for new file)
///     
/// Can input the path and file name manually (user input) or automatically (hardcoded),
/// Directory.GetCurrentDirectory() can be used instead if the same directory works 4 your needs
/// 
/// Usage: Call the constructor, set the file name and path, then call the "tryCreateNewFile" method, next use one of the "appendTextToFile" methods.
///


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TestLibrary1
{
    public class FileManage
    {
        private string fileName;
        public string FileName
        {
            get {return fileName; }
            set {fileName = value; }
        }
        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        private string creationDate;
        public string CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        private string modificationDate;
        public string ModificationDate
        {
            get { return modificationDate; }
            set { modificationDate = value; }
        }
        private string pathAndName;
        public string PathAndName
        {
            get { return pathAndName; }
            set { pathAndName = value; }
        }
        // Empty constructor (new or existing files)
        public FileManage() { }
        // Constructor with only file name (new or existing files)
        public FileManage(string file) { fileName = file; }
        //Constructor with file name and creation date (Use only for new files)
        public FileManage(string file, DateTime cDate) { fileName = file; creationDate = getFormatedTimeString(cDate); }
        
        // Check if file exist, if not, creates one
        public bool tryCreateNewFile()
        {
            setPathAndName(path);
            if (!File.Exists(pathAndName)) // if file not exist, create it and store creation date
            {
                var file = File.Create(pathAndName);
                CreationDate = getFormatedTimeString(DateTime.Now);
                file.Close();
                return File.Exists(pathAndName) ? true : false ;
            } 
            ModificationDate = getFormatedTimeString(DateTime.Now); // if file exists, store the modification date
            return File.Exists(pathAndName) ? true : false;
        }
        // Check if path string ends with "\" and concat it with existent/desired file name
        private void setPathAndName(string path)
        {
            if(path.Substring(path.Count()-1) != @"\")
            {
                path = path + @"\";
            }
            pathAndName = path + fileName;
        }
        // Format date to suitable string for file names
        public string getFormatedTimeString(DateTime date)
        {
            return date.ToString("dd/MM/yyyy_HH:mm:ss");
        }
        // Append text from a single string to a file
        public bool appendTextToFile(string textToAdd) 
        {
            try
            {
                StreamWriter test = File.AppendText(pathAndName);
                test.WriteLine(endLines());
                test.WriteLine((!string.IsNullOrEmpty(creationDate)) ? "Creation Date: " + creationDate : "Modification Date: " + modificationDate);
                test.WriteLine(endLines());
                test.WriteLine(textToAdd);
                test.WriteLine(endLines());
                test.Write("\n");
                test.Flush();
                test.Close();
                return true;
            } catch (Exception ex)
            {
                Logs l = new Logs();
                l.Trace("Append to file", ex.ToString(), Directory.GetCurrentDirectory());
                return false;
            }
        }
        // Append text from a List<string> to a file
        public bool appendTextToFile(List<string> textToAdd)
        {
            try
            {
                StreamWriter test = File.AppendText(pathAndName);
                test.WriteLine(endLines());
                test.WriteLine((!string.IsNullOrEmpty(creationDate)) ? "Creation Date: " + creationDate : "Modification Date: " + modificationDate);
                test.WriteLine(endLines());
                foreach (string text in textToAdd)
                {
                    test.WriteLine(text);
                }
                test.WriteLine(endLines());
                test.Write("\n");
                test.Flush();
                test.Close();
                return true;
            } catch(Exception ex)
            {
                Logs l = new Logs();
                l.Trace("Append to file", ex.ToString(), Directory.GetCurrentDirectory());
                return false;
            }
        }
        // String Used to start and end the writed data
        private string endLines()
        {
            return "----------------------------------------------------------------------------------------------------------------------------------";
        }
        // Set Manual file name
        public void setManualFileName()
        {
            do
            {
                fileName = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(fileName)/*test == null*/);
        }
        // Set Manual path to write or read files
        public void setManualPath()
        {
            do
            {
                path = Console.ReadLine();
            } while (!Directory.Exists(path));
        }
    }
}
