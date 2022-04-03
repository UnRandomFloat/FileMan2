using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager2._0
{
    class RenameFolderFile : Comands
    {
        public RenameFolderFile(string[] comArray, string currPath) : base(comArray, currPath)
        {

        }
        protected override string twoArgument()
        {
            string targetPath;
            if (isFolder(sArray[1], out targetPath, true) && !Directory.Exists(targetPath))
            {
                Directory.Move(currentPath, targetPath);
                inf.ShowMessage($"Директория {currentPath} переименована {targetPath}", TextAlign.Left);
                return targetPath;
            }
            else 
            {
                inf.ShowMessage("Указанный путь не является директорией! Или директория с таким именем уже существует", TextAlign.Left);
                Console.ReadLine();
                return currentPath;
            }
        }
        protected override string threeArgument()
        {
            string startPath;
            string targetPath;
            bool folder1 = isFolder(sArray[1], out startPath, true);
            bool folder2 = isFolder(sArray[2], out targetPath, true);
            if (folder1 && folder2 && Directory.Exists(startPath) && !Directory.Exists(targetPath))
            {
                Directory.Move(startPath, targetPath);
                inf.ShowMessage($"Директория {startPath} переименована {targetPath}", TextAlign.Left);
                inf.PrepareConsole(true, false);
                if (startPath != currentPath)
                {
                    return currentPath;
                }
                return targetPath;
            }
            else if (!folder1 && !folder2 && File.Exists(startPath) && !File.Exists(targetPath))
            {
                File.Move(startPath, targetPath);
                inf.ShowMessage($"Файл {startPath} переименован в {targetPath}", TextAlign.Left);
                inf.PrepareConsole(true, false);
                return currentPath;
            }
            else 
            {
                inf.ShowMessage("Введены некорректные пути.", TextAlign.Left);
                inf.PrepareConsole(true, false);
                return currentPath;
            }
         
        }


    }
}
