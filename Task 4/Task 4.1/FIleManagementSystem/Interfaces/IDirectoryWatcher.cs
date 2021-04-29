using System;

namespace FIleManagementSystem.Interfaces
{
    public interface IDirectoryWatcher : IDisposable
    {
        event Action<object> Saved;

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
