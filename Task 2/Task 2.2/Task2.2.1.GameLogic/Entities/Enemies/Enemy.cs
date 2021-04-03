using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2._2._1.GameLogic.Interfaces;

namespace Task2._2._1.GameLogic.Entities.Enemies
{
    public abstract class Enemy : GameObject, IEnemy
    {
        public int Damage => throw new NotImplementedException();
        public abstract void Move(int x, int y);
    }
}
