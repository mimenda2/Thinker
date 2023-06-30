using System;
using System.Diagnostics;
using System.IO;
using Thinker.Commands;

namespace Thinker
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args?.Length == 1)
            {
                DateTime startTime = DateTime.Now;
                var lines = File.ReadAllLines(args[0]);
                bool repeat = true;
                while(repeat)
                {
                    repeat = false;
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("-")) // stop program
                            break;
                        if (string.IsNullOrEmpty(line))
                            continue;
                        if (line.IndexOf(' ') < 0 || line.StartsWith("/")) // ignore comments
                            continue;
                        var cmdStr = line.Substring(0, line.IndexOf(' '));
                        if (cmdStr == "LOOP")
                        {
                            repeat = true;
                            break;
                        }
                        var cmdOpt1 = line.Substring(line.IndexOf(' ') + 1);
                        ICommands cmd = Activator.CreateInstance(
                            Type.GetType($"Thinker.Commands.Command{cmdStr}"), null) as ICommands;
                        Trace.WriteLine($"EXECUTE {cmdStr}, parameter {cmdOpt1}");
                        cmd.Execute(cmdOpt1);
                    }
                }

                TimeSpan dif = DateTime.Now - startTime;
                Console.WriteLine("Time to execute: " + dif.ToString("mm:ss"));
            }
        }
    }
}
