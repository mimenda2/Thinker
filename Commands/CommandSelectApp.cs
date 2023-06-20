using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Thinker.Commands
{
    public class CommandSelectApp : ICommands
    {
        public void Execute(string opt1)
        {
            int openOption = (int)NativeWin32.SW.SHOWNORMAL;
            if (opt1.Contains("::"))
            {
                var keys = opt1.Split("::", StringSplitOptions.RemoveEmptyEntries);
                opt1 = keys[0];
                openOption = int.Parse(keys[1]);
            }
            Process[] runningProcesses = Process.GetProcesses();
            //var names = runningProcesses.Select(x => x.ProcessName).ToList();
            foreach (Process process in runningProcesses)
            {
                if (process.ProcessName.ToUpper().Equals(opt1.ToUpper()))
                {
                    NativeWin32.ShowWindowAsync(new HandleRef(null, process.MainWindowHandle), openOption);
                    NativeWin32.SetForegroundWindow(process.MainWindowHandle);
                }
            }
        }
    }
}
