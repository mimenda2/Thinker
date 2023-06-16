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
    public class CommandMouseClick : ICommands
    {
        public async Task Execute(string opt1)
        {
                switch (opt1)
                {
                    case "0":
                        await WindowsInput.Simulate.Events()
                            .Click(ButtonCode.Left)
                            .Invoke();
                    break;
                    case "1":
                        await WindowsInput.Simulate.Events()
                            .DoubleClick(ButtonCode.Left)
                            .Invoke();
                        break;
                    case "2":
                        await WindowsInput.Simulate.Events()
                            .DoubleClick(ButtonCode.Right)
                            .Invoke();
                        break;
                }
            }
        }
    }
}
