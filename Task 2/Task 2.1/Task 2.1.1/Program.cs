using CustomStringLibrary;
using System;

namespace Task_2._1._1
{
    class Program
    {
        /*
         * Демонстрация работы класса CustomString
         */
        static void Main(string[] args)
        {
            CustomString hello = new CustomString("Hello");
            CustomString world = new CustomString("world");
            hello.Append(" ");
            Console.WriteLine($"{hello} + {world}: {hello + world}");
            Console.WriteLine();

            CustomString world2 = new CustomString("world");
            Console.WriteLine($"{world} == {world2}: {world == world2}");
            Console.WriteLine($"{world} != {world2}: {world != world2}");
            Console.WriteLine($"{world}.Equals({world}): {world.Equals(world2)}");
            Console.WriteLine($"{world} == {hello}: {world == hello}");
            Console.WriteLine();

            Console.WriteLine($"{world}.IndexOf({'l'}): {world.IndexOf('l')}");
            Console.WriteLine($"{world}.IndexOf({'a'}): {world.IndexOf('a')}");
            Console.WriteLine();

            Console.WriteLine($"Преобразование {world} в массив символов:");
            char[] charArray = world.ToCharArray();
            foreach (var item in charArray)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine($"{hello}.CharCount({'l'}): {hello.CharCount('l')}");
            Console.WriteLine();

            Console.WriteLine($"{world}.Reply(5): {world.Reply(5)}");
        }
    }
}
