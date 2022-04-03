using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager2._0
{
    class MainWorkPlace
    {
        //* Файловый менеджер должен иметь возможность:
        //* показывать содержимое дисков;+++
        //* создавать папки/файлы;+++
        //* удалять папки/файлы;+++
        //* переименовывать папки/файлы;+++
        //* копировать/переносить папки/файлы;+++
        //* вычислять размер папки/файла;+++
        //* производить поиск по маске(с поиском по подпапкам);---
        //* для текстовых файлов готовить статические данные(кол-во слов, кол-во строк, кол-во абзацев, кол-во символов с пробелами, кол-во слов без пробелов).---
        private string _currentPath;
        private PrintOuter MS = new PrintOuter();
        private ChangeDir _changeDirectory;
        private CreateFolderFile _create;
        private CopyFolderFile _copy;
        private DeleteFolderFile _delete;
        private WhatSizeFolderFile _size;
        private FindFolderFile _find;
        private MoveFolderFile _moove;
        private RenameFolderFile _rname;
        private ShowFolderFileInfo _showinfo;
        private ValidChoice validChoice = new ValidChoice();
        private TextAlign _textAlign;
        private bool doAgain = true;
        private bool invalidPath = false;
        private string[] sArray;
        public MainWorkPlace()
        {

        }
        private void TargetContaned()
        {


        }
        internal void LetsStartPoint()
        {
            MS.ShowMessage("Доступные диски:\n", TextAlign.Left);
            _currentPath = Path.GetFullPath(@"E:\");
            ShowContentOfCurrentDirectory();
            while (doAgain)
            {
                try
                {
                    Console.Write(_currentPath);
                    comand(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "//" + "logister.txt", true, Encoding.Default))
                    {
                        sw.WriteLine(ex.Message);
                    }
                
                    MS.ShowMessage("Что то пошло не так. Информация об ошибке внесена в лог, который создан в директории запуска", TextAlign.Left);
                    Console.ReadLine();
                    _currentPath = Environment.CurrentDirectory;
                }
            }
        }

        void comand(string s)
        {
            string[] comandArray = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            sArray = comandArray;
            if (comandArray.Count() == 0)
            {
                MS.ShowMessage("Введена пустая команда, повторите ввод", TextAlign.Left);

            }
            else
            {
                switch (comandArray[0])
                {
                    case "cp":
                        _copy = new CopyFolderFile(comandArray, _currentPath);
                        _copy.Execute();
                        MS.PrepareConsole(true, false);
                        ShowContentOfCurrentDirectory();
                        break;
                    case "cd":
                        _changeDirectory = new ChangeDir(comandArray, _currentPath);
                        string newPath = _changeDirectory.Execute();
                        bool check = String.IsNullOrEmpty(newPath);
                        if (!check)
                        {
                            _currentPath = Path.GetFullPath(newPath);
                        }
                       
                        ShowContentOfCurrentDirectory();
                        break;
                    case "del":
                        _delete = new DeleteFolderFile(comandArray, _currentPath);
                        _delete.Execute();
                        MS.PrepareConsole(true, false);
                        ShowContentOfCurrentDirectory();
                        break;
                    case "rename":
                        _rname = new RenameFolderFile(comandArray, _currentPath);
                        string pathAfterRename=_rname.Execute();
                        
                        bool checkRenamedPath = String.IsNullOrEmpty(pathAfterRename);
                        if (!checkRenamedPath)
                        {
                            _currentPath = Path.GetFullPath(pathAfterRename);
                        }
                        ShowContentOfCurrentDirectory();
                        break;
                    case "create":
                        _create = new CreateFolderFile(comandArray, _currentPath);
                        _create.Execute();
                        MS.PrepareConsole(true, false);
                        ShowContentOfCurrentDirectory();
                        break;
                    case "sz":
                        _size = new WhatSizeFolderFile(comandArray, _currentPath);
                        _size.Execute();
                        MS.PrepareConsole(true, false);
                        ShowContentOfCurrentDirectory();
                        break;
                    default:
                        MS.ShowMessage($"Неизвестная команда {comandArray[0]}", TextAlign.Left);
                        break;
                }
            }
        }
        void ShowContentOfCurrentDirectory()
        {
            DirectoryInfo subdirs = new DirectoryInfo(Path.GetFullPath(_currentPath));
            FileInfo[] files = subdirs.GetFiles();
            DirectoryInfo[] dirs = subdirs.GetDirectories();
            MS.PrepareConsole(false, true);
            //MS.ShowMessage(subdirs.FullName, TextAlign.Left);
            MS.ShowFolderFileList(dirs, files);
        }
  
    }
}
