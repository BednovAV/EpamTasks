using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2
{
    public class User
    {
        public string Name { get; }
        private List<Figure> _figures;
        public IEnumerable<Figure> Figures { get => _figures; }
        public User(string name)
        {
            Name = name;
            _figures = new List<Figure>();
        }

        public void AddFigure(Figure figure) => _figures.Add(figure);

        public void RemoveAll() => _figures.Clear();

    }
}
