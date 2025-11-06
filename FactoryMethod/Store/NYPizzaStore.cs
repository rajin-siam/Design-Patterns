using FactoryMethod.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Store
{
    public class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            return type.ToLower() switch
            {
                "cheese" => new NYStyleCheesePizza(),
                "pepperoni" => new NYStylePepperoniPizza(),
                "veggie" => new NYStyleVeggiePizza(),
                _ => throw new ArgumentException($"Unknown pizza type: {type}")
            };
        }
    }
}
