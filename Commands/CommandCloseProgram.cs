using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading;
using WindowsInput;

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
                    var inputSimulator = new InputSimulator();
                    inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_N);
                    Thread.Sleep(1500);
                    inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_N);
                    //process.Kill();
                }
            }
        }
    }
}
