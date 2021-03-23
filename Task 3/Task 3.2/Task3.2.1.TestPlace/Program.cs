using System;
using System.Collections.Generic;
using Task3._2._1.Library;

namespace Task3._2._1.TestPlace
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                test1.Add(i);
            }

            var test2 = new DynamicArray<int>(test1);

            for (int i = 0; i < test2.Length; i++)
            {
                //Console.WriteLine($"i = {test2[i]} Length = {test2.Length} Capacity = {test2.Capacity}");
            }

            test2.Add(222);
            //Console.WriteLine($"i = {test2[20]} Length = {test2.Length} Capacity = {test2.Capacity}");

            test2.AddRange(test1);
            for (int i = 0; i < test2.Length; i++)
            {
                Console.WriteLine($"i = {test2[i]} Length = {test2.Length} Capacity = {test2.Capacity}");
            }
        }
    }
}
