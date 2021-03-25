using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._2._1.Library.Enumerators;

namespace Task3._2._1.Library
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable, IEnumerable<T>
    {
        public CycledDynamicArray(): base() { }

        public CycledDynamicArray(int capacity): base(capacity) { }

        public CycledDynamicArray(IEnumerable<T> source): base(source) { }

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

        public new IEnumerator<T> GetEnumerator() => new CycledDynamicArrayEnum<T>(this); 
        
    }
}
