using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager2._0
{
    abstract class Comands
    {

        protected PrintOuter inf = new PrintOuter();
        protected string[] sArray;
        protected string currentPath;
        protected string targetPath;
        //protected bool validPath;
        //protected bool validFilename;
        public Comands(string[] sArray, string currentPath)
        {
            this.currentPath = currentPath;
            this.sArray = sArray;
        }
        public Comands(string currentPath)
        {
            this.currentPath = currentPath;
        }
        public string Execute()
        {

            switch (sArray.Length)
            {
                case 1:
                    return oneArgument();
                case 2:
                    return twoArgument();
                case 3:
                    return threeArgument();
                case 4:
                    return fourArgument();
                case 5:
                    return fiveArgument();
                dafault:
                    inf.ShowMessage($"Неверное количество аргументов для команды ({sArray[0]})", TextAlign.Left);
                    break;
            }
            return null;

        }
        protected virtual string oneArgument()
        {
            inf.ShowMessage($"Неверное количество аргументов для команды ({sArray[0]})", TextAlign.Left);
            return null;
        }
        protected virtual string twoArgument()
        {
            inf.ShowMessage($"Неверное количество аргументов для команды ({sArray[0]})", TextAlign.Left);
            return null;
        }
        protected virtual string threeArgument()
        {
            inf.ShowMessage($"Неверное количество аргументов для команды ({sArray[0]})", TextAlign.Left);
            return null;
        }
        protected virtual string fourArgument()
        {
            inf.ShowMessage($"Неверное количество аргументов для команды ({sArray[0]})", TextAlign.Left);
            return null;
        }
        protected virtual string fiveArgument()
        {
            inf.ShowMessage($"Неверное количество аргументов для команды ({sArray[0]})", TextAlign.Left);
            return null;
        }
        protected virtual string sixArgument()
        {
            inf.ShowMessage($"Неверное количество аргументов для команды ({sArray[0]})", TextAlign.Left);
            return null;
        }
        protected bool isFolder(string s, out string finalPath, bool chekAbsolute = false)
        {
            if (chekAbsolute)
            {
                if (!s.PadLeft(3).Contains(@":\") || s.Length <= 3)
                {
                    inf.ShowMessage($"Путь назначения -{s}- должен быть абсолютным!", TextAlign.Left);
                    finalPath = currentPath;
                    return false;
                }
            }
            string mabyPath;
            bool folder = false;
            if (!s.PadLeft(3).Contains(@":\"))
            {
                mabyPath = Path.GetFullPath(currentPath + "//" + s);
            }
            else
            {
                mabyPath = Path.GetFullPath(s);
            }
            string FileName = Path.GetFileName(mabyPath);
            string FileNam = Path.GetFileNameWithoutExtension(mabyPath);
            if (FileName == FileNam)
            {
                mabyPath += "//";
                folder = true;
            }
            finalPath = Path.GetFullPath(mabyPath);
            return folder;
        }

        protected bool isvalidFilename(string s)
        {
            char[] wrongSymbols = Path.GetInvalidFileNameChars();
            foreach  (char c in wrongSymbols)
            {
                if (s.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        protected bool isvalidPath(string s)
        {
            char[] wrongSymbols = Path.GetInvalidPathChars();
            foreach (char c in wrongSymbols)
            {
              
                if (s.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
