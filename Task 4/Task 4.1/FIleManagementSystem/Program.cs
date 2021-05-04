using FileManagementSystem.UI;
using FileManagementSystem.Logic;
using System;

namespace FileManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new ConsoleUI();
            app.StartMenu();
        }
    }
}
