using SimUDuck.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck.Ducks
{
    public class DecoyDuck : Duck
    {
        public DecoyDuck()
        {
            FlyBehavior = new FlyNoWay();
            QuackBehavior = new MuteQuack();
        }
        public override void display()
        {
            Console.WriteLine("I'm a Decoy Duck");
        }
    }
}
