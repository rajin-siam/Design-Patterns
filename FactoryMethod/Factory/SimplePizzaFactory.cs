using FactoryMethod.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Factory
{
    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            Pizza pizza = null;

            switch (type.ToLower())
            {
                case "cheese":
                    pizza = new CheesePizza();
                    break;
                case "pepperoni":
                    pizza = new PepperoniPizza();
                    break;
                case "veggie":
                    pizza = new NYStyleVeggiePizza();
                    break;
                default:
                    Console.WriteLine("Unknown pizza type");
                    break;
            }

            return pizza;
        }
    }
}
