using System;

namespace Task_2._1._2.RoundShapes
{
    public class Round : Circle
    {
        public Round(Point p, int r) : base(p, r) => Name = "Круг";
        public override double Area() => Math.PI * Radius * Radius; 
    }
}
