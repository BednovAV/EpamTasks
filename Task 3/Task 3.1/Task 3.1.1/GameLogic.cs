using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._2._1.Library;

namespace Task_3._1._1
{
    public class GameLogic
    {
        private DynamicArray<int> _members;

        /// <summary>
        /// Returns a sequence of members
        /// </summary>
        public IEnumerable<int> Members { get => _members; }

        /// <summary>
        /// Returns a count of members
        /// </summary>
        public int Count { get => _members.Length; }

        private int Current { get; set; }


        public GameLogic(int numberOfPlayers)
        {
            _members = new DynamicArray<int>(Enumerable.Range(1, numberOfPlayers));
            Current = -1;
        }

        private int IndexHelper(int index) => index % _members.Length;

        /// <summary>
        /// Simulated game step
        /// </summary>
        public int Step(int stepWidth)
        {
            Current = IndexHelper(Current + stepWidth - 1);

            int deleted = _members[IndexHelper(Current + 1)];

            _members.Remove(_members[IndexHelper(Current + 1)]);

            return deleted;
        }


    }
}
