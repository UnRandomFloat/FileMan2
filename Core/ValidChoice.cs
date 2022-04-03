using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager2._0
{
    class ValidChoice
    {
        PrintOuter MS = new PrintOuter();

        public string FromDisks(out bool doAgain, string mainMessage = "Выберите диск:", string errMessage = "Неверный ввод, повторите попытку", bool showDiskList = true)
        {
            doAgain = true;
            DriveInfo[] drivers = DriveInfo.GetDrives();
            bool oneMoreTime = true;
            if (showDiskList)
            {
                ShowDickList(drivers);
            }
            while (oneMoreTime)
            {
                MS.ShowMessage(mainMessage, TextAlign.Left);
                string s = Console.ReadLine();
                if (s.ToLower() == "out")
                {
                    doAgain = false;
                    return null;
                }

                foreach (DriveInfo d in drivers)
                {

                    if (d.Name.Equals(s))
                    {
                        doAgain = true;
                        oneMoreTime = false;
                        if (d.Name.ToString().PadRight(1) == @"\")
                        {
                            return d.Name.ToString();
                        }
                        return d.Name.ToString() + @"\";
                    }
                }
                MS.ShowMessage("Некорректный выбор повторите ввод!", TextAlign.Left);

            }
            doAgain = false;
            return null;

        }
        void ShowDickList(DriveInfo[] drivers)
        {
            foreach (DriveInfo d in drivers)
            {
                MS.ShowMessage(d.Name.ToString(), TextAlign.Left);
            }
        }
    }
}
