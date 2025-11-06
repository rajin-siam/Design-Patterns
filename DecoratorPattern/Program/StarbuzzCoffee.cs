using DecoratorPattern.Beverages;
using DecoratorPattern.Condiments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Program
{
    public class StarbuzzCoffee
    {
        public static void Main()
        {
            Beverage bevarage = new Espresso();
            Console.WriteLine(bevarage.GetDescription() + " $" + bevarage.Cost());

            Beverage bevarage2 = new DarkRoast();
            bevarage2 = new Mocha(bevarage2);
            bevarage2 = new Mocha(bevarage2);
            bevarage2 = new Whip(bevarage2);

            Console.WriteLine(bevarage2.GetDescription() + " $" + bevarage2.Cost());

            Beverage bevarage3 = new HouseBlend();
            bevarage3 = new Soy(bevarage3); 
            bevarage3 = new Mocha(bevarage3);
            bevarage3 = new Whip(bevarage3);
            Console.WriteLine(bevarage3.GetDescription() + " $" + bevarage3.Cost());

        }
    }
}
