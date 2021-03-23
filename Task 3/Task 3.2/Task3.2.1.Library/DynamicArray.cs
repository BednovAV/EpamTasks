﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._2._1.Library
{
    public class DynamicArray<T>
    {
        private T[] _array;

        public int Length { get; private set; }
        public int Capacity { get => _array.Length; }

        /// <summary>
        /// Конструктор без параметров (создаётся массив ёмкостью 8 элементов).
        /// </summary>
        public DynamicArray()
        {
            _array = new T[8];
            Length = 0;
        }

        /// <summary>
        /// Конструктор с одним целочисленным параметром (создаётся массив указанной ёмкости).
        /// </summary>
        /// <param name="capacity"></param>
        public DynamicArray(int capacity)
        {
            _array = new T[capacity];
            Length = 0;
        }

        /// <summary>
        /// Конструктор, который в качестве параметра принимает коллекцию, реализующую 
        /// интерфейс IEnumerable<T>, создаёт массив нужного размера и копирует в него все
        /// элементы из коллекции.
        /// </summary>
        public DynamicArray(IEnumerable<T> source) 
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
        /// Метод Add, добавляющий в конец массива один элемент. При нехватке места для
        /// добавления элемента, ёмкость массива должна удваиваться.
        /// </summary>
        public void Add(T value)
        {
            IncreaseCapacity(Length + 1);

            _array[Length] = value;
            Length+= 1;
        }

        /// <summary>
        /// Индексатор, позволяющий работать с элементом с указанным номером. При выходе за
        /// границу массива должно генерироваться исключение ArgumentOutOfRangeException.
        /// </summary>
        public T this[int i]
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
