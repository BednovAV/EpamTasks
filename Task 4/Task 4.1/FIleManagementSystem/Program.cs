using FileManagementSystem.UI;
using FileManagementSystem.Dependency;

namespace FileManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new ConsoleUI(DependencyResolver.BackupLogicFactory, DependencyResolver.DirectoryWatcherFactory);
            app.StartMenu();
        }
    }
}
