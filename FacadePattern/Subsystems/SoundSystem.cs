using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Subsystems
{
    public class SoundSystem
    {
        public void On()
        {
            Console.WriteLine("Sound System: Turning on");
        }

        public void SetVolume(int level)
        {
            Console.WriteLine($"Sound System: Setting volume to {level}");
        }

        public void SetSurroundSound()
        {
            Console.WriteLine("Sound System: Enabling 5.1 surround sound");
        }

        public void Off()
        {
            Console.WriteLine("Sound System: Turning off");
        }
    }
}
