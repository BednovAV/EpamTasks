using System;

namespace Task_2._1._2.Polygons
{
    class Line : Polygon
    {
        public Line(Point p1, Point p2) : base("Линия")
            => Points = new Point[] { p1, p2 };

        public override double Area() => 0;
        public override string ToString()
            => String.Format($"{Name}: [{Points[0]}{Points[1]}]");

        public Point GetVector()
        {
            int x = Points[0].X - Points[1].X;
            int y = Points[0].Y - Points[1].Y;

            return new Point(x, y);
        }
        public static double DOT(Line line1, Line line2)
        {
            Point vector1 = line1.GetVector();
            Point vector2 = line2.GetVector();

            return (vector1.X * vector2.X) + (vector1.Y * vector2.Y);
        }
        public static bool IsPerpendicular(Line line1, Line line2) => DOT(line1, line2) == 0;
        public static bool IsParallel(Line line1, Line line2)
        {
            Point vector1 = line1.GetVector();
            Point vector2 = line2.GetVector();

            if (vector1.X == 0 || vector1.Y == 0 || vector2.X == 0 || vector2.Y == 0)
            {
                if ((vector1.X == 0 && vector2.X == 0) ||
                    (vector1.Y == 0 && vector2.Y == 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ((double)vector1.X / vector2.X == (double)vector1.Y / vector2.Y)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
