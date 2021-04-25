using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3._2._1.Library;

namespace Task_3._1._1
{
    internal class GameLogic
    {
        private DynamicArray<int> _players;

        /// <summary>
        /// Returns a sequence of members
        /// </summary>
        public IEnumerable<int> Members { get => _players; }

        /// <summary>
        /// Returns a count of members
        /// </summary>
        public int Count { get => _players.Length; }

        private int Current { get; set; }


        public GameLogic(int numberOfPlayers)
        {
            if (numberOfPlayers < 0)
                throw new ArgumentException("The number of players must be positive");

            _players = new DynamicArray<int>(Enumerable.Range(1, numberOfPlayers));
            Current = -1;
        }

        private int IndexHelper(int index) => index % _players.Length;

        /// <summary>
        /// Simulated game step
        /// </summary>
        public int Step(int stepWidth)
        {
            if (Count < stepWidth)
                throw new ArgumentException("Step width can not be more than number of players");

            if (Count != 0)
            {
                Current = IndexHelper(Current + stepWidth - 1);

                int deleted = _players[IndexHelper(Current + 1)];

                _players.Remove(_players[IndexHelper(Current + 1)]);

                return deleted;
            }
            else
            {
                return -1;
            }
        }


    }
}
