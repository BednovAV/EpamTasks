using System;

namespace FileManagementSystem.Interfaces
{
    public interface IDirectoryWatcher : IDisposable
    {
        event Action<object> DirectorySaved;

        /// <summary>
        /// Starts tracking mode
        /// </summary>
        void Start(IBackupLogic backupLogic);

        /// <summary>
        /// Ends tracking mode
        /// </summary>
        void End();
    }
}
