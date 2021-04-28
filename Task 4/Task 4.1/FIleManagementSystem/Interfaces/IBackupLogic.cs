using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleManagementSystem.Interfaces
{
    public interface IBackupLogic
    {
        string Path { get; }

        void BackupDirectory();

        void RollbackFolder(DateTime dateTime);

        IEnumerable<DateTime> GetCommitList();
    }
}
