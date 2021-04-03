using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._2._1.GameLogic.Interfaces
{
    public interface IPlayer
    {
        Point Location { get; }
        public int HP { get; }
        void Move(int x, int y);
        void GetDamage(int damage);
        void GetBonusHP(int bonusHP);

    }
}
