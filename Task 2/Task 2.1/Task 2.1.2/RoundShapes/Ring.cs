using System;
using Task_2._1._2.Exceptions;

namespace Task_2._1._2.RoundShapes
{
    public class Ring : Figure
    {
        public Point Centre{ get => InnerCircle.Centre; }
        public Circle OutherCircle { get; }
        public Circle InnerCircle { get; }
        public Ring(Point p, int innerR, int outherR) : base("Кольцо")
        {
            if (innerR >= outherR)
                throw new IncorrectRadiusExeption("Внешний радиус должен быть строго больше внутреннего");

            OutherCircle = new Circle(p, outherR);
            InnerCircle = new Circle(p, innerR);
        }

        public override double Length() => OutherCircle.Length() + OutherCircle.Length();
        public override double Area() => Math.PI * Math.Pow(OutherCircle.Radius, 2) - Math.PI * Math.Pow(InnerCircle.Radius, 2);
        public override string ToString()
            => String.Format($"{Name}: центр - {Centre}, внешний радиус - {OutherCircle}, внутренний радиус - {InnerCircle}");
    }
    
}
