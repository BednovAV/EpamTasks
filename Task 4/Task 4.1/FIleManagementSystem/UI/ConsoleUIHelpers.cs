using System;
using System.IO;

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

        public static int InputValueInRange(string message, int from, int before)
        {
            int result;

            bool retry;
            do
            {
                Console.Write(message);
                retry = !int.TryParse(Console.ReadLine(), out result);
            } while (!(result < before && result >= from)
                   || retry);

            return result;
        }
    }
}
