using System;

namespace FIleManagementSystem.Logic.Exceptions
{
    class MissingBackupException : ArgumentException
    {
        public MissingBackupException(string message) : base(message)
        {

        }
    }
}
