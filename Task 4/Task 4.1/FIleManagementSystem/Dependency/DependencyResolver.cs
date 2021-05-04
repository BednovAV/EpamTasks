using FileManagementSystem.Interfaces;
using FileManagementSystem.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Dependency
{
    public static class DependencyResolver
    {
        private static IBackupLogic _backupLogic;
        public static IBackupLogic BackupLogic
            => _backupLogic is null ? _backupLogic = new BackupLogic() : _backupLogic;


        private static IDirectoryWatcher _directoryWatcher;
        public static IDirectoryWatcher DirectoryWatcher
            => _directoryWatcher is null ? _directoryWatcher = new DirectoryWatcher() : _directoryWatcher;
    }
}
