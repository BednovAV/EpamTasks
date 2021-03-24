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
            test2.Add(322);
            test2.Remove(322);
            for (int i = 0; i < test2.Length; i++)
            {
                //Console.WriteLine($"i = {test2[i]} Length = {test2.Length} Capacity = {test2.Capacity}");
            }

            var test3 = new DynamicArray<int>();

            for (int i = 0; i < 8; i++)
            {
                test3.Add(i);
            }
            ShowArray(test3);
            test3.Insert(8, 228);
            ShowArray(test3);
            foreach (var item in test3)
            {
                Console.WriteLine(item);
            }
        }

        static void ShowArray(DynamicArray<int> dynamicArray)
        {
            Console.WriteLine($"Length = {dynamicArray.Length}; Capacity = {dynamicArray.Capacity}");

            for (int i = 0; i < dynamicArray.Length; i++)
            {
                Console.WriteLine($"Array[{i}] = {dynamicArray[i]}");
            }
        }
    }
}
