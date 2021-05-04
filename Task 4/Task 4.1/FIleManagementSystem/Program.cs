using FileManagementSystem.UI;
using FileManagementSystem.Logic;
using System;
using FileManagementSystem.Dependency;

namespace FileManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new ConsoleUI(DependencyResolver.BackupLogic, DependencyResolver.DirectoryWatcherFactory);
            app.StartMenu();
        }
    }
}
