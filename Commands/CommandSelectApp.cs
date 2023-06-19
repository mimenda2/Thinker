using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thinker.Commands
{
    public class CommandSelectApp : ICommands
    {
        public async Task Execute(string opt1)
        {
            await Task.Run(() =>
            {
                Process[] runningProcesses = Process.GetProcesses();
                var names = runningProcesses.Select(x => x.ProcessName).ToList();
                foreach (Process process in runningProcesses)
                {
                    if (process.ProcessName.ToUpper().Equals(opt1.ToUpper()))
                    {
                        NativeWin32.ShowWindowAsync(new HandleRef(null, process.MainWindowHandle), (int)NativeWin32.SW.SHOW);
                        NativeWin32.SetForegroundWindow(process.MainWindowHandle);
                    }
                }
            });
        }
    }
}
