using System;

namespace Task_2._1._2.Figures.RoundShapes
{
    public enum Color
    {
        White,
        Red,
        Green,
        Blue,
        Black
    }
    public class Round : Circle
    {
        private Color _roundColor;
        public Color RoundColor 
        {
            get => _roundColor;
            set
            {
                Name = value switch
                {
                    Color.White => "Круг(белый)",
                    Color.Red => "Круг(Красный)",
                    Color.Green => "Круг(зеленый)",
                    Color.Blue => "Круг(голубой)",
                    Color.Black => "Круг(черный)"
                };
                _roundColor = value;
            }
        }
        public Round(Point p, int r, Color color = Color.White) : base(p, r) => RoundColor = color;
        public override double Area() => Math.PI * Radius * Radius;
    }
}
