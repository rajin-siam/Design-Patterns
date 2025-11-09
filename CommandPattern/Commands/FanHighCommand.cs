using CommandPattern.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class FanHighCommand : ICommand
    {
        private Fan fan;
        private int prevSpeed;

        public FanHighCommand(Fan fan)
        {
            this.fan = fan;
        }

        public void Execute()
        {
            prevSpeed = fan.GetSpeed();
            fan.High();
        }

        public void Undo()
        {
            if (prevSpeed == 3) fan.High();
            else if (prevSpeed == 2) fan.Medium();
            else if (prevSpeed == 1) fan.Low();
            else fan.Off();
        }
    }
}
