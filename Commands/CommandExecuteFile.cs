using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Thinker.Commands
{
    public class CommandExecuteFile : ICommands
    {
        public void Execute(string opt1)
        {
            try
            {
                Process.Start(@opt1);
            }
            catch
            {
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(@opt1)
                {
                    UseShellExecute = true
                };
                p.Start();
            }
        }

    }
}
