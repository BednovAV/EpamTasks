using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementSystem.Interfaces;

namespace FileManagementSystem.Logic.Factories
{
    public class BackupLogicFactory : IBackupLogicFactory
    {
        public IBackupLogic GetInstance(string path)
            => new BackupLogic(path);
    }
}
