using System;

namespace Task_2._1._2.Polygons
{
    class Quadrangle : Polygon
    {
        private enum QuadrangleType
        {
            Square,
            Rectangle,
            other
        }
        private QuadrangleType _type;
        public Quadrangle(Point p1, Point p2, Point p3, Point p4) : base("Четырехугольник")
        {
            Points = new Point[] { p1, p2, p3, p4 };

            Line a = new Line(p1, p2);
            Line b = new Line(p2, p3);
            Line c = new Line(p3, p4);
            Line d = new Line(p4, p1);

            if (Line.IsPerpendicular(a, b) || Line.IsPerpendicular(c, d))
            {
                if(a.Length() == b.Length())
                {
                    _type = QuadrangleType.Square;
                    Name += "(квадрат)";
                }
                else
                {
                    _type = QuadrangleType.Rectangle;
                    Name += "(прямоугольник)";
                }
            }
        }

        public override double Area()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
            => String.Format($"{Name}: ({Points[0]}{Points[1]}{Points[2]}{Points[3})");
    }
}
