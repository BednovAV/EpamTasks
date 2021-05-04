using System;

namespace FileManagementSystem.Logic.Exceptions
{
    class MissingBackupException : ArgumentException
    {
        public MissingBackupException(string message) : base(message)
        {

        }
    }
}
