using System;
using System.Diagnostics;
using System.IO;
using Thinker.Commands;

namespace Thinker
{
    class Program
    {
        static string traceFile = "";
        static void Main(string[] args)
        {
            if (args?.Length > 0)
            {
                ThinkerParameters arguments = CommandLine.Parser.Default.ParseArguments<ThinkerParameters>(args).Value;
                DateTime startTime = DateTime.Now;
                do
                {
                    try
                    {
                        AddTrace("Start iteration");
                        DateTime startIterationTime = DateTime.Now;
                        DoSteps(arguments, startTime);
                        TimeSpan dif = DateTime.Now - startIterationTime;
                        AddTrace("End iteration, time to execute iteration: " + dif.ToString());
                        if (arguments.Duration > 0 &&
                            (DateTime.Now - startTime).Seconds > arguments.Duration)
                        {
                            AddTrace("Max duration reached");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        AddTrace($"General error: " + ex.Message);
                    }
                } while (arguments.Loop);

            }
        }
        static void AddTrace(string text)
        {
            lock (traceFile)
            {
                if (string.IsNullOrEmpty(traceFile))
                {
                    traceFile = Path.Combine(Path.GetDirectoryName(
                        System.Reflection.Assembly.GetExecutingAssembly().Location), "thinkertraces.log");
                    if (!File.Exists(traceFile))
                        File.Create(traceFile);
                }

                File.AppendAllText(traceFile,
                    $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}: {text}{Environment.NewLine}");
            }
        }
        static void DoSteps(ThinkerParameters arguments, DateTime startTime)
        {
            // read the file in each iteration to aply changes
            var lines = File.ReadAllLines(arguments.FileName);
            foreach (var line in lines)
            {
                if (arguments.Duration > 0 &&
                    (DateTime.Now - startTime).Seconds > arguments.Duration)
                {
                    AddTrace("Max duration reached");
                    return;
                }

                if (line.StartsWith("-")) // stop program
                    break;
                if (string.IsNullOrEmpty(line))
                    continue;
                if (line.IndexOf(' ') < 0 || line.StartsWith("/")) // ignore comments
                    continue;
                var cmdStr = line.Substring(0, line.IndexOf(' '));
                var cmdOpt1 = line.Substring(line.IndexOf(' ') + 1);
                ICommands cmd = Activator.CreateInstance(
                    Type.GetType($"Thinker.Commands.Command{cmdStr}"), null) as ICommands;
                //Trace.WriteLine($"EXECUTE {cmdStr}, parameter {cmdOpt1}");
                try
                {
                    cmd.Execute(cmdOpt1);
                }
                catch (Exception ex)
                {
                    AddTrace($"Step error: " + ex.Message);
                }
            }
        }
    }
}
