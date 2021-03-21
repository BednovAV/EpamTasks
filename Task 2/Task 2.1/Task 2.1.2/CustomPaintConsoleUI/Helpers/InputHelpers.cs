using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2._1._2.Figures;

namespace Task_2._1._2.CustomPaintConsoleUI.Helpers
{
    public static class InputHelpers
    {

        public static Point InputPoint(string name)
        {
            Console.WriteLine(name);

            int x = InputValue("\tX: ");
            int y = InputValue("\tY: ");

            return new Point(x, y);
        }

        public static int InputPositiveValue(string text)
        {
            int value;

            do
            {
                Console.Write(text);
            } while (!(int.TryParse(Console.ReadLine(), out value)) || value <= 0);

            return value;
        }

        public static int InputValue(string text)
        {
            int value;

            do
            {
                Console.Write(text);
            } while (!(int.TryParse(Console.ReadLine(), out value)));

            return value;
        }
    }
}
