using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager2._0
{
    class PrintOuter
    {
        static int nextRow = 0;
        public void ShowMessage(string s, TextAlign textAlign=TextAlign.Left)
        {
            nextRow = Console.GetCursorPosition().Top;
            if (textAlign == TextAlign.Left)
            {
                Console.SetCursorPosition(0, nextRow++);
            }
            else if (textAlign == TextAlign.Centr)
            {
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, nextRow++);
            }
            else if (textAlign == TextAlign.Right)
            {
                Console.SetCursorPosition(Console.WindowWidth - s.Length, nextRow++);
            }
    
            Console.WriteLine(s);
        }
        public void ShowFolderFileList(DirectoryInfo[] dirs, FileInfo[] files)
        {

            if (dirs.Length==0 && files.Length == 0)
            {
                Console.WriteLine("<ПУСТО>");

            }
            else
            {
                Console.SetCursorPosition(0, 1);
                Console.Write("Name");
                Console.SetCursorPosition(Console.BufferWidth - "Atributes".Length - 15, 1);
                Console.Write("Atributes\n");
            }
            int i = 2;
            //if (dirs != null)
            //{
                PrintSome<DirectoryInfo>(dirs, ref i);          
            //}
            //if (files != null)
            //{
                PrintSome <FileInfo>(files, ref i);        
            //}
           
            Console.WriteLine();
            Console.WriteLine();
        }
        void PrintSome<T>(T[] t, ref int i) where T : FileSystemInfo
        {
            foreach (T f in t)
            {
                string s = new string('-', Console.BufferWidth - f.Name.Length - f.Attributes.ToString().Length - 15);
                Console.SetCursorPosition(0, i);
                Console.Write(f.Name);
                Console.SetCursorPosition(f.Name.Length + 1, i);
                Console.Write(s);
                Console.SetCursorPosition(Console.BufferWidth - f.Attributes.ToString().Length - 15, i);
                Console.Write(f.Attributes);
                i++;
            }
        }


        public void PrepareConsole(bool needAccept = false, bool clearConsoleBefoPrint = false)
        {
            if (needAccept)
            {
                Console.ReadLine();
            }
            if (clearConsoleBefoPrint)
            {
                Console.Clear();
                nextRow = 0;
            }


        }
    }
}
