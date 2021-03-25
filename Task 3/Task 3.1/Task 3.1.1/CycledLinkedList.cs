using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._1._1
{
    /// <summary>
    /// Собственная версия двусвязного списка, оптимизированная для задания
    /// </summary>
    public class CycledLinkedList
    {
        private class ListNode
        {
            public int Number { get; set; }

            public ListNode Next { get; set; }

            public ListNode Prev { get; set; }

            public ListNode(int value) => Number = value;
        }

        private ListNode First { get; set; }
        private ListNode Last { get; set; }

        public int Count { get; private set; }
        //public int Current { get; set; }

        public CycledLinkedList(int count)
        {
            foreach (var item in Enumerable.Range(1, count))
            {
                Add(item);
            }
        }

        private void Add(int value)
        {
            var newNode = new ListNode(value);

            if (Count == 0)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                newNode.Next = First;
                newNode.Prev = Last;
                Last.Next = newNode;
                First.Prev = newNode;

                Last = newNode;
            }

            Count += 1;
        }

        private int Remove(ListNode node)
        {
            node.Prev = node.Next;
            node.Next = node.Prev;

            if (node == First)
                First = node.Next;

            if (node == Last)
                Last = node.Prev;

            return node.Number;
        }


        public IEnumerable<int> GetValues()
        {
            var result = new List<int>();

            var cur = First;

            do
            {
                result.Add(cur.Number);
                cur = cur.Next;
            } while (cur != First);

            return result;
        }
    }
}
