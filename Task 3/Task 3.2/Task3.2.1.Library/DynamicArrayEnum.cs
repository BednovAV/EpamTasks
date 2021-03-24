using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._2._1.Library
{
    class DynamicArrayEnum<T> : IEnumerator<T>
    {
        private DynamicArray<T> _array;

        private int position = -1;

        public DynamicArrayEnum(DynamicArray<T> array)
        {
            _array = array;
        }

        public T Current
        {
            get
            {
                try
                {
                    return _array[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            position++;
            return (position < _array.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
