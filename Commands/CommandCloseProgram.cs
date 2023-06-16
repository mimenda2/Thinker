using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading;
using WindowsInput;
using System.Threading.Tasks;
using WindowsInput.Events;

namespace Thinker.Commands
{
    public class CommandCloseProgram : ICommands
    {
        public async Task Execute(string opt1)
        {
            Process[] runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                if (process.ProcessName.ToUpper().Equals(opt1.ToUpper()))
                {
                    process.CloseMainWindow();
                    Thread.Sleep(2000);
                    await WindowsInput.Simulate.Events()
                        .Click(KeyCode.N).Wait(1000)
                        .ClickChord(KeyCode.N).Wait(1000)
                        .Invoke();
                }
            }
        }
    }
}
