using System;

namespace Task_2._1._2.Figures.Polygons
{
    class Quadrangle : Polygon
    {
        private enum QuadrangleType
        {
            Square,
            Rectangle,
            Quadrangle
        }
        private readonly QuadrangleType _type;
        public Quadrangle(Point p1, Point p2, Point p3, Point p4) : base("Четырехугольник", p1, p2, p3, p4)
        {

            Line a = new Line(p1, p2);
            Line b = new Line(p2, p3);
            Line c = new Line(p3, p4);
            Line d = new Line(p4, p1);

            if (Line.ArePerpendicular(a, b) || Line.ArePerpendicular(c, d))
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
            else
            {
                _type = QuadrangleType.Quadrangle;
            }
        }

        public override double Area()
            => (double)1 / 2
            * Math.Abs(Points[0].X * Points[1].Y + Points[1].X * Points[2].Y + Points[2].X * Points[3].Y + Points[3].X * Points[0].Y
                - Points[1].X * Points[0].Y - Points[2].X * Points[1].Y - Points[3].X * Points[2].Y - Points[0].X * Points[3].Y);
        public override string ToString()
            => String.Format($"{Name}: [{Points[0]}{Points[1]}{Points[2]}{Points[3]}]");
    }
}
