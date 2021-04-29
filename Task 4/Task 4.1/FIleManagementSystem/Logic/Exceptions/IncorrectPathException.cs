using System;

namespace FIleManagementSystem.Logic.Exceptions
{
    class IncorrectPathException : ArgumentException
    {
        public IncorrectPathException(string message) : base(message)
        {

        }
    }
}
