using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck.Behaviors
{
    public class FlyWithWings : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I'm flying with wings!");
        }
    }
}
