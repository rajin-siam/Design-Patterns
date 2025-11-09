using CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Invokers
{
    public class RemoteControl
    {
        private ICommand[] onCommands;
        private ICommand[] offCommands;
        private Stack<ICommand> undoStack;

        public RemoteControl()
        {
            onCommands = new ICommand[7];
            offCommands = new ICommand[7];
            undoStack = new Stack<ICommand>();

            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonPressed(int slot)
        {
            onCommands[slot].Execute();
            undoStack.Push(onCommands[slot]);
        }

        public void OffButtonPressed(int slot)
        {
            offCommands[slot].Execute();
            undoStack.Push(offCommands[slot]);
        }

        public void UndoButtonPressed()
        {
            if (undoStack.Count > 0)
            {
                ICommand command = undoStack.Pop();
                command.Undo();
            }
            else
            {
                Console.WriteLine("Nothing to undo!");
            }
        }
    }
}