using System;
using System.Linq;

namespace ExtensionLibrary
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

        public static void Transform(this double[] array, Func<double, double> transform)
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

        #endregion

        #region SUM

        public static int MySum(this int[] array) => array.Sum();

        public static double MySum(this double[] array) => array.Sum();

        public static long MySum(this long[] array) => array.Sum();

        #endregion

        #region AVERAGE

        public static double MyAverage(this int[] array) => array.Average();

        public static double MyAverage(this double[] array) => array.Average();

        public static double MyAverage(this long[] array) => array.Average();

        #endregion
    }
}
