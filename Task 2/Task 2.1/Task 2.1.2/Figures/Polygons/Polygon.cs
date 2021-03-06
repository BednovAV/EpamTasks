﻿using System.Linq;
using Task_2._1._2.Figures.Exceptions;

namespace Task_2._1._2.Figures.Polygons
{
    public abstract class Polygon : Figure
    {
        protected Point[] Points { set; get; }

        public Polygon(string name, params Point[] points) : base(name)
        {
            Points = points;

            if (Points.Distinct().Count() < Points.Length)
                throw new IdenticalPointsExeption("Многоугольник не может содержать одинаковые точки");
        }
        public override double Length()
        {
            if (Points.Length > 1) // if point is 1, returns 0
            {
                double len = Point.Distance(Points.First(), Points.Last());
                if (Points.Length > 2) // if more then 2, count other lines
                {
                    for (int i = 0; i < Points.Length - 1; i++)
                    {
                        len += Point.Distance(Points[i], Points[i + 1]);
                    }
                }
                return len;
            }
            else
            {
                return 0;
            }
        }
    }
}
