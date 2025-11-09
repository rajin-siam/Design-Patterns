using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Subsystems
{
    public class Lights
    {
        public void Dim(int level)
        {
            Console.WriteLine($"Lights: Dimming to {level}%");
        }

        public void On()
        {
            Console.WriteLine("Lights: Turning on");
        }
    }
}
