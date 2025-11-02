using SimUDuck.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    class RedheadDuck : Duck
    {
        public RedheadDuck()
        {
                FlyBehavior = new FlyWithWings();
                QuackBehavior = new Quack();
        }
        public override void display()
        {
            Console.WriteLine("I'm a real Redhead duck");
        }

    }
}
