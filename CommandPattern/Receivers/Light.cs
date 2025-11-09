using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommandPattern.Receivers
{
    public class Light
    {
        private string location;
        private bool isOn;

        public Light(string location)
        {
            this.location = location;
            this.isOn = false;
        }

        public void On()
        {
            isOn = true;
            Console.WriteLine($"{location} light is ON");
        }

        public void Off()
        {
            isOn = false;
            Console.WriteLine($"{location} light is OFF");
        }
    }
}