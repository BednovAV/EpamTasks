using System;

namespace FileManagementSystem.Logic.Exceptions
{
    class IncorrectPathException : ArgumentException
    {
        public IncorrectPathException(string message) : base(message)
        {

        }
    }
}
