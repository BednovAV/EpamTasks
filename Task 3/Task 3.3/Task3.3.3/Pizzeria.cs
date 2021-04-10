using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3._3._3
{
    public class Pizzeria
    {
        public Pizza TastyPizza { get; private set; }

        public event Action<Pizzeria> PizzaIsReady = delegate { };

        public void Order(PizzaType pizzaType)
        {
            Console.WriteLine($"[Пиццерия] Заказ на пиццу \"{pizzaType}\" получен");
            Cook(pizzaType);
        }

        private void Cook(PizzaType pizzaType)
        {
            Console.WriteLine($"[Пиццерия] Приготовление пиццы \"{pizzaType}\" начато");
            
            Thread.Sleep(new TimeSpan(0, 0, 3));
            TastyPizza = new Pizza(pizzaType);

            Console.WriteLine($"[Пиццерия] Пицца \"{pizzaType}\" готова");
            PizzaIsReady?.Invoke(this);
        }
    }
}
