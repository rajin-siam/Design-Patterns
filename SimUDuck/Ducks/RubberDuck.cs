using SimUDuck.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    public class RubberDuck : Duck
    {
        public RubberDuck() 
        {
            QuackBehavior = new Squeak();
            FlyBehavior = new FlyNoWay();
        }
        public override void display()
        {
            Console.WriteLine("I'm a Rubber duck");
        }

    }
}
