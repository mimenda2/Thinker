﻿using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Thinker.Commands;
using WindowsInput.Events;

namespace Thinker
{
    class Program
    {

        static async Task Main(string[] args)
        {
            if (args?.Length == 1)
            {
                CommandSleep cmdSleep = new CommandSleep();
                var lines = File.ReadAllLines(args[0]);
                foreach(var line in lines)
                {
                    if (line.StartsWith("-"))
                        break;
                    if (string.IsNullOrEmpty(line))
                        continue;
                    if (line.IndexOf(' ') < 0)
                        continue;
                    var cmdStr = line.Substring(0, line.IndexOf(' '));
                    var cmdOpt1 = line.Substring(line.IndexOf(' ') + 1);
                    ICommands cmd = Activator.CreateInstance(
                        Type.GetType($"Thinker.Commands.Command{cmdStr}"), null) as ICommands;
                    Trace.WriteLine($"EXECUTE {cmdStr}, parameter {cmdOpt1}");
                    await cmd.Execute(cmdOpt1);
                }
            }
        }
    }
}