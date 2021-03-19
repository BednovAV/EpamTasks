using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2._2._1.GameLogic.Interfaces;

namespace Task2._2._1.GameLogic.Entities
{
    public class Map
    {
        public int Width { get; }
        public int Height { get; }
        public Player Player { get; set; }        
        public Dictionary<Point, IBarrier> Barriers { get; }
        public Dictionary<Point, IBonus> Bonuses { get; }
    }
}
