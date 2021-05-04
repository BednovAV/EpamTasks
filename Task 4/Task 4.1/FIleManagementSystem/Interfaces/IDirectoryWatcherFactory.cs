using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Interfaces
{
    public interface IDirectoryWatcherFactory
    {
        IDirectoryWatcher GetInstance(IBackupLogic backupLogic);
    }
}
