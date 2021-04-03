using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._2._1.GameLogic.Interfaces
{
    public interface IMap
    {
        int Width { get; }
        int Height { get; }
        IPlayer Player { get; }
        Dictionary<Point, IBarrier> Barriers { get; }
        Dictionary<Point, IBonus> Bonuses { get; }
        Dictionary<Point, IEnemy> Enemies { get; }
        Dictionary<Point, IGameObject> GameObjects { get; }
    }
}
