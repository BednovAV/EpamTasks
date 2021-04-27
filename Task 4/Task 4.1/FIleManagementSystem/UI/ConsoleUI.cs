using FIleManagementSystem.Logic;
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
                        ObservationMode();
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
            throw new NotImplementedException();
        }

        private void ObservationMode()
        {
            throw new NotImplementedException();
        }
    }
}
