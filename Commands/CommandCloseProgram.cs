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
        public void Execute(string opt1)
        {
            Process[] runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                if (process.ProcessName.ToUpper().Equals(opt1.ToUpper()))
                {
                    process.CloseMainWindow();
                    Thread.Sleep(2000);
                    Task.Run(() => WindowsInput.Simulate.Events()
                        .Click(KeyCode.N).Wait(1000)
                        .ClickChord(KeyCode.N).Wait(1000)
                        .Invoke()).Wait();
                }
            }
        }
    }
}
