using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager2._0
{
    class CreateFolderFile : Comands
    {
        public CreateFolderFile(string[] comArray, string currPath) : base(comArray, currPath)
        { }

        protected override string twoArgument()
        {
            bool isDirectory = isFolder(sArray[1], out targetPath/*, true*/);
            if (isDirectory && isvalidPath(targetPath))
            {
                if (Directory.Exists(targetPath))
                {
                    inf.ShowMessage("Каталог с таким именем уже существует", TextAlign.Left);
                    return currentPath;
                }
                else
                {
                    Directory.CreateDirectory(targetPath);
                    inf.ShowMessage($"Каталог {targetPath} успешно создан");
                    return currentPath;
                }
            }
            else if(isvalidFilename(targetPath))
            {
                if (File.Exists(targetPath))
                {
                    inf.ShowMessage("Файл с таким именем уже существует", TextAlign.Left);
                    return currentPath;
                }
                else
                {
                    File.Create(targetPath);
                    inf.ShowMessage($"Каталог {targetPath} успешно создан");
                    return currentPath;
                }

            }

            return currentPath;
        }
    }
}
