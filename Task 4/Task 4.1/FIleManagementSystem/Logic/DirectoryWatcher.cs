using FileManagementSystem.Interfaces;
using System;
using System.IO;

namespace FileManagementSystem.Logic
{
    public class DirectoryWatcher : IDirectoryWatcher
    {
        public event Action<object> DirectorySaved = delegate { };

        private IBackupLogic _backupLogic;

        private FileSystemWatcher _watcher;

        /// <summary>
        /// Starts tracking mode
        /// </summary>
        public DirectoryWatcher(IBackupLogic backupLogic)
        {
            _backupLogic = backupLogic;

            _watcher = new FileSystemWatcher(_backupLogic.DirectoryPath);

            _watcher.NotifyFilter = NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Size;

            _watcher.Changed += OnChanged;
            _watcher.Created += OnChanged;
            _watcher.Deleted += OnChanged;
            _watcher.Renamed += OnChanged;

            _watcher.Filter = "*.txt";

            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Ends tracking mode
        /// </summary>
        public void Dispose()
        {
            _watcher.Dispose();
        }

        

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            _backupLogic.BackupDirectory();
            DirectorySaved?.Invoke(this);
        }
    }
}
