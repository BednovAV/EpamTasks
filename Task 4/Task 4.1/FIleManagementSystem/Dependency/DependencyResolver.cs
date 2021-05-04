using FileManagementSystem.Interfaces;
using FileManagementSystem.Logic;
using FileManagementSystem.Logic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Dependency
{
    public static class DependencyResolver
    {
        private static IBackupLogicFactory _backupLogicFactory;
        public static IBackupLogicFactory BackupLogicFactory
            => _backupLogicFactory ??= new BackupLogicFactory();


        private static IDirectoryWatcherFactory _directoryWatcherfactory;
        public static IDirectoryWatcherFactory DirectoryWatcherFactory
            => _directoryWatcherfactory ??=  new DirectoryWatcherFactory();
    }
}
