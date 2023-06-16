using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using WindowsInput;
using System.Windows.Forms;
using System.Threading.Tasks;
using WindowsInput.Events;

namespace Thinker.Commands
{
    public class CommandWriteText : ICommands
    {
        public async Task Execute(string opt1)
        {
            if (opt1.StartsWith("::"))
            {
                var keys = opt1.Split("::", StringSplitOptions.RemoveEmptyEntries);
                KeyCode[] codes = new KeyCode[keys.Length];
                for(int i = 0; i < keys.Length; i++)
                    codes[i] = (KeyCode)Enum.Parse(typeof(KeyCode), keys[i]);

                await WindowsInput.Simulate.Events()
                                .ClickChord(codes).Wait(1000)
                                .Invoke();
            }
            else
                await WindowsInput.Simulate.Events()
                                .Click(opt1).Wait(Math.Max(1000, 500*opt1.Length))
                                .Invoke();
        }

    }
}
