using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleManagementSystem.UI
{
    public static class ConsoleUIHelpers
    {
        public static bool TryInputDirectory(string message, out string path)
        {
            Console.Write(message);

            path = Console.ReadLine();

            return Directory.Exists(path);
        }
    }
}
