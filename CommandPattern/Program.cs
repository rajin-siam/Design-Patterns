using CommandPattern.Commands;
using CommandPattern.Invokers;
using CommandPattern.Receivers;
using System;

namespace CommandPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Command Pattern Demo - Home Automation ===\n");

            // Create receivers
            Light livingRoomLight = new Light("Living Room");
            Light bedroomLight = new Light("Bedroom");
            Fan livingRoomFan = new Fan("Living Room");

            // Create commands
            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

            LightOnCommand bedroomLightOn = new LightOnCommand(bedroomLight);
            LightOffCommand bedroomLightOff = new LightOffCommand(bedroomLight);

            FanHighCommand livingRoomFanHigh = new FanHighCommand(livingRoomFan);
            FanOffCommand livingRoomFanOff = new FanOffCommand(livingRoomFan);

            // Create invoker
            RemoteControl remote = new RemoteControl();

            // Set commands
            remote.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
            remote.SetCommand(1, bedroomLightOn, bedroomLightOff);
            remote.SetCommand(2, livingRoomFanHigh, livingRoomFanOff);

            // Test the remote
            Console.WriteLine("--- Testing Remote Control ---");
            remote.OnButtonPressed(0);
            remote.OffButtonPressed(0);
            Console.WriteLine();

            remote.OnButtonPressed(1);
            remote.OnButtonPressed(2);
            Console.WriteLine();

            Console.WriteLine("--- Testing Undo ---");
            remote.UndoButtonPressed();
            remote.UndoButtonPressed();
            remote.UndoButtonPressed();
            Console.WriteLine();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}