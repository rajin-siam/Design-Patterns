using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Subsystems
{
    public class Projector
    {
        public void On()
        {
            Console.WriteLine("Projector: Turning on");
        }

        public void SetWideScreenMode()
        {
            Console.WriteLine("Projector: Setting widescreen mode (16:9)");
        }

        public void Off()
        {
            Console.WriteLine("Projector: Turning off");
        }
    }
}