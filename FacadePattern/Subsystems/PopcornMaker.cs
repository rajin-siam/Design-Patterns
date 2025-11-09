using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Subsystems
{
    public class PopcornMaker
    {
        public void On()
        {
            Console.WriteLine("Popcorn Maker: Turning on");
        }

        public void Pop()
        {
            Console.WriteLine("Popcorn Maker: Popping popcorn!");
        }

        public void Off()
        {
            Console.WriteLine("Popcorn Maker: Turning off");
        }
    }
}
