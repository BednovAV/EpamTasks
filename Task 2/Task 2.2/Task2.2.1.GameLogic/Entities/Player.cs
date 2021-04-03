using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2._2._1.GameLogic.Interfaces;

namespace Task2._2._1.GameLogic.Entities
{
    public class Player : GameObject, IPlayer
    {
        public int HP => throw new NotImplementedException();

        public void GetBonusHP(int bonusHP)
        {
            throw new NotImplementedException();
        }

        public void GetDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public void Move(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
