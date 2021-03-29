using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1._2
{
    public static class TextAnalyzerUI
    {
        private static TextAnalyzerLogic _analyzerLogic;

        static TextAnalyzerUI() => _analyzerLogic = new TextAnalyzerLogic();

        public static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("TEXT ANALYZER" + Environment.NewLine
                           + $"Hello, {Environment.UserName}" + Environment.NewLine);


            string startMenuText = "Выберите действие:" + Environment.NewLine
                                 + "\t1. Проанализировать текст" + Environment.NewLine
                                 + "\t2. Выйти";


            string select;
            do
            {
                Console.WriteLine(startMenuText);

                Console.Write("Ввод: ");
                select = Console.ReadLine();

                if (select == "1")
                {
                    AnalyzeMenu();
                }
                else if (select != "2")
                {
                    Console.WriteLine("Такого действия нет");
                }

            } while (select != "2");
        }

        private static void AnalyzeMenu()
        {
            _analyzerLogic.Text = InputHelpers.InputText("Введите текст: ");

            PrintWords(_analyzerLogic.WordsFrequency());
        }

        private static void PrintWords(IDictionary<string, int> dictionary)
        {
            Console.WriteLine("Список использованных слов:");
            Console.WriteLine("        Word|  Count");
            Console.WriteLine(new String('-', 22));
            foreach (var item in dictionary)
            {
                Console.WriteLine("{0, 12}|{1, 7}", item.Key, item.Value);
            }
            Console.WriteLine(new String('-', 22));
        }
    }
}
