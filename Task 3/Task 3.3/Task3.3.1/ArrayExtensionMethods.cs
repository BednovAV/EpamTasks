using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3._3._1
{
    /*
     * Расширьте массивы чисел методом, производящим действия с каждым конкретным элементом.
     * Действие должно передаваться в метод с помощью делегата.
     * Кроме указанного функционала выше, добавьте методы расширения для поиска:
     *  - суммы всех элементов;
     *  - среднего значения в массиве;
     *  - самого часто повторяемого элемента;
    */
    public static class ArrayExtensionMethods
    {
        #region TRANSFORM

        public static void Transform(this int[] array, Func<int, int> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
         
            }
        }

        public static void Transform(this uint[] array, Func<uint, uint> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
            }
        }

        public static void Transform(this long[] array, Func<long, long> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
            }
        }

        public static void Transform(this ulong[] array, Func<ulong, ulong> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
            }
        }

        public static void Transform(this float[] array, Func<float, float> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
            }
        }

        public static void Transform(this double[] array, Func<double, double> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
            }
        }

        public static void Transform(this byte[] array, Func<byte, byte> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
            }
        }

        public static void Transform(this sbyte[] array, Func<sbyte, sbyte> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
            }
        }

        public static void Transform(this short[] array, Func<short, short> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
            }
        }

        public static void Transform(this ushort[] array, Func<ushort, ushort> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
            }
        }

        public static void Transform(this decimal[] array, Func<decimal, decimal> transform)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = transform(array[i]);
            }
        }

        #endregion

        #region SUM

        public static int MySum(this int[] array) => array.Sum();

        public static uint MySum(this uint[] array)
        {
            uint sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static long MySum(this long[] array) => array.Sum();

        public static ulong MySum(this ulong[] array)
        {
            ulong sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static float MySum(this float[] array) => array.Sum();

        public static double MySum(this double[] array) => array.Sum();

        public static byte MySum(this byte[] array)
        {
            byte sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static sbyte MySum(this sbyte[] array)
        {
            sbyte sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static short MySum(this short[] array)
        {
            short sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static ushort MySum(this ushort[] array)
        {
            ushort sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static decimal MySum(this decimal[] array) => array.Sum();
        #endregion

        #region AVERAGE

        public static double MyAverage(this int[] array) => array.Average();

        public static double MyAverage(this double[] array) => array.Average();

        public static double MyAverage(this long[] array) => array.Average();

        #endregion

        #region MOST REPEATABLE
        public static int MostRepeatable(this int[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static uint MostRepeatable(this uint[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static long MostRepeatable(this long[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static ulong MostRepeatable(this ulong[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static float MostRepeatable(this float[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static double MostRepeatable(this double[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static byte MostRepeatable(this byte[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static sbyte MostRepeatable(this sbyte[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static short MostRepeatable(this short[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static ushort MostRepeatable(this ushort[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static decimal MostRepeatable(this decimal[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;
        #endregion
    }
}
