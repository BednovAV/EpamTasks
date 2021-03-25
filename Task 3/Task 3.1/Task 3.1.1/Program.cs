using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new CycledLinkedList(10);

            foreach (var item in test.GetValues())
            {
                Console.WriteLine(item);
            }
        }
    }
}
