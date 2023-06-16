using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thinker.Commands
{
    public class CommandExecuteFile : ICommands
    {
        public async Task Execute(string opt1)
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
