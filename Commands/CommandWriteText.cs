using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using WindowsInput;
using System.Windows.Forms;

namespace Thinker.Commands
{
    public class CommandWriteText : ICommands
    {
        public void Execute(string opt1)
        {
            var inputSimulator = new InputSimulator();
            if (opt1.Length == 1)
                inputSimulator.Keyboard.TextEntry(opt1[0]);
            else
                inputSimulator.Keyboard.TextEntry(opt1);
            inputSimulator.Keyboard.Sleep(1000);
        }

    }
}
