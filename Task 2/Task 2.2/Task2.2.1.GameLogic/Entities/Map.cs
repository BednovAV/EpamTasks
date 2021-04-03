using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2._2._1.GameLogic.Interfaces;

namespace Task2._2._1.GameLogic.Entities
{
    public class Map : IMap
    {
        public int Width => throw new NotImplementedException();

        public int Height => throw new NotImplementedException();

        public IPlayer Player => throw new NotImplementedException();

        public Dictionary<Point, IBarrier> Barriers => throw new NotImplementedException();

        public Dictionary<Point, IBonus> Bonuses => throw new NotImplementedException();

        public Dictionary<Point, IEnemy> Enemies => throw new NotImplementedException();

        public Dictionary<Point, IGameObject> GameObjects => throw new NotImplementedException();
    }
}
