using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2.Figures
{
    public abstract class Figure
    {
        public string Name { protected set; get; }
        public Figure(string name) => Name = name;
        public abstract double Length();
        public abstract double Area();
        public abstract override string ToString();
    }
}
