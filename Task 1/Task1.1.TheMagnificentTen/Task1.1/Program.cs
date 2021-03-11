using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1
{
    class Program
    {
        /*
         * Task 1.1.1
         * Написать программу, которая определяет площадь прямоугольника со сторонами a и b.Если
         * пользователь вводит некорректные значения (отрицательные или ноль), должно выдаваться
         * сообщение об ошибке.Возможность ввода пользователем строки вида «абвгд» или нецелых чисел
         * игнорировать.
         */
        static void Rectangle()
        {
            int a;
            do
            {
                Console.Write("a: ");
                a = int.Parse(Console.ReadLine());

                if (a <= 0)
                {
                    Console.WriteLine("Попробуйте еще раз.");
                }
            } while (a <= 0);

            int b;
            do
            {
                Console.Write("b: ");
                b = int.Parse(Console.ReadLine());

                if (b <= 0)
                {
                    Console.WriteLine("Попробуйте еще раз.");
                }
            } while (b <= 0);

            Console.WriteLine($"Площадь прямоугольника: {a * b}");
        }

        // Task 1.1.2
        static void Triangle()
        {
            int n;
            do
            {
                Console.Write("N: ");
                n = int.Parse(Console.ReadLine());
            } while (n < 0);

            for (int line = 1; line <= n; line++)
            {
                Console.WriteLine(new String('*', line));
            }
        }

        // Task 1.1.3
        static void AnotherTriangle()
        {
            int n;
            do
            {
                Console.Write("N: ");
                n = int.Parse(Console.ReadLine());
            } while (n < 0);

            for (int line = 1; line <= n; line++)
            {
                int numberOfChars = line * 2 - 1;

                string str = new String('*', numberOfChars);

                Console.WriteLine(str.PadLeft(n - line + numberOfChars));
            }
        }

        // Task 1.1.4
        static void XMasTree()
        {
            int n;
            do
            {
                Console.Write("N: ");
                n = int.Parse(Console.ReadLine());
            } while (n < 0);

            for (int triangle = 1; triangle <= n; triangle++)
            {
                for (int line = 1; line <= triangle; line++)
                {
                    int numberOfChars = line * 2 - 1;

                    string str = new String('*', numberOfChars);

                    Console.WriteLine(str.PadLeft(n - line + numberOfChars));
                }
            }
        }

        /* 
         * Task 1.1.5
         * Если выписать все натуральные числа меньше 10, кратные 3 или 5, то получим 3, 5, 6 и 9. Сумма
         * этих чисел будет равна 23. Напишите программу, которая выводит на экран сумму всех чисел
         * меньше 1000, кратных 3 или 5.
         */
        static void SumOfNumbers()
        {
            int s = 0;
            //for (int i = 1; i < 1000; i++)
            //{
            //    if (i % 3 == 0 || i % 5 == 0)
            //    {
            //        s += i;
            //    }
            //}

            for (int i = 0; i < 1000; i += 3)
            {
                if (i % 5 != 0)
                {
                    s += i;
                }
            }

            for (int i = 0; i < 1000; i += 5)
            {
                if (i % 3 != 0)
                {
                    s += i;
                }
            }

            for (int i = 0; i < 1000; i += 15)
            {
                s += i;
            }
            Console.WriteLine($"Сумма всех чисел меньше 1000, кратных 3 или 5: {s}");
        }

        /* 
         * Task 1.1.6
         * Для форматирования текста надписи можно использовать различные начертания: полужирное,
         * курсивное и подчёркнутое, а также их сочетания. Предложите способ хранения информации о
         * форматировании текста надписи и напишите программу, которая позволяет устанавливать и
         * изменять начертание: 
         */
        enum FontProp
        {
            Bold,
            Italic,
            Underline
        }
        static void FontAdjustment()
        {
            List<FontProp?> props = new List<FontProp?>();

            string select = "";
            while (select != "0")
            {
                StringBuilder outLine = new StringBuilder();
                if (props.Count != 0)
                {
                    foreach (var item in props)
                    {
                        outLine.Append(item + ", ");
                    }
                    outLine.Remove(outLine.Length - 2, 2); // удаляются последние запятая с пробелом
                }
                else
                {
                    outLine.Append("None");
                }

                Console.WriteLine($"Параметры надписи: {outLine}");

                Console.WriteLine("Введите:\n" +
                                    "\t1: bold\n" +
                                    "\t2: italic\n" +
                                    "\t3: underline\n" +
                                    "\t0: Выйти");

                select = Console.ReadLine();

                FontProp? prop = select switch
                {
                    "1" => FontProp.Bold,
                    "2" => FontProp.Italic,
                    "3" => FontProp.Underline,
                    _ => null
                };
                
                if (prop != null)
                {
                    if (props.Contains(prop))
                    {
                        props.Remove(prop);
                    }
                    else
                    {
                        props.Add(prop);
                    }
                }
            }

        }

        /* 
         * Task 1.1.7
         * Написать программу, которая генерирует случайным образом элементы массива (число элементов
         * в массиве и их тип определяются разработчиком), определяет для него максимальное и
         * минимальное значения, сортирует массив и выводит полученный результат на экран.
        */
        static void ArrayProcessing()
        {
            Random rnd = new Random();
            int[] array = new int[20];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-100, 101);
            }

            Console.Write("Массив: ");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            int min = 101;
            foreach (var item in array)
            {
                if (min > item)
                {
                    min = item;
                }
            }
            Console.WriteLine($"Минимальное значение: {min}");

            int max = -101;
            foreach (var item in array)
            {
                if (max < item)
                {
                    max = item;
                }
            }
            Console.WriteLine($"Максимальное значение: {max}");

            for (int i = 0; i < array.Length; i++)
            {
                min = 101;
                int minIndex = -1;
                for (int j = i; j < array.Length; j++)
                {
                    if (min > array[j])
                    {
                        min = array[j];
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    array[i] += array[minIndex];
                    array[minIndex] = array[i] - array[minIndex];
                    array[i] -= array[minIndex];
                }
            }

            Console.Write("Отсортированный массив: ");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        /*
         * Task 1.1.8
         * Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на
         * нули. Число элементов в массиве и их тип определяются разработчиком.*/
        static void NoPositive()
        {
            Random rnd = new Random();
            int[,,] array = new int[3, 3, 3];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = rnd.Next(-100, 101);
                    }
                }
            }

            Console.WriteLine("Массив:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.WriteLine($"\tarray[{i},{j},{k}]: {array[i, j, k]}");
                    }
                }
            }
            Console.WriteLine();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }

            Console.WriteLine("Отредакриванный массив:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.WriteLine($"\tarray[{i},{j},{k}]: {array[i, j, k]}");
                    }
                }
            }
        }

        /*
         * Task 1.1.9
         * Написать программу, которая определяет сумму неотрицательных элементов в одномерном
         * массиве. Число элементов в массиве и их тип определяются разработчиком.
        */
        static void NonNegativeSum()
        {
            Random rnd = new Random();
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10, 11);
            }

            Console.Write("Массив: ");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            int s = 0;
            foreach (var item in array)
            {
                if (item > 0)
                {
                    s += item;
                }
            }

            Console.WriteLine($"Сумма неотрицательных элементов: {s}");
        }

        /*
         * Task 1.1.10
         * Элемент двумерного массива считается стоящим на чётной позиции, если сумма номеров его
         * позиций по обеим размерностям является чётным числом (например, [1,1] — чётная позиция, а
         * [1,2] — нет). Определить сумму элементов массива, стоящих на чётных позициях.
        */
        static void Array2D()
        {
            Random rnd = new Random();
            int[,] array = new int[3, 3];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(0, 11);
                }
            }

            Console.WriteLine("Массив:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0,3}", array[i, j]);
                }
                Console.WriteLine();
            }

            int s = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        s += array[i, j];
                    }
                }
            }

            Console.WriteLine($"Сумма элементов массива, стоящих на чётных позициях: {s}");
        }


        static void Main(string[] args)
        {
            //Rectangle();

            //Triangle();

            //AnotherTriangle();

            //XMasTree();

            //SumOfNumbers();

            //FontAdjustment();

            //ArrayProcessing();

            //NoPositive();

            //NonNegativeSum();

            //Array2D();
        }
    }
}
