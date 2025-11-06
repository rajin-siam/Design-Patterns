using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Pizzas
{
    public abstract class Pizza
    {
        public string Name { get; protected set; }

        public virtual void Prepare() => Console.WriteLine($"Preparing {Name}");
        public virtual void Bake() => Console.WriteLine("Baking for 25 minutes at 350");
        public virtual void Cut() => Console.WriteLine("Cutting the pizza into diagonal slices");
        public virtual void Box() => Console.WriteLine("Placing pizza in official PizzaStore box");
    }
}
