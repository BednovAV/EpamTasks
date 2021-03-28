using Helpers;
using System;

namespace Task_3._1._1
{
    public static class GameUI
    {
        public static void StartMenu()
        {
            Console.Clear();

            string startMenuText = "Выберите действие:" + Environment.NewLine
                                 + "\t1. Начать новую игру" + Environment.NewLine
                                 + "\t2. Выйти";

            string select;
            do
            {
                Console.WriteLine(startMenuText);

                Console.Write("Ввод: ");
                select = Console.ReadLine();

                if (select == "1")
                {
                    GameMenu();
                }
                else if(select != "2")
                {
                    Console.WriteLine("Такого действия нет");
                }

            } while (select != "2");
        }

        private static void GameMenu()
        {
            Console.Clear();

            var gameLogic = new GameLogic(InputHelpers.InputPositiveValue("Введите N(число игроков): "));

            int step = InputHelpers.InputPositiveValue("Введите, какой по счету человек будет вычеркнут каждый раунд: ");

            int round = 0;
            while(gameLogic.Count >= step)
            {
                round++;
                int deleted = gameLogic.Step(step);

                Console.WriteLine($"Раунд {round}. Вычеркнут человек({deleted}). Людей осталось: {gameLogic.Count}");
            }

            Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
            Console.Write("Оставшиеся игроки: ");
            foreach (var item in gameLogic.Members)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
