using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2._0
{
    sealed class WhatSizeFolderFile :Comands
    {
        public WhatSizeFolderFile(string[] comArray, string currPath) : base(comArray, currPath)
        {

        } 
        protected override string twoArgument()
        {
            bool isDirectory = isFolder(sArray[1], out targetPath/*, true*/);
            if (isDirectory && Directory.Exists(targetPath))
            {
                DirectoryInfo dir = new DirectoryInfo(targetPath);
                double i = Convert.ToDouble((dir.GetFiles().Sum(fi => fi.Length) +
         dir.GetDirectories().Sum(di => DirSize(di)))/1024);
                Console.WriteLine("   размер - " + i + " kB");
                return currentPath;
            }
            else if(File.Exists(targetPath))
            {
                FileInfo fi = new FileInfo(targetPath);
                int i = Convert.ToInt32(fi.Length) / 1024;
                Console.Write("   размер - "+i+" kB");
                return currentPath;
            }
            double DirSize(DirectoryInfo d)
            {
                double size = 0;
               
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
          
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di);
                }
                return size;
            }
            return currentPath;
        }
    }
}
