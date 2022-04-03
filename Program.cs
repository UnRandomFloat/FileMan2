using System;
using System.IO;

namespace FileManager2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WindowWidth = Console.LargestWindowWidth-25;
            Console.WindowHeight = Console.LargestWindowHeight-10;
            Console.SetWindowPosition(0, 0);
            MainWorkPlace mwp = new MainWorkPlace();
            mwp.LetsStartPoint();
        }
    }
}
