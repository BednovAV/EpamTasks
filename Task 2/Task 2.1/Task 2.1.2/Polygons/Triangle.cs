using System;

namespace Task_2._1._2.Polygons
{
    public class Triangle : Polygon
    {
        public Triangle(Point p1, Point p2, Point p3) : base("Треугольник", p1, p2, p3) { }

        public override double Area()
        {
            double a = Point.Distance(Points[0], Points[1]);
            double b = Point.Distance(Points[1], Points[2]);
            double c = Point.Distance(Points[0], Points[2]);
            double semiArea = (a + b + c) / 2;

            return Math.Sqrt(semiArea * (semiArea - a) * (semiArea - b) * (semiArea - c));
        }
        public override string ToString()
            => String.Format($"{Name}: [{Points[0]}{Points[1]}{Points[2]}]");
    }
}
