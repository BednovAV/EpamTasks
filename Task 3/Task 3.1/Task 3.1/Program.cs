using System;
using Task_3._1._1;
using Task3._1._2;

namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "1. Task 3.1.1 WEAKEST LINK" + Environment.NewLine
                        + "2. Task 3.1.2 TEXT ANALYSIS" + Environment.NewLine
                        + "0. Выйти";

            string select = "";
            while(select != "0")
            {
                Console.Clear();

                Console.WriteLine(text);
                Console.Write("Ввод: ");
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        GameUI.StartMenu();
                        break;
                    case "2":
                        TextAnalyzerUI.StartMenu();
                        break;
                }
            }
        }
    }
}
