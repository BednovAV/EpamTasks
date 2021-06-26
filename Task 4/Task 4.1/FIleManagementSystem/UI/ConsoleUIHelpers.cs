using System;
using System.IO;

namespace FileManagementSystem.UI
{
    public static class ConsoleUIHelpers
    {
        /// <summary>
        /// Displays a message and asks to enter the directory path,
        /// in case of incorrect input, asks again
        /// </summary>
        /// <returns>Existing directory</returns>
        public static string InputDirectory(string message)
        {
            bool retry = false;
            string path;
            do
            {
                if (retry)
                    Console.WriteLine("Указанной директории не существует");

                retry = true;


                Console.Write(message);
                path = Console.ReadLine();

            } while (!Directory.Exists(path));
            

            return path;
        }

        public static int InputValueInRange(string message, int from, int to)
        {
            int result;

            bool retry;
            do
            {
                Console.Write(message);
                retry = !int.TryParse(Console.ReadLine(), out result);
            } while (!(result < to && result >= from)
                   || retry);

            return result;
        }
    }
}
