using System;

namespace Task_2._1._2.Figures.Polygons
{
    class Line : Polygon
    {
        private const double EPS = 0.000001d;
        public Point A { get => Points[0]; }
        public Point B { get => Points[1]; }
        public Line(Point p1, Point p2) : base("Линия", p1, p2) { }

        public override double Area() => 0;
        public override string ToString()
            => String.Format($"{Name}: [{A}{B}]");

        public Point GetVector()
        {
            int x = A.X - B.X;
            int y = A.Y - B.Y;

            return new Point(x, y);
        }
        public static double DotProduct(Line line1, Line line2)
        {
            Point vector1 = line1.GetVector();
            Point vector2 = line2.GetVector();

            return (vector1.X * vector2.X) + (vector1.Y * vector2.Y);
        }
        public static bool ArePerpendicular(Line line1, Line line2) => DotProduct(line1, line2) == 0;
        public static bool AreParallel(Line line1, Line line2)
        {
            Point vector1 = line1.GetVector();
            Point vector2 = line2.GetVector();

            if (vector1.X == 0 || vector1.Y == 0 || vector2.X == 0 || vector2.Y == 0)
            {
                return (vector1.X == 0 && vector2.X == 0) ||
                       (vector1.Y == 0 && vector2.Y == 0);
            }
            else
            {
                return Math.Abs((double)vector1.X / vector2.X - (double)vector1.Y / vector2.Y) < EPS;
            }
        }
    }
}
