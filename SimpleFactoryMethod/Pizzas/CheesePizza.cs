using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Pizzas
{
    public class CheesePizza : Pizza
    {
        public CheesePizza() => Name = "Cheese Pizza";
    }
}
