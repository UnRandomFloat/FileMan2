using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager2._0
{
    class DeleteFolderFile : Comands
    {
        public DeleteFolderFile(string[] comArray, string currPath) : base(comArray, currPath)
        {

        }
        protected override string twoArgument()
        {
            string pathToDelete;
            bool folder=isFolder(sArray[1], out pathToDelete);
            if (currentPath == pathToDelete)
            {
                inf.ShowMessage($"Нельзя удалить текущую директорию!", TextAlign.Left);
                return currentPath;
            }
            if (folder && Directory.Exists(pathToDelete))
            {
                DirectoryInfo dirsAndFiles = new DirectoryInfo(pathToDelete);
                FileInfo[] fileArray = dirsAndFiles.GetFiles("", SearchOption.AllDirectories);
                foreach (FileInfo fsi in fileArray)
                {
                    File.SetAttributes(fsi.FullName, FileAttributes.Normal);
                }
                Directory.Delete(Path.GetFullPath(pathToDelete), true);
                inf.ShowMessage($"Директория {pathToDelete} успешно удалена", TextAlign.Left);
                return currentPath;
            }
            else if (!folder && File.Exists(pathToDelete))
            {
                File.SetAttributes(pathToDelete, FileAttributes.Normal);
                File.Delete(pathToDelete);
                inf.ShowMessage($"Файл {pathToDelete} успешно удален", TextAlign.Left);
                return currentPath;
            }
            return currentPath;
        }
    }
}
