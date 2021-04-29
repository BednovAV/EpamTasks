using System;
using System.Collections.Generic;

namespace FIleManagementSystem.Interfaces
{
    public interface IBackupLogic
    {
        /// <summary>
        /// The path to the working directory
        /// </summary>
        string Path { get; set; }

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
        IEnumerable<DateTime> GetCommitList();
    }
}
