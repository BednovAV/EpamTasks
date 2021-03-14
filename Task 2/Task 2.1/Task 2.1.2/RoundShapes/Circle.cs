using System;

namespace Task_2._1._2.RoundShapes
{
    public class Circle : Figure
    {
        public Point Centre { get; }
        public int Radius { get; }
        public Circle(Point p, int r) : base("Окружность")
        {
            Centre = p;
            Radius = r;
        }

        public override double Length() => 2 * Math.PI * Radius;
        public override double Area() => 0;
        public override string ToString()
            => String.Format($"{Name}: центр - {Centre}, радиус - {Radius}");
    }
}
