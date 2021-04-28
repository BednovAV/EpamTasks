using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FIleManagementSystem.Logic.Exceptions;
using FIleManagementSystem.Interfaces;

namespace FIleManagementSystem.Logic
{
    public class FMSLogic
    {
        public event Action<object> Saved = delegate { };

        private IBackupLogic _backupLogic;

        private DirectoryWatcher _directoryWatcher;

        private string _path;

        public string Path
        {
            get => _path;
            set
            {
                _path = Directory.Exists(value) ?
                          value
                        : throw new IncorrectPathException("Указанный путь не существует");

                _backupLogic = new BackupLogic(Path);
                _directoryWatcher = new DirectoryWatcher();
            }
        }

        public void TrackingModeStart()
        {
            _directoryWatcher.Saved += Saved;
            _directoryWatcher.Start(_backupLogic);
        }

        public void TrackingModeEnd()
        {
            _directoryWatcher.Saved -= Saved;
            _directoryWatcher.End();
        }

        public IEnumerable<DateTime> GetCommitList() => _backupLogic.GetCommitList();

        public void RollBackFolder(DateTime dateTime) => _backupLogic.RollbackFolder(dateTime);
    }
}
