using FileManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Logic.Factories
{
    public class DirectoryWatcherFactory : IDirectoryWatcherFactory
    {
        public IDirectoryWatcher GetInstance(IBackupLogic backupLogic)
            => new DirectoryWatcher(backupLogic);
    }
}
