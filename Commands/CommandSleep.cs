using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thinker.Commands
{
    public class CommandSleep : ICommands
    {
        public async Task Execute(string opt1)
        {
            Thread.Sleep(int.Parse(opt1));

            await Task.Delay(0);
        }

    }
}
