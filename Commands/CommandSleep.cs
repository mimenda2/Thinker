﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Thinker.Commands
{
    public class CommandSleep : ICommands
    {
        public void Execute(string opt1)
        {
            Thread.Sleep(int.Parse(opt1));
        }

    }
}
