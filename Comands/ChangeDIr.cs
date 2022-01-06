using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager2._0
{
    class ChangeDir : Comands
    {
        public ChangeDir(string[] comArray, string currPath) : base(comArray, currPath)
        {

        }
        protected override string twoArgument()
        {
      
            targetPath = sArray[1];
            string mabyPath = Path.Combine(currentPath, targetPath);
            if (Directory.Exists(mabyPath))
            {
                return mabyPath+"//";
            }
            if (Directory.Exists(targetPath))
            {
                return targetPath+"//";
            }
            inf.ShowMessage("Каталог с именем не неайден", TextAlign.Left);
             return currentPath;
        }
    }
}
