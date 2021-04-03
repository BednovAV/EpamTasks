using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2._2._1.GameLogic.Interfaces;

namespace Task2._2._1.GameLogic.Entities
{
    abstract public class GameObject : IGameObject
    {
        public Point Location => throw new NotImplementedException();
    }
}
