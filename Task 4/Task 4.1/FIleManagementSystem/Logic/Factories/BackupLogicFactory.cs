using FileManagementSystem.Interfaces;

namespace FileManagementSystem.Logic.Factories
{
    public class BackupLogicFactory : IBackupLogicFactory
    {
        public IBackupLogic GetInstance(string path)
            => new BackupLogic(path);
    }
}
