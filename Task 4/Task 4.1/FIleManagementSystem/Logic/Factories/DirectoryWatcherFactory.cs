using FileManagementSystem.Interfaces;
using System;

namespace FileManagementSystem.Logic.Factories
{
    public class DirectoryWatcherFactory : IDirectoryWatcherFactory
    {
        public IDirectoryWatcher GetInstance(IBackupLogic backupLogic)
        {
            if (backupLogic is null)
                throw new NullReferenceException();

            return new DirectoryWatcher(backupLogic);
        }
    }
}
