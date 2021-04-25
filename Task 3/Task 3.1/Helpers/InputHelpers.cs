using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class InputHelpers
    {
        public static int InputPositiveValue(string message)
        {
            int result;
            bool retry;
            do
            {
                Console.Write(message);
                retry = !(int.TryParse(Console.ReadLine(), out result));
            } while (retry || result < 1);

            return result;
        }

        public static string InputText(string message)
        {
            string text;
            do
            {
                Console.Write(message);
                text = Console.ReadLine();
            } while (text == string.Empty);

            return text;
        }
    }
}
