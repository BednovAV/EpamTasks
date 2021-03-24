﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._2._1.Library
{
    /*
     * На базе массива (именно массива, специфичные коллекции .NET не использовать) реализовать
     * свой собственный класс DynamicArray<T>, представляющий собой массив с запасом, хранящий
     * объекты произвольных типов 
     */
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private T[] _array;

        /// <summary>
        /// Свойство Length — получение количества элементов.
        /// </summary>
        public int Length { get; private set; } // 8

        /// <summary>
        /// Свойство Capacity — получение ёмкости: длины внутреннего массива.
        /// </summary>
        public int Capacity { get => _array.Length; } // 9

        /// <summary>
        /// Конструктор без параметров (создаётся массив ёмкостью 8 элементов).
        /// </summary>
        public DynamicArray() // 1
        {
            _array = new T[8];
            Length = 0;
        }

        /// <summary>
        /// Конструктор с одним целочисленным параметром (создаётся массив указанной ёмкости).
        /// </summary>
        /// <param name="capacity"></param>
        public DynamicArray(int capacity) // 2
        {
            _array = new T[capacity];
            Length = 0;
        }

        /// <summary>
        /// Конструктор, который в качестве параметра принимает коллекцию, реализующую 
        /// интерфейс IEnumerable<T>, создаёт массив нужного размера и копирует в него все
        /// элементы из коллекции.
        /// </summary>
        public DynamicArray(IEnumerable<T> source)  // 3
        {
            _array = source.ToArray();
            Length = source.Count();
        }


        /// <summary>
        /// The method must be called before each addition to the array.
        /// Increases the capacity to the required value, if needed.
        /// (The array will grow as well)
        /// </summary>
        private void IncreaseCapacity(int requiredValue)
        {
            if (requiredValue <= Capacity)
                return;

            int newCapacity = Capacity;

            while (newCapacity < requiredValue) { newCapacity *= 2; }

            T[] newArray = new T[newCapacity];
            Array.Copy(_array, newArray, Length);
            _array = newArray;
        }

        /// <summary>
        /// The method shifts the elements of the array, starting from the
        /// specified position, to the right by the specified number of positions.
        /// (Increases capacity if needed)
        /// </summary>
        private void RightShift(int position, int numberOfPos)
        {
            IncreaseCapacity(Length + numberOfPos);

            for (int i = Length - 1; i >= position; i--)
            {
                _array[i + numberOfPos] = _array[i];
            }
            Length += numberOfPos;

            // write the default values ​​in the vacated cells
            for (int i = position; i < position + numberOfPos; i++)
            {
                _array[i] = default(T);
            }
        }

        /// <summary>
        /// The method shifts the elements of the array(right of the specified position),
        /// starting from the specified position, to the left by the specified number of positions.
        /// (Elements shifted to the left of the array are removed)
        /// </summary>
        private void LeftShift(int position, int numberOfPos)
        {
            for (int i = position; i < Length; i++)
            {
                if (i - numberOfPos >= 0)
                {
                    _array[i - numberOfPos] = _array[i];
                }
            }

            Length -= numberOfPos;
        }


        /// <summary>
        /// Метод Add, добавляющий в конец массива один элемент. При нехватке места для
        /// добавления элемента, ёмкость массива должна удваиваться.
        /// </summary>
        public void Add(T value) // 4
        {
            IncreaseCapacity(Length + 1);

            _array[Length] = value;
            Length+= 1;
        }

        /// <summary>
        /// Метод AddRange, добавляющий в конец массива содержимое коллекции, реализующей
        /// интерфейс IEnumerable<T>.Обратите внимание, метод должен корректно учитывать число
        /// элементов в коллекции с тем, чтобы при необходимости расширения массива делать это
        /// только один раз вне зависимости от числа элементов в добавляемой коллекции.
        /// </summary>
        public void AddRange(IEnumerable<T> sourse) // 5
        {
            IncreaseCapacity(Length + sourse.Count());

            foreach(var item in sourse)
            {
                _array[Length++] = item;
            }
        } 


        /// <summary>
        /// Метод Remove, удаляющий из коллекции указанный элемент. Метод должен возвращать
        /// true, если удаление прошло успешно и false в противном случае.При удалении элементов
        /// реальная ёмкость массива не должна уменьшаться.
        /// </summary>
        public bool Remove(T value) // 6
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i].Equals(value))
                {
                    LeftShift(i + 1, 1);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Метод Insert, позволяющий добавить элемент в произвольную позицию массива (обратите
        /// внимание, может потребоваться расширить массив). Метод должен возвращать true, если
        /// добавление прошло успешно и false в противном случае.При выходе за границу массива
        /// должно генерироваться исключение ArgumentOutOfRangeException.
        /// </summary>
        public bool Insert(int index, T item) // 7
        {
            if (index < 0 || index > Length)
                throw new ArgumentOutOfRangeException();

            RightShift(index, 1);
            _array[index] = item;
            return true;
        }

        /// <summary>
        /// Метод, реализующий интерфейс IEnumerable.
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод, реализующий интерфейс IEnumerable<T>.
        /// </summary>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Индексатор, позволяющий работать с элементом с указанным номером. При выходе за
        /// границу массива должно генерироваться исключение ArgumentOutOfRangeException.
        /// </summary>
        public T this[int i] // 11
        {
            get
            {
                if (i >= Length || i < 0)
                    throw new ArgumentOutOfRangeException();

                return _array[i];
            }
            set
            {
                if (i >= Length || i < 0)
                    throw new ArgumentOutOfRangeException();

                _array[i] = value;
            }
        }
    }
}
