using System;

namespace Task2._2._1.GameLogic.Interfaces
{
    public interface IGame
    {
        public IMap Map { get; }
        void Start();
        void NextMove();
    }
}
