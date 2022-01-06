using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager2._0
{
    class CopyFolderFile : Comands
    {
        public CopyFolderFile(string[] comArray, string currPath) : base(comArray, currPath)
        {

        }
        protected override string twoArgument()
        {

            if (isFolder(sArray[1], out targetPath))
            {
                CopyDir(currentPath, targetPath);
                inf.ShowMessage($"Директория {currentPath} успешно скопированна в {targetPath}", TextAlign.Left);
                return currentPath;
            }
            else
            {
                if (!isvalidPath(targetPath))
                {
                    inf.ShowMessage($"Указан некорректный путь - {targetPath}", TextAlign.Left);
                }
                else
                {
                    inf.ShowMessage($"Указанный путь не является директорией - {targetPath}", TextAlign.Left);
                }
            }
            return currentPath;

        }
        protected override string threeArgument()
        {
            if (!sArray[2].PadLeft(3).Contains(@":\"))
            {
                inf.ShowMessage($"Путь назначения {sArray[2]} должен быть абсолютным!", TextAlign.Left);
                return currentPath;
            }
            string startPath = string.Empty;
            string destPath = string.Empty;
            bool firstPath = isFolder(sArray[1], out startPath);
            bool secondPath = isFolder(sArray[2], out destPath);



            if (firstPath && secondPath)
            {
                if (isvalidPath(startPath) && isvalidPath(destPath))
                {
                    CopyDir(startPath, destPath);
                    inf.ShowMessage($"Копирование {startPath} в {destPath} выполнено", TextAlign.Left);
                    return currentPath;
                }
                else if(!isvalidPath(destPath) || !isvalidFilename(destPath))
                {
                    inf.ShowMessage($"Копирование не удалось так как был введен некорректный путь - {destPath}", TextAlign.Left);
                    return currentPath;
                }
            }
            else if (!firstPath && secondPath)// копирование указанного файла в директорию(имя файла опущено)
            {
                if (!File.Exists(startPath) || !isvalidFilename(startPath))
                {
                    inf.ShowMessage($"Файл {startPath} не найден или название файла содержит недопустимые символы.", TextAlign.Left);
                    return currentPath;
                }

                Directory.CreateDirectory(destPath);
                File.Copy(startPath, Path.GetFullPath(destPath + "//" + Path.GetFileName(startPath)));
                inf.ShowMessage($"Копирование {startPath} в {destPath} выполнено", TextAlign.Left);
                return currentPath;
            }
            else if (!firstPath && !secondPath)// копирование указанного файла в директорию(имя файла опущено) 
            {
                if (!File.Exists(startPath)) //|| !isvalidFilename(startPath) ||isvalidFilename(destPath))
                {
                    inf.ShowMessage($"Файл {startPath} не найден", TextAlign.Left);
                    return currentPath;
                }
                else if (!isvalidFilename(Path.GetFileName(startPath)))
                {
                    inf.ShowMessage($"Некорректное имя файла - {startPath}", TextAlign.Left);
                    return currentPath;
                }
                else if (!isvalidFilename(Path.GetFileName(destPath)))
                {
                    inf.ShowMessage($"Некорректное имя файла - {destPath}", TextAlign.Left);
                    return currentPath;
                }
                Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                File.Copy(startPath, destPath);
                inf.ShowMessage($"Копирование {startPath} в {destPath} выполнено", TextAlign.Left);
                return currentPath;
            }
            inf.ShowMessage("Копирование неудалось проверьте правильност указания путей, \nубедитесь в корректности имени файла!", TextAlign.Left);
            return currentPath;
        }
        void CopyDir(string currPath, string targPath)
        {

            DirectoryInfo dir = new DirectoryInfo(currPath);
            DirectoryInfo[] dirs = dir.GetDirectories();
            string tempPath = Directory.CreateDirectory(Path.Combine(targPath)).FullName;
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {

                file.CopyTo(Path.Combine(tempPath, file.Name), true);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                tempPath = Path.Combine(targPath, subdir.Name);
                CopyDir(subdir.FullName, tempPath);
            }

        }
    }
}

