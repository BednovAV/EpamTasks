using System;
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
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
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
            Length = _array.Length;
        }


        /// <summary>
        /// Возможность ручного изменения значения Capacity с сохранением уцелевших данных
        /// (данные за пределами новой Capacity сохранять не нужно).
        /// </summary>
        public void SetCapacity(int newCapacity) // 2*
        {
            if (newCapacity < 0)
                throw new ArgumentException("Capacity must be greater than 0");

            if (Capacity == newCapacity)
                return;

            T[] newArray = new T[newCapacity];
            int newLength = Length > newCapacity ? newCapacity : Length;

            Array.Copy(_array, newArray, newLength);

            Length = newLength;
            _array = newArray;
        }

        /// <summary>
        /// Метод Add, добавляющий в конец массива один элемент. При нехватке места для
        /// добавления элемента, ёмкость массива должна удваиваться.
        /// </summary>
        public void Add(T value) // 4
        {
            EnsureCapacity(Length + 1);

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
            var sourseArray = sourse.ToArray();

            EnsureCapacity(Length + sourseArray.Length);

            Array.Copy(sourseArray, 0, _array, Length, sourseArray.Length);
            Length += sourseArray.Length;
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
        /// Добавить метод ToArray, возвращающий новый массив (обычный), содержащий все
        /// содержащиеся в текущем динамическом массиве объекты.
        /// </summary>
        public T[] ToArray() // 4*
        {
            T[] newArray = new T[Length];

            Array.Copy(_array, newArray, Length);

            return newArray;
        }


        /// <summary>
        /// Метод, реализующий интерфейс IEnumerable.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator(); // 10

        /// <summary>
        /// Метод, реализующий интерфейс IEnumerable<T>.
        /// </summary>
        public virtual IEnumerator<T> GetEnumerator() // 10
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        /// <summary>
        /// Реализовать интерфейс ICloneable для создания копии массива.
        /// </summary>
        public object Clone() // 3*
        {
            DynamicArray<T> dyClone = new DynamicArray<T>(Capacity);
            dyClone.AddRange(this);

            return dyClone;
        }

        /// <summary>
            /// Индексатор, позволяющий работать с элементом с указанным номером. При выходе за
            /// границу массива должно генерироваться исключение ArgumentOutOfRangeException.
            /// * Доступ к элементам с конца при использовании отрицательного индекса (−1: последний,
            /// −2: предпоследний и т.д.).
            /// </summary>
        public T this[int index] // 11
        {
            get
            {
                index = ResolveIndex(index);

                return _array[index];
            }
            set
            {
                index = ResolveIndex(index);

                _array[index] = value;
            }
        }

        /// <summary>
        /// Check and return correct index
        /// </summary>
        private int ResolveIndex(int index)
        {
            if (index >= Length || index < 0 - Length)
                throw new ArgumentOutOfRangeException();

            if (index >= 0)
            {
                return index;
            }
            else
            {
                return index + Length;
            }
        } //1*

        /// <summary>
        /// The method must be called before each addition to the array.
        /// Increases the capacity to the required value, if needed.
        /// (The array will grow as well)
        /// </summary>
        private void EnsureCapacity(int requiredValue) // 2*
        {
            if (requiredValue <= Capacity)
                return;

            int newCapacity = requiredValue * 2;

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
            EnsureCapacity(Length + numberOfPos);

            Array.Copy(_array, position, _array, position + numberOfPos, Length - position);
            Length += numberOfPos;

            // write the default values ​​in the vacated cells
            Array.Fill(_array, default(T), position, numberOfPos);
        }

        /// <summary>
        /// The method shifts the elements of the array,
        /// starting from the specified position, to the left by the specified number of positions.
        /// (Elements shifted to the left of the array are removed)
        /// </summary>
        public void LeftShift(int position, int numberOfPos)
        {
            int insertPosition = position - numberOfPos < 0? 0 : position - numberOfPos;

            Array.Copy(_array, position, _array, insertPosition, Length - position);

            //for (int i = position; i < Length; i++)
            //{
            //    if (i - numberOfPos >= 0)
            //    {
            //        _array[i - numberOfPos] = _array[i];
            //    }
            //}

            Length -= numberOfPos;
        }
    }
}
