using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._1._1
{
    public static class InputHelpers
    {
        public static int InputPositiveValue(string text)
        {
            int result;
            bool retry;
            do
            {
                Console.Write(text);
                retry = !(int.TryParse(Console.ReadLine(), out result));
            } while (retry || result < 1);

            return result;
        }
    }
}
