using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._2._1.Library
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable, IEnumerable<T>
    {
        public CycledDynamicArray(): base() { }

        public CycledDynamicArray(int capacity): base(capacity) { }

        public CycledDynamicArray(IEnumerable<T> source): base(source) { }

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0;; i++)
            {
                yield return this[i % Length];
            }
        }
    }
}
