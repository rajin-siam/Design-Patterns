using SimUDuck.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck.Ducks
{
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            FlyBehavior = new FlyWithWings();
            QuackBehavior = new Quack();
        }
        public override void display()
        {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }
}
