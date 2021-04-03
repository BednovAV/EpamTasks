using System;
using Task_2._1._2.CustomPaintConsoleUI.Entities;

namespace Task_2._1._2.CustomPaintConsoleUI
{
    public static class App
    {
        public static void Start()
        {
            DrawingArea drawingArea;
            User user;

            do
            {
                user = AccountsManager.Accounts.GetUserMenu();

                drawingArea = new DrawingArea(user);
            }while(drawingArea.StartMenu());

            Console.WriteLine("Приложение завершило свою работу");
        }
    }
}
