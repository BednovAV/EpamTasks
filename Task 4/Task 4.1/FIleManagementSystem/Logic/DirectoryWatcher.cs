﻿using FIleManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleManagementSystem.Logic
{
    public class DirectoryWatcher : IDirectoryWatcher
    {
        public event Action<object> Saved = delegate { };

        private IBackupLogic _backupLogic;

        private FileSystemWatcher _watcher;

        /// <summary>
        /// Starts tracking mode
        /// </summary>
        public void Start(IBackupLogic backupLogic)
        {
            _backupLogic = backupLogic;

            _watcher = new FileSystemWatcher(_backupLogic.Path);

            _watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            _watcher.Changed += OnChanged;
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
            _watcher.Renamed += OnRenamed;

            _watcher.Filter = "*.txt";

            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Ends tracking mode
        /// </summary>
        public void End()
        {
            _watcher.Dispose();
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            _backupLogic.BackupDirectory();
            Saved?.Invoke(this);
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            _backupLogic.BackupDirectory();
            Saved?.Invoke(this);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            _backupLogic.BackupDirectory();
            Saved?.Invoke(this);
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            _backupLogic.BackupDirectory();
            Saved?.Invoke(this);
        }
    }
}
