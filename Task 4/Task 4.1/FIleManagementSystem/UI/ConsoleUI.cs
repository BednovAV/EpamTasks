﻿using FIleManagementSystem.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleManagementSystem.UI
{
    public class ConsoleUI
    {
        private FMSLogic _logic;

        public ConsoleUI() => _logic = new FMSLogic();

        public void StartMenu()
        {
            Console.Clear();

            string path;

            while (!ConsoleUIHelpers
                       .TryInputDirectory("Введите путь до отслеживаемой директории: ", out path))
            {
                Console.WriteLine("Указанной директории не существует");
            }

            _logic.Path = path;

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

            Console.WriteLine(_logic.Path);
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
            var commitList = new List<DateTime>(_logic.GetCommitList());


            Console.WriteLine($"Список фиксаций({_logic.Path}):");
            for (int i = 0; i < commitList.Count; i++)
            {
                Console.WriteLine($"\t{i}. {commitList[i].ToString()}");
            }

            int select = ConsoleUIHelpers.InputValueInRange("Ваш выбор: ", 0, commitList.Count);


            _logic.RollBackFolder(commitList[select]);
        }

        private void TrackingMode()
        {
            _logic.Saved += OnSaved;
            _logic.TrackingModeStart();

            Console.WriteLine($"Режим наблюдения включен ({_logic.Path})");
            Console.WriteLine("Нажмите на любую клавишу чтобы выйти");
            Console.ReadKey();

            _logic.TrackingModeEnd();
        }

        private void OnSaved(object sender)
        {
            Console.WriteLine($"{DateTime.Now.ToString()} Изменения зафиксированы");
        }
    }
}