using FactoryMethod.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Store
{
    public class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            return type.ToLower() switch
            {
                "cheese" => new ChicagoStyleCheesePizza(),
                "pepperoni" => new ChicagoStylePepperoniPizza(),
                "veggie" => new ChicagoStyleVeggiePizza(),
                _ => throw new ArgumentException($"Unknown pizza type: {type}")
            };
        }
    }
}
