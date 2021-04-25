using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3._3
{
    public class Pizza
    {
        public PizzaType Type { get; }

        public Pizza(PizzaType type) => Type = type;
    }

    public enum PizzaType
    {
        Classic,
        Pepperoni,
        Margarita
    }
}
