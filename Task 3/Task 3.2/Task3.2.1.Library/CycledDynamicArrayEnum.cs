using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._2._1.Library
{
    class CycledDynamicArrayEnum<T> : IEnumerator<T>
    {
        private CycledDynamicArray<T> _array;

        private int position = -1;

        public CycledDynamicArrayEnum(CycledDynamicArray<T> array) 
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

            if (position == _array.Length)
            {
                position = 0;
            }
            return true;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
