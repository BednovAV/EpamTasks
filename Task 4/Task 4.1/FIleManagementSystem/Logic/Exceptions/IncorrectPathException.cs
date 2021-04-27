using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleManagementSystem.Logic.Exceptions
{
    class IncorrectPathException : ArgumentException
    {
        public IncorrectPathException(string message) : base(message)
        {

        }
    }
}
