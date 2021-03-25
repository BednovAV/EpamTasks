using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._2._1.Library.Enumerators
{
    public class CycledDynamicArrayEnum<T> : DynamicArrayEnum<T>, IEnumerator<T>
    {
        public CycledDynamicArrayEnum(CycledDynamicArray<T> array) : base(array) { }

        public new bool MoveNext()
        {
            position++;

            if (position == _array.Length)
            {
                position = 0;
            }
            return (true);
        }
    }
}
