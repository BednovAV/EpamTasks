namespace FileManagementSystem.Interfaces
{
    public interface IDirectoryWatcherFactory
    {
        IDirectoryWatcher GetInstance(IBackupLogic backupLogic);
    }
}
