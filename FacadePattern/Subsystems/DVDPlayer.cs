using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Subsystems
{
    public class DVDPlayer
    {
        public void On()
        {
            Console.WriteLine("DVD Player: Turning on");
        }

        public void Play(string movie)
        {
            Console.WriteLine($"DVD Player: Playing \"{movie}\"");
        }

        public void Stop()
        {
            Console.WriteLine("DVD Player: Stopping");
        }

        public void Off()
        {
            Console.WriteLine("DVD Player: Turning off");
        }
    }
}
