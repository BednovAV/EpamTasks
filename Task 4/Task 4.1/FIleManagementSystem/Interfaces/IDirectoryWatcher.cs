using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleManagementSystem.Interfaces
{
    interface IDirectoryWatcher
    {
        event Action<object> Saved;
        void Start(IBackupLogic backupLogic);
        void End();
    }
}
