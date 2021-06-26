namespace FileManagementSystem.Interfaces
{
    public interface IBackupLogicFactory
    {
        IBackupLogic GetInstance(string path);
    }
}
