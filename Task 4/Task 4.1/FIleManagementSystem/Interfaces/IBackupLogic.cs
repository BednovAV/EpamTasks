﻿using System;
using System.Collections.Generic;

namespace FileManagementSystem.Interfaces
{
    public interface IBackupLogic
    {
        /// <summary>
        /// The path to the working directory
        /// </summary>
        string DirectoryPath { get; }

        /// <summary>
        /// The current directory is backed up
        /// </summary>
        void BackupDirectory();

        /// <summary>
        /// Rolls back the directory to the specified date
        /// </summary>
        void RollbackFolder(DateTime dateTime);

        /// <summary>
        /// Returns a list of commits in the current directory
        /// </summary>
        IEnumerable<DateTime> GetCommits();
    }
}
