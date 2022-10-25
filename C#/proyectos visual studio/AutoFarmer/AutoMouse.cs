using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Runtime.CompilerServices;
// InteropServices and Drawing needed to use the methods and classes needed.
namespace AutoFarmer
{
    public class AutoMouse //X=1919 MAX | Y=1079 MAX
    {
        /// <summary>
        /// Attributes 
        /// DefaultPoint stores X and Y for actual position, DifX and DifY stores the
        /// diference between default (previous) and new position of mouse.
        /// </summary>
        private static int DifX { get; set; }
        public int DIFX { get { return DifX; } set {  DifX = value; } } //use this from another class to set or get from that class
        private static int DifY { get; set; }
        public int DIFY { get { return DifY; } set { DIFY = value; } } //use this from another class to set or get from that class
        private static int Contador { get; set; }

        //Constructor
        //Empty
        public AutoMouse() // Use DIFY &/or DIFX with this one
        {
            Contador = 0;
        } 
        //With Difs
        public AutoMouse(int difX, int difY)
        {
            DifX = difX;
            DifY = difY;
            Contador = 0;
        }

        //Imported methods: Without this wont work
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);//With the one down
        public static void SetCursorPosition(int x, int y) //This methods set the position of the mouse
        {
            SetCursorPos(x, y);
        }

        //This method retrieves the actual position of the mouse
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint); 
        
        //Returns actual position as {X: num & Y: num}
        public string PrintActualPosition(Point actualPoint)
        {
            return "X: " + actualPoint.X.ToString() + " & Y: " + actualPoint.Y.ToString();
        }
        
        public static void Execute()
        {
            Point DefaultPoint = new Point();
            do
            {
                if(GetCursorPos(ref DefaultPoint))//Get the actual position of mouse
                {
                    Console.Write("Default Position - ");
                    Console.WriteLine("Default X = " + DefaultPoint.X.ToString());
                    Console.WriteLine("Default Y = " + DefaultPoint.Y.ToString());
                }
                Thread.Sleep(2000); //Sleep 2 sec
                if (Contador % 2 == 0)//If Contador isPar sum to position
                {
                    SetCursorPosition(DefaultPoint.X + DifX, DefaultPoint.Y + DifY);
                }
                else//if not sustract
                {
                    SetCursorPosition(DefaultPoint.X - DifX, DefaultPoint.Y - DifY);
                }
                GetCursorPos(ref DefaultPoint);//Get new mouse position
                Console.WriteLine("Changed X = " + DefaultPoint.X.ToString());
                Console.WriteLine("Changed Y = " + DefaultPoint.Y.ToString());
                Contador++;
                if (Contador == 60) //Top count (if any)
                    break;
            } while (true);
        }
    }
}
