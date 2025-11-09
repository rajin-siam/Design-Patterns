using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace CommandPattern.Receivers
{
    public class Fan
    {
        private string location;
        private int speed; // 0 = off, 1 = low, 2 = medium, 3 = high

        public Fan(string location)
        {
            this.location = location;
            this.speed = 0;
        }

        public void High()
        {
            speed = 3;
            Console.WriteLine($"{location} fan is on HIGH");
        }

        public void Medium()
        {
            speed = 2;
            Console.WriteLine($"{location} fan is on MEDIUM");
        }

        public void Low()
        {
            speed = 1;
            Console.WriteLine($"{location} fan is on LOW");
        }

        public void Off()
        {
            speed = 0;
            Console.WriteLine($"{location} fan is OFF");
        }

        public int GetSpeed() => speed;
    }
}