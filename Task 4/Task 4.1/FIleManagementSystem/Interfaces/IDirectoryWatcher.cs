using System;

namespace FileManagementSystem.Interfaces
{
    public interface IDirectoryWatcher : IDisposable
    {
        event Action<object> DirectorySaved;
    }
}
