using FileManagementSystem.Interfaces;
using System;
using System.Collections.Generic;

namespace FileManagementSystem.UI
{
    public class ConsoleUI
    {
        private IBackupLogic _backupLogic;
        private IDirectoryWatcherFactory _directoryWatcherFactory;

        public ConsoleUI(IBackupLogic backupLogic, IDirectoryWatcherFactory directoryWatcherFactory)
        {
            _backupLogic = backupLogic;
            _directoryWatcherFactory = directoryWatcherFactory;
        }

        public void StartMenu()
        {
            Console.Clear();

            string path;

            while (!ConsoleUIHelpers
                       .TryInputDirectory("Введите путь до отслеживаемой директории: ", out path))
            {
                Console.WriteLine("Указанной директории не существует");
            }

            _backupLogic.Path = path;

            MainMenu();
        }

        private void MainMenu()
        {
            string mainMenuText = "Выберите действие:" + Environment.NewLine
                                + "\t 1. Перейти в режим наблюдения" + Environment.NewLine
                                + "\t 2. Откат изменений" + Environment.NewLine
                                + "\t 0, Выйти" + Environment.NewLine
                                + "Ввод: ";

            Console.Clear();

            Console.WriteLine(_backupLogic.Path);
            Console.WriteLine();

            string select = string.Empty;
            do
            {
                Console.Write(mainMenuText);
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        TrackingMode();
                        break;
                    case "2":
                        BackChanges();
                        break;
                    default:
                        break;
                }

            } while (select is not "0");
        }

        private void BackChanges()
        {
            var commitList = new List<DateTime>(_backupLogic.GetCommitList());


            Console.WriteLine($"Список фиксаций({_backupLogic.Path}):");
            for (int i = 0; i < commitList.Count; i++)
            {
                Console.WriteLine($"\t{i}. {commitList[i].ToString()}");
            }

            int select = ConsoleUIHelpers.InputValueInRange("Ваш выбор: ", 0, commitList.Count);


            _backupLogic.RollbackFolder(commitList[select]);
        }

        private void TrackingMode()
        {

            using (var directoryWatcher = _directoryWatcherFactory.GetInstance(_backupLogic))
            {
                directoryWatcher.DirectorySaved += OnSaved;

                Console.WriteLine($"Режим наблюдения включен ({_backupLogic.Path})");
                Console.WriteLine();
                Console.WriteLine("Нажмите на любую клавишу чтобы выйти");
                Console.ReadKey();

                directoryWatcher.DirectorySaved -= OnSaved;
            }
        }

        private void OnSaved(object sendler)
        {
            Console.WriteLine($"{DateTime.Now.ToString()} Изменения зафиксированы");
        }
    }
}
